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
    public partial class registerForm : Form
    {
        public registerForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //todo registration code here




            this.Close();
        }
        //username
        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }
        //E-mail
        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }
        //password
        private void textBox3_Click(object sender, EventArgs e)
        {
            textBox3.UseSystemPasswordChar = true;
            textBox3.Text = "";
        }
        //confirm password
        private void textBox4_Click(object sender, EventArgs e)
        {
            textBox4.UseSystemPasswordChar = true;
            textBox4.Text = "";
        }
    }
}
