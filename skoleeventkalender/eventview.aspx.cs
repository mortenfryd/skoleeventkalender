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
        int flag = 0;
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
            
            //eventCalender.StartDate = dateH.denneUge();
            eventCalender.Days = 7;
            eventCalender.TimeFormat = DayPilot.Web.Ui.Enums.TimeFormat.Clock24Hours;
            eventCalender.HeaderDateFormat = "yyyy-MM-dd";

            eventCalender.DataSource = DB.GetCalenderEventData(eventCalender.StartDate, eventCalender.StartDate.AddDays(7));

            Response.Write(eventCalender.StartDate.ToString() + ", " + eventCalender.StartDate.AddDays(7).ToString());
            Response.Write(dateH.denneUge().ToString());

            eventCalender.DataStartField = "startDate";
            eventCalender.DataEndField = "endDate";
            eventCalender.DataTextField = "eventName";
            eventCalender.DataIdField = "eg_id";

            if (!IsPostBack)
                DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (flag == 0)
            {


                updateKalender("denne", DateTime.Now);
                flag = 1;
            }
            /*
            // Connect to DB.
            databaseConnection DB = new databaseConnection();
            DB.DBConnect();

            // Set calender start date.
            dateHandler dateH = new dateHandler();
            eventCalender.StartDate = dateH.denneUge();
            eventCalender.Days = 7;
            eventCalender.TimeFormat = DayPilot.Web.Ui.Enums.TimeFormat.Clock24Hours;
            eventCalender.HeaderDateFormat = "yyyy-MM-dd";

            eventCalender.DataSource = DB.GetCalenderEventData(eventCalender.StartDate, eventCalender.StartDate.AddDays(7));

            Response.Write(eventCalender.StartDate.ToString() + ", " + eventCalender.StartDate.AddDays(7).ToString());
            Response.Write(dateH.denneUge().ToString());

            eventCalender.DataStartField = "startDate";
            eventCalender.DataEndField = "endDate";
            eventCalender.DataTextField = "eventName";
            eventCalender.DataIdField = "eg_id";

            if (!IsPostBack)
                DataBind();*/
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
      
    }
}