using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace Library_Management_System
{
    public partial class BookReturnForm : Form
    {
        private List<issuedBooks> _IssuedBooks = new List<issuedBooks>();
        private IMongoDatabase _database;

        public BookReturnForm()
        {
            InitializeComponent();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private async void BookReturnForm_Load(object sender, EventArgs e)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            _database = client.GetDatabase("LibraryManagementSystem");
            var collection = _database.GetCollection<issuedBooks>("IssuedBooks");
            _IssuedBooks = await collection.Find(book => book.ReturnDate == null).ToListAsync();
            LoadComboBoxData();
        }

        private void LoadComboBoxData()
        {
            var students = _IssuedBooks.Where(s => s.ReturnDate == null).Select(s => s.RollNo).Distinct().ToList();
            cbSelectStudent.Items.Clear();
            cbSelectStudent.Items.AddRange(students.ToArray());
            cbSelectBook.Items.Clear();
        }

        private async void cbSelectStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedStudent = cbSelectStudent.SelectedItem?.ToString();
            if (!string.IsNullOrEmpty(selectedStudent))
            {
                cbSelectBook.Enabled = true;
                var studentBooks = _IssuedBooks
                    .Where(s => s.RollNo == selectedStudent && s.ReturnDate == null)
                    .Select(s => s.BookTitle)
                    .Distinct()
                    .ToList();
                cbSelectBook.Items.Clear();
                cbSelectBook.Items.AddRange(studentBooks.ToArray());
            }
            else
            {
                cbSelectBook.Enabled = false;
                cbSelectBook.Items.Clear();
            }
        }

        private async void cbSelectBook_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedStudent = cbSelectStudent.SelectedItem?.ToString();
            string selectedBook = cbSelectBook.SelectedItem?.ToString();
            var bookDetails = _IssuedBooks
                .FirstOrDefault(book => book.BookTitle == selectedBook && book.RollNo == selectedStudent);

            if (bookDetails != null)
            {
                ReturnDatePicker.MinDate = bookDetails.IssuedDate;
            }
        }

        private async void btnViewBook_Click(object sender, EventArgs e)
        {
            var collection = _database.GetCollection<Book>("Books");
            string selectedBook = cbSelectBook.SelectedItem?.ToString();
            var filter = Builders<Book>.Filter.Eq(b => b.Title, selectedBook);
            var filterBook = await collection.Find(filter).FirstOrDefaultAsync();
            var bookDetails = _IssuedBooks
                .FirstOrDefault(book => book.BookTitle == selectedBook && book.RollNo == cbSelectStudent.SelectedItem?.ToString());

            if (bookDetails != null)
            {
                lblBookName.Text = $"Book Name: {bookDetails.BookTitle}";
                lblAuthor.Text = $"Author: {bookDetails.Author}";
                lblEdition.Text = $"Edition: {filterBook?.Edition}";
                lblPrice.Text = $"Price: {filterBook?.Price.ToString()}";
                lblIssuedDate.Text = $"Issued Date: {bookDetails.IssuedDate:yyyy-MM-dd}";
                lblDueDate.Text = $"Due Date: {bookDetails.DueDate:yyyy-MM-dd}";
                lblStudentName.Text = $"Student Name: {bookDetails.StudentName}";
                if (filterBook?.Image != null)
                {
                    try
                    {
                        byte[] imageBytes = Convert.FromBase64String(filterBook.Image);
                        using (var ms = new MemoryStream(imageBytes))
                        {
                            pbBookPicture.Image = Image.FromStream(ms);
                            pbBookPicture.SizeMode = PictureBoxSizeMode.StretchImage;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to load book image: {ex.Message}");
                    }
                }
                else
                {
                    pbBookPicture.Image = null;
                }
            }
            else
            {
                MessageBox.Show("Book not found.");
            }
        }

        private async void btnReturn_Click(object sender, EventArgs e)
        {
            string selectedStudent = cbSelectStudent.SelectedItem?.ToString();
            string selectedBook = cbSelectBook.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(selectedStudent) || string.IsNullOrEmpty(selectedBook))
            {
                MessageBox.Show("Please select both student and book.");
                return;
            }

            var bookDetails = _IssuedBooks
                .FirstOrDefault(book => book.BookTitle == selectedBook && book.RollNo == selectedStudent);

            if (bookDetails == null)
            {
                MessageBox.Show("No such issued book found.");
                return;
            }

            DateTime returnDate = ReturnDatePicker.Value;
            DateTime dueDate = bookDetails.DueDate;
            decimal fine = CalculateFine(returnDate, dueDate);
            string penaltyStatus = "No Fine";
            if (fine > 0)
            {
                penaltyStatus = "Not Paid";
            }
            var collection = _database.GetCollection<issuedBooks>("IssuedBooks");
            var booksCollection = _database.GetCollection<Book>("Books");
            var filter = Builders<issuedBooks>.Filter.And(
                Builders<issuedBooks>.Filter.Eq(b => b.BookTitle, selectedBook),
                Builders<issuedBooks>.Filter.Eq(b => b.RollNo, selectedStudent)
            );

            var update = Builders<issuedBooks>.Update
                .Set(b => b.ReturnDate, returnDate)
                .Set(b => b.Fine, fine)
                .Set(b => b.PenaltyStatus, penaltyStatus);

            try
            {
                var result = await collection.UpdateOneAsync(filter, update);
                if (result.ModifiedCount > 0)
                {
                    MessageBox.Show($"Book returned successfully with a fine of Rs. {fine}");
                    var bookFilter = Builders<Book>.Filter.Eq(b => b.Title, selectedBook);
                    var bookUpdate = Builders<Book>.Update
                        .Inc(b => b.Issued, -1)
                        .Inc(b => b.Available, 1);
                    await booksCollection.UpdateOneAsync(bookFilter, bookUpdate);
                    BookReturnForm_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Failed to return the book.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating the database: {ex.Message}");
            }
        }

        private decimal CalculateFine(DateTime returnDate, DateTime dueDate)
        {
            if (returnDate > dueDate)
            {
                TimeSpan lateDays = returnDate - dueDate;
                return lateDays.Days * 50m;
            }
            return 0;
        }
        private void ReturnDatePicker_ValueChanged(object sender, EventArgs e)
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

        private void ReturnList_Click(object sender, EventArgs e)
        {
            ReturnBookReport form = new ReturnBookReport();
            form.Show();
        }

        private void PenaltyReport_Click(object sender, EventArgs e)
        {
            LibrarianPenalty form = new LibrarianPenalty();
            form.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            LoginPage loginPage = new LoginPage();
            loginPage.Show();
            this.Hide();
        }
    }
}
