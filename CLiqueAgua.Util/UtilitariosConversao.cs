using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Reflection;
using System.Data;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Globalization;
using System.Windows.Forms;

namespace CliqueAgua.Util
{
    public static class UtilitariosConversao
    {

        public static string FormataCep(this long cep)
        {
            var cepTxt = cep.GetSomenteNumero(8);
            return cepTxt.Substring(0, 5) + "-" + cepTxt.Substring(5, 3);
        }

        public static string CrystalFiltroDataHora(this object _DateTime)
        {
            DateTime data = Convert.ToDateTime(_DateTime);
            return string.Format("datetimevalue('{0}-{1}-{2} {3}:{4}:{5}')", data.Year, data.Month, data.Day, 0, 0, 0);
        }
        public static string CrystalFiltroData(this object _DateTime)
        {
            DateTime data = Convert.ToDateTime(_DateTime);
            return string.Format("'{0}-{1}-{2}'", data.Year, data.Month, data.Day);
        }
        public static string CrystalFiltroLista(this List<object> _Lista)
        {
            string acoes = "";
            for (int i = 0; i < _Lista.Count; i++)
            {
                if (i == 0) acoes += (_Lista[i] as DataRow)["Id"].ToString();
                else acoes += "," + (_Lista[i] as DataRow)["Id"].ToString();
            }
            return acoes;
        }

        #region conversao de objectos

