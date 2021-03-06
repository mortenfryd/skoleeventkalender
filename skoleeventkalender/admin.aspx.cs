﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace skoleeventkalender
{
    public partial class admin : System.Web.UI.Page
    {
       protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["u_id"] != null && Convert.ToString(Session["admin"]) == "0")
            {
                //Du er en bruger
                Response.Redirect("default.aspx");
            }
            else if (Session["u_id"] != null && Convert.ToString(Session["admin"]) == "1")
            {
                //Du er admin
            }
            else
            {
                //Du er ikke logget ind, tilbage til forsiden.
                Response.Redirect("default.aspx");
            }
            

            if (!Page.IsPostBack)
            {
                //Fill Years
                for (int i = 1900; i <= 2015; i++)
                {
                    ddlYear.Items.Add(i.ToString());
                }
                ddlYear.Items.FindByValue(System.DateTime.Now.Year.ToString()).Selected = true;  //set current year as selected

                //Fill Months
                for (int i = 1; i <= 12; i++)
                {
                    ddlMonth.Items.Add(i.ToString());
                }
                ddlMonth.Items.FindByValue(System.DateTime.Now.Month.ToString()).Selected = true; // Set current month as selected

                //Fill days
                FillDays();
            }
        }

        public void FillDays()
        {
            ddlDay.Items.Clear();
            //getting numbner of days in selected month & year
            int noofdays = DateTime.DaysInMonth(Convert.ToInt32(ddlYear.SelectedValue), Convert.ToInt32(ddlMonth.SelectedValue));

            //Fill days
            for (int i = 1; i <= noofdays; i++)
            {
                ddlDay.Items.Add(i.ToString());
            }
            ddlDay.Items.FindByValue(System.DateTime.Now.Day.ToString()).Selected = true;// Set current date as selected
        }
        protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillDays();
        }
        protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillDays();
        }


        protected void userdropdown_onLoad(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                dropdownrefresh();
            }
            
        }
        protected void dropdownrefresh()
        {
            userdropdown.Items.Clear();
            databaseConnection DB = new databaseConnection();
            DB.DBConnect();

            MySqlConnection connect = DB.getClone();
            MySqlCommand cmd = new MySqlCommand("select u_id, email from users", connect);
            connect.Open();
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                userdropdown.Items.Add(new ListItem(reader["email"].ToString(), reader["u_id"].ToString()));
            }
            reader.Close();
            connect.Close();
        }

        protected void resetInput()
        {
            fornavntext.Text = "";
            efternavntext.Text = "";
            emailtext.Text = "";
            isadmin.Checked = false;
            ddlYear.Items.FindByValue(ddlYear.Text.ToString()).Selected = false;
            ddlYear.Items.FindByValue(System.DateTime.Now.Year.ToString()).Selected = true;  //set current year as selected
            ddlDay.Items.FindByValue(ddlDay.Text.ToString()).Selected = false;
            ddlDay.Items.FindByValue(System.DateTime.Now.Day.ToString()).Selected = true;  //set current day as selected
            ddlMonth.Items.FindByValue(ddlMonth.Text.ToString()).Selected = false;
            ddlMonth.Items.FindByValue(System.DateTime.Now.Month.ToString()).Selected = true;  //set current month as selected
        }

        protected void userdropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
        
        }
        protected void select_Click(object sender, EventArgs e)
        {
            errorlabel.Text = "";
            userdropdown.Enabled = false;
            databaseConnection DB = new databaseConnection();
            DB.DBConnect();

            MySqlConnection connect = DB.getClone();
            MySqlCommand selected = new MySqlCommand("select firstname, lastname, email, birthday, isadmin from users where u_id =  " + userdropdown.SelectedValue.ToString() + " order by email", connect);
            connect.Open();
            MySqlDataReader reader = selected.ExecuteReader();

            while (reader.Read())
            {
                emailtext.Text = reader["email"].ToString();
                fornavntext.Text = reader["firstname"].ToString();
                efternavntext.Text = reader["lastname"].ToString();
                DateTime bday = Convert.ToDateTime(reader["birthday"]);
                ddlDay.SelectedValue = Convert.ToString(bday.Day);
                ddlMonth.SelectedValue = Convert.ToString(bday.Month);
                ddlYear.SelectedValue = Convert.ToString(bday.Year);

                if (reader["isadmin"].ToString() == "1")
                {
                    isadmin.Checked = true;
                }
                else
                {
                    isadmin.Checked = false;
                }
            }
            reader.Close();
            connect.Close();
        }

        protected void deletebtn_Click(object sender, EventArgs e)
        {
            databaseConnection DB = new databaseConnection();
            DB.DBConnect();
            MySqlConnection connect = DB.getClone();
            MySqlCommand delete = new MySqlCommand("delete from tilmeldinger where p_id = " + userdropdown.SelectedValue.ToString() + "; delete from users where u_id = "+userdropdown.SelectedValue.ToString()+"; ", connect);
            connect.Open();

            delete.ExecuteNonQuery();

            connect.Close();
            errorlabel.Text = userdropdown.SelectedItem.Text + " er slettet.";
            dropdownrefresh();
        }

        protected void editbtn_Click(object sender, EventArgs e)
        {
            databaseConnection DB = new databaseConnection();
            DB.DBConnect();
            MySqlConnection connect = DB.getClone();

            int adminint = 0;

            if (isadmin.Checked == true)
            {
                adminint = 1;
            }
            string bday = (ddlYear.Text + "-" + ddlMonth.Text + "-" + ddlDay.Text);
            if (password.Text == passwordconfirm.Text)
            {
                MySqlCommand edit = new MySqlCommand("update users set firstname='" + fornavntext.Text + "', lastname='" + efternavntext.Text + "', email='" + emailtext.Text + "', birthday='" + bday + "', isadmin='" + adminint + "' where u_id = " + userdropdown.SelectedValue.ToString() + " ", connect);
                connect.Open();
                edit.ExecuteNonQuery();
                connect.Close();
                errorlabel.Text = userdropdown.SelectedItem.Text + " er blevet ændret.";
                resetInput();
                dropdownrefresh();
                userdropdown.Enabled = true;
            }
            else
            {
                errorlabel.Text = "Password er ikke ens";
            }
            
        }
    }
}
