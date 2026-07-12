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
    public partial class LoginPage : Form
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoginPage_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void loginArea_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!radioStudent.Checked && !radioLibrarian.Checked && !radioAdmin.Checked)
            {
                MessageBox.Show("Please select a login role (Student or Librarian or Admin).", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                var client = new MongoClient("mongodb://localhost:27017"); // Replace with your connection string
                var database = client.GetDatabase("LibraryManagementSystem");
                if (radioStudent.Checked) 
                {
                    var studentsCollection = database.GetCollection<Student>("Students");
                    var student = studentsCollection
                        .Find(s => s.Username == username && s.Password == password)
                        .FirstOrDefault();
                    if (student != null)
                    {
                        Session.Instance.SetLoggedInStudent(student);
                        StudentHome form= new StudentHome();
                        this.Hide();
                        form.Show();
                    }
                    else
                    {
                        MessageBox.Show("Invalid student credentials.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (radioLibrarian.Checked) 
                {
                    var librariansCollection = database.GetCollection<Librarian>("Librarian");
                    var librarian = librariansCollection
                        .Find(l => l.Username == username && l.Password == password)
                        .FirstOrDefault();
                    if (librarian != null)
                    {
                        Session.Instance.SetLoggedInLibrarian(librarian);
                        LibrarianHome form = new LibrarianHome();
                        this.Hide();
                        form.Show();
                    }
                    else
                    {
                        MessageBox.Show("Invalid librarian credentials.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (radioAdmin.Checked)
                {
                    var adminCollection = database.GetCollection<BsonDocument>("Admin");
                    var admin = adminCollection
                        .Find(a => a["username"] == username && a["password"] == password)
                        .FirstOrDefault();
                    if (admin != null)
                    {
                        AddLibrarian form = new AddLibrarian();
                        this.Hide();
                        form.Show();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Admin credentials.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
