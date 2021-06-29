using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace Gym_Management_System
{
    public partial class Add_equip_picture_D_Box : Form
    {
        public int equipid;
        public string imgpath,nameplus;
        
        public Add_equip_picture_D_Box()
        {
            InitializeComponent();
            btnadd.Enabled = false;
        }

        OpenFileDialog ofd = new OpenFileDialog();



        private void Browse_Click(object sender, EventArgs e)
        {
            try
            {
                btnadd.Enabled = true;
                ofd.Filter = "jpg files(*.jpg)|*.jpg | png files(*.png)|*.png|All Files(*.*)|*.*";

                if (ofd.ShowDialog() == DialogResult.OK)
                {

                    string img_location = ofd.FileName.ToString();
                    txtbrowseequip.Text = img_location;
                    pictureBox1.ImageLocation = txtbrowseequip.Text;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            try
            {
                if (ofd.CheckFileExists)
                {
                    
                    string path = Application.StartupPath.Substring(0, Application.StartupPath.Length - 10);
                    
                    pictureBox1.Image.Save(path + @"\Images\Equipments\" + equipid + nameplus + ".jpg");
                    imgpath = path + @"\Images\Equipments\" + equipid + nameplus + ".jpg";
                    MessageBox.Show("Image added Successfully!");
                    

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
