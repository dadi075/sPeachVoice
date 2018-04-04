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
        Connection conn;
        NetworkStream networkStream;
        public chat_form(Object con)
        {
            InitializeComponent();
            conn = (Connection)con;
        }

        string chat_username;




        public static void onResponse()
        {
            Console.WriteLine("asda");
        }

        static Connection.onResponse response = onResponse;


        private void send_btn_Click(object sender, EventArgs e)
        {
            BinaryWriter binaryWriter = new BinaryWriter(networkStream);
            binaryWriter.Write((byte)UserMessageType.text_Message);
            binaryWriter.Write(chat_username);
            binaryWriter.Write(textBox1.Text);
            binaryWriter.Flush();

            textBox1.Text = "";
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BinaryWriter binaryWriter = new BinaryWriter(networkStream);
                binaryWriter = new BinaryWriter(networkStream);

                binaryWriter.Write((byte)UserMessageType.text_Message);
                binaryWriter.Write(chat_username);
                binaryWriter.Write(textBox1.Text);
                binaryWriter.Flush();
                textBox1.Text = "";
            }
        }
        public void receiveMessage()
        {
                BinaryReader binaryReader = new BinaryReader(networkStream);
                while (true)
                {
                    int messageType = binaryReader.ReadInt32();
                    if ((ServerMessageType)messageType == ServerMessageType.chat_message)
                    {
                        string username = binaryReader.ReadString();
                        string message = binaryReader.ReadString();
                    }
                }
            }

        private void chat_form_Load(object sender, EventArgs e)
        {
            networkStream = conn.tcpClient.GetStream();
            Thread receiverThread = new Thread(new ThreadStart(receiveMessage));
            receiverThread.Start();
        }
    }
}
