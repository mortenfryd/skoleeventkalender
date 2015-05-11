using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace skoleeventkalender
{
    public partial class eventView : System.Web.UI.Page
    {
        public void fillDropdown(DataTable dt)
        {
            selectedEvent.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                // MORTEN IS HERE DO NOT TOUCH!
                selectedEvent.Items.Add(new ListItem(dr["eventName"].ToString(), dr["eg_id"].ToString()));
            }
        }

        public void fillSignUp()
        {
            signedUpUsers.Items.Clear();
            databaseConnection DB = new databaseConnection();
            DB.DBConnect();

            int event_id = Convert.ToInt32(selectedEvent.SelectedValue);

            List<string> data = DB.getEventSignups(event_id);
            //kald en sql funktion til at hente brugere som er tilmeldt
            foreach (string item in data)
            {
                signedUpUsers.Items.Add(item);
            }
        }

        public void updateKalender(string action,DateTime currentDay)
        {
            databaseConnection DB = new databaseConnection();
            DB.DBConnect();

            dateHandler dateH = new dateHandler();
            if (action=="forrige")
            {
                eventCalender.StartDate = dateH.forrigeUge(currentDay);
            }
            else if (action == "denne")
            {
                eventCalender.StartDate = dateH.denneUge();
            }
            else if(action=="naeste")
            {
                eventCalender.StartDate = dateH.naesteUge(currentDay);
            }
            
            eventCalender.Days = 7;
            eventCalender.TimeFormat = DayPilot.Web.Ui.Enums.TimeFormat.Clock24Hours;
            eventCalender.HeaderDateFormat = "yyyy-MM-dd";

            DataTable dt = DB.GetCalenderEventData(eventCalender.StartDate, eventCalender.StartDate.AddDays(7));

            eventCalender.DataSource = dt;
            //string 
            eventCalender.DataStartField = "startDate";
            eventCalender.DataEndField = "endDate";
            eventCalender.DataTextField = "freeTxt";
            eventCalender.DataIdField = "eg_id";

                DataBind();
                fillDropdown(dt);
            
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
            eventCalender.Days = 7;
            eventCalender.TimeFormat = DayPilot.Web.Ui.Enums.TimeFormat.Clock24Hours;
            eventCalender.HeaderDateFormat = "yyyy-MM-dd";
            if (IsPostBack) return;
            {
                eventCalender.StartDate = DateTime.Now;
                updateKalender("denne", eventCalender.StartDate);
            }
        }

        private DataTable getTestData()
        {

            DataTable dt;
            dt = new DataTable();
            dt.Columns.Add("start", typeof(DateTime));
            dt.Columns.Add("end", typeof(DateTime));
            dt.Columns.Add("name", typeof(string));
            dt.Columns.Add("id", typeof(string));

            DataRow dr;

            dr = dt.NewRow();
            dr["id"] = 0;
            dr["start"] = Convert.ToDateTime("15:30").AddDays(1);
            Response.Write(dr["start"].ToString());
            dr["end"] = Convert.ToDateTime("16:30").AddDays(1);
            dr["name"] = "Partner conf. call";
            dt.Rows.Add(dr);

            // ...

            return dt;

        }

        protected void forrigeUgeBtn_Click(object sender, EventArgs e)
        {
            updateKalender("forrige",eventCalender.StartDate);
        }

        protected void denneUgeBtn_Click(object sender, EventArgs e)
        {
            updateKalender("denne", eventCalender.StartDate);
        }

        protected void naesteUgeBtn_Click(object sender, EventArgs e)
        {
            updateKalender("naeste", eventCalender.StartDate);
        }

        protected void CreateEventBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("eventcreator.aspx");
        }

        protected void eventCalender_EventClick(object sender, DayPilot.Web.Ui.Events.EventClickEventArgs e)
        {
            Response.Write("hahahahahaha");
        }

        protected void eventCalender_TimeRangeSelected(object sender, DayPilot.Web.Ui.Events.TimeRangeSelectedEventArgs e)
        {
            Response.Write("asdasdasddsadsadsaojdsaoijdsaoijdsadsadsaoij");
        }

        protected void tilmeldEvent_Click(object sender, EventArgs e)
        {
            databaseConnection DB = new databaseConnection();
            DB.DBConnect();

            int id = Convert.ToInt32(selectedEvent.SelectedValue);
            int u_id = Convert.ToInt32(Session["u_id"]);
            int resolved = DB.signUpEvent(id, u_id);

            if (resolved==(int)databaseConnection.signUpEventStatus.success)
                signUpSucces.Text = "Sign up was succesfull";
            else if(resolved==(int)databaseConnection.signUpEventStatus.AlreadySignedUp)
                signUpSucces.Text = "You are already signed up for this event";
            else
                signUpSucces.Text = "You fucking retard!";
            fillSignUp();
        }

        protected void DeleteEvent_Click(object sender, EventArgs e)
        {
            databaseConnection DB = new databaseConnection();
            DB.DBConnect();

            int id = Convert.ToInt32(selectedEvent.SelectedValue);
            //Response.Write(id);

            DB.deleteEvent(id);
            updateKalender("denne",eventCalender.StartDate);
        }

        protected void selectedEvent_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillSignUp();
        }
    }
}