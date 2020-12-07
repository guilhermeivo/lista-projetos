using System;
using System.Data;
using System.Data.SqlClient;

namespace ListaProjetos
{
    public class Connection
    {
        private static string connString = "Password=12345; Persist Security Info=True; User ID=sa; Initial Catalog=ListaProjetos; Data Source=" + Environment.MachineName;
        private static SqlConnection conn = null;

        public static SqlConnection open()
        {
            conn = new SqlConnection();

            try
            {
                conn = new SqlConnection(connString);
                conn.Open();
            }
            catch (Exception)
            {
                conn = null;
            }

            return conn;
        }

        public static void close()
        {
            try
            {
                if (conn != null)
                {
                    conn.Close();
                    conn.Dispose();
                    conn = null;
                }
            }
            catch (Exception)
            {
            }
        }      
    }
}