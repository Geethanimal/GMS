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
    public partial class ft_login_form2 : UserControl
    {
        public string password, passwordhint, pinnumber;
        public ft_login_form2()
        {
            InitializeComponent();
        }
        public void input_ftl_2()
        {
            password =Password_tb.Text;
            passwordhint =PasswordHint_tb.Text;
            pinnumber =PinNumber_tb.Text;
        }
    }
}
