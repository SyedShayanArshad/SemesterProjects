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
    public partial class StudentReturnBook : Form
    {
        public StudentReturnBook()
        {
            InitializeComponent();
            LoadReturnBooks();

        }
        private void LoadReturnBooks()
        {
            dgvReturnList.DefaultCellStyle.ForeColor = Color.Black;
            Student student = Session.Instance.LoggedInStudent;
            if (student == null)
            {
                MessageBox.Show("No student logged in.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("LibraryManagementSystem");
            var collection = database.GetCollection<issuedBooks>("IssuedBooks");
            var filter = Builders<issuedBooks>.Filter.Eq("RollNo", student.RollNo);
            var borrowedBooks = collection.Find(filter).ToList();
            dgvReturnList.Rows.Clear();

            if (borrowedBooks.Count > 0)
            {
                foreach (var book in borrowedBooks)
                {
                    if (book.ReturnDate != null)
                    {

                        int rowIndex = dgvReturnList.Rows.Add();
                        dgvReturnList.Rows[rowIndex].Cells["BookTitle"].Value = book.BookTitle;
                        dgvReturnList.Rows[rowIndex].Cells["BorrowedDate"].Value = book.IssuedDate;
                        dgvReturnList.Rows[rowIndex].Cells["DueDate"].Value = book.DueDate;
                        dgvReturnList.Rows[rowIndex].Cells["ReturnDate"].Value = book.ReturnDate;
                    }
                }
                dgvReturnList.ClearSelection();
            }
            else
            {
                MessageBox.Show("No borrowed books found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void StudentReturnBook_Load(object sender, EventArgs e)
        {

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

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Instance.ClearSession();
            LoginPage loginForm = new LoginPage();
            this.Hide();
            loginForm.Show();
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
    }
}
