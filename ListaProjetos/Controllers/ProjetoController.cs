using ListaProjetos.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace ListaProjetos.Controllers
{
    public class ProjetoController
    {
        public static void criarProjeto(Page page, Projeto projeto)
        {
            SqlConnection conn;
            String queryString = "insert into tblProjeto (codStatus, codTag, titulo, descricao) values (@codStatus, @codTag, @titulo, @descricao)";

            try
            {
                conn = Connection.open();

                SqlCommand cmd = new SqlCommand(queryString, conn);

                cmd.Parameters.Add("@codStatus", SqlDbType.Int).Value = projeto.getCodStatus();
                cmd.Parameters.Add("@codTag", SqlDbType.Int).Value = projeto.getCodTag();
                cmd.Parameters.Add("@titulo", SqlDbType.NVarChar, 70).Value = projeto.getTitulo();
                cmd.Parameters.Add("@descricao", SqlDbType.NVarChar, 200).Value = projeto.getDescricao();

                cmd.ExecuteScalar();

                Utils.ShowMessage(page, "Sucesso!");
            }
            catch (Exception)
            {
                Utils.ShowMessage(page, "Error ao cadastrar Projeto");
            }
        }
        public static int finalProjeto(Page page)
        {
            SqlConnection conn;
            String queryString = "select ident_current('tblProjeto') as TOTAL";

            try
            {
                conn = Connection.open();

                SqlCommand cmd = new SqlCommand(queryString, conn);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return int.Parse(reader["TOTAL"].ToString());
                }
                else
                {
                    return -1;
                }
            }
            catch (Exception)
            {
                Utils.ShowMessage(page, "Error");
                return -1;
            }
        }
    }
}