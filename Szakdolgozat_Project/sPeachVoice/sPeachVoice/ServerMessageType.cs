using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sPeachVoice
{
    enum ServerMessageType
    {
        login_response,
        register_response,
        all_user_data,
        chat_message,
        voice_message
    }
}
