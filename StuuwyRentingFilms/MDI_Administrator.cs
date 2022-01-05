using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace StuuwyRentingFilms
{
    public partial class MDI_Administrator : Form
    {
        private IconButton currentBtn;
        private Panel leftBoarderBtn;
        private Form CurrentChildForm;
        public MDI_Administrator()
        {
            InitializeComponent();
            leftBoarderBtn = new Panel();
            leftBoarderBtn.Size = new Size(7, 60);
            panelMenu.Controls.Add(leftBoarderBtn);
            //Form --> control buttons
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }
        //STRUCTURE
        private struct RGBColors
        {
            public static Color color1 = Color.FromArgb(172, 126, 241);
            public static Color color2 = Color.FromArgb(249, 118, 176);
            public static Color color3 = Color.FromArgb(253, 138, 114);
            public static Color color4 = Color.FromArgb(95, 77, 221);
            public static Color color5 = Color.FromArgb(249, 88, 155);
            public static Color color6 = Color.FromArgb(24, 161, 251);
            public static Color color7 = Color.FromArgb(102, 34, 204);
        }
        //METHODS
        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                //Button
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(37, 36, 81);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleRight;
                //Left border button
                leftBoarderBtn.BackColor = color;
                leftBoarderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBoarderBtn.Visible = true;
                leftBoarderBtn.BringToFront();
                //Icon Current Child form
                iconCurrentChildForm.IconChar = currentBtn.IconChar;
                iconCurrentChildForm.IconColor = color;
            }
        }
        private void DisableButton()
        {
            if (currentBtn != null)
            {
                //Button
                currentBtn.BackColor = Color.FromArgb(31, 30, 68);
                currentBtn.ForeColor = Color.Gainsboro;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.Gainsboro;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }
        private void Reset()
        {
            DisableButton();
            leftBoarderBtn.Visible = false;
            iconCurrentChildForm.IconChar = IconChar.Home;
            iconCurrentChildForm.IconColor = Color.MediumPurple;
            lblTitleChildForm.Text = "Home";
        }
        private void OpenChildForm(Form childForm)
        {
            if (CurrentChildForm != null)
            {
                CurrentChildForm.Close();
            }
            CurrentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitleChildForm.Text = childForm.Text;
        }
        //EVENTS
        private void iconAddNewMovie_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color1);
            OpenChildForm(new Add_Movie());
        }
        private void iconIssueMovie_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color2);
        }
        private void iconMovieRecord_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color3);
        }
        private void iconMovieReport_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color4);
        }
        private void iconAddUser_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color5);
            OpenChildForm(new Register());
            lblTitleChildForm.Text = "Register";
        }
        private void iconViewUserInfo_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color6);
        }
        private void iconUpdateMovieInfo_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color7);
            OpenChildForm(new Update_Movie());
        }
        private void iconUserLogout_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.color3);
            loginForm lf = new loginForm();
            lf.Show();
            this.Hide();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            Reset();
        }
        // Drag Form
        // DLL -dynamic link library [Inheritance > Object > Attribute > DllImportAttribute]
        // extern = modifikator koj se koristi za deklariranje metod koj e implementiran externally[nadvor od nasiot kod] - vo ovaj slucaj so DllImport mora da se deklarira static 
        // entryPoint = ja identifikuva lokacijata na funkcijata vo eden DLL
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMSH, int wParam, int lParam);
        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void iconClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void iconMaximaze_Click(object sender, EventArgs e) //maximaze
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
                WindowState = FormWindowState.Normal;
        }
        private void iconMinimaze_Click(object sender, EventArgs e) // minimaze
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}
