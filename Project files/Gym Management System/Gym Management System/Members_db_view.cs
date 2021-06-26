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
        private string members_qry = "SELECT Id,NICorDL,MemberName,DOB,Gender,Body_Type,Address,Mobile_Number,Health_Condition,Emergency_Contact_Name,Emergency_Contact_Number,Email FROM Members";
        public Members_db_view()
        {
            InitializeComponent();
        }
        private void FillGridView(string qry)
        {

            DB_Connection dB_Connection = new DB_Connection();
            dataGridView_Members.DataSource = dB_Connection.getDataGrid(qry);
        }

        private void Members_db_view_Load(object sender, EventArgs e)
        {
            FillGridView(members_qry);
        }

        private void dataGridView_Members_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Member_view_dialogbox mv_d = new Member_view_dialogbox();
            dataGridView_Members.CurrentRow.Selected = true;
            if (dataGridView_Members.Rows[e.RowIndex].Cells["Member_dp"].Value.ToString()!="")
            {
                mv_d.member_dp_picturebox.Image = new Bitmap(dataGridView_Members.Rows[e.RowIndex].Cells["Member_dp"].Value.ToString());
            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            string data_string = textBox1.Text;
            int data_int;

            try
            {
                data_int = int.Parse(data_string);
            }
            catch (FormatException ex)
            {
                data_int = 0;
            }

            members_qry = "SELECT Id,NICorDL,MemberName,DOB,Gender,Body_Type,Address,Mobile_Number,Health_Condition,Emergency_Contact_Name,Emergency_Contact_Number,Email FROM Members Where NICorDL='"+data_string+"' OR MemberName='"+data_string+"' OR Gender='"+data_string+"' OR Body_Type='"+data_string+"' OR Address='"+data_string+"' OR Mobile_Number='"+data_int+"' OR Health_Condition='"+data_string+"' OR Emergency_Contact_Name='"+data_string+"' OR Emergency_Contact_Number='"+data_int+"' OR Email='"+data_string+"' ";
            Console.WriteLine(members_qry);
            FillGridView(members_qry);
        }
    }
}
