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

namespace database_NAudio_test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string mysqlConnection = "datasource=localhost;port=3306;username=root;password=asdfghjk123";
            SqlConnection sqlcon = new SqlConnection();
            sqlcon.Open();
            textBox1.Text = "kapcsolódva";

            SqlCommand command = new SqlCommand("SELECT * FROM [Users]", sqlcon);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read()) {
                richTextBox1.Text = "első tábla: " + reader.GetString(0);
            }
            reader.Close();
            sqlcon.Close();
        }


        NAudio.Wave.WaveIn source = null;
        NAudio.Wave.DirectSoundOut waveOut = null;

        private void button2_Click(object sender, EventArgs e)
        {
            source = new NAudio.Wave.WaveIn();
            source.DeviceNumber = 0;
            source.WaveFormat = new NAudio.Wave.WaveFormat(44100, NAudio.Wave.WaveIn.GetCapabilities(0).Channels);

            NAudio.Wave.WaveInProvider waveIn = new NAudio.Wave.WaveInProvider(source);

            waveOut = new NAudio.Wave.DirectSoundOut();
            waveOut.Init(waveIn);

            textBox2.Text = "lejátszás folyamatos";

            source.StartRecording();
            waveOut.Play();
        }
    }
}
