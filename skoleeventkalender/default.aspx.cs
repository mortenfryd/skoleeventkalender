using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

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
            databaseConnection DB = new databaseConnection();
            MySqlConnection DBClone = DB.getClone();
            

            

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

        protected void makeuser_Click(object sender, EventArgs e)
        {
            Response.Redirect("opretbruger.aspx");
        }
    }
}