using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Globalization;
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
    public partial class BookIssueForm : Form
    {
        private List<Book> _books = new List<Book>();
        private List<Student> _students = new List<Student>();
        private Book _selectedBook;
        private Student _selectedStudent;
        private IMongoDatabase _database;
        public BookIssueForm()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            _database = client.GetDatabase("LibraryManagementSystem");
            InitializeComponent();
        }
        private async void BookIssueForm_Load(object sender, EventArgs e)
        {

            var StuCollection = _database.GetCollection<Student>("Students");
            var BookCollection = _database.GetCollection<Book>("Books");
            _students = await StuCollection.Find(FilterDefinition<Student>.Empty).ToListAsync();
            _books = await BookCollection.Find(FilterDefinition<Book>.Empty).ToListAsync();
            LoadComboBoxData();
        }
        private void LoadComboBoxData()
        {
            cbSelectBook.Items.Clear();
            foreach (var book in _books)
            {
                cbSelectBook.Items.Add(book.Title);
            }
            cbSelectRollNo.Items.Clear();
            foreach (var student in _students)
            {
                cbSelectRollNo.Items.Add(student.RollNo);
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedRollNo = cbSelectRollNo.SelectedItem?.ToString();
            _selectedStudent = _students.FirstOrDefault(s => s.RollNo == selectedRollNo);
        }

        private void cbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void btnSelectBook_Click(object sender, EventArgs e)
        {
            string selectedBookTitle = cbSelectBook.SelectedItem?.ToString();
            _selectedBook = _books.FirstOrDefault(b => b.Title == selectedBookTitle);

            if (_selectedBook != null)
            {
                lblBookName.Text = $"Book Name: {_selectedBook.Title}";
                lblAuthor.Text = $"Author: {_selectedBook.Author}";
                lblEdition.Text = $"Edition: {_selectedBook.Edition}";
                lblPrice.Text = $"Price: {_selectedBook.Price.ToString("C", new CultureInfo("ur-PK"))}";
                lblQuantity.Text = $"Quantity: {_selectedBook.Quantity}";
                lblAvailable.Text = $"Available: {_selectedBook.Available}";
                lblIssued.Text = $"Issued: {_selectedBook.Issued}";
                lblDetail.Text = $"Detail: {_selectedBook.Description}";
                if (!string.IsNullOrEmpty(_selectedBook.Image))
                {
                    try
                    {
                        byte[] imageBytes = Convert.FromBase64String(_selectedBook.Image);
                        using (var ms = new System.IO.MemoryStream(imageBytes))
                        {
                            pbPicture.Image = Image.FromStream(ms);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error displaying image: {ex.Message}");
                    }
                }
                else
                {
                    pbPicture.Image = null;
                }
            }
        }
        private async void btnIssue_Click(object sender, EventArgs e)
        {
            try
            {
                if (_selectedStudent == null || _selectedBook == null || string.IsNullOrEmpty(txtDays.Text) || !int.TryParse(txtDays.Text, out int numberOfDays) || numberOfDays <= 0)
                {
                    MessageBox.Show("Please select a valid student, book, and enter a valid number of days.");
                    return;
                }
                if (_selectedBook.Available <= 0)
                {
                    MessageBox.Show($"The book '{_selectedBook.Title}' is currently unavailable.");
                    return;
                }
                var issuedBooksCollection = _database.GetCollection<BsonDocument>("IssuedBooks");
                var existingIssueFilter = Builders<BsonDocument>.Filter.And(
                    Builders<BsonDocument>.Filter.Eq("RollNo", _selectedStudent.RollNo),
                    Builders<BsonDocument>.Filter.Eq("BookTitle", _selectedBook.Title),
                    Builders<BsonDocument>.Filter.Eq("ReturnDate", BsonNull.Value)
                );
                var existingIssue = await issuedBooksCollection.Find(existingIssueFilter).FirstOrDefaultAsync();
                if (existingIssue != null)
                {
                    MessageBox.Show($"The book '{_selectedBook.Title}' is already borrowed by this student and not yet returned.");
                    return;
                }
                DateTime dueDate = DateTime.Now.AddDays(numberOfDays);
                var issuedDocument = new BsonDocument
        {
            { "RollNo", _selectedStudent.RollNo },
            { "StudentName", _selectedStudent.StudentName },
            { "BookTitle", _selectedBook.Title },
            { "Author", _selectedBook.Author },
            { "IssuedDate", DateTime.Now },
            { "DueDate", dueDate },
            { "ReturnDate", BsonNull.Value },
            { "Fine", 0 },
            { "PenaltyStatus", BsonNull.Value }
        };
                await issuedBooksCollection.InsertOneAsync(issuedDocument);
                MessageBox.Show("Book Issued successfully!");
                var updateDefinition = Builders<Book>.Update
                    .Inc(b => b.Issued, 1)
                    .Inc(b => b.Available, -1);
                var filter = Builders<Book>.Filter.Eq(b => b.Title, _selectedBook.Title);
                await _database.GetCollection<Book>("Books").UpdateOneAsync(filter, updateDefinition);
                var updatedBook = _books.FirstOrDefault(b => b.Title == _selectedBook.Title);
                if (updatedBook != null)
                {
                    updatedBook.Issued += 1;
                    updatedBook.Available -= 1;
                }
                btnSelectBook_Click(sender, e);
            }

            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while issuing the book: " + ex.Message);
            }
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

        private void btnLogout_Click(object sender, EventArgs e)
        {
            LoginPage loginPage = new LoginPage();
            loginPage.Show();
            this.Hide();
        }
    }
}
