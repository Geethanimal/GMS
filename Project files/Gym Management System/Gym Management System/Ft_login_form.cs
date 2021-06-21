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
    public partial class Ft_login_form : Form
    {
        public string username, companyname;
        public Ft_login_form()
        {
            InitializeComponent();
            
        }

        private void CompanyName_tb_TextChanged(object sender, EventArgs e)
        {
            if (CompanyName_tb.Text != "")
            {
                companyname = CompanyName_tb.Text;
            }
            
        }

        private void UserName_tb_TextChanged(object sender, EventArgs e)
        {
            
            if (UserName_tb.Text != "")
            {
                username = UserName_tb.Text;
            }

        }
    }
}
