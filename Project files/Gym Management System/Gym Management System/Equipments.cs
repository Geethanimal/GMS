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
    public partial class Equipments : Form
    {
        public Equipments()
        {
            InitializeComponent();
            addEquipments1.Show();
            equipments_DBView1.Hide();
            modifyequipments1.Hide();

        }

        

        private void btnAddEquipments_Click(object sender, EventArgs e)
        {
            addEquipments1.Show();
            equipments_DBView1.Hide();
            modifyequipments1.Hide();

        }
        private void btnEquipmentsDBview_Click(object sender, EventArgs e)
        {
            equipments_DBView1.Show();
            addEquipments1.Hide();
            modifyequipments1.Hide();
        }

        private void btnModifyEquipments_Click(object sender, EventArgs e)
        {
            modifyequipments1.Show();
            addEquipments1.Hide();
            equipments_DBView1.Hide();
           

        }
    }
}
