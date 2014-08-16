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
    public partial class Main : Form
    {
        int selfLockTime = 1;  // in minutes

        public Main()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Dispose();
            GC.Collect();
            new Account().Show();
        }



        private void Main_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000 * 60 * selfLockTime;
            timer1.Start();
        }

        private void lo_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Dispose();
            GC.Collect();
            new Verify().Show();
        }

        private void x_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Dispose();
            GC.Collect();
            new View().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Dispose();
            GC.Collect();
            new Delete().Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            this.Hide();
            this.Dispose();
            GC.Collect();
            new Verify().Show();
        }
    }
}
