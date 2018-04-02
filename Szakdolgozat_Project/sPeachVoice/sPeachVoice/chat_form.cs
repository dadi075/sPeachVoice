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

namespace sPeachVoice
{
    public partial class chat_form : Form
    {
        public chat_form(string username)
        {
            InitializeComponent();
            chat_username = username;
            
        }
        static string chat_username;


        public static void onResponse()
        {
            Console.WriteLine("asda");
        }

        static Connection.onResponse response = onResponse;
        Connection connection;

        private void send_btn_Click(object sender, EventArgs e)
        {
            connection = new Connection(response);
            BinaryWriter binaryWriter = new BinaryWriter(connection.tcpClient.GetStream());

            Console.WriteLine("1");
            binaryWriter.Write((byte)UserMessageType.text_Message);
            binaryWriter.Write(chat_username);
            binaryWriter.Write(textBox1.Text);
            binaryWriter.Flush();
            Console.WriteLine("2");
            binaryWriter.Flush();

            textBox1.Text = "";
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                connection = new Connection(response);
                BinaryWriter binaryWriter = new BinaryWriter(connection.tcpClient.GetStream());


                Console.WriteLine("1");
                binaryWriter.Write((byte)UserMessageType.text_Message);
                binaryWriter.Write(chat_username);
                binaryWriter.Write(textBox1.Text);
                binaryWriter.Flush();
                Console.WriteLine("2");
                textBox1.Text = "";
            }
        }
        public void receiveMessage()
        {
            connection = new Connection(response);
            if (connection.tcpClient.GetStream().DataAvailable) {
                while (true)
                {
                    using (BinaryReader binaryReader = new BinaryReader(connection.tcpClient.GetStream()))
                    {
                        int messageType = binaryReader.ReadInt32();
                        if ((ServerMessageType)messageType == ServerMessageType.chat_message)
                        {
                            string username = binaryReader.ReadString();
                            string message = binaryReader.ReadString();
                            listBox1.Invoke((MethodInvoker)(() =>
                            {
                                listBox1.Items.Add(username + message);
                            }));
                        }
                    }
                }
            }
        }

        private void chat_form_Load(object sender, EventArgs e)
        {
            Thread receiverThread = new Thread(receiveMessage);
            receiverThread.Start();
        }
    }
}
