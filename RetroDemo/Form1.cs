using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fuel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        int num = 0;
        private void btnUp_Click(object sender, EventArgs e)
        {
            if(num < 9)
                rollingNumber1.SetNumber(++num);
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            if (num > 0)
                rollingNumber1.SetNumber(--num);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            rollingNumber1.AnimationDelay = trackBar1.Value;
        }
    }
}
