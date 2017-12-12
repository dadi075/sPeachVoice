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

            username_text.Text = "";
            if (String.IsNullOrEmpty(email_text.Text))
            {
                email_text.Text = "E-mail";
            }
            if (String.IsNullOrEmpty(password_text.Text))
            {
                password_text.UseSystemPasswordChar = false;
                password_text.Text = "Password";
            }
            if (String.IsNullOrEmpty(password2_text.Text))
            {
                password2_text.UseSystemPasswordChar = false;
                password2_text.Text = "Confirm Password";
            }
        }
        //E-mail
        private void textBox2_Click(object sender, EventArgs e)
        {
            //textbox things
            email_text.Text = "";
            if (String.IsNullOrEmpty(username_text.Text))
            {
                username_text.Text = "Username";
            }
            if (String.IsNullOrEmpty(password_text.Text))
            {
                password_text.UseSystemPasswordChar = false;
                password_text.Text = "Password";
            }
            if (String.IsNullOrEmpty(password2_text.Text))
            {
                password2_text.UseSystemPasswordChar = false;
                password2_text.Text = "Confirm Password";
            }
        }
        //password
        private void textBox3_Click(object sender, EventArgs e)
        {
            //textbox things
            password_text.UseSystemPasswordChar = true;
            password_text.Text = "";
            if (String.IsNullOrEmpty(username_text.Text))
            {
                username_text.Text = "Username";
            }
            if (String.IsNullOrEmpty(email_text.Text))
            {
                email_text.Text = "E-mail";
            }
            if (String.IsNullOrEmpty(password2_text.Text))
            {
                password2_text.UseSystemPasswordChar = false;
                password2_text.Text = "Confirm Password";
            }
        }
        //confirm password
        private void textBox4_Click(object sender, EventArgs e)
        {
            //textbox things
            password2_text.UseSystemPasswordChar = true;
            password2_text.Text = "";
            if (String.IsNullOrEmpty(username_text.Text))
            {
                username_text.Text = "Username";
            }
            if (String.IsNullOrEmpty(email_text.Text))
            {
                email_text.Text = "E-mail";
            }
            if (String.IsNullOrEmpty(password_text.Text))
            {
                password_text.UseSystemPasswordChar = false;
                password_text.Text = "Password";
            }
        }

        private void registerForm_Click(object sender, EventArgs e)
        {
            //textbox things
            if (String.IsNullOrEmpty(username_text.Text))
            {
                username_text.Text = "Username";
            }
            if (String.IsNullOrEmpty(email_text.Text))
            {
                email_text.Text = "E-mail";
            }
            if (String.IsNullOrEmpty(password_text.Text))
            {
                password_text.UseSystemPasswordChar = false;
                password_text.Text = "Password";
            }
            if (String.IsNullOrEmpty(password2_text.Text))
            {
                password2_text.UseSystemPasswordChar = false;
                password2_text.Text = "Confirm Password";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //textbox things
            if (String.IsNullOrEmpty(username_text.Text))
            {
                username_text.Text = "Username";
            }
            if (String.IsNullOrEmpty(email_text.Text))
            {
                email_text.Text = "E-mail";
            }
            if (String.IsNullOrEmpty(password_text.Text))
            {
                password_text.UseSystemPasswordChar = false;
                password_text.Text = "Password";
            }
            if (String.IsNullOrEmpty(password2_text.Text))
            {
                password2_text.UseSystemPasswordChar = false;
                password2_text.Text = "Confirm Password";
            }
        }
    }
}
