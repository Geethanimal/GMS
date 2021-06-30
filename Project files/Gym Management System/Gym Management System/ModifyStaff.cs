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
using System.Net;
using System.Net.Mail;

namespace Gym_Management_System
{
    public partial class ModifyStaff : UserControl
    {
        public string Id;
        private string Staff_Member_dp_path,mail_db;

        public ModifyStaff()
        {
            InitializeComponent();
           
        }

        private void textbox_Members_Id_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textbox_Staff_Members_Id.Text != "")
                {
                    try
                    {
                        Id = textbox_Staff_Members_Id.Text;
                        int id = int.Parse(textbox_Staff_Members_Id.Text);
                        DB_Connection dB_Connection = new DB_Connection();
                        SqlConnection con = new SqlConnection(dB_Connection.connectionstring);
                        con.Open();
                        string qry = "SELECT * FROM Staff_Member Where Id=@Id ";
                        SqlCommand cmd = new SqlCommand(qry, con);
                        cmd.Parameters.AddWithValue("@Id", id);
                        SqlDataReader da = dB_Connection.getDatausing_a(cmd);
                        if (da.HasRows)
                        {
                            while (da.Read())
                            {
                                
                                textBoxNIC.Text = da.GetValue(3).ToString();
                                textboxName.Text = da.GetValue(4).ToString();
                                textboxJobType.Text = da.GetValue(5).ToString();
                                txt_boxProQuli.Text = da.GetValue(6).ToString();


                                txt_boxAddressLivg.Text = da.GetValue(9).ToString();
                                txt_boxPN_private.Text = da.GetValue(10).ToString();
                                txt_boxPubN.Text = da.GetValue(11).ToString();
                                home_Address_tb.Text = da.GetValue(12).ToString();
                                txt_boxEmergencyContactNme.Text = da.GetValue(13).ToString();
                                txt_boxEmergencyContactPNo.Text = da.GetValue(14).ToString();
                                txt_boxMail.Text = da.GetValue(15).ToString();
                                mail_db = da.GetValue(15).ToString();
                                txt_boxGender.Text = da.GetValue(16).ToString();

                                if (da.GetValue(1).ToString() != "")
                                {
                                    pictureBox1.Image = new Bitmap(da.GetValue(1).ToString());
                                    Staff_Member_dp_path = da.GetValue(1).ToString();
                                }

                            }
                            con.Close();
                        }
                        else
                        {
                            MessageBox.Show("There is no Staff Member by member id:" + id + "\nTry again with another Id");
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
        }
        private void btn_update_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Are you sure that you want to update this member ?");
            Id = textbox_Staff_Members_Id.Text;
            string NIC_forqr = textBoxNIC.Text;
            string Name_forqr = textboxName.Text;
            string NIC = textBoxNIC.Text;
            string Name = textboxName.Text;
            string JobType = textboxJobType.Text;
            string p_qualifications = txt_boxProQuli.Text;


            string Address_living = txt_boxAddressLivg.Text;
            string PN_private = txt_boxPN_private.Text;
            string PN_public = txt_boxPubN.Text;
            string Home_Address = home_Address_tb.Text;
            string EmergencyContactName = txt_boxEmergencyContactNme.Text;
            string EmergencyContactPN = txt_boxEmergencyContactPNo.Text;
            string Email = txt_boxMail.Text;
            string Gender = txt_boxGender.Text;
            string qrimgpath = Application.StartupPath.Substring(0, Application.StartupPath.Length - 10) + "\\Images\\Member QR\\" + Id + "memQR.jpg";

            DB_Connection dB_Connection = new DB_Connection();
            string query = "UPDATE Staff_Member SET Capture_path ='"+Staff_Member_dp_path+"', QR_img_path='"+qrimgpath+"', NIC = '" + NIC + "', Name = '" + Name + "' , Job_Type='" + JobType + "', Professional_qualifications='" + p_qualifications + "', Address_living='" + Address_living + "', Mobile_no_public='" + PN_public + "', Mobile_no_private='" + PN_private + "', Home_address='" + Email + "', Emergency_Contact_Name='" + EmergencyContactName + "', Emergency_Contact_Number='" + EmergencyContactPN + "', Email='" + Email + "', Gender='" + Gender + "' ";
            dB_Connection.update(query);

            QRmailSender qRmailSender = new QRmailSender();

            if (NIC_forqr!=NIC || Name_forqr != Name || Email != mail_db )
            {
                string qrsubject = (Id.ToString() + NIC + Name).ToString();
                
                qRmailSender.qrgen(qrsubject, qrimgpath);
                qRmailSender.Emailgen(Name, "member");
                qRmailSender.Emailsend(Email, qrimgpath);
            }
            
            

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Are you sure that you want to Delete this member details ?");
            Id = textbox_Staff_Members_Id.Text;
            DB_Connection dB_Connection = new DB_Connection();
            string query = "DELETE FROM Staff_Member Where Id='" + Id + "'";
            dB_Connection.Delete(query);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            textbox_Staff_Members_Id.Text = "";
            textBoxNIC.Text = "";
            textboxName.Text = "";
            textboxJobType.Text = "";
            txt_boxProQuli.Text = "";
            txt_boxAddressLivg.Text = "";
            txt_boxPN_private.Text = "";
            txt_boxPubN.Text = "";
            home_Address_tb.Text = "";
            txt_boxEmergencyContactNme.Text = "";
            txt_boxEmergencyContactPNo.Text = "";
            txt_boxMail.Text = "";
            txt_boxGender.Text = "";
            string qrimgpath = "";
        }

        private void ModifyStaff_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = new Bitmap("E:\\NSBM\\OneDrive - National School of Busness Management\\Projects\\C#\\GMS\\Project files\\Gym Management System\\Gym Management System\\Resources\\avatar.png");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (Id != null)
            {
                Add_mem_image_D_Box dialogbox = new Add_mem_image_D_Box();
                dialogbox.id = int.Parse(Id);
                dialogbox.file_Name = "Staff Member Dp";
                pictureBox1.Image.Dispose();
                dialogbox.ShowDialog();
                Staff_Member_dp_path = dialogbox.imgpath;
                Console.WriteLine(Staff_Member_dp_path);

                if (dialogbox.btnmemaddclick == true)
                {
                    if (Staff_Member_dp_path != null)
                    {
                        pictureBox1.Image = new Bitmap(Staff_Member_dp_path);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please Enter the Id Number!");
            }
            
        }
    }
}
