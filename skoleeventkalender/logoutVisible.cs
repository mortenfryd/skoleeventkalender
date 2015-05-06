using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace skoleeventkalender
{
    public class logoutVisible
    {
        public void logoutVisibleM()
        {
            if (HttpContext.Current.Session["u_id"] != null)
            {
                LiteralControl logout = new LiteralControl();
                logout.Text = "<div class=\"log\" align=\"right\"><a id=\"logoutBtn\" href=\"\">Log ud</a></div>";
                logout.Visible = true;
            }
            else
            {
                LiteralControl logout = new LiteralControl();
                logout.Text = "<div class=\"log\" align=\"right\"><a id=\"logoutBtn\" href=\"\">Log ud</a></div>";
                logout.Visible = false;
            }
        }
    }
}