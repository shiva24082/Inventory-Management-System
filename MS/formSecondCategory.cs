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
    public partial class formSecondCategory : Form
    {
        public SqlDataAdapter dataAdapter;
        public DataTable dataTable;
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Testing\MS\MS\MS\Database2.mdf;Integrated Security=True");
        public formSecondCategory()
        {
            InitializeComponent();
        }
        private void RefreshData()
        {
            dataAdapter = new SqlDataAdapter("SELECT * FROM SecondCategories", con);
            dataTable = new DataTable();
            try
            {
                dataTable.Clear();
                dataAdapter.Fill(dataTable);

                foreach (DataRow row in dataTable.Rows)
                {
                    row["SecondCategoryId"] = row["SecondCategoryId"].ToString();
                    row["SecondCategoryName"] = row["SecondCategoryName"].ToString();
                    row["MainCategoryName"] = row["MainCategoryName"].ToString();
                }
                SecondCategoriesDataGridView.DataSource = dataTable;
                SecondCategoriesDataGridView.Refresh();
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

        private void SecondCategoriesDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (SecondCategoriesDataGridView.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = SecondCategoriesDataGridView.Rows[e.RowIndex];
                    txtSecondCateId.Text = Convert.ToString(selectedRow.Cells[0].Value);
                    txtSecondCateName.Text = selectedRow.Cells[1].Value.ToString();
                    cmbMainCateName.SelectedItem = selectedRow.Cells[2].Value;
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
        private void PopulateComboBox()
        {
            try
            {
                con.Open();
                string query = "SELECT MainCategoryName FROM MainCategories";
                using(SqlCommand command = new SqlCommand(query, con))
                {
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        cmbMainCateName.Items.Clear();
                        while (reader.Read())
                        {
                            string SecondCateName = reader.GetString(0);
                            cmbMainCateName.Items.Add(SecondCateName);
                        }
                        con.Close();
                        reader.Close();
                    }
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtSecondCateId.Text))
            {
                if (string.IsNullOrWhiteSpace(txtSecondCateName.Text))
                {
                    MessageBox.Show("Please Fill Correct Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    string MainCateId = "";
                    try
                    {
                        con.Open();
                        string query = "SELECT * FROM MainCategories WHERE MainCategoryName = '" + cmbMainCateName.Text + "'";
                        SqlCommand cmd = new SqlCommand(query, con);
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            MainCateId = Convert.ToString(reader["MainCategoryName"]);
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
                        using (SqlCommand command = new SqlCommand("UPDATE SecondCategories SET SecondCategoryName = @SecondCategoryName, MainCategoryName = @MainCategoryName  WHERE SecondCategoryId  = @SecondCategoryId;", con))
                        {
                            command.Parameters.AddWithValue("@SecondCategoryId", txtSecondCateId.Text);
                            command.Parameters.AddWithValue("@SecondCategoryName", txtSecondCateName.Text);
                            command.Parameters.AddWithValue("@MainCategoryName", MainCateId);
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
                if (string.IsNullOrWhiteSpace(txtSecondCateName.Text))
                {
                    MessageBox.Show("Please Fill Correct Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    string MainCateId = "";
                    try
                    {
                        con.Open();
                        string query = "SELECT * FROM MainCategories WHERE MainCategoryName = '" + cmbMainCateName.Text + "'";
                        SqlCommand cmd = new SqlCommand(query, con);
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            MainCateId = Convert.ToString(reader["MainCategoryName"]);
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
                        using (SqlCommand command = new SqlCommand("INSERT INTO SecondCategories( SecondCategoryName, MainCategoryName ) VALUES (@SecondCategoryName, @MainCategoryName);", con))
                        {
                            //command.Parameters.AddWithValue("@BrandId", txtBrandId.Text);
                            command.Parameters.AddWithValue("@SecondCategoryName", txtSecondCateName.Text);
                            command.Parameters.AddWithValue("@MainCategoryName", MainCateId);

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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (SecondCategoriesDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to delete.");
                return;
            }
            DataGridViewRow selectedRow = SecondCategoriesDataGridView.SelectedRows[0];

            int SecondCateId = Convert.ToInt32(selectedRow.Cells[0].Value);
            string SecondCateName = selectedRow.Cells[1].Value.ToString();

            try
            {
                using (SqlCommand command = new SqlCommand("DELETE FROM SecondCategories WHERE SecondCategoryId = @SecondCategoryId", con))
                {
                    command.Parameters.AddWithValue("@SecondCategoryId", SecondCateId);
                    con.Open();
                    command.ExecuteNonQuery();
                   SecondCategoriesDataGridView.Rows.Remove(selectedRow);
                    MessageBox.Show(SecondCateName + " - Sucessfully Deleted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnAddMainCate_Click(object sender, EventArgs e)
        {
            formMainCategory formMainCategory = new formMainCategory();
            formMainCategory.ShowDialog();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string Keyword = txtSearch.Text.Trim();
            try
            {
                string query = "SELECT * FROM SecondCategories WHERE SecondCategoryName LIKE @Keyword OR MainCategoryName LIKE @Keyword";
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
                            row["SecondCategoryId"] = row["SecondCategoryId"].ToString();
                            row["SecondCategoryName"] = row["SecondCategoryName"].ToString();
                            row["MainCategoryName"] = row["MainCategoryName"].ToString();
                        }
                    }
                    SecondCategoriesDataGridView.DataSource = dataTable;
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

        private void formSecondCategory_Load(object sender, EventArgs e)
        {
            PopulateComboBox();
        }
    }
}
