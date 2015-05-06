﻿using System;
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
           success,
           userAlreadyExist,
           userPassIlligal
       }

        public int CreateLogin(Dictionary<string,string> userinfo){

            string query = "create_user_procedure"; 

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

                cmd.ExecuteNonQuery();

                this.closeConnection();
            }
            else
            {
            }

            return (int)createLoginStatus.userAlreadyExist;
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