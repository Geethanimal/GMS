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
    public partial class Payments : Form
    {
        public Payments()
        {
            InitializeComponent();
            btnAddFees.BackColor = Color.FromArgb(24, 30, 54);
            this.panel_Add_Fees_form_loader.Controls.Clear();
            AddFees addFees = new AddFees() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            addFees.FormBorderStyle = FormBorderStyle.None;
            this.panel_Add_Fees_form_loader.Controls.Add(addFees);
            addFees.Show();
        }

        private void btnAddFees_Click(object sender, EventArgs e)
        {
            btnAddFees.BackColor = Color.FromArgb(24, 30, 54);
            this.panel_Add_Fees_form_loader.Controls.Clear();
            AddFees addFees = new AddFees() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            addFees.FormBorderStyle = FormBorderStyle.None;
            this.panel_Add_Fees_form_loader.Controls.Add(addFees);
            addFees.Show();
        }

        private void btnAddFees_Leave(object sender, EventArgs e)
        {
            btnAddFees.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void btnAddPackages_Click(object sender, EventArgs e)
        {
            btnAddPackages.BackColor = Color.FromArgb(24, 30, 54);
            this.panel_Add_Fees_form_loader.Controls.Clear();
            AddPackages addpackages = new AddPackages() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            addpackages.FormBorderStyle = FormBorderStyle.None;
            this.panel_Add_Fees_form_loader.Controls.Add(addpackages);
            addpackages.Show();
        }

        private void btnAddPackages_Leave(object sender, EventArgs e)
        {
            btnAddPackages.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void btnPaymentDue_Click(object sender, EventArgs e)
        {
            btnPaymentDue.BackColor = Color.FromArgb(24, 30, 54);
            this.panel_Add_Fees_form_loader.Controls.Clear();
            Payment_Due payment_Due = new Payment_Due() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            payment_Due.FormBorderStyle = FormBorderStyle.None;
            this.panel_Add_Fees_form_loader.Controls.Add(payment_Due);
            payment_Due.Show();
        }

        private void btnPaymentDue_Leave(object sender, EventArgs e)
        {
            btnPaymentDue.BackColor = Color.FromArgb(46, 51, 73);
        }
    }
}
