namespace sPeachVoice
{
    partial class logInForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(logInForm));
            this.username_text = new System.Windows.Forms.TextBox();
            this.signIn_btn = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pass_text = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // username_text
            // 
            this.username_text.BackColor = System.Drawing.Color.SeaShell;
            this.username_text.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.username_text.Dock = System.Windows.Forms.DockStyle.Fill;
            this.username_text.Font = new System.Drawing.Font("Lucida Sans", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username_text.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.username_text.Location = new System.Drawing.Point(0, 0);
            this.username_text.Name = "username_text";
            this.username_text.Size = new System.Drawing.Size(233, 32);
            this.username_text.TabIndex = 1;
            this.username_text.Text = "Username";
            this.username_text.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.username_text.Click += new System.EventHandler(this.textBox1_Click);
            this.username_text.TextChanged += new System.EventHandler(this.username_text_TextChanged);
            // 
            // signIn_btn
            // 
            this.signIn_btn.BackColor = System.Drawing.Color.SeaShell;
            this.signIn_btn.FlatAppearance.BorderSize = 0;
            this.signIn_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.signIn_btn.Font = new System.Drawing.Font("Lucida Sans", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signIn_btn.Location = new System.Drawing.Point(156, 303);
            this.signIn_btn.Name = "signIn_btn";
            this.signIn_btn.Size = new System.Drawing.Size(99, 33);
            this.signIn_btn.TabIndex = 3;
            this.signIn_btn.Text = "Sign In";
            this.signIn_btn.UseVisualStyleBackColor = false;
            this.signIn_btn.Click += new System.EventHandler(this.button1_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Lucida Sans", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(88, 379);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(257, 13);
            this.linkLabel1.TabIndex = 4;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "If you don\'t have an account, register!";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.username_text);
            this.panel1.Location = new System.Drawing.Point(100, 207);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(233, 37);
            this.panel1.TabIndex = 6;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.pass_text);
            this.panel3.Location = new System.Drawing.Point(100, 260);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(233, 37);
            this.panel3.TabIndex = 8;
            // 
            // pass_text
            // 
            this.pass_text.BackColor = System.Drawing.Color.SeaShell;
            this.pass_text.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pass_text.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pass_text.Font = new System.Drawing.Font("Lucida Sans", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pass_text.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.pass_text.Location = new System.Drawing.Point(0, 0);
            this.pass_text.Name = "pass_text";
            this.pass_text.Size = new System.Drawing.Size(233, 32);
            this.pass_text.TabIndex = 8;
            this.pass_text.Text = "Password";
            this.pass_text.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.pass_text.Click += new System.EventHandler(this.textBox2_Click);
            this.pass_text.TextChanged += new System.EventHandler(this.pass_text_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(91, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(242, 153);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // logInForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Bisque;
            this.ClientSize = new System.Drawing.Size(443, 439);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.signIn_btn);
            this.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "logInForm";
            this.Text = "Log In";
            this.Click += new System.EventHandler(this.logInForm_Click);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox username_text;
        private System.Windows.Forms.Button signIn_btn;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox pass_text;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

