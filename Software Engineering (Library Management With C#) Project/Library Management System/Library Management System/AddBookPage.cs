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

    public partial class AddBookPage : Form
    {
        private string base64Image = string.Empty;
        public AddBookPage()
        {
            InitializeComponent();
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            AddStudent form = new AddStudent();
            form.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            openFileDialog.Title = "Select an Image";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Image image = Image.FromFile(openFileDialog.FileName);
                using (MemoryStream ms = new MemoryStream())
                {
                    image.Save(ms, image.RawFormat);
                    byte[] imageBytes = ms.ToArray();
                    base64Image = Convert.ToBase64String(imageBytes);
                }

                MessageBox.Show("Image selected Successfully.");
            }
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            AddBookPage page = new AddBookPage();
            page.Show();
            this.Hide();
        }

        private void AddBookPage_Load(object sender, EventArgs e)
        {

        }

        private void btnBookAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "mongodb://localhost:27017";
                var client = new MongoClient(connectionString);
                var database = client.GetDatabase("LibraryManagementSystem");
                var collection = database.GetCollection<BsonDocument>("Books");
                // Create a new book document
                var bookDocument = new BsonDocument
                {
                    { "Title", txtBookTitle.Text },
                    { "Description", txtDescription.Text },
                    { "Author", txtAuthor.Text },
                    { "Edition", txtEdition.Text },
                    { "Price", txtPrice.Text },
                    { "Quantity", int.TryParse(txtQuantity.Text, out int quantity) ? quantity : 0 },
                    { "Image", base64Image },
                    { "Issued", 0 },
                    { "Available", int.TryParse(txtQuantity.Text, out int available) ? available : 0 }
                };
                // Insert the document into the collection
                collection.InsertOne(bookDocument);
                MessageBox.Show("Book added successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void btnBookReport_Click(object sender, EventArgs e)
        {
            BookReport form = new BookReport();
            form.Show();
            this.Hide();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            LibrarianHome form = new LibrarianHome();
            form.Show();
            this.Hide();
        }

        private void btnAddDepartment_Click(object sender, EventArgs e)
        {
            AddDepartment form = new AddDepartment();
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

        private void btnLogout_Click(object sender, EventArgs e)
        {
            LoginPage loginPage = new LoginPage();
            loginPage.Show();
            this.Hide();
        }
    }
}

