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
        static uint id = 0;
        static NetworkStream networkStream;
        static BinaryReader binaryReader;
        static BinaryWriter binaryWriter;

        static void Main(string[] args)
        {

            Thread receiver = new Thread(receiverThread);
            receiver.Start();

        }
        static void receiverThread()
        {
            Connection con = new Connection();
            con.tcpListener.Start();

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
            networkStream = acceptedClient.GetStream();

            binaryWriter = new BinaryWriter(networkStream);
            binaryReader = new BinaryReader(networkStream);

            while (true)
            {
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
                            clients.Add(id, new User() { username = username_login, picture = pictureArray, tcpClient = acceptedClient, networkStream = acceptedClient.GetStream() });
                            id++;

                            binaryWriter.Write((byte)ServerMessageTypes.login_response);
                            binaryWriter.Write(1);
                            binaryWriter.Write(id);
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
                        string messageAndUsername = chat_username + ": " + message;

                        foreach (var user in clients)
                        {
                            networkStream = user.Value.tcpClient.GetStream();
                            binaryWriter.Write((byte)ServerMessageTypes.chat_message);
                            binaryWriter.Write(messageAndUsername);
                            binaryWriter.Flush();
                        }
                        chat_username = "";
                        message = "";
                        messageAndUsername = "";
                        break;

                    case UserMessageType.logout:
                        int logout_message = binaryReader.ReadByte();
                        uint user_id = binaryReader.ReadByte();

                        if (logout_message == 1)
                        {
                            clients.Remove(user_id);
                            binaryWriter.Write((byte)ServerMessageTypes.logout_response);
                            binaryWriter.Write(1);
                            binaryWriter.Flush();
                        }
                        break;
                }
            }
        }
    }
}
