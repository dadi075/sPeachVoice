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
using System.Text.RegularExpressions;

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

        private bool connected;
        ALawChatCodec aLawChatCodec = new ALawChatCodec();
        WaveIn waveIn = null;
        BufferedWaveProvider waveProvider;
        UdpClient sendVoice;
        UdpClient receiveVoice;
        IWavePlayer waveOut;
        IPEndPoint endPoint = new IPEndPoint(IPAddress.Broadcast, 60001);
        IPEndPoint endPoint2 = new IPEndPoint(IPAddress.Any, 60001);

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
                listBox1.Invoke(new Action(() => listBox1.SelectedIndex = listBox1.Items.Count - 1));
            }
            else
            {
                listBox1.Items.Add(messageAndUsername);
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!connected)
            {
                int inputDeviceNumber = 0;
                connectVoice(endPoint, endPoint2, inputDeviceNumber, aLawChatCodec);
                button1.Text = "Disconnect";
            }
            else
            {
                disconnectVoice();
                button1.Text = "Connect";
            }
        }
        void connectVoice(IPEndPoint endPoint, IPEndPoint endpointListener, int inputDevice, INetworkChatCodec networkChatCodec)
        {
            waveIn = new WaveIn();
            waveIn.BufferMilliseconds = 50;
            waveIn.DeviceNumber = inputDevice;
            waveIn.WaveFormat = networkChatCodec.RecordFormat;
            waveIn.DataAvailable += waveIn_DataAvailable;
            waveIn.StartRecording();

            sendVoice = new UdpClient();
            receiveVoice = new UdpClient();

            receiveVoice.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, true);
            receiveVoice.Client.Bind(endpointListener);

            waveOut = new WaveOut();
            waveProvider = new BufferedWaveProvider(networkChatCodec.RecordFormat);
            waveOut.Init(waveProvider);
            waveOut.Play();

            connected = true;
            var state = new ListenerThreadState { Codec = networkChatCodec, EndPoint = endPoint, EndPointListener = endpointListener };
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
            sendVoice.Send(encoded, encoded.Length, endPoint);
        }
        void listenerThreadState(object state)
        {
            var listenerThreadState = (ListenerThreadState)state;
            var endPoint2 = listenerThreadState.EndPointListener;
            while (connected)
            {
                try
                {
                    byte[] b = receiveVoice.Receive(ref endPoint2);
                    byte[] decoded = listenerThreadState.Codec.Decode(b, 0, b.Length);
                    waveProvider.AddSamples(decoded, 0, decoded.Length);
                }
                catch
                {
                   
                }
            }
        }
    }
}
