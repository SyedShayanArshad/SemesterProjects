using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library_Management_System
{
    public partial class StudentPenalty : Form
    {
        public StudentPenalty()
        {
            InitializeComponent();
            LoadPenaltyData();
        }
        private void StudentPenalty_Load(object sender, EventArgs e)
        {
        }
        private async Task LoadPenaltyData()
        {
            dgvPenaltyList.DefaultCellStyle.ForeColor = Color.Black;
            try
            {
                var loggedInStudent = Session.Instance.LoggedInStudent;
                if (loggedInStudent == null)
                {
                    MessageBox.Show("No student is logged in. Please log in first.");
                    return;
                }
                string rollNo = loggedInStudent.RollNo;
                var client = new MongoClient("mongodb://localhost:27017");
                var database = client.GetDatabase("LibraryManagementSystem");
                var collection = database.GetCollection<issuedBooks>("IssuedBooks");
                var filter = Builders<issuedBooks>.Filter.And(
                    Builders<issuedBooks>.Filter.Eq(b => b.RollNo, rollNo),
                    Builders<issuedBooks>.Filter.Gt(b => b.Fine, 0)
                );
                var issuedBooks = await collection.Find(filter).ToListAsync();
                dgvPenaltyList.Rows.Clear();
                foreach (var Data in issuedBooks)
                {
                    int rowIndex = dgvPenaltyList.Rows.Add();
                    dgvPenaltyList.Rows[rowIndex].Cells["BookTitle"].Value = Data.BookTitle;
                    dgvPenaltyList.Rows[rowIndex].Cells["IssuedDate"].Value = Data.IssuedDate;
                    dgvPenaltyList.Rows[rowIndex].Cells["DueDate"].Value = Data.DueDate;
                    dgvPenaltyList.Rows[rowIndex].Cells["ReturnDate"].Value = Data.ReturnDate;
                    dgvPenaltyList.Rows[rowIndex].Cells["Fine"].Value = Data.Fine;
                    dgvPenaltyList.Rows[rowIndex].Cells["Status"].Value = Data.PenaltyStatus;
                }
                dgvPenaltyList.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading penalty data: {ex.Message}");
            }
        }
        private void btnHome_Click(object sender, EventArgs e)
        {
            StudentHome form = new StudentHome();
            form.Show();
            this.Hide();
        }
        private void btnMyAccount_Click(object sender, EventArgs e)
        {
            MyAccount form = new MyAccount();
            form.Show();
            this.Hide();
        }

        private void btnBorrowBooks_Click(object sender, EventArgs e)
        {
            StudentBorrowed form = new StudentBorrowed();
            form.Show();
            this.Hide();
        }
        private void btnReturnBook_Click(object sender, EventArgs e)
        {
            StudentReturnBook form = new StudentReturnBook();
            form.Show();
            this.Hide();
        }
        private void btnViewBooks_Click(object sender, EventArgs e)
        {
            StudentViewBooks form = new StudentViewBooks();
            form.Show();
            this.Hide();
        }
        private void btnPenalty_Click(object sender, EventArgs e)
        {
            StudentPenalty form = new StudentPenalty();
            form.Show();
            this.Hide();
        }
        private void dgvPenaltyList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Instance.ClearSession();
            LoginPage loginForm = new LoginPage();
            this.Hide();
            loginForm.Show();
        }
    }
}
