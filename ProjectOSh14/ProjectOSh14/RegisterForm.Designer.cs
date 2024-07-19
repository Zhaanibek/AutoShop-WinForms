namespace ProjectOSh14
{
    partial class RegisterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.LogField = new System.Windows.Forms.TextBox();
            this.PassField = new System.Windows.Forms.TextBox();
            this.Registration = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.userNameField = new System.Windows.Forms.TextBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.userSurnameField = new System.Windows.Forms.TextBox();
            this.AuthorizationLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.MainPanel1 = new System.Windows.Forms.Panel();
            this.RegisterErrorLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonLogin = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.panel1.SuspendLayout();
            this.MainPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(61, 288);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(84, 81);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(61, 391);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(84, 81);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 3;
            this.pictureBox3.TabStop = false;
            // 
            // LogField
            // 
            this.LogField.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.LogField.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LogField.Location = new System.Drawing.Point(151, 288);
            this.LogField.Name = "LogField";
            this.LogField.Size = new System.Drawing.Size(645, 81);
            this.LogField.TabIndex = 2;
            this.LogField.TextChanged += new System.EventHandler(this.LogField_TextChanged);
            this.LogField.Enter += new System.EventHandler(this.LogField_Enter);
            this.LogField.Leave += new System.EventHandler(this.LogField_Leave);
            // 
            // PassField
            // 
            this.PassField.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PassField.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PassField.Location = new System.Drawing.Point(151, 391);
            this.PassField.Name = "PassField";
            this.PassField.Size = new System.Drawing.Size(645, 81);
            this.PassField.TabIndex = 4;
            this.PassField.UseSystemPasswordChar = true;
            this.PassField.Enter += new System.EventHandler(this.PassField_Enter);
            this.PassField.Leave += new System.EventHandler(this.PassField_Leave);
            // 
            // Registration
            // 
            this.Registration.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(31)))));
            this.Registration.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Registration.ForeColor = System.Drawing.Color.White;
            this.Registration.Location = new System.Drawing.Point(199, 124);
            this.Registration.Name = "Registration";
            this.Registration.Size = new System.Drawing.Size(493, 85);
            this.Registration.TabIndex = 8;
            this.Registration.Text = "Sign Up";
            this.Registration.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Registration.Click += new System.EventHandler(this.Registration_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(61, 489);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(84, 81);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // userNameField
            // 
            this.userNameField.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.userNameField.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.userNameField.Location = new System.Drawing.Point(151, 489);
            this.userNameField.Name = "userNameField";
            this.userNameField.Size = new System.Drawing.Size(645, 81);
            this.userNameField.TabIndex = 8;
            this.userNameField.Enter += new System.EventHandler(this.userNameField_Enter);
            this.userNameField.Leave += new System.EventHandler(this.userNameField_Leave);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(61, 589);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(84, 81);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 9;
            this.pictureBox4.TabStop = false;
            // 
            // userSurnameField
            // 
            this.userSurnameField.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.userSurnameField.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.userSurnameField.Location = new System.Drawing.Point(151, 589);
            this.userSurnameField.Name = "userSurnameField";
            this.userSurnameField.Size = new System.Drawing.Size(645, 81);
            this.userSurnameField.TabIndex = 8;
            this.userSurnameField.TextChanged += new System.EventHandler(this.userSurnameField_TextChanged);
            this.userSurnameField.Enter += new System.EventHandler(this.userSurnameField_Enter);
            this.userSurnameField.Leave += new System.EventHandler(this.userSurnameField_Leave);
            // 
            // AuthorizationLabel
            // 
            this.AuthorizationLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.AuthorizationLabel.AutoSize = true;
            this.AuthorizationLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AuthorizationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AuthorizationLabel.ForeColor = System.Drawing.Color.White;
            this.AuthorizationLabel.Location = new System.Drawing.Point(387, 845);
            this.AuthorizationLabel.Name = "AuthorizationLabel";
            this.AuthorizationLabel.Size = new System.Drawing.Size(70, 25);
            this.AuthorizationLabel.TabIndex = 2;
            this.AuthorizationLabel.Text = "Login";
            this.AuthorizationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.AuthorizationLabel.Click += new System.EventHandler(this.AuthorizationLabel_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(31)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(892, 77);
            this.panel1.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(31)))));
            this.label1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(812, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 77);
            this.label1.TabIndex = 3;
            this.label1.Text = "X";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // MainPanel1
            // 
            this.MainPanel1.AutoSize = true;
            this.MainPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(31)))));
            this.MainPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MainPanel1.Controls.Add(this.RegisterErrorLabel);
            this.MainPanel1.Controls.Add(this.label2);
            this.MainPanel1.Controls.Add(this.panel1);
            this.MainPanel1.Controls.Add(this.AuthorizationLabel);
            this.MainPanel1.Controls.Add(this.userSurnameField);
            this.MainPanel1.Controls.Add(this.pictureBox4);
            this.MainPanel1.Controls.Add(this.userNameField);
            this.MainPanel1.Controls.Add(this.pictureBox2);
            this.MainPanel1.Controls.Add(this.Registration);
            this.MainPanel1.Controls.Add(this.PassField);
            this.MainPanel1.Controls.Add(this.LogField);
            this.MainPanel1.Controls.Add(this.buttonLogin);
            this.MainPanel1.Controls.Add(this.pictureBox3);
            this.MainPanel1.Controls.Add(this.pictureBox1);
            this.MainPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel1.Location = new System.Drawing.Point(0, 0);
            this.MainPanel1.Name = "MainPanel1";
            this.MainPanel1.Size = new System.Drawing.Size(892, 949);
            this.MainPanel1.TabIndex = 1;
            this.MainPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.MainPanel1_Paint);
            this.MainPanel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainPanel1_MouseDown);
            this.MainPanel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainPanel1_MouseMove);
            // 
            // RegisterErrorLabel
            // 
            this.RegisterErrorLabel.AutoSize = true;
            this.RegisterErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.RegisterErrorLabel.Location = new System.Drawing.Point(146, 709);
            this.RegisterErrorLabel.Name = "RegisterErrorLabel";
            this.RegisterErrorLabel.Size = new System.Drawing.Size(0, 25);
            this.RegisterErrorLabel.TabIndex = 13;
            this.RegisterErrorLabel.Click += new System.EventHandler(this.RegisterErrorLabel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(146, 696);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 25);
            this.label2.TabIndex = 12;
            // 
            // buttonLogin
            // 
            this.buttonLogin.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(31)))));
            this.buttonLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonLogin.FlatAppearance.BorderSize = 2;
            this.buttonLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogin.ForeColor = System.Drawing.Color.White;
            this.buttonLogin.Location = new System.Drawing.Point(307, 757);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(237, 70);
            this.buttonLogin.TabIndex = 5;
            this.buttonLogin.Text = "Registration";
            this.buttonLogin.UseVisualStyleBackColor = false;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            this.buttonLogin.MouseEnter += new System.EventHandler(this.buttonLogin_MouseEnter);
            this.buttonLogin.MouseLeave += new System.EventHandler(this.buttonLogin_MouseLeave);
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 949);
            this.Controls.Add(this.MainPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RegisterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RegisterForm";
            this.Load += new System.EventHandler(this.RegisterForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.panel1.ResumeLayout(false);
            this.MainPanel1.ResumeLayout(false);
            this.MainPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.TextBox LogField;
        private System.Windows.Forms.TextBox PassField;
        private System.Windows.Forms.Label Registration;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox userNameField;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.TextBox userSurnameField;
        private System.Windows.Forms.Label AuthorizationLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel MainPanel1;
        private System.Windows.Forms.Label RegisterErrorLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonLogin;
    }
}