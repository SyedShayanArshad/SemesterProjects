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
    public partial class StudentHome : Form
    {
        public StudentHome()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnMyAccount_Click(object sender, EventArgs e)
        {
            MyAccount myAccount = new MyAccount();
            myAccount.Show();
            this.Hide();
        }

        private void StudentHome_Load(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Instance.ClearSession();
            LoginPage loginForm = new LoginPage();
            this.Hide();
            loginForm.Show();
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

        private void btnHome_Click(object sender, EventArgs e)
        {
            StudentHome form = new StudentHome();
            form.Show();
            this.Hide();
        }
    }
}
