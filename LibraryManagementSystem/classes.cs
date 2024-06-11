using System;
using MySql.Data.MySqlClient;

public class User
{
    private string Lastname;
    private string Firstname;
    private string email;
    private string password;
    private string username;
    private string phonenumber;

    public User(string username, string firstname, string lastname, string email, string phonenumber, string password)
    {
        this.username = username;
        this.Firstname = firstname;
        this.Lastname = lastname;
        this.email = email;
        this.phonenumber = phonenumber;
        this.password = password;
    }

    public bool Register()
    {
        string connectionString = "Server=37.136.135.132;Port=3308;Database=library;Uid=root;Pwd=1234592;";

        try
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string selectBooksQuery = "SELECT * FROM Books";
                using (MySqlCommand command = new MySqlCommand(selectBooksQuery, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"BookID: {reader["BookID"]}, ISBN: {reader["ISBN"]}, Title: {reader["Title"]}, Author: {reader["Author"]}, Publisher: {reader["Publisher"]}, PublicationYear: {reader["PublicationYear"]}, Category: {reader["Category"]}, AvailableCopies: {reader["AvailableCopies"]}");
                        }
                    }
                }
            }
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            return false;
        }
    }
}

class Program
{
    static void Main()
    {
        User newUser = new User("username", "firstname", "lastname", "email@example.com", "1234567890", "password");
        newUser.Register();
    }
}
