using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace MaintenanceOrganizer
{
    public partial class MainMenuForm : Form
    {
        ViewDataForm viewDataForm;
        public MainMenuForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create an instance of the new form
            if (viewDataForm == null)
            {
                viewDataForm = new ViewDataForm();
                viewDataForm.FormClosed += mainMenu_FormClosed;
            }
            viewDataForm.Show(this);
            Hide();
        }

        void mainMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            viewDataForm = null;
            Show();
        }
    }
}
