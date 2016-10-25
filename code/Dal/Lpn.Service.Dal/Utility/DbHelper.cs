using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Collections;
using System.Data;
using System.Reflection;

namespace OneCoin.Service.Dal.Utility
{
    public class DbHelper
    {
        public DbHelper() { }

        private static Hashtable parmCache = Hashtable.Synchronized(new Hashtable());
        //存放MySqlConnection
        //public static Dictionary<string, MySqlConnection> sqlConnections = new Dictionary<string, MySqlConnection>();

        public static void CloseConn(MySqlConnection conn)
        {
            if (conn != null)
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
        }

        public static void OpenConn(MySqlConnection conn)
        {
            if (conn != null)
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
            }
        }

        public static int ExecuteNonQuery(string connectionString, string cmdText, params MySqlParameter[] commandParameters)
        {
            MySqlCommand cmd = new MySqlCommand();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                PrepareCommand(cmd, conn, null, CommandType.Text, cmdText, commandParameters);
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val;
            }
        }

        public static int ExecuteNonQuery(MySqlConnection conn, string cmdText, bool isTransaction, params MySqlParameter[] commandParameters)
        {
            MySqlCommand cmd = new MySqlCommand();
            PrepareCommand(cmd, conn, null, CommandType.Text, cmdText, commandParameters);
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            if (!isTransaction && conn != null)
            {
                conn.Close();
            }
            return val;
        }

        public static int ExecuteNonQuery(string connectionString, CommandType cmdType, string cmdText, params MySqlParameter[] commandParameters)
        {
            MySqlCommand cmd = new MySqlCommand();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val;
            }
        }

        public static int ExecuteNonQuery(MySqlConnection conn, CommandType cmdType, string cmdText, bool isTransaction, params MySqlParameter[] commandParameters)
        {
            MySqlCommand cmd = new MySqlCommand();
            PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            if (!isTransaction && conn != null)
            {
                conn.Close();
            }
            return val;
        }

        public static int ExecuteNonQuery(MySqlTransaction trans, CommandType cmdType, string cmdText, params MySqlParameter[] commandParameters)
        {
            MySqlCommand cmd = new MySqlCommand();
            PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, commandParameters);
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return val;
        }

        public static MySqlDataReader ExecuteReader(MySqlConnection conn, string cmdText)
        {
            MySqlCommand cmd = new MySqlCommand();
            PrepareCommand(cmd, conn, null, CommandType.Text, cmdText, null);
            MySqlDataReader rdr = cmd.ExecuteReader();
            cmd.Parameters.Clear();
            return rdr;
        }

        public static MySqlDataReader ExecuteReader(MySqlConnection conn, string cmdText, params MySqlParameter[] commandParameters)
        {
            MySqlCommand cmd = new MySqlCommand();
            PrepareCommand(cmd, conn, null, CommandType.Text, cmdText, commandParameters);
            MySqlDataReader rdr = cmd.ExecuteReader();
            cmd.Parameters.Clear();
            return rdr;
        }

        public static MySqlDataReader ExecuteReader(string connectionString, string cmdText, params MySqlParameter[] commandParameters)
        {
            MySqlCommand cmd = new MySqlCommand();
            MySqlConnection conn = new MySqlConnection(connectionString);
            PrepareCommand(cmd, conn, null, CommandType.Text, cmdText, commandParameters);
            MySqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd.Parameters.Clear();
            return rdr;
        }



        public static MySqlDataReader ExecuteReader(string connectionString, CommandType cmdType, string cmdText, params MySqlParameter[] commandParameters)
        {
            MySqlCommand cmd = new MySqlCommand();
            MySqlConnection conn = new MySqlConnection(connectionString);
            PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
            MySqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            cmd.Parameters.Clear();
            return rdr;
        }


        public static MySqlDataReader ExecuteReader(MySqlConnection conn, CommandType cmdType, string cmdText,params MySqlParameter[] commandParameters)
        {
            MySqlCommand cmd = new MySqlCommand();
            PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
            MySqlDataReader rdr = cmd.ExecuteReader();
            cmd.Parameters.Clear();
            return rdr;
        }


        public static MySqlDataReader ExecuteReader(MySqlConnection conn, CommandType cmdType, string cmdText, CommandBehavior commandBehavior, params MySqlParameter[] commandParameters)
        {
            MySqlCommand cmd = new MySqlCommand();
            PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
            MySqlDataReader rdr = cmd.ExecuteReader(commandBehavior);
            cmd.Parameters.Clear();
            return rdr;
        }

        public static object ExecuteScalar(string connectionString, string cmdText)
        {
            MySqlCommand cmd = new MySqlCommand();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                PrepareCommand(cmd, conn, null, CommandType.Text, cmdText, null);
                object val = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                return val;
            }
        }

        public static object ExecuteScalar(MySqlConnection conn, string cmdText)
        {
            MySqlCommand cmd = new MySqlCommand();
            PrepareCommand(cmd, conn, null, CommandType.Text, cmdText, null);
            object val = cmd.ExecuteScalar();
            cmd.Parameters.Clear();
            return val;
        }

        public static object ExecuteScalar(string connectionString, CommandType cmdType, string cmdText, params MySqlParameter[] commandParameters)
        {
            MySqlCommand cmd = new MySqlCommand();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
                object val = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                return val;
            }
        }

        public static object ExecuteScalar(MySqlConnection conn, CommandType cmdType, string cmdText, params MySqlParameter[] commandParameters)
        {
            MySqlCommand cmd = new MySqlCommand();
            PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
            object val = cmd.ExecuteScalar();
            cmd.Parameters.Clear();
            return val;
        }

        public static void CacheParameters(string cacheKey, params MySqlParameter[] commandParameters)
        {
            parmCache[cacheKey] = commandParameters;
        }

        public static MySqlParameter[] GetCachedParameters(string cacheKey)
        {
            MySqlParameter[] cachedParms = (MySqlParameter[])parmCache[cacheKey];
            if (cachedParms == null)
                return null;
            MySqlParameter[] clonedParms = new MySqlParameter[cachedParms.Length];
            for (int i = 0, j = cachedParms.Length; i < j; i++)
                clonedParms[i] = (MySqlParameter)((ICloneable)cachedParms[i]).Clone();
            return clonedParms;
        }

        private static void PrepareCommand(MySqlCommand cmd, MySqlConnection conn, MySqlTransaction trans, CommandType cmdType, string cmdText, MySqlParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
                cmd.Transaction = trans;
            cmd.CommandType = cmdType;
            if (cmdParms != null)
            {
                foreach (MySqlParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
        }

        public static long ExecuteReaderIdentity(string connStr, CommandType commandType, string cmdText, params MySqlParameter[] sqlParameter)
        {
            long indexer = 0;
            using (MySqlDataReader reader = DbHelper.ExecuteReader(connStr, commandType, cmdText, sqlParameter))
            {
                while (reader.Read())
                {
                    indexer = ToInt64(reader[0]);
                }
            }
            return indexer;
        }

        public static int ExecuteReaderIdentityInt32(string connStr, CommandType commandType, string cmdText, params MySqlParameter[] sqlParameter)
        {
            int indexer = 0;
            using (MySqlDataReader reader = DbHelper.ExecuteReader(connStr, commandType, cmdText, sqlParameter))
            {
                while (reader.Read())
                {
                    indexer = ToInt32(reader[0]);
                }
            }
            return indexer;
        }


        public static int ExecuteReaderIdentityInt32(string connStr,  string cmdText, params MySqlParameter[] sqlParameter)
        {
            return ExecuteReaderIdentityInt32(connStr, CommandType.Text, cmdText, sqlParameter);
        }

        public static long ExecuteReaderIdentity(string connStr, string cmdText, params MySqlParameter[] sqlParameter)
        {
            long indexer = 0;
            using (MySqlDataReader reader = DbHelper.ExecuteReader(connStr, CommandType.Text, cmdText, sqlParameter))
            {
                while (reader.Read())
                {
                    indexer = ToInt64(reader[0]);
                }
            }
            return indexer;
        }

        public static long ExecuteReaderIdentity(MySqlConnection conn, string cmdText, List<MySqlParameter> sqlParameter)
        {
            long indexer = 0;
            MySqlParameter[] para = null;
            if (sqlParameter.Count > 1)
            {
                para = new MySqlParameter[sqlParameter.Count];
                for (int i = 0; i < sqlParameter.Count; i++)
                {
                    para[i] = (MySqlParameter)sqlParameter[i];
                }
            }
            using (MySqlDataReader reader = DbHelper.ExecuteReader(conn, CommandType.Text, cmdText, para))
            {
                while (reader.Read())
                {
                    indexer = ToInt64(reader[0]);
                }
                return indexer;
            }
        }

        public static long ExecuteReaderIdentity(bool isTransaction, MySqlConnection conn, string cmdText, params MySqlParameter[] sqlParameter)
        {
            long indexer = 0;

            using (MySqlDataReader reader = DbHelper.ExecuteReader(conn, CommandType.Text, cmdText, sqlParameter))
            {
                while (reader.Read())
                {
                    indexer = ToInt64(reader[0]);
                }
                if (!isTransaction && conn != null)
                {
                    conn.Close();
                }
                return indexer;
            }
        }

        public static long ExecuteReaderIdentity(MySqlConnection conn, CommandType cmdType, string cmdText, params MySqlParameter[] sqlParameter)
        {
            long indexer = 0;
            using (MySqlDataReader reader = DbHelper.ExecuteReader(conn, cmdType, cmdText, sqlParameter))
            {
                while (reader.Read())
                {

                    indexer = ToInt64(reader[0]);
                }
            }
            return indexer;
        }


        public static int ExecuteReaderIdentityInt32(MySqlConnection conn, CommandType cmdType, string cmdText, params MySqlParameter[] sqlParameter)
        {
            int indexer = 0;
            using (MySqlDataReader reader = DbHelper.ExecuteReader(conn, cmdType, cmdText, sqlParameter))
            {
                while (reader.Read())
                {
                    indexer = ToInt32(reader[0]);
                }
            }
            return indexer;
        }
 

        public static object ExecuteReturnOneField(MySqlConnection conn, CommandType cmdType, string cmdText, params MySqlParameter[] sqlParameter)
        {
            using (MySqlDataReader reader = DbHelper.ExecuteReader(conn, cmdType, cmdText, sqlParameter))
            {
                if (reader.Read())
                {
                    return reader[0];
                }
                else
                {
                    return null;
                }
            }
        }


        public static DataSet ExecuteDataSet(string connectionString, string cmdText)
        {
            MySqlCommand cmd = new MySqlCommand();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                PrepareCommand(cmd, conn, null, CommandType.Text, cmdText, null);

                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataSet data = new DataSet();

                adapter.Fill(data);
                if (conn != null)
                {
                    conn.Close();
                }
                return data;
            }
        }

        private static DataSet ExecuteDataSetF(MySqlConnection conn, CommandType cmdType, string cmdText, bool isTransaction, IList commandParameters)
        {
            MySqlCommand cmd = new MySqlCommand();

            PrepareCommand(cmd, conn, null, cmdType, cmdText, (MySqlParameter[])commandParameters);

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataSet data = new DataSet();
            data.EnforceConstraints = false;
            adapter.Fill(data);
            if (!isTransaction && conn != null)
            {
                conn.Close();
            }
            return data;
        }

        public static DataSet ExecuteDataSet(MySqlConnection conn, string cmdText, params MySqlParameter[] commandParameters)
        {
            return ExecuteDataSetF(conn, CommandType.Text, cmdText, false, commandParameters);
        }

        public static DataSet ExecuteDataSet(MySqlConnection conn, CommandType cmdType, string cmdText, bool isTransaction, params MySqlParameter[] commandParameters)
        {
            return ExecuteDataSetF(conn, cmdType, cmdText, isTransaction, commandParameters);
        }

        public static DataSet ExecuteDataSet(string connectionString, CommandType cmdType, string cmdText, bool isTransaction, params MySqlParameter[] commandParameters)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                return ExecuteDataSetF(conn, cmdType, cmdText, isTransaction, commandParameters);
            }
        }

        public static DataTable ExecuteDataTable(MySqlConnection conn, string cmdText)
        {
            return ExecuteDataSet(conn, cmdText).Tables[0];
        }

        public static DataTable ExecuteDataTable(MySqlConnection conn, string cmdText, params MySqlParameter[] commandParameters)
        {
            return ExecuteDataSetF(conn, CommandType.Text, cmdText, false, commandParameters).Tables[0];
        }

        public static DataTable ExecuteDataTable(MySqlConnection conn, string cmdText, bool isTransaction, params MySqlParameter[] commandParameters)
        {
            return ExecuteDataSetF(conn, CommandType.Text, cmdText, isTransaction, commandParameters).Tables[0];
        }

        public static DataTable ExecuteDataTable(MySqlConnection conn, string cmdText, bool isTransaction)
        {
            return ExecuteDataSetF(conn, CommandType.Text, cmdText, isTransaction, null).Tables[0];
        }

        public static DataTable ExecuteDataTable(MySqlConnection conn, CommandType cmdType, string cmdText, params MySqlParameter[] commandParameters)
        {
            MySqlCommand cmd = new MySqlCommand();

            PrepareCommand(cmd, conn, null, cmdType, cmdText, commandParameters);
            DataTable dataTable = ExecuteDataSetF(conn, cmdType, cmdText, false, commandParameters).Tables[0];
            cmd.Parameters.Clear();
            return dataTable;
        }

        public static DataTable ExecuteDataTable(string connectionString, CommandType cmdType, string cmdText, bool isTransaction, params MySqlParameter[] commandParameters)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                return ExecuteDataSetF(conn, cmdType, cmdText, isTransaction, commandParameters).Tables[0];
            }
        }

        public static DataTable ExecuteDataTable(string connectionString, string cmdText, params MySqlParameter[] commandParameters)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                return ExecuteDataSetF(conn, CommandType.Text, cmdText, false, commandParameters).Tables[0];
            }
        }

        public static T ExecuteReader<T>(string connStr, CommandType commandType, string cmdText, params MySqlParameter[] sqlParameter) where T : new()
        {
            T t = new T();
            Type type = t.GetType();
            using (MySqlDataReader reader = DbHelper.ExecuteReader(connStr, commandType, cmdText, sqlParameter))
            {
                if (!reader.HasRows)
                    t = default(T);
                while (reader.Read())
                {
                    GetValueSqlDataReader<T>(reader, t);
                }
            }
            return t;
        }

        public static T ExecuteReader<T>(MySqlConnection con, CommandType commandType, string cmdText, bool isTransaction, params MySqlParameter[] sqlParameter) where T : new()
        {
            T t = new T();
            Type type = t.GetType();
            using (MySqlDataReader reader = DbHelper.ExecuteReader(con, commandType, cmdText, sqlParameter))
            {
                if (!reader.HasRows)
                    t = default(T);
                while (reader.Read())
                {
                    GetValueSqlDataReader<T>(reader, t);
                }
            }
            if (!isTransaction && con != null)
            {
                con.Close();
            }
            return t;
        }

        public static List<T> ExecuteReaders<T>(string connStr, CommandType commandType, string cmdText, params MySqlParameter[] sqlParameter) where T : new()
        {
            List<T> listT = new List<T>();

            using (MySqlDataReader reader = DbHelper.ExecuteReader(connStr, commandType, cmdText, sqlParameter))
            {
                listT = Reader<T>(listT, reader);
            }
            return listT;
        }

        public static List<T> ExecuteReaders<T>(MySqlConnection con, CommandType commandType, string cmdText, params MySqlParameter[] sqlParameter) where T : new()
        {
            List<T> listT = new List<T>();

            using (MySqlDataReader reader = DbHelper.ExecuteReader(con, commandType, cmdText, sqlParameter))
            {
                listT = Reader<T>(listT, reader);
            }
            return listT;
        }

        public static List<T> ExecuteReaders<T>(MySqlConnection con, CommandType commandType, string cmdText, bool isTransaction, params MySqlParameter[] sqlParameter) where T : new()
        {
            List<T> listT = new List<T>();

            using (MySqlDataReader reader = DbHelper.ExecuteReader(con, commandType, cmdText, sqlParameter))
            {
                listT = Reader<T>(listT, reader);
            }
            if (!isTransaction && con != null)
            {
                con.Close();
            }
            return listT;
        }

        private static List<T> Reader<T>(List<T> listT, MySqlDataReader reader) where T : new()
        {
            if (!reader.HasRows)
                listT = default(List<T>);
            while (reader.Read())
            {
                T t = new T();
                GetValueSqlDataReader<T>(reader, t);
                listT.Add(t);
            }
            return listT;
        }

        private static void GetValueSqlDataReader<T>(MySqlDataReader reader, T t) where T : new()
        {
            Type type = t.GetType();
            for (int i = 0; i < reader.FieldCount; i++)
            {
                string name = reader.GetName(i);
                PropertyInfo propertyInfo = type.GetProperty(name);
                if (propertyInfo != null)
                {
                    object obj = reader[name];
                    if (!string.IsNullOrEmpty(obj.ToString()))
                    {
                        obj = ToType(obj, propertyInfo.PropertyType);

                        propertyInfo.SetValue(t, obj, null);

                    }
                }
            }
        }

        public static object ToType(object obj, Type t)
        {
            object objs = null;
            switch (t.ToString())
            {
                case "System.Boolean":
                    if (obj != null)
                    {
                        switch (obj.ToString())
                        {
                            case "1": objs = true;
                                break;
                            case "0": objs = false;
                                break;
                            case "false": objs = false;
                                break;
                            case "true": objs = true;
                                break;
                            case "yes": objs = true;
                                break;
                            case "no": objs = false;
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                case "System.Byte":
                    objs = Convert.ToByte(obj);
                    break;
                case "System.DateTime":
                    objs = Convert.ToDateTime(obj);
                    break;
                case "System.Decimal":
                    objs = Convert.ToDecimal(obj);
                    break;
                case "System.Double":
                    objs = Convert.ToDouble(obj);
                    break;
                case "System.Int16":
                    objs = Convert.ToInt16(obj);
                    break;
                case "System.Int32":
                    objs = Convert.ToInt32(obj);
                    break;
                case "System.Int64":
                    objs = Convert.ToInt64(obj);
                    break;
                case "System.SByte":
                    objs = Convert.ToSByte(obj);
                    break;
                case "System.Single":
                    objs = Convert.ToSingle(obj);
                    break;
                case "System.UInt16":
                    objs = Convert.ToUInt16(obj);
                    break;
                case "System.UInt32":
                    objs = Convert.ToUInt32(obj);
                    break;
                case "System.UInt64":
                    objs = Convert.ToUInt64(obj);
                    break;
                case "System.String":
                    objs = obj.ToString();
                    break;
                default:
                    objs = obj;
                    break;
            }
            return objs;
        }

        public static int ToInt32(object obj)
        {
            if (obj != null && obj != DBNull.Value)
            {
                int i;
                int.TryParse(obj.ToString(), out i);
                return i;
            }
            else
            {
                return 0;
            }
        }

        public static long ToInt64(object obj)
        {
            if (obj != null && obj != DBNull.Value)
            {
                long i;
                long.TryParse(obj.ToString(), out i);
                return i;
            }
            else
            {
                return 0;
            }
        }

        public static string ToString(object obj)
        {
            if (obj != null && obj != DBNull.Value)
            {
                return obj.ToString();
            }
            else
            {
                return null;
            }
        }


        public static decimal ToDecimal(object obj)
        {
            if (obj != null && obj != DBNull.Value)
            {
                decimal value;
                decimal.TryParse(obj.ToString(), out value);
                return value;
            }
            else
            {
                return 0;
            }
        }

        public static DateTime ToDateTime(object obj)
        {
            if (obj != null && obj != DBNull.Value)
            {
                DateTime value;
                DateTime.TryParse(obj.ToString(), out value);
                return value;
            }
            else
            {
                return DateTime.Now;
            }
        }
    }
}
