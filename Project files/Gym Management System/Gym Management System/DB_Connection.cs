using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace Gym_Management_System
{
    class DB_Connection
    {
        public string connectionstring;
        SqlConnection con;
        SqlCommand cmd;
        public DB_Connection()
        {
            try
            {
                
                /*Yusry Connection String*/  connectionstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='E:\GMS\Project files\Gym Management System\GMS_1.0_DB\GMS_1.0v_DB.mdf';Integrated Security=True;Connect Timeout=30";
                /*Geethan Connection String*/ //connectionstring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='E:\NSBM\OneDrive - National School of Busness Management\Projects\C#\GMS\Project files\Gym Management System\GMS_1.0_DB\GMS_1.0v_DB.mdf';Integrated Security=True;Connect Timeout=30";
                con = new SqlConnection(connectionstring);
                con.Open();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        public void InsertData(String query)
        {
            try
            {
                cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Inserted Data Successfully");
                cmd.Dispose();
                con.Close();

            }
            catch (SqlException e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        public void update(String query)
        {
            try
            {
                cmd = new SqlCommand(query,con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Updated Successfully!");
                cmd.Dispose();
                con.Close();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.ToString());
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        public void Delete(String query)
        {
            try
            {
                cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data deleted Successfully!");
                cmd.Dispose();
                con.Close();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.ToString());
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
        public SqlDataReader getData(String query)
        {
            SqlDataReader dr;
            try
            {
                cmd = new SqlCommand(query, con);
                dr = cmd.ExecuteReader();
                cmd.Dispose();
                return dr;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            return null;
        }

        public DataTable getDataGrid(String query)
        {
            DataTable dt;
            SqlDataAdapter adpt = new SqlDataAdapter(query, con);
            dt = new DataTable();
            adpt.Fill(dt);
            dt.Dispose();
            return dt;
        }

        
        public SqlDataReader getDatausing_a(SqlCommand cmd)
        {
            try
            {
                SqlDataReader da = cmd.ExecuteReader();
                cmd.Dispose();
                return da;
            }
            catch(SqlException e)
            {
                MessageBox.Show(e.ToString());
            }
            return null;
        }
        
    }
}
