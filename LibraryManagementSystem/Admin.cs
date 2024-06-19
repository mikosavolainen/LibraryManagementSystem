using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using static Login.@public;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace LibraryManagementSystem
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
            LoadUsers();
        }

        private void LoadUsers()
        {
            listBox1.Items.Clear();
            string query = "SELECT MemberID, FirstName, LastName FROM members";

            using (MySqlConnection connection = new MySqlConnection(publix.Connect))
            {
                MySqlCommand command = new MySqlCommand(query, connection);

                try
                {
                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        string memberID = reader["MemberID"].ToString();
                        string firstName = reader["FirstName"].ToString();
                        string lastName = reader["LastName"].ToString();
                        string item = $"{firstName} {lastName} ({memberID})";
                        listBox1.Items.Add(item);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string selectedItem = listBox1.SelectedItem.ToString();
                string memberID = selectedItem.Substring(selectedItem.LastIndexOf('(') + 1).TrimEnd(')');

                LoadUserDetails(memberID);
            }
        }

        private void LoadUserDetails(string memberID)
        {
            string query = "SELECT FirstName, LastName, UserName, EmailAddress, Address, PhoneNumber FROM members WHERE MemberID = @MemberID";

            using (MySqlConnection connection = new MySqlConnection(publix.Connect))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@MemberID", memberID);

                try
                {
                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        textBox1.Enabled = false;
                        textBox2.Enabled = false;
                        textBox3.Enabled = false;
                        textBox4.Enabled = false;
                        textBox5.Enabled = false;
                        maskedTextBox1.Enabled = false;

                        textBox1.Text = reader["UserName"].ToString();
                        textBox2.Text = reader["LastName"].ToString();
                        textBox3.Text = reader["FirstName"].ToString();
                        textBox4.Text = reader["EmailAddress"].ToString();
                        textBox5.Text = reader["Address"].ToString();
                        maskedTextBox1.Text = reader["PhoneNumber"].ToString();
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }







        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Profile_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }



        private void button1_Click(object sender, EventArgs e)
        {

            maskedTextBox2.Visible = true;
            label7.Visible = true;
        }



        private void button2_Click_1(object sender, EventArgs e)
        {

            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            maskedTextBox1.Enabled = false;
            button2.Visible = false;
        }

        private void maskedTextBox2_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var log = new mainpage();
            log.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            publix.ID = "0";
            publix.Name = "0";
            publix.Password = "0";
            publix.Email = "0";
            publix.PhoneNumber = "0";
            publix.Firstname = "0";
            publix.Lastname = "0";


            var log = new login();
            log.Show();
            this.Hide();
        }


        private void button5_Click(object sender, EventArgs e)
        {
        }

    }
}
