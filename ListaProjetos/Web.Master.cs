using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ListaProjetos
{
    public partial class Web : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (false)
            {
                HyperLink LinkList = new HyperLink();
                LinkList.NavigateUrl = "~/Pages/ListProjects.aspx";
                LinkList.Text = "Projetos";

                navigationMenu.Controls.Add(LinkList);
            }
        }
    }
}