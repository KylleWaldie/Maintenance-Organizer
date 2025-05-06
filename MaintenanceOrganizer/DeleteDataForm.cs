using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using TextBox = System.Windows.Forms.TextBox;

namespace MaintenanceOrganizer
{
    public partial class DeleteDataForm : Form
    {
        public DeleteDataForm()
        {
            InitializeComponent();
            var dbManager = new DatabaseManager("PartsDatabase.db");
            var results = dbManager.QueryData();
            // Populate the ListBox with the query results
            listBox1.Items.AddRange(results.ToArray());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //todo: add multiple inputs from user
            var dbManager = new DatabaseManager("PartsDatabase.db"); //creates a database if one doesnt exist
            dbManager.CreateDatabase();

            //Gets User Input for Part Name, Part Number, and Quantity
            string partName = textBox1.Text;
            string initalPartNumber = textBox1.Text;
            string partNumberToUpper = initalPartNumber.ToUpper(); //Makes sure that the part number is always all capitals
            string quantityString = textBox3.Text;
            int quantity = int.Parse(quantityString);

            //Checks if part number already in database
            if (dbManager.GetPartNumber(partNumberToUpper))
            {
                dbManager.DeleteData(partNumberToUpper, quantity);
            }
            else
            {
                MessageBox.Show("Error: Part not found in the database.", "Part Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            listBox1.Items.Clear();// Clear the ListBox before adding new items
            var newResults = dbManager.QueryData(); //Variable to get the query data

            listBox1.Items.AddRange(newResults.ToArray()); //Outputs results to the list box.

            TextBox[] textBoxes = { textBox1, textBox3 }; //Clears the text box
            foreach (TextBox textBox in textBoxes)
            {
                textBox.Clear();
            }
            //dbManager.ClearData();
        }
    }
}
