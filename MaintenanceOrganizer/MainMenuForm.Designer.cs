﻿
namespace MaintenanceOrganizer
{
    partial class MainMenuForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenuForm));
            button1 = new Button();
            label1 = new Label();
            button3 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(228, 262);
            button1.Name = "button1";
            button1.Size = new Size(280, 73);
            button1.TabIndex = 0;
            button1.Text = "Add Parts";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(257, 104);
            label1.Name = "label1";
            label1.Size = new Size(222, 15);
            label1.TabIndex = 1;
            label1.Text = "Maintenance Department Parts Database";
            label1.Click += label1_Click;
            // 
            // button3
            // 
            button3.Location = new Point(228, 370);
            button3.Name = "button3";
            button3.Size = new Size(280, 73);
            button3.TabIndex = 0;
            button3.Text = "Remove Parts";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Location = new Point(228, 154);
            button2.Name = "button2";
            button2.Size = new Size(280, 73);
            button2.TabIndex = 2;
            button2.Text = "View Parts";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // MainMenuForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(764, 490);
            Controls.Add(button2);
            Controls.Add(button3);
            Controls.Add(label1);
            Controls.Add(button1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainMenuForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Database Main Menu";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private Button button3;
        private Button button2;
    }
}