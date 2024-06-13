using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.Text;
using static Login.@public;

namespace LibraryManagementSystem
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void logins(string User, string Pass)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(publix.Connect))
                {
                    string query = "SELECT * FROM members WHERE username = @UserName";
                    var command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Username", User);
                    connection.Open();

                    MySqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string storedPasswordHash = reader["Password"].ToString();
                        string inputPasswordHash = HashPassword(Pass);

                        if (storedPasswordHash == inputPasswordHash)
                        {
                            string username = reader["UserName"].ToString();
                            string email = "reader";
                            string firstname = reader["FirstName"].ToString();
                            string lastname = reader["LastName"].ToString();
                            string phoneNumber = reader["PhoneNumber"].ToString();

                            publix.Name = username;
                            publix.Password = storedPasswordHash;
                            publix.Email = email;
                            publix.PhoneNumber = phoneNumber;
                            publix.Firstname = firstname;
                            publix.Lastname = lastname;

                            var log = new mainpage();
                            log.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    reader.Close();
                }
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

        private void button1_Click(object sender, EventArgs e)
        {
            logins(textBox1.Text, maskedTextBox1.Text);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
