using CliqueAgua.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Reflection;

namespace CliqueAgua.Data.Dao
{
    public class DbHelper
    {
        private string _connectionString;
        private string _providerName;
        private DbProviderFactory _dbFactory;
        private DbTransaction _transacao;
        private DbConnection _connection;

        public DbHelper()
        {
            _connectionString = @"Data Source=FERNANDOSCHIMID\SQLSERVER2014;Initial Catalog=ProjetoUnip;Persist Security Info=True;User ID=fernando;Password=172203";
           //_connectionString = @"Data Source=localhost,11433;Initial Catalog=ProjetoUnip;Persist Security Info=True;User ID=sa;Password=sa@2000";
            //_connectionString = "Server=n2.mpsoftwares.com.br,3342;Database=ProjetoUnip;User Id=Unip;Password=unip@102030;";
            _providerName = "System.Data.SqlClient";
            _dbFactory = DbProviderFactories.GetFactory(_providerName);
        }
        
        public void IniciarConexao()
        {
            if (_connection == null || _connection.State != ConnectionState.Open)
            {
                _connection = _dbFactory.CreateConnection();
                _connection.ConnectionString = _connectionString;
                _connection.Open();
            }
        }

        public void EncerrarConexao()
        {
            _connection.Close();
            _connection.Dispose();
        }
        
        public int ExecutarComando(string query)
        {
            DbCommand cmd = _dbFactory.CreateCommand();
            cmd.CommandText = query;
            return ExecutarComando(cmd);
        }

        public object ExecutarConsultaObjeto(string query)
        {
            DbCommand cmd = _dbFactory.CreateCommand();
            cmd.CommandText = query;
            return ExecutarConsultaObjeto(cmd);
        }

        public DataTable ExecutarConsultaDataTable(string query)
        {
            DbCommand cmd = _dbFactory.CreateCommand();
            cmd.CommandText = query;
            return ExecutarConsultaDataTable(cmd);
        }

        private int ExecutarComando(DbCommand cmd)
        {
            cmd.Connection = _connection;
            cmd.Transaction = _transacao;
            int retorno = cmd.ExecuteNonQuery();
            return retorno;
        }

        private DataTable ExecutarConsultaDataTable(DbCommand cmd)
        {
            cmd.Connection = _connection;
            cmd.Transaction = _transacao;
            DataTable retorno = new DataTable();
            DbDataAdapter da = _dbFactory.CreateDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(retorno);
            return retorno;
        }

        private object ExecutarConsultaObjeto(DbCommand cmd)
        {
            cmd.Connection = _connection;
            cmd.Transaction = _transacao;
            object retorno = cmd.ExecuteScalar();
            return retorno;
        }
        
        public long Incluir(string tabela, object objeto)
        {
            try
            {
                if (string.IsNullOrEmpty(tabela))
                    throw new Exception("Não foi informado o nome da tebala para executar o insert.");
                if (objeto == null)
                    throw new Exception("Não foram encontrados dados para executar o insert.");

                string colunas = "", valores = "";

                DbCommand cmd = _dbFactory.CreateCommand();

                foreach (var parametro in GetParametros(objeto))
                {
                    if (parametro.ParameterName == "@Id")
                        continue;
                    colunas += parametro.ParameterName.Replace("@", "") + ",";
                    valores += parametro.ParameterName + ",";
                    cmd.Parameters.Add(parametro);
                }

                colunas = colunas.Substring(0, colunas.Length - 1);
                valores = valores.Substring(0, valores.Length - 1);
                string query = $"insert into {tabela} ({colunas}) values ({valores});";
                if (_providerName == "System.Data.SqlClient") query += $"select IDENT_CURRENT('{tabela}');";
                if (_providerName == "System.Data.MySqlClient") query += $"select LAST_INSERT_ID();";
                cmd.CommandText = query;
                return ExecutarConsultaObjeto(cmd).GetDBInt32();
            }
            catch
            {
                throw;
            }
        }

        public int Alterar(string tabela, object objeto, string filtro)
        {
            try
            {
                if (string.IsNullOrEmpty(tabela))
                    throw new Exception("Não foi informado o nome da tebala para executar o update.");
                if (objeto == null)
                    throw new Exception("Não foram encontrados dados para executar o update.");

                string valores = "";

                DbCommand cmd = _dbFactory.CreateCommand();

                foreach (var parametro in GetParametros(objeto))
                {
                    if (parametro.ParameterName == "@Id")
                        continue;
                    valores += $"{parametro.ParameterName.Replace("@", "")} = {parametro.ParameterName}" + ",";
                    cmd.Parameters.Add(parametro);

                }

                valores = valores.Substring(0, valores.Length - 1);
                string query = $"update {tabela} set {valores}";
                if (!string.IsNullOrEmpty(filtro))
                    query += $" where {filtro}";

                cmd.CommandText = query;
                return ExecutarComando(cmd);
            }
            catch
            {
                throw;
            }
        }

        public int Excluir(string tabela, string filtro)
        {
            try
            {
                if (string.IsNullOrEmpty(tabela))
                    throw new Exception("Não foi informado o nome da tebala para executar o delete.");

                DbCommand cmd = _dbFactory.CreateCommand();

                string query = $"delete from {tabela}";
                if (!string.IsNullOrEmpty(filtro))
                    query += $" where {filtro}";

                cmd.CommandText = query;

                return ExecutarComando(cmd);
            }
            catch
            {
                throw;
            }
        }

        public DataTable Consulta(string tabela, string colunas, string filtro, string classificacao, int? qtdeRegistros)
        {
            try
            {
                if (string.IsNullOrEmpty(tabela))
                    throw new Exception("Não foi informado o nome da tebala para executar o delete.");

                DbCommand cmd = _dbFactory.CreateCommand();

                string topCmd = (qtdeRegistros != null && qtdeRegistros > 0) ? $"top {qtdeRegistros}" : "";
                string fieldsCmd = string.IsNullOrEmpty(colunas) ? "*" : colunas;
                string whereCmd = string.IsNullOrEmpty(filtro) ? "" : " where " + filtro;
                string orderCmd = string.IsNullOrEmpty(classificacao) ? "" : " order by " + classificacao;

                string query = $"select {topCmd} {fieldsCmd} from {tabela} {whereCmd} {orderCmd}";

                cmd.CommandText = query;

                return ExecutarConsultaDataTable(cmd);
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<DbParameter> GetParametros(object objeto)
        {
            try
            {
                List<DbParameter> lista = new List<DbParameter>();
                Type t = objeto.GetType();
                PropertyInfo[] props = t.GetProperties();
                foreach (var prop in props)
                {
                    if (prop.GetIndexParameters().Length == 0)
                    {
                        var par = _dbFactory.CreateParameter();
                        par.ParameterName = "@" + prop.Name;
                        par.Value = prop.GetValue(objeto).SetDBValor();
                        lista.Add(par);
                    }
                }
                return lista;
            }
            catch
            {
                throw;
            }
        }

    }
}
