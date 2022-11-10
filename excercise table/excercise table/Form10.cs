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
    public partial class Form10 : Form
    {
        public Form10()
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
                cmd.CommandText = "SELECT * FROM register";
            }
            else
            {
                cmd.CommandText = "SELECT * FROM register where username LIKE '%" + textBoxsearch.Text + "%' OR firstname LIKE '%" + textBoxsearch.Text + "%'";
            }

            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(ds);

            conn.Close();
            Showalldataintable.DataSource = ds.Tables[0].DefaultView;


        }

        

        
        

        private void Form10_Load(object sender, EventArgs e)
        {
            showEquipment();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = databaseConnection();
            String sql = $"INSERT INTO register (firstname,lastname,phonenumber,yourmail,username,password) VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "')";
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

        private void button2_Click(object sender, EventArgs e)
        {
            int selectedRow = Showalldataintable.CurrentCell.RowIndex;
            int deleteId = Convert.ToInt32(Showalldataintable.Rows[selectedRow].Cells["id"].Value);

            MySqlConnection conn = databaseConnection();
            String sql = "DELETE FROM register WHERE id ='" + deleteId + "'";
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

        private void button3_Click(object sender, EventArgs e)
        {
            int selectedRow = Showalldataintable.CurrentCell.RowIndex;
            int editId = Convert.ToInt32(Showalldataintable.Rows[selectedRow].Cells["id"].Value);

            MySqlConnection conn = databaseConnection();
            String sql = "UPDATE register SET firstname = '" + textBox1.Text + "', lastname = '" + textBox2.Text + "', phonenumber = '" + textBox3.Text + "', yourmail = '" + textBox4.Text + "', username = '" + textBox5.Text + "', password = '" + textBox6.Text + "' WHERE id = '" + editId + "'";

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

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Showalldataintable_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            Showalldataintable.CurrentRow.Selected = true;
            textBox1.Text = Showalldataintable.Rows[e.RowIndex].Cells["firstname"].FormattedValue.ToString();
            textBox2.Text = Showalldataintable.Rows[e.RowIndex].Cells["lastname"].FormattedValue.ToString();
            textBox3.Text = Showalldataintable.Rows[e.RowIndex].Cells["phonenumber"].FormattedValue.ToString();
            textBox4.Text = Showalldataintable.Rows[e.RowIndex].Cells["yourmail"].FormattedValue.ToString();
            textBox5.Text = Showalldataintable.Rows[e.RowIndex].Cells["username"].FormattedValue.ToString();
            textBox6.Text = Showalldataintable.Rows[e.RowIndex].Cells["password"].FormattedValue.ToString();
        }

        private void buttonserach_Click_1(object sender, EventArgs e)
        {
            showEquipment();
        }
    }
}
