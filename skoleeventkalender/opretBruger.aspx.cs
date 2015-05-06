using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace skoleeventkalender
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["u_id"] != null)
            {
                Response.Redirect("eventview.aspx");
            }
            else
            {
                
            }
        }

        protected void confirm_Click(object sender, EventArgs e)
        {
            databaseConnection DB = new databaseConnection();
            DB.DBConnect();

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