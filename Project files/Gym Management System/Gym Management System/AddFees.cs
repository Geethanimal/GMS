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
    public partial class AddFees : Form
    {
        public AddFees()
        {
            InitializeComponent();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (memberid_tb.Text != "")
                {
                    try
                    {
                        
                        int id = int.Parse(memberid_tb.Text);
                        DB_Connection dB_Connection = new DB_Connection();
                        SqlConnection con = new SqlConnection(dB_Connection.connectionstring);
                        con.Open();
                        string qry = "SELECT * FROM Members Where Id=@Id ";
                        SqlCommand cmd = new SqlCommand(qry, con);
                        cmd.Parameters.AddWithValue("@Id", id);
                        SqlDataReader da = dB_Connection.getDatausing_a(cmd);
                        if (da.HasRows)
                        {
                            while (da.Read())
                            {

                                lbl_mname.Text = da.GetValue(2).ToString();
                                lbl_package_name.Text = da.GetValue(15).ToString();
                                string qrypack ="Select * From Packages where Package_Name='"+lbl_package_name.Text+"'" ;
                                DB_Connection dB_Connection1 = new DB_Connection();
                                SqlDataReader da2 = dB_Connection1.getData(qrypack);
                                da2.Read();
                                lbl_fee.Text = da2["Fee"].ToString() ;
                            }
                            con.Close();
                        }
                        else
                        {
                            MessageBox.Show("There is no Staff Member by member id:" + id + "\nTry again with another Id");
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
        }
    }
}
