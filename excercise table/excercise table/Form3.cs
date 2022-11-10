using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace excercise_table
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 frm = new Form4();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form6 frm = new Form6();
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            label2.Text = Form1.USERNAME.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            exercise frm = new exercise();
            frm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            warmup frm = new warmup();
            frm.Show();
        }
    }
}
