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
    public class ProjetoUsuarioController
    {
        public static void criarProjetoUsuario(Page page, ProjetoUsuario projetoUsuario)
        {
            SqlConnection conn;
            String queryString = "insert into tblProjetoUsuario (codProjeto, codUsuario) values (@codProjeto, @codUsuario)";

            try
            {
                conn = Connection.open();

                SqlCommand cmd = new SqlCommand(queryString, conn);

                cmd.Parameters.Add("@codProjeto", SqlDbType.Int).Value = projetoUsuario.getCodProjeto();
                cmd.Parameters.Add("@codUsuario", SqlDbType.Int).Value = projetoUsuario.getCodUsuario();

                cmd.ExecuteScalar();

                Utils.ShowMessage(page, "Sucesso!");
            }
            catch (Exception)
            {
                Utils.ShowMessage(page, "Error ao cadastrar Projeto");
            }
        }
    }
}