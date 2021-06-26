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
    public partial class Staff_DB_view : UserControl
    {
        private string Staffmem_qry = "SELECT Id,NIC,Name,Job_Type,Professional_qualifications,DOB,Joined_date,Address_living,Mobile_no_public,Mobile_no_private,Home_address,Emergency_Contact_Name,Emergency_Contact_Number,Email,Gender FROM Staff_Memeber";
        public Staff_DB_view()
        {
            InitializeComponent();
            FillGridView(Staffmem_qry);
        }
        private void FillGridView(string qry)
        {

            DB_Connection dB_Connection = new DB_Connection();
            dataGridView_Staff.DataSource = dB_Connection.getDataGrid(qry);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string data_string = textBox1.Text;
            int data_int;

            try
            {
                data_int = int.Parse(data_string);
            }
            catch (FormatException ex)
            {
                data_int = 0;
            }

            Staffmem_qry = "SELECT Id,NIC,Name,Job_Type,Professional_qualifications,DOB,Joined_date,Address_living,Mobile_no_public,Mobile_no_private,Home_address,Emergency_Contact_Name,Emergency_Contact_Number,Email,Gender FROM Staff_Memeber Where Id='"+data_int+ "' OR NIC='" + data_string + "' OR Name='" + data_string + "' OR Job_Type='" + data_string + "' OR Address_living='" + data_string + "' OR Mobile_no_public='" + data_int + "' OR Mobile_no_private='" + data_int + "' OR Home_address='" + data_string + "' OR Emergency_Contact_Name='" + data_string + "' OR Emergency_Contact_Number='" + data_int + "' OR Email='" + data_string + "' OR Gender='" + data_string + "' ";
            Console.WriteLine(Staffmem_qry);
            FillGridView(Staffmem_qry);
        }
    }
}
