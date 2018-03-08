using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace sPeachServer
{
    class Program
    {
        static void Main(string[] args)
        {
        }
        
        static void checkLogin(string username, string password)
        {
            string data = "";
            using (SQLiteConnection con = new SQLiteConnection("Data Source=server.db;Version=3;New=False;Compress=True;"))
            {
                con.Open();
                string cmd = @"SELECT name FROM user WHERE password LIKE " + password + " AND name LIKE " + username + ";";
                using (SQLiteCommand command = new SQLiteCommand(cmd, con))
                {
                    using (SQLiteDataReader dr = command.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            data = dr.GetString(0);
                        }
                    }

                }
                con.Close();
            }
        }
    }
}
