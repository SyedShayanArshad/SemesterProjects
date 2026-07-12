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
    public partial class LibrarianPenalty : Form
    {
        private List<issuedBooks> _issuedBooks = new List<issuedBooks>();
        private IMongoDatabase _database;
        private string _selectedRollNo = null;
        public LibrarianPenalty()
        {
            InitializeComponent();
        }

        private async void LibrarianPenalty_Load(object sender, EventArgs e)
        {
            dgvPenaltyList.DefaultCellStyle.ForeColor = Color.Black;
            var client = new MongoClient("mongodb://localhost:27017");
            _database = client.GetDatabase("LibraryManagementSystem");
            var collection = _database.GetCollection<issuedBooks>("IssuedBooks");
            var filter = Builders<issuedBooks>.Filter.Gt(b => b.Fine, 0);
            _issuedBooks = await collection.Find(filter).ToListAsync();
            LoadDGVData();
            LoadComboBoxData();
        }
        private async Task LoadDGVData(string rollNo = null)
        {
            dgvPenaltyList.Rows.Clear();
            var filteredData = _issuedBooks.AsEnumerable();
            if (!string.IsNullOrEmpty(rollNo))
            {
                filteredData = filteredData.Where(s => s.RollNo == rollNo);
            }
            foreach (var Data in filteredData)
            {
                int rowIndex = dgvPenaltyList.Rows.Add();
                dgvPenaltyList.Rows[rowIndex].Cells["RollNo"].Value = Data.RollNo;
                dgvPenaltyList.Rows[rowIndex].Cells["BookTitle"].Value = Data.BookTitle;
                dgvPenaltyList.Rows[rowIndex].Cells["IssuedDate"].Value = Data.IssuedDate;
                dgvPenaltyList.Rows[rowIndex].Cells["DueDate"].Value = Data.DueDate;
                dgvPenaltyList.Rows[rowIndex].Cells["ReturnDate"].Value = Data.ReturnDate;
                dgvPenaltyList.Rows[rowIndex].Cells["Fine"].Value = Data.Fine;
            }
            dgvPenaltyList.ClearSelection();
        }
        private void LoadComboBoxData()
        {
            cbRollNo.Items.Clear();
            var rollNos = _issuedBooks.Select(s => s.RollNo).Distinct().ToList();
            cbRollNo.Items.AddRange(rollNos.ToArray());
        }

        private void cbRollNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedRollNo = cbRollNo.SelectedItem?.ToString();

        }

        private void btnSelectRollNo_Click(object sender, EventArgs e)
        {
            LoadDGVData(_selectedRollNo);

        }

        private void btnResetFilter_Click(object sender, EventArgs e)
        {
            _selectedRollNo = null;
            cbRollNo.SelectedIndex = -1;
            LoadDGVData();
        }

        private async void btnWaiveFine_Click(object sender, EventArgs e)
        {
            if (dgvPenaltyList.SelectedRows.Count > 0)
            {
                string bookTitle = dgvPenaltyList.SelectedRows[0].Cells["BookTitle"].Value.ToString();
                string rollNo = dgvPenaltyList.SelectedRows[0].Cells["RollNo"].Value.ToString();

                var collection = _database.GetCollection<issuedBooks>("IssuedBooks");
                var filter = Builders<issuedBooks>.Filter.And(
                    Builders<issuedBooks>.Filter.Eq(b => b.BookTitle, bookTitle),
                    Builders<issuedBooks>.Filter.Eq(b => b.RollNo, rollNo)
                );

                var update = Builders<issuedBooks>.Update.Set(b => b.Fine, 0)
                    .Set(b => b.PenaltyStatus, "Waived");

                try
                {
                    var result = await collection.UpdateOneAsync(filter, update);
                    if (result.ModifiedCount > 0)
                    {
                        MessageBox.Show("Fine waived successfully.");
                        LibrarianPenalty_Load(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Failed to waive fine.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating the database: {ex.Message}");
                }

            }
            else
            {
                MessageBox.Show("Please select a book record.");
            }
        }

        private async void btnPaidFine_Click(object sender, EventArgs e)
        {
            if (dgvPenaltyList.SelectedRows.Count > 0)
            {
                string bookTitle = dgvPenaltyList.SelectedRows[0].Cells["BookTitle"].Value.ToString();
                string rollNo = dgvPenaltyList.SelectedRows[0].Cells["RollNo"].Value.ToString();

                var collection = _database.GetCollection<issuedBooks>("IssuedBooks");
                var filter = Builders<issuedBooks>.Filter.And(
                    Builders<issuedBooks>.Filter.Eq(b => b.BookTitle, bookTitle),
                    Builders<issuedBooks>.Filter.Eq(b => b.RollNo, rollNo)
                );

                var update = Builders<issuedBooks>.Update.Set(b => b.Fine, 0)
                    .Set(b => b.PenaltyStatus, "Paid");

                try
                {
                    var result = await collection.UpdateOneAsync(filter, update);
                    if (result.ModifiedCount > 0)
                    {
                        MessageBox.Show("Fine marked as paid successfully.");
                        LibrarianPenalty_Load(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Failed to mark fine as paid.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating the database: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Please select a book record.");
            }
        }
    }
}
