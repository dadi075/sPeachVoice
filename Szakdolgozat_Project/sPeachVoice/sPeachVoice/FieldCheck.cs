using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace sPeachVoice
{
    class FieldCheck
    {
        Regex usernameRgx = new Regex(@"^[a-z0-9_-]{3,15}$");



        public bool checkUsername(string username)
        {
            if (usernameRgx.IsMatch(username))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
