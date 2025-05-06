using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO PartsDatabase (PartName, PartNumber, Amount) VALUES (@PartName, @PartNumber, @Amount)";
                    command.Parameters.AddWithValue("@PartName", partName);
                    command.Parameters.AddWithValue("@PartNumber", partNumber);
                    command.Parameters.AddWithValue("@Amount", amount);

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

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT COUNT(*) FROM PartsDatabase WHERE PartNumber = @PartNumber";
                    command.Parameters.AddWithValue("@PartNumber", partNumber);

                    object result = command.ExecuteScalar();
                    int count = Convert.ToInt32(result);
                    partNumberExist = count > 0;
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
                    command.CommandText = "UPDATE PartsDatabase SET Amount = Amount + @AmountToAdd WHERE partNumber = @PartNumber";
                    command.Parameters.AddWithValue("@AmountToAdd", amountToAdd);
                    command.Parameters.AddWithValue("@PartNumber", partNumber);
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
                    command.CommandText = "UPDATE PartsDatabase SET Amount = Amount - @AmountToDelete WHERE partNumber = @PartNumber";
                    command.Parameters.AddWithValue("@AmountToDelete", amountToDelete);
                    command.Parameters.AddWithValue("@PartNumber", partNumber);
                    command.ExecuteNonQuery();
                }

                // Check the updated amount
                using (var selectCommand = connection.CreateCommand())
                {
                    selectCommand.CommandText = "SELECT Amount FROM PartsDatabase WHERE partNumber = @PartNumber";
                    selectCommand.Parameters.AddWithValue("@PartNumber", partNumber);
                    var result = selectCommand.ExecuteScalar();

                    if (result != null && Convert.ToInt32(result) <= 0)
                    {
                        // Delete the part if amount is 0 or less
                        using (var deleteCommand = connection.CreateCommand())
                        {
                            deleteCommand.CommandText = "DELETE FROM PartsDatabase WHERE partNumber = @PartNumber";
                            deleteCommand.Parameters.AddWithValue("@PartNumber", partNumber);
                            deleteCommand.ExecuteNonQuery();
                        }
                    }
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

        public List<string> LowItemError()
        {
            var warnings = new List<string>();

            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT PartName, PartNumber, Amount FROM PartsDatabase WHERE Amount <= @Threshold";
                    command.Parameters.AddWithValue("@Threshold", 3);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string partName = reader.GetString(0);
                            string partNumber = reader.GetString(1);
                            int amount = reader.GetInt32(2);

                            string warning = $"Warning: {partName} (#{partNumber}) is low: {amount} left.";
                            warnings.Add(warning);
                        }
                    }
                }

                connection.Close();
            }

            return warnings;
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
