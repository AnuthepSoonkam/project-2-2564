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
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace excercise_table
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private MySqlConnection databaseConnection()
        {
            string connectionString = "datasource = 127.0.01;port=3306;username=root;password=;database=exercise_table;charset=utf8;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;

        }


        
         

        private void button1_Click(object sender, EventArgs e)
        {

            string pass = textBox4.Text;
            //string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";


            MySqlConnection conn = databaseConnection();
            String sql = $"INSERT INTO register (firstname,lastname,phonenumber,yourmail,username,password) VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')";
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            conn.Open();

            

            if (!checkTextBoxesValues())
            {
                // check if the password equal the confirm password
                if (textBox4.Text.Equals(textBox7.Text))
                {

                    if (textBox5.TextLength == 10)
                    {


                        // check if this username already exists
                        if (checkUsername())
                        {
                            MessageBox.Show("Username นี้ ถูกใช้ไปแล้ว โปรดกรอก Username อื่น", "Duplicate Username", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                        }
                        else
                        {
                            // execute the query
                            if (cmd.ExecuteNonQuery() == 1)
                            {
                                MessageBox.Show("สร้างบัญชีเสร็จสิ้น", "Account Created", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("ERROR");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("โปรดกรอกเบอร์โทรศัพท์ให้ถูกต้อง", "Phone number Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                    }


                }
                else
                {
                    MessageBox.Show("โปรดยืนยันรหัสผ่านให้ถูกต้อง", "Password Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("โปรดใส่ข้อมูล", "Empty Data", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }

            conn.Close();

        }

        public Boolean checkUsername()
        {
            Class1 db = new Class1();

            String username = textBox3.Text;

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `register` WHERE `username` = @usn", db.getConnection());

            command.Parameters.Add("@usn", MySqlDbType.VarChar).Value = username;

            adapter.SelectCommand = command;

            adapter.Fill(table);

            // check if this username already exists in the database
            if (table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        public Boolean checkTextBoxesValues()
        {
            String fname = textBox1.Text;
            String lname = textBox2.Text;
            String email = textBox6.Text;
            String uname = textBox3.Text;
            String pass = textBox4.Text;

            if (fname.Equals("") || lname.Equals("") ||
                email.Equals("") || uname.Equals("")
                || pass.Equals(""))
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }





        private void textBox6_Validating(object sender, CancelEventArgs e)
        {
            System.Text.RegularExpressions.Regex rEMail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
            if (!rEMail.IsMatch(textBox6.Text))
            {
                MessageBox.Show("กรุณากรอก Email ให้ถูกต้อง", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox6.SelectAll();
                e.Cancel = true;
            }
        }

        private void textBox5_Validating(object sender, CancelEventArgs e)
        {
            System.Text.RegularExpressions.Regex rEMail = new System.Text.RegularExpressions.Regex(@"^[0-9]{0,10}$");
            if (!rEMail.IsMatch(textBox5.Text))
            {
                MessageBox.Show("กรุณากรอก หมายเลขโทรศัพท์ ให้ถูกต้อง", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox5.SelectAll();
                e.Cancel = true;
            }
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            System.Text.RegularExpressions.Regex rEMail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z]{0,100}$");
            if (!rEMail.IsMatch(textBox1.Text))
            {
                MessageBox.Show("กรุณากรอก ชื่อจริง เป็นภาษาอังกฤษ ให้ถูกต้อง", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.SelectAll();
                e.Cancel = true;
            }
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            System.Text.RegularExpressions.Regex rEMail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z]{0,100}$");
            if (!rEMail.IsMatch(textBox2.Text))
            {
                MessageBox.Show("กรุณากรอก นามสกุล เป็นภาษาอังกฤษ ให้ถูกต้อง", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.SelectAll();
                e.Cancel = true;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                button1.Enabled = true;
            }

            if (checkBox1.Checked == false)
            {
                button1.Enabled = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("“เงื่อนไขการใช้บริการ” ที่กำหนดนี้จะครอบคลุมสิทธิและภาระหน้าที่ในการใช้งานโปรแกรมคอมพิวเตอร์และการบริการ จึงขอให้ท่านอ่านและพิจารณาเงื่อนไขการใช้บริการที่กำหนดไว้นี้โดยละเอียด เมื่อท่านใช้บริการของโปรแกรม ย่อมถือว่าท่านยินยอมและยอมรับที่จะผูกพันและปฏิบัติตาม \n\n สิทธิการใช้ \n\tท่านสามารถใช้บริการเพื่อประโยชน์ส่วนบุคคลของท่านเท่านั้น ท่านไม่สามารถใช้บริการโดยมีวัตถุประสงค์เพื่อการค้าใดๆก็ตาม เมื่อมีการใช้บริการหรือใช้ข้อมูลจากฐานข้อมูล ท่านไม่สามารถแยกส่วน (Scraping) ค้นหารูปแบบความสัมพันธ์ของข้อมูล (Data Mining) หาประโยชน์จากข้อมูล (Harvesting) ใช้โปรแกรมคอมพิวเตอร์เพื่อนำข้อมูลออกมาใช้งาน (Screen Scraping) รวบรวมข้อมูล (Data Aggregating) และจัดลำดับข้อมูล (Indexing) นอกจากนี้ท่านตกลงว่า ท่านจะไม่ใช้หุ่นยนต์ โปรแกรมคอมพิวเตอร์สไปเดอร์ (Spider) โปรแกรมคอมพิวเตอร์สแครบเปอร์ (Scraper) หรือวิธีการอัตโนมัติอื่นใดในการเข้าถึงเว็บไซต์หรือฐานข้อมูลเพื่อประโยชน์ใดๆ โดยไม่ได้รับอนุญาตเป็นลายลักษณ์อักษรจากเจ้าของโปรแกรมก่อน\n\n " +
                "การยุติบริการ \n\tท่านอาจยุติบริการในเวลาใดก็ได้และไม่จำเป็นต้องมีเหตุผลใดๆ แต่ท่านมีหน้าที่จะต้องแสดงความประสงค์ในการยุติบริการให้เจ้าของโปรแกรม ทราบด้วย\n\tเจ้าของโปรแกรม มีสิทธิที่จะขัดขวางการเข้าใช้บริการและตัดการเชื่อมต่อการใช้บริการของท่านได้ไม่ว่าในเวลาใดและไม่ว่าด้วยเหตุผลใดตามที่เจ้าของโปรแกรม เห็นสมควรแต่เพียงฝ่ายเดียว นอกจากนี้เจ้าของโปรแกรม มีสิทธิที่จะแลกเปลี่ยนข้อมูลการใช้บริการของท่านกับบุคคลภายนอกได้ในกรณีดังต่อไปนี้" +
                "\n\tถ้าท่านมีส่วนร่วมในการกระทำที่ก่อหรืออาจจะก่อให้เกิดอัตรายหรือเสียหายแก่เจ้าของโปรแกรม บุคคลภายนอก ซึ่งรวมถึงผู้ใช้บริการรายอื่น ผู้ที่เป็นคู่ค้ากับเจ้าของโปรแกรม หรือผู้ที่เป็นพันธมิตรกับเจ้าของโปรแกรม \n\nถ้าท่านละเมิดเงื่อนไขการใช้บริการนี้\n\n\tหากเกิดกรณีดังกล่าวขึ้น เจ้าของโปรแกรม จะไม่แจ้งให้ท่านทราบถึงการปิดบัญชีผู้ใช้บริการของท่าน");
        }
    }
}
