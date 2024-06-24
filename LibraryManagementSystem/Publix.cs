using System;
using MySql.Data.MySqlClient;

namespace Login
{
    internal class @public
    {
        public static class publix
        {
            public static string ID { get; set; } = System.Windows.Forms.SystemInformation.ComputerName;
            public static string Name { get; set; } = System.Windows.Forms.SystemInformation.ComputerName;
            public static string Firstname { get; set; }
            public static string Lastname { get; set; }
            public static string Password { get; set; }
            public static string Email { get; set; }
            public static string PhoneNumber { get; set; }



            //public static string Connect { get; set; } = "server=188.67.164.224;port=3308;database=library;uid=root;password=1234592";

            public static string Connect { get; set; } = "server=192.168.1.129;port=3308;database=library;uid=root;password=1234592";
        }
    }
}
