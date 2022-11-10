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
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
        }


        public static string USERNAME = "";
        private void button1_Click(object sender, EventArgs e)
        {
            Class1 db = new Class1();

            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;

            DataTable dt = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM register WHERE username = @usn and password = @pass", db.getConnection());

            cmd.Parameters.Add("@usn", MySqlDbType.VarChar).Value = username;
            cmd.Parameters.Add("@pass", MySqlDbType.VarChar).Value = password;

            adapter.SelectCommand = cmd;

            adapter.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Welcome");
                USERNAME = username;
                
                Form3 mainform = new Form3();
                mainform.Show();
                

            }
            else
            {
                MessageBox.Show("กรุณาใส่ user name และ password ให้ถูกต้อง");
            }



        }

        

        private void button3_Click_1(object sender, EventArgs e)
        {
            admin frm = new admin();
            frm.Show();
        }
    }
}
