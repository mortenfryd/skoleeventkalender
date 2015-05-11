using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
using System.Globalization;

namespace skoleeventkalender
{

    public class databaseConnection
    {
        private MySqlConnection connection;

        public string query = "";

        //Constructor
        public void DBConnect()
        {
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringMySQL"].ConnectionString;
            connection = new MySqlConnection(connectionString);
        }

        private bool openConnection()
        {

           
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                // Handle!
                return false;
            }
           
             
        }

       private bool closeConnection()
        {
            try
            {
                connection.Close();
                return true;
            }catch(MySqlException ex){
                // Handle!
                return false;
            }
        }

       public Dictionary<string,string> getUserInfo (int userid)
       {
           Dictionary<string, string> data = new Dictionary<string, string>();
           string query = "SELECT * FROM users WHERE u_id = @userid";
           
           if (this.openConnection())
           {
               MySqlCommand cmd = new MySqlCommand(query, this.connection);

               cmd.Parameters.AddWithValue("@userid", userid);

               MySqlDataReader dr = cmd.ExecuteReader();
               while (dr.Read())
               {
                   data.Add("u_id", dr["u_id"].ToString());
                   data.Add("firstname", dr["firstname"].ToString());
                   data.Add("lastname", dr["email"].ToString());
                   data.Add("birthday", dr["birthday"].ToString());
                   data.Add("isAdmin", dr["isAdmin"].ToString());
               }         
           }
           return data;     
       }

       // Login funktion
       // Hvis brugeren ikke findes returneres -1;
       public int Login(string email, string password)
       {
           string query = "SELECT u_id FROM users WHERE email = @email AND pass = SHA1(@pass)";
           int userId = -1;

           if (this.openConnection())
           {
               MySqlCommand cmd = new MySqlCommand(query, this.connection);

               cmd.Parameters.AddWithValue("@email", email);
               cmd.Parameters.AddWithValue("@pass", password);

               MySqlDataReader dr = cmd.ExecuteReader();

               while (dr.Read())
               {
                   userId = Convert.ToInt32(dr["u_id"].ToString());
               }

               dr.Close();

               this.closeConnection();

               return userId;
           }
           else
           {
               return userId;
           }
       }

       public enum createLoginStatus
       {
           userAlreadyExist,
           success
       }

        public int CreateLogin(Dictionary<string,string> userinfo){

            string query = "create_user_procedure";
            int result = -1;

            if (this.openConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, this.connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySqlParameter("p_firstname", userinfo["Firstname"]));
                cmd.Parameters.Add(new MySqlParameter("p_lastname", userinfo["Lastname"]));
                cmd.Parameters.Add(new MySqlParameter("p_username", userinfo["Username"]));
                cmd.Parameters.Add(new MySqlParameter("p_password", userinfo["Password"]));
                cmd.Parameters.Add(new MySqlParameter("p_birthday", userinfo["Birthday"]));
                cmd.Parameters.Add(new MySqlParameter("p_is_admin", "0"));

                cmd.Parameters.Add(new MySqlParameter("v_res", MySqlDbType.Int32));
                cmd.Parameters["v_res"].Direction = System.Data.ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                result = (int)cmd.Parameters["v_res"].Value;

                this.closeConnection();
            }
            else
            {
            }

            if (result == 0){
                return (int)createLoginStatus.userAlreadyExist;
            }else if(result == 1){
                return (int)createLoginStatus.success;
            }

