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
        protected void Page_Load(object sender, EventArgs e)
        {
            logoutVisible log = new logoutVisible();
            log.logoutVisibleM();
            // Connect to DB.
            databaseConnection DB = new databaseConnection();
            DB.DBConnect();

            // Set calender start date.
            eventCalender.StartDate = DateTime.Now;
            eventCalender.Days = 5;

            eventCalender.DataSource = DB.GetCalenderEventData();

            eventCalender.DataStartField = "startDate";
            eventCalender.DataEndField = "endDate";
            eventCalender.DataTextField = "eventName";
            eventCalender.DataIdField = "eg_id";

            DB.CreateLogin();

            if (!IsPostBack)
                DataBind();

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
      
    }
}