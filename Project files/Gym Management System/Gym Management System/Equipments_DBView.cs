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
    }
}
