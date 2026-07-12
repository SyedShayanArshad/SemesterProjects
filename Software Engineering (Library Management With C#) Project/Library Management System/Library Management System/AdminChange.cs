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
    public partial class AdminChange : Form
    {
        public AdminChange()
        {
            InitializeComponent();
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
            AdminChange form = new AdminChange();
            form.Show();
            this.Hide();
        }

        private void AdminChange_Load(object sender, EventArgs e)
        {

        }

        private async void btnChangePass_Click(object sender, EventArgs e)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("LibraryManagementSystem");
            string oldPassword = txtOldPassword.Text;
            string newPassword = txtNewPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;
            string newUsername = txtUsername.Text;
            if (string.IsNullOrEmpty(oldPassword) || string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmPassword) || string.IsNullOrEmpty(newUsername))
            {
                MessageBox.Show("All fields are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("New password and confirm password do not match.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var adminCollection = database.GetCollection<BsonDocument>("Admin");
                var admin = await adminCollection.Find(FilterDefinition<BsonDocument>.Empty).FirstOrDefaultAsync();
                if (admin == null)
                {
                    MessageBox.Show("Admin account not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (admin["password"].AsString != oldPassword)
                {
                    MessageBox.Show("Old password is incorrect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var filter = Builders<BsonDocument>.Filter.Eq("_id", admin["_id"]);
                var update = Builders<BsonDocument>.Update
                    .Set("username", newUsername)
                    .Set("password", newPassword);

                var result = await adminCollection.UpdateOneAsync(filter, update);

                if (result.ModifiedCount > 0)
                {
                    MessageBox.Show("Admin details updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtOldPassword.Clear();
                    txtNewPassword.Clear();
                    txtConfirmPassword.Clear();
                }
                else
                {
                    MessageBox.Show("Failed to update admin details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            LoginPage loginPage = new LoginPage();
            loginPage.Show();
            this.Hide();
        }
    }
}
