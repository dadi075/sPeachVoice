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
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.options_btn = new System.Windows.Forms.Button();
            this.servers_btn = new System.Windows.Forms.Button();
            this.conversation_btn = new System.Windows.Forms.Button();
            this.dashboard_panel = new System.Windows.Forms.Panel();
            this.signout_btn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel4.SuspendLayout();
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
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Location = new System.Drawing.Point(0, 112);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(212, 100);
            this.panel3.TabIndex = 1;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Chartreuse;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(69, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "Név";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 50);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel4.Controls.Add(this.signout_btn);
            this.panel4.Controls.Add(this.options_btn);
            this.panel4.Controls.Add(this.servers_btn);
            this.panel4.Controls.Add(this.conversation_btn);
            this.panel4.Location = new System.Drawing.Point(0, 210);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(212, 268);
            this.panel4.TabIndex = 2;
            // 
            // options_btn
            // 
            this.options_btn.BackColor = System.Drawing.Color.LightSalmon;
            this.options_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.options_btn.Font = new System.Drawing.Font("Lucida Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.options_btn.Location = new System.Drawing.Point(0, 120);
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
            this.servers_btn.Location = new System.Drawing.Point(0, 60);
            this.servers_btn.Name = "servers_btn";
            this.servers_btn.Size = new System.Drawing.Size(212, 63);
            this.servers_btn.TabIndex = 1;
            this.servers_btn.Text = "Servers";
            this.servers_btn.UseVisualStyleBackColor = false;
            this.servers_btn.Click += new System.EventHandler(this.servers_btn_Click);
            // 
            // conversation_btn
            // 
            this.conversation_btn.BackColor = System.Drawing.Color.LightSalmon;
            this.conversation_btn.Cursor = System.Windows.Forms.Cursors.Default;
            this.conversation_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.conversation_btn.Font = new System.Drawing.Font("Lucida Sans", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.conversation_btn.Location = new System.Drawing.Point(0, 0);
            this.conversation_btn.Name = "conversation_btn";
            this.conversation_btn.Size = new System.Drawing.Size(212, 63);
            this.conversation_btn.TabIndex = 0;
            this.conversation_btn.Text = "Conversations";
            this.conversation_btn.UseVisualStyleBackColor = false;
            this.conversation_btn.Click += new System.EventHandler(this.conversation_btn_Click);
            // 
            // dashboard_panel
            // 
            this.dashboard_panel.BackColor = System.Drawing.Color.Coral;
            this.dashboard_panel.Location = new System.Drawing.Point(218, 0);
            this.dashboard_panel.Name = "dashboard_panel";
            this.dashboard_panel.Size = new System.Drawing.Size(458, 453);
            this.dashboard_panel.TabIndex = 3;
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
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSalmon;
            this.ClientSize = new System.Drawing.Size(677, 452);
            this.Controls.Add(this.dashboard_panel);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "mainForm";
            this.Text = "sPeach";
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel dashboard_panel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button options_btn;
        private System.Windows.Forms.Button servers_btn;
        private System.Windows.Forms.Button conversation_btn;
        private System.Windows.Forms.Button signout_btn;
    }
}