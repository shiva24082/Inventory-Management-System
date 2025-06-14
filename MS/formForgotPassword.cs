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

namespace MS
{
    public partial class formForgotPassword : Form
    {
        public formForgotPassword()
        {
            InitializeComponent();
        }
        private bool CheckIfEmailExists(string email)
        {
            using (SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Testing\MS\MS\MS\Database2.mdf;Integrated Security=True"))
            {
                
                string query = "SELECT COUNT(*) FROM Users WHERE Email = @Email";
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@Email", email);
                con.Open();
                int count = (int)command.ExecuteScalar();
                con.Close();
                return count > 0;

            }
        }
        private string GenerateOTP()
        {
            Random random = new Random();
            return random.Next(100000, 999999).ToString();
            //return random.Next(0, 9).ToString();
        }

        private void btnSendOTP_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            if (string.IsNullOrWhiteSpace(email) )
            {
                MessageBox.Show("Please Enter a Valid Email Address","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;

            }
            bool emailExists = CheckIfEmailExists(email);
            if (emailExists)
            {
                string otp = GenerateOTP();
                this.Hide();
                this.Close();
                //formChangePassword formChangePassword = new formChangePassword(email);
                //formChangePassword.ShowDialog();
                formResetPassword formResetPassword = new formResetPassword(email, otp);
                formResetPassword.ShowDialog();
            }
            else
            {
                MessageBox.Show("Provided Email Address Doesn't Exit in Database","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            if(CheckIfEmailExists(txtEmail.Text))
            {
                txtEmail.BorderColor = Color.Green;
                btnSendOTP.Focus();
            }
            else
            {
                txtEmail.BorderColor= Color.Red;
            }
        }
    }
}
