using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace ListaProjetos
{
    public static class Utils
    {
        public static void WindowAlertJavaScript(String alertString, Page page)
        {
            page.ClientScript.RegisterClientScriptBlock(page.GetType(), "OK", "window.alert('" + alertString + "');", true);
        }
    }
}