using ListaProjetos.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace ListaProjetos
{
    public static class UsuarioController
    {
        public static void criarUsuario(Page page, Usuario usuario)
        {
            SqlConnection conn;
            String queryString = "insert into tblUsuario (nome, username, email, senha, linkWebsite, localizacao) values (@nome, @username, @email, @senha, @linkWebsite, @localizacao)";

            try
            {
                conn = Connection.open();

                SqlCommand cmd = new SqlCommand(queryString, conn);

                cmd.Parameters.Add("@nome", SqlDbType.NVarChar, 70).Value = usuario.getNome();
                cmd.Parameters.Add("@username", SqlDbType.NVarChar, 70).Value = usuario.getUsername();
                cmd.Parameters.Add("@email", SqlDbType.NVarChar, 70).Value = usuario.getEmail();
                cmd.Parameters.Add("@senha", SqlDbType.NVarChar, 70).Value = usuario.getSenha();                
                cmd.Parameters.Add("@linkWebsite", SqlDbType.NVarChar, 70).Value = usuario.getLinkWebsite();
                cmd.Parameters.Add("@localizacao", SqlDbType.NVarChar, 70).Value = usuario.getLocalizacao();

                cmd.ExecuteScalar();

                Utils.ShowMessage(page, "Sucesso!");
            }
            catch (Exception ex)
            {
                Utils.ShowMessage(page, "Error");
            }
        }
        public static Usuario listarUsuarioEmail(Page page, String email)
        {
            SqlConnection conn;
            String queryString = "select * from tblUsuario where email = @email";

            try
            {
                conn = Connection.open();

                SqlCommand cmd = new SqlCommand(queryString, conn);
                cmd.Parameters.AddWithValue("@email", email);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    Usuario usuario = new Usuario();
                    usuario.setEmail(email);

                    usuario.setCodUsuario(int.Parse(reader["codUsuario"].ToString()));
                    usuario.setNome(reader["nome"].ToString());
                    usuario.setUsername(reader["username"].ToString());
                    usuario.setSenha(reader["senha"].ToString());
                    usuario.setLinkWebsite(reader["linkWebsite"].ToString());
                    usuario.setLocalizacao(reader["localizacao"].ToString());

                    return usuario;
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
        public static Usuario listarUsuarioCod(Page page, String codUsuario)
        {
            SqlConnection conn;
            String queryString = "select * from tblUsuario where codUsuario = @codUsuario";

            try
            {
                conn = Connection.open();

                SqlCommand cmd = new SqlCommand(queryString, conn);
                cmd.Parameters.AddWithValue("@codUsuario", codUsuario);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    Usuario usuario = new Usuario();
                    usuario.setCodUsuario(int.Parse(codUsuario));

                    usuario.setCodUsuario(int.Parse(reader["codUsuario"].ToString()));
                    usuario.setNome(reader["nome"].ToString());
                    usuario.setUsername(reader["username"].ToString());
                    usuario.setEmail(reader["email"].ToString());
                    usuario.setSenha(reader["senha"].ToString());
                    usuario.setLinkWebsite(reader["linkWebsite"].ToString());
                    usuario.setLocalizacao(reader["localizacao"].ToString());

                    return usuario;
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
        public static void alterarUsuario(Page page, Usuario usuario)
        {
            SqlConnection conn; 
            string queryString = "update tblUsuario set nome = @nome, username = @username, email = @email, senha = @senha, linkWebsite = @linkWebsite, localizacao = @localizacao where codUsuario = @Id";

            try
            {
                conn = Connection.open();

                SqlCommand cmd = new SqlCommand(queryString, conn);
                cmd.Parameters.Add("@Id", SqlDbType.Int).Value = usuario.getCodUsuario();
                cmd.Parameters.Add("@nome", SqlDbType.NVarChar, 70).Value = usuario.getNome();
                cmd.Parameters.Add("@username", SqlDbType.NVarChar, 70).Value = usuario.getUsername();
                cmd.Parameters.Add("@email", SqlDbType.NVarChar, 70).Value = usuario.getEmail();
                cmd.Parameters.Add("@senha", SqlDbType.NVarChar, 70).Value = usuario.getSenha();
                cmd.Parameters.Add("@linkWebsite", SqlDbType.NVarChar, 70).Value = usuario.getLinkWebsite();
                cmd.Parameters.Add("@localizacao", SqlDbType.NVarChar, 70).Value = usuario.getLocalizacao();

                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    Utils.ShowMessage(page, "Registro atualizado com sucesso!");
                }
            }
            catch (Exception ex)
            {
                Utils.ShowMessage(page, "Error");
            }
        }
    }
}