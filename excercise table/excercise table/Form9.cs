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
using System.IO;
using System.Drawing.Imaging;

namespace excercise_table
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource = 127.0.01;port=3306;username=root;password=;database=exercise_table;charset=utf8;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;

        }

        private void showEquipment()
        {
            MySqlConnection conn = databaseConnection();
            DataSet ds = new DataSet();
            conn.Open();

            MySqlCommand cmd;
            cmd = conn.CreateCommand();
            if (string.IsNullOrEmpty(textBoxsearch.Text))
            {
                cmd.CommandText = "SELECT * FROM usingplan";
            }
            else
            {
                cmd.CommandText = "SELECT * FROM usingplan where name LIKE '%" + textBoxsearch.Text + "%'";
            }

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);

            conn.Close();
            Showalldataintable.DataSource = ds.Tables[0].DefaultView;


        }

        private void Form9_Load(object sender, EventArgs e)
        {
            showEquipment();

        }

        

        private void button3_Click(object sender, EventArgs e)
        {
            int selectedRow = Showalldataintable.CurrentCell.RowIndex;
            int editId = Convert.ToInt32(Showalldataintable.Rows[selectedRow].Cells["id"].Value);

            MySqlConnection conn = databaseConnection();
            String sql = "UPDATE usingplan SET warm_up = '" + textBox2.Text + "', warm_up2 = '" + textBox3.Text + "', warm_up3 = '" + textBox4.Text + "', work_out = '" + textBox5.Text + "', work_out2 = '" + textBox6.Text + "', work_out3 = '" + textBox7.Text + "', work_out4 = '" + textBox8.Text + "' WHERE name = '" + Form1.USERNAME + "'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();

            int rows = cmd.ExecuteNonQuery();
            conn.Close();

            if (rows > 0)
            {
                MessageBox.Show("แก้ไขข้อมูลสำเร็จ");

                showEquipment();

            }
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            

            MySqlConnection conn = databaseConnection();
            String sql = "DELETE FROM usingplan WHERE name ='" + Form1.USERNAME + "'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();

            int rows = cmd.ExecuteNonQuery();

            conn.Close();
            if (rows > 0)
            {
                MessageBox.Show("ลบข้อมูลสำเร็จ");

                showEquipment();

            }
        }

        

        

        

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonserach_Click_1(object sender, EventArgs e)
        {
            showEquipment();
        }

        public List<string> WORK1 = new List<string>();

        public List<string> WORK2 = new List<string>();
        private void Showalldataintable_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            
            for(int i = 1; i < 8; i++)
            {
                WORK1.Add(Showalldataintable.Rows[e.RowIndex].Cells[i].FormattedValue.ToString());
                //MessageBox.Show(Showalldataintable.Rows[e.RowIndex].Cells[i].FormattedValue.ToString());

            }

            for(int i = 0; i <WORK1.Count; i++)
            {
                if (i < 3)
                {
                    WORK2.Add(new Form4().warmup(WORK1[i], "warm_up")[0]);


                }
                else
                {
                    WORK2.Add(new Form4().warmup(WORK1[i], "work_out")[0]);

                }
            }
            
            Showalldataintable.CurrentRow.Selected = true;
            textBox1.Text = Showalldataintable.Rows[e.RowIndex].Cells["name"].FormattedValue.ToString();
            textBox2.Text = WORK2[0];
            textBox3.Text = WORK2[1];
            textBox4.Text = WORK2[2];
            textBox5.Text = WORK2[3];
            textBox7.Text = WORK2[4];
            textBox6.Text = WORK2[5];
            textBox8.Text = WORK2[6];
        }

        /*void check1()
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
                    WORK1.Add(dr.GetString(i));
                    //MessageBox.Show(dr.GetString(i));
                }
            }


            conn.Close();
        }*/
    }
}
