using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sPeachVoice
{
    public partial class optionForm : Form
    {
        public optionForm(Main main)
        {
            InitializeComponent();
            this.main = main;
        }
        private Main main;
        
        public string filePath;
        Bitmap selectedAvatar;
        OpenFileDialog fileDialog = new OpenFileDialog();
        string stateText = "";
        Color stateColor;


        private void button1_Click(object sender, EventArgs e)
        {
            fileDialog.Title = "Select Picture";
            fileDialog.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = fileDialog.FileName;
                selectedAvatar = new Bitmap(fileDialog.FileName);
                label2.Text = filePath;
            }
        }

        private void submit_btn_Click(object sender, EventArgs e)
        {
            mainForm mainForm = new mainForm(selectedAvatar, stateText, stateColor, main);
            mainForm.Show();
            this.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            stateColor = Color.Green;
            stateText = "Available";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            stateColor = Color.Red;
            stateText = "Busy";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            stateColor = Color.Orange;
            stateText = "Away";
        }
    }
}
