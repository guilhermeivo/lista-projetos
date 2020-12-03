using System;
using System.Data;
using System.Data.SqlClient;

namespace ListaProjetos
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                String nome = txtNome.Text.Trim();
                String email = txtEmail.Text.Trim();
                String senha = txtPassword.Text.Trim();

                if (nome != null && email != null && senha != null)
                {
                    if (thisEmailIsUnique(email))
                    {
                        String queryString = "insert into tblUsuario (nome, email, senha) values (@nome, @email, @senha)";
                        SqlCommand cmd = new SqlCommand(queryString);

                        cmd.Parameters.Add("@nome", SqlDbType.NVarChar, 70).Value = nome;
                        cmd.Parameters.Add("@email", SqlDbType.NVarChar, 70).Value = email;
                        cmd.Parameters.Add("@senha", SqlDbType.NVarChar, 70).Value = senha;

                        int flag = Connection.manutencaoDB(cmd);

                        if (flag > 0)
                        {
                            Utils.ShowMessage(Page, "Cadastrado Com sucesso!");
                        }
                        else
                        {
                            Utils.ShowMessage(Page, "Erro ao cadastrar!");
                        }
                    }
                    else
                    {
                        Utils.ShowMessage(Page, "Já tem uma email cadastrado com esse nome!");
                    }
                }
                else
                {
                    
                }
            }
            catch (Exception error)
            {
                Utils.ShowMessage(Page, "error" + error);
            }
        }

        public bool thisEmailIsUnique(String email)
        {
            try
            {
                String queryString = "select email from tblUsuario where email = '" + email + "'";

                DataTable dt = Connection.executarSQL(queryString);

                if (dt.Rows.Count > 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}