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
    public partial class formBrand : Form
    {
        public SqlDataAdapter dataAdapter;
        public DataTable dataTable;
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Testing\MS\MS\MS\Database2.mdf;Integrated Security=True");
        public formBrand()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }
        private void PopulateComboBox()
        {
            try
            {
                con.Open();
                string query = "SELECT VendorName FROM Vendors";
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        cmbVendorName.Items.Clear();
                        while (reader.Read())
                        {
                            string SecondCateName = reader.GetString(0);
                            cmbVendorName.Items.Add(SecondCateName);
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

        private void btnAddVendor_Click(object sender, EventArgs e)
        {
            formVendors formVendors = new formVendors();
            formVendors.ShowDialog();
        }

        private void BrandsDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (BrandsDataGridView.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = BrandsDataGridView.Rows[e.RowIndex];
                    txtBrandId.Text = Convert.ToString(selectedRow.Cells[0].Value);
                    txtBrandName.Text = selectedRow.Cells[1].Value.ToString();
                    cmbVendorName.Text = selectedRow.Cells[2].Value.ToString();
                    cmbStatus.Text = Convert.ToString(selectedRow.Cells[3].Value);
                    txtBrandDescription.Text = Convert.ToString(selectedRow.Cells[4].Value);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtBrandId.Text))
            {
                if (string.IsNullOrWhiteSpace(txtBrandName.Text) || string.IsNullOrWhiteSpace(cmbVendorName.Text) || string.IsNullOrWhiteSpace(cmbStatus.Text) || string.IsNullOrWhiteSpace(txtBrandDescription.Text))
                {
                    MessageBox.Show("Please Fill Correct Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    string VendorId = "";
                    try
                    {
                        con.Open();
                        string query = "SELECT * FROM Vendors WHERE VendorName = '" + cmbVendorName.Text + "'";
                        SqlCommand cmd = new SqlCommand(query, con);
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            VendorId = Convert.ToString(reader["VendorName"]);
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
                        using (SqlCommand command = new SqlCommand("UPDATE Brands SET BrandName = @BrandName, VendorName = @VendorName, BrandStatus = @BrandStatus, BrandDescription = @BrandDescription WHERE BrandId = @BrandId;", con))
                        {
                            command.Parameters.AddWithValue("@BrandId", txtBrandId.Text);
                            command.Parameters.AddWithValue("@BrandName", txtBrandName.Text);
                            command.Parameters.AddWithValue("@VendorName", VendorId);
                            command.Parameters.AddWithValue("@BrandStatus", cmbStatus.Text);
                            command.Parameters.AddWithValue("@BrandDescription", txtBrandDescription.Text);
                         
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
                if (string.IsNullOrWhiteSpace(txtBrandName.Text) || string.IsNullOrWhiteSpace(cmbVendorName.Text) || string.IsNullOrWhiteSpace(cmbStatus.Text) || string.IsNullOrWhiteSpace(txtBrandDescription.Text))
                {
                    MessageBox.Show("Please Fill Correct Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    string VendorId = "";
                    try
                    {
                        con.Open();
                        string query = "SELECT * FROM Vendors WHERE VendorName = '" + cmbVendorName.Text + "'";
                        SqlCommand cmd = new SqlCommand(query, con);
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            VendorId = Convert.ToString(reader["VendorName"]);
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
                        using (SqlCommand command = new SqlCommand("INSERT INTO Brands( BrandName, VendorName, BrandStatus, BrandDescription) VALUES (@BrandName, @VendorName, @BrandStatus, @BrandDescription);", con))
                        {
                            //command.Parameters.AddWithValue("@BrandId", txtBrandId.Text);
                            command.Parameters.AddWithValue("@BrandName", txtBrandName.Text);
                            command.Parameters.AddWithValue("@VendorName", VendorId);
                            command.Parameters.AddWithValue("@BrandStatus", cmbStatus.Text);
                            command.Parameters.AddWithValue("@BrandDescription", txtBrandDescription.Text);
                           
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string Keyword = txtSearch.Text.Trim();
            try
            {
                string query = "SELECT * FROM Brands WHERE BrandName LIKE @Keyword OR VendorName LIKE @Keyword OR BrandStatus LIKE @Keyword OR BrandDescription LIKE @Keyword";
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
                            row["BrandId"] = row["BrandId"].ToString();
                            row["BrandName"] = row["BrandName"].ToString();
                            row["VendorName"] = row["VendorName"].ToString();
                            row["BrandStatus"] = row["BrandStatus"].ToString();
                            row["BrandDescription"] = row["BrandDescription"].ToString();
                          
                        }
                    }
                    BrandsDataGridView.DataSource = dataTable;
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (BrandsDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to delete.");
                return;
            }
            DataGridViewRow selectedRow = BrandsDataGridView.SelectedRows[0];

            string BrandId = selectedRow.Cells[0].Value.ToString();
            string BrandName = selectedRow.Cells[1].Value.ToString();

            try
            {
                using (SqlCommand command = new SqlCommand("DELETE FROM Brands WHERE BrandId = @BrandId", con))
                {
                    command.Parameters.AddWithValue("@BrandId", BrandId);
                    con.Open();
                    command.ExecuteNonQuery();
                    BrandsDataGridView.Rows.Remove(selectedRow);
                    MessageBox.Show(BrandName + " - Sucessfully Deleted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void RefreshData()
        {
            dataAdapter = new SqlDataAdapter("SELECT * FROM Brands", con);
            dataTable = new DataTable();
            try
            {
                dataTable.Clear();
                dataAdapter.Fill(dataTable);

                foreach (DataRow row in dataTable.Rows)
                {
                    row["BrandId"] = row["BrandId"].ToString();
                    row["BrandName"] = row["BrandName"].ToString();
                    row["VendorName"] = row["VendorName"].ToString();
                    row["BrandStatus"] = row["BrandStatus"].ToString();
                    row["BrandDescription"] = row["BrandDescription"].ToString();
                   
                }
                BrandsDataGridView.DataSource = dataTable;
                BrandsDataGridView.Refresh();
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

        private void formBrand_Load(object sender, EventArgs e)
        {
            PopulateComboBox();
        }
    }
}
