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
    public partial class LoginForm : UserControl
    {
        private bool btn_clicked;

        public LoginForm()
        {
            InitializeComponent();
            pw_hint_lbl.Hide();
        }
        private void checklogin(string qry)
        {
            try
            {
                DB_Connection dB_Connection = new DB_Connection();

                DataTable dt = dB_Connection.getDataGrid(qry);
                if (dt.Rows.Count == 1)
                {
                    GMS_1v gMS_1V = new GMS_1v();
                    
                    gMS_1V.Show();
                    ((Form)this.TopLevelControl).Hide();
                }
                else
                {
                    MessageBox.Show("Your Username or Password is incorrect! Check your username , password and try again!");
                    Username_tb_lg.Text = "";
                    Password_tb_lg.Text = "";
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void checkloginbypw()
        {
            string qrypwcheck = "SELECT * from Usertb Where Username='" + Username_tb_lg.Text.Trim() + "' and Password='" + Password_tb_lg.Text.Trim() + "'";
            checklogin(qrypwcheck);
        }

        private void checkloginbypin()
        {
            string qrypincheck = "SELECT * from Usertb Where Username='" + Username_tb_lg.Text.Trim() + "' and Pin_Number='" + Password_tb_lg.Text.Trim() + "'";
            checklogin(qrypincheck);

        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            if (btn_clicked == true)
            {
                checkloginbypin();
            }
            else
            {
                checkloginbypw();

            }
        }

        private void btn_usepinno_Click(object sender, EventArgs e)
        {
            label1.Text = "Enter Pin Number here :";
            btn_clicked = true;
        }

        private void btn_show_pwhint_Click(object sender, EventArgs e)
        {
            try
            {
                DB_Connection dB_Connection = new DB_Connection();
                string qry = "Select Password_Hint From Usertb";
                SqlDataReader dr = dB_Connection.getData(qry);
                if (dr.HasRows)
                {
                    dr.Read();
                    pw_hint_lbl.Text = "Password Hint is : " + dr["Password_Hint"].ToString();
                    pw_hint_lbl.Show();
                }
            }
            catch(SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }




        }
    }
}
