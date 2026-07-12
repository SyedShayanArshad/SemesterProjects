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
    public partial class Patient : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-2O42OM4;Initial Catalog=DBProject;Integrated Security=True;Encrypt=False");
        public void populateCBHandleDoctor()
        {
            con.Open();
            string Query = "select DoctorName from Doctor";
            SqlCommand cmd = new SqlCommand(Query, con);
            CBHandleDoctor.Items.Clear();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string DoctorName = reader["DoctorName"].ToString();
                CBHandleDoctor.Items.Add(DoctorName);
            }
            con.Close();
        }
        void populateDGVPatientPaymentDetail()
        {
            DGVPaymentDetail.Rows.Clear();
            con.Open();
            string Query = "select * from Payment where PatientID = " + CBSelectAdmitPatient.SelectedItem;
            SqlCommand cmd = new SqlCommand(Query, con);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                DGVPaymentDetail.Rows.Add(reader["PaymentID"], reader["Amount"], reader["PaymentType"], reader["BankName"], reader["ChequeNo"]);
            }
            con.Close();
        }
        void populateDischargeDGVPatientPaymentDetail()
        {
            DGVPaymentDetail.Rows.Clear();
            con.Open();
            string Query = "select * from Payment where PatientID = " + CBSelectDisPatient.SelectedItem;
            SqlCommand cmd = new SqlCommand(Query, con);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                DGVPaymentDetail.Rows.Add(reader["PaymentID"], reader["Amount"], reader["PaymentType"], reader["BankName"], reader["ChequeNo"]);
            }
            con.Close();
        }
        public void populateCBRoomType()
        {
            con.Open();
            string Query = "SELECT RoomType FROM Room";
            SqlCommand cmd = new SqlCommand(Query, con);
            CBRoomType.Items.Clear();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string roomType = reader["RoomType"].ToString();
                CBRoomType.Items.Add(roomType);
            }
            con.Close();
        }
        public void populateCBAdmitPatient()
        {
            con.Open();
            string Query = "select PatientID from Patient where status = 'Admitted'";
            SqlCommand cmd = new SqlCommand(Query, con);
            CBSelectAdmitPatient.Items.Clear();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int PatientID = (int)reader["PatientID"];
                CBSelectAdmitPatient.Items.Add(PatientID);
            }
            con.Close();
        }        
        public void populateCBDelPatientID()
        {
            con.Open();
            string Query = "select PatientID from Patient";
            SqlCommand cmd = new SqlCommand(Query, con);
            CBDelPatientID.Items.Clear();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int PatientID = (int)reader["PatientID"];
                CBDelPatientID.Items.Add(PatientID);
            }
            con.Close();
        }
        public void populateCBSelectDisPatient()
        {
            con.Open();
            string Query = "select PatientID from Patient where status = 'Discharge'";
            SqlCommand cmd = new SqlCommand(Query, con);
            CBSelectDisPatient.Items.Clear();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int PatientID = (int)reader["PatientID"];
                CBSelectDisPatient.Items.Add(PatientID);
            }
            con.Close();
        }
        public void populateCBDelPatient()
        {
            con.Open();
            string Query = "select PatientID from Patient";
            SqlCommand cmd = new SqlCommand(Query, con);
            CBDelPatientID.Items.Clear();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int PatientID = (int)reader["PatientID"];
                CBDelPatientID.Items.Add(PatientID);
            }
            con.Close();
        }
        public Patient()
        {
            InitializeComponent();
            CBSelectAdmitPatient.SelectedIndexChanged += CBSelectAdmitPatient_SelectedIndexChanged;
            CBDelPatientID.SelectedIndexChanged += CBDelPatientID_SelectedIndexChanged;


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Patient_Load(object sender, EventArgs e)
        {
            populateCBAdmitPatient();
            populateCBHandleDoctor();
            populateCBDelPatient();
            populateCBRoomType();
            populateCBSelectDisPatient();
        }

        private void btnPatientAdd_Click(object sender, EventArgs e)
        {
            if (txtPatientID.Text == "" || txtPatientName.Text == "" || CBGender.SelectedItem == null || txtAge.Text == "" || txtAddress.Text == "" || txtCity.Text == "" || txtMobileNo.Text == "" || txtReferByDoctor.Text == "" || txtDisease.Text == "" || CBHandleDoctor.SelectedItem == null || CBRoomType.SelectedItem == null)
            {
                MessageBox.Show("Missing Information... Fill All Details!!!");
            }
            else
            {
                con.Open();
                string Query = "INSERT INTO Patient VALUES ('" + txtPatientID.Text + "', '" + txtPatientName.Text + "', '" + CBGender.SelectedItem + "', " + txtAge.Text + ", '" + txtAddress.Text + "', '" + txtCity.Text + "', '" + txtMobileNo.Text + "', '" + txtReferByDoctor.Text + "', '" + txtDisease.Text + "', '" + CBHandleDoctor.SelectedItem + "', '" + CBRoomType.SelectedItem + "', 'Admitted')";
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Patient Added Successfully.");
                con.Close();
                txtPatientID.Clear();
                txtPatientName.Clear();
                CBGender.SelectedItem = null;
                txtAge.Clear();
                txtAddress.Clear();
                txtCity.Clear();
                txtMobileNo.Clear();
                txtReferByDoctor.Clear();
                txtDisease.Clear();
                CBHandleDoctor.SelectedItem = null;
                CBRoomType.SelectedItem = null;
            }
        }

        private void btnAddPatient_Click(object sender, EventArgs e)
        {
            PanelDeleteRecord.Hide();
            PanelAddPatient.Show();
            PanelPatientReport.Hide();
        }

        private void btnPatientReport_Click(object sender, EventArgs e)
        {
            PanelDeleteRecord.Hide();
            populateCBAdmitPatient();
            PanelAddPatient.Hide();
            PanelPatientReport.Show();
        }

        private void btnDeleteRecord_Click(object sender, EventArgs e)
        {
            populateCBDelPatientID();
            PanelDeleteRecord.Show();
            PanelPatientReport.Hide();
            PanelAddPatient.Hide();

        }

        private void DGVPaymentDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void PanelPatientReport_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (CBSelectAdmitPatient.SelectedItem == null)
            {
                return;
            }
            int selectedPatientID = (int)CBSelectAdmitPatient.SelectedItem;
            string Query = "select * from Patient where PatientID = " + selectedPatientID;
            string BillQuery = "select * from Bill where PatientID = " + selectedPatientID;
            SqlCommand cmd = new SqlCommand(Query, con);
            SqlCommand Billcmd = new SqlCommand(BillQuery, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                txtgetName.Text = reader["PatientName"].ToString();
                txtGetAge.Text = reader["Age"].ToString();
                txtGetGender.Text = reader["Gender"].ToString();
                txtGetMobile.Text = reader["Mobile"].ToString();
                txtGetAddress.Text = reader["Address"].ToString();
                txtGetReferDr.Text = reader["ReferByDoctor"].ToString();
                txtGetDisease.Text = reader["Disease"].ToString();
                txtGetHandleDr.Text = reader["HandleByDoctor"].ToString();
                txtGetRoomType.Text = reader["RoomType"].ToString();
            }
            reader.Close();
            SqlDataReader Billreader = Billcmd.ExecuteReader();
            while (Billreader.Read())
            {
                txtgetRoomBill.Text = (Billreader["RoomBill"] == DBNull.Value) ? "0" : Billreader["RoomBill"].ToString();
                txtgetDoctorBill.Text = (Billreader["DoctorBill"] == DBNull.Value) ? "0" : Billreader["DoctorBill"].ToString();
                txtgetMedicineBill.Text = (Billreader["MedicineBill"] == DBNull.Value) ? "0" : Billreader["MedicineBill"].ToString();
                txtgetTotalBill.Text = (Billreader["TotalBill"] == DBNull.Value) ? "0" : Billreader["TotalBill"].ToString();
                txtgetPaidBill.Text = (Billreader["PaidBill"] == DBNull.Value) ? "0" : Billreader["PaidBill"].ToString();
                txtgetRemainingBill.Text = (Billreader["RemainingBill"] == DBNull.Value) ? "0" : Billreader["RemainingBill"].ToString();
            }
            Billreader.Close();
            con.Close();
            populateDGVPatientPaymentDetail();
        }

        private void CBSelectAdmitPatient_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void btnHomeClick_Click(object sender, EventArgs e)
        {
            Home obj = new Home();
            obj.Show();
            this.Hide();

        }

        private void btnRoomClick_Click(object sender, EventArgs e)
        {
            AddRoom obj = new AddRoom();
            obj.Show();
            this.Hide();
        }

        private void btnDoctorClick_Click(object sender, EventArgs e)
        {
            Doctor obj = new Doctor();
            obj.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DGVDeletePatient.Rows.Clear();
            if (CBDelPatientID.SelectedItem == null)
            {
                return;
            }
            int selectedPatientID = (int)CBDelPatientID.SelectedItem;
            string Query = "select * from Patient where PatientID = " + selectedPatientID;
            SqlCommand cmd = new SqlCommand(Query, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                DGVDeletePatient.Rows.Add(reader["PatientName"], reader["Gender"], reader["Age"], reader["Address"], reader["HandleByDoctor"]);
            }
            con.Close();
        }

        private void CBDelPatientID_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnDeletePatient_Click(object sender, EventArgs e)
        {
            if (CBDelPatientID.SelectedItem == null)
            {
                MessageBox.Show("Please select a Patient to delete.");
                return;
            }
            int DelPatientID = (int)CBDelPatientID.SelectedItem;
            con.Open();
            string Query = "delete from Patient where PatientID = " + DelPatientID;
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Patient Delete Successfully.");
            con.Close();
            DGVDeletePatient.Rows.Clear();
            CBDelPatientID.SelectedItem = null;
            populateCBDelPatient();
        }

        private void btnBillClick_Click(object sender, EventArgs e)
        {
            Bill obj = new Bill();
            obj.Show();
            this.Hide();
        }

        private void btnPaymentClick_Click(object sender, EventArgs e)
        {
            Payment obj = new Payment();
            obj.Show();
            this.Hide();
        }

        private void btnAdminClick_Click(object sender, EventArgs e)
        {
            Admin obj = new Admin();
            obj.Show();
            this.Hide();
        }

        private void CBSelectDisPatient_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSelectDischarge_Click(object sender, EventArgs e)
        {
            if (CBSelectDisPatient.SelectedItem == null)
            {
                return;
            }
            int selectedPatientID = (int)CBSelectDisPatient.SelectedItem;
            string Query = "select * from Patient where PatientID = " + selectedPatientID;
            string BillQuery = "select * from Bill where PatientID = " + selectedPatientID;
            SqlCommand cmd = new SqlCommand(Query, con);
            SqlCommand Billcmd = new SqlCommand(BillQuery, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                txtgetName.Text = reader["PatientName"].ToString();
                txtGetAge.Text = reader["Age"].ToString();
                txtGetGender.Text = reader["Gender"].ToString();
                txtGetMobile.Text = reader["Mobile"].ToString();
                txtGetAddress.Text = reader["Address"].ToString();
                txtGetReferDr.Text = reader["ReferByDoctor"].ToString();
                txtGetDisease.Text = reader["Disease"].ToString();
                txtGetHandleDr.Text = reader["HandleByDoctor"].ToString();
                txtGetRoomType.Text = reader["RoomType"].ToString();
            }
            reader.Close();
            SqlDataReader Billreader = Billcmd.ExecuteReader();
            while (Billreader.Read())
            {
                txtgetRoomBill.Text = (Billreader["RoomBill"] == DBNull.Value) ? "0" : Billreader["RoomBill"].ToString();
                txtgetDoctorBill.Text = (Billreader["DoctorBill"] == DBNull.Value) ? "0" : Billreader["DoctorBill"].ToString();
                txtgetMedicineBill.Text = (Billreader["MedicineBill"] == DBNull.Value) ? "0" : Billreader["MedicineBill"].ToString();
                txtgetTotalBill.Text = (Billreader["TotalBill"] == DBNull.Value) ? "0" : Billreader["TotalBill"].ToString();
                txtgetPaidBill.Text = (Billreader["PaidBill"] == DBNull.Value) ? "0" : Billreader["PaidBill"].ToString();
                txtgetRemainingBill.Text = (Billreader["RemainingBill"] == DBNull.Value) ? "0" : Billreader["RemainingBill"].ToString();
            }
            Billreader.Close();
            con.Close();
            populateDischargeDGVPatientPaymentDetail();
        }

        private void btnLogoutClick_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }
    }
}
