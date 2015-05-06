using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace skoleeventkalender
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            logoutVisible log =new logoutVisible();
            log.logoutVisibleM();
        }

        protected void LogoutBtn_Click(object sender, EventArgs e)
        {
            Session["u_id"] = null;
            Response.Redirect("Default.aspx");
        }
    }
}