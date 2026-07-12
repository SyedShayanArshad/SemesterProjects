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
    public partial class Doctor : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-2O42OM4;Initial Catalog=DBProject;Integrated Security=True;Encrypt=False");
        public void populateCBDoctorID()
        {
            con.Open();
            string Query = "select DoctorID from Doctor";
            SqlCommand cmd = new SqlCommand(Query, con);
            CBDoctorID.Items.Clear();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int DoctorID = reader.GetInt32(reader.GetOrdinal("DoctorID"));
                CBDoctorID.Items.Add(DoctorID);
            }
            con.Close();
        }
        void viewData()
        {
            DGVDoctors.Rows.Clear();
            con.Open();
            string Query = "select * from Doctor";
            SqlCommand cmd = new SqlCommand(Query, con);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                DGVDoctors.Rows.Add(reader["DoctorID"], reader["DoctorName"], reader["Speciality"], reader["MobileNo"]);
            }
            con.Close();
        }
        public Doctor()
        {
            InitializeComponent();
            CBDoctorID.SelectedIndexChanged += CBDoctorID_SelectedIndexChanged;
        }

        private void btnEditDoctorDetails_Click(object sender, EventArgs e)
        {
            populateCBDoctorID();
            PanelEditDetails.Show();
            DGVDoctors.Hide();
            PancelAddDoctor.Hide();
        }

        private void Doctor_Load(object sender, EventArgs e)
        {
            PancelAddDoctor.Show();
            populateCBDoctorID();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnDoctorReport_Click(object sender, EventArgs e)
        {
            PanelEditDetails.Hide();
            PancelAddDoctor.Hide();
            DGVDoctors.Show();
            viewData();
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

        private void btnAddDoctor_Click(object sender, EventArgs e)
        {
            DGVDoctors.Hide();
            PanelEditDetails.Hide();
            PancelAddDoctor.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtDoctorID.Text == "" || txtDoctorName.Text == "" || CBSpeciality.SelectedItem == "" || txtMobileNo.Text == "")
            {
                MessageBox.Show("Missing Information...Fill All Details!!!");
            }
            else
            {
                con.Open();
                string Query = "INSERT INTO Doctor VALUES ('" + txtDoctorID.Text + "', '" + txtDoctorName.Text + "', '" + CBSpeciality.SelectedItem + "', '" + txtMobileNo.Text + "')";
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Doctor Added Successfully.");
                con.Close();
                txtDoctorID.Clear();
                txtDoctorName.Clear();
                CBSpeciality.SelectedItem = null;
                txtMobileNo.Clear(); ;
            }
        }

        private void btnDoctorClick_Click(object sender, EventArgs e)
        {

        }

        private void btnDoctorClick_Click_1(object sender, EventArgs e)
        {

        }

        private void CBDoctorID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBDoctorID.SelectedItem == null)
            {
                return;
            }
            int selectedDoctorID = (int)CBDoctorID.SelectedItem;
            string Query = "select DoctorName,Speciality,MobileNo from Doctor where DoctorID = " + selectedDoctorID;
            SqlCommand cmd = new SqlCommand(Query, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                txtDName.Text = reader["DoctorName"].ToString();
                CBDSpeciality.SelectedItem = reader["Speciality"].ToString();
                txtMobile.Text = reader["MobileNo"].ToString();
            }
            con.Close();
        }

        private void DGVDoctors_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void PancelAddDoctor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PancelAddDoctor_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void CBDSpeciality_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void PanelEditDetails_Paint(object sender, PaintEventArgs e)
        {

        }



        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (CBDoctorID.SelectedItem == null)
            {
                MessageBox.Show("Please select a Doctor to Update.");
                return;
            }
            con.Open();
            string Query = "UPDATE Doctor SET DoctorName = '" + txtDName.Text + "', Speciality = '" + CBDSpeciality.SelectedItem + "', MobileNo = '" + txtMobile.Text + "' WHERE DoctorID = " + CBDoctorID.SelectedItem;
            SqlCommand cmd = new SqlCommand(Query, con);
            int rowsAffected = cmd.ExecuteNonQuery();
            MessageBox.Show("Doctor Modified Successfully.");
            txtDName.Clear();
            CBDSpeciality.SelectedItem = null;
            txtMobile.Clear();
            con.Close();
            CBDoctorID.SelectedItem = null;
            populateCBDoctorID();

        }
        private void DGVDoctors_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (CBDoctorID.SelectedItem == null)
            {
                MessageBox.Show("Please select a Doctor to delete.");
                return;
            }
            int selectedDoctorID = (int)CBDoctorID.SelectedItem;
            con.Open();
            string Query = "delete from Doctor where DoctorID = " + selectedDoctorID;
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Doctor Delete Successfully.");
            txtDName.Clear();
            CBDSpeciality.SelectedItem = null;
            txtMobile.Clear();
            con.Close();
            CBDoctorID.SelectedItem = null;
            populateCBDoctorID();

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
    }

}
