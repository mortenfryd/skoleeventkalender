using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;

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

       public int Login(string email, string password)
       {
           string query = "SELECT u_id FROM users WHERE email = @email AND pass = @pass";
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

       enum createLoginStatus
       {
           userAlreadyExist,
           usernameOrPasswordIlligal
       }

        public int CreateLogin(){

            if (this.openConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, this.connection);
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {

                }

                dr.Close();

                this.closeConnection();
            }
            else
            {
            }

            return (int)createLoginStatus.userAlreadyExist;
        }

        public DataTable GetCalenderEventData()
        {

            string query = "SELECT * FROM events_general";
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
                    row["eg_id"] = 0;
                    row["startDate"] = Convert.ToDateTime(dr["startDate"].ToString());
                    row["endDate"] = Convert.ToDateTime(dr["endDate"].ToString());
                    row["eventName"] = "Partner conf. call";
                    row["host"] = "Partner conf. call";
                    row["freeTxt"] = "Partner conf. call";
                    row["eventType"] = "Partner conf. call";
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