using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ListaProjetos.Views
{
    public partial class CreateProjects : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadSubjects();
        }

        protected void btnProjeto_Click(object sender, EventArgs e)
        {
            
        }

        public void LoadSubjects()
        {
            try
            {
                String queryString = "select * from tblStatus";

                DataTable dt = Connection.executarSQL(queryString);

                if (dt.Rows.Count > 0)
                {
                    ddlStatus.DataSource = dt;
                    ddlStatus.DataBind();
                    ddlStatus.DataTextField = "descricao";
                    ddlStatus.DataValueField = "codStatus";
                    ddlStatus.DataBind();
                }
                else
                {
                    Utils.ShowMessage(Page, "Erro ao cadastrar!");
                }
            }
            catch (Exception ex)
            {
                Utils.ShowMessage(Page, "Erro ao cadastrar!");
            }
        }
    }
}