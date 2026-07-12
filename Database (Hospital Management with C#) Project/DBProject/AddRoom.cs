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
    namespace DBProject
    {
    public partial class AddRoom : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-2O42OM4;Initial Catalog=DBProject;Integrated Security=True;Encrypt=False");

        void viewData()
        {
            DGVRooms.Rows.Clear();
            con.Open();
            string Query = "select * from Room";
            SqlCommand cmd = new SqlCommand(Query, con);
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {

                DGVRooms.Rows.Add(reader["RoomID"], reader["RoomType"], reader["TotalRoom"], reader["Price"]);
            }
            con.Close();
        }
        public AddRoom()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            uC_Edit_Room_Detail1.Hide();
            userControl11.Show();
        }

        private void btnRoomReports_Click(object sender, EventArgs e)
        {
            uC_Edit_Room_Detail1.Hide();
            userControl11.Hide();
            viewData();
        }

        private void btnEditRoomDetails_Click(object sender, EventArgs e)
        {
            uC_Edit_Room_Detail1.populateCBRoomID();
            uC_Edit_Room_Detail1.Show();
            userControl11.Hide();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void AddRoom_Load(object sender, EventArgs e)
        {
            uC_Edit_Room_Detail1.Hide();
            userControl11.Show();
        }

        private void btnRoomClick_Click(object sender, EventArgs e)
        {

        }

        private void PanelRoomReports_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void userControl11_Load(object sender, EventArgs e)
        {

        }

        private void btnHomeClick_Click(object sender, EventArgs e)
        {
            Home obj = new Home();
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

        private void btnLogoutClick_Click(object sender, EventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Hide();
        }
    }
}
