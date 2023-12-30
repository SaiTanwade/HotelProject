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
    public partial class DeleteItems : Form
    {
        SqlConnection con;SqlDataAdapter da;DataSet ds; DataRow dr;
        string sqlcon, query;int c = 0;
        public DeleteItems()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
               if( dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    textBox1.Text=dataGridView1.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
                    textBox2.Text=dataGridView1.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();
                }
            }
            catch(Exception E)
            {
                MessageBox.Show("select correct row to delete.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dr = ds.Tables[0].Rows.Find(textBox1.Text);
                if (textBox1.Text != "" && textBox2.Text != "")
                {
                    dr.Delete();
                    textBox1.Clear();
                    textBox2.Clear();

                    c++;
                }
                else
                {
                    MessageBox.Show("select correct row to delete.");
                }
            }
            catch (Exception E)
            {
                MessageBox.Show("something went wrong try again");
            }
        }
            

        private void button2_Click(object sender, EventArgs e)
        {
            if (c != 0)
            {
                da.Update(ds, "items");
                MessageBox.Show("data saved in data base");
            }
            else
            {
                MessageBox.Show("their is no modification in datatable");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DeleteItems_Load(object sender, EventArgs e)
        {
            sqlcon = "server=LAPTOP-E9UVLEEE;user id=sa; password=123;database=hotelProject;";
            con = new SqlConnection(sqlcon);
            query = "select * from items";
            da = new SqlDataAdapter(query, con);
            ds = new DataSet();
            da.Fill(ds, "items");
            da.FillSchema(ds, SchemaType.Source, "items");
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            dataGridView1.DataSource = ds.Tables[0];
        }
    }
}
