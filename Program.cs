using System;
using System.Data.SqlClient;

namespace SQLi_1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (args.Length < 2)
                {
                    Console.WriteLine("Usage: program <username> <password>");
                    return;
                }

                var user = args[0];
                var pwd = Encrypt(args[1]);
                Login(user, pwd);
            }
            catch
            {
                Console.WriteLine("An error has occurred !!");
            }
        }

        private static string Encrypt(string plain)
        {
            return plain;
        }

        private static void Login(string username, string password)
        {
            try
            {
                using (var conn = new SqlConnection("conn..."))
                {
                    conn.Open();

                    const string sql =
                        "SELECT * FROM Users WHERE username = @username AND pwd = @password";

                    using (var cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add("@username", System.Data.SqlDbType.NVarChar, 100).Value = username;
                        cmd.Parameters.Add("@password", System.Data.SqlDbType.NVarChar, 256).Value = password;

                        cmd.ExecuteScalar();
                    }
                }
            }
            catch
            {
                Console.WriteLine("An error has occurred !!");
            }
        }
    }
}