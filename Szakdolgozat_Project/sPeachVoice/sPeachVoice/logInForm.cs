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
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace sPeachVoice
{
    public partial class logInForm : Form
    {
        public logInForm()
        {
            InitializeComponent();
        }
        //formok
        registerForm regForm = new registerForm();
        mainForm mainForm = new mainForm(defaultAvatar, "Available", Color.Green);

        Hash sha = new Hash();
        //ellenőrzésnél segítő mezők
        bool isUsernameOk = false;
        bool isPasswordOk = false;

        public static string username;
        string password;
        byte[] pictureInBytes = imageToByteArray(defaultAvatar);

        static Bitmap defaultAvatar = new Bitmap(@"avatar.png");

        void onResponse()
        {

        }
        public static byte[] imageToByteArray(Bitmap img)
        {
            ImageConverter convert = new ImageConverter();
            return (byte[])convert.ConvertTo(img, typeof(byte[]));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // login form bezárása, mainform felbukkan
            // mező állapot jelző panelek ellenőrzése
            // ha jól lett beírva egyenlőre csak átvisz a main formra
            //ha nem, focusba hozza a regisztrációs linket
            // bejelentkezési adatok elküldése majd
            if (isUsernameOk == true && isPasswordOk == true)
            {
                username = username_text.Text;
                password = pass_text.Text;

                Connection.onResponse response = onResponse;
                Connection connection = new Connection(response);

                BinaryWriter binaryWriter = new BinaryWriter(connection.tcpClient.GetStream());

                binaryWriter.Write((byte)UserMessageType.login_Data);
                binaryWriter.Write(username);
                binaryWriter.Write(sha.sha256(password));
                binaryWriter.Write(pictureInBytes.Length);
                binaryWriter.Write(pictureInBytes);
                binaryWriter.Flush();

                //visszakapott adat levizsgálása, hogy sikerült-e a login
                using (BinaryReader binaryReader = new BinaryReader(connection.tcpClient.GetStream())) {
                    if ((ServerMessageType)binaryReader.ReadByte() == 0)
                    {
                        if (binaryReader.ReadInt32() == 1)
                        {
                            mainForm.Show();
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
            else
            {
                linkLabel1.Focus();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //regisztrációra átvisz
            regForm.Show();
        }
        // textbox-ok beállításai eddig
        private void textBox1_Click(object sender, EventArgs e)
        {
            username_text.Text = "";
            if (String.IsNullOrEmpty(pass_text.Text))
            {
                pass_text.UseSystemPasswordChar = false;
                pass_text.Text = "Password";
            }
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            pass_text.UseSystemPasswordChar = true;
            pass_text.Text = "";
            if (String.IsNullOrEmpty(username_text.Text))
            {
                username_text.Text = "Username";
            }
        }

        private void logInForm_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(username_text.Text))
            {
                username_text.Text = "Username";
            }
            if (String.IsNullOrEmpty(pass_text.Text))
            {
                pass_text.UseSystemPasswordChar = false;
                pass_text.Text = "Password";
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(username_text.Text))
            {
                username_text.Text = "Username";
            }
            if (String.IsNullOrEmpty(pass_text.Text))
            {
                pass_text.UseSystemPasswordChar = false;
                pass_text.Text = "Password";
            }
        }
        /*username ellenőrzés regex-el
        *ehhez beimportálva a System.Text.RegularExpressions 
        * felhelyezve két panel amik az adott mezők helyességét mutatják
        * csak akkor lehet elkülden majd, ha a két panel színe megegyezik
        */
        private void username_text_TextChanged(object sender, EventArgs e)
        {
            //csak kis és nagybetű + szám
            Regex usernameRgx = new Regex(@"^[a-z0-9_-]{3,15}$");
            username = username_text.Text;

            if (usernameRgx.IsMatch(username))
            {
                isUsernameOk = true;
            }
            else
            {
                isUsernameOk = false;
            }
        }

        private void pass_text_TextChanged(object sender, EventArgs e)
        {
            //kis és nagybetű, különleges karakter és minimum 8 karakter
            Regex passwordRgx = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$");
            string password = pass_text.Text;
            if (passwordRgx.IsMatch(password))
            {
                isPasswordOk = true;
            }
            else
            {
                isPasswordOk = false;
            }
        }
    }
}
