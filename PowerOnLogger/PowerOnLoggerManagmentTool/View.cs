using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections;

namespace PowerOnLoggerManagmentTool
{
    public partial class View : Form
    {
        public View()
        {
            InitializeComponent();
        }

        private void View_Load(object sender, EventArgs e)
        {
            listBox1.Hide();
            String path = Environment.GetEnvironmentVariable("SystemRoot") + "\\System32\\AC-Engine\\PowerOnLogger";
            IEnumerable enu0 = Directory.EnumerateFiles(path);

            listBox1.BeginUpdate();

            foreach (string s in enu0)
            {
                string first = s.Replace(path + "\\", " ");
                string second = first.Replace("ACPOL_", " ");
                string third = second.Replace("_", " ");
                string forth = third.Replace("H ", ":").Replace("M ", ":");
                string fifth = forth.Replace("S ", " ");
                string final = fifth.Replace(".aclog", " ");
                listBox1.Items.Add(final);
            }

            listBox1.EndUpdate();

            listBox1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            GC.Collect();
            new Main().Show();
        }
    }
}