            return result;

        }

        public enum createEventStatus
        {
            success
        }

        public int CreateEvent(Dictionary<string, string> eventinfo)
        {
            string query = "create_event_procedure";
            int result = -1;

            if (this.openConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, this.connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySqlParameter("p_host", eventinfo["host"]));
                cmd.Parameters.Add(new MySqlParameter("p_startDate", eventinfo["startDate"]));
                cmd.Parameters.Add(new MySqlParameter("p_endDate", eventinfo["endDate"]));
                cmd.Parameters.Add(new MySqlParameter("p_eventName", eventinfo["eventName"]));
                cmd.Parameters.Add(new MySqlParameter("p_freeTxt", eventinfo["freeTxt"]));
                cmd.Parameters.Add(new MySqlParameter("p_eventType", eventinfo["eventType"]));

                cmd.Parameters.Add(new MySqlParameter("v_res", MySqlDbType.Int32));
                cmd.Parameters["v_res"].Direction = System.Data.ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                result = (int)cmd.Parameters["v_res"].Value;

                this.closeConnection();
            }
            else
            {
            }

            if (result == 1)
            {
                return (int)createLoginStatus.success;
            }

            return result;
        }

        public enum signUpEventStatus
        {
            success,
            AlreadySignedUp
        }

        public int signUpEvent(int eg_id, int u_id){

            string query = "sign_up_event_procedure";
            int result = -1;

            if (this.openConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, this.connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new MySqlParameter("p_eg_id", eg_id));
                cmd.Parameters.Add(new MySqlParameter("p_u_id", u_id));

                cmd.Parameters.Add(new MySqlParameter("v_res", MySqlDbType.Int32));
                cmd.Parameters["v_res"].Direction = System.Data.ParameterDirection.Output;

                cmd.ExecuteNonQuery();

                result = (int)cmd.Parameters["v_res"].Value;

                this.closeConnection();

            }
            else
            {

            }

            if (result == 0)
                return (int)signUpEventStatus.AlreadySignedUp;
            else if (result == 1)
                return (int)signUpEventStatus.success;

                return result;

        }

        public List<string> getEventSignups(int eg_id){

            string query = "SELECT firstname, lastname FROM tilmeldinger LEFT JOIN users on tilmeldinger.p_id = users.u_id WHERE tilmeldinger.event_id=@eg_id";

            List<string> res = new List<string>();

            if (this.openConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, this.connection);

                cmd.Parameters.AddWithValue("@eg_id", eg_id);

                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    res.Add(dr["firstname"] + " " + dr["lastname"]);
                }

                dr.Close();

                this.closeConnection();

                return res;
            }
            else
            {
                return res;
            }

        }

        public void deleteEvent(int eg_id) {

            string query = "DELETE FROM events_general WHERE eg_id = @eg_id";

            if (this.openConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, this.connection);

                cmd.Parameters.AddWithValue("@eg_id", eg_id);

                cmd.ExecuteNonQuery();

                this.closeConnection();
            }
            else
            {
            }

        }

        public DataTable GetCalenderEventData(DateTime start, DateTime end)
        {
           
            string query = "SELECT * FROM events_general where startDate >= '" + start.ToString("yyyy-MM-dd HH:mm:ss") + "' and startDate <= '" + end.ToString("yyyy-MM-dd HH:mm:ss") + "';";
            
            DataTable dt = new DataTable();

            dt.Columns.Add("eg_id", typeof(string));
            dt.Columns.Add("startDate", typeof(DateTime));
            dt.Columns.Add("endDate", typeof(DateTime));
            dt.Columns.Add("eventName", typeof(string));
            dt.Columns.Add("host", typeof(string));
            dt.Columns.Add("freeTxt", typeof(string));
            dt.Columns.Add("eventType", typeof(string));

            if (this.openConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, this.connection);
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    DataRow row;
                    row = dt.NewRow();
                    row["eg_id"] = dr["eg_id"].ToString();
                    row["startDate"] = Convert.ToDateTime(dr["startDate"].ToString());
                    row["endDate"] = Convert.ToDateTime(dr["endDate"].ToString());
                    row["eventName"] = dr["eventName"].ToString();
                    row["host"] = dr["host"].ToString();
                    row["freeTxt"] = "<b>" + dr["eventName"].ToString() + "</b>" + "<br />" + "<br />" + dr["freeTxt"].ToString();
                    row["eventType"] = dr["eventType"].ToString();
                    dt.Rows.Add(row);
                }

                dr.Close();

                this.closeConnection();

                return dt;

            }
            else 
            {
                return dt; 
            }

        }

        public MySqlConnection getClone()
        {
            // Til ekstern brug.
            return connection.Clone();
        }

    }
}