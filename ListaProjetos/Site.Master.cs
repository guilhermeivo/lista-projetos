using ListaProjetos.Model;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ListaProjetos
{
    public partial class Web : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {          
            try
            {
                if (Request.Cookies["codUsuario"] != null)
                {
                    int codUsuario = int.Parse(Request.Cookies["codUsuario"].Value);
                    String imagem = "";

                    Usuario usuario = UsuarioController.listarUsuarioCod(Page, codUsuario);

                    if (usuario != null)
                    {
                        // HyperLink in menu
                        HyperLink LinkList = new HyperLink();
                        LinkList.NavigateUrl = "~/Views/ListProjects.aspx";
                        LinkList.Text = "Projetos";
                        
                        navigationMenu.Controls.Add(LinkList);

                        // Photo perfil                        

                        ImageButton imgPhotoPerfil = new ImageButton();

                        if (imagem == "")
                        {
                            imgPhotoPerfil.ImageUrl = "~/Content/perfilPhoto.jpg";
                            imgPhotoPerfil.CssClass = "imgPhotoPerfil";
                            imgPhotoPerfil.ID = "ImgPhoto";
                            imgPhotoPerfil.Click += new ImageClickEventHandler(ImgPhoto_Click);
                        }
                        else
                        {
                            imgPhotoPerfil.CssClass = "imgPhotoPerfil";
                        }

                        loginMenu.InnerHtml = String.Empty;

                        LiteralControl iconPerfil = new LiteralControl("<span class='material-icons'>keyboard_arrow_down</span>");
                        loginMenu.Controls.Add(imgPhotoPerfil);
                        loginMenu.Controls.Add(iconPerfil);
                    }                    
                }
            }
            catch (Exception ex)
            {
                Utils.ShowMessage(Page, "Error:" + ex);
            }
        }
        public void ImgPhoto_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Views/PerfilUser.aspx");
        }
    }
}