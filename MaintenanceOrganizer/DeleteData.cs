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

namespace MaintenanceOrganizer
{
    public partial class DeleteData : Form
    {
        public DeleteData()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //todo: add multiple inputs from user
            var dbManager = new DatabaseManager("PartsDatabase.db"); //creates a database if one doesnt exist
            dbManager.CreateDatabase();

            //Gets User Input for Part Name, Part Number, and Quantity
            string partName = textBox1.Text;
            string initalPartNumber = textBox1.Text;
            string partNumberToUpper = initalPartNumber.ToUpper(); //Makes sure that the part number is always all capitals
            string quantityString = textBox2.Text;
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
        }
    }
}
