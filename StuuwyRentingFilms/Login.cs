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

namespace StuuwyRentingFilms
{
    public partial class loginForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-27VNER1\TEW_SQLEXPRESS;Initial Catalog=movie_ManagmentSystem;Integrated Security=True"); // konekciski string do data bazata
        int countAdministrator = 0;
        int countUser = 0;
        public loginForm()
        {
            InitializeComponent();
            // Form control buttons
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }
        private void Form1_Load(object sender, EventArgs e) // pri vcituvanje na formata loginForm
        {
            if (con.State == ConnectionState.Open) // ako konekcijata e otvorena
            {
                con.Close(); // zatvorija
            }
            con.Open(); //..vo sprotivno otvorija
        }

        private void button1_Click(object sender, EventArgs e)
        {
            countAdministrator = CheckAdministrator();
            countUser = CheckUser();
            // IF CASSES FOR LOGIN
            if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0) // ako texBox1 i textBox2 se prazni
            {
                label3.Text = "All field's are required.";
                MessageBox.Show("Enter username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // ispisi poraka
            }
            else if (countAdministrator == 0 && countUser == 0) // ako metodot ExecuteNonQuery() vrati rezultat 0 [nema kolona so takva kombinacija na "username" i "password"]
            {
                label3.Text = "Credentials don't match.";
                MessageBox.Show("Credentials don't match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // ispisi poraka
            }
            else if (countAdministrator >= 1) // ako ima >=1 t.e ako postoi taa kombinacija na "username" i "password"
            {
                this.Hide();
                MDI_Administrator ma = new MDI_Administrator();
                ma.Show();
            }
            else if (countUser >= 1)
            {
                this.Hide();
                MDI_User mu = new MDI_User();
                mu.Show();
            }
            else // nepredviden slucaj 
            {
                label3.Text = "Try again.";
                MessageBox.Show("Try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); // ispisi poraka
            }
        }
        private int CheckAdministrator()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            int i = 0;
            SqlCommand cmdLibrarian = con.CreateCommand();
            cmdLibrarian.CommandType = CommandType.Text;
            cmdLibrarian.CommandText = "SELECT * FROM movieAdministrator WHERE email COLLATE Latin1_general_CS_AS ='" + textBox1.Text + "' AND password COLLATE Latin1_general_CS_AS ='" + textBox2.Text + "'";
            cmdLibrarian.ExecuteNonQuery(); // metod koj se koristi za manipuliranje podatoci vo databaza i se koristi vo naredbi bez rezultat kako CREATE,INSERT,UPDATE,DELETE,SELECT ...
            DataTable dtLibrarian = new DataTable();
            SqlDataAdapter daLibrarian = new SqlDataAdapter(cmdLibrarian);
            daLibrarian.Fill(dtLibrarian);
            i = Convert.ToInt32(dtLibrarian.Rows.Count.ToString());
            return i;
        }
        private int CheckUser()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            int x = 0;
            SqlCommand cmdStudent = con.CreateCommand();
            cmdStudent.CommandType = CommandType.Text;
            cmdStudent.CommandText = "SELECT * FROM movieUser WHERE email COLLATE Latin1_general_CS_AS ='" + textBox1.Text + "' AND password COLLATE Latin1_general_CS_AS ='" + textBox2.Text + "'";
            cmdStudent.ExecuteNonQuery(); // metod koj se koristi za manipuliranje podatoci vo databaza i se koristi vo naredbi bez rezultat kako CREATE,INSERT,UPDATE,DELETE,SELECT ...
            DataTable dtStudent = new DataTable();
            SqlDataAdapter daStudent = new SqlDataAdapter(cmdStudent);
            daStudent.Fill(dtStudent);
            x = Convert.ToInt32(dtStudent.Rows.Count.ToString());
            return x;
        }
        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
                button1_Click(sender, e);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register rf = new Register();
            rf.Show();
        }
    }
}
