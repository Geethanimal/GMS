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
    public partial class View_member_image : Form
    {
        public View_member_image(string img_path)
        {
            InitializeComponent();
            pictureBox1.Image = new Bitmap(img_path);
            Console.WriteLine(img_path);
            
        }


    }
}
