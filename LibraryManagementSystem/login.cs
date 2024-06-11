using MySql.Data.MySqlClient;
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
                    string query = "SELECT * FROM members WHERE username = @UserName AND password = @Password";
                    var command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Username", User);
                    command.Parameters.AddWithValue("@Password", Pass);
                    connection.Open();

                    MySqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {

                        string username = reader["UserName"].ToString();
                        string email = "reader";
                        string firstname = reader["FirstName"].ToString();
                        string lastname = reader["LastName"].ToString();
                        string phoneNumber = reader["PhoneNumber"].ToString();
                        string password = reader["Password"].ToString();

                        publix.Name = username;
                        publix.Password = password;
                        publix.Email = email;
                        publix.PhoneNumber = phoneNumber;
                        publix.Firstname = firstname;
                        publix.Lastname = lastname;

                        var log = new Profile();
                        log.Show();
                        this.Hide();

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
                if (ex.Message == "Object cannot be cast from DBNull to other types.")
                {
                    logins(textBox1.Text, textBox2.Text);
                }
                else
                {
                    Console.WriteLine(ex.Message);
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            logins(textBox1.Text, textBox2.Text);
        }
    }
}
