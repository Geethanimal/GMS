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
    public partial class Instructions : Form
    {
        public Instructions()
        {
            InitializeComponent();
            addInstructions1.Show();
            workoutplans1.Hide();
            find_Body_type1.Hide();
        }

        private void btnInstructions_Click(object sender, EventArgs e)
        {
            addInstructions1.Show();
            workoutplans1.Hide();
            find_Body_type1.Hide();
        }

        private void btnWork_Out_Plans_Click(object sender, EventArgs e)
        {
            workoutplans1.Show();
            addInstructions1.Hide();
            find_Body_type1.Hide();
        }

        private void btnFind_Body_Type_Click(object sender, EventArgs e)
        {
            find_Body_type1.Show();
            workoutplans1.Hide();
            addInstructions1.Hide();
        }
    }
}
