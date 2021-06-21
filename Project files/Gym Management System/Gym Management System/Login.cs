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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
             DB_Connection dB_Connection = new DB_Connection();
            string qry = "Select * from Usertb";
            DataTable dt = dB_Connection.getDataGrid(qry);

            if (dt.Rows.Count!=0)
            {
                loginForm1.Show();
                
            }
            else
            {
                this.panel1.Controls.Clear();
                ft_wrapper ft_Wrapper = new ft_wrapper() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                ft_Wrapper.FormBorderStyle = FormBorderStyle.None;
                this.panel1.Controls.Add(ft_Wrapper);
                ft_Wrapper.Show();
            }
            
        }

    }
}
