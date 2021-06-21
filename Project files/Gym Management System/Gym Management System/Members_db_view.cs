using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gym_Management_System
{

    public partial class Members_db_view : Form
    {
        public Members_db_view()
        {
            InitializeComponent();
        }
        private void FillGridView()
        {
            string members_qry = "SELECT * FROM Members";
            DB_Connection dB_Connection = new DB_Connection();
            dataGridView_Members.DataSource = dB_Connection.getDataGrid(members_qry);
        }

        private void Members_db_view_Load(object sender, EventArgs e)
        {
            FillGridView();
        }

        private void dataGridView_Members_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Member_view_dialogbox mv_d = new Member_view_dialogbox();
            dataGridView_Members.CurrentRow.Selected = true;
            mv_d.lbl_mid_v.Text = dataGridView_Members.Rows[e.RowIndex].Cells["Id"].Value.ToString();
            mv_d.lbl_nod_v.Text = dataGridView_Members.Rows[e.RowIndex].Cells["NICorDL"].Value.ToString();
            mv_d.lbl_mn_v.Text = dataGridView_Members.Rows[e.RowIndex].Cells["MemberName"].Value.ToString();
            mv_d.lbl_a_v.Text = dataGridView_Members.Rows[e.RowIndex].Cells["Address"].Value.ToString();
            mv_d.lbl_mnum_v.Text = dataGridView_Members.Rows[e.RowIndex].Cells["Mobile_Number"].Value.ToString();
            mv_d.lbl_dob_v.Text = dataGridView_Members.Rows[e.RowIndex].Cells["DOB"].Value.ToString();
            mv_d.lbl_ecn_v.Text = dataGridView_Members.Rows[e.RowIndex].Cells["Emergency_Contact_Name"].Value.ToString();
            mv_d.lbl_ecnum_v.Text = dataGridView_Members.Rows[e.RowIndex].Cells["Emergency_Contact_Number"].Value.ToString();
            mv_d.lbl_bt_v.Text = dataGridView_Members.Rows[e.RowIndex].Cells["Body_Type"].Value.ToString();
            mv_d.lbl_hc_v.Text = dataGridView_Members.Rows[e.RowIndex].Cells["Health_Condition"].Value.ToString();
            mv_d.ShowDialog();
        }
    }
}
