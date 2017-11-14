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
    public partial class logInForm : Form
    {
        public logInForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //showing the registration form
            logInForm logForm = new logInForm();
            registerForm regForm = new registerForm();
            logForm.Hide();
            regForm.Show();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            if (String.IsNullOrEmpty(textBox2.Text))
            {
                textBox2.UseSystemPasswordChar = false;
                textBox2.Text = "Password";
            }
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
            textBox2.Text = "";
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.Text = "Username";
            }
        }

        private void logInForm_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.Text = "Username";
            }
            if (String.IsNullOrEmpty(textBox2.Text))
            {
                textBox2.UseSystemPasswordChar = false;
                textBox2.Text = "Password";
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.Text = "Username";
            }
            if (String.IsNullOrEmpty(textBox2.Text))
            {
                textBox2.UseSystemPasswordChar = false;
                textBox2.Text = "Password";
            }
        }
    }
}
