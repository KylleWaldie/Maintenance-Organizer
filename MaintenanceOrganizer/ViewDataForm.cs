namespace MaintenanceOrganizer
{
    public partial class ViewDataForm : Form
    {
        public ViewDataForm()
        {
            InitializeComponent();
            var dbManager = new DatabaseManager("PartsDatabase.db");
            var results = dbManager.QueryData();
            // Populate the ListBox with the query results
            listBox1.Items.AddRange(results.ToArray());
        }


        private void button1_Click(object sender, EventArgs e)
        {
            //todo: add multiple inputs from user
            var nonDatabase = new NonDatabaseFunctions();
            var dbManager = new DatabaseManager("PartsDatabase.db"); //creates a database if one doesnt exist
            dbManager.CreateDatabase();

            //Gets User Input for Part Name, Part Number, and Quantity
            string partName = nonDatabase.CapitalizeFirstThreeLetters(textBox1.Text.Trim());

            string initalPartNumber = textBox2.Text;
            string partNumberToUpper = initalPartNumber.ToUpper(); //Makes sure that the part number is always all capitals
            string quantityString = textBox3.Text;
            int quantity = int.Parse(quantityString);

            //Checks if part number already in database
            if (dbManager.GetPartNumber(partNumberToUpper))
            {
                dbManager.ChangeAmountData(partNumberToUpper, quantity);
            }
            else
            {
                dbManager.InsertData(partName, partNumberToUpper, quantity); //Inserts into the database
            }

            listBox1.Items.Clear();// Clear the ListBox before adding new items
            var newResults = dbManager.QueryData(); //Variable to get the query data

            listBox1.Items.AddRange(newResults.ToArray()); //Outputs results to the list box.

            TextBox[] textBoxes = { textBox1, textBox2, textBox3 }; //Clears the text box
            foreach (TextBox textBox in textBoxes)
            {
                textBox.Clear();
            }
            //dbManager.ClearData();
        }

    }
}
