﻿using System;
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
        //ellenőrzésnél segítő mezők
        bool isUsernameOk = false;
        bool isEmailOk = false;
        bool isPasswordOk = false;
        bool isPasswordConfOk = false;


        void onResponse()
        {
            Console.WriteLine("asd");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isUsernameOk == true
                &&
                isEmailOk == true
                &&
                isPasswordOk == true
                &&
                isPasswordConfOk == true)
            {
                Connection.onResponse response = onResponse;
                Connection connection = new Connection(response);
                Hash sha = new Hash();

                //adatok küldése
                connection.binaryWriter.Write((byte)UserMessageType.registration_Data);
                connection.binaryWriter.Write(username_text.Text);
                connection.binaryWriter.Write(email_text.Text);
                connection.binaryWriter.Write(sha.sha256(password_text.Text));
                connection.binaryWriter.Flush();

                //vissza kapott adat levizsgálása, hogy sikerült-e a regisztráció


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
                bool isUsernameOk = true;
            }
            else
            {
                bool isUsernameOk = false;
            }
        }

        private void email_text_TextChanged(object sender, EventArgs e)
        {
            string email = email_text.Text;
            Regex emailRgx = new Regex(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$");
            if (emailRgx.IsMatch(email))
            {
                bool isEmailOk = true;
            }
            else
            {
                bool isEmailOk = false;
            }
        }
        //metóduson kívül helyeztem el a passowrd regex-et, mert másik metódus is használja
        Regex passwordRgx = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$");

        private void password_text_TextChanged(object sender, EventArgs e)
        {
            string password = password_text.Text;
            if (passwordRgx.IsMatch(password))
            {
                bool isPasswordOk = true;
            }
            else
            {
                bool isPasswordOk = false;
            }

        }

        private void password2_text_TextChanged(object sender, EventArgs e)
        {
            string password1 = password_text.Text;
            string password2 = password2_text.Text;
            if (passwordRgx.IsMatch(password2) && password1 == password2)
            {
                bool isPasswordConfOk = true;
            }
            else
            {
                bool isPasswordConfOk = false;
            }
        }
    }
}