        public static DateTime GetDBDateTimeByReferencia(this object objData, bool retornoPrimeiroDia)
        {
            try
            {
                var referencia = objData.GetDBString();
                if (string.IsNullOrEmpty(referencia))
                    return DateTime.MinValue;
                var mes = referencia.Substring(0, 2).GetDBInt32();
                var ano = referencia.Substring(3, 4).GetDBInt32();
                if (ano == 0 || (mes < 1 || mes > 12))
                    return DateTime.MinValue;
                DateTime data;
                if (retornoPrimeiroDia)
                    data = new DateTime(ano, mes, 1);
                else
                    data = new DateTime(ano, mes, DateTime.DaysInMonth(ano, mes));
                return data;
            }
            catch
            {
                return DateTime.MinValue;
            }
        }
        public static DateTime GetDBDateTimeByReferencia(this object objData)
        {
            return GetDBDateTimeByReferencia(objData, false);
        }
        public static int GetDBInt32(this object objNumero)
        {
            try
            {
                if (objNumero == null || objNumero == DBNull.Value) return 0;
                return Convert.ToInt32(objNumero);
                //return Convert.ToInt32(objNumero.GetSomenteNumero());
            }
            catch
            {
                return 0;
            }
        }
        public static int GetDBInt32(DataRow dataRow, string nomeColuna)
        {
            try
            {
                if (dataRow[nomeColuna] != null && dataRow[nomeColuna] != DBNull.Value)
                    return dataRow[nomeColuna].GetDBInt32();
            }
            catch
            {
                return 0;
            }
            return 0;
        }
        public static int GetDBInt32(SqlDataReader objDataReader, string nomeColuna)
        {
            try
            {
                if (objDataReader[nomeColuna] != null && objDataReader[nomeColuna] != DBNull.Value)
                    return objDataReader[nomeColuna].GetDBInt32();
            }
            catch
            {
                return 0;
            }
            return 0;
        }
        public static String GetDBString(this object objTexto)
        {
            try
            {
                if (objTexto == DBNull.Value || objTexto == null) return "";
                return objTexto.ToString();
            }
            catch
            {
                return "";
            }
        }
        public static Int64 GetDBInt64(this object objNumero)
        {
            try
            {
                if (objNumero == DBNull.Value || objNumero == null) return 0;
                return Convert.ToInt64(objNumero);
                //return Convert.ToInt64(objNumero.GetSomenteNumero());
            }
            catch
            {
                return 0;
            }
        }
        public static Int64 GetDBInt64(SqlDataReader objDataReader, string nomeColuna)
        {
            try
            {
                if (objDataReader[nomeColuna] != null && objDataReader[nomeColuna] != DBNull.Value)
                    return objDataReader[nomeColuna].GetDBInt64();
            }
            catch
            {
                return 0;
            }
            return 0;
        }
        public static Int64 GetDBInt64(DataRow dataRow, string nomeColuna)
        {
            try
            {

                if (dataRow[nomeColuna] != null && dataRow[nomeColuna] != DBNull.Value)
                    return dataRow[nomeColuna].GetDBInt64();
            }
            catch
            {
                return 0;
            }
            return 0;
        }
        public static double GetDBDouble(this object objNumero)
        {
            try
            {
                if (objNumero == DBNull.Value || objNumero == null) return 0;
                return Convert.ToDouble(objNumero);
            }
            catch
            {
                return 0;
            }
        }
        public static double GetDBDouble(SqlDataReader objDataReader, string nomeColuna)
        {
            try
            {
                if (objDataReader[nomeColuna] != null && objDataReader[nomeColuna] != DBNull.Value)
                    return objDataReader[nomeColuna].GetDBDouble();
            }
            catch
            {
                return 0;
            }
            return 0;
        }
        public static double GetDBDouble(DataRow dataRow, string nomeColuna)
        {
            try
            {
                if (dataRow.Table.Columns.Contains(nomeColuna))
                {
                    if (dataRow[nomeColuna] != null && dataRow[nomeColuna] != DBNull.Value)
                        return dataRow[nomeColuna].GetDBDouble();
                }
                else return 0;

            }
            catch
            {
                return 0;
            }
            return 0;
        }
        public static decimal GetDBDecimal(this object objValor)
        {
            try
            {
                if (objValor == null || objValor == DBNull.Value) return 0;
                return Convert.ToDecimal(objValor);
            }
            catch
            {
                return 0;
            }
        }
        public static decimal GetDBDecimal(this object objValor, int qtdeDecimal)
        {
            try
            {
                if (objValor == null || objValor == DBNull.Value) return 0;
                if (qtdeDecimal > 0)
                    return Convert.ToDecimal(objValor) * (10 ^ qtdeDecimal);
                else
                    return Convert.ToDecimal(objValor);
            }
            catch
            {
                return 0;
            }
        }
        public static decimal GetDBDecimal(SqlDataReader objDataReader, string nomeColuna)
        {
            try
            {
                if (objDataReader[nomeColuna] != null && objDataReader[nomeColuna] != DBNull.Value)
                    return objDataReader[nomeColuna].GetDBDecimal();
            }
            catch
            {
                return 0;
            }
            return 0;
        }
        public static decimal GetDBDecimal(DataRow dataRow, string nomeColuna)
        {
            try
            {
                if (dataRow.Table.Columns.Contains(nomeColuna))
                {
                    if (dataRow[nomeColuna] != null && dataRow[nomeColuna] != DBNull.Value)
                        return dataRow[nomeColuna].GetDBDecimal();
                }
                else return 0;
            }
            catch
            {
                return 0;
            }
            return 0;
        }
        public static bool GetDBBool(this object objBooleano)
        {
            try
            {
                if (objBooleano == null || objBooleano == DBNull.Value) return false;
                if (string.IsNullOrWhiteSpace(objBooleano.ToString())) return false;
                return Convert.ToBoolean(objBooleano);
            }
            catch
            {
                return false;
            }
        }
        public static bool GetDBBool(SqlDataReader objDataReader, string nomeColuna)
        {
            try
            {
                if (objDataReader[nomeColuna] != null && objDataReader[nomeColuna] != DBNull.Value)
                    return objDataReader[nomeColuna].GetDBBool();
            }
            catch
            {
                return false;
            }
            return false;
        }
        public static bool GetDBBool(DataRow dataRow, string nomeColuna)
        {
            try
            {
                if (dataRow.Table.Columns.Contains(nomeColuna))
                {
                    if (dataRow[nomeColuna] != null && dataRow[nomeColuna] != DBNull.Value)
                        return dataRow[nomeColuna].GetDBBool();
                }
                else return false;
            }
            catch
            {
                return false;
            }
            return false;
        }
        public static DateTime? GetDBDateTimeNull(this object objData)
        {
            try
            {
                if (objData == null || objData == DBNull.Value) return null;
                var data = Convert.ToDateTime(objData);
                if (data == DateTime.MinValue) return null;
                else return data;
            }
            catch
            {
                return null;
            }
        }
        public static DateTime GetDBDateTime(this object objData)
        {
            try
            {
                if (objData == null || objData == DBNull.Value) return DateTime.MinValue;
                return Convert.ToDateTime(objData);
            }
            catch
            {
                return DateTime.MinValue;
            }
        }
        public static DateTime GetDBDateTime(SqlDataReader objDataReader, string nomeColuna)
        {
            try
            {
                if (objDataReader[nomeColuna] != null && objDataReader[nomeColuna] != DBNull.Value)
                    return objDataReader[nomeColuna].GetDBDateTime();
            }
            catch
            {
                return DateTime.MinValue;
            }
            return DateTime.MinValue;
        }
        public static DateTime GetDBDateTimeNFe(this object objData)
        {
            try
            {
                if (objData == null || objData == DBNull.Value) return DateTime.MinValue;
                var data = objData.ToString();
                return new DateTime(
                    data.Substring(0, 4).GetDBInt32(),
                    data.Substring(6, 2).GetDBInt32(),
                    data.Substring(9, 2).GetDBInt32(),
                    data.Substring(12, 2).GetDBInt32(),
                    data.Substring(15, 2).GetDBInt32(),
                    data.Substring(18, 2).GetDBInt32()
                    );
            }
            catch
            {
                return DateTime.MinValue;
            }
        }
        public static string GetDBString(SqlDataReader objDataReader, string nomeColuna)
        {
            try
            {
                if (objDataReader[nomeColuna] != null && objDataReader[nomeColuna] != DBNull.Value)
                    return objDataReader[nomeColuna].ToString();
            }
            catch
            {
                return string.Empty;
            }
            return string.Empty;
        }
        public static string GetDBString(DataRow dataRow, string nomeColuna)
        {
            try
            {
                if (dataRow.Table.Columns.Contains(nomeColuna))
                {
                    if (dataRow[nomeColuna] != null && dataRow[nomeColuna] != DBNull.Value)
                        return dataRow[nomeColuna].ToString();
                }
                else return string.Empty;
            }
            catch
            {
                return string.Empty;
            }
            return string.Empty;
        }
        public static string GetDBString(this string objNome)
        {
            try
            {
                if (objNome == null)
                    return string.Empty;
            }
            catch
            {
                return string.Empty;
            }
            return objNome;
        }

        #endregion conversao de objectos

        #region conversao de objetos para o DB

