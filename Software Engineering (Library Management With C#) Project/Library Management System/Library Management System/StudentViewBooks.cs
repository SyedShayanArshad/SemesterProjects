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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Library_Management_System
{
    public partial class StudentViewBooks : Form
    {
        private List<Book> _books = new List<Book>();
        public StudentViewBooks()
        {
            InitializeComponent();
        }

        private async void StudentViewBooks_Load(object sender, EventArgs e)
        {
            detailPanel.Hide();
            dgvBookReport.DefaultCellStyle.ForeColor = Color.Black;
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("LibraryManagementSystem");
            var collection = database.GetCollection<Book>("Books");
            _books = await collection.Find(FilterDefinition<Book>.Empty).ToListAsync();
            dgvBookReport.Rows.Clear();
            foreach (var book in _books)
            {
                int rowIndex = dgvBookReport.Rows.Add();
                dgvBookReport.Rows[rowIndex].Cells["BookTitle"].Value = book.Title;
                dgvBookReport.Rows[rowIndex].Cells["Price"].Value = book.Price;
                dgvBookReport.Rows[rowIndex].Cells["Quantity"].Value = book.Quantity;
                dgvBookReport.Rows[rowIndex].Cells["Available"].Value = book.Available;
                dgvBookReport.Rows[rowIndex].Cells["View"].Value = "View";
            }
            dgvBookReport.ClearSelection();
        }

        private void dgvBookReport_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvBookReport.Columns[e.ColumnIndex].Name == "View")
            {
                ReportPanel.Hide();
                detailPanel.Show();
                string selectedTitle = dgvBookReport.Rows[e.RowIndex].Cells["BookTitle"].Value.ToString();
                var selectedBook = _books.Find(book => book.Title == selectedTitle);
                if (selectedBook != null)
                {
                    lblBookName.Text = $"Book Name: {selectedBook.Title}";
                    lblAuthor.Text = $"Author: {selectedBook.Author}";
                    lblEdition.Text = $"Edition: {selectedBook.Edition}";
                    lblPrice.Text = $"Price: {selectedBook.Price}";
                    lblQuantity.Text = $"Quantity: {selectedBook.Quantity}";
                    lblAvailable.Text = $"Available: {selectedBook.Available}";
                    lblIssued.Text = $"Issued: {selectedBook.Issued}";
                    lblDetail.Text = $"Details: {selectedBook.Description}";
                    if (!string.IsNullOrEmpty(selectedBook.Image))
                    {
                        try
                        {
                            byte[] imageBytes = Convert.FromBase64String(selectedBook.Image);
                            using (var ms = new MemoryStream(imageBytes))
                            {
                                pbBookPicture.Image = Image.FromStream(ms);
                            }
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Error: Image format is invalid.", "Image Load Error");
                            pbBookPicture.Image = null;
                        }
                    }
                    else
                    {
                        pbBookPicture.Image = null;
                    }
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            detailPanel.Hide();
            ReportPanel.Show();
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

        private void btnViewBooks_Click(object sender, EventArgs e)
        {
            StudentViewBooks form = new StudentViewBooks();
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

        private void btnPenalty_Click(object sender, EventArgs e)
        {
            StudentPenalty form = new StudentPenalty();
            form.Show();
            this.Hide();
        }
    }
}
