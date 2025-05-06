namespace MaintenanceOrganizer
{
    partial class ViewDatabaseForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewDatabaseForm));
            listBox1 = new ListBox();
            listBox2 = new ListBox();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(141, 82);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(518, 274);
            listBox1.TabIndex = 0;
            // 
            // listBox2
            // 
            listBox2.FormattingEnabled = true;
            listBox2.ItemHeight = 15;
            listBox2.Location = new Point(141, 12);
            listBox2.Name = "listBox2";
            listBox2.Size = new Size(518, 64);
            listBox2.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(141, 372);
            button1.Name = "button1";
            button1.Size = new Size(123, 55);
            button1.TabIndex = 2;
            button1.Text = "Add Parts";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(536, 372);
            button2.Name = "button2";
            button2.Size = new Size(123, 55);
            button2.TabIndex = 3;
            button2.Text = "Remove Parts";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // ViewDatabaseForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(800, 450);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(listBox2);
            Controls.Add(listBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ViewDatabaseForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ViewDatabase";
            ResumeLayout(false);
        }

        #endregion

        private ListBox listBox1;
        private ListBox listBox2;
        private Button button1;
        private Button button2;
    }
}