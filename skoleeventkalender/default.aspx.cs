﻿using System;
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
            if (Session["u_id"] != null)
            {
                Response.Redirect("eventview.aspx");
            }
        }

        protected void login_Click(object sender, EventArgs e)
        {
            databaseConnection DB = new databaseConnection();
            DB.DBConnect();

            int user_id = DB.Login(username.Text, password.Text);

            Dictionary<string, string> data = DB.getUserInfo(user_id);

            if (user_id != -1 && data["isAdmin"] == "0")
            {
                Session["admin"] = "0";
                Session["u_id"] = user_id;
                Response.Redirect("eventview.aspx");
            }
            else if (user_id != -1 && data["isAdmin"] == "1")
            {
                Session["u_id"] = user_id;
                Session["admin"] = "1";
                Response.Redirect("eventview.aspx");
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