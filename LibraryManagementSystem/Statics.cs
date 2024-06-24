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
    public partial class Statics : Form
    {
        public Statics()
        {
            InitializeComponent();
            LoadTopUsers();
            LoadTopBooks();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void LoadTopUsers()
        {
            string query = @"
                SELECT m.FirstName, m.LastName, COUNT(l.LoanID) AS TotalBooks
                FROM members m
                JOIN loans l ON m.MemberID = l.MemberID
                GROUP BY m.FirstName, m.LastName
                ORDER BY TotalBooks DESC
                LIMIT 10"
            ;

            using (MySqlConnection connection = new MySqlConnection(publix.Connect))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable table = new DataTable();

                adapter.Fill(table);

                foreach (DataRow row in table.Rows)
                {
                    string fullName = $"{row["FirstName"]} {row["LastName"]}";
                    int totalBooks = Convert.ToInt32(row["TotalBooks"]);
                    string displayText = $"{fullName} ({totalBooks} books)";
                    listBox1.Items.Add(displayText);
                }
            }
        }

        private void LoadTopBooks()
        {
            string query = @"
                SELECT b.Title, COUNT(l.LoanID) AS TotalLoans
                FROM books b
                JOIN loans l ON b.BookID = l.BookID
                GROUP BY b.Title
                ORDER BY TotalLoans DESC
                LIMIT 10"
            ;

            using (MySqlConnection connection = new MySqlConnection(publix.Connect))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable table = new DataTable();

                adapter.Fill(table);

                foreach (DataRow row in table.Rows)
                {
                    string bookTitle = Convert.ToString(row["Title"]);
                    int totalLoans = Convert.ToInt32(row["TotalLoans"]);
                    string displayText = $"{bookTitle} ({totalLoans} loans)";
                    listBox2.Items.Add(displayText);
                }
            }
        }
    }
}
