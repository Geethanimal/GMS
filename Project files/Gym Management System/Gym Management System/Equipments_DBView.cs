using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Gym_Management_System
{
    public partial class Equipments_DBView : UserControl
    {
        private string equipment_qry = "SELECT Equip_ID,Equip_Name,Equip_Type,Equip_Amount,Purchased_Date FROM Equipment";
        public Equipments_DBView()
        {
            InitializeComponent();
            FillGridView(equipment_qry);
        }

        private void FillGridView(string qry)
        {
            
            DB_Connection dB_Connection = new DB_Connection();
            dataGridView_Equipments.DataSource = dB_Connection.getDataGrid(qry);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string data_string = textBox1.Text;
            int data_int;

            try
            {
                data_int = int.Parse(data_string);
            }
            catch(FormatException ex)
            {
                data_int = 0;
            }

            equipment_qry = "SELECT Equip_ID,Equip_Name,Equip_Type,Equip_Amount,Purchased_Date FROM Equipment Where Equip_ID='"+data_int+"' OR Equip_Name='"+data_string+"' OR Equip_Type='"+data_string+"' OR Equip_Amount='"+data_string+"'";
            Console.WriteLine(equipment_qry);
            FillGridView(equipment_qry);
        }

        private void dataGridView_Equipments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Equipment_View_dialoguebox eVD = new Equipment_View_dialoguebox();

            dataGridView_Equipments.CurrentRow.Selected = true;
            string id = dataGridView_Equipments.Rows[e.RowIndex].Cells["Equip_ID"].Value.ToString();

            eVD.lbl_eid.Text = dataGridView_Equipments.Rows[e.RowIndex].Cells["Equip_ID"].Value.ToString();
            eVD.lbl_ename.Text = dataGridView_Equipments.Rows[e.RowIndex].Cells["Equip_Name"].Value.ToString();
            eVD.lbl_etype.Text = dataGridView_Equipments.Rows[e.RowIndex].Cells["Equip_Type"].Value.ToString();
            eVD.lbl_eprice.Text = dataGridView_Equipments.Rows[e.RowIndex].Cells["Equip_Amount"].Value.ToString();
            

            string qry = "SELECT Equip_img1,Equip_img2,Equip_img3,Equip_img4 From Equipment Where Equip_ID = '"+id+"' ";
            Console.WriteLine(qry);
            DB_Connection dB_Connection = new DB_Connection();
            SqlDataReader dr = dB_Connection.getData(qry);
            if (dr.HasRows)
            {
                dr.Read();

                string Equip_img1 = dr["Equip_img1"].ToString();
                string Equip_img2 = dr["Equip_img2"].ToString();
                string Equip_img3 = dr["Equip_img3"].ToString();
                string Equip_img4 = dr["Equip_img4"].ToString();

                if (Equip_img1 != null)
                {
                    eVD.equippicbox1.Image = new Bitmap(Equip_img1);
                }
                if (Equip_img2 != null)
                {
                    eVD.equippicbox2.Image = new Bitmap(Equip_img2);
                }
                if (Equip_img3 != null)
                {
                    eVD.equippicbox3.Image = new Bitmap(Equip_img3);
                }
                if (Equip_img4 != null)
                {
                    eVD.equippicbox4.Image = new Bitmap(Equip_img4);
                }

            }

            eVD.ShowDialog();


        }
    }
}
