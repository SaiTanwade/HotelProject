using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace HotelProject
{
    public partial class CreateUser : Form
    {
        SqlConnection con;SqlCommand cmd;
        string sqlcon, query;
        public CreateUser()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("enter user name");
                    textBox1.Focus();
                }
                else if (textBox2.Text == "")
                {
                    MessageBox.Show("enter password");
                    textBox2.Focus();
                }
                else if (textBox3.Text == "")
                {
                    MessageBox.Show("enter confirm password");
                    textBox3.Focus();

                }
                else if (textBox2.Text != textBox3.Text)
                {
                    MessageBox.Show("Password not matched..");
                    textBox3.Clear();
                    textBox2.Clear();
                }
                else if (textBox4.Text == "")
                {
                    MessageBox.Show("enter first name");
                    textBox4.Focus();

                }
                else if (textBox5.Text == "")
                {
                    MessageBox.Show("enter last name");
                    textBox5.Focus();
                }
                else if (comboBox1.SelectedIndex < 0)
                {
                    MessageBox.Show("select hint question");
                    comboBox1.Focus();
                }
                else if (textBox6.Text == "")
                {
                    MessageBox.Show("enter Hint Answer");
                    textBox6.Focus();
                }
                else
                {
                    query = "insert into users values(@q1,@q2,@q3,@q4,@q5,@q6)";
                    cmd = new SqlCommand(query, con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@q1", textBox1.Text);
                    cmd.Parameters.AddWithValue("@q2", textBox2.Text);
                    cmd.Parameters.AddWithValue("@q3", textBox4.Text);
                    cmd.Parameters.AddWithValue("@q4", textBox5.Text);
                    cmd.Parameters.AddWithValue("@q5", comboBox1.SelectedItem);
                    cmd.Parameters.AddWithValue("@q6", textBox6.Text);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("account created sucessfully");
                    this.clear();
                }
            }
            catch(Exception E)
            {
                MessageBox.Show("user already exist");
            }
        }
        private void clear()
        {
            foreach (Control c in Controls)
            {
                if (c is TextBox)
                {
                    c.Text = "";
                }
            }
            comboBox1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.clear();
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        public void trim()
        {

            foreach (Control c in Controls)
            {
                if (c is TextBox)
                {
                    c.Text.Trim();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CreateUser_Load(object sender, EventArgs e)
        {
            sqlcon = "server=LAPTOP-E9UVLEEE;user id=sa; password=123;database=hotelProject;";
            con = new SqlConnection(sqlcon);
            this.trim();
        }
    }
}
