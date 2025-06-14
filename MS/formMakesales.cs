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
    public partial class formMakesales : Form
    {
        public SqlDataAdapter dataAdapter;
        public DataTable dataTable;
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Testing\MS\MS\MS\Database2.mdf;Integrated Security=True");
        public formMakesales()
        {
            InitializeComponent();
        }
        private void PopulateComboBox()
        {
            try
            {
                con.Open();
                string query = "SELECT FirstName FROM Users";
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        cmbSellby.Items.Clear();
                        while (reader.Read())
                        {
                            string UserName = reader.GetString(0);
                            cmbSellby.Items.Add(UserName);
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
        private void PopulateBrandComboBox()
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

        private void btnFillData_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_ProductId.Text))
            {
                MessageBox.Show("Please Enter Product Id", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int productId = int.Parse(txt_ProductId.Text);
                //string brandid = "";
                try
                {
                    con.Open();
                    string query = "SELECT * FROM Products WHERE ProductId = '" + productId + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader read = cmd.ExecuteReader();
                    if (read.Read())
                    {
                        txt_ProductName.Text = Convert.ToString(read["ProductName"]);
                        txtPrice.Text = Convert.ToString(read["ProductUnitPrice"]);
                        txtBrandName.Text = Convert.ToString(read["BrandName"]);
                    }
                    con.Close();
                    read.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error occurred while fetching Data: " + ex.Message);

                }
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
                    //row["ProductQuantity"] = row["ProductQuantity"].ToString();
                    row["ProductUnitPrice"] = row["ProductUnitPrice"].ToString();
                    row["ProductStatus"] = row["ProductStatus"].ToString();
                    //row["ProductWeight"] = row["ProductWeight"].ToString();
                    //row["ProductDescription"] = row["ProductDescription"].ToString();

                }
                CartDataGridView.DataSource = dataTable;
                CartDataGridView.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured While Refreshing Data" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }

        private void CartDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (CartDataGridView.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = CartDataGridView.Rows[e.RowIndex];
                    txt_ProductId.Text = selectedRow.Cells[0].Value.ToString();
                    txt_ProductName.Text = Convert.ToString(selectedRow.Cells[1].Value);
                    txtBrandName.Text = Convert.ToString(selectedRow.Cells[2].Value);
                    txtPrice.Text = Convert.ToString(selectedRow.Cells[3].Value);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void formMakesales_Load(object sender, EventArgs e)
        {
            PopulateComboBox();
            PopulateBrandComboBox();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string Keyword = txtSearch.Text.Trim();
            try
            {
                string query = "SELECT * FROM Products WHERE ProductName LIKE @Keyword OR BrandName LIKE @Keyword OR ProductStatus LIKE @Keyword ";
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
                            //row["ProductQuantity"] = row["ProductQuantity"].ToString();
                            //row["ProductUnitPrice"] = row["ProductUnitPrice"].ToString();
                            row["ProductStatus"] = row["ProductStatus"].ToString();
                            //row["ProductWeight"] = row["ProductWeight"].ToString();
                            //row["ProductDescription"] = row["ProductDescription"].ToString();
                        }
                    }
                    CartDataGridView.DataSource = dataTable;
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
            int rowCount = CartDataGridView.Rows.Count;
            lblTotalItemResult.Text = rowCount.ToString();
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txt_Quantity.Text))
            {
                double price = Convert.ToDouble(txtPrice.Text);
                double quantity = Convert.ToDouble(txt_Quantity.Text);
                double totalAmount = price * quantity;
                txtTotalAmount.Text = Convert.ToString(totalAmount);

            }
        }

        private void txt_Quantity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtPrice.Text))
                {
                    if (!string.IsNullOrWhiteSpace(txt_Quantity.Text))
                    {
                        double price = Convert.ToDouble(txtPrice.Text);
                        double quantity = Convert.ToDouble(txt_Quantity.Text);
                        double totalAmount = price * quantity;
                        txtTotalAmount.Text = Convert.ToString(totalAmount);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnCancelSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            txt_ProductId.Text = "";
            txt_ProductName.Text = "";
            txtBrandName.Text = "";
            txt_Quantity.Text = "";
            txtPrice.Text = "";
            cmbSellby.SelectedIndex = -1;
            txtCustomerName.Text = "";
            txtCustomerEmail.Text = "";
            txtCustomerAddress.Text = "";
            cmbPaymentMethod.SelectedIndex = 0;
            txtCustomerPhone.Text = "";
            txtTotalAmount.Clear();
        }

        private void btnPlaceOrderToSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_ProductName.Text) || string.IsNullOrWhiteSpace(txtPrice.Text) || string.IsNullOrWhiteSpace(txt_Quantity.Text) || string.IsNullOrWhiteSpace(cmbSellby.Text) || string.IsNullOrWhiteSpace(txtCustomerName.Text) || string.IsNullOrWhiteSpace(txtCustomerEmail.Text) || string.IsNullOrWhiteSpace(txtCustomerAddress.Text) || string.IsNullOrWhiteSpace(txtCustomerPhone.Text) || string.IsNullOrWhiteSpace(cmbPaymentMethod.Text) || string.IsNullOrWhiteSpace(txtTotalAmount.Text))
            {
                MessageBox.Show("Please Input Missing Fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                string UserId = "";
                try
                {
                    con.Open();
                    string query = "SELECT * FROM Users WHERE FirstName = '" + cmbSellby.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        UserId = Convert.ToString(reader["FirstName"]);
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
                    using (SqlCommand command = new SqlCommand("INSERT INTO Orders (ProductName, OrderQuantity, EmployeeFirstName, CustomerName, CustomerEmail, CustomerAddress, PaymentMethod, CustomerPhone, PurchasedDate, TotalAmount)" + "VALUES (@ProductName, @OrderQuantity, @EmployeeFirstName, @CustomerName, @CustomerEmail, @CustomerAddress, @PaymentMethod, @CustomerPhone, @PurchasedDate, @TotalAmount);", con))
                    {
                        command.Parameters.AddWithValue("@ProductName", txt_ProductName.Text);
                        command.Parameters.AddWithValue("@OrderQuantity", int.Parse(txt_Quantity.Text));
                        command.Parameters.AddWithValue("@EmployeeFirstName", cmbSellby.Text);
                        command.Parameters.AddWithValue("@CustomerName", txtCustomerName.Text);
                        command.Parameters.AddWithValue("@CustomerEmail", txtCustomerEmail.Text);
                        command.Parameters.AddWithValue("@CustomerAddress", txtCustomerAddress.Text);
                        command.Parameters.AddWithValue("@PaymentMethod", cmbPaymentMethod.Text);
                        command.Parameters.AddWithValue("@CustomerPhone", txtCustomerPhone.Text);
                        command.Parameters.AddWithValue("@PurchasedDate", dtpPaymentDate.Value.Date);
                        command.Parameters.AddWithValue("@TotalAmount", int.Parse(txtTotalAmount.Text));

                        con.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Order Placed Sucessfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
}
