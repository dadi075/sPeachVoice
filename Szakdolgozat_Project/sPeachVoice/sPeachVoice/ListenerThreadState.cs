using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace sPeachVoice
{
    class ListenerThreadState
    {
        public IPEndPoint EndPoint { get; set; }
        public INetworkChatCodec Codec { get; set; }
    }
}
