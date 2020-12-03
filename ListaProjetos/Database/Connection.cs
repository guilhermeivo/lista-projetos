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

        public static DataTable executarSQL(String queryString) // select, procedures, etc
        {
            conn = Connection.open();

            try
            {
                SqlDataAdapter adaptador = new SqlDataAdapter(queryString, conn);
                DataSet ds = new DataSet();
                adaptador.Fill(ds);
                return ds.Tables[0];
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                Connection.close();
            }
        }

        public static int manutencaoDB(SqlCommand cmd) //incluir, alterar, excluir
        {
            try
            {
                cmd.Connection = Connection.open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return 0;
            }
            finally
            {
                Connection.close();
            }
        }
    }
}