using System;
using System.Data;
using System.Data.SqlClient;

namespace ListaProjetos
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {            
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                String email = txtEmail.Text.Trim();
                String senha = txtPassword.Text.Trim();

                if (email != null && senha != null)
                {
                    String queryString = "select codUsuario, email, senha from tblUsuario where '" + email + "' = email and '" + senha + "' = senha";

                    DataTable dt = Connection.executarSQL(queryString);
                    DataRow[] rows = dt.Select();

                    if (dt.Rows.Count > 0)
                    {
                        Response.Cookies["codUsuario"].Value = rows[0]["codUsuario"].ToString();
                        Response.Cookies["codUsuario"].Expires = DateTime.Now.AddDays(1d);

                        Utils.ShowMessage(Page, "Login Aprovado!");

                        Response.Redirect("~/");
                    }
                    else
                    {
                        Utils.ShowMessage(Page, "Erro ao efetuar login!");
                    }
                }
                else
                {
                    Utils.ShowMessage(Page, "Insira os valores!");
                }
            }
            catch (Exception error)
            {
                Utils.ShowMessage(Page, "error" + error);
            }
        }
    }
}