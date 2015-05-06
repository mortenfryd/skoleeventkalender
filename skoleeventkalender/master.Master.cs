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
            if (Session["u_id"] != null)
            {
                LogoutBtn.Visible = true;
            }
            else
            {
                LogoutBtn.Visible = false;
            }
        }

        protected void LogoutBtn_Click(object sender, EventArgs e)
        {
            Session.Contents.Remove("u_id");
            Response.Redirect("Default.aspx");
        }
    }
}