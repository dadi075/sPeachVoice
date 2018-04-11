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
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace sPeachVoice
{
    public partial class LogInForm : Form
    {
        public LogInForm(Main main)
        {
            InitializeComponent();
            this.main = main;
            main.connection.logInForm = this;
            main.connection.regForm = regForm;
        }
        private Main main;

        public static string username;
        public static uint userIdFromServer;
        registerForm regForm;

        Hash sha = new Hash();

        bool isUsernameOk = false;
        bool isPasswordOk = false;


        string password;
        byte[] pictureInBytes = imageToByteArray(defaultAvatar);

        static Bitmap defaultAvatar = new Bitmap(@"avatar.png");

        public static byte[] imageToByteArray(Bitmap img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
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

                main.connection.binaryWriter.Write((byte)UserMessageType.login_Data);
                main.connection.binaryWriter.Write(username);
                main.connection.binaryWriter.Write(sha.sha256(password));
                main.connection.binaryWriter.Write(pictureInBytes.Length);
                main.connection.binaryWriter.Write(pictureInBytes);
                main.connection.binaryWriter.Flush();
            }
            else
            {
                linkLabel1.Focus();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //regisztrációra átvisz
            regForm = new registerForm(main);
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
        //visszakapott adat levizsgálása, hogy sikerült-e a login
        void receiver()
        {
            main.connection.listen();
        }

        private void logInForm_Load(object sender, EventArgs e)
        {
            main.connection.openConnection();
            Thread receiveData = new Thread(receiver);
            receiveData.Start();
        }
        public void onLogIn(int loginResponse, uint id)
        {
            userIdFromServer = id;
            if (loginResponse == 1)
            {
                this.Invoke((MethodInvoker)(() =>
                {
                    mainForm mainForm = new mainForm(defaultAvatar, "Available", Color.Green, main);
                    mainForm.Show();
                }));
            }
            else
            {
                label1.Invoke((MethodInvoker)(() =>
                {
                    label1.Text = "Wrong username or password";
                }));
            }
        }
    }
}
