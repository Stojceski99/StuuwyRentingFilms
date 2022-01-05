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
    public partial class View_Movies : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-27VNER1\TEW_SQLEXPRESS;Initial Catalog=movie_ManagmentSystem;Integrated Security=True"); // konekciski string do data bazata
        public View_Movies()
        {
            InitializeComponent();
        }
        //METODI
        private void Display_Grid()
        {
            try
            {
                if (con.State == ConnectionState.Open) // ako konekcijata e otvorena
                {
                    con.Close(); // zatvorija
                }
                con.Open(); //..vo sprotivno otvorija
                String query = "SELECT * FROM Movie";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt; // data grid se polni so informacii od Book_Information
                con.Close();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //EVENTS
        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            try
            {
                if (con.State == ConnectionState.Open) // ako konekcijata e otvorena
                {
                    con.Close(); // zatvorija
                }
                con.Open(); //..vo sprotivno otvorija
                String query = "SELECT * FROM Movie WHERE movieGenre LIKE('%" + textBox1.Text + "%')";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                i = Convert.ToInt32(dt.Rows.Count.ToString());
                if (i == 0)
                {
                    MessageBox.Show("Genre not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                textBox1.Text = "";
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void View_Movies_Load(object sender, EventArgs e)
        {
            Display_Grid();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            int i = 0;
            try
            {
                if (con.State == ConnectionState.Open) // ako konekcijata e otvorena
                {
                    con.Close(); // zatvorija
                }
                con.Open(); //..vo sprotivno otvorija
                String query = "SELECT * FROM Movie WHERE movieTitle LIKE('%" + textBox2.Text + "%')";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                i = Convert.ToInt32(dt.Rows.Count.ToString());
                if (i == 0)
                    MessageBox.Show("Title not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Text = "";
                dataGridView1.DataSource = dt;
                con.Close();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                button1_Click(sender, e);
        }
        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                button2_Click(sender, e);
        }
    }
}
