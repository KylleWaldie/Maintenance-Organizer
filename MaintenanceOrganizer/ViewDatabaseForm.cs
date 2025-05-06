using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaintenanceOrganizer
{
    public partial class ViewDatabaseForm : Form
    {

        AddDataForm addDataForm;
        DeleteDataForm deleteDataForm;

        public ViewDatabaseForm()
        {
            InitializeComponent();
            RefreshData(); // Load initially

            this.Activated += (s, e) => RefreshData(); // Reload when the form is re-activated
        }

        private void RefreshData()
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();

            var dbManager = new DatabaseManager("PartsDatabase.db");

            var results = dbManager.QueryData();
            listBox1.Items.AddRange(results.ToArray());

            var warnings = dbManager.LowItemError();
            listBox2.Items.AddRange(warnings.ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create an instance of the new form
            if (addDataForm == null)
            {
                addDataForm = new AddDataForm();
                addDataForm.FormClosed += addDataForm_FormClosed;
            }
            addDataForm.Show(this);
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Create an instance of the new form
            if (deleteDataForm == null)
            {
                deleteDataForm = new DeleteDataForm();
                deleteDataForm.FormClosed += deleteDataForm_FormClosed;
            }
            deleteDataForm.Show(this);
            Hide();
        }

        void addDataForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            addDataForm = null;
            Show();
        }

        void deleteDataForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            deleteDataForm = null;
            Show();
        }
    }
}
