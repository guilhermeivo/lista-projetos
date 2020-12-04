using System;
using System.Data;
using System.Data.SqlClient;

namespace ListaProjetos
{
    public partial class ListProjects : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String codUsuario = Request.Cookies["codUsuario"].Value;

            String queryString = "select tblProjeto.codProjeto, tblProjeto.titulo, tblProjeto.descricao, tblTag.descricao as tag, tblStatus.descricao as status from tblProjeto inner join tblProjetoUsuario on tblProjeto.codProjeto = tblProjetoUsuario.codProjeto inner join tblTag on tblProjeto.codTag = tblTag.codTag inner join tblStatus on tblProjeto.codStatus = tblStatus.codStatus where tblProjetoUsuario.codUsuario = "+ codUsuario;

            SqlConnection conn = Connection.open();

            try
            {
                SqlDataAdapter adaptador = new SqlDataAdapter(queryString, conn);
                DataSet ds = new DataSet();
                adaptador.Fill(ds);

                rptProjetos.DataSource = ds;
                rptProjetos.DataBind();
            }
            catch (Exception)
            {
                boxProjects.InnerText = "Não foi encontrado nenhum projeto";
            }
            finally
            {
                Connection.close();
            }     
        }
    }
}