using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Digital_Clock_WindowsForm
{
    public partial class ClockWindow : Form
    {
        public ClockWindow()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Int32Converter i32c = new Int32Converter();
            h.Text = i32c.ConvertToString(DateTime.Now.Hour);
            m.Text = i32c.ConvertToString(DateTime.Now.Minute);
        }

        private void ClockWindow_Load(object sender, EventArgs e)
        {
            Int32Converter i32c = new Int32Converter();
            h.Text = i32c.ConvertToString(DateTime.Now.Hour);
            m.Text = i32c.ConvertToString(DateTime.Now.Minute);
            timer1.Start();
        }
    }
}
