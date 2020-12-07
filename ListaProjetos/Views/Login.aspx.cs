using ListaProjetos.Model;
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
                String email = (txtEmail.Text.Trim());
                String senha = txtPassword.Text.Trim();

                if (email != "" && senha != "")
                {
                    Usuario usuario = UsuarioController.listarUsuarioEmail(this, email);
                    
                    if (usuario.getSenha() == senha)
                    {
                        Response.Cookies["codUsuario"].Value = Convert.ToString(usuario.getCodUsuario());
                        Response.Cookies["codUsuario"].Expires = DateTime.Now.AddDays(1d);

                        Response.Redirect("~/");
                    }
                    else
                    {
                        Utils.ShowMessage(this, "Erro ao efetuar login!");
                    }
                }
                else
                {
                    Utils.ShowMessage(this, "Insira os valores!");
                }
            }
            catch (Exception error)
            {
                Utils.ShowMessage(this, "error" + error);
            }
        }
    }
}