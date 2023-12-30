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
    public partial class DeleteUser : Form
    {
        SqlConnection con;SqlCommand cmd;SqlDataAdapter da;DataSet ds;
        SqlCommandBuilder cb;DataRow dr;
        string sqlcon, query; string find1;
        public DeleteUser()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                 find1 = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                dr = ds.Tables[0].Rows.Find(find1);
                
            }
            catch(Exception E)
            {
                MessageBox.Show("Select correct user to delete");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if(dr!=null)
                {
                    if (find1.Equals(commandata.user1))
                    {
                        dr.Delete();
                       // da.Update(ds, "users");
                    }
                    else
                        MessageBox.Show("You can not delete another user");
                }
                else
                    MessageBox.Show("Select correct user to delete");

            }
            catch(Exception E)
            {
                MessageBox.Show("Select correct user to delete");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DeleteUser_Load(object sender, EventArgs e)
        {
            sqlcon = "server=LAPTOP-E9UVLEEE;user id=sa; password=123;database=hotelProject;";
            con = new SqlConnection(sqlcon);
            query = "select * from users";
            cmd = new SqlCommand(query, con);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds, "users");
            da.FillSchema(ds, SchemaType.Mapped, "users");
            cb = new SqlCommandBuilder(da);
            dataGridView1.DataSource = ds.Tables[0];
        }
    }
}
