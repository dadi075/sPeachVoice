using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sPeachServer
{
    enum UserMessageType
    {
        login_Data, //username + password
        registration_Data, // username + email + password
        user_Data, //username + user picture
        text_Message,
        voice_Message
    }
}
