using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MS
{
    public partial class formVendors : Form
    {
        public SqlDataAdapter dataAdapter;
        public DataTable dataTable;
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Testing\MS\MS\MS\Database2.mdf;Integrated Security=True");
        public formVendors()
        {
            InitializeComponent();
        }
        private void RefreshData()
        {
            dataAdapter = new SqlDataAdapter("SELECT * FROM Vendors", con);
            dataTable = new DataTable();
            try
            {
                dataTable.Clear();
                dataAdapter.Fill(dataTable);

                foreach (DataRow row in dataTable.Rows)
                {
                    row["VendorId"] = row["VendorId"].ToString();
                    row["VendorName"] = row["VendorName"].ToString();
                    row["ThirdCategoryName"] = row["ThirdCategoryName"].ToString();
                    row["RegisterDate"] = row["RegisterDate"].ToString();
                    row["VendorStatus"] = row["VendorStatus"].ToString();
                    row["VendorDescription"] = row["VendorDescription"].ToString();
                    
                }
                VendorsDataGridView.DataSource = dataTable;
                VendorsDataGridView.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured While Refreshing Data" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshData();
        }
        private void PopulateComboBox()
        {
            try
            {
                con.Open();
                string query = "SELECT ThirdCategoryName FROM ThirdCategories";
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        cmbThirdCateName.Items.Clear();
                        while (reader.Read())
                        {
                            string SecondCateName = reader.GetString(0);
                            cmbThirdCateName.Items.Add(SecondCateName);
                        }
                        con.Close();
                        reader.Close();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (VendorsDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to delete.");
                return;
            }
            DataGridViewRow selectedRow = VendorsDataGridView.SelectedRows[0];

            string VendorId = selectedRow.Cells[0].Value.ToString();
            string VendorName = selectedRow.Cells[1].Value.ToString();

            try
            {
                using (SqlCommand command = new SqlCommand("DELETE FROM Vendors WHERE VendorId = @VendorId", con))
                {
                    command.Parameters.AddWithValue("@VendorId", VendorId);
                    con.Open();
                    command.ExecuteNonQuery();
                    VendorsDataGridView.Rows.Remove(selectedRow);
                    MessageBox.Show(VendorName + " - Sucessfully Deleted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtVendorId.Text))
            {
                if (string.IsNullOrWhiteSpace(txtVendorName.Text) || string.IsNullOrWhiteSpace(cmbThirdCateName.Text) || string.IsNullOrWhiteSpace(dtpRegisterDate.Text) || string.IsNullOrWhiteSpace(cmbStatus.Text) || string.IsNullOrWhiteSpace(txtVendorDesciption.Text))
                {
                    MessageBox.Show("Please Fill Correct Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    string ThirdCateId = "";
                    try
                    {
                        con.Open();
                        string query = "SELECT * FROM ThirdCategories WHERE ThirdCategoryName = '" + cmbThirdCateName.Text + "'";
                        SqlCommand cmd = new SqlCommand(query, con);
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            ThirdCateId = Convert.ToString(reader["ThirdCategoryName"]);
                        }
                        con.Close();
                        reader.Close();
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }
                    try
                    {
                        using (SqlCommand command = new SqlCommand("UPDATE Vendors SET VendorName = @VendorName, ThirdCategoryName = @ThirdCategoryName, RegisterDate = @RegisterDate, VendorStatus = @VendorStatus, VendorDescription = @VendorDescription WHERE VendorId = @VendorId;", con))
                        {
                            command.Parameters.AddWithValue("@VendorId", txtVendorId.Text);
                            command.Parameters.AddWithValue("@VendorName", txtVendorName.Text);
                            command.Parameters.AddWithValue("@ThirdCategoryName", ThirdCateId);
                            command.Parameters.AddWithValue("@RegisterDate", dtpRegisterDate.Text);
                            command.Parameters.AddWithValue("@VendorStatus", cmbStatus.Text);
                            command.Parameters.AddWithValue("@VendorDescription", txtVendorDesciption.Text);
                            con.Open();
                            command.ExecuteNonQuery();
                            MessageBox.Show("Data Updated Sucessfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            }
            else
            {
                if (string.IsNullOrWhiteSpace(txtVendorName.Text) || string.IsNullOrWhiteSpace(cmbThirdCateName.Text) || string.IsNullOrWhiteSpace(dtpRegisterDate.Text) || string.IsNullOrWhiteSpace(cmbStatus.Text) || string.IsNullOrWhiteSpace(txtVendorDesciption.Text))
                {
                    MessageBox.Show("Please Fill Correct Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    string ThirdCateId = "";
                    try
                    {
                        con.Open();
                        string query = "SELECT * FROM ThirdCategories WHERE ThirdCategoryName = '" + cmbThirdCateName.Text + "'";
                        SqlCommand cmd = new SqlCommand(query, con);
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            ThirdCateId = Convert.ToString(reader["ThirdCategoryName"]);
                        }
                        con.Close();
                        reader.Close();
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message);
                    }
                    try
                    {
                        using (SqlCommand command = new SqlCommand("INSERT INTO Vendors( VendorName, ThirdCategoryName, RegisterDate, VendorStatus, VendorDescription) VALUES (@VendorName, @ThirdCategoryName, @RegisterDate, @VendorStatus, @VendorDescription);", con))
                        {
                          
                            //command.Parameters.AddWithValue("@VendorId", txtVendorId.Text);
                            command.Parameters.AddWithValue("@VendorName", txtVendorName.Text);
                            command.Parameters.AddWithValue("@ThirdCategoryName", ThirdCateId);
                            command.Parameters.AddWithValue("@RegisterDate", dtpRegisterDate.Text);
                            command.Parameters.AddWithValue("@VendorStatus", cmbStatus.Text);
                            command.Parameters.AddWithValue("@VendorDescription", txtVendorDesciption.Text);

                            con.Open();
                            command.ExecuteNonQuery();
                            MessageBox.Show("Data Saved Sucessfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string Keyword = txtSearch.Text.Trim();
            try
            {
                string query = "SELECT * FROM Vendors WHERE VendorName LIKE @Keyword OR ThirdCategoryName LIKE @Keyword OR VendorStatus LIKE @Keyword";
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@Keyword", "%" + Keyword + "%");
                    DataTable dataTable = new DataTable();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        con.Open();
                        adapter.Fill(dataTable);
                        foreach (DataRow row in dataTable.Rows)
                        {
                            row["VendorId"] = row["VendorId"].ToString();
                            row["VendorName"] = row["VendorName"].ToString();
                            row["ThirdCategoryName"] = row["ThirdCategoryName"].ToString();
                            row["RegisterDate"] = row["RegisterDate"].ToString();
                            row["VendorStatus"] = row["VendorStatus"].ToString();
                            row["VendorDescription"] = row["VendorDescription"].ToString();

                        }
                    }
                    VendorsDataGridView.DataSource = dataTable;
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

        private void btnAddThirdCate_Click(object sender, EventArgs e)
        {
            formThirdCategory formThirdCategory = new formThirdCategory();
            formThirdCategory.ShowDialog();
        }

        private void VendorsDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (VendorsDataGridView.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = VendorsDataGridView.Rows[e.RowIndex];
                    txtVendorId.Text = Convert.ToString(selectedRow.Cells[0].Value);
                    txtVendorName.Text = selectedRow.Cells[1].Value.ToString();
                    cmbThirdCateName.Text = selectedRow.Cells[2].Value.ToString();
                    DateTime registerDate = Convert.ToDateTime(selectedRow.Cells[3].Value);
                    dtpRegisterDate.Value = registerDate;
                    cmbStatus.Text = Convert.ToString(selectedRow.Cells[4].Value);
                    txtVendorDesciption.Text = Convert.ToString(selectedRow.Cells[5].Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void formVendors_Load(object sender, EventArgs e)
        {
            PopulateComboBox();
        }
    }
}
