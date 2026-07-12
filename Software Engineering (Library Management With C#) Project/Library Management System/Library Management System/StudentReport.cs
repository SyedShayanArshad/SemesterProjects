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
    public partial class StudentReport : Form
    {
        private List<Student> _students = new List<Student>();
        private string _selectedDepartment = null;
        private string _selectedRollNo = null;
        public StudentReport()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private async void StudentReport_Load(object sender, EventArgs e)
        {
            detailPanel.Hide();
            DGVStudentReport.DefaultCellStyle.ForeColor = Color.Black;

            var client = new MongoClient("mongodb://localhost:27017"); // Connect to MongoDB
            var database = client.GetDatabase("LibraryManagementSystem"); // Access your database
            var collection = database.GetCollection<Student>("Students"); // Access the Students collection
            _students = await collection.Find(FilterDefinition<Student>.Empty).ToListAsync();
            LoadStudentData();
            LoadComboBoxData();
        }
        private void LoadStudentData(string department = null, string rollNo = null)
        {
            DGVStudentReport.Rows.Clear();
            var filteredStudents = _students.AsEnumerable();

            if (!string.IsNullOrEmpty(department))
            {
                filteredStudents = filteredStudents.Where(s => s.Department == department);
            }

            if (!string.IsNullOrEmpty(rollNo))
            {
                filteredStudents = filteredStudents.Where(s => s.RollNo == rollNo);
            }
            foreach (var student in filteredStudents)
            {
                int rowIndex = DGVStudentReport.Rows.Add();
                DGVStudentReport.Rows[rowIndex].Cells["RollNo"].Value = student.RollNo;
                DGVStudentReport.Rows[rowIndex].Cells["StuName"].Value = student.StudentName;
                DGVStudentReport.Rows[rowIndex].Cells["Department"].Value = student.Department;
                DGVStudentReport.Rows[rowIndex].Cells["Mobile"].Value = student.Mobile;
                DGVStudentReport.Rows[rowIndex].Cells["View"].Value = "View"; // Button text
            }
            DGVStudentReport.ClearSelection();
        }

        private void LoadComboBoxData()
        {
            var departments = _students.Select(s => s.Department).Distinct().ToList();
            cbDepartment.Items.AddRange(departments.ToArray());
            var rollNos = _students.Select(s => s.RollNo).Distinct().ToList();
            cbRollNo.Items.AddRange(rollNos.ToArray());
        }
        private void DGVStudentReport_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && DGVStudentReport.Columns[e.ColumnIndex].Name == "View")
            {
                ReportPanel.Hide();
                detailPanel.Show();
                string selectedRollNo = DGVStudentReport.Rows[e.RowIndex].Cells["RollNo"].Value.ToString();
                var selectedStudent = _students.Find(student => student.RollNo == selectedRollNo);

                if (selectedStudent != null)
                {
                    lblName.Text = $"Name: {selectedStudent.StudentName}";
                    lblRollNo.Text = $"Roll No: {selectedStudent.RollNo}";
                    lblGender.Text = $"Gender: {selectedStudent.Gender}";
                    lblDepartment.Text = $"Department: {selectedStudent.Department}";
                    lblMobile.Text = $"Mobile: {selectedStudent.Mobile}";
                    lblAddress.Text = $"Address: {selectedStudent.Address}";
                    lblUsername.Text = $"Username: {selectedStudent.Username}";
                    lblPassword.Text = $"Password: {selectedStudent.Password}";
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            detailPanel.Hide();
            ReportPanel.Show();
        }

        private void cbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedDepartment = cbDepartment.SelectedItem?.ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedRollNo = cbRollNo.SelectedItem?.ToString();
        }

        private void btnDepartView_Click(object sender, EventArgs e)
        {
            LoadStudentData(department: _selectedDepartment);

        }

        private void btnRollNoView_Click(object sender, EventArgs e)
        {
            LoadStudentData(rollNo: _selectedRollNo);

        }

        private void btnResetFilter_Click(object sender, EventArgs e)
        {
            _selectedDepartment = null;
            _selectedRollNo = null;
            cbDepartment.SelectedIndex = -1;
            cbRollNo.SelectedIndex = -1;

            LoadStudentData();
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
