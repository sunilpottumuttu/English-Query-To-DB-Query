using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace EnglishQueryToDBQueryDemo
{
    public class DBManager
    {
        private const string DataBase = "Weather.db";
        public SQLiteCommand Command { get; set; }
        public SQLiteConnection Connection { get; set; }

        public void CreateDB()
        {
            if (File.Exists(DataBase) == false)
            {
                WriteLine("Creating DB..Please Wait");
                Connection = new SQLiteConnection { ConnectionString = "Data Source=" + DataBase };
                Connection.Open();

                ExecuteCommand("CREATE TABLE IF NOT EXISTS WEATHER (ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, CityName VARCHAR(100) NOT NULL,  Tempreature INTEGER NOT NULL);");
                ExecuteCommand("INSERT INTO WEATHER VALUES(1, 'Chennai', 43)");
                ExecuteCommand("INSERT INTO WEATHER VALUES(2, 'Delhi', 46)");
                ExecuteCommand("INSERT INTO WEATHER VALUES(3, 'Mumbai', 32)");
                ExecuteCommand("INSERT INTO WEATHER VALUES(4, 'Hyderabad', 28)");

                WriteLine("DB Created Successfully..");
            }
            else
            {
                WriteLine("Database Already Exists");
            }
        }

        public void ShowRecords()
        {
            var m_dbConnection = new SQLiteConnection("Data Source=Weather.db;Version=3;");
            m_dbConnection.Open();
            string sql = "select * from weather";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                var cityName = reader["CityName"];
                var temp = reader["Tempreature"];
                Console.WriteLine($"CityName: {cityName}   Temp:{temp}");
            }
            m_dbConnection.Close();
        }


        public void Execute(string sql)
        {
            var m_dbConnection = new SQLiteConnection("Data Source=Weather.db;Version=3;");
            m_dbConnection.Open();
            //string sql = "select * from weather";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                var cityName = reader["CityName"];
                var temp = reader["Tempreature"];
                Console.WriteLine($"CityName: {cityName}   Temp:{temp}");
            }
            m_dbConnection.Close();
        }

        public void ExecuteCommand(string commandText)
        {
            Command = new SQLiteCommand(Connection) { CommandText = commandText };
            Command.ExecuteNonQuery();
        }
        public void Close()
        {
            Command.Dispose();
            Connection.Dispose();
        }

    }
}
