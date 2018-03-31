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
        public mainForm(Bitmap avatar, string stateName, Color stateColor)
        {
            InitializeComponent();
            setAvatar(avatar);
            setState(stateName, stateColor);
        }
        chat_form chat_form = new chat_form();
        optionForm option_form = new optionForm();

        private void servers_btn_Click(object sender, EventArgs e)
        {
            chat_form.Show();
        }

        private void options_btn_Click(object sender, EventArgs e)
        {
            option_form.Show();
            this.Close();
        }


        private void mainForm_Load(object sender, EventArgs e)
        {
            //név hozzáad
            name.Text = logInForm.username;

            //kép hozzáad a listához
            ImageList imageList = new ImageList();
            imageList.Images.Add(Bitmap.FromFile("avatar.png"));

            //lista kép beállítása
            availableListView.LargeImageList = imageList;
            availableListView.View = View.LargeIcon;

            //item előkészítése képpel
            ListViewItem item = new ListViewItem();
            item.ImageIndex = 0;
            item.Text = logInForm.username;
            availableListView.Items.Add(item);

        }
        //option formtól kapott kép beállítása az avatar helyére
        public void setAvatar(Bitmap avatar)
        {
            pictureBox1.Image = avatar;
        }
        public void setState(string txt, Color color)
        {
            label2.Text = txt;
            pictureBox2.BackColor = color;
        }
    }
}
