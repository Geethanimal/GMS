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
    public partial class Payment_Due : Form
    {
        
        string payment_due_QRY = "SELECT mem_id,Name,package,due_date,amount From Payment Where paid='0'   ";
        public Payment_Due()
        {
            InitializeComponent();
        }
        private void FillGridView(string qry)
        {
            DB_Connection dB_Connection = new DB_Connection();
            dataGridView1.DataSource = dB_Connection.getDataGrid(qry);
        }

        private void Payment_Due_Load(object sender, EventArgs e)
        {
            FillGridView(payment_due_QRY);
        }
    }
}
