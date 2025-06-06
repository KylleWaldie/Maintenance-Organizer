﻿using System;
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
        AddDataForm addDataForm;
        DeleteDataForm deleteDataForm;
        ViewDatabaseForm viewDatabaseForm;

        public MainMenuForm()
        {
            InitializeComponent();
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
            if (viewDatabaseForm == null)
            {
                viewDatabaseForm = new ViewDatabaseForm();
                viewDatabaseForm.FormClosed += viewDatabaseForm_FormClosed;
            }

            viewDatabaseForm.Show(this);
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
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

        void viewDatabaseForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            viewDatabaseForm = null;
            Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
