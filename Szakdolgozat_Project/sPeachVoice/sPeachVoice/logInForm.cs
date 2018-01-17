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
        static logInForm logForm = new logInForm();
        static registerForm regForm = new registerForm();
        static mainForm mainForm = new mainForm();

        private void button1_Click(object sender, EventArgs e)
        {
            // login form bezárása, mainform felbukkan
            // majd account és jelszó ellenőrzés
            logForm.Close();
            mainForm.Show();
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
    }
}
