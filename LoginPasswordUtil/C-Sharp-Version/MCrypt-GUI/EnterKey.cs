using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCrypt_GUI
{
    public partial class EnterKey : Form
    {
        public EnterKey()
        {
            InitializeComponent();
        }

        private void ok_Click(object sender, EventArgs e)
        {
            DataStore.Key = textBox1.Text;
            this.Hide();
            GC.Collect();
            this.Dispose();
        }

        private void can_Click(object sender, EventArgs e)
        {
            DataStore.exit = true;
            this.Hide();
            GC.Collect();
            this.Dispose();
        }

        private void EnterKey_Load(object sender, EventArgs e)
        {
            DataStore.exit = false;
        }
    }
}
