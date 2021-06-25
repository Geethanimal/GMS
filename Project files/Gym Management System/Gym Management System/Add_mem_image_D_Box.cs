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
using AForge;
using AForge.Video;
using AForge.Video.DirectShow;

namespace Gym_Management_System
{

    public partial class Add_mem_image_D_Box : Form
    {
        public int id;
        public string imgpath;
        public bool btnmemaddclick;
        public Add_mem_image_D_Box()
        {
            InitializeComponent();

            //declare function for showing camera list in combo box
            getallcameralist();
            btn_Capture.Enabled = false;
            btn_Stop_Camera.Enabled = false;
            btn_add.Enabled = false;

        }
        private FilterInfoCollection CaptureDevice;
        private VideoCaptureDevice VideoCaptureDevice;
        OpenFileDialog ofd = new OpenFileDialog();

        //Function for show and select webcam from combo box
        private void getallcameralist()
        {
            CaptureDevice = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach(FilterInfo Devices in CaptureDevice)
            {
                comboBox_Cameralist.Items.Add(Devices.Name);
            }
        }
        
        private void btn_browse_am_Click(object sender, EventArgs e)
        {
            try
            {
                btn_add.Enabled = true;
                ofd.Filter = "png files(*.png)|*.png|jpg files(*.jpg)|*.jpg|All Files(*.*)|*.*";

                if (ofd.ShowDialog() == DialogResult.OK)
                {

                    string img_location = ofd.FileName.ToString();
                    text_box_img_path.Text = img_location;
                    pictureBox1.ImageLocation = text_box_img_path.Text;
                    
                }
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
           try
            {
                btnmemaddclick = true;
               
                if (ofd.CheckFileExists)
                {
                    
                    string path = Application.StartupPath.Substring(0, Application.StartupPath.Length-10);
                    AddMembers am = new AddMembers();
                    pictureBox1.Image.Save(path + @"\Images\Member DP\" + id + ".jpg");
                    imgpath =path + @"\Images\Member DP\" + id + ".jpg";
                    MessageBox.Show("Image added Successfully!");
                    if (VideoCaptureDevice != null)
                    {
                        VideoCaptureDevice.Stop();
                    }
                   
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                    MessageBox.Show(ex.Message.ToString());   
            }
                
            
        }
        private void Add_mem_image_D_Box_Load(object sender, EventArgs e)
        {
            comboBox_Cameralist.SelectedIndex = 0;
        } 

        private void btn_camstart_Click_1(object sender, EventArgs e)
        {
            try
            {
                VideoCaptureDevice = new VideoCaptureDevice(CaptureDevice[comboBox_Cameralist.SelectedIndex].MonikerString);
                VideoCaptureDevice.NewFrame += new NewFrameEventHandler(NewVideoFrame);
                VideoCaptureDevice.Start();
                btn_Capture.Enabled = true;
                btn_Stop_Camera.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void NewVideoFrame(object sender, NewFrameEventArgs eventArgs)
        {
            pictureBox2.Image = (Bitmap)eventArgs.Frame.Clone();
            
        }

        private void btn_Capture_Click_1(object sender, EventArgs e)
        {
                pictureBox1.Image = (Bitmap)pictureBox2.Image.Clone();
                btn_add.Enabled = true;
            
        }

        private void btn_Stop_Camera_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Image != null)
            {
                VideoCaptureDevice.Stop();
                pictureBox2.Image = null;
                btn_Capture.Enabled = false;
                btn_Stop_Camera.Enabled = false;
            }
            
        }

        
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            if (VideoCaptureDevice != null)
            {
                VideoCaptureDevice.Stop();
                pictureBox2.Image = null;
                btn_Capture.Enabled = false;
                btn_Stop_Camera.Enabled = false;
                this.Close();
            }
            else
            {
                pictureBox2.Image = null;
                btn_Capture.Enabled = false;
                btn_Stop_Camera.Enabled = false;
                this.Close();
            }
        }
    }
}
