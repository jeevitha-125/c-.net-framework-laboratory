using System;
using System.Data;
using Microsoft.Data.Sqlite;

namespace DisconnectedDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=students.db";

            using (SqliteConnection connection = new SqliteConnection(connectionString))
            {
                connection.Open();

                // Create table
                string createTable = @"
                    CREATE TABLE IF NOT EXISTS Students
                    (
                        Id INTEGER PRIMARY KEY,
                        Name TEXT NOT NULL,
                        Department TEXT NOT NULL,
                        Mark INTEGER
                    )";

                using (SqliteCommand command = new SqliteCommand(createTable, connection))
                {
                    command.ExecuteNonQuery();
                }

                // Clear old records
                string deleteData = "DELETE FROM Students";

                using (SqliteCommand command = new SqliteCommand(deleteData, connection))
                {
                    command.ExecuteNonQuery();
                }

                // Insert records
                string insertData = @"
                    INSERT INTO Students (Id, Name, Department, Mark)
                    VALUES
                    (1, 'Jeevitha', 'AI & DS', 90),
                    (2, 'Anu', 'Computer Science', 85),
                    (3, 'Priya', 'Information Technology', 88),
                    (4, 'Divya', 'AI & DS', 92)";

                using (SqliteCommand command = new SqliteCommand(insertData, connection))
                {
                    command.ExecuteNonQuery();
                }

                // Retrieve data
                string selectQuery = "SELECT * FROM Students";

                using (SqliteCommand command = new SqliteCommand(selectQuery, connection))
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    DataTable dataTable = new DataTable();

                    dataTable.Load(reader);

                    // Disconnected data
                    DataSet dataSet = new DataSet();
                    dataSet.Tables.Add(dataTable);

                    // Close database connection
                    connection.Close();

                    Console.WriteLine("Student Details");
                    Console.WriteLine("-----------------------------");

                    foreach (DataRow row in dataSet.Tables[0].Rows)
                    {
                        Console.WriteLine(
                            "ID: " + row["Id"] +
                            ", Name: " + row["Name"] +
                            ", Department: " + row["Department"] +
                            ", Mark: " + row["Mark"]
                        );
                    }

                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("Data retrieved successfully using disconnected environment.");
                }
            }
        }
    }
}