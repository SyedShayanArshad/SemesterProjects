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
    public partial class AddLibrarian : Form
    {
        public AddLibrarian()
        {
            InitializeComponent();
        }

        private void btnLibrarianAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "mongodb://localhost:27017";
                var client = new MongoClient(connectionString);
                var database = client.GetDatabase("LibraryManagementSystem");
                var collection = database.GetCollection<BsonDocument>("Librarian");
                string gender = radioButton1.Checked ? "Male" : (radioButton2.Checked ? "Female" : "Not Specified");
                var studentDocument = new BsonDocument
                {
                    { "LibrarianName", txtName.Text },
                    { "LibrarianID", txtLibrarianID.Text },
                    { "Gender", gender },
                    { "Username", txtUsername.Text },
                    { "Password", txtPassword.Text },
                    { "Mobile", txtMobile.Text },
                    { "Address", txtAddress.Text }
                };
                collection.InsertOne(studentDocument);

                MessageBox.Show("Librarian added successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void btnLibrarianReport_Click(object sender, EventArgs e)
        {
            LibrarianReport form = new LibrarianReport();
            form.Show();
            this.Hide();
        }

        private void AddLibrarian_Load(object sender, EventArgs e)
        {

        }

        private void btnMyAccount_Click(object sender, EventArgs e)
        {
            AddLibrarian form = new AddLibrarian();
            form.Show();
            this.Hide();
        }

        private void btnReturnBook_Click(object sender, EventArgs e)
        {
            AdminChange f = new AdminChange();
            f.Show();
            this.Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            LoginPage loginPage = new LoginPage();
            loginPage.Show();
            this.Hide();
        }
    }
}
