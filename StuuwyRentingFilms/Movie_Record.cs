using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;

namespace StuuwyRentingFilms
{
    public partial class Movie_Record : Form
    {
        readonly SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-27VNER1\TEW_SQLEXPRESS;Initial Catalog=movie_ManagmentSystem;Integrated Security=True"); // konekciski string do data bazata
        public Movie_Record()
        {
            InitializeComponent();
        }

        private void Movie_Record_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            FillMovieInfo();
        }
        //Metodi
        private void FillMovieInfo()
        {
            String query = "SELECT movieTitle, movieGenre, movieProducer, movieAvailableQuantity from Movie";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView2.Visible = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            String i;
            i = dataGridView1.SelectedCells[0].Value.ToString();

            String query = "SELECT * FROM MovieIssue WHERE movieTitle='" + i.ToString() + "' AND movieReturnDate=''";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            dataGridView2.Visible = true;
        }

        private void textBox3_KeyUp(object sender, KeyEventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            int i;
            String queryValidate = "SELECT movieTitle,movieGenre,movieProducer,movieAvailableQuantity FROM Movie WHERE movieTitle like ('%" + textBox3.Text + "%')";
            SqlCommand cmdValidate = new SqlCommand(queryValidate, con);
            cmdValidate.ExecuteNonQuery();
            DataTable dtValidate = new DataTable();
            SqlDataAdapter daValidate = new SqlDataAdapter(cmdValidate);
            daValidate.Fill(dtValidate);
            i = Convert.ToInt32(dtValidate.Rows.Count.ToString());
            if (i == 0)
            {
                labelControl.Text = "No such movie,try again.";
                textBox3.Text = "";
                MessageBox.Show("No such movie,try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                String query = "SELECT movieTitle,movieGenre,movieProducer,movieAvailableQuantity FROM Movie WHERE movieTitle like ('%" + textBox3.Text + "%')";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                dataGridView2.Visible = false;
            }
        }
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            String i;
            i = dataGridView2.SelectedCells[2].Value.ToString();
            textBox1.Text = i.ToString();
            panel1.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;

            // Username, password from admin
            smtp.Credentials = new NetworkCredential("stuuwylibrary@gmail.com", "stuuwyLibraryAdmin123!");

            //FROM, TO, SUBJECT, BODY
            // MAKE SURE YOU ENABLE FORWARDING POP/IMAP ON YOUR GMAIL ACCOUNT [Settings, Forwarding POP/IMAP, Enable IMAP, Save Changes]
            // Allow less secure apps: ON [https://myaccount.google.com/lesssecureapps] 

            MailMessage mail = new MailMessage("stuuwylibrary@gmail.com", textBox1.Text, "Потсетник за враќање на филмот", textBox2.Text);
            mail.Priority = MailPriority.High;
            smtp.Send(mail);
            MessageBox.Show("Mail successfully sent.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            textBox3.Text = "";
        }
    }
}
