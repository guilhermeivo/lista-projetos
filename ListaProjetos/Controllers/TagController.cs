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
    public class TagController
    {
        public static void criarTag(Page page, Tag tag)
        {
            SqlConnection conn;
            String queryString = "insert into tblTag (descricao) values (@descricao)";

            try
            {
                conn = Connection.open();

                SqlCommand cmd = new SqlCommand(queryString, conn);
                cmd.Parameters.Add("@descricao", SqlDbType.NVarChar, 200).Value = tag.getDescricao();

                cmd.ExecuteScalar();

                Utils.ShowMessage(page, "Sucesso!");
            }
            catch (Exception)
            {
                Utils.ShowMessage(page, "Error");
            }
        }
        public static Tag listarTag(Page page, String descricao)
        {
            SqlConnection conn;
            String queryString = "select * from tblTag where @descricao = descricao";

            try
            {
                conn = Connection.open();

                SqlCommand cmd = new SqlCommand(queryString, conn);
                cmd.Parameters.AddWithValue("@descricao", descricao);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    Tag tag = new Tag();
                    tag.setDescricao(descricao);

                    tag.setCodTag(int.Parse(reader["codTag"].ToString()));
                    tag.setDescricao(reader["descricao"].ToString());

                    return tag;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
        }
    }
}