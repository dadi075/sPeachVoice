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
        static Dictionary<uint, User> chat_members = new Dictionary<uint, User>();
        static byte[] loginResponse;
        static uint id = 0;

        static void Main(string[] args)
        {

            Thread receiver = new Thread(receiverThread);
            receiver.Start();

        }
        static void receiverThread()
        {
            Connection con = new Connection();
            Console.WriteLine("sad");

            con.tcpListener.Start();
            Console.WriteLine("asd");
            while (true)
            {
                TcpClient acceptedClient = con.tcpListener.AcceptTcpClient();

                Thread listenForMessageThread = new Thread(new ParameterizedThreadStart(listenForMessage));
                listenForMessageThread.Start(acceptedClient);
            }
        }
        static void listenForMessage(Object accepted)
        {
            TcpClient acceptedClient = (TcpClient)accepted;
            NetworkStream networkStream = acceptedClient.GetStream();

            using (BinaryReader binaryReader = new BinaryReader(networkStream))
            {
                using (BinaryWriter binaryWriter = new BinaryWriter(networkStream))
                {
                    while (true) {
                        if (acceptedClient.Available > 0) {
                            int messageType = binaryReader.ReadByte();

                            switch ((UserMessageType)messageType)
                            {
                                case UserMessageType.login_Data:
                                    string username_login = binaryReader.ReadString();
                                    string password_login = binaryReader.ReadString();
                                    int pictureArrayLength = binaryReader.ReadInt32();
                                    byte[] pictureArray = binaryReader.ReadBytes(pictureArrayLength);


                                    string command = "SELECT username, password FROM user WHERE username = '" + username_login + "' AND password = '" + password_login + "';";

                                    sql.loginSelect(command);

                                    if (sql.username == username_login
                                        &&
                                        sql.password == password_login)
                                    {
                                        clients.Add(id, new User() { username = username_login, picture = pictureArray, tcpClient = acceptedClient });
                                        id++;

                                        binaryWriter.Write((byte)ServerMessageTypes.login_response);
                                        binaryWriter.Write(1);
                                        binaryWriter.Flush();
                                        Console.WriteLine("Sikeres Login, " + username_login + " nevű felhasználó csatlakozott");
                                    }
                                    else
                                    {
                                        binaryWriter.Write((byte)ServerMessageTypes.login_response);
                                        binaryWriter.Write(0);
                                        binaryWriter.Flush();
                                        Console.WriteLine("Nem sikeres Login");
                                    }
                                    break;
                                case UserMessageType.registration_Data:
                                    string username_reg = binaryReader.ReadString();
                                    string email_reg = binaryReader.ReadString();
                                    string password_reg = binaryReader.ReadString();

                                    string command_reg = "INSERT INTO user (id, username, password, email) VALUES (NULL, '" + username_reg + "', '" + password_reg + "', '" + email_reg + "');";



                                    if (sql.executeInsert(command_reg) == 1)
                                    {
                                        binaryWriter.Write((byte)ServerMessageTypes.register_response);
                                        binaryWriter.Write(1);
                                        binaryWriter.Flush();
                                        Console.WriteLine(username_reg + " nevű felhasználó sikeresen regisztrált");
                                    }
                                    else
                                    {
                                        binaryWriter.Write((byte)ServerMessageTypes.register_response);
                                        binaryWriter.Write(0);
                                        binaryWriter.Flush();
                                        Console.WriteLine(username_reg + " nevű felhasználót nem tudtuk regisztrálni");
                                    }


                                    break;
                                case UserMessageType.text_Message:
                                    string chat_username = binaryReader.ReadString();
                                    string message = binaryReader.ReadString();
                                    Console.WriteLine(chat_username + message);

                                    foreach (var user in clients)
                                    {
                                        using (BinaryWriter binaryWriterChat = new BinaryWriter(user.Value.tcpClient.GetStream()))
                                        {
                                            binaryWriterChat.Write((byte)ServerMessageTypes.chat_message);
                                            binaryWriterChat.Write(chat_username);
                                            binaryWriterChat.Write(message);
                                            binaryWriterChat.Flush();
                                        }
                                    }

                                    break;
                                case UserMessageType.user_Data:

                                    break;
                            }
                        }
                    }
                }
            }
        }
    }
}
