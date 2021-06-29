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
    public partial class Modifyequipments : UserControl
    {
        public string equipId;
        public string equip_imgpath1, equip_imgpath2, equip_imgpath3, equip_imgpath4;

        private void btnDelete_emod_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Are you sure that you want to Delete this Equipment details ?");
            equipId = txtmodeid.Text;
            DB_Connection dB_Connection = new DB_Connection();
            string query = "DELETE FROM Equipment Where Equip_ID='" + equipId + "'";
            dB_Connection.Delete(query);
        }

        private void txtmodeid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtmodeid.Text != "")
                {
                    try
                    {
                        equipId = txtmodeid.Text;
                        int id = int.Parse(txtmodeid.Text);
                        DB_Connection dB_Connection = new DB_Connection();
                        SqlConnection con = new SqlConnection(dB_Connection.connectionstring);
                        con.Open();
                        string qry = "SELECT * FROM Equipment Where Equip_ID=@Id ";
                        SqlCommand cmd = new SqlCommand(qry, con);
                        cmd.Parameters.AddWithValue("@Id", id);
                        SqlDataReader da = dB_Connection.getDatausing_a(cmd);
                        if (da.HasRows)
                        {
                            while (da.Read())
                            {

                                txtmodename.Text = da.GetValue(1).ToString();
                                txtmodetype.Text = da.GetValue(2).ToString();
                                txtmodeamount.Text = da.GetValue(3).ToString();

                                if (da.GetValue(5).ToString() != null)
                                {
                                    picbmodequip1.Image = new Bitmap(da.GetValue(5).ToString());
                                    equip_imgpath1 = da.GetValue(5).ToString();

                                }
                                if (da.GetValue(6).ToString() != null)
                                {
                                    picbmodequip2.Image = new Bitmap(da.GetValue(6).ToString());
                                    equip_imgpath2 = da.GetValue(6).ToString();

                                }
                                if (da.GetValue(7).ToString() != null)
                                {
                                    picbmodequip3.Image = new Bitmap(da.GetValue(7).ToString());
                                    equip_imgpath3 = da.GetValue(7).ToString();

                                }
                                if (da.GetValue(8).ToString() != null)
                                {
                                    picbmodequip4.Image = new Bitmap(da.GetValue(8).ToString());
                                    equip_imgpath4 = da.GetValue(8).ToString();

                                }



                            }
                            con.Close();
                        }
                        else
                        {
                            MessageBox.Show("There is no Equipment by id:" + id + "\nTry again with another Id");
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

        private void picbmodequip1_Click(object sender, EventArgs e)
        {
            equipId = txtmodeid.Text;
            if (equipId != "")
            {
                Add_equip_picture_D_Box add_equip_Image_D_Box_update = new Add_equip_picture_D_Box();
                add_equip_Image_D_Box_update.equipid = int.Parse(equipId);
                add_equip_Image_D_Box_update.nameplus = "_pic1";
                picbmodequip1.Image.Dispose();
                add_equip_Image_D_Box_update.ShowDialog();
                equip_imgpath1 = add_equip_Image_D_Box_update.imgpath;

                if (equip_imgpath1 != null)
                {
                    picbmodequip1.Image = new Bitmap(equip_imgpath1);
                }
            }
            else
            {
                MessageBox.Show("First you must Enter Equipment Id !");
            }
        }

        private void picbmodequip2_Click(object sender, EventArgs e)
        {
            equipId = txtmodeid.Text;
            if (equipId != "")
            {
                Add_equip_picture_D_Box add_equip_Image_D_Box_update = new Add_equip_picture_D_Box();
                add_equip_Image_D_Box_update.equipid = int.Parse(equipId);
                add_equip_Image_D_Box_update.nameplus = "_pic2";
                picbmodequip2.Image.Dispose();
                add_equip_Image_D_Box_update.ShowDialog();
                equip_imgpath2 = add_equip_Image_D_Box_update.imgpath;

                if (equip_imgpath2 != null)
                {
                    picbmodequip2.Image = new Bitmap(equip_imgpath2);
                }
            }
            else
            {
                MessageBox.Show("First you must Enter Equipment Id !");
            }
        }

        private void picbmodequip3_Click(object sender, EventArgs e)
        {
            equipId = txtmodeid.Text;
            if (equipId != "")
            {
                Add_equip_picture_D_Box add_equip_Image_D_Box_update = new Add_equip_picture_D_Box();
                add_equip_Image_D_Box_update.equipid = int.Parse(equipId);
                add_equip_Image_D_Box_update.nameplus = "_pic3";
                picbmodequip3.Image.Dispose();
                add_equip_Image_D_Box_update.ShowDialog();
                equip_imgpath3 = add_equip_Image_D_Box_update.imgpath;

                if (equip_imgpath3 != null)
                {
                    picbmodequip3.Image = new Bitmap(equip_imgpath3);
                }
            }
            else
            {
                MessageBox.Show("First you must Enter Equipment Id !");
            }
        }

        private void picbmodequip4_Click(object sender, EventArgs e)
        {
            equipId = txtmodeid.Text;
            if (equipId != "")
            {
                Add_equip_picture_D_Box add_equip_Image_D_Box_update = new Add_equip_picture_D_Box();
                add_equip_Image_D_Box_update.equipid = int.Parse(equipId);
                add_equip_Image_D_Box_update.nameplus = "_pic4";
                picbmodequip4.Image.Dispose();
                add_equip_Image_D_Box_update.ShowDialog();
                equip_imgpath4 = add_equip_Image_D_Box_update.imgpath;
                

                if (equip_imgpath4 != null)
                {
                    picbmodequip4.Image = new Bitmap(equip_imgpath4);
                }
            }
            else
            {
                MessageBox.Show("First you must Enter Equipment Id !");
            }
        }

        private void btncancel_emod_Click(object sender, EventArgs e)
        {
            txtmodeid.Text = "";
            txtmodename.Text = "";
            txtmodetype.Text = "";
            txtmodeamount.Text = "";
        }

        public Modifyequipments()
        {
            InitializeComponent();
        }

        private void btnupdate_emod_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Are you sure that you want to update this Equipment ?");
            equipId = txtmodeid.Text;
            string Name= txtmodename.Text;
            string Type = txtmodetype.Text;
            string Amount = txtmodeamount.Text;

            DB_Connection dB_Connection = new DB_Connection();
            string query = "UPDATE Equipment SET Equip_Name='"+Name+ "', Equip_Type='"+Type+"', Equip_Amount='"+Amount+"', Equip_img1='"+ equip_imgpath1 + "',Equip_img2='" + equip_imgpath2 + "',Equip_img3='" + equip_imgpath3 + "',Equip_img4='" + equip_imgpath4 + "' WHERE Equip_ID='" + equipId + "'";
            dB_Connection.update(query);
        }
    }
}
