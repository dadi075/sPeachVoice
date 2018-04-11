using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace sPeachVoice
{
    public class Connection
    {
        private string ipAddress = "127.0.0.1";
        private int port = 1234;
        private TcpClient tcpClient;
        private NetworkStream networkStream;
        private BinaryReader binaryReader;
        public BinaryWriter binaryWriter;

        public LogInForm logInForm;
        public registerForm regForm;
        public chat_form chatForm;
        public mainForm mainForm;


        public void openConnection()
        {
            tcpClient = new TcpClient();
            tcpClient.Connect(ipAddress, port);
            networkStream = tcpClient.GetStream();
            binaryReader = new BinaryReader(networkStream);
            binaryWriter = new BinaryWriter(networkStream);
        }
        public void closeConnection()
        {
            tcpClient.Close();
            networkStream.Close();
            binaryReader.Close();
            binaryWriter.Close();
        }
        public void listen()
        {
            if (tcpClient.Connected)
            {
                while (true)
                {
                    int messageType = binaryReader.ReadByte();

                    switch ((ServerMessageType)messageType)
                    {
                        case ServerMessageType.login_response:
                            int loginResponse = binaryReader.ReadByte();
                            uint id = binaryReader.ReadByte();
                            logInForm.onLogIn(loginResponse, id);
                            break;
                        case ServerMessageType.register_response:
                            int registerResponse = binaryReader.ReadByte();
                            regForm.onRegister(registerResponse);
                            break;
                        case ServerMessageType.chat_message:
                            string message = binaryReader.ReadString();
                            chatForm.onMessageReceived(message);
                            break;
                        case ServerMessageType.logout_response:
                            int logoutResponse = binaryReader.ReadByte();
                            mainForm.onLogout(logoutResponse);
                            break;
                    }
                }
            }
        }
    }
}
