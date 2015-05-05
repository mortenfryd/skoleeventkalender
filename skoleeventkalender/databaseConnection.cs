using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

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

        public List<string>[] GetCalenderEventData()
        {

            string query = "SELECT * FROM events_general";

             List< string >[] list = new List< string >[3];
             list[0] = new List<string>();
             list[1] = new List<string>();
             list[2] = new List<string>();
             list[3] = new List<string>();
             list[4] = new List<string>();
             list[5] = new List<string>();
             list[6] = new List<string>();

            if (this.openConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, this.connection);
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    list[0].Add(dr["eg_id"].ToString());
                    list[1].Add(dr["host"].ToString());
                    list[2].Add(dr["startDate"].ToString());
                    list[3].Add(dr["endDate"].ToString());
                    list[4].Add(dr["eventName"].ToString());
                    list[5].Add(dr["freeTxt"].ToString());
                    list[6].Add(dr["eventType"].ToString());
                }

                dr.Close();

                this.closeConnection();

                return list;

            }
            else 
            {
                return list; 
            }

        }

        public MySqlConnection getClone()
        {
            // Til ekstern brug.
            return connection.Clone();
        }

    }
}