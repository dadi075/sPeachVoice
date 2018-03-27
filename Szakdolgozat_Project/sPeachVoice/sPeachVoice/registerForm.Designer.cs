namespace sPeachVoice
{
    partial class registerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(registerForm));
            this.label1 = new System.Windows.Forms.Label();
            this.username_text = new System.Windows.Forms.TextBox();
            this.email_text = new System.Windows.Forms.TextBox();
            this.password_text = new System.Windows.Forms.TextBox();
            this.password2_text = new System.Windows.Forms.TextBox();
            this.register_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Sans", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(374, 43);
            this.label1.TabIndex = 0;
            this.label1.Text = "Create an account";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // username_text
            // 
            this.username_text.BackColor = System.Drawing.Color.SeaShell;
            this.username_text.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.username_text.Font = new System.Drawing.Font("Lucida Sans", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username_text.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.username_text.Location = new System.Drawing.Point(44, 105);
            this.username_text.Name = "username_text";
            this.username_text.Size = new System.Drawing.Size(366, 33);
            this.username_text.TabIndex = 1;
            this.username_text.Text = "Username";
            this.username_text.Click += new System.EventHandler(this.textBox1_Click);
            this.username_text.TextChanged += new System.EventHandler(this.username_text_TextChanged);
            // 
            // email_text
            // 
            this.email_text.BackColor = System.Drawing.Color.SeaShell;
            this.email_text.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.email_text.Font = new System.Drawing.Font("Lucida Sans", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.email_text.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.email_text.Location = new System.Drawing.Point(44, 149);
            this.email_text.Name = "email_text";
            this.email_text.Size = new System.Drawing.Size(366, 33);
            this.email_text.TabIndex = 2;
            this.email_text.Text = "E-mail";
            this.email_text.Click += new System.EventHandler(this.textBox2_Click);
            this.email_text.TextChanged += new System.EventHandler(this.email_text_TextChanged);
            // 
            // password_text
            // 
            this.password_text.BackColor = System.Drawing.Color.SeaShell;
            this.password_text.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.password_text.Font = new System.Drawing.Font("Lucida Sans", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password_text.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.password_text.Location = new System.Drawing.Point(44, 192);
            this.password_text.Name = "password_text";
            this.password_text.Size = new System.Drawing.Size(366, 33);
            this.password_text.TabIndex = 3;
            this.password_text.Text = "Password";
            this.password_text.Click += new System.EventHandler(this.textBox3_Click);
            this.password_text.TextChanged += new System.EventHandler(this.password_text_TextChanged);
            // 
            // password2_text
            // 
            this.password2_text.BackColor = System.Drawing.Color.SeaShell;
            this.password2_text.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.password2_text.Font = new System.Drawing.Font("Lucida Sans", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password2_text.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.password2_text.Location = new System.Drawing.Point(44, 237);
            this.password2_text.Name = "password2_text";
            this.password2_text.Size = new System.Drawing.Size(366, 33);
            this.password2_text.TabIndex = 4;
            this.password2_text.Text = "Confirm Password";
            this.password2_text.Click += new System.EventHandler(this.textBox4_Click);
            this.password2_text.TextChanged += new System.EventHandler(this.password2_text_TextChanged);
            // 
            // register_btn
            // 
            this.register_btn.BackColor = System.Drawing.Color.SeaShell;
            this.register_btn.FlatAppearance.BorderSize = 0;
            this.register_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.register_btn.Font = new System.Drawing.Font("Lucida Sans", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.register_btn.Location = new System.Drawing.Point(44, 331);
            this.register_btn.Name = "register_btn";
            this.register_btn.Size = new System.Drawing.Size(366, 48);
            this.register_btn.TabIndex = 5;
            this.register_btn.Text = "Register";
            this.register_btn.UseVisualStyleBackColor = false;
            this.register_btn.Click += new System.EventHandler(this.button1_Click);
            // 
            // registerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Bisque;
            this.ClientSize = new System.Drawing.Size(452, 468);
            this.Controls.Add(this.register_btn);
            this.Controls.Add(this.password2_text);
            this.Controls.Add(this.password_text);
            this.Controls.Add(this.email_text);
            this.Controls.Add(this.username_text);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Lucida Sans", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "registerForm";
            this.Text = "Register";
            this.Click += new System.EventHandler(this.registerForm_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox username_text;
        private System.Windows.Forms.TextBox email_text;
        private System.Windows.Forms.TextBox password_text;
        private System.Windows.Forms.TextBox password2_text;
        private System.Windows.Forms.Button register_btn;
    }
}