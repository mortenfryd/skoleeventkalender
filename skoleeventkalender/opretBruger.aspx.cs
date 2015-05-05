using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace skoleeventkalender
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void confirm_Click(object sender, EventArgs e)
        {
            if (username.Text != "" && password.Text != "" && passwordconfirm.Text != "")
            {
                //Der er noget i felterne, vi fortsætter
            }
            else
            {
                errorlabel.Text = "Fejl i indtastning";
            }
        }

        protected void tilbage_Click(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx");
        }
    }
}