        public static object SetDBInt64(this object objNumero)
        {
            if (objNumero == null) return DBNull.Value;
            long varNumero = 0;
            try
            {
                Int64.TryParse(objNumero.ToString(), out varNumero);
                if (varNumero == 0)
                    return DBNull.Value;
                else
                    return varNumero;
            }
            catch
            {
                return DBNull.Value;
            }
        }
        public static object SetDBString(this object objValor)
        {
            if (objValor == null) return DBNull.Value;
            try
            {
                return objValor;
            }
            catch
            {
                return DBNull.Value;
            }
        }
        public static object SetDBDecimal(this object objeto)
        {
            if (objeto == null) return 0;
            decimal varNumero = 0;
            try
            {
                decimal.TryParse(objeto.ToString(), out varNumero);
                if (varNumero == 0)
                    return 0;
                else
                    return varNumero;
            }
            catch
            {
                return 0;
            }
        }
        public static object SetDBDouble(this object objeto)
        {
            if (objeto == null) return 0;
            double varNumero = 0;
            try
            {
                double.TryParse(objeto.ToString(), out varNumero);
                if (varNumero == 0)
                    return 0;
                else
                    return varNumero;
            }
            catch
            {
                return 0;
            }
        }
        public static object SetDBInt32(this object objeto)
        {
            if (objeto == null) return DBNull.Value;
            int varNumero = 0;
            try
            {
                Int32.TryParse(objeto.ToString(), out varNumero);
                if (varNumero == 0)
                    return DBNull.Value;
                else
                    return varNumero;
            }
            catch
            {
                return DBNull.Value;
            }
        }
        public static object SetDBBool(this object objeto)
        {
            if (objeto == null) return false;
            bool varBool = false;
            try
            {
                bool.TryParse(objeto.ToString(), out varBool);
                return varBool;
            }
            catch
            {
                return false;
            }
        }
        public static object SetDBDateTime(this object objData)
        {
            if (objData == null) return DBNull.Value;
            DateTime varData = DateTime.MinValue;
            try
            {
                DateTime.TryParse(objData.ToString(), out varData);
                if (varData == DateTime.MinValue)
                    return DBNull.Value;
                else
                    return varData;
            }
            catch
            {
                return DBNull.Value;
            }
        }
        public static object SetDBValor(this object objeto)
        {
            try
            {
                if (objeto == null) return DBNull.Value;
                var tipoObjeto = objeto.GetType();
                if (tipoObjeto == typeof(string)) return objeto.SetDBString().ToString().TrimEnd();
                if (tipoObjeto == typeof(decimal)) return objeto.SetDBDecimal();
                if (tipoObjeto == typeof(double)) return objeto.SetDBDouble();
                if (tipoObjeto == typeof(Int32)) return objeto.SetDBInt32();
                if (tipoObjeto == typeof(Int64)) return objeto.SetDBInt64();
                if (tipoObjeto == typeof(bool)) return objeto.SetDBBool();
                if (tipoObjeto == typeof(DateTime)) return objeto.SetDBDateTime();
            }
            catch (Exception ex)
            {
                throw new McpNetException(ex.Message);
            }
            return null;
        }

        #endregion conversao de objetos para o DB


        /// <summary>
        /// Conversao de objeto em campo DATETIME
        /// </summary>
        /// <param name="objNumero">objeto a ser convertido em DATETIME</param>
        /// <returns>Retorna DATETIME quando convertido com sucesso ou NULL quando ocorrer erro</returns>
        public static object SetDevExpressDateEdit(this DateTime objData)
        {
            try
            {
                if (objData == null) return null;
                if (objData.Date == DateTime.MinValue) return null;
                return Convert.ToDateTime(objData);
            }
            catch
            {
                return null;
            }
        }

