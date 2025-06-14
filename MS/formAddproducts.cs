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
    public partial class formAddproducts : Form
    {
        public SqlDataAdapter dataAdapter;
        public DataTable dataTable;
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Testing\MS\MS\MS\Database2.mdf;Integrated Security=True");
        public formAddproducts()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtProductId.Text = "";
            txtProductName.Text = "";
            cmbBrand.SelectedIndex = -1;
            txtQuantity.Text = "";
            txtPerUnitPrice.Text = "";
            cmbStatus.SelectedIndex = -1;
            txtWeight.Text = "";
            txtDescription.Text = "";
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (ProductDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to delete.");
                return;
            }
            DataGridViewRow selectedRow = ProductDataGridView.SelectedRows[0];

            string ProductId = selectedRow.Cells[0].Value.ToString();
            string ProductName = selectedRow.Cells[1].Value.ToString();

            try
            {
                using (SqlCommand command = new SqlCommand("DELETE FROM Products WHERE ProductId = @ProductId", con))
                {
                    command.Parameters.AddWithValue("@ProductId", ProductId);
                    con.Open();
                    command.ExecuteNonQuery();
                    ProductDataGridView.Rows.Remove(selectedRow);
                    MessageBox.Show(ProductName + " - Sucessfully Deleted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void PopulateComboBox()
        {
            try
            {
                con.Open();
                string query = "SELECT BrandName FROM Brands";
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        cmbBrand.Items.Clear();
                        while (reader.Read())
                        {
                            string brandName = reader.GetString(0);
                            cmbBrand.Items.Add(brandName);
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
        private void RefreshData()
        {
            dataAdapter = new SqlDataAdapter("SELECT * FROM Products", con);
            dataTable = new DataTable();
            try
            {
                dataTable.Clear();
                dataAdapter.Fill(dataTable);

                foreach (DataRow row in dataTable.Rows)
                {
                    row["ProductId"] = row["ProductId"].ToString();
                    row["ProductName"] = row["ProductName"].ToString();
                    row["BrandName"] = row["BrandName"].ToString();
                    row["ProductQuantity"] = row["ProductQuantity"].ToString();
                    row["ProductUnitPrice"] = row["ProductUnitPrice"].ToString();
                    row["ProductStatus"] = row["ProductStatus"].ToString();
                    row["ProductWeight"] = row["ProductWeight"].ToString();
                    row["ProductDescription"] = row["ProductDescription"].ToString();

                }
                ProductDataGridView.DataSource = dataTable;
                ProductDataGridView.Refresh();
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

        private void formAddproducts_Load(object sender, EventArgs e)
        {
            PopulateComboBox();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtProductId.Text))
            {
                if (string.IsNullOrWhiteSpace(txtProductName.Text) || string.IsNullOrWhiteSpace(cmbBrand.Text) || string.IsNullOrWhiteSpace(txtQuantity.Text) || string.IsNullOrWhiteSpace(txtPerUnitPrice.Text) || string.IsNullOrWhiteSpace(cmbStatus.Text) || string.IsNullOrWhiteSpace(txtWeight.Text) || string.IsNullOrWhiteSpace(txtDescription.Text))
                {
                    MessageBox.Show("Please Fill Correct Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    string brandId = "";
                    try
                    {
                        con.Open();
                        string query = "SELECT * FROM Brands WHERE BrandName = '" + cmbBrand.Text + "'";
                        SqlCommand cmd = new SqlCommand(query, con);
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            brandId = Convert.ToString(reader["BrandName"]);
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
                        using (SqlCommand command = new SqlCommand("UPDATE Products  SET ProductName = @ProductName, BrandName = @BrandName, ProductQuantity = @ProductQuantity, ProductUnitPrice = @ProductUnitPrice, ProductStatus = @ProductStatus, ProductWeight = @ProductWeight, ProductDescription = @ProductDescription WHERE ProductId = @ProductId;", con))
                        {
                            command.Parameters.AddWithValue("@ProductId", txtProductId.Text);
                            command.Parameters.AddWithValue("@ProductName", txtProductName.Text);
                            command.Parameters.AddWithValue("@BrandName", brandId);
                            command.Parameters.AddWithValue("@ProductQuantity", txtQuantity.Text);
                            command.Parameters.AddWithValue("@ProductUnitPrice", txtPerUnitPrice.Text);
                            command.Parameters.AddWithValue("@ProductStatus", cmbStatus.Text);
                            command.Parameters.AddWithValue("@ProductWeight", txtWeight.Text);
                            command.Parameters.AddWithValue("@ProductDescription", txtDescription.Text);

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
                if (string.IsNullOrWhiteSpace(txtProductName.Text) || string.IsNullOrWhiteSpace(cmbBrand.Text) || string.IsNullOrWhiteSpace(txtQuantity.Text) || string.IsNullOrWhiteSpace(txtPerUnitPrice.Text) || string.IsNullOrWhiteSpace(cmbStatus.Text) || string.IsNullOrWhiteSpace(txtWeight.Text) || string.IsNullOrWhiteSpace(txtDescription.Text))
                {
                    MessageBox.Show("Please Fill Correct Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    string brandId = "";
                    try
                    {
                        con.Open();
                        string query = "SELECT * FROM Brands WHERE BrandName = '" + cmbBrand.Text + "'";
                        SqlCommand cmd = new SqlCommand(query, con);
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            brandId = Convert.ToString(reader["BrandName"]);
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
                        using (SqlCommand command = new SqlCommand("INSERT INTO Products( ProductName, BrandName, ProductQuantity, ProductUnitPrice, ProductStatus, ProductWeight, ProductDescription) VALUES (@ProductName, @BrandName, @ProductQuantity, @ProductUnitPrice, @ProductStatus, @ProductWeight, @ProductDescription);", con))
                        {
                            //command.Parameters.AddWithValue("@ProductId", txtProductId.Text);
                            command.Parameters.AddWithValue("@ProductName", txtProductName.Text);
                            command.Parameters.AddWithValue("@BrandName", brandId);
                            command.Parameters.AddWithValue("@ProductQuantity", txtQuantity.Text);
                            command.Parameters.AddWithValue("@ProductUnitPrice", txtPerUnitPrice.Text);
                            command.Parameters.AddWithValue("@ProductStatus", cmbStatus.Text);
                            command.Parameters.AddWithValue("@ProductWeight", txtWeight.Text);
                            command.Parameters.AddWithValue("@ProductDescription", txtDescription.Text);


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

        private void ProductDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (ProductDataGridView.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = ProductDataGridView.Rows[e.RowIndex];
                    int productId = Convert.ToInt32(selectedRow.Cells[0].Value);
                    string productName = selectedRow.Cells[1].Value.ToString();
                    string brandName = selectedRow.Cells[2].Value.ToString();
                    int productQuantity = Convert.ToInt32(selectedRow.Cells[3].Value);
                    int productUnitPrice = Convert.ToInt32(selectedRow.Cells[4].Value);
                    string productStatus = Convert.ToString(selectedRow.Cells[5].Value);
                    int  productWeight = Convert.ToInt32(selectedRow.Cells[6].Value);
                    string productDescription = Convert.ToString(selectedRow.Cells[7].Value);

                    txtProductId.Text = productId.ToString();
                    txtProductName.Text = productName;
                    cmbBrand.Text = brandName;
                    txtQuantity.Text = productQuantity.ToString();
                    txtPerUnitPrice.Text = productUnitPrice.ToString();
                    cmbStatus.Text = productStatus;
                    txtWeight.Text = productWeight.ToString();
                    txtDescription.Text = productDescription;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string Keyword = txtSearch.Text.Trim();
            try
            {
                string query = "SELECT * FROM Products WHERE ProductName LIKE @Keyword OR BrandName LIKE @Keyword OR ProductStatus LIKE @Keyword OR ProductDescription LIKE @Keyword";
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
                            row["ProductId"] = row["ProductId"].ToString();
                            row["ProductName"] = row["ProductName"].ToString();
                            row["BrandName"] = row["BrandName"].ToString();
                            row["ProductQuantity"] = row["ProductQuantity"].ToString();
                            row["ProductUnitPrice"] = row["ProductUnitPrice"].ToString();
                            row["ProductStatus"] = row["ProductStatus"].ToString();
                            row["ProductWeight"] = row["ProductWeight"].ToString();
                            row["ProductDescription"] = row["ProductDescription"].ToString();
                        }
                    }
                    ProductDataGridView.DataSource = dataTable;
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
