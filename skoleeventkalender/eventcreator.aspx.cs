using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace skoleeventkalender
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //Fill Years
                for (int i = 2015; i <= 2030; i++)
                {
                    ecStartYear.Items.Add(i.ToString());
                    ecEndYear.Items.Add(i.ToString());
                }
                ecStartYear.Items.FindByValue(System.DateTime.Now.Year.ToString()).Selected = true;  //set current year as selected
                ecEndYear.Items.FindByValue(System.DateTime.Now.Year.ToString()).Selected = true;  //set current year as selected

                //Fill Months
                for (int i = 1; i <= 12; i++)
                {
                    ecStartMonth.Items.Add(i.ToString());
                    ecEndMonth.Items.Add(i.ToString());
                }
                ecStartMonth.Items.FindByValue(System.DateTime.Now.Month.ToString()).Selected = true; // Set current month as selected
                ecEndMonth.Items.FindByValue(System.DateTime.Now.Month.ToString()).Selected = true; // Set current month as selected

                //Fill days
                FillDaysStart();
                fillTime();
            }
        }

        public void FillEventType()
        {
            //insert database connection stuff here
        }

        public void fillTime()
        {
            for (int i = 0; i < 24; i++)
            {
                ecStartHour.Items.Add(i.ToString());
                ecEndHour.Items.Add(i.ToString());
            }
            for (int i = 0; i < 60; i++)
            {
                ecStartMinute.Items.Add(i.ToString());
                ecEndMinute.Items.Add(i.ToString());
            }
        }

        public void FillDaysStart()
        {
            ecStartDay.Items.Clear();
            //getting numbner of days in selected month & year
            int noofdays = DateTime.DaysInMonth(Convert.ToInt32(ecStartYear.SelectedValue), Convert.ToInt32(ecStartMonth.SelectedValue));

            //Fill days
            for (int i = 1; i <= noofdays; i++)
            {
                ecStartDay.Items.Add(i.ToString());
                ecEndDay.Items.Add(i.ToString());
            }
            ecStartDay.Items.FindByValue(System.DateTime.Now.Day.ToString()).Selected = true;// Set current date as selected
            ecEndDay.Items.FindByValue(System.DateTime.Now.Day.ToString()).Selected = true;// Set current date as selected
        }

        protected void ecStartYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillDaysStart();
            if (Convert.ToInt32(ecEndYear.Text) < Convert.ToInt32(ecStartYear.SelectedValue))
            {
                ecEndYear.Text = ecStartYear.SelectedValue;
            }
        }

        protected void ecStartMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillDaysStart();
            if (Convert.ToInt32(ecEndMonth.Text) < Convert.ToInt32(ecStartMonth.SelectedValue))
            {
                ecEndMonth.Text = ecStartMonth.SelectedValue;
            }
        }

        protected void ecStartDay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(ecEndDay.Text) < Convert.ToInt32(ecStartDay.SelectedValue))
            {
                ecEndDay.Text = ecStartDay.SelectedValue;
            }
        }

        protected void ecEndYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(ecEndYear.Text) < Convert.ToInt32(ecStartYear.SelectedValue))
            {
                ecEndYear.Text = ecStartYear.SelectedValue;
            }
        }

        protected void ecEndMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(ecEndMonth.Text) < Convert.ToInt32(ecStartMonth.SelectedValue))
            {
                ecEndMonth.Text = ecStartMonth.SelectedValue;
            }
        }

        protected void ecEndDay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32(ecEndDay.Text) < Convert.ToInt32(ecStartDay.SelectedValue))
            {
                ecEndDay.Text = ecStartDay.SelectedValue;
            }
        }

        protected void eventCreateBtn_Click(object sender, EventArgs e)
        {
            //insert i database og send tilbage til kalender

            databaseConnection DB = new databaseConnection();
            DB.DBConnect();
            string startDate = ecStartYear.Text + "-" + ecStartMonth.Text + "-" + ecStartDay.Text+" "+ecStartHour.Text+":"+ecStartMinute.Text+":00";
            string endDate = ecEndYear.Text + "-" + ecEndMonth.Text + "-" + ecEndDay.Text + " " + ecEndHour.Text + ":" + ecEndMinute.Text + ":00";




            int stat = DB.CreateEvent(new Dictionary<string, string>{
                {"host",Session["u_id"].ToString()},
                {"startDate",startDate},
                {"endDate",endDate},
                {"eventName",eventName.Text},
                {"freeTxt",eventDescription.Text},
                {"eventType",eventTypeDropD.Text}
            });

            Response.Redirect("eventview.aspx");
        }

        protected void eventCancelBtn_Click(object sender, EventArgs e)
        {
            //gå tilbage til kalender
            Response.Redirect("eventview.aspx");
        }
    }
}