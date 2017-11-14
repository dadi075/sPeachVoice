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
            //textbox things

            textBox1.Text = "";
            if (String.IsNullOrEmpty(textBox2.Text))
            {
                textBox2.Text = "E-mail";
            }
            if (String.IsNullOrEmpty(textBox3.Text))
            {
                textBox3.UseSystemPasswordChar = false;
                textBox3.Text = "Password";
            }
            if (String.IsNullOrEmpty(textBox4.Text))
            {
                textBox4.UseSystemPasswordChar = false;
                textBox4.Text = "Confirm Password";
            }
        }
        //E-mail
        private void textBox2_Click(object sender, EventArgs e)
        {
            //textbox things
            textBox2.Text = "";
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.Text = "Username";
            }
            if (String.IsNullOrEmpty(textBox3.Text))
            {
                textBox3.UseSystemPasswordChar = false;
                textBox3.Text = "Password";
            }
            if (String.IsNullOrEmpty(textBox4.Text))
            {
                textBox4.UseSystemPasswordChar = false;
                textBox4.Text = "Confirm Password";
            }
        }
        //password
        private void textBox3_Click(object sender, EventArgs e)
        {
            //textbox things
            textBox3.UseSystemPasswordChar = true;
            textBox3.Text = "";
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.Text = "Username";
            }
            if (String.IsNullOrEmpty(textBox2.Text))
            {
                textBox2.Text = "E-mail";
            }
            if (String.IsNullOrEmpty(textBox4.Text))
            {
                textBox4.UseSystemPasswordChar = false;
                textBox4.Text = "Confirm Password";
            }
        }
        //confirm password
        private void textBox4_Click(object sender, EventArgs e)
        {
            //textbox things
            textBox4.UseSystemPasswordChar = true;
            textBox4.Text = "";
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.Text = "Username";
            }
            if (String.IsNullOrEmpty(textBox2.Text))
            {
                textBox2.Text = "E-mail";
            }
            if (String.IsNullOrEmpty(textBox3.Text))
            {
                textBox3.UseSystemPasswordChar = false;
                textBox3.Text = "Password";
            }
        }

        private void registerForm_Click(object sender, EventArgs e)
        {
            //textbox things
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.Text = "Username";
            }
            if (String.IsNullOrEmpty(textBox2.Text))
            {
                textBox2.Text = "E-mail";
            }
            if (String.IsNullOrEmpty(textBox3.Text))
            {
                textBox3.UseSystemPasswordChar = false;
                textBox3.Text = "Password";
            }
            if (String.IsNullOrEmpty(textBox4.Text))
            {
                textBox4.UseSystemPasswordChar = false;
                textBox4.Text = "Confirm Password";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //textbox things
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                textBox1.Text = "Username";
            }
            if (String.IsNullOrEmpty(textBox2.Text))
            {
                textBox2.Text = "E-mail";
            }
            if (String.IsNullOrEmpty(textBox3.Text))
            {
                textBox3.UseSystemPasswordChar = false;
                textBox3.Text = "Password";
            }
            if (String.IsNullOrEmpty(textBox4.Text))
            {
                textBox4.UseSystemPasswordChar = false;
                textBox4.Text = "Confirm Password";
            }
        }
    }
}
