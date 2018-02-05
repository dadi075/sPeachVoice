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
    public partial class logInForm : Form
    {
        public logInForm()
        {
            InitializeComponent();
        }
        static logInForm logForm = new logInForm();
        static registerForm regForm = new registerForm();
        static mainForm mainForm = new mainForm();

        private void button1_Click(object sender, EventArgs e)
        {
            // login form bezárása, mainform felbukkan
            // mező állapot jelző panelek ellenőrzése
            // ha jól lett beírva egyenlőre csak átvisz a main formra
            //ha nem focusba hozza a regisztrációs linket
            // bejelentkezési adatok elküldése majd
            if (panel2.BackColor == Color.Green && panel4.BackColor == Color.Green)
            {
                mainForm.Show();
                logForm.Close();
            }
            else {
                linkLabel1.Focus();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //regisztrációra átvisz
            logForm.Hide();
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
            string username = username_text.Text;

            if (usernameRgx.IsMatch(username))
            {
                panel2.BackColor = Color.Green;
            }
            else
            {
                panel2.BackColor = Color.Red;
            }
        }

        private void pass_text_TextChanged(object sender, EventArgs e)
        {
            //kis és nagybetű, különleges karakter és minimum 8 karakter
            Regex passwordRgx = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$");
            string password = pass_text.Text;
            if (passwordRgx.IsMatch(password))
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
