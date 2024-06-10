using System;
using System.Data.SqlClient;
using System.IO;

public abstract class Entity
{
    public abstract void SaveToDatabase(SqlConnection connection);
    public abstract void SaveToFile(string filePath);
}

public abstract class User : Entity
{
    private string name;
    private string email;

    public User(string name, string email)
    {
        this.name = name;
        this.email = email;
    }

    public string GetName()
    {
        return name;
    }

    public void SetName(string name)
    {
        this.name = name;
    }

    public string GetEmail()
    {
        return email;
    }

    public void SetEmail(string email)
    {
        this.email = email;
    }

    public override void SaveToFile(string filePath)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine($"Name: {name}, Email: {email}");
            }
            Console.WriteLine("User data saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while saving user data: {ex.Message}");
        }
    }

    public override void SaveToDatabase(SqlConnection connection)
    {
        try
        {
            string query = "INSERT INTO Users (Name, Email) VALUES (@Name, @Email)";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Email", email);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
            Console.WriteLine("User data saved to database successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while saving user data to database: {ex.Message}");
        }
    }

    public abstract void DisplayInfo();
}

public abstract class Book : Entity
{
    private string title;
    private string author;

    public Book(string title, string author)
    {
        this.title = title;
        this.author = author;
    }

    public string GetTitle()
    {
        return title;
    }

    public void SetTitle(string title)
    {
        this.title = title;
    }

    public string GetAuthor()
    {
        return author;
    }

    public void SetAuthor(string author)
    {
        this.author = author;
    }

    public override void SaveToFile(string filePath)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine($"Title: {title}, Author: {author}");
            }
            Console.WriteLine("Book data saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while saving book data: {ex.Message}");
        }
    }

    public override void SaveToDatabase(SqlConnection connection)
    {
        try
        {
            string query = "INSERT INTO Books (Title, Author) VALUES (@Title, @Author)";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Title", title);
                command.Parameters.AddWithValue("@Author", author);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
            Console.WriteLine("Book data saved to database successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while saving book data to database: {ex.Message}");
        }
    }

    public abstract void DisplayInfo();
}
