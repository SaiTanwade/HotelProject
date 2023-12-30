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
    public partial class Bill_Trans : Form
    {
        SqlConnection con;SqlDataAdapter da;DataSet ds;SqlCommand cmd;SqlDataReader dr;DataRow drow;
        string sqlcon, query;public static double sum = 0;int c=0;
        public Bill_Trans()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BillMaster bm = new BillMaster();
            drow = ds.Tables[0].NewRow();
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                drow[0] = BillMaster.bno;
                drow[1] = comboBox1.SelectedItem;
                drow[2] = textBox1.Text;
                drow[3] = textBox2.Text;
                drow[4] = textBox3.Text;
                ds.Tables[0].Rows.Add(drow);
                comboBox1.Text = "";
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                c++;

            }else
                MessageBox.Show("Add items first");

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            query = "select * from items where items=@q1";
            cmd = new SqlCommand(query, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@q1", comboBox1.SelectedItem);
            con.Open();
            dr = cmd.ExecuteReader();
            dr.Read();
            textBox1.Text = dr[1].ToString();
            con.Close();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                double a, b, c;
                a = Convert.ToDouble(textBox1.Text);
                b = Convert.ToDouble(textBox2.Text);
                c = a * b;
                textBox3.Text = c.ToString();
            }
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (c != 0)
            {
                int i = (ds.Tables[0].Rows.Count) - 1;
                for (int j = 0; j <= i; j++)
                {
                    sum = sum + Convert.ToDouble(ds.Tables[0].Rows[j][4]);
                }

                da.Update(ds, "billtrans");

                MessageBox.Show("data added in data base");
                BillMaster bm = new BillMaster();
                bm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("add atleast one item.");

            }


        }
        private void Bill_Trans_Load(object sender, EventArgs e)
        {
            sqlcon = "server=LAPTOP-E9UVLEEE;user id=sa; password=123;database=hotelProject;";
            con = new SqlConnection(sqlcon);
            query = "select * from billtrans";
            da = new SqlDataAdapter(query, con);
            ds = new DataSet();
           // da.Fill(ds, "billtrans");
            da.FillSchema(ds, SchemaType.Source, "billtrans");
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            dataGridView1.DataSource = ds.Tables[0];

            string query2 = "select * from items";
            cmd = new SqlCommand(query2, con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            dr=cmd.ExecuteReader();
            while(dr.Read())
            {
                comboBox1.Items.Add(dr[0]);
                
            }
            
            con.Close();
            textBox2.Focus();
          //  comboBox1.SelectedIndex = 0;
        }
    }
}
