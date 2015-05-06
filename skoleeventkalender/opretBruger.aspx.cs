using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;

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






        protected void confirm_Click(object sender, EventArgs e)
        {
            databaseConnection DB = new databaseConnection();
            DB.DBConnect();

            if (username.Text != "" && password.Text != "" && passwordconfirm.Text != "" && firstname.Text != "" && lastname.Text != "" )
            {
                string email = username.Text;
                Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                Match match = regex.Match(email);
                
                if (match.Success)
                {
                    if (password.Text == passwordconfirm.Text)
                    {
                        string pwd = password.Text;
                        if (pwd.Length > 5)
                        {
                            string bday = (ddlYear.Text + "-" + ddlMonth.Text + "-" + ddlDay.Text);

                            DB.CreateLogin(new Dictionary<string, string>{
                        { "Username", username.Text },
                        { "Password", password.Text },
                        { "Firstname", firstname.Text},
                        { "Lastname", lastname.Text},
                        { "Birthday", bday}
                        });

                            Response.Redirect("default.aspx");
                        }
                        else
                        {
                            errorlabel.Text = "Password skal være længere end 6 karaktere.";
                        }
                    }
                    else
                    {
                        errorlabel.Text = "Password er ikke ens.";
                    }
                    
                    
                }
                else
	            {
                    errorlabel.Text = "Indtast en valid email addresse";
	            }
                
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