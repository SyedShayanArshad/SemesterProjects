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
    public partial class ReturnBookReport : Form
    {
        private List<issuedBooks> _issuedBooks = new List<issuedBooks>();
        private string _selectedBook = null;
        private string _selectedRollNo = null;
        public ReturnBookReport()
        {
            InitializeComponent();
        }
        private async void ReturnBookReport_Load(object sender, EventArgs e)
        {
            dgvIssuedBooks.DefaultCellStyle.ForeColor = Color.Black;
            var client = new MongoClient("mongodb://localhost:27017"); // Connect to MongoDB
            var database = client.GetDatabase("LibraryManagementSystem"); // Access your database
            var collection = database.GetCollection<issuedBooks>("IssuedBooks"); // Access the Students collection
            _issuedBooks = await collection.Find(book => book.ReturnDate != null).ToListAsync();
            LoadDGVData();
            LoadComboBoxData();
        }
        private void LoadDGVData(string BookTitle = null, string rollNo = null)
        {
            dgvIssuedBooks.Rows.Clear();
            var filteredData = _issuedBooks.AsEnumerable();

            if (!string.IsNullOrEmpty(BookTitle))
            {
                filteredData = filteredData.Where(s => s.BookTitle == BookTitle);
            }

            if (!string.IsNullOrEmpty(rollNo))
            {
                filteredData = filteredData.Where(s => s.RollNo == rollNo);
            }
            foreach (var Data in filteredData)
            {
                int rowIndex = dgvIssuedBooks.Rows.Add();
                dgvIssuedBooks.Rows[rowIndex].Cells["RollNo"].Value = Data.RollNo;
                dgvIssuedBooks.Rows[rowIndex].Cells["BookTitle"].Value = Data.BookTitle;
                dgvIssuedBooks.Rows[rowIndex].Cells["IssuedDate"].Value = Data.IssuedDate;
                dgvIssuedBooks.Rows[rowIndex].Cells["DueDate"].Value = Data.DueDate;
                dgvIssuedBooks.Rows[rowIndex].Cells["ReturnDate"].Value = Data.ReturnDate;
                dgvIssuedBooks.Rows[rowIndex].Cells["PenaltyStatus"].Value = Data.PenaltyStatus;
            }
            dgvIssuedBooks.ClearSelection();
        }
        private void LoadComboBoxData()
        {
            cbBookTitle.Items.Clear();
            cbRollNo.Items.Clear();
            var books = _issuedBooks.Select(s => s.BookTitle).Distinct().ToList();
            cbBookTitle.Items.AddRange(books.ToArray());
            var rollNos = _issuedBooks.Select(s => s.RollNo).Distinct().ToList();
            cbRollNo.Items.AddRange(rollNos.ToArray());
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cbRollNo_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            _selectedRollNo = cbRollNo.SelectedItem?.ToString();
        }

        private void cbBookTitle_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            _selectedBook = cbBookTitle.SelectedItem?.ToString();
        }

        private void btnSelectRollNo_Click(object sender, EventArgs e)
        {
            LoadDGVData(null, _selectedRollNo);
        }

        private void btnBookTitle_Click(object sender, EventArgs e)
        {
            LoadDGVData(_selectedBook);
        }

        private void btnResetFilter_Click_1(object sender, EventArgs e)
        {
            _selectedBook = null;
            _selectedRollNo = null;
            cbBookTitle.SelectedIndex = -1;
            cbRollNo.SelectedIndex = -1;
            LoadDGVData();
        }
    }
}
