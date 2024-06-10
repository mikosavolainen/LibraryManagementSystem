using System;
using System.Data.SqlClient;
using System.IO;

public class User
{
    private string Lastname;
    private string Firstname;
    private string email;
    private string password;
    private string username;
    private string phonenumber;
    

    public Register(string username, string firstname, string lastname, string email, string phonenumber, string password)
    {
        string connectionString = "Server=your_server_name;Database=LibraryManagement;User Id=your_username;Password=your_password;";

        using (Sqlconnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string selectBooksQuery = "SELECT * FROM Books";
            using (SqlCommand command = new SqlCommand(selectBooksQuery, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
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

}
