namespace sPeachVoice
{
    partial class mainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.signout_btn = new System.Windows.Forms.Button();
            this.options_btn = new System.Windows.Forms.Button();
            this.servers_btn = new System.Windows.Forms.Button();
            this.dashboard_panel = new System.Windows.Forms.Panel();
            this.availableListView = new System.Windows.Forms.ListView();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel4.SuspendLayout();
            this.dashboard_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSalmon;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(212, 112);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(0, 112);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(212, 106);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightSalmon;
            this.panel3.Controls.Add(this.pictureBox2);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.name);
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Location = new System.Drawing.Point(0, 112);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(212, 100);
            this.panel3.TabIndex = 1;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Chartreuse;
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(161, 54);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(12, 12);
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Sans", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(94, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Available";
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.Font = new System.Drawing.Font("Lucida Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name.Location = new System.Drawing.Point(93, 16);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(46, 22);
            this.name.TabIndex = 1;
            this.name.Text = "Név";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.OrangeRed;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 64);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Coral;
            this.panel4.Controls.Add(this.signout_btn);
            this.panel4.Controls.Add(this.options_btn);
            this.panel4.Controls.Add(this.servers_btn);
            this.panel4.Location = new System.Drawing.Point(0, 218);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(212, 235);
            this.panel4.TabIndex = 2;
            // 
            // signout_btn
            // 
            this.signout_btn.BackColor = System.Drawing.Color.LightSalmon;
            this.signout_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.signout_btn.Font = new System.Drawing.Font("Lucida Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.signout_btn.Location = new System.Drawing.Point(0, 180);
            this.signout_btn.Name = "signout_btn";
            this.signout_btn.Size = new System.Drawing.Size(212, 63);
            this.signout_btn.TabIndex = 3;
            this.signout_btn.Text = "Sign Out";
            this.signout_btn.UseVisualStyleBackColor = false;
            // 
            // options_btn
            // 
            this.options_btn.BackColor = System.Drawing.Color.LightSalmon;
            this.options_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.options_btn.Font = new System.Drawing.Font("Lucida Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.options_btn.Location = new System.Drawing.Point(0, 60);
            this.options_btn.Name = "options_btn";
            this.options_btn.Size = new System.Drawing.Size(212, 63);
            this.options_btn.TabIndex = 2;
            this.options_btn.Text = "Options";
            this.options_btn.UseVisualStyleBackColor = false;
            this.options_btn.Click += new System.EventHandler(this.options_btn_Click);
            // 
            // servers_btn
            // 
            this.servers_btn.BackColor = System.Drawing.Color.LightSalmon;
            this.servers_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.servers_btn.Font = new System.Drawing.Font("Lucida Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.servers_btn.Location = new System.Drawing.Point(0, 0);
            this.servers_btn.Name = "servers_btn";
            this.servers_btn.Size = new System.Drawing.Size(212, 61);
            this.servers_btn.TabIndex = 1;
            this.servers_btn.Text = "Chat";
            this.servers_btn.UseVisualStyleBackColor = false;
            this.servers_btn.Click += new System.EventHandler(this.servers_btn_Click);
            // 
            // dashboard_panel
            // 
            this.dashboard_panel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.dashboard_panel.BackColor = System.Drawing.Color.Coral;
            this.dashboard_panel.Controls.Add(this.availableListView);
            this.dashboard_panel.Controls.Add(this.label3);
            this.dashboard_panel.Location = new System.Drawing.Point(218, 0);
            this.dashboard_panel.Name = "dashboard_panel";
            this.dashboard_panel.Size = new System.Drawing.Size(458, 453);
            this.dashboard_panel.TabIndex = 3;
            // 
            // availableListView
            // 
            this.availableListView.BackColor = System.Drawing.Color.Coral;
            this.availableListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.availableListView.Location = new System.Drawing.Point(17, 36);
            this.availableListView.Name = "availableListView";
            this.availableListView.Size = new System.Drawing.Size(430, 404);
            this.availableListView.TabIndex = 1;
            this.availableListView.UseCompatibleStateImageBehavior = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.label3.Location = new System.Drawing.Point(13, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 24);
            this.label3.TabIndex = 0;
            this.label3.Text = "Available Users";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSalmon;
            this.ClientSize = new System.Drawing.Size(677, 453);
            this.Controls.Add(this.dashboard_panel);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "mainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "sPeach";
            this.Load += new System.EventHandler(this.mainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.dashboard_panel.ResumeLayout(false);
            this.dashboard_panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel dashboard_panel;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button options_btn;
        private System.Windows.Forms.Button servers_btn;
        private System.Windows.Forms.Button signout_btn;
        private System.Windows.Forms.ListView availableListView;
        private System.Windows.Forms.Label label3;
    }
}