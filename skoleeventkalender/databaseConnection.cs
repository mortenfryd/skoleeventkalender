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

             List< string >[] list = new List< string >[3];
             list[0] = new List< string >();
             list[1] = new List< string >();
             list[2] = new List< string >();

            if (this.openConnection())
            {
                MySqlCommand cmd = new MySqlCommand(this.query, this.connection);
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {

                }

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