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

    public partial class ModifyStaff : UserControl
    {
        public string stffId;
        private string namef, emailf, stffMember_dp_path;
        public ModifyStaff()
        {
            InitializeComponent();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Are you sure that you want to Delete this staff member details ?");
            stffId = textbox_Staff_Id.Text;
            DB_Connection dB_Connection = new DB_Connection();
            string query = "DELETE FROM Members Where Id='" + stffId + "'";
            dB_Connection.Delete(query);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            stffId = textbox_Staff_Id.Text;
            if (stffId != "")
            {
                Add_mem_image_D_Box add_Mem_Image_D_Box_update = new Add_mem_image_D_Box();
                add_Mem_Image_D_Box_update.id = int.Parse(stffId);
                add_Mem_Image_D_Box_update.ShowDialog();
                stffMember_dp_path = add_Mem_Image_D_Box_update.imgpath;

            }
            else
            {
                MessageBox.Show("First you must Enter staff member Id !");
            }
        }

        private void textbox_Staff_Id_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textbox_Staff_Id.Text != "")
                {
                    try
                    {
                        int id = int.Parse(textbox_Staff_Id.Text);
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
                                textboxjobType.Text = da.GetValue(5).ToString();
                                txtbox_hmeaddrss.Text = da.GetValue(12).ToString();
                                TextBoxAddressLiv.Text = da.GetValue(9).ToString();
                                textboxMobileNumberPvt.Text = da.GetValue(11).ToString();
                                textbox_MobNoPub.Text = da.GetValue(10).ToString();
                                textboxEmergencyContactPhoneNumber.Text = da.GetValue(14).ToString();
                                textboxEmergencyContactName.Text = da.GetValue(13).ToString();
                                textbox_Prof_Quali.Text = da.GetValue(6).ToString();
                                text_boxmail.Text = da.GetValue(15).ToString();
                                text_boxgender.Text = da.GetValue(16).ToString();
                                pictureBox1.Image = new Bitmap(da.GetValue(1).ToString());
                                stffMember_dp_path = da.GetValue(17).ToString();
                            }
                            con.Close();
                        }
                        else
                        {
                            MessageBox.Show("There is no Staff member by Id:" + id + "\nTry again with another Id");
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            textbox_Staff_Id.Text = "";
            textBoxNIC.Text = "";
            textboxName.Text = "";
            textboxjobType.Text = "";
            txtbox_hmeaddrss.Text = "";
            TextBoxAddressLiv.Text = "";
            textboxMobileNumberPvt.Text = "";
            textbox_MobNoPub.Text = "";
            textboxEmergencyContactPhoneNumber.Text = "";
            textboxEmergencyContactName.Text = "";
            textbox_Prof_Quali.Text = "";
            text_boxmail.Text = "";
            text_boxgender.Text = "";

        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Are you sure that you want to update this staff member ?");
            stffId = textbox_Staff_Id.Text;
            string NIC = textBoxNIC.Text;
            string name = textboxName.Text;
            string jobtype = textboxjobType.Text;
            string homeaddress = txtbox_hmeaddrss.Text;
            string AddressLiv = TextBoxAddressLiv.Text;
            string MobileNopvt = textboxMobileNumberPvt.Text;
            string MobileNopub = textbox_MobNoPub.Text;
            string EmergConPhnNo = textboxEmergencyContactPhoneNumber.Text;
            string EmergConName = textboxEmergencyContactName.Text;
            string profQuali = textbox_Prof_Quali.Text;
            string mail =text_boxmail.Text;
            string gender = text_boxgender.Text;

            DB_Connection dB_Connection = new DB_Connection();
            string qry = "UPDATE Staff_Member SET  NIC='" + NIC + "', Name='" + name + "' , Gender='" + gender + "' , Job_Type='" + jobtype + "' , Professional_qualification='" + profQuali + "' , Address_living='" + AddressLiv + "' , Mobile_no_public='" + MobileNopub + "' , Mobile_no_private='" + MobileNopvt + "' , Home_Address='" +homeaddress + "',Emergency_Contact_Name='"+EmergConName+"',Emergency_Contact_Number='"+EmergConPhnNo+"', Member_dp='" + stffMember_dp_path + "' , Email = '" + mail + "' WHERE Id='" + stffId + "'";
            dB_Connection.update(qry);

            string qrimgpath = Application.StartupPath.Substring(0, Application.StartupPath.Length - 10) + "\\Images\\Staff QR\\" + stffId + "memQR.jpg";
            string qrsubject = (stffId.ToString() + NIC + name).ToString();
            QRmailSender qRmailSender = new QRmailSender();
            qRmailSender.qrgen(qrsubject, qrimgpath);
            qRmailSender.Emailgen(namef, "member");
            qRmailSender.Emailsend(emailf, qrimgpath);
        }
    }
}
