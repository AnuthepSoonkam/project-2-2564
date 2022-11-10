using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace excercise_table
{
    public partial class way : Form
    {
        public way()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form7 frm = new Form7();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Form8 frm = new Form8();
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form9 frm = new Form9();
            frm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form10 frm = new Form10();
            frm.Show();
        }
    }
}
