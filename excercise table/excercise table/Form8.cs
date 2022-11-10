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
    public partial class Form8 : Form
    {
        public Form8()
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

        

        

        

        

        

        

        private void Form8_Load(object sender, EventArgs e)
        {
            showEquipment();
        }

        

        

        private void button1_Click_1(object sender, EventArgs e)
        {
            MySqlConnection conn = databaseConnection();
            String sql = $"INSERT INTO warm_up (name,muscle,timeperset,equipment,setamount,explan,pic,gif) VALUES('" + textBox1.Text + "','testmuscle','" + textBox2.Text + "','" + textBox4.Text + "','" + textBox3.Text + "','" + richTextBox1.Text + "','" + textBox5.Text + "','" + textBox6.Text + "')";
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            conn.Open();

            int rows = cmd.ExecuteNonQuery();

            conn.Close();

            if (rows > 0)
            {
                MessageBox.Show("เพิ่มข้อมูลสำเร็จ");

                showEquipment();

            }
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonserach_Click_1(object sender, EventArgs e)
        {
            showEquipment();
        }

        private void Showalldataintable_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            Showalldataintable.CurrentRow.Selected = true;
            textBox1.Text = Showalldataintable.Rows[e.RowIndex].Cells["name"].FormattedValue.ToString();
            textBox7.Text = Showalldataintable.Rows[e.RowIndex].Cells["muscle"].FormattedValue.ToString();
            textBox2.Text = Showalldataintable.Rows[e.RowIndex].Cells["timeperset"].FormattedValue.ToString();
            textBox3.Text = Showalldataintable.Rows[e.RowIndex].Cells["setamount"].FormattedValue.ToString();
            textBox4.Text = Showalldataintable.Rows[e.RowIndex].Cells["equipment"].FormattedValue.ToString();
            textBox5.Text = Showalldataintable.Rows[e.RowIndex].Cells["pic"].FormattedValue.ToString();
            textBox6.Text = Showalldataintable.Rows[e.RowIndex].Cells["gif"].FormattedValue.ToString();
            richTextBox1.Text = Showalldataintable.Rows[e.RowIndex].Cells["explan"].FormattedValue.ToString();
        }

        private void button4_Click_1(object sender, EventArgs e)
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

        private void button5_Click_1(object sender, EventArgs e)
        {
            if (!File.Exists(textBox6.Text))
            {
                MessageBox.Show("notfound");
            }
            else
            {
                Image image = Image.FromFile(textBox6.Text);
                this.pictureBox1.Image = image;
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            int selectedRow = Showalldataintable.CurrentCell.RowIndex;
            int editId = Convert.ToInt32(Showalldataintable.Rows[selectedRow].Cells["id"].Value);

            MySqlConnection conn = databaseConnection();
            String sql = "UPDATE warm_up SET name = '" + textBox1.Text + "', muscle = 'muscletest', timeperset = '" + textBox2.Text + "', equipment = '" + textBox4.Text + "', setamount = '" + textBox3.Text + "', explan = '" + richTextBox1.Text + "', pic = '" + textBox5.Text + "', gif = '" + textBox6.Text + "' WHERE id = '" + editId + "'";
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

        private void button2_Click_1(object sender, EventArgs e)
        {
            int selectedRow = Showalldataintable.CurrentCell.RowIndex;
            int deleteId = Convert.ToInt32(Showalldataintable.Rows[selectedRow].Cells["id"].Value);

            MySqlConnection conn = databaseConnection();
            String sql = "DELETE FROM warm_up WHERE id ='" + deleteId + "'";
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
    }
}
