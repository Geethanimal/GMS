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
    public partial class Find_Body_type : UserControl
    {
        public Find_Body_type()
        {
            InitializeComponent();
        }

        private void btn_find_bodytype_Click(object sender, EventArgs e)
        {
            float weight,waist,chest,shoulder,hip;

            weight = float.Parse(lbl_weight.Text);
            waist = float.Parse(lbl_waist.Text);
            chest = float.Parse(lbl_chest.Text);
            shoulder = float.Parse(lbl_shoulder.Text);
            hip = float.Parse(lbl_hip.Text);

            if (waist>=shoulder||hip>=shoulder)
            {
                lbl_result.Text = "The Body Type is Endomorph";
            }else if (waist < shoulder && hip < shoulder && hip>=waist)
            {
                lbl_result.Text = "The Body Type is Mesoomorph";
            }else if (shoulder<=waist&&hip>=waist)
            {
                lbl_result.Text = "The Body Type is Ectomorph";
            }
        }
    }
}
