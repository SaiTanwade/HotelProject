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
    public partial class ViewUsers : Form
    {
        SqlConnection con;SqlDataAdapter da;DataSet ds;
        string sqlcon, query;
        public ViewUsers()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ViewUsers_Load(object sender, EventArgs e)
        {
            sqlcon = "server=LAPTOP-E9UVLEEE;user id=sa; password=123;database=hotelProject;";
            con = new SqlConnection(sqlcon);
            query = "select * from users";
           // cmd = new SqlCommand(query, con);
            da = new SqlDataAdapter(query, con);
            ds = new DataSet();
            da.Fill(ds, "users");
            dataGridView1.DataSource = ds.Tables[0];
        }
    }
}
