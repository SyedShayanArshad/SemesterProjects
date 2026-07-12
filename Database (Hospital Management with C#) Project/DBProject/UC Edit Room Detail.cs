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
    public partial class UC_Edit_Room_Detail : UserControl
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-2O42OM4;Initial Catalog=DBProject;Integrated Security=True;Encrypt=False");

        public void populateCBRoomID()
        {
            con.Open();
            string Query = "select RoomID from Room";
            SqlCommand cmd = new SqlCommand(Query, con);
            CBRoomID.Items.Clear();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                int roomID = reader.GetInt32(reader.GetOrdinal("RoomID"));
                CBRoomID.Items.Add(roomID);
            }
            con.Close();
        }
        public UC_Edit_Room_Detail()
        {
            InitializeComponent();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void UC_Edit_Room_Detail_Load(object sender, EventArgs e)
        {
            populateCBRoomID();
            CBRoomID.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBRoomID.SelectedItem == null)
            {
                return;
            }
            int selectedRoomID = (int)CBRoomID.SelectedItem;
            string Query = "select TotalRoom,Price,RoomType from Room where RoomID = " + selectedRoomID;
            SqlCommand cmd = new SqlCommand(Query, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                txtRoomType.Text = reader["RoomType"].ToString();
                txtRate.Text = reader["Price"].ToString();
                txtTotalRoom.Text = reader["TotalRoom"].ToString();
            }
            con.Close();
        }

        private void txtTotalRoom_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtRate_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (CBRoomID.SelectedItem == null)
            {
                MessageBox.Show("Please select a room to delete.");
                return;
            }
            int selectedRoomID = (int)CBRoomID.SelectedItem;
            con.Open();
            string Query = "delete from Room where RoomID = " + selectedRoomID;
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Room Delete Successfully.");
            txtRate.Clear();
            txtRoomType.Clear();
            txtTotalRoom.Clear();
            con.Close();
            CBRoomID.SelectedItem = null;
            populateCBRoomID();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (CBRoomID.SelectedItem == null)
            {
                MessageBox.Show("Please select a room to Update.");
                return;
            }
                con.Open();
            string Query = "UPDATE Room SET RoomType = '" + txtRoomType.Text + "', Price = '" + txtRate.Text + "', TotalRoom = '" + txtTotalRoom.Text + "' WHERE RoomID = " + CBRoomID.SelectedItem;
            SqlCommand cmd = new SqlCommand(Query, con);
                int rowsAffected = cmd.ExecuteNonQuery();
                MessageBox.Show("Room Modified Successfully.");
                txtRate.Clear();
                txtRoomType.Clear();
                txtTotalRoom.Clear();
                con.Close();
                CBRoomID.SelectedItem = null;
                populateCBRoomID();
        }
    }
}
