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
        public mainpage()
        {
            InitializeComponent();
            getbook();
        }
        private void getbook()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(publix.Connect))
                {
                    string query = "SELECT * FROM books";
                    var command = new MySqlCommand(query, connection);
                    connection.Open();

                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read()) 
                    {
                        var Title = reader["Title"].ToString();
                        var Author = reader["Author"].ToString();
                        var Publisher = reader["Publisher"].ToString();
                        var PublicationYear = reader["PublicationYear"].ToString();
                        var bookText = Title + " | " + Author + " | " + PublicationYear + " | " + Publisher;


                        listBox1.Items.Add(bookText);

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
        private void mainpage_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var log = new Profile();
            log.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("dont click me");
        }
    }
}
