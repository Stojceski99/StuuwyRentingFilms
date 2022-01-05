
namespace StuuwyRentingFilms
{
    partial class MDI_User
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MDI_User));
            this.panelMenu = new System.Windows.Forms.Panel();
            this.iconUserLogout = new FontAwesome.Sharp.IconButton();
            this.iconReturnMovie = new FontAwesome.Sharp.IconButton();
            this.iconViewMovies = new FontAwesome.Sharp.IconButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnHome = new System.Windows.Forms.PictureBox();
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.iconMinimaze = new FontAwesome.Sharp.IconPictureBox();
            this.iconMaximaze = new FontAwesome.Sharp.IconPictureBox();
            this.iconClose = new FontAwesome.Sharp.IconPictureBox();
            this.lblTitleChildForm = new System.Windows.Forms.Label();
            this.iconCurrentChildForm = new FontAwesome.Sharp.IconPictureBox();
            this.panelShadow = new System.Windows.Forms.Panel();
            this.panelDesktop = new System.Windows.Forms.Panel();
            this.panelMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnHome)).BeginInit();
            this.panelTitleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconMinimaze)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconMaximaze)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconCurrentChildForm)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(30)))), ((int)(((byte)(68)))));
            this.panelMenu.Controls.Add(this.iconUserLogout);
            this.panelMenu.Controls.Add(this.iconReturnMovie);
            this.panelMenu.Controls.Add(this.iconViewMovies);
            this.panelMenu.Controls.Add(this.panel1);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(220, 686);
            this.panelMenu.TabIndex = 0;
            // 
            // iconUserLogout
            // 
            this.iconUserLogout.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.iconUserLogout.FlatAppearance.BorderSize = 0;
            this.iconUserLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconUserLogout.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.iconUserLogout.ForeColor = System.Drawing.Color.Gainsboro;
            this.iconUserLogout.IconChar = FontAwesome.Sharp.IconChar.ArrowAltCircleLeft;
            this.iconUserLogout.IconColor = System.Drawing.Color.Gainsboro;
            this.iconUserLogout.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconUserLogout.IconSize = 40;
            this.iconUserLogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconUserLogout.Location = new System.Drawing.Point(0, 626);
            this.iconUserLogout.Name = "iconUserLogout";
            this.iconUserLogout.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.iconUserLogout.Size = new System.Drawing.Size(220, 60);
            this.iconUserLogout.TabIndex = 3;
            this.iconUserLogout.Text = "Logout";
            this.iconUserLogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconUserLogout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconUserLogout.UseVisualStyleBackColor = true;
            this.iconUserLogout.Click += new System.EventHandler(this.iconUserLogout_Click);
            // 
            // iconReturnMovie
            // 
            this.iconReturnMovie.Dock = System.Windows.Forms.DockStyle.Top;
            this.iconReturnMovie.FlatAppearance.BorderSize = 0;
            this.iconReturnMovie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconReturnMovie.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.iconReturnMovie.ForeColor = System.Drawing.Color.Gainsboro;
            this.iconReturnMovie.IconChar = FontAwesome.Sharp.IconChar.ExchangeAlt;
            this.iconReturnMovie.IconColor = System.Drawing.Color.Gainsboro;
            this.iconReturnMovie.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconReturnMovie.IconSize = 40;
            this.iconReturnMovie.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconReturnMovie.Location = new System.Drawing.Point(0, 200);
            this.iconReturnMovie.Name = "iconReturnMovie";
            this.iconReturnMovie.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.iconReturnMovie.Size = new System.Drawing.Size(220, 60);
            this.iconReturnMovie.TabIndex = 2;
            this.iconReturnMovie.Text = "Return Movie";
            this.iconReturnMovie.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconReturnMovie.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconReturnMovie.UseVisualStyleBackColor = true;
            this.iconReturnMovie.Click += new System.EventHandler(this.iconReturnMovie_Click);
            // 
            // iconViewMovies
            // 
            this.iconViewMovies.Dock = System.Windows.Forms.DockStyle.Top;
            this.iconViewMovies.FlatAppearance.BorderSize = 0;
            this.iconViewMovies.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconViewMovies.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.iconViewMovies.ForeColor = System.Drawing.Color.Gainsboro;
            this.iconViewMovies.IconChar = FontAwesome.Sharp.IconChar.Eye;
            this.iconViewMovies.IconColor = System.Drawing.Color.Gainsboro;
            this.iconViewMovies.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconViewMovies.IconSize = 40;
            this.iconViewMovies.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconViewMovies.Location = new System.Drawing.Point(0, 140);
            this.iconViewMovies.Name = "iconViewMovies";
            this.iconViewMovies.Padding = new System.Windows.Forms.Padding(10, 0, 20, 0);
            this.iconViewMovies.Size = new System.Drawing.Size(220, 60);
            this.iconViewMovies.TabIndex = 1;
            this.iconViewMovies.Text = "View Movies";
            this.iconViewMovies.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconViewMovies.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconViewMovies.UseVisualStyleBackColor = true;
            this.iconViewMovies.Click += new System.EventHandler(this.iconViewMovies_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnHome);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(220, 140);
            this.panel1.TabIndex = 0;
            // 
            // btnHome
            // 
            this.btnHome.Image = ((System.Drawing.Image)(resources.GetObject("btnHome.Image")));
            this.btnHome.Location = new System.Drawing.Point(-217, 0);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(437, 134);
            this.btnHome.TabIndex = 0;
            this.btnHome.TabStop = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(25)))), ((int)(((byte)(62)))));
            this.panelTitleBar.Controls.Add(this.iconMinimaze);
            this.panelTitleBar.Controls.Add(this.iconMaximaze);
            this.panelTitleBar.Controls.Add(this.iconClose);
            this.panelTitleBar.Controls.Add(this.lblTitleChildForm);
            this.panelTitleBar.Controls.Add(this.iconCurrentChildForm);
            this.panelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitleBar.Location = new System.Drawing.Point(220, 0);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Size = new System.Drawing.Size(1070, 75);
            this.panelTitleBar.TabIndex = 1;
            this.panelTitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitleBar_MouseDown);
            // 
            // iconMinimaze
            // 
            this.iconMinimaze.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconMinimaze.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(25)))), ((int)(((byte)(62)))));
            this.iconMinimaze.ForeColor = System.Drawing.Color.MediumPurple;
            this.iconMinimaze.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize;
            this.iconMinimaze.IconColor = System.Drawing.Color.MediumPurple;
            this.iconMinimaze.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconMinimaze.IconSize = 24;
            this.iconMinimaze.Location = new System.Drawing.Point(1001, 3);
            this.iconMinimaze.Name = "iconMinimaze";
            this.iconMinimaze.Size = new System.Drawing.Size(24, 24);
            this.iconMinimaze.TabIndex = 4;
            this.iconMinimaze.TabStop = false;
            this.iconMinimaze.Click += new System.EventHandler(this.iconMinimaze_Click);
            // 
            // iconMaximaze
            // 
            this.iconMaximaze.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconMaximaze.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(25)))), ((int)(((byte)(62)))));
            this.iconMaximaze.ForeColor = System.Drawing.Color.MediumPurple;
            this.iconMaximaze.IconChar = FontAwesome.Sharp.IconChar.WindowRestore;
            this.iconMaximaze.IconColor = System.Drawing.Color.MediumPurple;
            this.iconMaximaze.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconMaximaze.IconSize = 24;
            this.iconMaximaze.Location = new System.Drawing.Point(1022, 3);
            this.iconMaximaze.Name = "iconMaximaze";
            this.iconMaximaze.Size = new System.Drawing.Size(24, 24);
            this.iconMaximaze.TabIndex = 3;
            this.iconMaximaze.TabStop = false;
            this.iconMaximaze.Click += new System.EventHandler(this.iconButton2_Click);
            // 
            // iconClose
            // 
            this.iconClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.iconClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(25)))), ((int)(((byte)(62)))));
            this.iconClose.ForeColor = System.Drawing.Color.MediumPurple;
            this.iconClose.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.iconClose.IconColor = System.Drawing.Color.MediumPurple;
            this.iconClose.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconClose.IconSize = 24;
            this.iconClose.Location = new System.Drawing.Point(1043, 3);
            this.iconClose.Name = "iconClose";
            this.iconClose.Size = new System.Drawing.Size(24, 24);
            this.iconClose.TabIndex = 2;
            this.iconClose.TabStop = false;
            this.iconClose.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // lblTitleChildForm
            // 
            this.lblTitleChildForm.AutoSize = true;
            this.lblTitleChildForm.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitleChildForm.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblTitleChildForm.Location = new System.Drawing.Point(56, 45);
            this.lblTitleChildForm.Name = "lblTitleChildForm";
            this.lblTitleChildForm.Size = new System.Drawing.Size(49, 17);
            this.lblTitleChildForm.TabIndex = 1;
            this.lblTitleChildForm.Text = " Home";
            // 
            // iconCurrentChildForm
            // 
            this.iconCurrentChildForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(25)))), ((int)(((byte)(62)))));
            this.iconCurrentChildForm.ForeColor = System.Drawing.Color.MediumPurple;
            this.iconCurrentChildForm.IconChar = FontAwesome.Sharp.IconChar.Home;
            this.iconCurrentChildForm.IconColor = System.Drawing.Color.MediumPurple;
            this.iconCurrentChildForm.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconCurrentChildForm.IconSize = 43;
            this.iconCurrentChildForm.Location = new System.Drawing.Point(6, 29);
            this.iconCurrentChildForm.Name = "iconCurrentChildForm";
            this.iconCurrentChildForm.Size = new System.Drawing.Size(44, 43);
            this.iconCurrentChildForm.TabIndex = 0;
            this.iconCurrentChildForm.TabStop = false;
            // 
            // panelShadow
            // 
            this.panelShadow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(24)))), ((int)(((byte)(58)))));
            this.panelShadow.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelShadow.Location = new System.Drawing.Point(220, 75);
            this.panelShadow.Name = "panelShadow";
            this.panelShadow.Size = new System.Drawing.Size(1070, 9);
            this.panelShadow.TabIndex = 2;
            // 
            // panelDesktop
            // 
            this.panelDesktop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(33)))), ((int)(((byte)(74)))));
            this.panelDesktop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktop.Location = new System.Drawing.Point(220, 84);
            this.panelDesktop.Name = "panelDesktop";
            this.panelDesktop.Size = new System.Drawing.Size(1070, 602);
            this.panelDesktop.TabIndex = 3;
            // 
            // MDI_User
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1290, 686);
            this.Controls.Add(this.panelDesktop);
            this.Controls.Add(this.panelShadow);
            this.Controls.Add(this.panelTitleBar);
            this.Controls.Add(this.panelMenu);
            this.Name = "MDI_User";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Interface";
            this.panelMenu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnHome)).EndInit();
            this.panelTitleBar.ResumeLayout(false);
            this.panelTitleBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconMinimaze)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconMaximaze)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconCurrentChildForm)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton iconUserLogout;
        private FontAwesome.Sharp.IconButton iconReturnMovie;
        private FontAwesome.Sharp.IconButton iconViewMovies;
        private System.Windows.Forms.PictureBox btnHome;
        private System.Windows.Forms.Panel panelTitleBar;
        private System.Windows.Forms.Label lblTitleChildForm;
        private FontAwesome.Sharp.IconPictureBox iconCurrentChildForm;
        private System.Windows.Forms.Panel panelShadow;
        private System.Windows.Forms.Panel panelDesktop;
        private FontAwesome.Sharp.IconPictureBox iconMinimaze;
        private FontAwesome.Sharp.IconPictureBox iconMaximaze;
        private FontAwesome.Sharp.IconPictureBox iconClose;
    }
}