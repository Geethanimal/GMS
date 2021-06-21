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
    public partial class ft_wrapper : Form
    {
        public ft_wrapper()
        {
            InitializeComponent();
            /*this.panel1.Controls.Clear();
            Ft_login_form ft_Login_Form = new Ft_login_form() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            ft_Login_Form.FormBorderStyle = FormBorderStyle.None;
            this.panel1.Controls.Add(ft_Login_Form);
            ft_Login_Form.Show();
            btnPrevious.Enabled = false;
            btnLogin.Enabled = false*/
        }

     

        private void button1_Click(object sender, EventArgs e)
        {
            /*this.panel1.Controls.Clear();
            Ft_login_form ft_Login_Form = new Ft_login_form() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            ft_Login_Form.FormBorderStyle = FormBorderStyle.None;
            this.panel1.Controls.Add(ft_Login_Form);
            ft_Login_Form.Show();*/
            btnPrevious.Enabled = false;
            btnLogin.Enabled = false;
            btnNext.Enabled = true;
            userControl11.Show();
            ft_login_form21.Hide();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            
            btnPrevious.Enabled = true;
            btnLogin.Enabled = true;
            btnNext.Enabled = false;
            userControl11.Hide();
            ft_login_form21.Show();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            userControl11.inputs_ftl_1();
            ft_login_form21.input_ftl_2();
            string Username, Company_Name, Password, Password_hint,pin_Number;
            
            Username = userControl11.username ;
            Company_Name = userControl11.companyname;
            Password = ft_login_form21.password;
            Password_hint = ft_login_form21.passwordhint;
            pin_Number = ft_login_form21.pinnumber;

            DB_Connection dB_Connection = new DB_Connection();
            string qry = "INSERT INTO Usertb (Username,Company_Name,Password,Password_hint,Pin_Number) VALUES ('"+Username+"','"+Company_Name+"','"+Password+"','"+Password_hint+"','"+pin_Number+"')";
            string qry2 = "Select * From Usertb";
            dB_Connection.InsertData(qry);
            DataTable dt = dB_Connection.getDataGrid(qry2);
            if (dt.Rows.Count!=0)
            {
                GMS_1v gMS_1V = new GMS_1v();
                gMS_1V.ShowDialog();
                Console.WriteLine(qry);
            }
        }
    }
}
