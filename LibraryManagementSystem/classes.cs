using System;
using MySql.Data.MySqlClient;

public class User
{
    public string Name { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }

    public string connecstri { get; set; } = "Server=176.93.48.21;Port=3308;Database=library;Uid=root;Pwd=1234592;";
}
