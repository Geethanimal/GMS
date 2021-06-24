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
using QRCoder;
using System.Net;
using System.Net.Mail;

namespace Gym_Management_System
{
    
    public partial class AddMembers : Form
    {
        public int mem_id;
        public string mem_imgpath;
                       
        public AddMembers()
        {
            InitializeComponent();
            
            string idqry = "SELECT * FROM Members WHERE Id = (SELECT MAX(Id) from Members ) ";
            DB_Connection dB_Connection = new DB_Connection();
            SqlDataReader dr = dB_Connection.getData(idqry);
            if (dr.HasRows)
            {
                dr.Read();
                string num = dr["Id"].ToString();
                int num_1 = int.Parse(num);
                labelMID.Text = "Member id : "+(num_1 + 1).ToString();
                mem_id = num_1 + 1;
                


            }
            else
            {
                labelMID.Text = 1.ToString();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Add_mem_image_D_Box dialogbox = new Add_mem_image_D_Box();
            dialogbox.ShowDialog();
            mem_imgpath = dialogbox.imgpath;
            if (dialogbox.btnmemaddclick == true)
            {
                if (mem_imgpath != null)
                {
                    pictureBox1.Image = new Bitmap(mem_imgpath);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string type = "Member";
            string NIC = textBoxNIC.Text;
            string name = textboxName.Text;
            string DOB = dateTimePicker1.Text;
            string Gender = textboxGender.Text;
            string Body_Type = textboxBodyType.Text;
            string Address = richTextBoxAddress.Text;
            string Mobile_Number = textboxMobileNumber.Text;
            string Health_Condition = richTextBoxHealthCondition.Text;
            string Emergency_Contact_Name = textboxEmergencyContactName.Text;
            string Emergency_Contact_Number = (textboxEmergencyContactPhoneNumber.Text);
            string Email = memEmail_tb.Text;

            DB_Connection dB_Connection = new DB_Connection();
            string insertqry = "INSERT INTO Members(NICorDL,MemberName,Gender,Body_Type,Address,Mobile_Number,Health_Condition,Emergency_Contact_Name,Emergency_Contact_Number,Member_dp,Email) VALUES('" + NIC + "','" + name + "','" + Gender + "','" + Body_Type + "','" + Address + "'," + Mobile_Number + ",'" + Health_Condition + "','" + Emergency_Contact_Name + "','" + Emergency_Contact_Number + "','"+mem_imgpath+"','"+Email+"')";
            Console.WriteLine(insertqry);
            dB_Connection.InsertData(insertqry);

            string qrimgpath = Application.StartupPath.Substring(0, Application.StartupPath.Length - 10) + "\\Images\\Member QR\\" + mem_id +"memQR.jpg";
            string qrsubject =(mem_id+NIC+name).ToString();
            QRmailSender qRmailSender = new QRmailSender();
            qRmailSender.qrgen(qrsubject,qrimgpath);
            qRmailSender.Emailgen(name,type);
            qRmailSender.Emailsend(Email,qrimgpath);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBoxNIC.Text = "";
            textboxName.Text = "";
            textboxGender.Text = "";
            textboxBodyType.Text = "";
            richTextBoxAddress.Text = "";
            textboxMobileNumber.Text = "";
            richTextBoxHealthCondition.Text = "";
            textboxEmergencyContactName.Text = "";
            textboxEmergencyContactPhoneNumber.Text = "";
            mem_imgpath = "";
            memEmail_tb.Text = "";
        }

        
    }
}
