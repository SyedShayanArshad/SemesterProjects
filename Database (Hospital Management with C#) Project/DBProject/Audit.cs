using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBProject
{
    public partial class Audit : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-2O42OM4;Initial Catalog=DBProject;Integrated Security=True;Encrypt=False");

        public Audit()
        {
            InitializeComponent();
        }

        private void Audit_Load(object sender, EventArgs e)
        {

        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (CBSelectRecord.SelectedItem == "Doctors")
            {
                con.Open();
                string Query = "Select * from Doctor_Audit";
                SqlCommand cmd = new SqlCommand(Query, con);
                var reader = cmd.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(reader);
                DGVAudit.DataSource = table;
                con.Close();   
            }
            else if (CBSelectRecord.SelectedItem == "Patients")
            {
                con.Open();
                string Query = "Select * from Patient_Audit";
                SqlCommand cmd = new SqlCommand(Query, con);
                var reader = cmd.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(reader);
                DGVAudit.DataSource = table;
                con.Close();
            }            
            else if (CBSelectRecord.SelectedItem == "Rooms")
            {
                con.Open();
                string Query = "Select * from Room_Audit";
                SqlCommand cmd = new SqlCommand(Query, con);
                var reader = cmd.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(reader);
                DGVAudit.DataSource = table;
                con.Close();
            }            
            else if (CBSelectRecord.SelectedItem == "Bills")
            {
                con.Open();
                string Query = "Select * from Bill_Audit";
                SqlCommand cmd = new SqlCommand(Query, con);
                var reader = cmd.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(reader);
                DGVAudit.DataSource = table;
                con.Close();
            }            
            else if (CBSelectRecord.SelectedItem == "Payments")
            {
                con.Open();
                string Query = "Select * from Payment_Audit";
                SqlCommand cmd = new SqlCommand(Query, con);
                var reader = cmd.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(reader);
                DGVAudit.DataSource = table;
                con.Close();
            }
        }
    }
}
