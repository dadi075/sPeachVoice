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
        }
        NAudio.Wave.WaveIn source = null;
        NAudio.Wave.DirectSoundOut waveOut = null;
        private void button1_Click(object sender, EventArgs e)
        {
            int deviceNumber = 0;

            source = new NAudio.Wave.WaveIn();
            source.DeviceNumber = deviceNumber;
            source.WaveFormat = new NAudio.Wave.WaveFormat(44100, NAudio.Wave.WaveIn.GetCapabilities(deviceNumber).Channels);

            NAudio.Wave.WaveInProvider waveIn = new NAudio.Wave.WaveInProvider(source);

            waveOut = new NAudio.Wave.DirectSoundOut();
            waveOut.Init(waveIn);

            source.StartRecording();
            waveOut.Play();
        }
        static UdpClient uc = new UdpClient(2302);


        static Form1 f = new Form1();


        private void button2_Click(object sender, EventArgs e)
        {
            int i = 0;
            while (i < 50) {
                receiver();
                i++;
            }
        }
        static void receiver()
        {
                IPEndPoint iep = null;
                byte[] db = uc.Receive(ref iep);
                String s = Encoding.UTF8.GetString(db);
                f.listBox1.Text = s;
        }
    }
}
