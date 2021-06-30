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
using System.Diagnostics;

namespace Gym_Management_System
{
    public partial class Addstaff : UserControl
    {
        public int staffmem_id;
        public string staffmem_imgpath;
        public Addstaff()
        {
            InitializeComponent();
            string idqry = "SELECT * FROM Staff_Member WHERE Id = (SELECT MAX(Id) from Staff_Member ) ";
            DB_Connection dB_Connection = new DB_Connection();
            SqlDataReader dr = dB_Connection.getData(idqry);
            if (dr.HasRows)
            {
                dr.Read();
                string num = dr["Id"].ToString();
                int num_1 = int.Parse(num);
                labelSMID.Text = "Member id : " + (num_1 + 1).ToString();
                staffmem_id = num_1 + 1;



            }
            else
            {
                labelSMID.Text = 1.ToString();
            }
        }

        

        private void btnCancel_Click(object sender, EventArgs e)
        {
             txt_boxNIC.Text = ""; 
             txt_boxName.Text = ""; 
             dateTimePickerDOB.Text = ""; 
             txt_boxJobtype.Text = ""; 
             txt_boxHomeAddress.Text = "";
             txt_boxAddressLivg.Text = "";
             txt_boxPN.Text = "";
             txt_boxPubN.Text = "";
             txt_boxEmergencyContactNme.Text = "";
             txt_boxEmergencyContactPNo.Text = "";
             txt_boxProQuli.Text = "";
             txt_boxGender.Text = "";
             txt_boxMail.Text = "";
        }

        private void pictureBoxstaff_Click(object sender, EventArgs e)
        {
            Add_mem_image_D_Box dialogbox = new Add_mem_image_D_Box();
            dialogbox.id = staffmem_id;
            dialogbox.file_Name = "Staff Member Dp";
            dialogbox.ShowDialog();
            staffmem_imgpath = dialogbox.imgpath;
            if (dialogbox.btnmemaddclick == true)
            {
                if (staffmem_imgpath != null)
                {
                    pictureBoxstaff.Image = new Bitmap(staffmem_imgpath);
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string type = "StaffMember";
            string NIC_No = txt_boxNIC.Text;
            string name = txt_boxName.Text;
            string Dob = this.dateTimePickerDOB.Text;
            string joinDte = this.dateTimePickerJoinedDate.Text;
            string jobType = txt_boxJobtype.Text;
            string homeAdrss = txt_boxHomeAddress.Text;
            string Adrs_Lvg = txt_boxAddressLivg.Text;
            string PrivtNo = txt_boxPN.Text;
            string PubNo = txt_boxPubN.Text;
            string EmergConName = txt_boxEmergencyContactNme.Text;
            string EmergConNo = (txt_boxEmergencyContactPNo.Text);
            string ProQuli = txt_boxProQuli.Text;
            string Gendr = txt_boxGender.Text;
            string Email = txt_boxMail.Text;
            string qrimgpath = Application.StartupPath.Substring(0, Application.StartupPath.Length - 10) + "\\Images\\Staff QR\\" + staffmem_id + "memQR.jpg";
            string qrsubject = (staffmem_id + NIC_No + name).ToString();

            DB_Connection dB_Connection = new DB_Connection();
            string insrtqry = "INSERT INTO Staff_Member (Capture_path,QR_img_path,NIC,Name,Gender,Job_Type,Professional_qualifications,DOB,Joined_date,Address_Living,Mobile_no_public,Mobile_no_private,Home_Address,Emergency_Contact_Name,Emergency_Contact_Number,Email) VALUES('"+staffmem_imgpath+"','"+NIC_No+"','"+name+"','"+Gendr+"','"+jobType+"','"+ProQuli+"','"+Dob+"','"+joinDte+"','"+Adrs_Lvg+"','"+PubNo+"','"+PrivtNo+"','"+homeAdrss+"','"+EmergConName+"','"+EmergConNo+"','"+Email+"' )";
            Console.WriteLine(insrtqry);
            dB_Connection.InsertData(insrtqry);
                QRmailSender qRmailSender = new QRmailSender();
                qRmailSender.qrgen(qrsubject, qrimgpath);
            if (Email != null)
            {
                DialogResult dialog = MessageBox.Show("This Staff member has not provided an Email Address! So, You can print the QR code. Do you want to print it ?", "Print QR Code", MessageBoxButtons.YesNo);
                if (dialog == DialogResult.Yes)
                {
                    string filename = qrimgpath;
                    var p = new Process();
                    p.StartInfo.FileName = filename;
                    p.StartInfo.Verb = "print";
                    p.Start();
                }
            } else
            {
                qRmailSender.Emailgen(name, type);
                qRmailSender.Emailsend(Email, qrimgpath);
            }
                

            
        }
    }
}
