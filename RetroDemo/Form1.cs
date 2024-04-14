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
        private void button1_Click(object sender, EventArgs e)
        {
            rollingNumber1.SetNumber(num++);
        }
    }
}
