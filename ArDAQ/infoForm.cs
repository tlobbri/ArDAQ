using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArDAQ
{
    public partial class infoForm : Form
    {

        public infoForm(string info, int timerDuration)
        {
            InitializeComponent();
            tbinfo.Text = string.Format(info);
            timer1.Interval= timerDuration;
            this.ShowDialog();
        }

        public void SetInfo(string msg)
        {
            this.tbinfo.Text = string.Format(msg);
        }



        private void infoForm_MouseClick(object sender, MouseEventArgs e)
        {
            this.Dispose();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

            timer1.Enabled = false;
            this.Dispose();

        }

        private void infoForm_Load(object sender, EventArgs e)
        {

        }
    }
}
