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
    public partial class editwarmup : Form
    {
        public editwarmup()
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
                cmd.CommandText = "SELECT * FROM warm_up";
            }
            else
            {
                cmd.CommandText = "SELECT * FROM warm_up where name LIKE '%" + textBoxsearch.Text + "%'";
            }

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);

            conn.Close();
            Showalldataintable.DataSource = ds.Tables[0].DefaultView;


        }

        private void editwarmup_Load(object sender, EventArgs e)
        {
            showEquipment();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void buttonserach_Click(object sender, EventArgs e)
        {
            showEquipment();
        }

        private void Showalldataintable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Showalldataintable.CurrentRow.Selected = true;
            textBox8.Text = Showalldataintable.Rows[e.RowIndex].Cells["id"].FormattedValue.ToString();
            textBox1.Text = Showalldataintable.Rows[e.RowIndex].Cells["name"].FormattedValue.ToString();
            textBox7.Text = Showalldataintable.Rows[e.RowIndex].Cells["muscle"].FormattedValue.ToString();
            textBox2.Text = Showalldataintable.Rows[e.RowIndex].Cells["timeperset"].FormattedValue.ToString();
            textBox3.Text = Showalldataintable.Rows[e.RowIndex].Cells["setamount"].FormattedValue.ToString();
            textBox4.Text = Showalldataintable.Rows[e.RowIndex].Cells["equipment"].FormattedValue.ToString();
            textBox5.Text = Showalldataintable.Rows[e.RowIndex].Cells["pic"].FormattedValue.ToString();
            textBox6.Text = Showalldataintable.Rows[e.RowIndex].Cells["gif"].FormattedValue.ToString();
            richTextBox1.Text = Showalldataintable.Rows[e.RowIndex].Cells["explan"].FormattedValue.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!File.Exists(textBox5.Text))
            {
                MessageBox.Show("notfound");
            }
            else
            {
                Image image = Image.FromFile(textBox5.Text);
                this.pictureBox1.Image = image;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!File.Exists(textBox5.Text))
            {
                MessageBox.Show("notfound");
            }
            else
            {
                Image image = Image.FromFile(textBox6.Text);
                this.pictureBox1.Image = image;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Form4.ID == "1")
            {
                finish(Form4.work);
            }
            if (Form4.ID == "2")
            {
                finishh(Form4.work);
            }
            if (Form4.ID == "3")
            {
                finishhh(Form4.work);
            }

            Form4 frm = new Form4();
            frm.Show();
            this.Close();
        }

        void finish(string b)
        {
            int selectedRow = Showalldataintable.CurrentCell.RowIndex;
            int editId = Convert.ToInt32(Showalldataintable.Rows[selectedRow].Cells["id"].Value);

            MySqlConnection conn = databaseConnection();
            String sql = "UPDATE usingplan SET warm_up = '" + textBox8.Text + "' WHERE warm_up = '" + b + "'";
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

        void finishh(string b)
        {
            int selectedRow = Showalldataintable.CurrentCell.RowIndex;
            int editId = Convert.ToInt32(Showalldataintable.Rows[selectedRow].Cells["id"].Value);

            MySqlConnection conn = databaseConnection();
            String sql = "UPDATE usingplan SET warm_up2 = '" + textBox8.Text + "' WHERE warm_up2 = '" + b + "'";
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

        void finishhh(string b)
        {
            int selectedRow = Showalldataintable.CurrentCell.RowIndex;
            int editId = Convert.ToInt32(Showalldataintable.Rows[selectedRow].Cells["id"].Value);

            MySqlConnection conn = databaseConnection();
            String sql = "UPDATE usingplan SET warm_up3 = '" + textBox8.Text + "' WHERE warm_up3 = '" + b + "'";
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
    }
}
