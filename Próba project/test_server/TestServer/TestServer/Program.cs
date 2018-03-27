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
        //fields
        static byte[] s;
        static String data;

        static void Main(string[] args)
        {
            // string sqlcommand = "INSERT INTO user(id, name, username, password) VALUES (1, 'test123', 'teszt@freemail.hu', 'password');";
            // string sqlcommand1 = "SELECT * FROM user;";
            //sql_con = new SQLiteConnection("Data Source=test_user.db;Version=3;New=False;Compress=True;");

            //SQL CONNECTION
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
            //Küldés
            UdpClient uc = new UdpClient();
            Console.WriteLine("Írd be az ip címet amire küldenél!!");
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse(Console.ReadLine()), 2302);
            uc.Send(s, s.Length, iep);
            
            Console.ReadKey();
        }
    }
}
