using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;
using System;
using System.Collections;
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
    public partial class AddDepartment : Form
    {
        private readonly string connectionString = "mongodb://localhost:27017";
        private readonly string databaseName = "LibraryManagementSystem";
        private readonly string collectionName = "Departments";
        public AddDepartment()
        {
            InitializeComponent();
            LoadDepartments(); // Load departments when the form is initialized
        }
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void HomePage_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtAddDepartment_TextChanged(object sender, EventArgs e)
        {

        }
        private void LoadDepartments()
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);
            var collection = database.GetCollection<BsonDocument>(collectionName);
            var departments = collection.Find(FilterDefinition<BsonDocument>.Empty).ToList();
            dgvDepartment.DefaultCellStyle.ForeColor = Color.Black;
            dgvDepartment.Rows.Clear(); // Clear existing rows
            foreach (var department in departments)
            {
                int rowIndex = dgvDepartment.Rows.Add();
                dgvDepartment.Rows[rowIndex].Cells["DepartmentName"].Value = department["Name"].AsString; // Store department name
            }
            dgvDepartment.ClearSelection(); // Clear selection for a better user experience
        }
        private void btnDepartmentAdd_Click_1(object sender, EventArgs e)
        {
            string departmentName = txtAddDepartment.Text;
            if (!string.IsNullOrEmpty(departmentName))
            {
                try
                {
                    var client = new MongoClient(connectionString);
                    var database = client.GetDatabase(databaseName);
                    var collection = database.GetCollection<BsonDocument>(collectionName);
                    var departmentDocument = new BsonDocument
                    {
                        { "Name", departmentName }
                    };
                    collection.InsertOne(departmentDocument);
                    MessageBox.Show("Department added successfully!");
                    LoadDepartments(); // Refresh the DataGridView to show the new department
                    txtAddDepartment.Clear(); // Clear the text box after adding
                }
                catch (Exception ex)
                {
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please enter a department name.");
            }
        }

        private void dgvDepartment_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Ensure a valid row is clicked
            {
                string departmentName = dgvDepartment.Rows[e.RowIndex].Cells["DepartmentName"].Value?.ToString();

                // Handle Edit button click
                if (dgvDepartment.Columns[e.ColumnIndex].Name == "Edit")
                {
                    string newDepartmentName = PromptForNewName(departmentName); // Ask user for new name

                    if (!string.IsNullOrEmpty(newDepartmentName))
                    {
                        UpdateDepartment(departmentName, newDepartmentName); // Call update method
                        MessageBox.Show("Department updated successfully!");
                        LoadDepartments();
                    }
                }
                // Handle Delete button click
                else if (dgvDepartment.Columns[e.ColumnIndex].Name == "Delete")
                {
                    var confirmResult = MessageBox.Show($"Are you sure you want to delete the department '{departmentName}'?",
                                                        "Confirm Delete", MessageBoxButtons.YesNo);
                    if (confirmResult == DialogResult.Yes)
                    {
                        DeleteDepartment(departmentName); // Call delete method
                        MessageBox.Show("Department deleted successfully!");
                        LoadDepartments();
                    }
                }
            }
        }

        private void UpdateDepartment(string oldName, string newName)
        {
            try
            {
                var client = new MongoClient(connectionString);
                var database = client.GetDatabase(databaseName);
                var collection = database.GetCollection<BsonDocument>(collectionName);

                var filter = Builders<BsonDocument>.Filter.Eq("Name", oldName);
                var update = Builders<BsonDocument>.Update.Set("Name", newName);

                collection.UpdateOne(filter, update);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while updating the department: " + ex.Message);
            }
        }

        private void DeleteDepartment(string departmentName)
        {
            try
            {
                var client = new MongoClient(connectionString);
                var database = client.GetDatabase(databaseName);
                var collection = database.GetCollection<BsonDocument>(collectionName);

                var filter = Builders<BsonDocument>.Filter.Eq("Name", departmentName);

                collection.DeleteOne(filter);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while deleting the department: " + ex.Message);
            }
        }

        private string PromptForNewName(string oldName)
        {
            using (var inputForm = new Form())
            {
                inputForm.Width = 300;
                inputForm.Height = 200;
                inputForm.Text = "Edit Department";

                Label label = new Label() { Left = 10, Top = 10, Text = "New Department Name:", Width = 250 };
                TextBox textBox = new TextBox() { Left = 10, Top = 40, Width = 260, Text = oldName };
                Button okButton = new Button() { Text = "Update", Left = 100, Top = 70, Width = 80, Height = 40 };

                okButton.Click += (sender, e) => { inputForm.DialogResult = DialogResult.OK; inputForm.Close(); };

                inputForm.Controls.Add(label);
                inputForm.Controls.Add(textBox);
                inputForm.Controls.Add(okButton);
                inputForm.StartPosition = FormStartPosition.CenterParent;

                return inputForm.ShowDialog() == DialogResult.OK ? textBox.Text : null;
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
