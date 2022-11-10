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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource = 127.0.01;port=3306;username=root;password=;database=exercise_table;charset=utf8;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;

        }



        public List<string> intlist = new List<string>();

        public List<string> WORK = new List<string>();

        void start()
        {
            Random random = new Random();

            for (int i = 1; i < 10; i++)
            {
                intlist.Add(i.ToString());
            }
            int index = random.Next(intlist.Count);

            warm1 = intlist[index];
            intlist.RemoveAt(index);
            index = random.Next(intlist.Count);
            warm2 = intlist[index];
            intlist.RemoveAt(index);
            index = random.Next(intlist.Count);
            warm3 = intlist[index];
            intlist.RemoveAt(index);

            //MessageBox.Show(warm1 + warm2 + warm3);
        }




        string warm1 = "";
        string warm2 = "";
        string warm3 = "";


        string work1 = "";
        string work2 = "";
        string work3 = "";
        string work4 = "";




        public Boolean checkname()
        {
            Class1 db = new Class1();

            String username = Form1.USERNAME.ToString();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `usingplan` WHERE `name` = @usn", db.getConnection());

            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = username;

            adapter.SelectCommand = command;

            adapter.Fill(table);

            // check if this name already exists in the database
            if (table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            MySqlConnection conn = databaseConnection();
            DataTable ds = new DataTable();

            conn.Open();

            MySqlCommand cmd;
            cmd = conn.CreateCommand();

            if (checkname())
            {
                
                String sql = "DELETE FROM usingplan WHERE name ='" + Form1.USERNAME + "'";
                MySqlCommand cmdd = new MySqlCommand(sql, conn);
                

                int rows = cmdd.ExecuteNonQuery();

                conn.Close();
                if (rows > 0)
                {
                

                    

                }
                           
            }


            if (checkBox1.Checked == true)
            {
                check1("1");

            }
            if (checkBox2.Checked == true)
            {
                check1("2");
            }
            if (checkBox3.Checked == true)
            {
                check1("3");
            }
            if (checkBox4.Checked == true)
            {
                check1("4");
            }
            if (checkBox5.Checked == true)
            {
                check1("5");
            }
            if (checkBox6.Checked == true)
            {
                check1("6");
            }
            if (checkBox7.Checked == true)
            {
                check1("7");
            }
            if (checkBox9.Checked == true)
            {

                start();

                finishhh();
            }
            else
            {
                start();

                finishhhhhh();
            }
            Form4 form4 = new Form4();
            form4.Show(); 
            this.Close();
                                





        }
    

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox8.Checked == true)
            {
                checkBox1.Checked = true;
                checkBox2.Checked = true;
                checkBox3.Checked = true;
                checkBox4.Checked = true;
                checkBox5.Checked = true;
                checkBox6.Checked = true;
                checkBox7.Checked = true;
            }

            if (checkBox8.Checked == false)
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                checkBox6.Checked = false;
                checkBox7.Checked = false;
            }

        }

        /*            
            Random random = new Random();

            for (int i = 0; i < 10; i++)
            {
                intlist.Add(i.ToString());
            }
            int index = random.Next(intlist.Count);

            warm1 = intlist[index];
            intlist.RemoveAt(index);
            index = random.Next(intlist.Count);
            warm2 = intlist[index];
            intlist.RemoveAt(index);
            index = random.Next(intlist.Count);
            warm3 = intlist[index];
            intlist.RemoveAt(index);*/

        void finishhh()
        {
            if (checkBox9.Checked == true)
            {

                MySqlConnection conn = databaseConnection();
                DataTable ds = new DataTable();

                conn.Open();

                MySqlCommand cmd;
                cmd = conn.CreateCommand();

                List<string> distinct = WORK.Distinct().ToList();

                Random random = new Random();
                int index = random.Next(distinct.Count);
                work1 = WORK[index];
                WORK.RemoveAt(index);
                index = random.Next(distinct.Count);
                work2 = WORK[index];
                WORK.RemoveAt(index);
                index = random.Next(distinct.Count);
                work3 = WORK[index];
                WORK.RemoveAt(index);
                index = random.Next(distinct.Count);
                work4 = WORK[index];
                WORK.RemoveAt(index);

                String sql = $"INSERT INTO usingplan (name,warm_up,warm_up2,warm_up3,work_out,work_out2,work_out3,work_out4) VALUES('" + Form1.USERNAME + "','" + warm1 + "','" + warm2 + "','" + warm3 + "','" + work1 + "','" + work2 + "','" + work3 + "','" + work4 + "')";
                cmd = new MySqlCommand(sql, conn);

                

                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("สร้างเสร็จสิ้น", "Plan Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("ERROR");
                }
                conn.Close();
            }
        }

        void finishhhhhh()
        {
            if (checkBox9.Checked == false)
            {

                MySqlConnection conn = databaseConnection();
                DataTable ds = new DataTable();

                conn.Open();

                MySqlCommand cmd;
                cmd = conn.CreateCommand();

                List<string> distinct = WORK.Distinct().ToList();

                Random random = new Random();
                int index = random.Next(distinct.Count);
                work1 = distinct[index];
                WORK.RemoveAt(index);
                index = random.Next(distinct.Count);
                work2 = distinct[index];
                WORK.RemoveAt(index);
                index = random.Next(distinct.Count);
                work3 = distinct[index];
                WORK.RemoveAt(index);
                index = random.Next(distinct.Count);
                work4 = distinct[index];
                WORK.RemoveAt(index);

                String sql = $"INSERT INTO usingplan (name,warm_up,warm_up2,warm_up3,work_out,work_out2,work_out3,work_out4) VALUES('" + Form1.USERNAME + "','none','none','none','" + work1 + "','" + work2 + "','" + work3 + "','" + work4 + "')";
                cmd = new MySqlCommand(sql, conn);



                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("สร้างเสร็จสิ้น", "Plan Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("ERROR");
                }
                conn.Close();
            }
        }


        void check1(string s)
        {
            MySqlConnection conn = databaseConnection();
            DataTable ds = new DataTable();

            conn.Open();

            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT id FROM work_out where muscle like '%" + s + "%'";

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);

            for (int i = 0; i < ds.Rows.Count; i++)
            {
                WORK.Add(ds.Rows[i].ItemArray[0].ToString());
                //MessageBox.Show(ds.Rows[i].ItemArray[0].ToString());
            }
            conn.Close();
        }


    }

}
