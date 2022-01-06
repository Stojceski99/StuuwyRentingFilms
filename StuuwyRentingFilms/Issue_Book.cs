using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace StuuwyRentingFilms
{
    public partial class Issue_Book : Form
    {
        bool emailValidation = false;
        readonly SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-27VNER1\TEW_SQLEXPRESS;Initial Catalog=movie_ManagmentSystem;Integrated Security=True"); // konekciski string do data bazata
        public Issue_Book()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            String query = "SELECT * FROM movieUser WHERE email ='" + textBox1.Text + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            i = Convert.ToInt32(dt.Rows.Count.ToString());

            if (i == 0)
            {
                label9.Text = "Record not found";
                MessageBox.Show("Record not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ClearBox();
            }
            else
            {
                foreach (DataRow dr in dt.Rows)
                {
                    textBoxFirst.Text = dr["firstName"].ToString();
                    textBoxLast.Text = dr["lastName"].ToString();
                }
            }
        }
        private void textBoxMovieTitle_KeyDown(object sender, KeyEventArgs e)
        {
            listBox1.Focus();
            //listBox1.SelectedIndex = 0;
        }
        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            textBoxMovieTitle.Text = listBox1.SelectedItem.ToString();
            listBox1.Visible = false;
        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textBoxMovieTitle.Text = listBox1.SelectedItem.ToString();
            listBox1.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int checkBookQuantity = 0;
            checkBookQuantity = 0;
            String queryCheck = "SELECT * FROM Movie WHERE movieTitle='" + textBoxMovieTitle.Text + "'";
            SqlCommand cmdCheck = new SqlCommand(queryCheck, con);
            cmdCheck.ExecuteNonQuery();
            DataTable dtCheck = new DataTable();
            SqlDataAdapter daCheck = new SqlDataAdapter(cmdCheck);
            daCheck.Fill(dtCheck);

            foreach (DataRow drCheck in dtCheck.Rows)
            {
                checkBookQuantity = Convert.ToInt32(drCheck["movieAvailableQuantity"].ToString());
            }

            if (checkBookQuantity > 0)
            {
                // Query for inserting information about issued movie in database
                String query = "INSERT INTO MovieIssue VALUES(" + textBoxMovieTitle.Text + ",'" + textBox1.Text + "','" + dateTimePicker1.Value.ToShortDateString() + "','')";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();

                // Query for updating availableQuantity
                String queryUpdate = "UPDATE Movie SET movieAvailableQuantity = movieAvailableQuantity-1 WHERE movieTitle ='" + textBoxMovieTitle.Text + "' ";
                SqlCommand cmdUpdate = new SqlCommand(queryUpdate, con);
                cmdUpdate.ExecuteNonQuery();

                ClearBox();
                MessageBox.Show("Movie issued successfully.", "Inforamation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                textBoxMovieTitle.Focus();
                MessageBox.Show("Movie not available.", "Inforamation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void Issue_Book_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
        }
        private void textBox1_Leave(object sender, EventArgs e)
        {
            emailValidation = ValidateEmail(textBox1, label1);
        }
        //METODI
        private void ClearBox()
        {
            textBox1.Text = "";
            textBoxFirst.Text = "";
            textBoxLast.Text = "";
            textBoxMovieTitle.Text = "";
        }
        private int CheckAvailability(int checkMovieQuantity)
        {
            checkMovieQuantity = 0;
            String queryCheck = "SELECT * FROM Movie WHERE movieTitle='" + textBoxMovieTitle.Text + "'";
            SqlCommand cmdCheck = new SqlCommand(queryCheck, con);
            cmdCheck.ExecuteNonQuery();
            DataTable dtCheck = new DataTable();
            SqlDataAdapter daCheck = new SqlDataAdapter(cmdCheck);
            daCheck.Fill(dtCheck);
            foreach (DataRow drCheck in dtCheck.Rows)
            {
                checkMovieQuantity = Convert.ToInt32(drCheck["movieAvailableQuantity"].ToString());
            }
            return checkMovieQuantity;
        }
        public bool ValidateEmail(TextBox textBox, Label label)
        {
            if (!Regex.Match(textBox.Text, "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$").Success)
            {
                label1.Text = label.Text + " is invalid.";
                MessageBox.Show("Invalid " + label.Text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox.Focus();
                textBox.Text = "";
                return false;
            }
            else
                return true;
        }
    }
}
