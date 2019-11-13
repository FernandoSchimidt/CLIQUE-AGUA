using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;

namespace CliqueAgua.Util
{
    public static class UtilitariosConversaoDados
    {

        // conversao json

        public static T ConverteJsonParaClasse<T>(string jsonString)
        {
            return JsonConvert.DeserializeObject<T>(jsonString);
        }

        public static string ConverteClasseParaJson(object objeto)
        {
            return JsonConvert.SerializeObject(objeto);
        }


        // conversoes classe e datatable
        public static List<T> ConverteDataTableParaList<T>(DataTable tabela) where T : new()
        {
            try
            {
                List<T> list = new List<T>();

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

        public static DataTable ConverteListParaDataTable<T>(IEnumerable<T> list)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in list)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }


        // conversao de dados

        public static object SetDBValor(this object objeto)
        {
            try
            {
                if (objeto == null) return DBNull.Value;
                var tipoObjeto = objeto.GetType();
                if (tipoObjeto == typeof(string)) return objeto.SetDBString();
                if (tipoObjeto == typeof(decimal)) return objeto.SetDBDecimal();
                if (tipoObjeto == typeof(double)) return objeto.SetDBDouble();
                if (tipoObjeto == typeof(Int32)) return objeto.SetDBInt32();
                if (tipoObjeto == typeof(Int64)) return objeto.SetDBInt64();
                if (tipoObjeto == typeof(bool)) return objeto.SetDBBool();
                if (tipoObjeto == typeof(DateTime)) return objeto.SetDBDateTime();
                throw new Exception($"" +
                    $"Classe: UtilitariosBancoDados\r\n" +
                    $"Metodo: SetDBValor\r\n" +
                    $"Erro: Tipo de valor não identificado {tipoObjeto.ToString()}");
            }
            catch (Exception)
            {
                throw;
            }

        }

        private static object SetDBInt64(this object objeto)
        {
            if (objeto == null) return DBNull.Value;
            long varNumero = 0;
            try
            {
                Int64.TryParse(objeto.ToString(), out varNumero);
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
        private static object SetDBString(this object objeto)
        {
            if (objeto == null) return DBNull.Value;
            try
            {
                return objeto;
            }
            catch
            {
                return DBNull.Value;
            }
        }
        private static object SetDBDecimal(this object objeto)
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
        private static object SetDBDouble(this object objeto)
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
        private static object SetDBInt32(this object objeto)
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
        private static object SetDBBool(this object objeto)
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
        private static object SetDBDateTime(this object objData)
        {
            if (objData == null || objData == DBNull.Value) return DBNull.Value;
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

        public static object GetDbValue(this object objeto)
        {
            var tipo = objeto.GetType();
            if (tipo == typeof(string)) return GetDBString(objeto);
            if (tipo == typeof(long)) return GetDBInt64(objeto);
            if (tipo == typeof(int)) return GetDBInt32(objeto);
            if (tipo == typeof(decimal)) return GetDBDecimal(objeto);
            if (tipo == typeof(double)) return GetDBDecimal(objeto);
            if (tipo == typeof(bool)) return GetDBBool(objeto);
            return null;
        }

        public static object GetDbValue(this object objeto, PropertyInfo tipoValor)
        {
            if (tipoValor.PropertyType == typeof(string)) return GetDBString(objeto);
            if (tipoValor.PropertyType == typeof(long)) return GetDBInt64(objeto);
            if (tipoValor.PropertyType == typeof(int)) return GetDBInt32(objeto);
            if (tipoValor.PropertyType == typeof(decimal)) return GetDBDecimal(objeto);
            if (tipoValor.PropertyType == typeof(double)) return GetDBDouble(objeto);
            if (tipoValor.PropertyType == typeof(bool)) return GetDBBool(objeto);
            if (tipoValor.PropertyType == typeof(DateTime)) return GetDBDateTime(objeto);
            throw new Exception($"Tipo de Campo sem Conversao: {tipoValor.PropertyType}");
        }

        public static string GetDBString(this object objeto)
        {
            try
            {
                if (objeto == null)
                    return string.Empty;
            }
            catch
            {
                return string.Empty;
            }
            return objeto.ToString();
        }
        public static int GetDBInt32(this object objeto)
        {
            try
            {
                if (objeto == null || objeto == DBNull.Value) return 0;
                return Convert.ToInt32(objeto);
                //return Convert.ToInt32(objNumero.GetSomenteNumero());
            }
            catch
            {
                return 0;
            }
        }
        public static long GetDBInt64(this object objeto)
        {
            try
            {
                if (objeto == null || objeto == DBNull.Value) return 0;
                return Convert.ToInt64(objeto);
            }
            catch
            {
                return 0;
            }
        }
        public static double GetDBDouble(this object objeto)
        {
            try
            {
                if (objeto == DBNull.Value || objeto == null) return 0;
                return Convert.ToDouble(objeto);
            }
            catch
            {
                return 0;
            }
        }
        public static decimal GetDBDecimal(this object objeto)
        {
            try
            {
                if (objeto == null || objeto == DBNull.Value) return 0;
                return Convert.ToDecimal(objeto);
            }
            catch
            {
                return 0;
            }
        }
        public static bool GetDBBool(this object objeto)
        {
            try
            {
                if (objeto == null || objeto == DBNull.Value) return false;
                if (string.IsNullOrWhiteSpace(objeto.ToString())) return false;
                return Convert.ToBoolean(objeto);
            }
            catch
            {
                return false;
            }
        }
        public static DateTime GetDBDateTime(this object objeto)
        {
            try
            {
                if (objeto == null || objeto == DBNull.Value) return DateTime.MinValue;
                return Convert.ToDateTime(objeto);
            }
            catch
            {
                return DateTime.MinValue;
            }
        }
        public static DateTime? GetDBDateTimeNull(this object objeto)
        {
            try
            {
                if (objeto == null || objeto == DBNull.Value) return null;
                var data = Convert.ToDateTime(objeto);
                if (data == DateTime.MinValue) return null;
                else return data;
            }
            catch
            {
                return null;
            }
        }


    }
}
