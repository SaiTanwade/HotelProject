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
    public partial class Login : Form
    {
        SqlCommand cmd;
        string query,sqlcon;SqlConnection con;
       // public static string user1,pass;
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("enter user name");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("enter password");
            }
            else
            {
                query = "select count(*) from users where username=@q1 and password=@q2";
                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@q1", textBox1.Text);
                cmd.Parameters.AddWithValue("@q2", textBox2.Text);
                commandata.user1 = textBox1.Text;
                commandata.pass = textBox2.Text;
                
               // MessageBox.Show(commandata.user1);
                con.Open();
                int i= Convert.ToInt32(cmd.ExecuteScalar());
                con.Close();
                if(i!=0)
                {
                    MessageBox.Show("Login sucessfull");
                    MDIForm md = new MDIForm();
                    md.Show();
                    this.Hide();
                }
               
                else
                    MessageBox.Show("invalid user name password");

            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ChangePassword cp = new ChangePassword();
            cp.Show();

        }

        private void Login_Load(object sender, EventArgs e)
        {
            sqlcon = "server=LAPTOP-E9UVLEEE;user id=sa; password=123;database=hotelProject;";
            con = new SqlConnection(sqlcon);
           
        }
    }
}
