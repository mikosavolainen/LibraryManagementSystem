using Microsoft.VisualBasic.ApplicationServices;
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
using static Login.@public;

namespace LibraryManagementSystem
{
    public partial class mainpage : Form
    {
        private Dictionary<string, string> bookIdMap = new Dictionary<string, string>();

        public mainpage()
        {
            InitializeComponent();
            getbook();

            buttonSearch.Click += buttonSearch_Click;
            buttonLoan.Click += buttonLoan_Click;
        }

        private void getbook(string searchTerm = null)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(publix.Connect))
                {
                    string query = "SELECT * FROM books";
                    if (!string.IsNullOrEmpty(searchTerm))
                    {
                        query += " WHERE Title LIKE @SearchTerm OR Author LIKE @SearchTerm OR Publisher LIKE @SearchTerm";
                    }

                    var command = new MySqlCommand(query, connection);
                    if (!string.IsNullOrEmpty(searchTerm))
                    {
                        command.Parameters.AddWithValue("@SearchTerm", "%" + searchTerm + "%");
                    }

                    connection.Open();
                    MySqlDataReader reader = command.ExecuteReader();

                    listBox1.Items.Clear();
                    bookIdMap.Clear();
                    while (reader.Read())
                    {
                        var BookID = reader["BookID"].ToString();
                        var Title = reader["Title"].ToString();
                        var Author = reader["Author"].ToString();
                        var Publisher = reader["Publisher"].ToString();
                        var PublicationYear = reader["PublicationYear"].ToString();
                        var bookText = Title + " | " + Author + " | " + PublicationYear + " | " + Publisher;

                        listBox1.Items.Add(bookText);
                        bookIdMap[bookText] = BookID;
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

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = textBox1.Text;
            getbook(searchTerm);
        }

        private void LoanBook(string bookID)
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(publix.Connect))
                {
                    connection.Open();

                    // Check current number of loans for the user
                    string countQuery = "SELECT COUNT(*) FROM loans WHERE MemberID = @MemberID AND ReturnDate > NOW()";
                    var countCommand = new MySqlCommand(countQuery, connection);
                    countCommand.Parameters.AddWithValue("@MemberID", publix.ID);

                    int currentLoans = Convert.ToInt32(countCommand.ExecuteScalar());

                    if (currentLoans >= 5)
                    {
                        MessageBox.Show("You have already loaned the maximum number of books (5).", "Loan Limit Reached", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Proceed with loaning the book
                    DateTime loanDate = DateTime.Now;
                    DateTime returnDate = loanDate.AddMonths(1);
                    string query = "INSERT INTO loans (BookID, MemberID, LoanDate, ReturnDate) VALUES (@BookID, @MemberID, @LoanDate, @ReturnDate)";
                    var command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@BookID", bookID);
                    command.Parameters.AddWithValue("@MemberID", publix.ID);
                    command.Parameters.AddWithValue("@LoanDate", loanDate);
                    command.Parameters.AddWithValue("@ReturnDate", returnDate);

                    command.ExecuteNonQuery();
                    MessageBox.Show("Book loaned successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void buttonLoan_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string selectedBook = listBox1.SelectedItem.ToString();
                if (bookIdMap.TryGetValue(selectedBook, out string bookID))
                {
                    LoanBook(bookID);
                }
            }
            else
            {
                MessageBox.Show("Please select a book to loan.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void mainpage_Load(object sender, EventArgs e) { }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void button1_Click(object sender, EventArgs e)
        {
            var log = new Profile();
            log.Show();
            this.Hide();
        }
        
    }
}
