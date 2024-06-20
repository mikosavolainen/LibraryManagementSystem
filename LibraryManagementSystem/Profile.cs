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
using System.Net;

namespace LibraryManagementSystem
{
    public partial class Profile : Form
    {
        private Dictionary<string, string> bookIdMap = new Dictionary<string, string>();
        public Profile()
        {
            InitializeComponent();
            Lataatiedot();
            LoadLoans();
            
        }


        private void Lataatiedot()
        {
            string memberid = publix.ID;
            string query = "SELECT FirstName, LastName, UserName, EmailAddress, Address, PhoneNumber, Role FROM members WHERE memberid = @MemberID";

            using (MySqlConnection connection = new MySqlConnection(publix.Connect))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@MemberID", memberid);
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

                        string role = reader["Role"].ToString();
                        if (role == "admin")
                        {
                            button6.Visible = true; 
                        }
                        else
                        {
                            button6.Visible = false; 
                        }
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
                string.IsNullOrWhiteSpace(maskedTextBox1.Text))
            {
                MessageBox.Show("Kaikki kentät on täytettävä.");
                return;
            }

            string memberid = publix.ID;
            string query = "UPDATE members SET FirstName = @FirstName, LastName = @LastName, UserName = @UserName, EmailAddress = @EmailAddress, Address = @Address, PhoneNumber = @PhoneNumber WHERE memberid = @MemberID";

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




        private void LoadLoans()
        {
            listBox1.Items.Clear();
            string memberid = publix.ID;
            string query = "SELECT b.Title, l.LoanDate, l.ReturnDate FROM loans l INNER JOIN books b ON l.BookID = b.BookID WHERE l.MemberID = @MemberID";

            using (MySqlConnection connection = new MySqlConnection(publix.Connect))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@MemberID", memberid);
                    connection.Open();

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        bookIdMap.Clear();
                        while (reader.Read())
                        {
                            string title = reader.GetString("Title");
                            DateTime loanDate = reader.GetDateTime("LoanDate");
                            DateTime? returnDate = reader.IsDBNull(reader.GetOrdinal("ReturnDate")) ? (DateTime?)null : reader.GetDateTime("ReturnDate");

                            string item = $"Book Name: {title} | Loan Date: {loanDate.ToShortDateString()} | Return Date: {(returnDate.HasValue ? returnDate.Value.ToShortDateString() : "Ei tiedossa")}";
                            listBox1.Items.Add(item);
                        }
                    }
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



        private void VerifyUser()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(publix.Connect))
                {
                    string memberid = publix.ID;
                    string query = "SELECT Password FROM members WHERE memberid = @MemberID";
                    var command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MemberID", memberid);
                    connection.Open();

                    MySqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string storedPasswordHash = reader["Password"].ToString();
                        string inputPasswordHash = HashPassword(maskedTextBox2.Text);

                        if (storedPasswordHash == inputPasswordHash)
                        {
                            publix.Password = storedPasswordHash;

                            button2.Visible = true;
                            textBox1.Enabled = true;
                            textBox2.Enabled = true;
                            textBox3.Enabled = true;
                            textBox4.Enabled = true;
                            textBox5.Enabled = true;
                            maskedTextBox1.Enabled = true;
                        }
                        else
                        {
                            MessageBox.Show("Invalid password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("User ID not found.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            maskedTextBox2.Visible = true;
            label7.Visible = true;
            VerifyUser();
        }



        private void button2_Click_1(object sender, EventArgs e)
        {
            Tallennatiedot();

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
            publix.ID = null;
            publix.Name = null;
            publix.Password = null;
            publix.Email = null;
            publix.PhoneNumber = null;
            publix.Firstname = null;
            publix.Lastname = null;


            var log = new login();
            log.Show();
            this.Hide();
        }


        private void button5_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Please select a book to return.");
                return;
            }

            string selectedItem = listBox1.SelectedItem.ToString();
            string[] itemParts = selectedItem.Split('|');
            if (itemParts.Length < 3)
            {
                MessageBox.Show("The selected item is in an incorrect format.");
                return;
            }


            string titlePart = itemParts[0].Trim();
            string bookTitle = titlePart.Replace("Book Name: ", "").Trim();
            string memberId = publix.ID;

            string query2 = "UPDATE books SET AvailableCopies = AvailableCopies + 1 WHERE BookID = (SELECT BookID FROM books WHERE Title = @BookTitle)";
            using (MySqlConnection connection = new MySqlConnection(publix.Connect))
            {
               connection.Open();
               
            }
            
            string query = "DELETE FROM loans WHERE BookID = (SELECT BookID FROM books WHERE Title = @BookTitle) AND MemberID = @MemberID";
            string report = "INSERT INTO reports (ReportType, GeneratedDate, Details, Sender) VALUES (@Type, @Date, @Details, @Sender)";
            using (MySqlConnection connection = new MySqlConnection(publix.Connect))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@BookTitle", bookTitle);
                command.Parameters.AddWithValue("@MemberID", memberId);
                var updateCommand = new MySqlCommand(query2, connection);
                updateCommand.Parameters.AddWithValue("@BookTitle", bookTitle);
                MySqlCommand repo = new MySqlCommand(report, connection);
                repo.Parameters.AddWithValue("@Type","Return");
                repo.Parameters.AddWithValue("@Date", DateTime.Now);
                repo.Parameters.AddWithValue("@Details",publix.Name+" Returned book: "+bookTitle);
                repo.Parameters.AddWithValue("@Sender",publix.ID);
                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                repo.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Book returned successfully.");
                    LoadLoans();
                }
                else
                {
                    MessageBox.Show("No loan record found for the selected book.");
                }
                updateCommand.ExecuteNonQuery();

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var log = new Admin();
            log.Show();
            this.Hide();
        }
    }
}
