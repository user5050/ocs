using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace OneCoin.Service.Dal.Utility
{
    internal class DbChange
    {

        public static int ToInt(object source, int failValue)
        {
            if (source == null)
                return failValue;

            int temp;
            if (int.TryParse(source.ToString(), out temp))
                return temp;

            return failValue;
        }


        public static string ToString(object source)
        {
            if (source == null)
                return string.Empty;

            return Convert.ToString(source);
        }

        public static long ToLong(object source, long failValue)
        {
            if (source == null)
                return failValue;

            long temp;
            if (long.TryParse(source.ToString(), out temp))
                return temp;

            return failValue;
        }


        public static bool ToBool(object source, bool failValue)
        {
            if (source == null)
                return failValue;

            bool temp;
            if (bool.TryParse(source.ToString(), out temp))
                return temp;

            return failValue;
        }

        public static float ToFloat(object source, float failValue)
        {
            if (source == null)
                return failValue;

            float temp;
            if (float.TryParse(source.ToString(), out temp))
                return temp;

            return failValue;
        }


        public static double ToDouble(object source, double failValue)
        {
            if (source == null)
                return failValue;

            double temp;
            if (double.TryParse(source.ToString(), out temp))
                return temp;

            return failValue;
        }


        public static decimal ToDecimal(object source, decimal failValue)
        {
            if (source == null)
                return failValue;

            decimal temp;
            if (decimal.TryParse(source.ToString(), out temp))
                return temp;

            return failValue;
        }


        public static DateTime ToDateTime(object source, DateTime failValue)
        {
            if (source == null)
                return failValue;

            DateTime temp;
            if (DateTime.TryParse(source.ToString(), out temp))
                return temp;

            return failValue;
        }

        public static List<T> ToEntity<T>(DataSet source) where T : class, new()
        {
            var items = new List<T>();
            if (source != null && source.Tables.Count > 0)
            {
                var type = typeof (T);
                foreach (DataRow dr in source.Tables[0].Rows)
                {
                    var newObj = new T();
                    var haveValue = false;
                    foreach (PropertyInfo pi in type.GetProperties(BindingFlags.Instance | BindingFlags.Public))
                    {
                        if (source.Tables[0].Columns.Contains(pi.Name))
                        {
                            if (!string.IsNullOrEmpty(Convert.ToString(dr[pi.Name])))
                            {
                                haveValue = true;
                            }
                            pi.SetValue(newObj, Convert2Target(pi.PropertyType, dr[pi.Name]), null);
                        }
                    }
                    if (haveValue)
                    {
                        items.Add(newObj);
                    }
                }
            }

            return items;
        }


        public static List<Dictionary<string, string>> ToDictionary(DataSet ds)
        {
            var dataList = new List<Dictionary<string, string>>();
            if (ds != null)
            {
                DataTable dt = ds.Tables[0];
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    var newData = new Dictionary<string, string>();
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        string columnsName = dt.Columns[i].ColumnName;
                        string rowValue = dt.Rows[j][i].ToString();
                        newData.Add(columnsName, rowValue);
                    }
                    dataList.Add(newData);
                }
            }

            return dataList;
        }


        public static DataTable ToDataTable<T>(IEnumerable<T> source) where T : class, new()
        {
            var dt = new DataTable();
            var type = typeof (T);
            var pis = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);

            foreach (PropertyInfo pi in pis)
            {
                if (pi.CanRead)
                {
                    dt.Columns.Add(new DataColumn(pi.Name));
                }
            }

            if (source != null)
            {
                foreach (var item in source)
                {
                    var dr = dt.NewRow();
                    foreach (PropertyInfo pi in pis)
                    {
                        dr[pi.Name] = pi.GetValue(item, null);
                    }

                    dt.Rows.Add(dr);
                }
            }

            return dt;
        }


        public static decimal ToByteArray(object source, decimal failValue)
        {
            if (source == null)
                return failValue;

            decimal temp;
            if (decimal.TryParse(source.ToString(), out temp))
                return temp;

            return failValue;
        }

        public static Object Convert2Target(Type targetType, Object source)
        {
            Object ret;
            if (targetType == typeof (string))
            {
                ret = Convert.ToString(source).Trim();
            }
            else if (targetType == typeof (int))
            {
                ret = Convert.ToInt32(source);
            }
            else if (targetType == typeof (Int64))
            {
                ret = Convert.ToInt64(source);
            }
            else if (targetType == typeof (DateTime))
            {
                ret = Convert.ToDateTime(source);
            }
            else if (targetType == typeof (double))
            {
                ret = Convert.ToDouble(source);
            }
            else if (targetType == typeof (float) || targetType == typeof (Single))
            {
                ret = Convert.ToSingle(source);
            }
            else if (targetType == typeof (long))
            {
                ret = Convert.ToInt64(source);
            }
            else
            {
                ret = Convert.ToString(source).Trim();
            }

            return ret;
        }
    }
}
