using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DBProject
{
    public partial class UserControl1 : UserControl
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-2O42OM4;Initial Catalog=DBProject;Integrated Security=True;Encrypt=False");

        public UserControl1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtRoomType.Text == "" || txtTotalRoom.Text == "" || txtRoomRate.Text == "")
            {
                MessageBox.Show("Missing Information...Fill All Details!!!");
            }
            else
            {
                con.Open();
                string Query = "insert into Room values('" + txtRoomID.Text + "','" + txtRoomType.Text + "','" + txtTotalRoom.Text + "','" + txtRoomRate.Text + "')";
                SqlCommand cmd = new SqlCommand(Query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Room Added Successfully.");
                con.Close();
                txtRoomID.Clear();
                txtRoomRate.Clear();
                txtRoomType.Clear();
                txtTotalRoom.Clear();
            }
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
