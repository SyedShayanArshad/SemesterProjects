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
    public partial class AddStudent : Form
    {
        public AddStudent()
        {
            InitializeComponent();
        }

        private void AddStudent_Load(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "mongodb://localhost:27017";
                var client = new MongoClient(connectionString);
                var database = client.GetDatabase("LibraryManagementSystem");
                var collection = database.GetCollection<BsonDocument>("Departments");
                var departments = collection.Find(new BsonDocument()).ToList();
                cbDepartment.Items.Clear();
                foreach (var department in departments)
                {
                    cbDepartment.Items.Add(department["Name"].AsString);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while loading departments: " + ex.Message);
            }
        }

        private void btnStudentAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "mongodb://localhost:27017";
                var client = new MongoClient(connectionString);
                var database = client.GetDatabase("LibraryManagementSystem");
                var collection = database.GetCollection<BsonDocument>("Students");
                string gender = radioButton1.Checked ? "Male" : (radioButton2.Checked ? "Female" : "Not Specified");
                var studentDocument = new BsonDocument
                {
                    { "StudentName", txtStudentName.Text },
                    { "RollNo", txtRollNo.Text },
                    { "Gender", gender },
                    { "Username", txtUsername.Text },
                    { "Password", txtPassword.Text },
                    { "Department", cbDepartment.Text },
                    { "Mobile", txtMobile.Text },
                    { "Address", txtAddress.Text }
                };

                // Insert the document into the MongoDB collection
                collection.InsertOne(studentDocument);

                MessageBox.Show("Student added successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void cbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        private void btnLogout_Click(object sender, EventArgs e)
        {
            LoginPage loginPage = new LoginPage();
            loginPage.Show();
            this.Hide();
        }
    }
}
