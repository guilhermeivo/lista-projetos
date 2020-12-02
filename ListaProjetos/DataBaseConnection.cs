using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ListaProjetos
{
    public class DataBaseConnection
    {
        private static string connString = "Password=12345; Persist Security Info=True; User ID=sa; Initial Catalog=ListaProjetos; Data Source=" + Environment.MachineName;
        private static SqlConnection conn = null;

        public static SqlConnection obterConexao()
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

        public static void fecharConexao()
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
            conn = DataBaseConnection.obterConexao();

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
                DataBaseConnection.fecharConexao();
            }
        }

        public static int manutencaoDB(SqlCommand cmd) //incluir, alterar, excluir
        {
            try
            {
                cmd.Connection = DataBaseConnection.obterConexao();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return 0;
            }
            finally
            {
                DataBaseConnection.fecharConexao();
            }
        }
    }
}