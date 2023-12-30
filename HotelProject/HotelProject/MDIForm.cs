using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelProject
{
    public partial class MDIForm : Form
    {
        AddItems ai;EditItems ei;
        public MDIForm()
        {
            InitializeComponent();
        }

        private void addItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ai = new AddItems();
            ai.Show();
        }

        private void MDIForm_Load(object sender, EventArgs e)
        {
           
        }

        private void editItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            ei = new EditItems();
            ei.Show();
        }

        private void deleteItemsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteItems di = new DeleteItems();
            di.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void addNewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateUser cu = new CreateUser();
            cu.Show();
        }

        private void deleteUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteUser du = new DeleteUser();
            du.Show();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePassword cp = new ChangePassword();
            cp.Show();
        }

        private void viewUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewUsers vu = new ViewUsers();
            vu.Show();
        }

        private void newBillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BillMaster bm = new BillMaster();
            bm.Show();
        }

        private void viewBillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewBill vb = new ViewBill();
            vb.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}
