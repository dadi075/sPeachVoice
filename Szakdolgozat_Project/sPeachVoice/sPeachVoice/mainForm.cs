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
    public partial class mainForm : Form
    {
        public mainForm(Bitmap avatar, string stateName, Color stateColor, Main main)
        {
            InitializeComponent();
            setAvatar(avatar);
            setState(stateName, stateColor);
            this.main = main;
            idFromServer = LogInForm.userIdFromServer;
        }

        public static string usernameToShow;
        static uint idFromServer;
        private Main main;


        private void servers_btn_Click(object sender, EventArgs e)
        {
            chat_form chat_form = new chat_form(main);
            chat_form.Show();
        }

        private void options_btn_Click(object sender, EventArgs e)
        {
            optionForm option_form = new optionForm(main);
            option_form.Show();
            this.Close();
        }


        private void mainForm_Load(object sender, EventArgs e)
        {
            //név hozzáad
            name.Text = LogInForm.username;
            usernameToShow = name.Text;

            //kép hozzáad a listához
            ImageList imageList = new ImageList();
            imageList.Images.Add(Bitmap.FromFile("avatar.png"));

            //lista kép beállítása
            availableListView.LargeImageList = imageList;
            availableListView.View = View.LargeIcon;

            //item előkészítése képpel
            ListViewItem item = new ListViewItem();
            item.ImageIndex = 0;
            item.Text = LogInForm.username;
            availableListView.Items.Add(item);

        }
        //option és login formtól kapott kép beállítása az avatar helyére
        public void setAvatar(Bitmap avatar)
        {
            pictureBox1.Image = avatar;
        }
        public void setState(string txt, Color color)
        {
            label2.Text = txt;
            pictureBox2.BackColor = color;
        }

        private void signout_btn_Click(object sender, EventArgs e)
        {
            main.connection.binaryWriter.Write((byte)UserMessageType.logout);
            main.connection.binaryWriter.Write(1);
            main.connection.binaryWriter.Write(idFromServer);
            main.connection.binaryWriter.Flush();
        }
        public void onLogout(int logout_resp)
        {
            if (logout_resp == 1)
            {
                main.connection.closeConnection();
                this.Close();
            }
        }
    }
}
