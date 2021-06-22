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
    public partial class Staff : Form
    {
        public Staff()
        {
            InitializeComponent();
            addstaff1.Show();
            staff_DB_view1.Hide();
            modifyStaff1.Hide();



        }

        private void btnAddStaff_Click(object sender, EventArgs e)
        {
            addstaff1.Show();
            staff_DB_view1.Hide();
            modifyStaff1.Hide();
        }

        private void btnEquipmentsDBview_Click(object sender, EventArgs e)
        {
            staff_DB_view1.Show();
            addstaff1.Hide();
            modifyStaff1.Hide();
        }

        private void btnModifyEquipments_Click(object sender, EventArgs e)
        {
            modifyStaff1.Show();
            staff_DB_view1.Hide();
            addstaff1.Hide();
        }
    }
}
