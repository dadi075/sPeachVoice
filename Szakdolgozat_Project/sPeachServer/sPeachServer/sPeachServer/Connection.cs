using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Sockets;
using System.Net;

namespace sPeachServer
{
    class Connection
    {
        private string ipAddress;
        private int port = 1234;
        private TcpListener tcpListener;
        private BinaryReader binaryReader;

        public Connection()
        {
            tcpListener = new TcpListener(port);
            listen();
        }


        int messageType;
        string username;
        string password;

        public void listen()
        {
            tcpListener.Start();

            
            Socket socket = tcpListener.AcceptSocket();
            NetworkStream networkStream = new NetworkStream(socket);
            binaryReader = new BinaryReader(networkStream);

            while (true)
            {
                messageType = binaryReader.ReadByte();
                username = binaryReader.ReadString();
                password = binaryReader.ReadString();
                Console.WriteLine(messageType);
                Console.WriteLine(username);
                Console.WriteLine(password);
            }

            socket.Close();
            tcpListener.Stop();
        }
    }
}
