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
        static SQLite sql = new SQLite();
        static Dictionary<uint, User> clients = new Dictionary<uint, User>();
        static byte[] loginResponse;

        static void Main(string[] args)
        {
            Thread receiver = new Thread(receiverThread);
            receiver.Start();

        }
        static void receiverThread()
        {
            Connection con = new Connection();
            int messageType;
            con.tcpListener.Start();

            while (true)
            {
                Socket socket = con.tcpListener.AcceptSocket();
                NetworkStream networkStream = new NetworkStream(socket);
                con.binaryReader = new BinaryReader(networkStream);


                messageType = con.binaryReader.ReadByte();

                switch ((UserMessageType)messageType)
                {
                    case UserMessageType.login_Data:
                        string username_login = con.binaryReader.ReadString();
                        string password_login = con.binaryReader.ReadString();
                        
                        uint id = 0;

                        string command = "SELECT username, password FROM user WHERE username = '" + username_login + "' AND password = '" + password_login + "';";

                        sql.loginSelect(command);

                        if (sql.username == username_login
                            &&
                            sql.password == password_login)
                        {
                            clients.Add(id, new User() {ipAddress = socket.RemoteEndPoint.ToString(), username = username_login, picture =  });
                        }

                        break;
                    case UserMessageType.registration_Data:
                        string username_reg = con.binaryReader.ReadString();
                        string email_reg = con.binaryReader.ReadString();
                        string password_reg = con.binaryReader.ReadString();

                        string command_reg = "INSERT INTO user (id, username, password, email) VALUES (NULL, " + username_reg + ", " + password_reg + ", " + email_reg + ");";



                        sql.executeInsert(command_reg);

                        break;
                    case UserMessageType.text_Message:

                        break;
                    case UserMessageType.user_Data:

                        break;
                    case UserMessageType.voice_Message:

                        break;
                }
            }


        }
    }
}
