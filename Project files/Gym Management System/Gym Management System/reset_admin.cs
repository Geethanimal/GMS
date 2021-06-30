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
    public partial class reset_admin : UserControl
    {
        private string id;
        public reset_admin()
        {
            InitializeComponent();
            string idqry = "SELECT * FROM Usertb WHERE Id = (SELECT MAX(Id) from Usertb ) ";
            DB_Connection dB_Connection = new DB_Connection();
            SqlDataReader dr = dB_Connection.getData(idqry);
            if (dr.HasRows)
            {
                dr.Read();
                string id = dr["Id"].ToString();
                
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Are you sure that you want to change this?", "Reset Administrator", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                string Username = un_tb.Text;
                string Company_name = cn_tb.Text;
                string Password = p_tb.Text;
                string Password_Hint = ph_tb.Text;
                string Pin_Number = pn_tb.Text;
                string Email = e_tb.Text;

                string qry = "UPDATE Usertb SET Username='" + Username + "', Company_Name='" + Company_name + "', Password='" + Password_Hint + "', Password_Hint='" + Pin_Number + "' WHERE Id='" + id + "'";
                DB_Connection dB_Connection = new DB_Connection();
                dB_Connection.update(qry);
            }
            

        }

    }
}
