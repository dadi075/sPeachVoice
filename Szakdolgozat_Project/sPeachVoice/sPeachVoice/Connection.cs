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
    class Connection
    {
        private string ipAddress = "127.0.0.1";
        private int port = 1234;
        public TcpClient tcpClient = new TcpClient();
        public BinaryWriter binaryWriter;
        private onResponse response;


        public delegate void onResponse();

        //konstruktor, ha létrehozunk egy példányt, akkor csatlakozik
        public Connection(onResponse response)
        {
            this.response = response;
            tcpClient.Connect(ipAddress, port);
            binaryWriter = new BinaryWriter(tcpClient.GetStream());
            response();
        }
        public void CloseConnection()
        {
            tcpClient.Close();
        }
    }
}
