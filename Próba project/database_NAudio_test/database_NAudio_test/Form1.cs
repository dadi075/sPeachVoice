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

namespace database_NAudio_test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            PopulateInputDevicesCombo();
           // PopulateCodecsCombo(codecs);
        }
        void OnPanelDisposed(object sender, EventArgs e)
        {
            Disconnect();
        }
        //NAudio.Wave.WaveIn source = null;
        // NAudio.Wave.DirectSoundOut waveOut = null;
        private void button1_Click(object sender, EventArgs e)
        {
            /* int deviceNumber = 0;

             source = new NAudio.Wave.WaveIn();
             source.DeviceNumber = deviceNumber;
             source.WaveFormat = new NAudio.Wave.WaveFormat(44100, NAudio.Wave.WaveIn.GetCapabilities(deviceNumber).Channels);

             NAudio.Wave.WaveInProvider waveIn = new NAudio.Wave.WaveInProvider(source);

             waveOut = new NAudio.Wave.DirectSoundOut();
             waveOut.Init(waveIn);

             source.StartRecording();
             waveOut.Play();*/
            
        }
        //static UdpClient uc = new UdpClient(2302);


        private void button2_Click(object sender, EventArgs e)
        {
            //Thread t = new Thread(receiver);
            //t.Start();
        }
        void receiver()
        {
            while (true)
            {
                IPEndPoint iep = null;
                byte[] db = uc.Receive(ref iep);
                String s = Encoding.UTF8.GetString(db);
                listBox1.Invoke(new Action(() => listBox1.Items.Add(s)));
                Console.WriteLine("" + s);
            }
        }
        WaveIn waveIn;
        UdpClient udpSender;
        UdpClient udpListener;
        IWavePlayer waveOut;
        BufferedWaveProvider waveProvider;
        INetworkChatCodec selectedCodec;
        volatile bool connected;
        void Connect(IPEndPoint endPoint, int inputDeviceNumber, INetworkChatCodec codec)
        {
            waveIn = new WaveIn();
            waveIn.BufferMilliseconds = 50;
            waveIn.DeviceNumber = inputDeviceNumber;
            waveIn.WaveFormat = codec.RecordFormat;
            waveIn.DataAvailable += waveIn_DataAvailable;
            waveIn.StartRecording();

            udpSender = new UdpClient();
            udpListener = new UdpClient();


            udpListener.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            udpListener.Client.Bind(endPoint);

            udpSender.Connect(endPoint);

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
                waveIn.DataAvailable -= waveIn_DataAvailable;
                waveIn.StopRecording();
                waveOut.Stop();

                udpSender.Close();
                udpListener.Close();
                waveIn.Dispose();
                waveOut.Dispose();

                // a bit naughty but we have designed the codecs to support multiple calls to Dispose, 
                // recreating their resources if Encode/Decode called again
                selectedCodec.Dispose();
            }
        }
        class ListenerThreadState
        {
            public IPEndPoint EndPoint { get; set; }
            public INetworkChatCodec Codec { get; set; }
        }
        void ListenerThread(object state)
        {
            var listenerThreadState = (ListenerThreadState)state;
            var endPoint = listenerThreadState.EndPoint;
            while (connected)
            {
                byte[] b = udpListener.Receive(ref endPoint);
                byte[] decoded = listenerThreadState.Codec.Decode(b, 0, b.Length);
                waveProvider.AddSamples(decoded, 0, decoded.Length);
            }
        }
        void waveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            byte[] encoded = selectedCodec.Encode(e.Buffer, 0, e.BytesRecorded);
            udpSender.Send(encoded, encoded.Length);
        }
        private void buttonStartStreaming_Click(object sender, EventArgs e)
        {
            if (!connected)
            {
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(textBox1.Text), int.Parse(textBox2.Text));
                int inputDeviceNumber = 0;
                selectedCodec = ((CodecComboItem)comboBox1.SelectedItem).Codec;
                Connect(endPoint, inputDeviceNumber, selectedCodec);
                button1.Text = "Disconnect";
            }
            else
            {
                Disconnect();
                button1.Text = "Connect";
            }
        }
        class CodecComboItem
        {
            public string Text { get; set; }
            public INetworkChatCodec Codec { get; set; }
            public override string ToString()
            {
                return Text;
            }
        }
        void PopulateCodecsCombo(IEnumerable<INetworkChatCodec> codecs)
        {
            var sorted = from codec in codecs
                         where codec.IsAvailable
                         orderby codec.BitsPerSecond ascending
                         select codec;

            foreach (var codec in sorted)
            {
                string bitRate = codec.BitsPerSecond == -1 ? "VBR" : String.Format("{0:0.#}kbps", codec.BitsPerSecond / 1000.0);
                string text = String.Format("{0} ({1})", codec.Name, bitRate);
                comboBox1.Items.Add(new CodecComboItem { Text = text, Codec = codec });
            }
            comboBox1.SelectedIndex = 0;
        }
        void PopulateInputDevicesCombo()
        {
            for (int n = 0; n < WaveIn.DeviceCount; n++)
            {
                var capabilities = WaveIn.GetCapabilities(n);
                comboBox2.Items.Add(capabilities.ProductName);
            }
            if (comboBox2.Items.Count > 0)
            {
                comboBox2.SelectedIndex = 0;
            }
        }
       
    }
}
