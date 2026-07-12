using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Library_Management_System
{
    public partial class BookReport : Form
    {
        private List<Book> _books = new List<Book>();

        public BookReport()
        {
            InitializeComponent();
        }

        private async void BookReport_Load(object sender, EventArgs e)
        {
            DetailPanel.Hide();
            DGVBookReport.DefaultCellStyle.ForeColor = Color.Black;
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("LibraryManagementSystem");
            var collection = database.GetCollection<Book>("Books");
            _books = await collection.Find(FilterDefinition<Book>.Empty).ToListAsync();
            DGVBookReport.Rows.Clear();
            foreach (var book in _books)
            {
                int rowIndex = DGVBookReport.Rows.Add();
                DGVBookReport.Rows[rowIndex].Cells["Title"].Value = book.Title;
                DGVBookReport.Rows[rowIndex].Cells["Price"].Value = book.Price;
                DGVBookReport.Rows[rowIndex].Cells["Quantity"].Value = book.Quantity;
                DGVBookReport.Rows[rowIndex].Cells["Available"].Value = book.Available;
                DGVBookReport.Rows[rowIndex].Cells["Issued"].Value = book.Issued;
                DGVBookReport.Rows[rowIndex].Cells["View"].Value = "View"; // The button text
            }
            DGVBookReport.ClearSelection();
        }
        private void DGVBookReport_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && DGVBookReport.Columns[e.ColumnIndex].Name == "View")
            {
                ReportPanel.Hide();
                DetailPanel.Show();
                string selectedTitle = DGVBookReport.Rows[e.RowIndex].Cells["Title"].Value.ToString();
                var selectedBook = _books.Find(book => book.Title == selectedTitle);
                if (selectedBook != null)
                {
                    // Populate the DetailPanel with the book's details
                    dName.Text = $"Book Name: {selectedBook.Title}";
                    dAuthor.Text = $"Author: {selectedBook.Author}";
                    dEdition.Text = $"Edition: {selectedBook.Edition}";
                    dPrice.Text = $"Price: {selectedBook.Price}";
                    dQuantity.Text = $"Quantity: {selectedBook.Quantity}";
                    dAvailable.Text = $"Available: {selectedBook.Available}";
                    dIssued.Text = $"Issued: {selectedBook.Issued}";
                    dDetail.Text = $"Details: {selectedBook.Description}";
                    if (!string.IsNullOrEmpty(selectedBook.Image))
                    {
                        try
                        {
                            byte[] imageBytes = Convert.FromBase64String(selectedBook.Image);
                            using (var ms = new MemoryStream(imageBytes))
                            {
                                dPicture.Image = Image.FromStream(ms);
                            }
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Error: Image format is invalid.", "Image Load Error");
                            dPicture.Image = null;
                        }
                    }
                    else
                    {
                        dPicture.Image = null;
                    }
                }
            }
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            DetailPanel.Hide();
            ReportPanel.Show();
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
