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
        public optionForm()
        {
            InitializeComponent();
        }
        public static string filePath;

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Title = "Select Picture";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = fileDialog.FileName;
                label2.Text = filePath;
            }
        }

        private void submit_btn_Click(object sender, EventArgs e)
        {
            mainForm.avatar.ImageLocation = filePath;
        }
    }
}
