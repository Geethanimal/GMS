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
    public partial class AddPackages : Form
    {
        private string qry = "Select Package_Name,Duration,Fee From Packages";
        public AddPackages()
        {
            InitializeComponent();
            FillGridView(qry);
        }

        private void FillGridView(string qry)
        {
            string members_qry = "SELECT * FROM Members";
            DB_Connection dB_Connection = new DB_Connection();
            dataGridViewpackages.DataSource = dB_Connection.getDataGrid(qry);
        }

        private void btnAP_Add_Click(object sender, EventArgs e)
        {
            string package_name, duration, fee, qry;
            package_name = Package_Name_tb.Text;
            duration = Duration_tb.Text;
            fee = Fee_tb.Text;
            qry = "INSERT INTO Packages(Package_Name,Duration,Fee) VALUES('"+package_name+"','"+duration+"','"+fee+"')";
            DB_Connection dB_Connection = new DB_Connection();
            DialogResult dialog = MessageBox.Show("Are you sure that you want to add this package?", "Add Package", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                dB_Connection.InsertData(qry);
            }
            
        }

    }
}
