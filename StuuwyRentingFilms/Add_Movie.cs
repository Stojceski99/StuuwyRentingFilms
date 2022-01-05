using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;

namespace StuuwyRentingFilms
{
    public partial class Add_Movie : Form
    {
        readonly SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-27VNER1\TEW_SQLEXPRESS;Initial Catalog=movie_ManagmentSystem;Integrated Security=True"); // konekciski string do data bazata
        bool movieTitleValidation = false;
        bool movieGenreValidation = false;
        bool movieProducerValidation = false;
        bool movieAvailableQuantity = false;
        public Add_Movie()
        {
            InitializeComponent();
        }
        //METHODS
        private void ClearTextBox() // metod za brisenje na podatocite vo textBox-ovite
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }
        public bool ValidateInteger(TextBox textBox, Label label)
        {
            if (!Regex.Match(textBox.Text, "^[0-9]+$").Success)
            {
                label7.Text = "";
                label7.Text = label.Text + " is invalid.";
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
        public bool ValidateEmail(TextBox textBox, Label label, bool validate)
        {
            if (!Regex.Match(textBox.Text, "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$").Success)
            {
                label7.Text = "";
                label7.Text = label.Text + " is invalid.";
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
        public bool ValidateString(TextBox textBox, Label label)
        {
            if (!Regex.Match(textBox.Text, "^[A-Z0-9]*[0-9a-zA-Z\\s]").Success)
            {
                label7.Text = "";
                label7.Text = label.Text + " is invalid.";
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
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                //Proverka na movieTitle AND movieAuthor pri vnes - ako se zafateni obidise so drugo movieTitle ili drug movieProducer
                SqlDataAdapter da = new SqlDataAdapter("SELECT movieTitle,movieProducer FROM Movie WHERE movieTitle='" + textBox1.Text + "' AND movieProducer='" + textBox3.Text + "'", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1) // Ako postoi barem 1 kolona 
                {
                    label7.Text = "That movie is already in database.";
                    MessageBox.Show("That movie is already in database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0 || textBox3.Text.Length == 0 || dateTimePicker1.Text.Length == 0 || textBox4.Text.Length == 0) // ako se prazni textBox-ovite
                {
                    label7.Text = "All field's are required.";
                    MessageBox.Show("Please fill all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (dt.Rows.Count == 0 && movieTitleValidation && movieGenreValidation && movieProducerValidation && movieAvailableQuantity)
                {
                    String query = "INSERT INTO Movie VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + dateTimePicker1.Value.ToString() + "','" + textBox3.Text + "'," + textBox4.Text + ")";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Movie was added successufully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();
                    ClearTextBox();
                }
                else
                {
                    label7.Text = "Something went wrong.";
                    MessageBox.Show("Something went wrong.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ClearTextBox();
                }
            }catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearTextBox();
            }
        }
        private void textBox1_Leave(object sender, EventArgs e)
        {
            movieTitleValidation= ValidateString(textBox1, label1);
        }
        private void textBox2_Leave(object sender, EventArgs e)
        {
            movieGenreValidation = ValidateString(textBox2, label2);
        }
        private void textBox3_Leave(object sender, EventArgs e)
        {
            movieProducerValidation = ValidateString(textBox3, label4);
        }
        private void textBox4_Leave(object sender, EventArgs e)
        {
            movieAvailableQuantity = ValidateInteger(textBox4, label5);
        }
        private void textBox4_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                button1_Click(sender, e);
        }
    }
}
