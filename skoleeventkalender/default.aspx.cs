using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace skoleeventkalender
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void login_Click(object sender, EventArgs e)
        {
            string DB_user="", DB_pass="";

            if (username.Text != "" && password.Text != "")
            {
                //SQL query her

                if (DB_user == username.Text && DB_pass == password.Text)
                {
                    
                }
                else
                {
                    errorlabel.Text = "Brugernavn eller kodeord er forkert";
                }
            }
            else
            {
                errorlabel.Text = "Fejl i indtasting";
            }
        }
    }
}