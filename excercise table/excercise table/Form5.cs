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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            string muscle = "";
            foreach (char i in warmup()[1])
            {
                switch (i )
                {
                    case '1':
                        muscle += " biceps,";
                        break;
                    case '2':
                        muscle += " triceps,";
                        break;
                    case '3':
                        muscle += " shoulders,";
                        break;
                    case '4':
                        muscle += " abs,";
                        break;
                    case '5':
                        muscle += " back,";
                        break;
                    case '6':
                        muscle += " chests,";
                        break;
                    case '7':
                        muscle += " legs,";
                        break;
                    default:muscle += "none";
                        break;
                }
                
                
            }
            //MessageBox.Show(muscle);
            textBox1.Text = muscle;
            //textBox1.Text = warmup()[1];
            textBox2.Text = warmup()[2]+ " วินาที";
            textBox3.Text = warmup()[3];
            textBox5.Text = warmup()[4];

            richTextBox1.Text = warmup()[5];
            pictureBox1.Image = Image.FromFile(warmup()[6]);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource = 127.0.01;port=3306;username=root;password=;database=exercise_table;charset=utf8;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;

        }

        List<string> warmup()
        {
            string[] allforone = Form4.ONEFORALL.Split(',');
            List<string> WARM = new List<string>();

            MySqlConnection conn = databaseConnection();

            string sql = "SELECT * FROM " + allforone[0] + " where name = '" + allforone[1] + "'";
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                WARM.Add(dr.GetString("name"));
                WARM.Add(dr.GetString("muscle"));
                WARM.Add(dr.GetString("timeperset"));
                WARM.Add(dr.GetString("equipment"));
                WARM.Add(dr.GetString("setamount"));
                WARM.Add(dr.GetString("explan"));
                WARM.Add(dr.GetString("gif"));


            }
            return WARM;
        }


    }
}
