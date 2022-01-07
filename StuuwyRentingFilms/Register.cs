using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions; // biblioteka za ne-mutiracki regularni izrazi [regex] - ja koristam za validacija na EMAIL adresa 84 programski red
using System.Data.SqlClient;

namespace StuuwyRentingFilms
{
    public partial class Register : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-27VNER1\TEW_SQLEXPRESS;Initial Catalog=movie_ManagmentSystem;Integrated Security=True"); // konekciski string do data bazata
        bool emailValidation = false;
        bool firstValidation = false;
        bool lastValidation = false;
        public Register()
        {
            InitializeComponent();
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }
        private void Register_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open) // ako konekcijata e otvorena
            {
                con.Close(); // zatvorija
            }
            con.Open(); //..vo sprotivno otvorija
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //Proverka na email pri registracija - ako e zafaten obidise so drug email
            SqlDataAdapter da = new SqlDataAdapter("SELECT email FROM movieUser WHERE email COLLATE Latin1_general_CS_AS ='" + userEmail.Text + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count >= 1) // Ako postoi barem 1 kolona so takvi userName OR email
            {
                labelControl.Text = "Email is already taken.";
                MessageBox.Show("Email is already taken.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // ispisi poraka
                return;
            }
            if (userFirst.Text.Length == 0 || userLast.Text.Length == 0 || userEmail.Text.Length == 0 || userPassword.Text.Length == 0 || userConPass.Text.Length == 0) // ako se prazni textBox-ovite
            {
                labelControl.Text = "All field's are required.";
                MessageBox.Show("Please fill all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // ispisi poraka
                return;
            }
            if (userConPass.Text != userPassword.Text) // ako ne se ednakvi stringovite 
            {
                userPassword.Text = "";
                userConPass.Text = "";
                userPassword.Focus();
                labelControl.Text = "Password don't match.";
                MessageBox.Show("Password don't match", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // ispisi poraka
                return;
            }
            if (emailValidation && firstValidation && lastValidation)
            {
                try
                {
                    String query = "INSERT INTO movieUser (firstName,lastName,email,password) VALUES ('" + userFirst.Text + "','" + userLast.Text + "','" + userEmail.Text + "','" + userPassword.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("You were registered successufully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearTextBox();
                    Show_loginForm();
                }
                catch (System.Exception exp)
                {
                    labelControl.Text = "Something went wrong.";
                    MessageBox.Show("Something went wrong,please try again." + exp.ToString(), "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
            // METODI
        }
        private void userEmail_Leave(object sender, EventArgs e)
        {
            string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$"; // tocna sema na Email
            if (Regex.IsMatch(userEmail.Text, pattern))
                emailValidation = true;
            else
            {
                labelControl.Text = "Email was incorect.";
                MessageBox.Show("Enter valid mail.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // ispisi poraka
                userEmail.Text = "";
                userEmail.Focus();
            }
        }
        private void userLast_Leave(object sender, EventArgs e)
        {
            lastValidation = ValidateString(userFirst, labelLast);
        }
        private void userFirst_Leave(object sender, EventArgs e)
        {
            firstValidation = ValidateString(userFirst, labelFirst);
        }
        private void Show_loginForm()
        {
            this.Hide();
            loginForm lf = new loginForm();
            lf.Show();
        }
        private void ClearTextBox() // metod za brisenje na podatocite vo textBox-ovite
        {
            userFirst.Text = "";
            userLast.Text = "";
            userEmail.Text = "";
            userPassword.Text = "";
            userConPass.Text = "";
        }
        public bool ValidateString(TextBox textBox, Label label)
        {
            if (!Regex.Match(textBox.Text, "^[A-Z\\s][a-zA-Z\\s]+$").Success)
            {
                labelControl.Text = label.Text + " is invalid.";
                MessageBox.Show("Invalid " + label.Text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox.Focus();
                textBox.Text = "";
                return false;
            }
            else
            {
                return true;
            }
        }
        private void iconClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void iconMaximaze_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
                WindowState = FormWindowState.Normal;
        }
        private void iconMinimaze_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}
