using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace PowerOnLoggerManagmentTool
{
    public partial class Delete : Form
    {

        private int wrongCount = 0;
        private int maxWrongCount = 5;
        private int remainChance;

        public Delete()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Dispose();
            GC.Collect();
            new Main().Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            wrongCount++;

            remainChance = maxWrongCount - wrongCount;

            if (Properties.Settings.Default.Pass.Equals(textBox1.Text))
            {
                if (MessageBox.Show("Are you sure?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation).Equals(DialogResult.Yes))
                {
                    if (Directory.Exists(Environment.GetEnvironmentVariable("SystemRoot") + "\\System32\\AC-Engine\\PowerOnLogger"))
                    {
                        Directory.Delete(Environment.GetEnvironmentVariable("SystemRoot") + "\\System32\\AC-Engine\\PowerOnLogger", true);
                        Directory.CreateDirectory(Environment.GetEnvironmentVariable("SystemRoot") + "\\System32\\AC-Engine\\PowerOnLogger");
                        MessageBox.Show("Delete Log Successful.", "Done");
                        this.Hide();
                        this.Dispose();
                        GC.Collect();
                        new Main().Show();
                    }
                    else
                    {
                        MessageBox.Show("You did not install POL.", "HINT!");
                        this.Hide();
                        this.Dispose();
                        GC.Collect();
                        new Main().Show();
                    }
                }
                else
                {
                    this.Hide();
                    this.Dispose();
                    GC.Collect();
                    new Main().Show();
                }
            }
            else
            {
                if (remainChance == 0)
                {
                    MessageBox.Show("Password Wrong! You have no chance.", "Fail");
                }
                if (remainChance == 1)
                {
                    MessageBox.Show("Password Wrong! You only have " + remainChance + " chance.", "Fail");
                }
                else
                {
                    MessageBox.Show("Password Wrong! You only have " + remainChance + " chances.", "Fail");
                }

                if (wrongCount >= maxWrongCount)
                {
                    this.Hide();
                    this.Dispose();
                    GC.Collect();
                    Main mainObj = new Main();
                    mainObj.button1.Enabled = false;
                    mainObj.button2.Enabled = false;
                    mainObj.button3.Enabled = false;
                    mainObj.Show();
                }
            }
        }
    }
}
