using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;
using static Login.@public;

namespace LibraryManagementSystem
{
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
            LoadUsers();
            listBox1.SelectedIndexChanged += new EventHandler(listBox1_SelectedIndexChanged);
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
            if (listBox1.SelectedIndex == -1)
                return;

            string selectedItem = listBox1.SelectedItem.ToString();
            string memberID = selectedItem.Substring(selectedItem.LastIndexOf('(') + 1).TrimEnd(')');

            LoadUserDetails(memberID);
        }

        private void LoadUserDetails(string memberID)
        {
            string query = "SELECT FirstName, LastName, UserName, EmailAddress, Address, PhoneNumber, Role FROM members WHERE MemberID = @MemberID";

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
                        textBox1.Text = reader["UserName"].ToString();
                        textBox2.Text = reader["LastName"].ToString();
                        textBox3.Text = reader["FirstName"].ToString();
                        textBox4.Text = reader["EmailAddress"].ToString();
                        textBox5.Text = reader["Address"].ToString();
                        maskedTextBox1.Text = reader["PhoneNumber"].ToString();
                        comboBox1.SelectedItem = reader["Role"].ToString(); 
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void Tallennatiedot()
        {
            if (string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox4.Text) ||
                string.IsNullOrWhiteSpace(textBox5.Text) ||
                string.IsNullOrWhiteSpace(maskedTextBox1.Text) ||
                comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Kaikki kentät on täytettävä.");
                return;
            }

            string selectedItem = listBox1.SelectedItem.ToString();
            string memberID = selectedItem.Substring(selectedItem.LastIndexOf('(') + 1).TrimEnd(')');
            string memberid = memberID;
            string query = "UPDATE members SET FirstName = @FirstName, LastName = @LastName, UserName = @UserName, EmailAddress = @EmailAddress, Address = @Address, PhoneNumber = @PhoneNumber, Role = @Role WHERE memberid = @MemberID";

            using (MySqlConnection connection = new MySqlConnection(publix.Connect))
            {
                MySqlCommand command = new MySqlCommand(query, connection);

                command.Parameters.AddWithValue("@MemberID", memberid);
                command.Parameters.AddWithValue("@FirstName", textBox3.Text);
                command.Parameters.AddWithValue("@LastName", textBox2.Text);
                command.Parameters.AddWithValue("@UserName", textBox1.Text);
                command.Parameters.AddWithValue("@EmailAddress", textBox4.Text);
                command.Parameters.AddWithValue("@Address", textBox5.Text);
                command.Parameters.AddWithValue("@PhoneNumber", maskedTextBox1.Text);
                command.Parameters.AddWithValue("@Role", comboBox1.SelectedItem.ToString());

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Tallennettu onnistuneesti.");
                    }
                    else
                    {
                        MessageBox.Show("Tietoja ei päivitetty.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Virhe: " + ex.Message);
                }
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Tallennatiedot();

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

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
