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
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }
        chat_form chat_form = new chat_form();
        optionForm option_form = new optionForm();
        public static PictureBox avatar = new PictureBox();

        private void servers_btn_Click(object sender, EventArgs e)
        {
            chat_form.Show();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            name.Text = logInForm.username;

        }

        private void options_btn_Click(object sender, EventArgs e)
        {
            option_form.Show();
        }
    }
}
