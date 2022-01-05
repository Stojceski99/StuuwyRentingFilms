using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace StuuwyRentingFilms
{
    public partial class Update_Movie : Form
    {
        readonly SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-27VNER1\TEW_SQLEXPRESS;Initial Catalog=movie_ManagmentSystem;Integrated Security=True"); // konekciski string do data bazata
        bool movieTitleValidation = false;
        bool movieGenreValidation = false;
        bool movieProducerValidation = false;
        bool movieAvailableQuantity = false;
        public Update_Movie()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i;
            i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            try
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
                con.Open();
                String query = "UPDATE  Movie SET movieTitle='" + textBoxTitle.Text + "',movieGenre='" + textBoxGenre.Text + "',movieProducer='" + textBoxProducer.Text + "',movieReleaseDate='" + dateTimePicker1.Value.ToString() + "',movieavailableQuantity='" + textBoxAvailableQuantity.Text + "' WHERE ID =" + i + "";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                Display_Grid();
                label12.Text = "";
                MessageBox.Show("Record updated successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                panel2.Visible = false;
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Update_Movie_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            Display_Grid();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            panel2.Visible = true;
            // Za sekoja kolona selektirana od datagridView da se pretstavaat soodvetnite vrednosti vo textBox-ovite.
            int i;
            i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            try
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
                con.Open();
                String query = "SELECT * FROM Movie WHERE ID =" + i + "";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                foreach (DataRow dr in dt.Rows) // Za sekoj red vo dt[DataTable] da se prikazat vrednostite:
                {
                    textBoxTitle.Text = dr["movieTitle"].ToString();
                    textBoxGenre.Text = dr["movieGenre"].ToString();
                    textBoxProducer.Text = dr["movieProducer"].ToString();
                    dateTimePicker1.Text = (dr["movieReleaseDate"].ToString()); // dateTimePicker1.Text = Convert.ToDateTime((dr["movieReleaseDate"].ToString())); -> ERROR ????
                    textBoxAvailableQuantity.Text = dr["movieAvailableQuantity"].ToString();
                }
            }catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void textBoxTitle_Leave(object sender, EventArgs e)
        {
            movieAvailableQuantity = ValidateString(textBoxTitle, label1);
        }
        private void textBoxGenre_Leave(object sender, EventArgs e)
        {
            movieAvailableQuantity = ValidateString(textBoxGenre, label2);
        }
        private void textBoxProducer_Leave(object sender, EventArgs e)
        {
            movieAvailableQuantity = ValidateString(textBoxProducer, label4);
        }
        private void textBoxAvailableQuantity_Leave(object sender, EventArgs e)
        {
            movieAvailableQuantity = ValidateInteger(textBoxAvailableQuantity, label5);
        }
        private void textBoxAvailableQuantity_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                button1_Click(sender, e);
        }
        //METODI
        private void Display_Grid()
        {
            try
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
                con.Open();
                String query = "SELECT * FROM Movie";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt; // data grid se polni so informacii od Movie
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public bool ValidateInteger(TextBox textBox, Label label)
        {
            if (!Regex.Match(textBox.Text, "^[0-9]+$").Success)
            {
                label12.Text = "";
                label12.Text = label.Text + " is invalid.";
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
                label12.Text = "";
                label12.Text = label.Text + " is invalid.";
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
    }
}
