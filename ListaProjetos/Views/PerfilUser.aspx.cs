using ListaProjetos.Model;
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

                        int codUsuario = int.Parse(Request.Cookies["codUsuario"].Value);

                        Usuario usuario = UsuarioController.listarUsuarioCod(this, codUsuario);

                        if (usuario != null)
                        {
                            txtNome.Text = usuario.getNome();
                            txtUsername.Text = usuario.getUsername();
                            txtEmail.Text = usuario.getEmail();
                            txtPassword.Text = usuario.getSenha();
                            txtWebsite.Text = usuario.getLinkWebsite();
                            txtCidade.Text = usuario.getLocalizacao();
                        }
                        else
                        {
                            Utils.ShowMessage(this, "Error");
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
            Usuario usuario = new Usuario();

            usuario.setCodUsuario(int.Parse(Request.Cookies["codUsuario"].Value));
            usuario.setNome(txtNome.Text);
            usuario.setUsername(txtUsername.Text);
            usuario.setEmail(txtEmail.Text);
            usuario.setSenha(txtPassword.Text);
            String confirmSenha = txtConfirmPassowrd.Text;
            usuario.setLinkWebsite(txtWebsite.Text);
            usuario.setLocalizacao(txtCidade.Text);

            try
            {
                if (usuario.getSenha() == confirmSenha)
                {
                    UsuarioController.alterarUsuario(this, usuario);

                    Response.Redirect("~/");
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