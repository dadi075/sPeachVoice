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
        static List<TcpClient> clients = new List<TcpClient>();
        static List<User> users = new List<User>();
        static byte[] onResponseLogin;

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


                //eltároljuk a kapcsolódott usereket
                //bejelentkezés után majd még egyszer fogadjuk a usereket és majd akkor a User képével együtt tároljuk el


                TcpClient client = con.tcpListener.AcceptTcpClient();
                clients.Add(client);

                messageType = con.binaryReader.ReadByte();

                switch ((UserMessageType)messageType)
                {
                    case UserMessageType.login_Data:
                        string username = con.binaryReader.ReadString();
                        string password = con.binaryReader.ReadString();

                        string command = "SELECT username, password FROM user WHERE username = '" + username + "' AND password = '" + password + "';";

                        sql.loginSelect(command);


                        if (sql.username == username)
                        {
                            onResponseLogin = Encoding.ASCII.GetBytes("1");
                            networkStream.Write(onResponseLogin, 1, onResponseLogin.Length);
                        }
                        else
                        {
                            onResponseLogin = Encoding.ASCII.GetBytes("0");
                            networkStream.Write(onResponseLogin, 1, onResponseLogin.Length);
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
