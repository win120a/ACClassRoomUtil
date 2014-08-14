using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PowerOnLoggerManagmentTool
{
    public partial class Verify : Form
    {
        public Verify()
        {
            InitializeComponent();
        }

        private void co_Click(object sender, EventArgs e)
        {
#if DEBUG
            MessageBox.Show(Properties.Settings.Default.User);
            MessageBox.Show(Properties.Settings.Default.Pass);
#endif
            if ((p.Text.Equals(Properties.Settings.Default.Pass)) && (u.Text.Equals(Properties.Settings.Default.User)))
            {
                MessageBox.Show("OK", "OK");
                this.Hide();
                new Main().Show();
            }
            else
            {
                MessageBox.Show("User/Password Wrong!", "Fail");
            }
        }

        private void cc_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
