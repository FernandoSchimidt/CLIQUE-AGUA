using CliqueAgua.Data.Dao;
using CliqueAgua.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Reflection;

namespace CliqueAgua.Data.Controllers
{
    public class ControllerHelper<T> where T : new()
    {
        public DbHelper dbHelper;

        public ControllerHelper()
        {
            dbHelper = new DbHelper();
        }

        private string GetNomeTabela()
        {
            var tipo = new T().GetType();
            TableAttribute atributoTabela = (TableAttribute)Attribute.GetCustomAttribute(tipo, typeof(TableAttribute));
            if (atributoTabela != null && !string.IsNullOrEmpty(atributoTabela.Name))
                return atributoTabela.Name;
            else
                throw new Exception($"Nome da tabela não informado na classe {tipo.Name}");
        }

        public virtual T Gravar(T objeto, long id)
        {
            if (id == 0)
                id = Inserir(objeto);
            else
                Alterar(objeto, id);
            return Consultar(id);
        }

        private long Inserir(T objeto)
        {
            dbHelper.IniciarConexao();
            long id = dbHelper.Incluir(GetNomeTabela(), objeto);
            dbHelper.EncerrarConexao();
            return id;
        }
             
        private void Alterar(T objeto, long id)
        {
            dbHelper.IniciarConexao();
            dbHelper.Alterar(GetNomeTabela(), objeto, $"id = {id}");
            dbHelper.EncerrarConexao();
        }

        public virtual void Excluir(long id)
        {
            dbHelper.IniciarConexao();
            dbHelper.Excluir(GetNomeTabela(), $"id = {id}");
            dbHelper.EncerrarConexao();
        }

        public virtual T Consultar(long id)
        {
            dbHelper.IniciarConexao();
            var retorno = new T();
            var table = dbHelper.Consulta(GetNomeTabela(), null, $"id = {id}", "", null);
            var list = UtilitariosConversaoDados.ConverteDataTableParaList<T>(table);
            if (list.Count > 0)
                retorno = list.FirstOrDefault();
            dbHelper.EncerrarConexao();
            return retorno;
        }
        
        public virtual IEnumerable<T> Listar()
        {
            return Listar(null, null, null);
        }

        public virtual IEnumerable<T> Listar(string filtro, string classificacao, int? qtdeRegistros)
        {
            dbHelper.IniciarConexao();
            var table = dbHelper.Consulta(GetNomeTabela(), null, filtro, classificacao, qtdeRegistros);
            var retorno = ConverteDataTableParaList(table);
            dbHelper.EncerrarConexao();
            return retorno;
        }
        
        public virtual DataTable ListarRaw(string queryConsulta)
        {
            dbHelper.IniciarConexao();
            var retorno = dbHelper.ExecutarConsultaDataTable(queryConsulta);
            dbHelper.EncerrarConexao();
            return retorno;
        }   

        private List<T> ConverteDataTableParaList(DataTable tabela)
        {
            try
            {
                var list = new List<T>();

                foreach (var row in tabela.AsEnumerable())
                {
                    T obj = new T();
                    foreach (var prop in obj.GetType().GetProperties())
                    {
                        try
                        {
                            PropertyInfo propertyInfo = obj.GetType().GetProperty(prop.Name);
                            var valor = Convert.ChangeType(row[prop.Name].GetDbValue(propertyInfo), propertyInfo.PropertyType);
                            propertyInfo.SetValue(obj, valor, null);
                        }
                        catch
                        {
                            continue;
                        }
                    }
                    list.Add(obj);
                }
                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
