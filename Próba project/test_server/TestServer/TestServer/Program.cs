using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Data.SQLite;
using System.Data;

namespace TestServer
{
    class Program
    {
        
        static byte[] s;
        static String data;
        static void Main(string[] args)
        {
            // string sqlcommand = "INSERT INTO user(id, name, username, password) VALUES (1, 'test123', 'teszt@freemail.hu', 'password');";
            // string sqlcommand1 = "SELECT * FROM user;";


            //sql_con = new SQLiteConnection("Data Source=test_user.db;Version=3;New=False;Compress=True;");

            using (SQLiteConnection con = new SQLiteConnection("Data Source=test_user.db;Version=3;New=False;Compress=True;"))
            {
                con.Open();
                string cmd = @"SELECT * FROM user;";
                using (SQLiteCommand command = new SQLiteCommand(cmd, con))
                {
                    using (SQLiteDataReader dr = command.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            data = dr.GetInt32(0) + dr.GetString(1) + dr.GetString(2) + dr.GetString(3);
                            s = Encoding.UTF8.GetBytes(data);
                            Console.WriteLine(data);
                        }
                    }

                }
            }
            UdpClient uc = new UdpClient();
            while (true)
            {
                uc.Send(s, s.Length, new IPEndPoint(IPAddress.Loopback, 2302));
            }
            
            Console.ReadKey();
        }
    }
}
