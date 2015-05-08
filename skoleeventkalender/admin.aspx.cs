using MySql.Data.MySqlClient;
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
            if (Session["u_id"] == null)
            {
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
           ((Button)this.Master.FindControl("gotoadmin")).Visible = false;
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
            MySqlCommand cmd = new MySqlCommand("select email from users", connect);
            connect.Open();
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                userdropdown.Items.Add(new ListItem(reader["email"].ToString(), reader["email"].ToString()));
            }
            reader.Close();
            connect.Close();
        }

        protected void userdropdown_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void select_Click(object sender, EventArgs e)
        {
            databaseConnection DB = new databaseConnection();
            DB.DBConnect();

            MySqlConnection connect = DB.getClone();
            string valgtnavn = userdropdown.SelectedValue.ToString();
            MySqlCommand selected = new MySqlCommand("select firstname, lastname, email, birthday, isadmin from users where email =  '" +userdropdown.SelectedValue.ToString()+ "' order by email", connect);
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
            MySqlCommand delete = new MySqlCommand("delete from users where email = '"+userdropdown.SelectedValue.ToString()+"'; ", connect);
            connect.Open();
            delete.ExecuteNonQuery();
            connect.Close();
            errorlabel.Text = userdropdown.SelectedValue.ToString() + " er slettet.";
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
            MySqlCommand edit = new MySqlCommand("update users set firstname='" + fornavntext.Text + "', lastname='" + efternavntext.Text + "', email='" + emailtext.Text + "', birthday='" + bday + "', isadmin='"+adminint+"' where email = '" + userdropdown.SelectedValue.ToString() + "' ", connect);
            connect.Open();
            edit.ExecuteNonQuery();
            connect.Close();
            errorlabel.Text = userdropdown.SelectedValue.ToString() + " er blevet ændret.";
            dropdownrefresh();
        }
    }
}
