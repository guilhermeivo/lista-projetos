using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ListaProjetos.Views
{
    public partial class PerfilUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    if (Request.Cookies["codUsuario"] != null)
                    {
                        String codUsuario = Request.Cookies["codUsuario"].Value;
                        String nome = "";
                        String username = "";
                        String email = "";
                        String senha = "";
                        String linkWebsite = "";
                        String localizacao = "";

                        String queryString = "select * from tblUsuario where '" + codUsuario + "' = codUsuario";

                        DataTable dt = Connection.executarSQL(queryString);

                        if (dt != null)
                        {
                            if (dt.Rows.Count > 0)
                            {
                                DataRow[] rows = dt.Select();

                                nome = rows[0]["nome"].ToString();
                                username = rows[0]["username"].ToString();
                                email = rows[0]["email"].ToString();
                                senha = rows[0]["senha"].ToString();
                                linkWebsite = rows[0]["linkWebsite"].ToString();
                                localizacao = rows[0]["localizacao"].ToString();

                                txtNome.Text = nome;
                                txtUsername.Text = username;
                                txtEmail.Text = email;
                                txtPassword.Text = senha;
                                txtWebsite.Text = linkWebsite;
                                txtCidade.Text = localizacao;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Utils.ShowMessage(this, "Error:" + ex);
                }
            }            
        }

        protected void btnAtualizar_Click(object sender, EventArgs e)
        {
            String codUsuario = Request.Cookies["codUsuario"].Value;
            String nome = "";
            String username = "";
            String email = "";
            String senha = "";
            String confirmSenha = "";
            String linkWebsite = "";
            String localizacao = "";

            nome = txtNome.Text;
            username = txtUsername.Text;
            email = txtEmail.Text;
            senha = txtPassword.Text;
            confirmSenha = txtConfirmPassowrd.Text;
            linkWebsite = txtWebsite.Text;
            localizacao = txtCidade.Text;

            try
            {
                if (senha == confirmSenha)
                {
                    String queryString = "update tblUsuario set nome = @nome, username = @username, email = @email, senha = @senha, linkWebsite = @linkWebsite, localizacao = @localizacao where codUsuario = " + codUsuario;
                    SqlCommand cmd = new SqlCommand(queryString);

                    cmd.Parameters.Add("@nome", SqlDbType.NVarChar, 70).Value = nome;
                    cmd.Parameters.Add("@username", SqlDbType.NVarChar, 70).Value = username;
                    cmd.Parameters.Add("@email", SqlDbType.NVarChar, 70).Value = email;
                    cmd.Parameters.Add("@senha", SqlDbType.NVarChar, 70).Value = senha;
                    cmd.Parameters.Add("@linkWebsite", SqlDbType.NVarChar, 70).Value = linkWebsite;
                    cmd.Parameters.Add("@localizacao", SqlDbType.NVarChar, 70).Value = localizacao;

                    int flag = Connection.manutencaoDB(cmd);

                    if (flag > 0)
                    {
                        Utils.ShowMessage(this, "Atualizado Com sucesso!");

                        Response.Redirect("~/");
                    }
                    else
                    {
                        Utils.ShowMessage(this, "Erro ao atualizar!");
                    }
                }
                else
                {
                    Utils.ShowMessage(this, "Senha Incorreta!");
                }
            }
            catch (Exception ex)
            {
                Utils.ShowMessage(this, "Error:" + ex);
            }            
        }

        protected void btnSair_Click(object sender, EventArgs e)
        {
            Response.Cookies["codUsuario"].Expires = DateTime.Now.AddDays(-1);
            Response.Redirect("~/");
        }
    }
}