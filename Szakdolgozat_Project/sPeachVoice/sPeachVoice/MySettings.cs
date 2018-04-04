using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sPeachVoice
{
    class MySettings
    {
        private string username;
        private Image avatar;
        private int Available;

        public Image getMyAvatar()
        {
            return avatar;
        }
        public void setMyAvatar(Image avatar)
        {
            this.avatar = avatar;
        }
        public string getMyUsername()
        {
            return username;
        }
        public void setMyUsername(string username)
        {
            this.username = username;
        }
        public int getMyState()
        {
            return Available;
        }
        public void setMyState(int state)
        {
            Available = state;
        }
    }
}
