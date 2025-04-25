using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace MaintenanceOrganizer
{
    public class DatabaseManager
    {
        private string _connectionString;

        public DatabaseManager(string databasePath)
        {
            _connectionString = $"Data Source={databasePath}";
        }

        public void CreateDatabase()
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                // Example: Create a table
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "CREATE TABLE IF NOT EXISTS PartsDatabase (Id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                          "PartName VARCHAR(50), PartNumber VARCHAR(255), Amount INT)";
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

        // Inserts data into database
        public void InsertData(string partName, string partNumber, int amount)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                // Example: Insert data into the table
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = $"INSERT INTO PartsDatabase (PartName, PartNumber, Amount) VALUES ('{partName}', '{partNumber}', '{amount}')";
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

        public bool GetPartNumber(string partNumber)
        {
            bool partNumberExist = false;

            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                // Query data from the table
                using (var command = connection.CreateCommand())
                {
                    string query = $"SELECT COUNT(*) FROM PartsDatabase WHERE PartNumber = '{partNumber}'";
                    command.CommandText = query;

                    // Execute the query and retrieve the count
                    object result = command.ExecuteScalar();
                    int count = Convert.ToInt32(result);

                    if (count > 0) 
                        partNumberExist = true;
                }

                connection.Close();
            }

            return partNumberExist;
        }

        // Chages the amount of parts for a certain part
        public void ChangeAmountData(string partNumber, int amountToAdd)
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                // Change the part amount
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = $"UPDATE PartsDatabase SET Amount = Amount + '{amountToAdd}' WHERE partNumber = '{partNumber}'";
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

        public void DeleteData(string partNumber, int amountToDelete) 
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                // Change the part amount
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = $"UPDATE PartsDatabase SET Amount = Amount - '{amountToDelete}' WHERE partNumber = '{partNumber}'";
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

        //Prints out the data
        public List<string> QueryData()
        {
            List<string> result = new List<string>();

            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                // Query data from the table
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM PartsDatabase";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var id = reader.GetInt32(0); // assuming the first column is an integer
                            var partName = reader.GetString(1); // assuming the second column is a string
                            var partNumber = reader.GetString(2);
                            var amount = reader.GetInt32(3);

                            // Create a string representation of the row
                            string row = $"Id: {id}, Part Name: {partName}, Part Number: {partNumber}, Amount: {amount}";

                            // Add the string to the result collection
                            result.Add(row);
                        }
                    }
                }

                connection.Close();
            }

            return result;
        }


        //Clears the database
        public void ClearData()
        {
            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                //Clears all data from database
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM PartsDatabase";
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
            Console.WriteLine("Database Clearer");
        }

    }
}
