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
    public partial class AddEquipments : UserControl
    {
        public int equip_id;
        public string equip_imgpath1, equip_imgpath2, equip_imgpath3, equip_imgpath4;

        public AddEquipments()
        {
            InitializeComponent();

            string idqry = "SELECT * FROM Equipment WHERE Equip_ID = (SELECT MAX(Equip_ID) from Equipment ) ";
            DB_Connection dB_Connection = new DB_Connection();
            SqlDataReader dr = dB_Connection.getData(idqry);
            if (dr.HasRows)
            {
                dr.Read();
                string num = dr["Equip_ID"].ToString();
                int num_1 = int.Parse(num);
                labelEID.Text = (num_1 + 1).ToString();
                equip_id = num_1 + 1;



            }
            else
            {
                labelEID.Text = "1";
            }

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Add_equip_picture_D_Box add_Equip_Picture_dialogbox = new Add_equip_picture_D_Box();
            add_Equip_Picture_dialogbox.equipid = equip_id;
            add_Equip_Picture_dialogbox.nameplus = "_pic3";
            add_Equip_Picture_dialogbox.ShowDialog();
            equip_imgpath3 = add_Equip_Picture_dialogbox.imgpath;
            if (equip_imgpath3 != null)
            {
                pictureBox3.Image = new Bitmap(equip_imgpath3);
            }

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Add_equip_picture_D_Box add_Equip_Picture_dialogbox = new Add_equip_picture_D_Box();
            add_Equip_Picture_dialogbox.equipid = equip_id;
            add_Equip_Picture_dialogbox.nameplus = "_pic4";
            add_Equip_Picture_dialogbox.ShowDialog();
            equip_imgpath4 = add_Equip_Picture_dialogbox.imgpath;
            if (equip_imgpath4 != null)
            {
                pictureBox4.Image = new Bitmap(equip_imgpath4);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = txtequipname.Text;
            string type = txtequiptype.Text;
            string price = txtamount.Text;

            DB_Connection dB_Connection = new DB_Connection();
            string insertqry = "INSERT INTO Equipment (Equip_Name,Equip_Type,Equip_Amount,Equip_img1,Equip_img2,Equip_img3,Equip_img4) VALUES('" + name+ "','" + type + "','" + price + "','" + equip_imgpath1 + "','" + equip_imgpath2 + "','" + equip_imgpath3 + "','" + equip_imgpath4 + "')";
            Console.WriteLine(insertqry);
            dB_Connection.InsertData(insertqry);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtequipname.Text = "";
            txtequiptype.Text = "";
            txtamount.Text = "";
            equip_imgpath1 ="";
            equip_imgpath2 = "";
            equip_imgpath3 = "";
            equip_imgpath4 = "";

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Add_equip_picture_D_Box add_Equip_Picture_dialogbox = new Add_equip_picture_D_Box();
            add_Equip_Picture_dialogbox.equipid = equip_id;
            add_Equip_Picture_dialogbox.nameplus = "_pic2";
            add_Equip_Picture_dialogbox.ShowDialog();
            equip_imgpath2 = add_Equip_Picture_dialogbox.imgpath;
            if (equip_imgpath2 != null)
            {
                pictureBox2.Image = new Bitmap(equip_imgpath2);
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Add_equip_picture_D_Box add_Equip_Picture_dialogbox = new Add_equip_picture_D_Box();
            add_Equip_Picture_dialogbox.equipid = equip_id;
            add_Equip_Picture_dialogbox.nameplus = "_pic1";
            add_Equip_Picture_dialogbox.ShowDialog();
            equip_imgpath1 = add_Equip_Picture_dialogbox.imgpath;
            
                if (equip_imgpath1 != null)
                {
                    pictureBox1.Image = new Bitmap(equip_imgpath1);
                }
            


        }

        
        
    }
}
