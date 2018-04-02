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
using System.IO;

namespace sPeachVoice
{
    public partial class registerForm : Form
    {
        public registerForm()
        {
            InitializeComponent();
        }
        //ellenőrzésnél segítő mezők
        static bool isUsernameOk = false;
        static bool isEmailOk = false;
        static bool isPasswordOk = false;
        static bool isPasswordConfOk = false;


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

                BinaryWriter binaryWriter = new BinaryWriter(connection.tcpClient.GetStream());
                //adatok küldése
                
                binaryWriter.Write((byte)UserMessageType.registration_Data);
                binaryWriter.Write(username_text.Text);
                binaryWriter.Write(email_text.Text);
                binaryWriter.Write(sha.sha256(password_text.Text));
                binaryWriter.Flush();

                //vissza kapott adat levizsgálása, hogy sikerült-e a regisztráció
                using (BinaryReader binaryReader = new BinaryReader(connection.tcpClient.GetStream())) {
                    ServerMessageType i = (ServerMessageType)binaryReader.ReadByte();
                    if (i == ServerMessageType.register_response)
                    {
                        if (binaryReader.ReadInt32() == 1)
                        {
                            this.Close();
                            connection.CloseConnection();
                        }
                        else
                        {
                            label1.Text = "Wrong username or password!";
                            connection.CloseConnection();
                        }
                    }
                }
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
                isUsernameOk = true;
            }
            else
            {
                isUsernameOk = false;
            }
        }

        private void email_text_TextChanged(object sender, EventArgs e)
        {
            string email = email_text.Text;
            Regex emailRgx = new Regex(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$");
            if (emailRgx.IsMatch(email))
            {
                isEmailOk = true;
            }
            else
            {
                isEmailOk = false;
            }
        }
        //metóduson kívül helyeztem el a passowrd regex-et, mert másik metódus is használja
        static Regex passwordRgx = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$");

        private void password_text_TextChanged(object sender, EventArgs e)
        {
            string password = password_text.Text;
            if (passwordRgx.IsMatch(password))
            {
                isPasswordOk = true;
            }
            else
            {
                isPasswordOk = false;
            }

        }

        private void password2_text_TextChanged(object sender, EventArgs e)
        {
            string password1 = password_text.Text;
            string password2 = password2_text.Text;
            if (passwordRgx.IsMatch(password2) && password1 == password2)
            {
                isPasswordConfOk = true;
            }
            else
            {
                isPasswordConfOk = false;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
