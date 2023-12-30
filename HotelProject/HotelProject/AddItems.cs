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
    public partial class AddItems : Form
    {
        SqlConnection con;SqlCommand cmd;
        SqlDataAdapter da;DataSet ds;
        string query, sqlcon;
        DataRow dr;int c = 0;
        public AddItems()
        {
            InitializeComponent();
        }

        public void clrdata()
        {
            txtItem.Clear();
            txtPrice.Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string s= Convert.ToString(ds.Tables[0].Rows.Find(txtItem.Text));
           
            if (s!="System.Data.DataRow")
            {
                if (txtItem.Text != "" && txtPrice.Text != "")
                {
                    dr = ds.Tables[0].NewRow();
                    dr[0] = txtItem.Text;
                    dr[1] = txtPrice.Text;
                    ds.Tables[0].Rows.Add(dr);
                    c++;
                    btnSave.Enabled = true;
                    clrdata();
                }
                else
                {
                    MessageBox.Show("both fields are mendatory");
                }
            }
            else
            {
                MessageBox.Show("Item alrady exists..");
            }



        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(c!=0)
            {

                da.Update(ds, "items");
                MessageBox.Show("Data Saved To DataBase..");
            }
           
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(char.IsDigit(e.KeyChar))
            {
                MessageBox.Show("enter only char");
                e.Handled = true;
            }
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                MessageBox.Show("enter only number");
                e.Handled = true;
            }
        }

        private void AddItems_Load(object sender, EventArgs e)
        {
            //EditItems ei = new EditItems();
            //ei.EditItems_Load(sender,e);

            sqlcon = "server=LAPTOP-E9UVLEEE;user id=sa; password=123;database=hotelProject;";
            con = new SqlConnection(sqlcon);
            query = "select * from items";
            cmd = new SqlCommand(query, con);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds, "items");
            da.FillSchema(ds, SchemaType.Source, "items");
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            DgVitem.DataSource = ds.Tables[0];
            btnSave.Enabled = false;

        }
    }
}
