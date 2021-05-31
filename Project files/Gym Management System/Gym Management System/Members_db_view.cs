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
    public partial class Members_db_view : Form
    {
        public Members_db_view()
        {
            InitializeComponent();
        }
        private void FillGridView()
        {
            string members_qry = "SELECT * FROM Members";
            DB_Connection dB_Connection = new DB_Connection();
            dataGridView_Members.DataSource = dB_Connection.getDataGrid(members_qry);
        }

        private void Members_db_view_Load(object sender, EventArgs e)
        {
            FillGridView();
        }


    }
}
