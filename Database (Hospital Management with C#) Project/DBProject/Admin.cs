using System;
using System.Collections;
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
    public partial class Admin : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-2O42OM4;Initial Catalog=DBProject;Integrated Security=True;Encrypt=False");

        public void populateCBPatientRoomShift()
        {
            con.Open();
            string Query = "select PatientID from Patient where status = 'Admitted'";
            SqlCommand cmd = new SqlCommand(Query, con);
            CBPatientRoomShift.Items.Clear();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int PatientID = (int)reader["PatientID"];
                CBPatientRoomShift.Items.Add(PatientID);
            }
            con.Close();
        }
        public void populateCBDischargePID()
        {
            con.Open();
            string Query = "select PatientID from Patient where status = 'Admitted'";
            SqlCommand cmd = new SqlCommand(Query, con);
            CBDischargePID.Items.Clear();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int PatientID = (int)reader["PatientID"];
                CBDischargePID.Items.Add(PatientID);
            }
            con.Close();
        }
        public void populateCBPRoomType()
        {
            con.Open();
            string Query = "select RoomType from Room";
            SqlCommand cmd = new SqlCommand(Query, con);
            CBRoomTypes.Items.Clear();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string RoomType = reader["RoomType"].ToString();
                CBRoomTypes.Items.Add(RoomType);
            }
            con.Close();
        }

        public Admin()
        {
            InitializeComponent();
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            populateCBPatientRoomShift();
            populateCBPRoomType();
            populateCBDischargePID();
        }

        private void btnSelectPatientID_Click(object sender, EventArgs e)
        {

            if (CBPatientRoomShift.SelectedItem == null)
            {
                MessageBox.Show("Select Patient To Shift Room.");
                return;
            }
            int selectedPatientID = (int)CBPatientRoomShift.SelectedItem;
            string Query = "SELECT Patient.*, R.Price FROM Patient JOIN Room AS R ON Patient.RoomType = R.RoomType WHERE PatientID = @PatientID";
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.Parameters.AddWithValue("@PatientID", CBPatientRoomShift.SelectedItem);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                txtGetMobile.Text = reader["Mobile"].ToString();
                txtGetAddress.Text = reader["Address"].ToString();
                txtGetReferDr.Text = reader["ReferByDoctor"].ToString();
                txtGetDisease.Text = reader["Disease"].ToString();
                txtGetAge.Text = reader["Age"].ToString();
                txtCurrentRoomRate.Text = reader["Price"].ToString();
                txtGetHandleDr.Text = reader["HandleByDoctor"].ToString();
                txtGetRoomType.Text = reader["RoomType"].ToString();
                txtCurrentRoomType.Text = reader["RoomType"].ToString();
                txtGetGender.Text = reader["Gender"].ToString();
                txtgetName.Text = reader["PatientName"].ToString();
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (CBRoomTypes.SelectedItem == null)
            {
                MessageBox.Show("Please select a room to Update.");
                return;
            }
            con.Open();
            string Query = "UPDATE Patient SET RoomType = '" + CBRoomTypes.SelectedItem + "' WHERE PatientID = " + CBPatientRoomShift.SelectedItem;
            SqlCommand cmd = new SqlCommand(Query, con);
            int rowsAffected = cmd.ExecuteNonQuery();
            MessageBox.Show("Room Shifted Successfully.");
            con.Close();
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CBDischargePID_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSelectDischargeID_Click(object sender, EventArgs e)
        {
            if (CBDischargePID.SelectedItem == null)
            {
                MessageBox.Show("Select Patient To Shift Room.");
                return;
            }
            int selectedPatientID = (int)CBDischargePID.SelectedItem;
            string Query = "select * from Patient Join Bill on Bill.PatientID = Patient.PatientID where Patient.PatientID = @PatientID;";
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.Parameters.AddWithValue("@PatientID", CBDischargePID.SelectedItem);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                txtPName.Text = reader["PatientName"].ToString();
                txtPGender.Text = reader["Gender"].ToString();
                txtPAge.Text = reader["Age"].ToString();
                txtPMobile.Text = reader["Mobile"].ToString();
                txtPAddress.Text = reader["Address"].ToString();
                txtHandleDr.Text = reader["HandleByDoctor"].ToString();
                txtDisease.Text = reader["Disease"].ToString();
                txtReferDr.Text = reader["ReferByDoctor"].ToString();
                txtRoomType.Text = reader["RoomType"].ToString();
                txtRBill.Text = reader["RoomBill"].ToString();
                txtDBill.Text = reader["DoctorBill"].ToString();
                txtMBill.Text = reader["MedicineBill"].ToString();
                txtTBill.Text = reader["TotalBill"].ToString();
                txtPBill.Text = reader["PaidBill"].ToString();
                txtRemainBill.Text = reader["RemainingBill"].ToString();
            }
            reader.Close();
            con.Close();
        }

        private void btnDischargePatient_Click(object sender, EventArgs e)
        {
            PanelDischargePatient.Show();
            PanelAddBillDetail.Hide();
        }

        private void btnRoomShifting_Click(object sender, EventArgs e)
        {
            PanelAddBillDetail.Show();
            PanelDischargePatient.Hide();
        }

        private void btnDischarge_Click(object sender, EventArgs e)
        {
            string status = "Null";

            con.Open();
            string Query = "SELECT Status FROM Bill WHERE PatientID = @PatientID";
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.Parameters.AddWithValue("@PatientID", CBDischargePID.SelectedItem);
            cmd.ExecuteNonQuery();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                status = reader["Status"].ToString();
            }
            reader.Close();
            con.Close();
            if (status == "Paid")
            {
                con.Open();
                string UpdateQuery = "update Patient set Status = 'Discharge' where PatientID = " + CBDischargePID.SelectedItem;
                SqlCommand Updatecmd = new SqlCommand(UpdateQuery, con);
                Updatecmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Patient Discharge Successfully.");
                return;
            }
            else
            {
                MessageBox.Show("Clear the Patient Balance before Discharge.");

            }
        }

        private void btnLogoutClick_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }

        private void btnAuditRecord_Click(object sender, EventArgs e)
        {
            Audit obj = new Audit();
            obj.Show();
        }
    }
}
