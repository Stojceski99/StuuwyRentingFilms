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
    public partial class View_User_Info : Form
    {
        bool firstNameValidation = true;
        bool lastNameValidation = true;
        bool emailValidation = true;
        readonly SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-27VNER1\TEW_SQLEXPRESS;Initial Catalog=movie_ManagmentSystem;Integrated Security=True"); // konekciski string do data bazata
        public View_User_Info()
        {
            InitializeComponent();
        }

        //METODI
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
            {
                return true;
            }
        }
        public bool ValidateString(TextBox textBox, Label label)
        {
            if (!Regex.Match(textBox.Text, "^[A-Z\\s][a-zA-Z\\s]+$").Success)
            {
                label1.Text = label.Text + " is invalid.";
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
        public void FillGrid()
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            dataGridView1.Columns.Clear();
            dataGridView1.Refresh();

            String query = "SELECT * FROM movieUser";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void ClearBox()
        {
            textBoxFirstname.Text = "";
            textBoxLastname.Text = "";
            textBoxEmail.Text = "";
            textBoxPassword.Text = "";
        }
        private void View_User_Info_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            FillGrid();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (radioButton1.Checked)
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                    con.Open();
                    dataGridView1.Columns.Clear();
                    dataGridView1.Refresh();
                    String query = "SELECT * FROM movieUser WHERE firstName like('%" + textBox1.Text + "%') ";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                if (radioButton2.Checked)
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                    con.Open();
                    dataGridView1.Columns.Clear();
                    dataGridView1.Refresh();
                    String query = "SELECT * FROM movieUser WHERE lastName like('%" + textBox1.Text + "%') ";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
                if (radioButton3.Checked)
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                    con.Open();
                    dataGridView1.Columns.Clear();
                    dataGridView1.Refresh();
                    String query = "SELECT * FROM movieUser WHERE email like('%" + textBox1.Text + "%') ";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = "Enter user first name";
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = "Enter user last name";
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = "Enter user email";
        }
        private void textBoxFirstName_Leave(object sender, EventArgs e)
        {
            lastNameValidation = ValidateString(textBoxFirstname, labelFirstname);
        }
        private void textBoxLastName_Leave(object sender, EventArgs e)
        {
            lastNameValidation = ValidateString(textBoxLastname, labelLastName);
        }
        private void textBoxEmail_Leave(object sender, EventArgs e)
        {
            emailValidation = ValidateEmail(textBoxEmail, labelEmail);
        }

        private void button1_Click(object sender, EventArgs e) // FOR OPTIMATIZATION, YOU CAN CHECK IN WHICH TEXTBOX TEXT HAS BEEN CHANGED(TEXT CHANGED EVENT), THEN YOU CAN UPDATE TEXT TO ONLY THOSE TEXTBOX'S, NOT ALL OF THEM!
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            SqlDataAdapter da = new SqlDataAdapter("SELECT email FROM movieUser WHERE email='" + textBoxEmail.Text + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count >= 1)  // POSSIBLE BUG  !!!!!!!
            {
                label1.Text = "User Email are already taken.";
                MessageBox.Show("User Email are already taken.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (textBoxFirstname.Text.Length == 0 || textBoxLastname.Text.Length == 0 || textBoxEmail.Text.Length == 0 | textBoxPassword.Text.Length == 0) // ako se prazni textBox-ovite
            {
                label1.Text = "All field's are required.";
                MessageBox.Show("Please fill all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (firstNameValidation && lastNameValidation && emailValidation) //
            {
                try
                {
                    int i;
                    i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
                    con.Open();
                    String query = "UPDATE movieUser SET firstName ='" + textBoxFirstname.Text + "',lastName ='" + textBoxLastname.Text + "',email ='" + textBoxEmail.Text + "',password='" + textBoxPassword.Text + "' WHERE ID =" + i + "";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    FillGrid();
                    MessageBox.Show("User information updated successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearBox();
                    con.Close();
                }
                catch (Exception exp)
                {
                    MessageBox.Show("Error." + exp.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                label1.Text = "Something went wrong.";
                MessageBox.Show("Something went wrong.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) // BUG: pri prvoto selektiranje vo text polinjata ne se refreshira novi vrednosti ako se klikni na nova cell
        {
            if (con.State == ConnectionState.Open)
                con.Close();
            con.Open();
            ClearBox();
            panel2.Visible = true;
            int i;
            i = Convert.ToInt32(dataGridView1.SelectedCells[0].Value.ToString());
            String query = "SELECT * FROM movieUser";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                textBoxFirstname.Text = dr["firstName"].ToString();
                textBoxLastname.Text = dr["lastName"].ToString();
                textBoxEmail.Text = dr["email"].ToString();
                textBoxPassword.Text = dr["password"].ToString();
            }
        }
    }
}
