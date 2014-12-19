using System;
using System.Windows.Forms;

namespace LPUGUIProvider
{
    public partial class Prefs : Form
    {
        public Prefs()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) // ok
        {
            Properties.Settings.Default.autologoff = checkBox1.Checked;
            Properties.Settings.Default.Save();
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e) // cancel
        {
            Application.Exit();
        }

        private void Prefs_Load(object sender, EventArgs e)
        {
            checkBox1.Checked = Properties.Settings.Default.autologoff;
        }
    }
}
