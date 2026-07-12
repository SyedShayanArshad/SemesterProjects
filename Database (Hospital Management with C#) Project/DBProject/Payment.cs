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
    public partial class Payment : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-2O42OM4;Initial Catalog=DBProject;Integrated Security=True;Encrypt=False");
        int BillID = -1;
        public void populateCBPaymentDetail()
        {
            con.Open();
            string Query = "select PatientID from Patient where status = 'Admitted'";
            SqlCommand cmd = new SqlCommand(Query, con);
            CBPaymentDetail.Items.Clear();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int PatientID = (int)reader["PatientID"];
                CBPaymentDetail.Items.Add(PatientID);
            }
            con.Close();
        }
        public void populateCBPaymentReport()
        {
            con.Open();
            string Query = "select PatientID from Patient";
            SqlCommand cmd = new SqlCommand(Query, con);
            CBPaymentReport.Items.Clear();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int PatientID = (int)reader["PatientID"];
                CBPaymentReport.Items.Add(PatientID);
            }
            con.Close();
        }

        public Payment()
        {
            InitializeComponent();
        }

        private void label_Click(object sender, EventArgs e)
        {

        }

        private void Payment_Load(object sender, EventArgs e)
        {
            populateCBPaymentDetail();
            populateCBPaymentReport();
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

        private void btnSelectAddPayment_Click(object sender, EventArgs e)
        {
            if (CBPaymentDetail.SelectedItem == null)
            {
                MessageBox.Show("Select Patient To View Report.");
                return;
            }
            int selectedPatientID = (int)CBPaymentDetail.SelectedItem;
            string Query = "SELECT * FROM Patient p JOIN Bill b ON p.PatientID = b.PatientID WHERE p.PatientID = '" + selectedPatientID + "'";
            SqlCommand cmd = new SqlCommand(Query, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                BillID = (int)reader["BillID"];
                txtPAge.Text = reader["Age"].ToString();
                txtPMobile.Text = reader["Mobile"].ToString();
                txtPAddress.Text = reader["Address"].ToString();
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
        private void SetChequePanelEnabled(bool enabled)
        {
            ChequePanel.Enabled = enabled;
            Color color = enabled ? SystemColors.ControlText : SystemColors.GrayText;
            foreach (Control control in ChequePanel.Controls)
            {
                control.Enabled = enabled;
                control.ForeColor = color;
                control.BackColor = enabled ? SystemColors.Window : SystemColors.Control;
            }
        }
        private void ChequePanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PaymentPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            //Bank textbox
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            //Cheque textbox

        }

        private void CBPaymentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isChequeSelected = CBPaymentType.SelectedItem != null && CBPaymentType.SelectedItem.ToString() == "Cheque";
            SetChequePanelEnabled(isChequeSelected);
        }

        private void btnAddPayment_Click(object sender, EventArgs e)
        {
            con.Open();
            string query = "INSERT INTO Payment VALUES ( @BillID, @PatientID, @Amount, @PaymentType, @ChequeNo, @BankName)";
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@BillID", BillID);
            cmd.Parameters.AddWithValue("@PatientID", CBPaymentDetail.SelectedItem);
            cmd.Parameters.AddWithValue("@Amount", txtAmount.Text);
            cmd.Parameters.AddWithValue("@PaymentType", CBPaymentType.SelectedItem);
            cmd.Parameters.AddWithValue("@ChequeNo", txtChequeNo.Text);
            cmd.Parameters.AddWithValue("@BankName", txtBankName.Text);
            txtPaidBill.Text = (Convert.ToInt32(txtPaidBill.Text) + Convert.ToInt32(txtAmount.Text)).ToString();
            txtRemainingBal.Text = (Convert.ToInt32(txtRemainingBal.Text) - Convert.ToInt32(txtAmount.Text)).ToString();
            cmd.ExecuteNonQuery();
            con.Close();
            con.Open();
            string updateBillQuery = "UPDATE Bill SET PaidBill = @PaidBill, RemainingBill = @RemainingBill WHERE BillID = @BillID";
            SqlCommand updateBillCmd = new SqlCommand(updateBillQuery, con);
            updateBillCmd.Parameters.AddWithValue("@PaidBill", txtPaidBill.Text);
            updateBillCmd.Parameters.AddWithValue("@RemainingBill", txtRemainingBal.Text);
            updateBillCmd.Parameters.AddWithValue("@BillID", BillID);
            updateBillCmd.ExecuteNonQuery();
            con.Close();
        }

        private void btnAddPaymentDetail_Click(object sender, EventArgs e)
        {
            PanelPaymentDetail.Show();
            PanelPaymentReport.Hide();
        }

        private void btnPaymentReport_Click(object sender, EventArgs e)
        {
            PanelPaymentReport.Show();
            PanelPaymentDetail.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DGVPaymentRecord.Rows.Clear();
            con.Open();
            string Query = "select * from Payment As P join Bill on Bill.BillID = P.BillID where Bill.PatientID = " + CBPaymentReport.SelectedItem;
            SqlCommand cmd = new SqlCommand(Query, con);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                DGVPaymentRecord.Rows.Add(reader["Amount"], reader["PaymentType"], reader["BankName"], reader["ChequeNo"], reader["TotalBill"], reader["PaidBill"], reader["RemainingBill"]);
            }
            con.Close();
        }

        private void btnAdminClick_Click(object sender, EventArgs e)
        {
            Admin obj = new Admin();
            obj.Show();
            this.Hide();
        }

        private void btnLogoutClick_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }
    }
}
