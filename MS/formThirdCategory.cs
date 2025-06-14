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
    public partial class formThirdCategory : Form
    {
        public SqlDataAdapter dataAdapter;
        public DataTable dataTable;
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Testing\MS\MS\MS\Database2.mdf;Integrated Security=True");
        public formThirdCategory()
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
                string query = "SELECT SecondCategoryName FROM SecondCategories";
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        cmbSecondCateName.Items.Clear();
                        while (reader.Read())
                        {
                            string SecondCateName = reader.GetString(0);
                            cmbSecondCateName.Items.Add(SecondCateName);
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
            dataAdapter = new SqlDataAdapter("SELECT * FROM ThirdCategories", con);
            dataTable = new DataTable();
            try
            {
                dataTable.Clear();
                dataAdapter.Fill(dataTable);

                foreach (DataRow row in dataTable.Rows)
                {
                    row["ThirdCategoryId"] = row["ThirdCategoryId"].ToString();
                    row["ThirdCategoryName"] = row["ThirdCategoryName"].ToString();
                    row["SecondCategoryName"] = row["SecondCategoryName"].ToString();
                }
                ThirdCategoriesDataGridView.DataSource = dataTable;
                ThirdCategoriesDataGridView.Refresh();
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (ThirdCategoriesDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to delete.");
                return;
            }
            DataGridViewRow selectedRow = ThirdCategoriesDataGridView.SelectedRows[0];

            string ThirdCateId = selectedRow.Cells[0].Value.ToString();
            string ThirdCateName = selectedRow.Cells[1].Value.ToString();

            try
            {
                using (SqlCommand command = new SqlCommand("DELETE FROM ThirdCategories WHERE ThirdCategoryId = @ThirdCategoryId", con))
                {
                    command.Parameters.AddWithValue("@ThirdCategoryId", ThirdCateId);
                    con.Open();
                    command.ExecuteNonQuery();
                    ThirdCategoriesDataGridView.Rows.Remove(selectedRow);
                    MessageBox.Show(ThirdCateName + " - Sucessfully Deleted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                string query = "SELECT * FROM ThirdCategories WHERE ThirdCategoryName LIKE @Keyword OR SecondCategoryName LIKE @Keyword";
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
                            row["ThirdCategoryId"] = row["ThirdCategoryId"].ToString();
                            row["ThirdCategoryName"] = row["ThirdCategoryName"].ToString();
                            row["SecondCategoryName"] = row["SecondCategoryName"].ToString();
                        }
                    }
                    ThirdCategoriesDataGridView.DataSource = dataTable;
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
            if (!string.IsNullOrWhiteSpace(txtThirdCateId.Text))
            {
                if (string.IsNullOrWhiteSpace(txtThirdCateName.Text))
                {
                    MessageBox.Show("Please Fill Correct Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    string SecondCateId = "";
                    try
                    {
                        con.Open();
                        string query = "SELECT * FROM SecondCategories WHERE SecondCategoryName = '" + cmbSecondCateName.Text + "'";
                        SqlCommand cmd = new SqlCommand(query, con);
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            SecondCateId = Convert.ToString(reader["SecondCategoryName"]);
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
                        using (SqlCommand command = new SqlCommand("UPDATE ThirdCategories SET ThirdCategoryName = @ThirdCategoryName, SecondCategoryName = @SecondCategoryName  WHERE ThirdCategoryId  = @ThirdCategoryId;", con))
                        {
                            command.Parameters.AddWithValue("@ThirdCategoryId", txtThirdCateId.Text);
                            command.Parameters.AddWithValue("@ThirdCategoryName", txtThirdCateName.Text);
                            command.Parameters.AddWithValue("@SecondCategoryName", SecondCateId);
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
                if (string.IsNullOrWhiteSpace(txtThirdCateName.Text))
                {
                    MessageBox.Show("Please Fill Correct Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    string SecondCateId = "";
                    try
                    {
                        con.Open();
                        string query = "SELECT * FROM SecondCategories WHERE SecondCategoryName = '" + cmbSecondCateName.Text + "'";
                        SqlCommand cmd = new SqlCommand(query, con);
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            SecondCateId = Convert.ToString(reader["SecondCategoryName"]);
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
                        using (SqlCommand command = new SqlCommand("INSERT INTO ThirdCategories( ThirdCategoryName, SecondCategoryName ) VALUES (@ThirdCategoryName, @SecondCategoryName);", con))
                        {
                          
                            command.Parameters.AddWithValue("@ThirdCategoryName", txtThirdCateName.Text);
                            command.Parameters.AddWithValue("@SecondCategoryName", SecondCateId);
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

        private void btnAddMainCate_Click(object sender, EventArgs e)
        {
            formSecondCategory formSecondCategory = new formSecondCategory();
            formSecondCategory.ShowDialog();
        }

        private void ThirdCategoriesDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (ThirdCategoriesDataGridView.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = ThirdCategoriesDataGridView.Rows[e.RowIndex];
                    txtThirdCateId.Text = Convert.ToString(selectedRow.Cells[0].Value);
                    txtThirdCateName.Text = selectedRow.Cells[1].Value.ToString();
                    cmbSecondCateName.SelectedItem = selectedRow.Cells[2].Value;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void formThirdCategory_Load(object sender, EventArgs e)
        {
            PopulateComboBox();
        }
    }
}
