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
    public partial class formMainCategory : Form
    {
        public SqlDataAdapter dataAdapter;
        public DataTable dataTable;
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Testing\MS\MS\MS\Database2.mdf;Integrated Security=True");
        public formMainCategory()
        {
            InitializeComponent();
        }

        private void MainCategoriesDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (MainCategoriesDataGridView.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = MainCategoriesDataGridView.Rows[e.RowIndex];
                    int MainCateId = Convert.ToInt32(selectedRow.Cells[0].Value);
                    string MainCateName = Convert.ToString(selectedRow.Cells[1].Value);
                    txtMainCateId.Text = MainCateId.ToString();
                    txtMainCateName.Text = MainCateName;
                  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }
        private void RefreshData()
        {
            dataAdapter = new SqlDataAdapter("SELECT * FROM MainCategories", con);
            dataTable = new DataTable();
            try
            {
                dataTable.Clear();
                dataAdapter.Fill(dataTable);

                foreach (DataRow row in dataTable.Rows)
                {
                    row["MainCategoryId"] = row["MainCategoryId"].ToString();
                    row["MainCategoryName"] = row["MainCategoryName"].ToString();
                }
                MainCategoriesDataGridView.DataSource = dataTable;
                MainCategoriesDataGridView.Refresh();
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

        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            if (MainCategoriesDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to delete.");
                return;
            }
            DataGridViewRow selectedRow = MainCategoriesDataGridView.SelectedRows[0];

            string MainCateId = selectedRow.Cells[0].Value.ToString();
            string MainCateName = selectedRow.Cells[1].Value.ToString();

            try
            {
                using (SqlCommand command = new SqlCommand("DELETE FROM MainCategories WHERE MainCategoryId = @MainCategoryId", con))
                {
                    command.Parameters.AddWithValue("@MainCategoryId", MainCateId);
                    con.Open();
                    command.ExecuteNonQuery();
                    MainCategoriesDataGridView.Rows.Remove(selectedRow);
                    MessageBox.Show(MainCateName + " - Sucessfully Deleted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string Keyword = txtSearch.Text.Trim();
            try
            {
                string query = "SELECT * FROM MainCategories WHERE MainCategoryName LIKE @Keyword";
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
                            row["MainCategoryId"] = row["MainCategoryId"].ToString();
                            row["MainCategoryName"] = row["MainCategoryName"].ToString();
                        }
                    }
                    MainCategoriesDataGridView.DataSource = dataTable;
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

        private void btnSaveCategory_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtMainCateId.Text))
            {
                if (string.IsNullOrWhiteSpace(txtMainCateName.Text))
                {
                    MessageBox.Show("Please Fill Correct Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    try
                    {
                        using (SqlCommand command = new SqlCommand("UPDATE MainCategories SET MainCategoryName = @MainCategoryName WHERE MainCategoryId = @MainCategoryId;", con))
                        {
                            command.Parameters.AddWithValue("@MainCategoryId", txtMainCateId.Text);
                            command.Parameters.AddWithValue("@MainCategoryName", txtMainCateName.Text);
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
                if (string.IsNullOrWhiteSpace(txtMainCateName.Text))
                {
                    MessageBox.Show("Please Fill Correct Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    try
                    {
                        using (SqlCommand command = new SqlCommand("INSERT INTO MainCategories( MainCategoryName ) VALUES (@MainCategoryName);", con))
                        {
                            //command.Parameters.AddWithValue("@BrandId", txtBrandId.Text);
                            command.Parameters.AddWithValue("@MainCategoryName", txtMainCateName.Text);

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
    }
}
