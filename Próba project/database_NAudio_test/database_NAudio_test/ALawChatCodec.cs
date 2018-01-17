using System;
using System.Linq;
using NAudio.Wave;
using NAudio.Codecs;
using database_NAudio_test;

namespace NAudioDemo.NetworkChatDemo
{
    //kodek
    class ALawChatCodec : INetworkChatCodec
    {
        public string Name
        {
            get { return "G.711 a-law"; }
        }

        public int BitsPerSecond
        {
            get { return RecordFormat.SampleRate * 8; }
        }

        public WaveFormat RecordFormat
        {
            get { return new WaveFormat(8000, 32, 2); }
        }

        public byte[] Encode(byte[] data, int offset, int length)
        {
            byte[] encoded = new byte[length / 2];
            int outIndex = 0;
            for (int n = 0; n < length; n += 2)
            {
                encoded[outIndex++] = ALawEncoder.LinearToALawSample(BitConverter.ToInt16(data, offset + n));
            }
            return encoded;
        }

        public byte[] Decode(byte[] data, int offset, int length)
        {
            byte[] decoded = new byte[length * 2];
            int outIndex = 0;
            for (int n = 0; n < length; n++)
            {
                short decodedSample = ALawDecoder.ALawToLinearSample(data[n + offset]);
                decoded[outIndex++] = (byte)(decodedSample & 0xFF);
                decoded[outIndex++] = (byte)(decodedSample >> 8);
            }
            return decoded;
        }

        public void Dispose()
        {
            // nem szükséges a teszt projecthez
        }

        public bool IsAvailable { get { return true; } }
    }
}

