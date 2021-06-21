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
    
    public partial class Ft_login_form1 : UserControl
    {
        public string username,companyname;
        public Ft_login_form1()
        {
            InitializeComponent();
        }

        public void inputs_ftl_1()
        {
            username = UserName_tb.Text;
            companyname = CompanyName_tb.Text;
        }
    }
}
