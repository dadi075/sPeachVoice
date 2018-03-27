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
        private int port = 1234;
        public TcpListener tcpListener;
        public BinaryReader binaryReader;
        public BinaryWriter binaryWriter;
        public NetworkStream networkStream;

        public Connection()
        {
            tcpListener = new TcpListener(port);
        }
    }
}
