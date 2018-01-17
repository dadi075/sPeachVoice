using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net.Sockets;
using System.Net;
using NAudio.Wave;
using System.IO;
using System.Threading;
using NAudioDemo.NetworkChatDemo;

namespace database_NAudio_test
{
    class ListenerThreadState
    {
        public IPEndPoint EndPoint { get; set; }
        public INetworkChatCodec Codec { get; set; }
    }
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        NAudio.Wave.WaveIn source = null;
        NAudio.Wave.DirectSoundOut waveout = null;
        BufferedWaveProvider waveProvider;
        bool connected;
        UdpClient receiveData = new UdpClient(2302);
        UdpClient sendVoice;
        UdpClient receiveVoice;
        ALawChatCodec alcc = new ALawChatCodec();
        IWavePlayer waveOut;


        private void button1_Click(object sender, EventArgs e)
        {
            /*
             * A saját hangomat adja vissza a default mikrofonból
             */
            int deviceNumber = 0;

            source = new NAudio.Wave.WaveIn();
            source.DeviceNumber = deviceNumber;
            source.WaveFormat = new NAudio.Wave.WaveFormat(44100, NAudio.Wave.WaveIn.GetCapabilities(deviceNumber).Channels);

            NAudio.Wave.WaveInProvider waveIn = new NAudio.Wave.WaveInProvider(source);

            waveout = new NAudio.Wave.DirectSoundOut();
            waveout.Init(waveIn);

            source.StartRecording();
            waveout.Play();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*
             * Az adatbázis adatok fogadása
             */
            Thread t = new Thread(dataReceiver);
            t.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            /*
             csatlakozás/ küldés / fogadás
             innen indul ki minden
             */
            if (!connected)
            {
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(textBox2.Text), 2303);
                int inputDeviceNumber = 0;
                Connect(endPoint, inputDeviceNumber, alcc);
                button3.Text = "Disconnect";
            }
            else
            {
                Disconnect();
                button3.Text = "Connect";
            }
        }

        void dataReceiver()
        {
            while (true)
            {
                IPEndPoint iep = null;
                byte[] db = receiveData.Receive(ref iep);
                String s = Encoding.UTF8.GetString(db);
                listBox1.Invoke(new Action(() => listBox1.Items.Add(s)));
                Console.WriteLine("" + s);
            }
        }
        void ListenerThread(object state)
        {
            var listenerThreadState = (ListenerThreadState)state;
            var endPoint = listenerThreadState.EndPoint;
            while (connected)
            {
                byte[] b = receiveVoice.Receive(ref endPoint);
                byte[] decoded = listenerThreadState.Codec.Decode(b, 0, b.Length);
                waveProvider.AddSamples(decoded, 0, decoded.Length);
            }
        }

        void waveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            byte[] encoded = alcc.Encode(e.Buffer, 0, e.BytesRecorded);
            sendVoice.Send(encoded, encoded.Length);
        }

        void Connect(IPEndPoint endPoint, int inputDeviceNumber, INetworkChatCodec codec)
        {
            source = new WaveIn();
            source.BufferMilliseconds = 50;
            source.DeviceNumber = inputDeviceNumber;
            source.WaveFormat = codec.RecordFormat;
            source.DataAvailable += waveIn_DataAvailable;
            source.StartRecording();

            sendVoice = new UdpClient();
            receiveVoice = new UdpClient();

            receiveVoice.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, true);
            receiveVoice.Client.Bind(endPoint);

            sendVoice.Connect(endPoint);

            waveOut = new WaveOut();
            waveProvider = new BufferedWaveProvider(codec.RecordFormat);
            waveOut.Init(waveProvider);
            waveOut.Play();

            connected = true;
            var state = new ListenerThreadState { Codec = codec, EndPoint = endPoint };
            ThreadPool.QueueUserWorkItem(ListenerThread, state);
        }
        void Disconnect()
        {
            if (connected)
            {
                connected = false;
                source.DataAvailable -= waveIn_DataAvailable;
                source.StopRecording();
                waveOut.Stop();

                sendVoice.Close();
                receiveVoice.Close();
                source.Dispose();
                waveOut.Dispose();

                alcc.Dispose();
            }
        }


    }
}
