using System;
using System.Web.UI;

namespace ListaProjetos
{
    public static class Utils
    {
        public static void ShowMessage(Page page, String alertString)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "OK", "window.alert('" + alertString + "');", true);
        }
    }
}