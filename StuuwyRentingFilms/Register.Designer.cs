
namespace StuuwyRentingFilms
{
    partial class Register
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
            this.button1 = new System.Windows.Forms.Button();
            this.labelLast = new System.Windows.Forms.Label();
            this.labelFirst = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.labelEmail = new System.Windows.Forms.Label();
            this.labelConfirm = new System.Windows.Forms.Label();
            this.userLast = new System.Windows.Forms.TextBox();
            this.userFirst = new System.Windows.Forms.TextBox();
            this.userPassword = new System.Windows.Forms.TextBox();
            this.userEmail = new System.Windows.Forms.TextBox();
            this.userConPass = new System.Windows.Forms.TextBox();
            this.labelControl = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(250)))), ((int)(((byte)(90)))));
            this.button1.Location = new System.Drawing.Point(145, 287);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 33);
            this.button1.TabIndex = 3;
            this.button1.Text = "Register";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelLast
            // 
            this.labelLast.AutoSize = true;
            this.labelLast.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelLast.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(250)))), ((int)(((byte)(90)))));
            this.labelLast.Location = new System.Drawing.Point(47, 97);
            this.labelLast.Name = "labelLast";
            this.labelLast.Size = new System.Drawing.Size(81, 16);
            this.labelLast.TabIndex = 5;
            this.labelLast.Text = "Last Name";
            // 
            // labelFirst
            // 
            this.labelFirst.AutoSize = true;
            this.labelFirst.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelFirst.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(250)))), ((int)(((byte)(90)))));
            this.labelFirst.Location = new System.Drawing.Point(47, 58);
            this.labelFirst.Name = "labelFirst";
            this.labelFirst.Size = new System.Drawing.Size(82, 16);
            this.labelFirst.TabIndex = 4;
            this.labelFirst.Text = "First Name";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(250)))), ((int)(((byte)(90)))));
            this.labelPassword.Location = new System.Drawing.Point(47, 184);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(75, 16);
            this.labelPassword.TabIndex = 7;
            this.labelPassword.Text = "Password";
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(250)))), ((int)(((byte)(90)))));
            this.labelEmail.Location = new System.Drawing.Point(47, 141);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(46, 16);
            this.labelEmail.TabIndex = 6;
            this.labelEmail.Text = "Email";
            // 
            // labelConfirm
            // 
            this.labelConfirm.AutoSize = true;
            this.labelConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelConfirm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(250)))), ((int)(((byte)(90)))));
            this.labelConfirm.Location = new System.Drawing.Point(37, 221);
            this.labelConfirm.Name = "labelConfirm";
            this.labelConfirm.Size = new System.Drawing.Size(131, 16);
            this.labelConfirm.TabIndex = 8;
            this.labelConfirm.Text = "Confirm Password";
            // 
            // userLast
            // 
            this.userLast.Location = new System.Drawing.Point(174, 93);
            this.userLast.Name = "userLast";
            this.userLast.Size = new System.Drawing.Size(174, 20);
            this.userLast.TabIndex = 10;
            this.userLast.Leave += new System.EventHandler(this.userLast_Leave);
            // 
            // userFirst
            // 
            this.userFirst.Location = new System.Drawing.Point(174, 54);
            this.userFirst.Name = "userFirst";
            this.userFirst.Size = new System.Drawing.Size(174, 20);
            this.userFirst.TabIndex = 9;
            this.userFirst.Leave += new System.EventHandler(this.userFirst_Leave);
            // 
            // userPassword
            // 
            this.userPassword.Location = new System.Drawing.Point(174, 180);
            this.userPassword.Name = "userPassword";
            this.userPassword.Size = new System.Drawing.Size(174, 20);
            this.userPassword.TabIndex = 12;
            // 
            // userEmail
            // 
            this.userEmail.Location = new System.Drawing.Point(174, 137);
            this.userEmail.Name = "userEmail";
            this.userEmail.Size = new System.Drawing.Size(174, 20);
            this.userEmail.TabIndex = 11;
            this.userEmail.Leave += new System.EventHandler(this.userEmail_Leave);
            // 
            // userConPass
            // 
            this.userConPass.Location = new System.Drawing.Point(174, 221);
            this.userConPass.Name = "userConPass";
            this.userConPass.Size = new System.Drawing.Size(174, 20);
            this.userConPass.TabIndex = 13;
            // 
            // labelControl
            // 
            this.labelControl.AutoSize = true;
            this.labelControl.BackColor = System.Drawing.SystemColors.Control;
            this.labelControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelControl.ForeColor = System.Drawing.Color.Red;
            this.labelControl.Location = new System.Drawing.Point(150, -24);
            this.labelControl.Name = "labelControl";
            this.labelControl.Size = new System.Drawing.Size(0, 16);
            this.labelControl.TabIndex = 14;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.panel1.Controls.Add(this.labelFirst);
            this.panel1.Controls.Add(this.labelControl);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.userConPass);
            this.panel1.Controls.Add(this.labelLast);
            this.panel1.Controls.Add(this.userPassword);
            this.panel1.Controls.Add(this.labelEmail);
            this.panel1.Controls.Add(this.userEmail);
            this.panel1.Controls.Add(this.labelPassword);
            this.panel1.Controls.Add(this.userLast);
            this.panel1.Controls.Add(this.labelConfirm);
            this.panel1.Controls.Add(this.userFirst);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(388, 358);
            this.panel1.TabIndex = 15;
            // 
            // Register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 358);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Register";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Register";
            this.Load += new System.EventHandler(this.Register_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelLast;
        private System.Windows.Forms.Label labelFirst;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Label labelConfirm;
        private System.Windows.Forms.TextBox userLast;
        private System.Windows.Forms.TextBox userFirst;
        private System.Windows.Forms.TextBox userPassword;
        private System.Windows.Forms.TextBox userEmail;
        private System.Windows.Forms.TextBox userConPass;
        private System.Windows.Forms.Label labelControl;
        private System.Windows.Forms.Panel panel1;
    }
}