        public static DataTable ConverterClasseEmDataTable<T>(this IList<T> data)
        {
            DataTable table = new DataTable();
            int qtdeColunas = 0;

            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));

            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                if (prop.Name.ToUpper() == "HELPER")
                    continue;
                table.Columns.Add(prop.Name, prop.PropertyType);
                qtdeColunas++;
            }

            object[] values = new object[qtdeColunas];

            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    if (props[i].Name.ToUpper() == "HELPER")
                        continue;

                    if (props[i].PropertyType == typeof(DateTime))
                    {
                        DateTime currDT = (DateTime)props[i].GetValue(item);
                        if (currDT == DateTime.MinValue)
                            values[i] = DBNull.Value;
                        else
                            values[i] = currDT.ToUniversalTime();
                    }
                    else
                    {
                        values[i] = props[i].GetValue(item);
                    }
                }
                table.Rows.Add(values);
            }
            return table;
        }

        public static List<string> ConverteStringEmLista(this string stringTxt)
        {
            return stringTxt.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None).ToList();
        }

        public static T ConverterParaLista<T>(this DataTable dataTable, DataRow dataRow) where T : new()
        {
            T Temp = new T();
            try
            {
                List<string> columnsNames = new List<string>();
                foreach (DataColumn DataColumn in dataTable.Columns)
                    columnsNames.Add(DataColumn.ColumnName);
                if (dataRow.RowState != DataRowState.Deleted)
                    Temp = getObject<T>(dataRow, columnsNames);
                return Temp;
            }
            catch
            {
                return Temp;
            }

        }

        public static T ConverterParaLista<T>(this DataTable dataTable, DataRowView dataRowView) where T : new()
        {
            T Temp = new T();
            try
            {
                var dr = dataRowView.Row;
                List<string> columnsNames = new List<string>();
                foreach (DataColumn DataColumn in dataTable.Columns)
                    columnsNames.Add(DataColumn.ColumnName);
                if (dr.RowState != DataRowState.Deleted)
                    Temp = getObject<T>(dr, columnsNames);
                return Temp;
            }
            catch
            {
                return Temp;
            }

        }

        public static List<T> ConverterParaLista<T>(this DataTable datatable) where T : new()
        {
            List<T> Temp = new List<T>();
            try
            {
                List<string> columnsNames = new List<string>();
                foreach (DataColumn DataColumn in datatable.Columns)
                    columnsNames.Add(DataColumn.ColumnName);
                Temp = datatable.AsEnumerable().Where(w => w.RowState != DataRowState.Deleted).ToList().ConvertAll<T>(row => getObject<T>(row, columnsNames));
                return Temp;
            }
            catch
            {
                return Temp;
            }

        }

        /// <summary>
        /// retorna uma lista com os registros da tabela que atendam ao tipo de registro
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="datatable"></param>
        /// <param name="tipoRegistro"></param>
        /// <returns></returns>
        public static List<T> ConverterParaLista<T>(this DataTable datatable, DataViewRowState tipoRegistro) where T : new()
        {
            List<T> Temp = new List<T>();
            try
            {
                var dtItens = datatable.Clone();
                var dtSelecionados = datatable.Select(string.Empty, string.Empty, tipoRegistro);
                if (dtSelecionados != null && dtSelecionados.Length > 0)
                    dtItens = dtSelecionados.CopyToDataTable();
                List<string> columnsNames = new List<string>();
                foreach (DataColumn DataColumn in dtItens.Columns)
                    columnsNames.Add(DataColumn.ColumnName);
                Temp = dtItens.AsEnumerable().ToList().ConvertAll<T>(row => getObject<T>(row, columnsNames));
                return Temp;
            }
            catch
            {
                return Temp;
            }

        }

        public static decimal ArredondarValor(this double valor)
        {
            return ArredondarValor(valor.GetDBDecimal(), 2);
        }

        public static decimal ArredondarValor(this decimal valor)
        {
            return ArredondarValor(valor, 2);
        }

        public static decimal ArredondarValor(this decimal valor, int qtdeDecimais)
        {
            return Math.Round(valor, qtdeDecimais);
        }

        //public static T getObject<T>(DataRow row, List<string> columnsName) where T : new()
        //{
        //    T obj = new T();
        //    try
        //    {
        //        string columnname = "";
        //        string value = "";
        //        PropertyInfo[] Properties;
        //        Properties = typeof(T).GetProperties();
        //        foreach (PropertyInfo objProperty in Properties)
        //        {
        //            columnname = columnsName.Find(name => name.ToLower() == objProperty.Name.ToLower());
        //            if (!string.IsNullOrEmpty(columnname))
        //            {
        //                value = row[columnname].ToString();

        //                var tipoObjeto = row[columnname].GetType();
        //                if (tipoObjeto == typeof(string))
        //                    objProperty.SetValue(obj, Convert.ChangeType(value, Type.GetType(objProperty.PropertyType.ToString())), null);
        //                else
        //                    if (!string.IsNullOrEmpty(value))
        //                    {
        //                        if (Nullable.GetUnderlyingType(objProperty.PropertyType) != null)
        //                        {
        //                            value = row[columnname].ToString().Replace("$", "").Replace(",", "");
        //                            objProperty.SetValue(obj, Convert.ChangeType(value, Type.GetType(Nullable.GetUnderlyingType(objProperty.PropertyType).ToString())), null);
        //                        }
        //                        else
        //                        {
        //                            value = row[columnname].ToString().Replace("%", "");
        //                            objProperty.SetValue(obj, Convert.ChangeType(value, Type.GetType(objProperty.PropertyType.ToString())), null);
        //                        }
        //                    }
        //            }
        //        }
        //        return obj;
        //    }
        //    catch
        //    {
        //        return obj;
        //    }
        //}

        public static T getObject<T>(DataRow row, List<string> columnsName) where T : new()
        {
            string columnName = null;
            T obj = new T();
            try
            {

                object valor = null;
                Type tipoObjeto;
                PropertyInfo[] Properties;
                Properties = typeof(T).GetProperties();
                foreach (PropertyInfo objProperty in Properties)
                {
                    columnName = columnsName.Find(name => name.ToLower() == objProperty.Name.ToLower());
                    var tipoObjetoNull = Nullable.GetUnderlyingType(objProperty.PropertyType);
                    if (!string.IsNullOrEmpty(columnName))
                    {
                        valor = row[columnName];
                        if (tipoObjetoNull == null)
                        {
                            tipoObjeto = objProperty.PropertyType;
                            if (valor == DBNull.Value || valor == null)
                            {
                                if (tipoObjeto == typeof(string)) objProperty.SetValue(obj, Convert.ChangeType(string.Empty, tipoObjeto, null), null);
                                if (tipoObjeto == typeof(long)) objProperty.SetValue(obj, Convert.ChangeType(0, tipoObjeto, null), null);
                                if (tipoObjeto == typeof(int)) objProperty.SetValue(obj, Convert.ChangeType(0, tipoObjeto, null), null);
                                if (tipoObjeto == typeof(decimal)) objProperty.SetValue(obj, Convert.ChangeType(0.00, tipoObjeto, null), null);
                                if (tipoObjeto == typeof(double)) objProperty.SetValue(obj, Convert.ChangeType(0.00, tipoObjeto, null), null);
                                if (tipoObjeto == typeof(bool)) objProperty.SetValue(obj, Convert.ChangeType(false, tipoObjeto, null), null);
                                if (tipoObjeto == typeof(DateTime)) objProperty.SetValue(obj, Convert.ChangeType(DateTime.MinValue, tipoObjeto, null), null);
                                continue;
                            }
                            var valorConvertido = Convert.ChangeType(valor, tipoObjeto, null);
                            objProperty.SetValue(obj, valorConvertido, null);
                        }
                        else
                        {
                            if (valor == DBNull.Value || valor == null)
                            {
                                if (tipoObjetoNull == typeof(string)) objProperty.SetValue(obj, Convert.ChangeType(string.Empty, tipoObjetoNull, null), null);
                                if (tipoObjetoNull == typeof(long)) objProperty.SetValue(obj, Convert.ChangeType(0, tipoObjetoNull, null), null);
                                if (tipoObjetoNull == typeof(int)) objProperty.SetValue(obj, Convert.ChangeType(0, tipoObjetoNull, null), null);
                                if (tipoObjetoNull == typeof(decimal)) objProperty.SetValue(obj, Convert.ChangeType(0.00, tipoObjetoNull, null), null);
                                if (tipoObjetoNull == typeof(double)) objProperty.SetValue(obj, Convert.ChangeType(0.00, tipoObjetoNull, null), null);
                                if (tipoObjetoNull == typeof(bool)) objProperty.SetValue(obj, Convert.ChangeType(false, tipoObjetoNull, null), null);
                                if (tipoObjetoNull == typeof(DateTime)) objProperty.SetValue(obj, Convert.ChangeType(DateTime.MinValue, tipoObjetoNull, null), null);
                                continue;
                            }
                            var valorConvertido = Convert.ChangeType(valor, tipoObjetoNull, null);
                            objProperty.SetValue(obj, valorConvertido, null);
                        }
                    }
                }
                return obj;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO CONVERSÃO DADOS. \r\nCOLUNA: " + columnName + "\r\n" + ex.Message);
                return obj;
            }
        }

        public static T RetornaClasse<T>(string nome) where T : class
        {
            return (T)Assembly.GetExecutingAssembly().CreateInstance(nome);
        }

        public static Object GetPropertieValue(this Object obj, String name)
        {
            foreach (String part in name.Split('.'))
            {
                if (obj == null) { return null; }

                Type type = obj.GetType();
                PropertyInfo info = type.GetProperty(part);
                if (info == null) { return null; }

                obj = info.GetValue(obj, null);
            }
            return obj;
        }

        public static object SetUltimaHora(string dataFim)
        {
            string newData = dataFim.Replace("00:00:00", "");
            if (!string.IsNullOrWhiteSpace(dataFim))
            {
                newData = string.Format("{0}{1}", newData, " 23:59:59");
            }

            return newData;
        }
        
        public static string FormataSegundosEmHHMMSS(this int qtdeSegundos)
        {
            int Horas, Minutos, Segundos;
            Horas = qtdeSegundos / 3600;
            Minutos = qtdeSegundos % 3600 / 60;
            Segundos = qtdeSegundos % 60;
            return Horas + ":" + Minutos.ToString("00") + ":" + Segundos.ToString("00");
        }


        /// <summary>
        /// converte o campo txt AAAAMMDD em datetime (pode ser com /)
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static DateTime? GetDataAMD(this string txt)
        {
            try
            {
                int ano, mes, dia;
                if (txt.Contains("/"))
                {
                    ano = txt.Substring(0, 4).GetDBInt32();
                    mes = txt.Substring(5, 2).GetDBInt32();
                    dia = txt.Substring(8, 2).GetDBInt32();
                }
                else
                {
                    ano = txt.Substring(0, 4).GetDBInt32();
                    mes = txt.Substring(4, 2).GetDBInt32();
                    dia = txt.Substring(6, 2).GetDBInt32();
                }

                return new DateTime(ano, mes, dia);
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// converte o campo txt DDMMAAAA em datetime (pode ser com /)
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static DateTime? GetDataDMA(this string txt)
        {
            try
            {
                int ano, mes, dia;
                if (txt.Contains("/"))
                {
                    ano = txt.Substring(6, 4).GetDBInt32();
                    mes = txt.Substring(3, 2).GetDBInt32();
                    dia = txt.Substring(0, 2).GetDBInt32();
                }
                else
                {
                    ano = txt.Substring(4, 4).GetDBInt32();
                    mes = txt.Substring(2, 2).GetDBInt32();
                    dia = txt.Substring(0, 2).GetDBInt32();
                }
                return new DateTime(ano, mes, dia);
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// converte o campo txt DDMMAAAA em datetime (pode ser com /)
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static DateTime GetDataDMASemNull(this string txt)
        {
            try
            {
                int ano, mes, dia;
                if (txt.Contains("/"))
                {
                    ano = txt.Substring(6, 4).GetDBInt32();
                    mes = txt.Substring(3, 2).GetDBInt32();
                    dia = txt.Substring(0, 2).GetDBInt32();
                }
                else
                {
                    ano = txt.Substring(4, 4).GetDBInt32();
                    mes = txt.Substring(2, 2).GetDBInt32();
                    dia = txt.Substring(0, 2).GetDBInt32();
                }
                return new DateTime(ano, mes, dia);
            }
            catch (Exception)
            {
                return DateTime.MinValue;
            }
        }

        /// <summary>
        /// converte o campo txt AAAAMMDDHHMMSS em datetime
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static DateTime? GetDataHoraAMDHMS(this string txt)
        {
            try
            {
                int ano = txt.Substring(0, 4).GetDBInt32();
                int mes = txt.Substring(4, 2).GetDBInt32();
                int dia = txt.Substring(6, 2).GetDBInt32();
                int hor = txt.Substring(8, 2).GetDBInt32();
                int min = txt.Substring(10, 2).GetDBInt32();
                int seg = txt.Substring(12, 2).GetDBInt32();
                return new DateTime(ano, mes, dia, hor, min, seg);
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// converte o campo txt DDMMAAAAHMMSS em datetime
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static DateTime? GetDataHoraDMAHMS(this string txt)
        {
            try
            {
                int dia = txt.Substring(0, 2).GetDBInt32();
                int mes = txt.Substring(2, 2).GetDBInt32();
                int ano = txt.Substring(4, 4).GetDBInt32();
                int hor = txt.Substring(8, 2).GetDBInt32();
                int min = txt.Substring(10, 2).GetDBInt32();
                int seg = txt.Substring(12, 2).GetDBInt32();
                return new DateTime(ano, mes, dia, hor, min, seg);
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// converte o campo txt DDMMAAAAHMMSS em datetime
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static DateTime GetDataHoraDMAHMSSemNull(this string txt)
        {
            try
            {
                int dia = txt.Substring(0, 2).GetDBInt32();
                int mes = txt.Substring(2, 2).GetDBInt32();
                int ano = txt.Substring(4, 4).GetDBInt32();
                int hor = txt.Substring(8, 2).GetDBInt32();
                int min = txt.Substring(10, 2).GetDBInt32();
                int seg = txt.Substring(12, 2).GetDBInt32();
                return new DateTime(ano, mes, dia, hor, min, seg);
            }
            catch (Exception)
            {
                return DateTime.MinValue;
            }
        }

        /// <summary>
        /// retorn o mes com o nome reduzido
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static string GetMesReduzido(this int objeto)
        {
            try
            {
                if (objeto == 1) return "Jan";
                if (objeto == 2) return "Fev";
                if (objeto == 3) return "Mar";
                if (objeto == 4) return "Abr";
                if (objeto == 5) return "Mai";
                if (objeto == 6) return "Jun";
                if (objeto == 7) return "Jul";
                if (objeto == 8) return "Ago";
                if (objeto == 9) return "Set";
                if (objeto == 10) return "Out";
                if (objeto == 11) return "Nov";
                if (objeto == 12) return "Dez";
                if (objeto == 13) return "Tot";
                return "";
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static bool IsInteger(this string pColuna)
        {
            Regex objNotIntPattern = new Regex("[^0-9-]");
            Regex objIntPattern = new Regex("^-[0-9]+$|^[0-9]+$");

            return !objNotIntPattern.IsMatch(pColuna) && objIntPattern.IsMatch(pColuna);
        }
        public static bool IsNumber(this string pColuna)
        {
            Regex objNotNumberPattern = new Regex("[^0-9.-]");
            Regex objTwoDotPattern = new Regex("[0-9]*[.][0-9]*[.][0-9]*");
            Regex objTwoMinusPattern = new Regex("[0-9]*[-][0-9]*[-][0-9]*");
            String strValidRealPattern = "^([-]|[.]|[-.]|[0-9])[0-9]*[.]*[0-9]+$";
            String strValidIntegerPattern = "^([-]|[0-9])[0-9]*$";
            Regex objNumberPattern = new Regex("(" + strValidRealPattern + ")|(" + strValidIntegerPattern + ")");
            return !objNotNumberPattern.IsMatch(pColuna) && !objTwoDotPattern.IsMatch(pColuna) && !objTwoMinusPattern.IsMatch(pColuna) && objNumberPattern.IsMatch(pColuna);
        }


        public static string Criptografar(this string objString)
        {
            if (string.IsNullOrEmpty(objString)) return "";
            const string senha = "eklm@2013";
            byte[] Results;
            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();
            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(senha));
            TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();
            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;
            byte[] DataToEncrypt = UTF8.GetBytes(objString);
            try
            {
                ICryptoTransform Encryptor = TDESAlgorithm.CreateEncryptor();
                Results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length);
            }
            finally
            {
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }
            return Convert.ToBase64String(Results);
        }
        public static string Descriptografar(this string objString)
        {
            if (string.IsNullOrEmpty(objString)) return "";
            const string senha = "eklm@2013";
            byte[] Results;
            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();
            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(senha));
            TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();
            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;
            byte[] DataToDecrypt = Convert.FromBase64String(objString);
            try
            {
                ICryptoTransform Decryptor = TDESAlgorithm.CreateDecryptor();
                Results = Decryptor.TransformFinalBlock(DataToDecrypt, 0, DataToDecrypt.Length);
            }
            finally
            {
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }
            return UTF8.GetString(Results);
        }




        public static string GetSomenteNumero(this object strTexto)
        {
            var str = strTexto.GetDBString();
            if (string.IsNullOrEmpty(str))
                return "";
            return string.Join(null, System.Text.RegularExpressions.Regex.Split(str, "[^\\d]"));
        }
        public static string GetSomenteNumero(this string strTexto)
        {
            if (string.IsNullOrEmpty(strTexto))
                return "";
            return string.Join(null, System.Text.RegularExpressions.Regex.Split(strTexto, "[^\\d]"));
        }
        public static string GetSomenteNumero(this string strTexto, int qtdeZerosEsquerda)
        {
            string retorno = "".PadLeft(qtdeZerosEsquerda, '0');
            if (string.IsNullOrEmpty(strTexto) || string.IsNullOrWhiteSpace(strTexto))
                return retorno;
            retorno = string.Join(null, System.Text.RegularExpressions.Regex.Split(strTexto, "[^\\d]"));
            return retorno.PadLeft(qtdeZerosEsquerda, '0');
        }
        public static string GetSomenteNumero(this object strTexto, int qtdeZerosEsquerda)
        {
            return GetSomenteNumero(strTexto.GetDBString(), qtdeZerosEsquerda);
        }

       
        public static string RemoveCaracteresParaDiretorio(this string strTexto)
        {
            /** Troca os caracteres acentuados por não acentuados **/
            string[] acentos = new string[] { "\\", "/", ":", "*", "?", "<", ">", "|" };
            string[] semAcento = new string[] { " ", " ", " ", " ", " ", " ", " ", " " };
            for (int i = 0; i < acentos.Length; i++)
                strTexto = strTexto.Replace(acentos[i], semAcento[i]);
            return strTexto;
        }

        public static string RemoveCaracteresNFe(this string strTexto)
        {
            string strRetorno = string.Empty;
            strRetorno = strTexto.RemoverCaracteresExpressaoRegular().RemoveEspacosDuplos().Trim();
            return strRetorno.TrimStart().TrimEnd();
        }

        public static string RemoverCaracteresExpressaoRegular(this string strTexto)
        {
            try
            {
                if (string.IsNullOrEmpty(strTexto))
                    return "";

                StringBuilder stringBuilder = new StringBuilder();
                char[] nome = strTexto.ToCharArray();
                foreach (char letra in nome)
                {
                    if (Regex.IsMatch(letra.ToString(), @"[!-ÿ]{1}[ -ÿ]{0,}[!-ÿ]{1}|[!-ÿ]{1}"))
                        stringBuilder.Append(letra);
                    else
                        stringBuilder.Append(" ");
                }
                return stringBuilder.ToString();
            }

            // If we timeout when replacing invalid characters, 
            // we should return Empty.
            catch (RegexMatchTimeoutException)
            {
                return String.Empty;
            }
        }

        public static string RemoverAcentos(this string strTexto)
        {
            strTexto = strTexto.Normalize(NormalizationForm.FormD);
            StringBuilder stbNovoTexto = new StringBuilder();

            foreach (char c in strTexto.ToCharArray())
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                {
                    stbNovoTexto.Append(c);
                }
            }
            return stbNovoTexto.ToString();
        }

        public static string RemoveEspacosDuplos(this string strTexto)
        {
            if (!string.IsNullOrEmpty(strTexto))
            {
                if (strTexto.Contains("  "))
                {
                    strTexto = strTexto.Replace("  ", " ");
                    strTexto = strTexto.RemoveEspacosDuplos();
                }
            }
            strTexto = strTexto.Trim();

            return strTexto;
        }

        public static string RemoverCaracteresEspeciais(this string strTexto)
        {

            /** Troca os caracteres acentuados por não acentuados **/
            string[] acentos = new string[] { "ç", "Ç", "á", "é", "í", "ó", "ú", "ý", "Á", "É", "Í", "Ó", "Ú", "Ý",
                "à", "è", "ì", "ò", "ù", "À", "È", "Ì", "Ò", "Ù", "ã", "õ", "ñ", "ä", "ë", "ï", "ö", "ü", "ÿ", "Ä", "Ë", "Ï",
                "Ö", "Ü", "Ã", "Õ", "Ñ", "â", "ê", "î", "ô", "û", "Â", "Ê", "Î", "Ô", "Û", "ª", "°", "€", "§", "–", "â€“", "“", "”", "	", "•", "º" };
            string[] semAcento = new string[] { "c", "C", "a", "e", "i", "o", "u", "y", "A", "E", "I", "O", "U", "Y",
                "a", "e", "i", "o", "u", "A", "E", "I", "O", "U", "a", "o", "n", "a", "e", "i", "o", "u", "y", "A", "E", "I",
                "O", "U", "A", "O", "N", "a", "e", "i", "o", "u", "A", "E", "I", "O", "U", "a", "o", "C", "o", "-", "-", "''", "''", " ", " - ", "o" };

            for (int i = 0; i < acentos.Length; i++)
            {
                strTexto = strTexto.Replace(acentos[i], semAcento[i]);
            }

            return strTexto;


        }

        public static string RemoveDiacritics(string s)
        {
            return new string(s.Normalize(System.Text.NormalizationForm.FormD).Where(c => System.Globalization.CharUnicodeInfo.GetUnicodeCategory(c) != System.Globalization.UnicodeCategory.NonSpacingMark).ToArray());
        }

        public static string ReplaceEnter(this string strTexto, string replace)
        {
            if (!string.IsNullOrWhiteSpace(strTexto))
            {
                strTexto = strTexto.Replace("\r\n", replace);
            }
            return strTexto;
        }

        public static string AcertaTamanhoCampoTxt(this string strLinha, int tamanhoLinha)
        {
            string retorno = string.Empty;
            int maxTamanho = strLinha.Length;
            if (tamanhoLinha == 0 || string.IsNullOrEmpty(strLinha) || strLinha.Length < tamanhoLinha)
                retorno = strLinha.PadRight(tamanhoLinha, ' ');
            else
            {
                if (strLinha.Length > tamanhoLinha) maxTamanho = tamanhoLinha;
                retorno = strLinha.Substring(0, maxTamanho);
            }
            return retorno;
        }

        public static string AlinharEsquerda(this string str, int length, char character = ' ')
        {
            return str.PadLeft((length - str.Length) / 2 + str.Length, character).PadRight(length, character);
        }

        public static string AlinharCentro(this string str, int length, char character = ' ')
        {
            return str.PadLeft((length - str.Length) / 2 + str.Length, character).PadRight(length, character);
        }

        public static string AlinharDireta(this string str, int length, char character = ' ')
        {
            return str.PadLeft((length - str.Length) / 2 + str.Length, character).PadRight(length, character);
        }

        /// <summary>
        /// Métodos para remover espaços de uma string
        /// </summary>
        /// <param name="strTexto">String a ser tratada</param>
        /// <returns>String sem espaços duplos</returns>
        public static String RemoveEspacos(this string strTexto)
        {
            if (!string.IsNullOrEmpty(strTexto))
            {
                if (strTexto.Contains(" "))
                {
                    strTexto = strTexto.Replace(" ", "");
                    strTexto = strTexto.RemoveEspacosDuplos();
                }
            }
            strTexto = strTexto.Trim();

            return strTexto;
        }

        /// <summary>
        /// converte o campo txt AAAAMMDDHHMMSS em datetime
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static DateTime? GetDataHora(this string txt)
        {
            try
            {
                int ano = txt.Substring(0, 4).GetDBInt32();
                int mes = txt.Substring(4, 2).GetDBInt32();
                int dia = txt.Substring(6, 2).GetDBInt32();
                int hor = txt.Substring(8, 2).GetDBInt32();
                int min = txt.Substring(10, 2).GetDBInt32();
                int seg = txt.Substring(12, 2).GetDBInt32();
                return new DateTime(ano, mes, dia, hor, min, seg);
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// retorn o dia da semana
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static string GetDiaSemana(this int objeto)
        {
            try
            {
                if (objeto == 1) return "Segunda";
                if (objeto == 2) return "Terca";
                if (objeto == 3) return "Quarta";
                if (objeto == 4) return "Quinta";
                if (objeto == 5) return "Sexta";
                if (objeto == 6) return "Sabado";
                if (objeto == 7) return "Domingo";
                return "";
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// retorn o mes
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static string GetMes(this int objeto)
        {
            try
            {
                if (objeto == 1) return "Janeiro";
                if (objeto == 2) return "Fevereiro";
                if (objeto == 3) return "Marco";
                if (objeto == 4) return "Abril";
                if (objeto == 5) return "Maio";
                if (objeto == 6) return "Junho";
                if (objeto == 7) return "Julho";
                if (objeto == 8) return "Agosto";
                if (objeto == 9) return "Setembro";
                if (objeto == 10) return "Outubro";
                if (objeto == 11) return "Novembro";
                if (objeto == 12) return "Dezembro";
                if (objeto == 13) return "Total";
                return "";
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// calculo digito modulo 11
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns></returns>
        public static int DigitoModulo11(string strNumero)
        {

            try
            {
                int[] intPesos = { 2, 3, 4, 5, 6, 7, 8, 9 };
                string strText = strNumero;

                int intSoma = 0;
                int intIdx = 0;

                for (int intPos = strText.Length - 1; intPos >= 0; intPos--)
                {
                    intSoma += Convert.ToInt32(strText[intPos].ToString()) * intPesos[intIdx];
                    intIdx++;
                    if (intIdx == 10) intIdx = 0;
                }

                int intResto = (intSoma * 10) % 11;
                int intDigito = intResto;
                if (intDigito >= 10)
                    intDigito = 0;

                return intDigito;
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// calculo digito modulo 10
        /// </summary>
        /// <param name="strNumero"></param>
        /// <returns></returns>
        public static int DigitoModulo10(string strNumero)
        {
            try
            {
                int i = 2;
                int sum = 0;
                int res = 0;
                foreach (char c in strNumero.ToCharArray())
                {
                    res = Convert.ToInt32(c.ToString()) * i;
                    sum += res > 9 ? (res - 9) : res;
                    i = i == 2 ? 1 : 2;
                }
                return 10 - (sum % 10);
            }
            catch (Exception)
            {
                throw;
            }

        }

        public static void AddPropertyToClasse(object objetoClasse, string propertyName, object propertyValue)
        {
            // ExpandoObject da suporte a IDictionary então podemos estendê-lo assim:
            var expandoDict = objetoClasse as IDictionary<string, object>;
            if (expandoDict.ContainsKey(propertyName))
                expandoDict[propertyName] = propertyValue;
            else
                expandoDict.Add(propertyName, propertyValue);
        }

        #region formatacao remessa bancos


        // rotinas auxiliares

        public static string CampoTextoCnab(this object texto, int posicaoInicial, int posicaoFinal)
        {
            int tamanhoCampo = posicaoFinal - posicaoInicial + 1;
            if (tamanhoCampo <= 0)
                throw new McpNetException($"TAMANHO DO CAMPO NUMERICO é INVALIDO: POSIÇÃO ({posicaoInicial}, {posicaoFinal})");
            string txt = texto.GetDBString().ToUpper();
            int maxTamanho = txt.Length;
            if (string.IsNullOrEmpty(txt))
                return txt.PadRight(tamanhoCampo, ' ');
            if (txt.Length > tamanhoCampo)
                return txt.Substring(0, tamanhoCampo);
            return txt.PadRight(tamanhoCampo, ' ');
        }

        public static string CampoNumeroCnab(this object valor, int posicaoInicial, int posicaoFinal, int casasDecimas)
        {
            try
            {
                int tamanhoCampo = posicaoFinal - posicaoInicial + 1;
                if (tamanhoCampo <= 0)
                    throw new McpNetException($"TAMANHO DO CAMPO NUMERICO é INVALIDO: POSIÇÃO ({posicaoInicial}, {posicaoFinal})");

                string retorno;
                decimal val = valor.GetDBDecimal();
                string valorEx = val.ToString().Replace(".", "");
                if (val == 0)
                    retorno = val.ToString("n" + casasDecimas.ToString()).Replace(".", "").Replace(",", "");
                else
                    retorno = val.ToString("n" + casasDecimas.ToString()).Replace(".", "").Replace(",", "");
                retorno = retorno.PadLeft(tamanhoCampo, '0');
                if (retorno.Length > tamanhoCampo)
                    throw new McpNetException($"TAMANHO DO CAMPO NUMERICO RETORNADO É MAIOR QUE O CAMPO DO ARQUIVO: POSIÇÃO ({posicaoInicial}, {posicaoFinal}), RETORNO: {retorno}");
                return retorno;

            }
            catch (Exception)
            {
                throw;
            }
        }


        #endregion

    }
}
