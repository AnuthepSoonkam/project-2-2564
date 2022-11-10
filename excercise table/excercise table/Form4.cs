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
    public partial class Form4 : Form
    {
        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource = 127.0.01;port=3306;username=root;password=;database=exercise_table;charset=utf8;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;

        }

        public List<string> WORK = new List<string>();

        public static string ONEFORALL = "";

        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ONEFORALL = "warm_up," + label1.Text;
            Form5 form = new Form5();
            form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ONEFORALL = "warm_up," + label3.Text;
            Form5 form = new Form5();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ONEFORALL = "warm_up," + label2.Text;
            Form5 form = new Form5();
            form.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ONEFORALL = "work_out," + label8.Text;
            Form5 form = new Form5();
            form.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ONEFORALL = "work_out," + label9.Text;
            Form5 form = new Form5();
            form.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ONEFORALL = "work_out," + label10.Text;
            Form5 form = new Form5();
            form.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            ONEFORALL = "work_out," + label11.Text;
            Form5 form = new Form5();
            form.Show();
        }



        private void Form4_Load(object sender, EventArgs e)
        {
            check1();
            if (WORK.Count > 0)
            {
                label1.Text = warmup(WORK[0], "warm_up")[0];
                pictureBox1.Image = Image.FromFile(warmup(WORK[0], "warm_up")[1]);
                label2.Text = warmup(WORK[1], "warm_up")[0];
                pictureBox2.Image = Image.FromFile(warmup(WORK[1], "warm_up")[1]);
                label3.Text = warmup(WORK[2], "warm_up")[0];
                pictureBox3.Image = Image.FromFile(warmup(WORK[2], "warm_up")[1]);
                label8.Text = warmup(WORK[3], "work_out")[0];
                pictureBox8.Image = Image.FromFile(warmup(WORK[3], "work_out")[1]);
                label9.Text = warmup(WORK[4], "work_out")[0];
                pictureBox9.Image = Image.FromFile(warmup(WORK[4], "work_out")[1]);
                label10.Text = warmup(WORK[5], "work_out")[0];
                pictureBox10.Image = Image.FromFile(warmup(WORK[5], "work_out")[1]);
                label11.Text = warmup(WORK[6], "work_out")[0];
                pictureBox11.Image = Image.FromFile(warmup(WORK[6], "work_out")[1]);

            }
            else
            {
                MessageBox.Show("ยังไม่มีแผนการออกกำลังกาย");
                this.Close();
            }



        }

        void check1()
        {
            MySqlConnection conn = databaseConnection();

            string sql = "SELECT * FROM usingplan where name = '" + Form1.USERNAME + "'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                for (int i = 1; i < 8; i++)
                {
                    WORK.Add(dr.GetString(i));
                    //MessageBox.Show(dr.GetString(i));
                }
            }


            conn.Close();
        }

        public List<string> warmup(string id, string table)
        {
            List<string> WARM = new List<string>();

            MySqlConnection conn = databaseConnection();

            string sql = "SELECT * FROM " + table + " where id = '" + id + "'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                WARM.Add(dr.GetString("name"));
                WARM.Add(dr.GetString("pic"));

            }
            return WARM;
        }

        public static string ID = "";
        public static string work = "";

        private void button5_Click(object sender, EventArgs e)
        {
            exercise frm = new exercise();
            frm.Show();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            editwarmup frm = new editwarmup();
            frm.Show();
            ID = "1";
            work = WORK[0];
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            editwarmup frm = new editwarmup();
            frm.Show();
            ID = "2";
            work = WORK[1];
            this.Close();
        }




        private void button12_Click(object sender, EventArgs e)
        {
            editwarmup frm = new editwarmup();
            frm.Show();
            ID = "3";
            work = WORK[2];
            this.Close();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            editexcercise frm = new editexcercise();
            frm.Show();
            ID = "4";
            work = WORK[3];
            this.Close();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            editexcercise frm = new editexcercise();
            frm.Show();
            ID = "5";
            work = WORK[4];
            this.Close();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            editexcercise frm = new editexcercise();
            frm.Show();
            ID = "6";
            work = WORK[5];
            this.Close();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            editexcercise frm = new editexcercise();
            frm.Show();
            ID = "7";
            work = WORK[6];
            this.Close();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            warmup frm = new warmup();
            frm.Show();

        }

    }
}
