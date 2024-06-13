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
    public partial class Profile : Form
    {
        public Profile()
        {
            InitializeComponent();
            Lataatiedot();
        }


        private void Lataatiedot()
        {
            string memberid = publix.ID;
            string query = "SELECT FirstName, LastName, UserName, EmailAddress, Address, PhoneNumber FROM members WHERE memberid = @MemberID";

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
                        MessageBox.Show("Saved successfully.");
                    }
                    else
                    {
                        MessageBox.Show("No data was updated.");
                    }
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
            button2.Visible = true;
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            maskedTextBox1.Enabled = true;

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
    }
}
