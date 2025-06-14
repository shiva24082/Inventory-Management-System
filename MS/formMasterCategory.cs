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
    public partial class formMasterCategory : Form
    {
        public SqlDataAdapter dataAdapter;
        public DataTable dataTable;
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Testing\MS\MS\MS\Database2.mdf;Integrated Security=True");
        public formMasterCategory()
        {
            InitializeComponent();
        }

        private void btnAddMainCate_Click(object sender, EventArgs e)
        {
            formMainCategory formMainCategory = new formMainCategory();
            formMainCategory.ShowDialog();
        }

        private void btnAddSecondCate_Click(object sender, EventArgs e)
        {
            formSecondCategory formSecondCategory = new formSecondCategory();
            formSecondCategory.ShowDialog();
        }

        private void btnAddThirdCate_Click(object sender, EventArgs e)
        {
            formThirdCategory formThirdCategory = new formThirdCategory();
            formThirdCategory.ShowDialog();
        }

        private void btnAddVendor_Click(object sender, EventArgs e)
        {
            formVendors formVendors = new formVendors();
            formVendors.ShowDialog();
        }

        private void btnAddBrands_Click(object sender, EventArgs e)
        {
            formBrand formBrand = new formBrand();
            formBrand.ShowDialog();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string Keyword = txtSearch.Text.Trim();
            try
            {
                string query = "SELECT * FROM MasterCategories WHERE ProductName LIKE @Keyword OR BrandName LIKE @Keyword OR VendorName LIKE @Keyword OR ThirdCategoryName LIKE @Keyword OR SecondCategoryName LIKE @Keyword OR MainCategoryName LIKE @Keyword";
                //string query = "SELECT p.ProductName, b.BrandName, v.VendorName, tc.ThirdCategoryName, sc.SecondCategoryName, mc.MainCategoryName FROM MasterCategories Mcs INNER JOIN Products p ON Mcs.ProductName = p.ProductName INNER JOIN Brands b ON Mcs.BrandName = b.BrandName INNER JOIN Vendors v ON Mcs.VendorName = v.VendorName INNER JOIN ThirdCategories tc ON Mcs.ThirdCategoryName = tc.ThirdCategoryName INNER JOIN SecondCategories sc ON Mcs.SecondCategoryName = sc.SecondCategoryName INNER JOIN MainCategories mc ON Mcs.MainCategoryName = mc.MainCategoryName WHERE p.ProductName LIKE @Keyword OR b.BrandName LIKE @Keyword OR v.VendorName LIKE @Keyword OR tc.ThirdCategoryName LIKE @Keyword OR sc.SecondCategoryName LIKE @Keyword OR mc.MainCategoryName LIKE @Keyword";
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
                            row["ProductName"] = row["ProductName"].ToString();
                            row["BrandName"] = row["BrandName"].ToString();
                            row["VendorName"] = row["VendorName"].ToString();
                            row["ThirdCategoryName"] = row["ThirdCategoryName"].ToString();
                            row["SecondCategoryName"] = row["SecondCategoryName"].ToString();
                            row["MainCategoryName"] = row["MainCategoryName"].ToString();
                        }
                    }
                    MasterCategoriesDataGridView.DataSource = dataTable;
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
            dataAdapter = new SqlDataAdapter("SELECT * FROM MasterCategories", con);
            //dataAdapter = new SqlDataAdapter("SELECT p.ProductName, b.BrandName, v.VendorName, tc.ThirdCategoryName, sc.SecondCategoryName, mc.MainCategoryName FROM MasterCategories Mcs INNER JOIN Products p ON Mcs.ProductName = p.ProductName INNER JOIN Brands b ON Mcs.BrandName = b.BrandName INNER JOIN Vendors v ON Mcs.VendorName = v.VendorName INNER JOIN ThirdCategories tc ON Mcs.ThirdCategoryName = tc.ThirdCategoryName INNER JOIN SecondCategories sc ON Mcs.SecondCategoryName = sc.SecondCategoryName INNER JOIN MainCategories mc ON Mcs.MainCategoryName = mc.MainCategoryName", con);
            dataTable = new DataTable();
            try
            {
                //dataTable.Clear();
                dataAdapter.Fill(dataTable);

                foreach (DataRow row in dataTable.Rows)
                {
                    row["ProductName"] = row["ProductName"].ToString();
                    row["BrandName"] = row["BrandName"].ToString();
                    row["VendorName"] = row["VendorName"].ToString();
                    row["ThirdCategoryName"] = row["ThirdCategoryName"].ToString();
                    row["SecondCategoryName"] = row["SecondCategoryName"].ToString();
                    row["MainCategoryName"] = row["MainCategoryName"].ToString();

                }
                MasterCategoriesDataGridView.DataSource = dataTable;
                MasterCategoriesDataGridView.Refresh();
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
    }
}
