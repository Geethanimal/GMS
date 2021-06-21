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
    public partial class Members : Form
    {
        public Members()
        {
            InitializeComponent();
            btnAddMembers.BackColor = Color.FromArgb(24, 30, 54);
            this.panel_Members.Controls.Clear();
            AddMembers add_Members = new AddMembers() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            add_Members.FormBorderStyle = FormBorderStyle.None;
            this.panel_Members.Controls.Add(add_Members);
            add_Members.Show();
        }

        private void btnAddMembers_Click(object sender, EventArgs e)
        {
            
            this.panel_Members.Controls.Clear();
            AddMembers add_Members = new AddMembers() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            add_Members.FormBorderStyle = FormBorderStyle.None;
            this.panel_Members.Controls.Add(add_Members);
            add_Members.Show();
            btnAddMembers.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnAddMembers_Leave(object sender, EventArgs e)
        {
            btnAddMembers.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void btnMembers_Click(object sender, EventArgs e)
        {
            
            this.panel_Members.Controls.Clear();
            Members_db_view members_Db_View = new Members_db_view() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            members_Db_View.FormBorderStyle = FormBorderStyle.None;
            this.panel_Members.Controls.Add(members_Db_View);
            members_Db_View.Show();
            btnMembers.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnMembers_Leave(object sender, EventArgs e)
        {
            btnMembers.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void btnModifyMembers_Click(object sender, EventArgs e)
        {
            
            this.panel_Members.Controls.Clear();
            Modify_members modify_members = new Modify_members() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            modify_members.FormBorderStyle = FormBorderStyle.None;
            this.panel_Members.Controls.Add(modify_members);
            modify_members.Show();
            btnModifyMembers.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnModifyMembers_Leave(object sender, EventArgs e)
        {
            btnModifyMembers.BackColor = Color.FromArgb(46, 51, 73);
        }
    }
}
