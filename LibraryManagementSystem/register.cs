using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Login.@public;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LibraryManagementSystem
{
    public partial class register : Form
    {
        public register()
        {
            InitializeComponent();
        }

        private void Registers(string firstName, string lastName, string userName, string emailAddress, string Address, string phoneNumber, string password)
        {
            try
            {
                if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(userName) ||
                    string.IsNullOrEmpty(emailAddress) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("All fields except Phone Number must be filled in.");
                    return;
                }

                if (maskedTextBox1.Text != maskedTextBox3.Text)
                {
                    MessageBox.Show("Passwords do not match. Please re-enter the password.");
                    return;
                }

                using (MySqlConnection connection = new MySqlConnection(publix.Connect))
                {
                    connection.Open();

                    string checkQuery = "SELECT UserName FROM members WHERE UserName=@UserName";
                    MySqlCommand checkCommand = new MySqlCommand(checkQuery, connection);
                    checkCommand.Parameters.AddWithValue("@UserName", userName);
                    object result = checkCommand.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        MessageBox.Show("Username is already in use. Please choose a different username.");
                        return;
                    }


                    string hashedPassword = HashPassword(password);

                    string query = "INSERT INTO members (FirstName, LastName, UserName, EmailAddress, Address, PhoneNumber, Password) VALUES (@FirstName, @LastName, @UserName, @EmailAddress, @Address, @PhoneNumber, @Password)";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@LastName", lastName);
                    command.Parameters.AddWithValue("@UserName", userName);
                    command.Parameters.AddWithValue("@EmailAddress", emailAddress);
                    command.Parameters.AddWithValue("@Address", Address);

                    if (!string.IsNullOrEmpty(phoneNumber))
                    {
                        command.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@PhoneNumber", DBNull.Value);
                    }

                    command.Parameters.AddWithValue("@Password", hashedPassword);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("User registered successfully.");
                    }
                    else
                    {
                        MessageBox.Show("Failed to register user.");
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("MySQL Exception: " + ex.Message);
                MessageBox.Show("MySQL Exception: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }



        private void register_Load(object sender, EventArgs e)
        {

        }



        private void maskedTextBox3_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var log = new login();
            log.Show();
            this.Hide();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Registers(textBox4.Text, textBox3.Text, textBox2.Text, textBox1.Text, textBox5.Text, maskedTextBox2.Text, maskedTextBox1.Text);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
