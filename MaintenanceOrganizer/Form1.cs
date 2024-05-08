namespace MaintenanceOrganizer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //todo: add multiple inputs from user
            var dbManager = new DatabaseManager("PartsDatabase.db");
            dbManager.CreateDatabase();

            //Gets User Input for Part Name, Part Number, and Quantity
            string partName = textBox1.Text;
            string initalPartNumber = textBox2.Text;
            string partNumberToUpper = initalPartNumber.ToUpper(); //Makes sure that the part number is always all capitals
            string quantityString = textBox3.Text;
            int quantity = int.Parse(quantityString);

            dbManager.InsertData(partName, partNumberToUpper, quantity); //Inserts into the database

            listBox1.Items.Clear();// Clear the ListBox before adding new items
            var results = dbManager.QueryData(); //Variable to get the query data

            listBox1.Items.AddRange(results.ToArray()); //Outputs results to the list box.
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            dbManager.ClearData();
        }
    }
}
