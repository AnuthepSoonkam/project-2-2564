using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace excercise_table
{



    internal class Class1
    {
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource = 127.0.01;port=3306;username=root;password=;database=exercise_table;charset=utf8;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;

        }

        public void openConnection()
        {
            if (databaseConnection().State == System.Data.ConnectionState.Closed)
            {
                databaseConnection().Open();
            }
        }

        public void closeConnection()
        {
            if (databaseConnection().State == System.Data.ConnectionState.Open)
            {
                databaseConnection().Close();
            }
        }

        public MySqlConnection getConnection()
        {
            return databaseConnection();
        }
    }
}
