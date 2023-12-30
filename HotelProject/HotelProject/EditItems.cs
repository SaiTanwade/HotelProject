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
    public partial class EditItems : Form
    {
        SqlConnection con;SqlCommand cmd;SqlDataAdapter da;DataSet ds;SqlCommandBuilder cb;
        DataRow dr;
        string sqlcon,query;int c=0;
        public EditItems()
        {
            InitializeComponent();
        }

        public void dataload()
        {
            
        }

        private void DgVitem_MouseClick(object sender, MouseEventArgs e)
        {
            // MessageBox.Show((DgVitem.Rows.Count).ToString());

        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
               
                e.Handled = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DgVitem_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void DgVitem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //DataGridViewRow r1 = this.DgVitem.Rows[e.RowIndex];
            // if(this.DgVitem.Rows[e.RowIndex])
            // int r = Convert.ToInt32(r1);
            //MessageBox.Show(r1.ToString());
            //txtItem.Text = (ds.Tables[0].Rows[r1][0]).ToString();
            //txtPrice.Text = r1.ToString();


            try
            {
                if (DgVitem.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    DgVitem.CurrentRow.Selected = true;
                    txtItem.Text = DgVitem.Rows[e.RowIndex].Cells[0].FormattedValue.ToString();
                    txtPrice.Text = DgVitem.Rows[e.RowIndex].Cells[1].FormattedValue.ToString();

                }
            }
            catch(Exception a)
            {
                MessageBox.Show("select proper item to edit");
            }

        }

       

        

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(c!=0)
            {
                da.Update(ds, "items");
                MessageBox.Show("updated data saved in database..");
            }
            
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
           
            if (txtItem.Text != "" && txtPrice.Text != "")
            {
                dr = ds.Tables[0].Rows.Find(txtItem.Text);
                dr[0] = txtItem.Text;
                dr[1] = txtPrice.Text;

                ////txtItem.Text = ds.Tables[0].Rows[0][0].ToString();
                ////txtPrice.Text = ds.Tables[0].Rows[0][0].ToString();
                c++;
                btnSave.Enabled = true;
            }
            else
                MessageBox.Show("select item to edit");
        }

        public void EditItems_Load(object sender, EventArgs e)
        {
            sqlcon = "server=LAPTOP-E9UVLEEE;user id=sa; password=123;database=hotelProject;";
            con = new SqlConnection(sqlcon);
            query = "select * from Items";
            cmd = new SqlCommand(query, con);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds, "items");
            da.FillSchema(ds, SchemaType.Source, "items");
            cb = new SqlCommandBuilder(da);
            DgVitem.DataSource = ds.Tables[0];
            btnSave.Enabled = false;
        }
    }
}
