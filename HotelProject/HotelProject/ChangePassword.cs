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
    public partial class ChangePassword : Form
    {
        SqlConnection con;SqlCommand cmd;
        string query , sqlcon;
        public ChangePassword()
        {
            InitializeComponent();
        }
        //public void validation()
        //{
        //    if(textBox2.Text=="")
        //    {
        //        MessageBox.Show("enter old password");
        //        textBox2.Focus();
        //    }
            
        //    else if (textBox3.Text == "")
        //    {
        //        MessageBox.Show("enter new password");
        //        textBox3.Focus();
        //    }
        //   else if (textBox4.Text == "")
        //    {
        //        MessageBox.Show("Re-enter password");
        //        textBox4.Focus();
        //    }
        //    else if(textBox2.Text!=textBox3.Text)
        //    {
        //        MessageBox.Show("Password not matched");
        //    }
           
        //}
        private void button1_Click(object sender, EventArgs e)
        {
            
            
            if(radioButton1.Checked)
            {
                if (textBox2.Text == "")
                {
                    MessageBox.Show("enter old password");
                    textBox2.Focus();
                }

                else if (textBox3.Text == "")
                {
                    MessageBox.Show("enter new password");
                    textBox3.Focus();
                }
                else if (textBox4.Text == "")
                {
                    MessageBox.Show("Re-enter password");
                    textBox4.Focus();
                }
                else if (textBox3.Text != textBox4.Text)
                {
                    MessageBox.Show("Password not matched");
                    textBox3.Clear();
                    textBox4.Clear();
                }
                else if (textBox2.Text != commandata.pass)
                {
                    MessageBox.Show("invalid Password");
                    textBox2.Clear();
                    textBox2.Focus();


                }
                else 
                {
                    query = "update users set password=@q1 where password=@q2";
                    cmd = new SqlCommand(query, con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@q1", textBox3.Text);
                    cmd.Parameters.AddWithValue("@q2", textBox2.Text);
                    con.Open();
                    int i = cmd.ExecuteNonQuery();
                    con.Close();
                    if (i == 0)
                    {
                        MessageBox.Show("invalid Password");
                        textBox3.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("password updated sucessfully");
                        this.clr();
                    }
                }               

            }

            else if(radioButton2.Checked)
            {



                if (comboBox1.SelectedIndex < 0)
                {
                    MessageBox.Show("select hint question");
                    comboBox1.Focus();
                }
                else if (textBox1.Text == "")
                {
                    MessageBox.Show("Answer is required..");
                    textBox1.Focus();
                }
                else if (textBox3.Text == "")
                {
                    MessageBox.Show("enter new password");
                    textBox3.Focus();
                }
                else if (textBox4.Text == "")
                {
                    MessageBox.Show("Re-enter password");
                    textBox4.Focus();
                }
                else if (textBox3.Text != textBox4.Text)
                {
                    MessageBox.Show("Password not matched");
                    textBox3.Clear();
                    textBox4.Clear();
                }
                //else if (textBox2.Text != commandata.pass)
                //{
                //    MessageBox.Show("invalid Password");
                //    textBox2.Clear();
                //    textBox2.Focus();

                //}

                else
                {

                    query = "Select count(*) from users where hintquestion=@q1 and HintAnswer=@q2";
                    cmd = new SqlCommand(query, con);
                    cmd.CommandType = CommandType.Text;                    
                    cmd.Parameters.AddWithValue("@q1", comboBox1.SelectedItem);
                    cmd.Parameters.AddWithValue("@q2", textBox1.Text);
                    con.Open();
                    int i = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                    if (i == 0)
                    {
                        MessageBox.Show("invalid question and answer");
                        comboBox1.Text = "";
                        textBox1.Text = "";
                    }
                    else
                    {
                        query = "update users set password=@q1 where username=@q2 and HintAnswer=@q3";
                        cmd = new SqlCommand(query, con);
                        cmd.CommandType = CommandType.Text;
                        cmd.Parameters.AddWithValue("@q1", textBox3.Text);
                        cmd.Parameters.AddWithValue("@q2", commandata.user1);
                        cmd.Parameters.AddWithValue("@q3", textBox1.Text);
                        con.Open();
                        int j = cmd.ExecuteNonQuery();
                        con.Close();
                        if (j == 0)
                        {
                            MessageBox.Show("Failed to update");
                        }
                        else
                        {
                            MessageBox.Show("passwoed updated..");
                            this.clr();
                        }
                    }

                }
            }
        }

       public void clr()
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

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked==true)
            {
                label2.Visible = false;
                textBox2.Visible = false;
                label5.Visible = true;
                label6.Visible = true;
                comboBox1.Visible = true;
                textBox1.Visible = true;

            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                label2.Visible = true;
                textBox2.Visible = true;
                label5.Visible = false;
                label6.Visible = false;
                comboBox1.Visible = false;
                textBox1.Visible = false;

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {
            sqlcon = "server=LAPTOP-E9UVLEEE;user id=sa; password=123;database=hotelProject;";
            con = new SqlConnection(sqlcon);
            label5.Visible = false;
            label6.Visible = false;
            comboBox1.Visible = false;
            textBox1.Visible = false;
            textBox1.Text.Trim();
            textBox2.Text.Trim();
            textBox3.Text.Trim();
            textBox4.Text.Trim();
            //foreach (Control c in Controls)
            //{
            //    if (c is TextBox)
            //    {
            //        c.Text.Trim();
            //    }
                //}
            }
    }
}
