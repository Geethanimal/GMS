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

namespace Gym_Management_System
{
    public partial class Staff_DB_view : UserControl
    {
        //Id,NIC,Name,Job_Type,Professional_qualifications,DOB,Joined_date,Address_living,Mobile_no_public,Mobile_no_private,Home_address,Emergency_Contact_Name,Emergency_Contact_Number,Email,Gender
        private string staffmembers_qry = "SELECT Id,NIC,Name,Job_Type,Professional_qualifications,DOB,Joined_date,Address_living,Mobile_no_public,Mobile_no_private,Home_address,Emergency_Contact_Name,Emergency_Contact_Number,Email,Gender FROM Staff_Member";
        public Staff_DB_view()
        {
            InitializeComponent();
            FillGridView(staffmembers_qry);
        }
        private void FillGridView(string qry)
        {

            DB_Connection dB_Connection = new DB_Connection();
            dataGridView_StaffMembers.DataSource = dB_Connection.getDataGrid(qry);
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

            staffmembers_qry = "SELECT Id,NIC,Name,Job_Type,Professional_qualifications,DOB,Joined_date,Address_living,Mobile_no_public,Mobile_no_private,Home_address,Emergency_Contact_Name,Emergency_Contact_Number,Email,Gender FROM Staff_Member WHERE Id= '" + data_int + "' OR NIC= '" + data_string + "' OR Name= '" + data_string + "' OR Job_Type= '" + data_string + "' OR Professional_qualifications= '" + data_string + "' OR Address_living= '" + data_string + "' OR Mobile_no_public= '" + data_int + "' OR Mobile_no_private= '" + data_int + "' OR Home_address= '" + data_string + "' OR Emergency_Contact_Name = '" + data_string + "' OR Emergency_Contact_Number = '" + data_int + "' OR Email = '" + data_string + "' OR Gender = '" + data_string+"' ";
            Console.WriteLine(staffmembers_qry);
            FillGridView(staffmembers_qry);
        }

        private void dataGridView_StaffMembers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Staff_Member_View_dialogbox smv_d = new Staff_Member_View_dialogbox();
            dataGridView_StaffMembers.CurrentRow.Selected = true;
            
            smv_d.lbl_smid_v.Text = dataGridView_StaffMembers.Rows[e.RowIndex].Cells["Id"].Value.ToString();
            string id = dataGridView_StaffMembers.Rows[e.RowIndex].Cells["Id"].Value.ToString();

            string qry = "Select Capture_path,QR_img_path from Staff_Member Where Id='"+id+"'";
            
            DB_Connection dB_Connection = new DB_Connection();
            SqlDataReader dr = dB_Connection.getData(qry);
            dr.Read();

            string Capture_path = dr["Capture_path"].ToString();
            string QR_img_path = dr["QR_img_path"].ToString();
            

            if (Capture_path != null || Capture_path !="")
            {
                smv_d.Staff_member_dp_picturebox.Image = new Bitmap(Capture_path);
            }

            if (QR_img_path != null)
            {
                smv_d.Staff_member_qr_picturebox.Image = new Bitmap(QR_img_path);
            }

            smv_d.lbl_nod_v.Text = dataGridView_StaffMembers.Rows[e.RowIndex].Cells["NIC"].Value.ToString();
            smv_d.lbl_smn_v.Text = dataGridView_StaffMembers.Rows[e.RowIndex].Cells["Name"].Value.ToString();
            smv_d.lbl_jt_v.Text = dataGridView_StaffMembers.Rows[e.RowIndex].Cells["Job_Type"].Value.ToString();
            smv_d.lbl_pq_v.Text = dataGridView_StaffMembers.Rows[e.RowIndex].Cells["Professional_qualifications"].Value.ToString();
            smv_d.lbl_dob_v.Text = dataGridView_StaffMembers.Rows[e.RowIndex].Cells["DOB"].Value.ToString();
            smv_d.lbl_jd_v.Text = dataGridView_StaffMembers.Rows[e.RowIndex].Cells["Joined_date"].Value.ToString();
            smv_d.lbl_al_v.Text = dataGridView_StaffMembers.Rows[e.RowIndex].Cells["Address_living"].Value.ToString();
            smv_d.lbl_mnpu_v.Text = dataGridView_StaffMembers.Rows[e.RowIndex].Cells["Mobile_no_public"].Value.ToString();
            smv_d.lbl_mnpri_v.Text = dataGridView_StaffMembers.Rows[e.RowIndex].Cells["Mobile_no_private"].Value.ToString();
            smv_d.lbl_ha_v.Text = dataGridView_StaffMembers.Rows[e.RowIndex].Cells["Home_address"].Value.ToString();
            smv_d.lbl_ecnum_v.Text = dataGridView_StaffMembers.Rows[e.RowIndex].Cells["Emergency_Contact_Name"].Value.ToString();
            smv_d.lbl_ecn_v.Text = dataGridView_StaffMembers.Rows[e.RowIndex].Cells["Emergency_Contact_Number"].Value.ToString();
            smv_d.lbl_mail_v.Text = dataGridView_StaffMembers.Rows[e.RowIndex].Cells["Email"].Value.ToString();
            smv_d.lbl_gender_v.Text = dataGridView_StaffMembers.Rows[e.RowIndex].Cells["Gender"].Value.ToString();
            smv_d.ShowDialog();



        }


    }
}
