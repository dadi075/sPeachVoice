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

        public Connection()
        {
            tcpListener = new TcpListener(port);
        }
    }
}
