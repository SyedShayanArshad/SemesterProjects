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
    public partial class LibrarianHome : Form
    {
        public LibrarianHome()
        {
            InitializeComponent();
        }
        private void btnHome_Click(object sender, EventArgs e)
        {
            LibrarianHome form = new LibrarianHome();
            form.Show();
            this.Hide();
        }
        private void btnAddBook_Click(object sender, EventArgs e)
        {
            AddBookPage form = new AddBookPage();
            form.Show();
            this.Hide();
        }
        private void btnBookReport_Click(object sender, EventArgs e)
        {
            BookReport form = new BookReport();
            form.Show();
            this.Hide();
        }

        private void btnAddDepartment_Click(object sender, EventArgs e)
        {
            AddDepartment form = new AddDepartment();
            form.Show();
            this.Hide();
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            AddStudent form = new AddStudent();
            form.Show();
            this.Hide();
        }

        private void btnStudentReport_Click(object sender, EventArgs e)
        {
            StudentReport form = new StudentReport();
            form.Show();
            this.Hide();
        }

        private void btnIssueBook_Click(object sender, EventArgs e)
        {
            BookIssueForm form = new BookIssueForm();
            form.Show();
            this.Hide();
        }

        private void btnIssueReport_Click(object sender, EventArgs e)
        {
            IssueBookReport form = new IssueBookReport();
            form.Show();
            this.Hide();
        }

        private void btnReturnBook_Click(object sender, EventArgs e)
        {
            BookReturnForm form = new BookReturnForm();
            form.Show();
            this.Hide();
        }

        private void lblChangeInformation_Click(object sender, EventArgs e)
        {
            if (Session.Instance.LoggedInLibrarian != null)
            {
                var updateForm = new UpdateLibrarian(Session.Instance.LoggedInLibrarian);
                updateForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("No librarian is logged in. Please log in and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            LoginPage loginPage = new LoginPage();
            loginPage.Show();
            this.Hide();
        }
    }
}
