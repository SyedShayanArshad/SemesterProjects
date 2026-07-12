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
    public partial class LibrarianReport : Form
    {
        private IMongoDatabase _database;

        public LibrarianReport()
        {
            InitializeComponent();
            LoadLibrarianData();
        }

        private void LibrarianReport_Load(object sender, EventArgs e)
        {

        }
        private async void LoadLibrarianData()
        {
            DGVLibrarianReport.DefaultCellStyle.ForeColor = Color.Black;
            var client = new MongoClient("mongodb://localhost:27017");
            _database = client.GetDatabase("LibraryManagementSystem"); // Access your database
            var collection = _database.GetCollection<Librarian>("Librarian"); // Access the Students collection
            var librarians = await collection.Find(FilterDefinition<Librarian>.Empty).ToListAsync();
            DGVLibrarianReport.Rows.Clear();
            foreach (var librarian in librarians.AsEnumerable())
            {
                int rowIndex = DGVLibrarianReport.Rows.Add();
                DGVLibrarianReport.Rows[rowIndex].Cells["ID"].Value = librarian.LibrarianID;
                DGVLibrarianReport.Rows[rowIndex].Cells["Name"].Value = librarian.LibrarianName;
                DGVLibrarianReport.Rows[rowIndex].Cells["Username"].Value = librarian.Username;
                DGVLibrarianReport.Rows[rowIndex].Cells["Password"].Value = librarian.Password;
                DGVLibrarianReport.Rows[rowIndex].Cells["Mobile"].Value = librarian.Mobile;
                DGVLibrarianReport.Rows[rowIndex].Cells["Gender"].Value = librarian.Gender;
                DGVLibrarianReport.Rows[rowIndex].Cells["Address"].Value = librarian.Address;
            }
            DGVLibrarianReport.ClearSelection();
        }

        private async void btnRemoveLibrarian_Click(object sender, EventArgs e)
        {
            if (DGVLibrarianReport.SelectedRows.Count > 0)
            {
                string librarianID = DGVLibrarianReport.SelectedRows[0].Cells["ID"].Value.ToString();
                var collection = _database.GetCollection<Librarian>("Librarian");
                var filter = Builders<Librarian>.Filter.Eq(l => l.LibrarianID, librarianID);
                try
                {
                    var result = await collection.DeleteOneAsync(filter);
                    if (result.DeletedCount > 0)
                    {
                        MessageBox.Show("Librarian removed successfully.");
                        DGVLibrarianReport.Rows.RemoveAt(DGVLibrarianReport.SelectedRows[0].Index);
                    }
                    else
                    {
                        MessageBox.Show("Failed to remove librarian. The record might not exist.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error removing librarian: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Please select a librarian to remove.");
            }
        }

        private void btnUpdateLibrarian_Click(object sender, EventArgs e)
        {
            if (DGVLibrarianReport.SelectedRows.Count > 0)
            {
                var selectedRow = DGVLibrarianReport.SelectedRows[0];
                var librarian = new Librarian
                {
                    LibrarianID = selectedRow.Cells["ID"].Value.ToString(),
                    LibrarianName = selectedRow.Cells["Name"].Value.ToString(),
                    Username = selectedRow.Cells["Username"].Value.ToString(),
                    Password = selectedRow.Cells["Password"].Value.ToString(),
                    Mobile = selectedRow.Cells["Mobile"].Value.ToString(),
                    Gender = selectedRow.Cells["Gender"].Value.ToString(),
                    Address = selectedRow.Cells["Address"].Value.ToString()
                };
                UpdateLibrarian updateForm = new UpdateLibrarian(librarian);
                if (updateForm.ShowDialog() == DialogResult.OK)
                {
                    LoadLibrarianData();
                }
            }
            else
            {
                MessageBox.Show("Please select a librarian to update.");
            }
        }

        private void btnMyAccount_Click(object sender, EventArgs e)
        {
            AddLibrarian form = new AddLibrarian();
            form.Show();
            this.Hide();
        }

        private void btnLibrarianReport_Click(object sender, EventArgs e)
        {
            LibrarianReport form = new LibrarianReport();
            form.Show();
            this.Hide();
        }

        private void btnReturnBook_Click(object sender, EventArgs e)
        {
            AdminChange adminChange = new AdminChange();
            adminChange.Show();
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
