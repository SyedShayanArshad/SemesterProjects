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
    public partial class Bill : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-2O42OM4;Initial Catalog=DBProject;Integrated Security=True;Encrypt=False");
        int passPatientID;
        public void populateCBPatientIDBill()
        {
            con.Open();
            string Query = "select PatientID from Patient where status = 'Admitted'";
            SqlCommand cmd = new SqlCommand(Query, con);
            CBPatientIDBill.Items.Clear();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int PatientID = (int)reader["PatientID"];
                CBPatientIDBill.Items.Add(PatientID);
            }
            con.Close();
        }
        public void populateCBBillReport()
        {
            con.Open();
            string Query = "select PatientID from Patient";
            SqlCommand cmd = new SqlCommand(Query, con);
            CBBillReport.Items.Clear();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int PatientID = (int)reader["PatientID"];
                CBBillReport.Items.Add(PatientID);
            }
            con.Close();
        }
        private void UpdateTotalBill()
        {
            int totalRoomBill = string.IsNullOrWhiteSpace(txtTotalRoomBill.Text) ? 0 : Convert.ToInt32(txtTotalRoomBill.Text);
            int totalDoctorBill = string.IsNullOrWhiteSpace(txtTotalDoctorBill.Text) ? 0 : Convert.ToInt32(txtTotalDoctorBill.Text);
            int totalMedicineBill = string.IsNullOrWhiteSpace(txtTotalMedicineBill.Text) ? 0 : Convert.ToInt32(txtTotalMedicineBill.Text);

            txtTotalBill.Text = (totalRoomBill + totalDoctorBill + totalMedicineBill).ToString();
            txtgetRemainingBill.Text = txtTotalBill.Text;
        }
        public Bill()
        {
            InitializeComponent();
            txtTotalDays.TextChanged += txtTotalDays_TextChanged;
            txtgetDoctorBill.TextChanged += txtgetDoctorBill_TextChanged;
            txtgetMedicineBill.TextChanged += txtgetMedicineBill_TextChanged;

        }

        private void Bill_Load(object sender, EventArgs e)
        {
            populateCBPatientIDBill();
            populateCBBillReport();

        }

        private void btnSelectPatientID_Click(object sender, EventArgs e)
        {
            if (CBPatientIDBill.SelectedItem == null)
            {
                MessageBox.Show("Select Patient To Add Bill.");
                return;
            }
            int selectedPatientID = (int)CBPatientIDBill.SelectedItem;
            string Query = "SELECT P.*, R.Price FROM Patient as  P JOIN room as R ON P.RoomType = R.RoomType where P.PatientID = " + selectedPatientID;
            SqlCommand cmd = new SqlCommand(Query, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                txtGetMobile.Text = reader["Mobile"].ToString();
                txtGetAddress.Text = reader["Address"].ToString();
                txtGetReferDr.Text = reader["ReferByDoctor"].ToString();
                txtGetDisease.Text = reader["Disease"].ToString();
                txtGetAge.Text = reader["Age"].ToString();
                txtGetHandleDr.Text = reader["HandleByDoctor"].ToString();
                txtGetRoomType.Text = reader["RoomType"].ToString();
                txtGetGender.Text = reader["Gender"].ToString();
                txtgetName.Text = reader["PatientName"].ToString();
                txtgetRoomBill.Text = reader["Price"].ToString();
            }
            reader.Close();
            con.Close();
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

        private void btnPatientClick_Click(object sender, EventArgs e)
        {
            Patient obj = new Patient();
            obj.Show();
            this.Hide();
        }

        private void btnBillClick_Click(object sender, EventArgs e)
        {
            Bill obj = new Bill();
            obj.Show();
            this.Hide();
        }

        private void btnAddBillDetail_Click(object sender, EventArgs e)
        {
            PanelAddBillDetail.Show();
            PanelBillReport.Hide();
        }

        private void btnBillReport_Click(object sender, EventArgs e)
        {
            PanelBillReport.Show();
            PanelAddBillDetail.Hide();

        }

        private void btnAddBill_Click(object sender, EventArgs e)
        {
            int selectedPatientID = (int)CBPatientIDBill.SelectedItem;
            con.Open();
            string Query = "UPDATE Bill SET RoomBill = @RoomBill, DoctorBill = @DoctorBill, MedicineBill = @MedicineBill, TotalBill = @TotalBill, PaidBill = @PaidBill, RemainingBill = @RemainingBill WHERE PatientID = @PatientID";
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.Parameters.AddWithValue("@RoomBill", txtTotalRoomBill.Text);
            cmd.Parameters.AddWithValue("@DoctorBill", txtTotalDoctorBill.Text);
            cmd.Parameters.AddWithValue("@MedicineBill", txtTotalMedicineBill.Text);
            cmd.Parameters.AddWithValue("@TotalBill", txtTotalBill.Text);
            cmd.Parameters.AddWithValue("@PaidBill", txtgetPaidBill.Text);
            cmd.Parameters.AddWithValue("@RemainingBill", txtgetRemainingBill.Text);
            cmd.Parameters.AddWithValue("@PatientID", selectedPatientID);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Patient Bill Added Successfully.");
        }

        private void txtTotalRoomBill_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTotalDoctorBill_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTotalMedicineBill_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTotalDays_TextChanged(object sender, EventArgs e)
        {
            txtTotalRoomBill.Text = (Convert.ToInt32(txtTotalDays.Text) * Convert.ToInt32(txtgetRoomBill.Text)).ToString();
            UpdateTotalBill();
        }

        private void txtgetDoctorBill_TextChanged(object sender, EventArgs e)
        {
            txtTotalDoctorBill.Text = txtgetDoctorBill.Text;
            UpdateTotalBill();
        }

        private void txtgetMedicineBill_TextChanged(object sender, EventArgs e)
        {
            txtTotalMedicineBill.Text = txtgetMedicineBill.Text;
            UpdateTotalBill();
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void PanelBillReport_Paint(object sender, PaintEventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (CBBillReport.SelectedItem == null)
            {
                MessageBox.Show("Select Patient To View Report.");
                return;
            }
            int selectedPatientID = (int)CBBillReport.SelectedItem;
            string Query = "SELECT * FROM Patient p JOIN Bill b ON p.PatientID = b.PatientID WHERE p.PatientID = '" + selectedPatientID + "'";
            SqlCommand cmd = new SqlCommand(Query, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                txtPAge.Text = reader["Age"].ToString();
                txtPMobile.Text = reader["Mobile"].ToString();
                txtPAddress.Text = reader["Address"].ToString();
                txtPGender.Text = reader["Gender"].ToString();
                txtPName.Text = reader["PatientName"].ToString();
                txtDisease.Text = reader["Disease"].ToString();
                txtRoomType.Text = reader["RoomType"].ToString();
                txtRoomBill.Text = reader["RoomBill"].ToString();
                txtHanDoctor.Text = reader["HandleByDoctor"].ToString();
                txtRefDoctor.Text = reader["ReferByDoctor"].ToString();
                txtMedicineBill.Text = reader["MedicineBill"].ToString();
                txtTBill.Text = reader["TotalBill"].ToString();
                txtDoctorBill.Text = reader["DoctorBill"].ToString();
                txtPaidBill.Text = reader["PaidBill"].ToString();
                txtRemainingBal.Text = reader["RemainingBill"].ToString();
            }
            reader.Close();
            con.Close();
        }

        private void txtPName_TextChanged(object sender, EventArgs e)
        {

        }

        private void CBBillReport_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnPaymentClick_Click(object sender, EventArgs e)
        {
            Payment obj = new Payment();
            obj.Show();
            this.Hide();
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAdminClick_Click(object sender, EventArgs e)
        {
            Admin obj = new Admin();
            obj.Show();
            this.Hide();
        }

        private void CBPatientIDBill_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnLogoutClick_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }
    }
}
