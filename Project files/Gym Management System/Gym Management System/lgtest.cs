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
    public partial class lgtest : Form
    {
        public lgtest()
        {
            InitializeComponent();
            //Load create user profile form
            this.panel1.Controls.Clear();
            lgtest2 ft_Login_Form = new lgtest2() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            ft_Login_Form.FormBorderStyle = FormBorderStyle.None;
            this.panel1.Controls.Add(ft_Login_Form);
            ft_Login_Form.Show();
        }
    }
}
