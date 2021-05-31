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
    public partial class GMS_1v : Form
    {
        public GMS_1v()
        {
            InitializeComponent();
            //changing main label name
            Main_label.Text = "Dashboard";
            //Dashboard btn style with nav pannel
            panelnav.Height = btnDashboard.Height;
            panelnav.Top = btnDashboard.Top;
            panelnav.Left = btnDashboard.Left;
            btnDashboard.BackColor = Color.FromArgb(46, 51, 73);

            //Load Dashboard form
            this.form_load_panel.Controls.Clear();
            Dashboard dashboard = new Dashboard() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            dashboard.FormBorderStyle = FormBorderStyle.None;
            this.form_load_panel.Controls.Add(dashboard);
            dashboard.Show();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            //changing main label name
            Main_label.Text = "Dashboard";
            //Dashboard btn style with nav pannel
            panelnav.Height = btnDashboard.Height;
            panelnav.Top = btnDashboard.Top;
            panelnav.Left = btnDashboard.Left;
            btnDashboard.BackColor = Color.FromArgb(46, 51, 73);

            //Load Dashboard form
            this.form_load_panel.Controls.Clear();
            Dashboard dashboard = new Dashboard() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            dashboard.FormBorderStyle = FormBorderStyle.None;
            this.form_load_panel.Controls.Add(dashboard);
            dashboard.Show();
        }

        private void btnDashboard_Leave(object sender, EventArgs e)
        {
            btnDashboard.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnPayments_Click(object sender, EventArgs e)
        {
            //changing main label name
            Main_label.Text = "Payments";
            //Payments btn style with nav panel
            panelnav.Height = btnPayments.Height;
            panelnav.Top = btnPayments.Top;
            panelnav.Left = btnPayments.Left;
            btnPayments.BackColor = Color.FromArgb(46, 51, 73);
            btnDashboard.BackColor = Color.FromArgb(24, 30, 54);

            //Load Payment form
            this.form_load_panel.Controls.Clear();
            Payments payments = new Payments() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            payments.FormBorderStyle = FormBorderStyle.None;
            this.form_load_panel.Controls.Add(payments);
            payments.Show();
        }

        private void btnPayments_Leave(object sender, EventArgs e)
        {
            btnPayments.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnMembers_Click(object sender, EventArgs e)
        {
            panelnav.Height = btnMembers.Height;
            panelnav.Top = btnMembers.Top;
            panelnav.Left = btnMembers.Left;
            btnMembers.BackColor = Color.FromArgb(46, 51, 73);
            btnDashboard.BackColor = Color.FromArgb(24, 30, 54);
            //changing main label name
            Main_label.Text = "Members";
            //Load Members form
            this.form_load_panel.Controls.Clear();
            Members members = new Members() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            members.FormBorderStyle = FormBorderStyle.None;
            this.form_load_panel.Controls.Add(members);
            members.Show();
        }

        private void btnMembers_Leave(object sender, EventArgs e)
        {
            btnMembers.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            panelnav.Height = btnStaff.Height;
            panelnav.Top = btnStaff.Top;
            panelnav.Left = btnStaff.Left;
            btnStaff.BackColor = Color.FromArgb(46, 51, 73);
            btnDashboard.BackColor = Color.FromArgb(24, 30, 54);
            //changing main label name
            Main_label.Text = "Staff";
        }

        private void btnStaff_Leave(object sender, EventArgs e)
        {
            btnStaff.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnEquipments_Click(object sender, EventArgs e)
        {
            panelnav.Height = btnEquipments.Height;
            panelnav.Top = btnEquipments.Top;
            panelnav.Left = btnEquipments.Left;
            btnEquipments.BackColor = Color.FromArgb(46, 51, 73);
            btnDashboard.BackColor = Color.FromArgb(24, 30, 54);
            //changing main label name
            Main_label.Text = "Equipments";
        }

        private void btnEquipments_Leave(object sender, EventArgs e)
        {
            btnEquipments.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnInstructions_Click(object sender, EventArgs e)
        {
            panelnav.Height = btnInstructions.Height;
            panelnav.Top = btnInstructions.Top;
            panelnav.Left = btnInstructions.Left;
            btnInstructions.BackColor = Color.FromArgb(46, 51, 73);
            btnDashboard.BackColor = Color.FromArgb(24, 30, 54);
            //changing main label name
            Main_label.Text = "Instructions";
        }

        private void btnInstructions_Leave(object sender, EventArgs e)
        {
            btnInstructions.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            panelnav.Height = btnSettings.Height;
            panelnav.Top = btnSettings.Top;
            panelnav.Left = btnSettings.Left;
            btnSettings.BackColor = Color.FromArgb(46, 51, 73);
            btnDashboard.BackColor = Color.FromArgb(24, 30, 54);
            //changing main label name
            Main_label.Text = "Settings";
        }

        private void btnSettings_Leave(object sender, EventArgs e)
        {
            btnSettings.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
