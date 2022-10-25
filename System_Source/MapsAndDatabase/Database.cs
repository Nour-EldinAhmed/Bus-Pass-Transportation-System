using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace Bus_Station
{

    class Database
    {
        public SqlConnection connection;
        public Database()
        {
            connection = new SqlConnection(@"Data Source=DESKTOP-5JJ226K;Initial Catalog=Bus_Pass_Transportation;Integrated Security=True");

        }
        // connection of DataBaseD:\nour\Bus Station\Bus Station\Content\
        public SqlConnection connect()
        {
            connection.Open();
            return connection;

        }
        // disconnection of dataBase
        public void disconnect()
        {
            if (connection.State == ConnectionState.Open == true)
                connection.Close();
        }


    }
}
