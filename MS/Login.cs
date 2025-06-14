using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace MS
{
    public partial class Login : Form
    {
        public static string role = "";
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Testing\MS\MS\MS\Database2.mdf;Integrated Security=True");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        private string Username()
        {
            string username = "";
            con.Open();
            string query = "SELECT * FROM Users WHERE UserName = '" + txtusername.Text + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                username = (dr["FirstName"] + " " + dr["LastName"]);
            }
            return username;
            dr.Close();
            con.Close();
        }
        public Login()
        {
            InitializeComponent();
        }

        private void btnShowPassword_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar.ToString() == "•")
            {
                txtPassword.PasswordChar = '\0';
                btnShowPassword.Image = Properties.Resources.show;
            }
            else
            {
                txtPassword.PasswordChar = '•';
                btnShowPassword.Image = Properties.Resources.hide1;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                //Test test = new Test();
               // dr = test.checkUser(txtusername.Text, txtPassword.Text);
                con.Open();
                cm = new SqlCommand("SELECT * FROM Users WHERE UserName = @Username AND Password = @Password", con);
                cm.Parameters.AddWithValue("@Username", txtusername.Text);
                cm.Parameters.AddWithValue("@Password", txtPassword.Text);
                cm.ExecuteNonQuery();
                dr = cm.ExecuteReader();
                if (dr.Read())
                {
                   role = dr["Role"]+"";
                }
                else
                {
                    MessageBox.Show("Invalid Username or Password..!", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (role=="")
                {
                    MessageBox.Show("Please Select a Valid Role..!", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                dr.Close();
                con.Close();

                if (role == "Admin")
                {
                    formDashboard db = new formDashboard(Username(), role);
                    this.Hide();
                    db.ShowDialog();

                }
                else if(role == "Cashier")
                { 
                    formDashboard db = new formDashboard(Username(), role);
                    this.Hide();
                    db.ShowDialog();

                }
                else if (role == "Salesman")
                {
                    formDashboard db = new formDashboard(Username(), role);
                    this.Hide();
                    db.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void lblForgetPassword_Click(object sender, EventArgs e)
        {
            this.Hide();
            formForgotPassword formForgotPassword = new formForgotPassword();
            formForgotPassword.ShowDialog();
        }
    }
}
