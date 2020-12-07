using ListaProjetos.Model;
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
                Usuario usuario = new Usuario();
                usuario.setNome(txtNome.Text.Trim());
                usuario.setEmail(txtEmail.Text.Trim());
                usuario.setSenha(txtPassword.Text.Trim());
                String confirmSenha = txtConfirmPassowrd.Text.Trim();

                if ((usuario.getNome() != "") && (usuario.getEmail() != "") && (usuario.getSenha() != "") && (confirmSenha != ""))
                {
                    if (usuario.getSenha() == confirmSenha)
                    {
                        if (chbConfirm.Checked)
                        {
                            if (thisEmailIsUnique(usuario.getEmail()))
                            {
                                UsuarioController.criarUsuario(this, usuario);                                
                            }
                            else
                            {
                                Utils.ShowMessage(this, "Já tem uma email cadastrado com esse nome!");
                            }
                        }
                        else
                        {
                            Utils.ShowMessage(this, "É necessário aceita os termos!");
                        }
                    }
                    else
                    {
                        Utils.ShowMessage(this, "Senhas diferentes!");
                    }
                }
                else
                {
                    Utils.ShowMessage(this, "É necessário completar todos os campos!");
                }
            }
            catch (Exception error)
            {
                Utils.ShowMessage(this, "error" + error);
            }
        }

        public bool thisEmailIsUnique(String email)
        {
            Usuario usuario = UsuarioController.listarUsuarioEmail(this, email);

            if (usuario == null)
            {
                return true;
            }
            else
            {
                return false;
            }            
        }
    }
}