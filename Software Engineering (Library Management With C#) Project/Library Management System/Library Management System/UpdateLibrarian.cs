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
    public partial class UpdateLibrarian : Form
    {
        private readonly string _librarianID;
        public UpdateLibrarian( Librarian librarian)
        {
            InitializeComponent();
            _librarianID = librarian.LibrarianID;
            txtLibrarianID.Text = librarian.LibrarianID;
            txtName.Text = librarian.LibrarianName;
            txtUsername.Text = librarian.Username;
            txtPassword.Text = librarian.Password;
            txtMobile.Text = librarian.Mobile;
            txtAddress.Text = librarian.Address;
            if (librarian.Gender == "Male")
                radioButton1.Checked = true;
            else if (librarian.Gender == "Female")
                radioButton2.Checked = true;
        }

        private void UpdateLibrarian_Load(object sender, EventArgs e)
        {

        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            var updatedLibrarian = new Librarian
            {
                LibrarianID = _librarianID,
                LibrarianName = txtName.Text,
                Username = txtUsername.Text,
                Password = txtPassword.Text,
                Mobile = txtMobile.Text,
                Gender = radioButton1.Checked ? "Male" : "Female",
                Address = txtAddress.Text
            };
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("LibraryManagementSystem");
            var collection = database.GetCollection<Librarian>("Librarian");
            var filter = Builders<Librarian>.Filter.Eq(l => l.LibrarianID, _librarianID);
            var update = Builders<Librarian>.Update
                .Set(l => l.LibrarianName, updatedLibrarian.LibrarianName)
                .Set(l => l.Username, updatedLibrarian.Username)
                .Set(l => l.Password, updatedLibrarian.Password)
                .Set(l => l.Mobile, updatedLibrarian.Mobile)
                .Set(l => l.Gender, updatedLibrarian.Gender)
                .Set(l => l.Address, updatedLibrarian.Address);

            try
            {
                var result = await collection.UpdateOneAsync(filter, update);
                if (result.ModifiedCount > 0)
                {
                    MessageBox.Show("Librarian updated successfully.");
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to update librarian.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}
