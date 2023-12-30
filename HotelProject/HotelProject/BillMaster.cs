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
    public partial class BillMaster : Form
    {
        SqlConnection con;SqlCommand cmd;
        string sqlcon, query;
        public static string bno;
        public BillMaster()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                try
                {

                    query = "insert into billmaster values(@q1,@q2,@q3,@q4,@q5,@q6,@q7,@q8)";
                    cmd = new SqlCommand(query, con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@q1", textBox1.Text);
                    cmd.Parameters.AddWithValue("@q2", dateTimePicker1.Value);
                    cmd.Parameters.AddWithValue("@q3", textBox2.Text);
                    cmd.Parameters.AddWithValue("@q4", textBox3.Text);
                    cmd.Parameters.AddWithValue("@q5", textBox4.Text);
                    cmd.Parameters.AddWithValue("@q6", textBox5.Text);
                    cmd.Parameters.AddWithValue("@q7", textBox6.Text);
                    cmd.Parameters.AddWithValue("@q8", commandata.user1);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    Bill_Trans bt = new Bill_Trans();
                    bt.Show();
                    bno = textBox1.Text;
                    this.Hide();
                }
                catch (Exception E)
                {
                    MessageBox.Show("bill no. already exist try another one..");

                }
            }
            else
            {
                MessageBox.Show("enter bill no..");
            }
                

        }

        private void BillMaster_Load(object sender, EventArgs e)
        {
            sqlcon = "server=LAPTOP-E9UVLEEE;user id=sa; password=123;database=hotelProject;";
            con = new SqlConnection(sqlcon);
            textBox2.Text = Bill_Trans.sum.ToString();
            textBox1.Text = bno;
            if(textBox2.Text!="0")
            {
                textBox5.Focus();
            }else
            {
                textBox1.Focus();
            }



            
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
       

        private void textBox4_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
           // double dis = Convert.ToDouble(textBox5.Text);
           
            //if(textBox5.Text=="")
            //    MessageBox.Show("discount cannot be empty");
           

        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach(Control c in Controls)
            {
                if(c is TextBox)
                {
                    c.Text = "";
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void textBox5_KeyUp(object sender, KeyEventArgs e)
        {
            if (textBox5.Text != "")
            {
                //if (dis > 15)
                //{
                //    MessageBox.Show("discount cannot be greate than 15%");
                //    e.Handled = true;
                //}
                double amount, CGST, GST, Discount, TotalBill;
                //double discount=Convert.ToDouble(textBox3.Text)-((Convert.ToDouble(textBox4.Text)+ (Convert.ToDouble(textBox5.Text)))*0.
                amount = Convert.ToDouble(textBox2.Text);
                CGST = amount * 0.05;
                GST = amount * 0.18;

                TotalBill = (amount + CGST + GST);
                Discount = ((TotalBill) * (Convert.ToDouble(textBox5.Text))) / 100;

                double netBill = TotalBill - Discount;
                textBox3.Text = CGST.ToString();
                textBox4.Text = GST.ToString();
                textBox6.Text = netBill.ToString();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //try
            //{
                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "")
                {
                   
                    query = "update billmaster set billdate=@q2,billamount=@q3,cgst=@q4,gst=@q5,discount=@q6,totalbill=@q7,username=@q8 where billnumber=@q1";
                    cmd = new SqlCommand(query, con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@q1", textBox1.Text);
                    cmd.Parameters.AddWithValue("@q2", dateTimePicker1.Value);
                    cmd.Parameters.AddWithValue("@q3", textBox2.Text);
                    cmd.Parameters.AddWithValue("@q4", textBox3.Text);
                    cmd.Parameters.AddWithValue("@q5", textBox4.Text);
                    cmd.Parameters.AddWithValue("@q6", textBox5.Text);
                    cmd.Parameters.AddWithValue("@q7", textBox6.Text);
                    cmd.Parameters.AddWithValue("@q8", commandata.user1);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("data inserted..");
                }
                else
                    MessageBox.Show("get all data is maendatory");
            //}
            //catch(Exception E)
            //{
            //        MessageBox.Show("Bill already exist");
            //}
        }
    }
}
