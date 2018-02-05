using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

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
            if (panel1.BackColor == Color.Green
                &&
                panel2.BackColor == Color.Green
                &&
                panel3.BackColor == Color.Green
                &&
                panel4.BackColor == Color.Green)
            {
                this.Close();
            }
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

        private void username_text_TextChanged(object sender, EventArgs e)
        {
            Regex usernameRgx = new Regex(@"^[a-z0-9_-]{3,15}$");
            string username = username_text.Text;

            if (usernameRgx.IsMatch(username))
            {
                panel1.BackColor = Color.Green;
            }
            else
            {
                panel1.BackColor = Color.Red;
            }
        }

        private void email_text_TextChanged(object sender, EventArgs e)
        {
            string email = email_text.Text;
            Regex emailRgx = new Regex(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$");
            if (emailRgx.IsMatch(email))
            {
                panel2.BackColor = Color.Green;
            }
            else
            {
                panel2.BackColor = Color.Red;
            }
        }
        //metóduson kívül helyeztem el a passowrd regex-et, mert másik metódus is használja
        Regex passwordRgx = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$");

        private void password_text_TextChanged(object sender, EventArgs e)
        {
            string password = password_text.Text;
            if (passwordRgx.IsMatch(password))
            {
                panel3.BackColor = Color.Green;
            }
            else
            {
                panel3.BackColor = Color.Red;
            }

        }

        private void password2_text_TextChanged(object sender, EventArgs e)
        {
            string password1 = password_text.Text;
            string password2 = password2_text.Text;
            if (passwordRgx.IsMatch(password2) && password1 == password2)
            {
                panel4.BackColor = Color.Green;
            }
            else
            {
                panel4.BackColor = Color.Red;
            }
        }
    }
}
