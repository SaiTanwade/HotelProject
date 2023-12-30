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
    public partial class ViewBill : Form
    {
        SqlConnection con;SqlDataReader dr;DataSet ds;SqlDataAdapter da;SqlCommand cmd;
        string sqlcon, query;
        public ViewBill()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //query = "select * from billtrans where billnumber=@q1";
            //cmd = new SqlCommand(query, con);
            //cmd.CommandType = CommandType.Text;
            //cmd.Parameters.AddWithValue("@q1", comboBox1.SelectedItem);
            //con.Open();
            //dr = cmd.ExecuteReader();
            //dr.Read();
            //textBox1.Text = dr[1].ToString();
            //con.Close();

            query = "select * from billtrans where billnumber='"+comboBox1.SelectedItem+"'";
            da = new SqlDataAdapter(query, con);
            ds = new DataSet();
            da.Fill(ds, "billtrans");
            //da.FillSchema(ds, SchemaType.Source, "billtrans");
            //SqlCommandBuilder cb = new SqlCommandBuilder(da);
            dataGridView2.DataSource = ds.Tables[0];

            query = "select * from billmaster where billnumber='" + comboBox1.SelectedItem + "'";
            da = new SqlDataAdapter(query, con);
            ds = new DataSet();
            da.Fill(ds, "billmaster");
            //da.FillSchema(ds, SchemaType.Source, "billmaster");
            //SqlCommandBuilder cb = new SqlCommandBuilder(da);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ViewBill_Load(object sender, EventArgs e)
        {
            sqlcon = "server=LAPTOP-E9UVLEEE;user id=sa; password=123;database=hotelProject;";
            con = new SqlConnection(sqlcon);
            //query = "select * from billmaster";
            //da = new SqlDataAdapter(query, con);
            //ds = new DataSet();
            //da.Fill(ds, "billmaster");
            //da.FillSchema(ds, SchemaType.Source, "billmaster");
            //SqlCommandBuilder cb = new SqlCommandBuilder(da);
            //dataGridView1.DataSource = ds.Tables[0];

            string query2 = "select * from billmaster";
            cmd = new SqlCommand(query2, con);
            cmd.CommandType = CommandType.Text;
            con.Open();
            dr = cmd.ExecuteReader();
            
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0]);
            }

            con.Close();


        }
    }
}
