namespace DBProject
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void btnHomeClick_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Doctor obj = new Doctor();
            obj.Show();
            this.Hide();

        }

        private void btnRoomClick_Click(object sender, EventArgs e)
        {
            AddRoom obj = new AddRoom();
            obj.Show();
            this.Hide();
        }

        private void Home_Load(object sender, EventArgs e)
        {

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
