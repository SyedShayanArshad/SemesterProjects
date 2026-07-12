using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBProject
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Enter Username & Password");
            }
            else if(txtUserName.Text == "admin" && txtPassword.Text == "1111")
            {
                MessageBox.Show("Login Successfully....");
                Home obj = new Home();
                obj.Show();
                this.Hide();
            }
            else if (txtUserName.Text != "admin" || txtPassword.Text != "1111")
            {
                MessageBox.Show("Wrong Username or Password");
                txtUserName.Text = "";
                txtPassword.Text = "";
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
