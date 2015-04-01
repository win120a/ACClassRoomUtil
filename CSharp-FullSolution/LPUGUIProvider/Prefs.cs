using System;
using System.Collections.Generic;
using System.Windows.Forms;
using LPUGUIProvider.Properties;
using ACLibrary.Collection;
using System.ComponentModel;

namespace LPUGUIProvider
{
    public partial class Prefs : Form
    {
        ACDictionary<string, int> SelectBoxData = new ACDictionary<string, int>();

        public Prefs()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) // ok
        {
            Settings.Default.operateID = SelectBoxData[comboBox1.Text];
            Settings.Default.Save();
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e) // cancel
        {
            Application.Exit();
        }

        private void Prefs_Load(object sender, EventArgs e)
        {
            SelectBoxData.Add("不操作", 0);
            SelectBoxData.Add("关  机", 1);
            SelectBoxData.Add("重  启", 2);
            SelectBoxData.Add("注  销", 3);

            // comboBox1.Text = SelectBoxData.GetKeyByValue(Settings.Default.operateID);

            foreach (string s in SelectBoxData.KeyList())
            {
                comboBox1.Items.Add(s);
            }

            comboBox1.Text = SelectBoxData.GetKeyByValue(Settings.Default.operateID);
        }
    }
}
