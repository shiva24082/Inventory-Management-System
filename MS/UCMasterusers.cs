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

namespace MS
{
    public partial class UCMasterusers : Form
    {
        public SqlDataAdapter dataAdapter;
        public DataTable dataTable;
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Testing\MS\MS\MS\Database2.mdf;Integrated Security=True");
        public UCMasterusers()
        {
            InitializeComponent();
        }

        private void btnCancelUser_Click(object sender, EventArgs e)
        {
            txtUserId.Text = "";
            txtUsername.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtPassword.Text = "";
            txtEmail.Text = "";
            dtpBirthDate.Value = DateTime.Now;
            txtAge.Text = "";
            cmbGender.SelectedIndex = -1;
            cmbRole.SelectedIndex = -1;
            txtSalary.Text = "";
            dtpJoinDate.Value = DateTime.Now;
            txtNID.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            txtCurrentCity.Text = "";
            cmbBloodGroup.SelectedIndex = -1;

        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (UsersDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to delete.");
                return;
            }
            DataGridViewRow selectedRow = UsersDataGridView.SelectedRows[0];

            int userId = Convert.ToInt32(selectedRow.Cells[0].Value);
            string Fname = selectedRow.Cells[2].Value.ToString();
            string Lname = selectedRow.Cells[3].Value.ToString();

            try
            {
                using (SqlCommand command = new SqlCommand("DELETE FROM Users WHERE UserId = @UserId", con))
                {
                    command.Parameters.AddWithValue("@UserId", userId);
                    con.Open();
                    command.ExecuteNonQuery();
                    UsersDataGridView.Rows.Remove(selectedRow);
                    MessageBox.Show(Fname + " " + Lname + " - Delete Succeeded", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }

        private void DisplayUserData()
        {
            dataAdapter = new SqlDataAdapter("SELECT * FROM Users", con);
            dataTable = new DataTable();
            try
            {
                dataTable.Clear();
                dataAdapter.Fill(dataTable);

                foreach(DataRow row in dataTable.Rows)
                {
                    row["UserId"] = row["UserId"].ToString();
                    row["UserName"] = row["UserName"].ToString();
                    row["FirstName"] = row["FirstName"].ToString();
                    row["LastName"] = row["LastName"].ToString();
                    row["Password"] = row["Password"].ToString();
                    row["Email"] = row["Email"].ToString();
                    row["Birthdate"] = row["Birthdate"].ToString();
                    row["Age"] = row["Age"].ToString();
                    row["Gender"] = row["Gender"].ToString();
                    row["Role"] = row["Role"].ToString();
                    row["Salary"] = row["Salary"].ToString();
                    row["JoinDate"] = row["JoinDate"].ToString();
                    row["NID"] = row["NID"].ToString();
                    row["Phone"] = row["Phone"].ToString();
                    row["Address"] = row["Address"].ToString();
                    row["CurrentCity"] = row["CurrentCity"].ToString();
                    row["BloodGroup"] = row["BloodGroup"].ToString();
                }
                UsersDataGridView.DataSource = dataTable;
                UsersDataGridView.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured While Refreshing Data" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }

        private void btnRefreshUser_Click(object sender, EventArgs e)
        {
            DisplayUserData();

        }

        private void btnSaveUser_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtUserId.Text))
            {
                if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtFirstName.Text) || string.IsNullOrWhiteSpace(txtLastName.Text) || string.IsNullOrWhiteSpace(txtPassword.Text) || string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(dtpBirthDate.Text) || string.IsNullOrWhiteSpace(txtAge.Text) || string.IsNullOrWhiteSpace(cmbGender.Text) || string.IsNullOrWhiteSpace(cmbRole.Text) || string.IsNullOrWhiteSpace(txtSalary.Text) || string.IsNullOrWhiteSpace(dtpJoinDate.Text) || string.IsNullOrWhiteSpace(txtNID.Text) || string.IsNullOrWhiteSpace(txtPhone.Text) || string.IsNullOrWhiteSpace(txtAddress.Text) || string.IsNullOrWhiteSpace(txtCurrentCity.Text) || string.IsNullOrWhiteSpace(cmbBloodGroup.Text))
                {
                    MessageBox.Show("Please Fill Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                try
                {
                    using (SqlCommand command = new SqlCommand("UPDATE Users SET UserName = @UserName, FirstName = @FirstName, LastName = @LastName, Password = @Password, Email = @Email, Birthdate = @Birthdate, Age = @Age, Gender = @Gender, Role = @Role, Salary = @Salary, JoinDate = @JoinDate, NID = @NID, Phone = @Phone, Address = @Address, CurrentCity = @CurrentCity, BloodGroup = @BloodGroup WHERE UserId = @UserId;", con))
                    {
                        command.Parameters.AddWithValue("@UserId", Convert.ToInt32(txtUserId.Text));
                        command.Parameters.AddWithValue("@UserName", txtUsername.Text);
                        command.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                        command.Parameters.AddWithValue("@LastName", txtLastName.Text);
                        command.Parameters.AddWithValue("@Password", txtPassword.Text);
                        command.Parameters.AddWithValue("@Email", txtEmail.Text);
                        command.Parameters.AddWithValue("@Birthdate", dtpBirthDate.Value.Date);
                        command.Parameters.AddWithValue("@Age", Convert.ToInt32(txtAge.Text));
                        command.Parameters.AddWithValue("@Gender", cmbGender.Text);
                        command.Parameters.AddWithValue("@Role", cmbRole.Text);
                        command.Parameters.AddWithValue("@Salary", Convert.ToInt64(txtSalary.Text));
                        command.Parameters.AddWithValue("@JoinDate", dtpJoinDate.Value.Date);
                        command.Parameters.AddWithValue("@NID", txtNID.Text);
                        command.Parameters.AddWithValue("@Phone", Convert.ToInt64(txtPhone.Text));
                        command.Parameters.AddWithValue("@Address", txtAddress.Text);
                        command.Parameters.AddWithValue("@CurrentCity", txtCurrentCity.Text);
                        command.Parameters.AddWithValue("@BloodGroup", cmbBloodGroup.Text);

                        con.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Data Updated Sucessfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    con.Close();
                }

            }
            else
            {
                 if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtFirstName.Text) || string.IsNullOrWhiteSpace(txtLastName.Text) || string.IsNullOrWhiteSpace(txtPassword.Text) || string.IsNullOrWhiteSpace(txtEmail.Text) || string.IsNullOrWhiteSpace(dtpBirthDate.Text) || string.IsNullOrWhiteSpace(txtAge.Text) || string.IsNullOrWhiteSpace(cmbGender.Text) || string.IsNullOrWhiteSpace(cmbRole.Text) || string.IsNullOrWhiteSpace(txtSalary.Text) || string.IsNullOrWhiteSpace(dtpJoinDate.Text) || string.IsNullOrWhiteSpace(txtNID.Text) || string.IsNullOrWhiteSpace(txtPhone.Text) || string.IsNullOrWhiteSpace(txtAddress.Text) || string.IsNullOrWhiteSpace(txtCurrentCity.Text) || string.IsNullOrWhiteSpace(cmbBloodGroup.Text))
                    {
                        MessageBox.Show("Please Fill Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                try
                {
                    using (SqlCommand command = new SqlCommand("INSERT INTO Users (UserName, FirstName, LastName, Password, Email, Birthdate, Age, Gender, Role, Salary, JoinDate, NID, Phone, Address, CurrentCity, BloodGroup )" + "VALUES (@UserName, @FirstName, @LastName, @Password, @Email, @Birthdate, @Age, @Gender, @Role, @Salary, @JoinDate, @NID, @Phone, @Address, @CurrentCity, @BloodGroup );", con))
                    {
                        //command.Parameters.AddWithValue("@UserId", Convert.ToInt32(txtUserId.Text));
                        command.Parameters.AddWithValue("@UserName", txtUsername.Text);
                        command.Parameters.AddWithValue("@FirstName", txtFirstName.Text);
                        command.Parameters.AddWithValue("@LastName", txtLastName.Text);
                        command.Parameters.AddWithValue("@Password", txtPassword.Text);
                        command.Parameters.AddWithValue("@Email", txtEmail.Text);
                        command.Parameters.AddWithValue("@Birthdate", dtpBirthDate.Value.Date);
                        command.Parameters.AddWithValue("@Age", Convert.ToInt32(txtAge.Text));
                        command.Parameters.AddWithValue("@Gender", cmbGender.Text);
                        command.Parameters.AddWithValue("@Role", cmbRole.Text);
                        command.Parameters.AddWithValue("@Salary", Convert.ToInt64(txtSalary.Text));
                        command.Parameters.AddWithValue("@JoinDate", dtpJoinDate.Value.Date);
                        command.Parameters.AddWithValue("@NID", txtNID.Text);
                        command.Parameters.AddWithValue("@Phone", Convert.ToInt64(txtPhone.Text));
                        command.Parameters.AddWithValue("@Address", txtAddress.Text);
                        command.Parameters.AddWithValue("@CurrentCity", txtCurrentCity.Text);
                        command.Parameters.AddWithValue("@BloodGroup", cmbBloodGroup.Text);

                        con.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Data Saved Sucessfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error occurred: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }

             
        }

        private void UsersDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if(e.RowIndex >= 0)
                {
                    DataGridViewRow selectedRow = UsersDataGridView.Rows[e.RowIndex];

                    int userId = Convert.ToInt32(selectedRow.Cells[0].Value);
                    string userName = selectedRow.Cells[1].Value.ToString();
                    string firstName = selectedRow.Cells[2].Value.ToString();
                    string lastName = selectedRow.Cells[3].Value.ToString();
                    string password = selectedRow.Cells[4].Value.ToString();
                    string email = selectedRow.Cells[5].Value.ToString();
                    DateTime birthdate = Convert.ToDateTime(selectedRow.Cells[6].Value);
                    int age = Convert.ToInt32(selectedRow.Cells[7].Value);
                    string gender = selectedRow.Cells[8].Value.ToString();
                    string role = selectedRow.Cells[9].Value.ToString();
                    long salary = Convert.ToInt64(selectedRow.Cells[10].Value);
                    DateTime joindate = Convert.ToDateTime(selectedRow.Cells[11].Value);
                    string nid = selectedRow.Cells[12].Value.ToString();
                    long phone = Convert.ToInt64(selectedRow.Cells[13].Value);
                    string address = selectedRow.Cells[14].Value.ToString();
                    string currentCity = selectedRow.Cells[15].Value.ToString();
                    string bloodGroup = selectedRow.Cells[16].Value.ToString();

                    txtUserId.Text = userId.ToString();
                    txtUsername.Text = userName;
                    txtFirstName.Text = firstName;
                    txtLastName.Text = lastName;
                    txtPassword.Text = password;
                    txtEmail.Text = email;
                    dtpBirthDate.Value = birthdate;
                    txtAge.Text = age.ToString();
                    cmbGender.SelectedItem = gender;
                    cmbRole.SelectedItem = role;
                    txtSalary.Text = salary.ToString();
                    dtpJoinDate.Value = joindate;
                    txtNID.Text = nid;
                    txtPhone.Text = phone.ToString();
                    txtAddress.Text = address;
                    txtCurrentCity.Text = currentCity;
                    cmbBloodGroup.SelectedItem = bloodGroup;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string Keyword = txtSearch.Text.Trim();
            try
            {
                string query = "SELECT * FROM Users WHERE FirstName LIKE @Keyword OR LastName LIKE @Keyword OR CurrentCity LIKE @Keyword OR Gender LIKE @Keyword OR Role LIKE @Keyword OR BloodGroup LIKE @Keyword";
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@Keyword", "%" + Keyword + "%");
                    DataTable dataTable = new DataTable();
                    using(SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        con.Open();
                        adapter.Fill(dataTable);
                        foreach (DataRow row in dataTable.Rows)
                        {
                            row["UserId"] = row["UserId"].ToString();
                            row["UserName"] = row["UserName"].ToString();
                            row["FirstName"] = row["FirstName"].ToString();
                            row["LastName"] = row["LastName"].ToString();
                            row["Password"] = row["Password"].ToString();
                            row["Email"] = row["Email"].ToString();
                            row["Birthdate"] = row["Birthdate"].ToString();
                            row["Age"] = row["Age"].ToString();
                            row["Gender"] = row["Gender"].ToString();
                            row["Role"] = row["Role"].ToString();
                            row["Salary"] = row["Salary"].ToString();
                            row["JoinDate"] = row["JoinDate"].ToString();
                            row["NID"] = row["NID"].ToString();
                            row["Phone"] = row["Phone"].ToString();
                            row["Address"] = row["Address"].ToString();
                            row["CurrentCity"] = row["CurrentCity"].ToString();
                            row["BloodGroup"] = row["BloodGroup"].ToString();
                        }
                    }
                    UsersDataGridView.DataSource = dataTable;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
