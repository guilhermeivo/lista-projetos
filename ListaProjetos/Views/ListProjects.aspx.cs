using System;
using System.Data;

namespace ListaProjetos
{
    public partial class ListProjects : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String codUsuario = Request.Cookies["codUsuario"].Value;

            String queryString = "select codStatus, codTag, titulo, descricao from tblProjeto inner join tblProjetoUsuario on tblProjeto.codProjeto = tblProjetoUsuario.codUsuario and tblProjetoUsuario.codUsuario = '" + codUsuario + "'";

            DataTable dt = Connection.executarSQL(queryString);
            

            if (dt.Rows.Count > 0)
            {
                DataRow[] rows = dt.Select();

                rptProjetos.DataSource = dt;
                rptProjetos.DataBind();
            }        
            else
            {
                boxProjects.InnerText = "Não foi encontrado nenhum projeto";
            }
        }
    }
}