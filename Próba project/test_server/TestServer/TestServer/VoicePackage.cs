using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestServer
{
    class VoicePackage
    {
        private byte[] voice;

        public VoicePackage(byte[] voice) {
            this.voice = voice;
        }
        public virtual void becsomagol(BinaryWriter bw)
        {
            bw.Write(voice);
        }

    }
}
