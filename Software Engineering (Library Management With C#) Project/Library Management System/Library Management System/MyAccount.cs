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
    public partial class MyAccount : Form
    {
        public MyAccount()
        {
            InitializeComponent();
            LoadAccountDetails();
        }
        private void LoadAccountDetails()
        {
            Student student = Session.Instance.LoggedInStudent;
            if (student != null)
            {
                lblName.Text = $"Name : {student.StudentName}";
                lblRollNo.Text = $"Roll No : {student.RollNo}";
                lblGender.Text = $"Gender : {student.Gender}";
                lblUsername.Text = $"Username : {student.Username}";
                lblPassword.Text = $"Password : {student.Password}";
                lblDepartment.Text = $"Department : {student.Department}";
                lblMobileNo.Text = $"Mobile No : {student.Mobile}";
                lblAddress.Text = $"Address : {student.Address}";
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
        private void btnViewAccount_Click(object sender, EventArgs e)
        {
            panelAccountDetail.Show();
            panelChangePassword.Hide();
            panelEditAccount.Hide();
            LoadAccountDetails();
        }
        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            panelChangePassword.Show();
            panelAccountDetail.Hide();
            panelEditAccount.Hide();
        }
        private void btnEditDetail_Click(object sender, EventArgs e)
        {
            panelEditAccount.Show();
            panelChangePassword.Hide();
            panelAccountDetail.Hide();
            Student student = Session.Instance.LoggedInStudent;
            if (student != null)
            {
                txtRollNo.Text = student.RollNo;
                txtName.Text = student.StudentName;
                txtUsername.Text = student.Username;
                txtPassword.Text = student.Password;
                txtDepartment.Text = student.Department;
                txtGender.Text = student.Gender;
                txtMobileNo.Text = student.Mobile;
                txtAddress.Text = student.Address;
            }
        }
        private void btnHome_Click(object sender, EventArgs e)
        {
            StudentHome form = new StudentHome();
            form.Show();
            this.Hide();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Student student = Session.Instance.LoggedInStudent;
            if (student != null)
            {
                student.RollNo = txtRollNo.Text;
                student.StudentName = txtName.Text;
                student.Username = txtUsername.Text;
                student.Password = txtPassword.Text;
                student.Department = txtDepartment.Text;
                student.Gender = txtGender.Text;
                student.Mobile = txtMobileNo.Text;
                student.Address = txtAddress.Text;
                try
                {
                    var client = new MongoClient("mongodb://localhost:27017");
                    var database = client.GetDatabase("LibraryManagementSystem");
                    var collection = database.GetCollection<Student>("Students");
                    var filter = Builders<Student>.Filter.Eq("RollNo", student.RollNo);
                    var update = Builders<Student>.Update
                        .Set("StudentName", student.StudentName)
                        .Set("Username", student.Username)
                        .Set("Password", student.Password)
                        .Set("Department", student.Department)
                        .Set("Gender", student.Gender)
                        .Set("Mobile", student.Mobile)
                        .Set("Address", student.Address);
                    collection.UpdateOne(filter, update);
                    MessageBox.Show("Account details updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAccountDetails();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error updating details in the database: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnChangePass_Click_1(object sender, EventArgs e)
        {
            Student student = Session.Instance.LoggedInStudent;
            if (student != null)
            {
                if (txtOldPassword.Text == student.Password)
                {
                    if (txtNewPassword.Text == txtConfirmPassword.Text)
                    {
                        student.Password = txtNewPassword.Text;
                        try
                        {
                            var client = new MongoClient("mongodb://localhost:27017");
                            var database = client.GetDatabase("LibraryManagementSystem");
                            var collection = database.GetCollection<Student>("Students");
                            var filter = Builders<Student>.Filter.Eq("RollNo", student.RollNo);
                            var update = Builders<Student>.Update.Set("Password", student.Password);
                            collection.UpdateOne(filter, update);
                            MessageBox.Show("Password changed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error updating password in the database: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("New Password and Confirm Password do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Old Password is incorrect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void MyAccount_Load(object sender, EventArgs e)
        {
            panelAccountDetail.Show();
            panelChangePassword.Hide();
            panelEditAccount.Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Instance.ClearSession();
            LoginPage loginForm = new LoginPage();
            this.Hide();
            loginForm.Show();
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

        private void btnPenalty_Click(object sender, EventArgs e)
        {
            StudentPenalty form = new StudentPenalty();
            form.Show();
            this.Hide();
        }
    }
}
