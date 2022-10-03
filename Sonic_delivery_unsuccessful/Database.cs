using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Sonic_delivery_unsuccessful
{
    class Database
    {
        public string num;

        public void Tracking_Number()
        {
            // connection string
            MySqlConnectionStringBuilder connBuilder = new MySqlConnectionStringBuilder();
            connBuilder.Add("Database", "sonic");
            connBuilder.Add("Data Source", "sonic-replica-for-staging.cuyto0fths1v.eu-west-1.rds.amazonaws.com");
            connBuilder.Add("User Id", "sonic");
            connBuilder.Add("Password", "sonic123");
            MySqlConnection connection = new MySqlConnection(connBuilder.ConnectionString);

            MySqlCommand cmd = connection.CreateCommand();

            //connection open
            connection.Open();

            //query command
            cmd.CommandText = "SELECT tracking_number FROM sonic.shipments ORDER BY created_at DESC limit 1;";
            cmd.CommandType = CommandType.Text;

            //read and save data fetched
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                num = reader.GetString(0);
                Console.WriteLine(" \n*** TRACKING NUMBER IS : " + num + " ***");
            }
        }
    }
}
