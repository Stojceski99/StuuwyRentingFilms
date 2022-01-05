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
    public partial class Return_Movie : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-27VNER1\TEW_SQLEXPRESS;Initial Catalog=movie_ManagmentSystem;Integrated Security=True"); // konekciski string do data bazata
        private bool emailValidation = false;
        public Return_Movie()
        {
            InitializeComponent();
        }
        //EVENTS
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            panel4.Visible = true;
            int i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            String query = "SELECT * FROM MovieIssue WHERE ID =" + i + "";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                lblTitleInv.Text = dr["movieTitle"].ToString();
                lblIssueInv.Text = dr["movieIssueDate"].ToString();
            }
        }
        private void Return_Movie_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            textBox1.Focus();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (emailValidation)
            {
                FillGrid(textBox1.Text);
                panel2.Visible = true;
            }
            else
            {
                MessageBox.Show("Invalid email.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dataGridView1.Columns.Clear();
                dataGridView1.Refresh();
            }
        }
        private void textBox1_Leave(object sender, EventArgs e)
        {
            string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$"; // tocna sema na Email
            if (Regex.IsMatch(textBox1.Text, pattern))
                emailValidation = true;
            else
            {
                MessageBox.Show("Enter valid email.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // ispisi poraka
                textBox1.Text = "";
                textBox1.Focus();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            int i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            String query = "UPDATE MovieIssue SET movieReturnDate='" + dateTimePicker1.Value.ToString() + "' WHERE ID=" + i + "";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            String queryUpdate = "UPDATE Movie SET movieAvailableQuantity=movieAvailableQuantity+1 WHERE movieTitle='" + lblTitleInv.Text + "'";
            SqlCommand cmdUpdate = new SqlCommand(queryUpdate, con);
            cmdUpdate.ExecuteNonQuery();
            MessageBox.Show("Movie returned successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            panel3.Visible = true;
            FillGrid(textBox1.Text);
        }
        //METODI
        private void FillGrid(string email)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Refresh();

            String query = "SELECT * FROM MovieIssue WHERE email='" + email.ToString() + "' AND movieReturnDate=''";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
