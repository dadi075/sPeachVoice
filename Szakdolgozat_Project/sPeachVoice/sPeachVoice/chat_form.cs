using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;
using System.Net;
using System.Net.Sockets;

namespace sPeachVoice
{
    public partial class chat_form : Form
    {
        public chat_form(Main main)
        {
            InitializeComponent();
            this.main = main;
            this.chat_username = mainForm.usernameToShow;
            main.connection.chatForm = this;
        }
        private Main main;
        string chat_username;

        //hang
        private bool connected;
        ALawChatCodec aLawChatCodec = new ALawChatCodec();
        WaveIn waveIn = null;
        DirectSoundOut waveout = null;
        BufferedWaveProvider waveProvider;
        UdpClient sendVoice;
        UdpClient receiveVoice;
        IWavePlayer waveOut;

        private void send_btn_Click(object sender, EventArgs e)
        {
            main.connection.binaryWriter.Write((byte)UserMessageType.text_Message);
            main.connection.binaryWriter.Write(chat_username);
            main.connection.binaryWriter.Write(textBox1.Text);
            main.connection.binaryWriter.Flush();

            textBox1.Text = "";
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                main.connection.binaryWriter.Write((byte)UserMessageType.text_Message);
                main.connection.binaryWriter.Write(chat_username);
                main.connection.binaryWriter.Write(textBox1.Text);
                main.connection.binaryWriter.Flush();
                textBox1.Text = "";
            }
        }
        public void receiveMessage()
        {
            main.connection.listen();
        }

        private void chat_form_Load(object sender, EventArgs e)
        {
            Thread receiverThread = new Thread(new ThreadStart(receiveMessage));
            receiverThread.Start();
        }
        public void onMessageReceived(string messageAndUsername)
        {
            if (this.listBox1.InvokeRequired)
            {
                listBox1.Invoke(new Action(() => listBox1.Items.Add(messageAndUsername)));
            }
            else
            {
                listBox1.Items.Add(messageAndUsername);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!connected)
            {
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Broadcast, 60001);
                IPEndPoint endpoint2 = new IPEndPoint(IPAddress.Any, 60001);
                int inputDeviceNumber = 0;
                connectVoice(endPoint, inputDeviceNumber, aLawChatCodec);
                button1.Text = "Disconnect";
            }
            else
            {
                disconnectVoice();
                button1.Text = "Connect";
            }
        }
        void connectVoice(IPEndPoint endPoint, int inputDevice, INetworkChatCodec networkChatCodec)
        {
            waveIn = new WaveIn();
            waveIn.BufferMilliseconds = 50;
            waveIn.DeviceNumber = inputDevice;
            waveIn.WaveFormat = networkChatCodec.RecordFormat;
            waveIn.DataAvailable += waveIn_DataAvailable;
            waveIn.StartRecording();

            sendVoice = new UdpClient();
            receiveVoice = new UdpClient();
            sendVoice.EnableBroadcast = true;
            receiveVoice.EnableBroadcast = true;

            receiveVoice.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, true);
            receiveVoice.Client.Bind(endPoint);

            sendVoice.Connect(endPoint);

            waveOut = new WaveOut();
            waveProvider = new BufferedWaveProvider(networkChatCodec.RecordFormat);
            waveOut.Init(waveProvider);
            waveOut.Play();

            connected = true;
            var state = new ListenerThreadState { Codec = networkChatCodec, EndPoint = endPoint };
            ThreadPool.QueueUserWorkItem(listenerThreadState, state);
        }
        void disconnectVoice()
        {
            if (connected)
            {
                connected = false;
                waveIn.DataAvailable -= waveIn_DataAvailable;
                waveIn.StopRecording();
                waveOut.Stop();

                sendVoice.Close();
                receiveVoice.Close();
                waveIn.Dispose();
                waveOut.Dispose();

                aLawChatCodec.Dispose();
            }
        }
        void waveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            byte[] encoded = aLawChatCodec.Encode(e.Buffer, 0, e.BytesRecorded);
            sendVoice.Send(encoded, encoded.Length);
        }
        void listenerThreadState(object state)
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
    }
}
