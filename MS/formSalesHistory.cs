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
using System.Drawing.Printing;

namespace MS
{
    public partial class formSalesHistory : Form
    {
        private PrintPreviewDialog printPreviewDialog1;
        private PrintDocument printDocument1;
        public SqlDataAdapter dataAdapter;
        public DataTable dataTable;
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Testing\MS\MS\MS\Database2.mdf;Integrated Security=True");
        public formSalesHistory()
        {
            InitializeComponent();

        }
        private void RefreshData()
        {
            dataAdapter = new SqlDataAdapter("SELECT * FROM Orders", con);
            dataTable = new DataTable();
            try
            {
                dataTable.Clear();
                dataAdapter.Fill(dataTable);

                foreach (DataRow row in dataTable.Rows)
                {
                    row["OrderId"] = row["OrderId"].ToString();
                    row["ProductName"] = row["ProductName"].ToString();
                    row["OrderQuantity"] = row["OrderQuantity"].ToString();
                    row["EmployeeFirstName"] = row["EmployeeFirstName"].ToString();
                    row["CustomerName"] = row["CustomerName"].ToString();
                    row["CustomerEmail"] = row["CustomerEmail"].ToString();
                    row["CustomerAddress"] = row["CustomerAddress"].ToString();
                    row["PaymentMethod"] = row["PaymentMethod"].ToString();
                    row["CustomerPhone"] = row["CustomerPhone"].ToString();
                    row["PurchasedDate"] = row["PurchasedDate"].ToString();
                    row["TotalAmount"] = row["TotalAmount"].ToString();

                }
                SalesHistoryDataGridView.DataSource = dataTable;
                SalesHistoryDataGridView.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Occured While Refreshing Data" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
            int rowcount = SalesHistoryDataGridView.Rows.Count;
            lblTotalItemResult.Text = rowcount.ToString();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshData();

        }
      

        private void txtSearchForSell_TextChanged(object sender, EventArgs e)
        {
            string Keyword = txtSearchForSell.Text.Trim();
            try
            {
                string query = "SELECT * FROM Orders WHERE ProductName LIKE @Keyword OR PaymentMethod LIKE @Keyword OR EmployeeFirstName LIKE @Keyword OR CustomerName LIKE @Keyword OR CustomerEmail LIKE @Keyword OR CustomerAddress LIKE @Keyword OR CustomerPhone LIKE @Keyword";
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
                            row["OrderId"] = row["OrderId"].ToString();
                            row["ProductName"] = row["ProductName"].ToString();
                            row["OrderQuantity"] = row["OrderQuantity"].ToString();
                            row["EmployeeFirstName"] = row["EmployeeFirstName"].ToString();
                            row["CustomerName"] = row["CustomerName"].ToString();
                            row["CustomerEmail"] = row["CustomerEmail"].ToString();
                            row["CustomerAddress"] = row["CustomerAddress"].ToString();
                            row["PaymentMethod"] = row["PaymentMethod"].ToString();
                            row["CustomerPhone"] = row["CustomerPhone"].ToString();
                            row["PurchasedDate"] = row["PurchasedDate"].ToString();
                            row["TotalAmount"] = row["TotalAmount"].ToString();
                        }
                    }
                    SalesHistoryDataGridView.DataSource = dataTable;
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
            int rowcount = SalesHistoryDataGridView.Rows.Count;
            lblTotalItemResult.Text = rowcount.ToString();
        }

        private void btnGenerateInvoice_Click(object sender, EventArgs e)
        {
            printPreviewDialog1 = new PrintPreviewDialog();
            printDocument1 = new PrintDocument();

            // Subscribe to the PrintPage event
            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            // Print the invoice
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
            MessageBox.Show("Invoice Generated Sucessfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (MessageBox.Show("Do you want to save the Invoice?", "Confirmation", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                printDocument1.Print();
            }
        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (SalesHistoryDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to generate the invoice.", "No Row Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataGridViewRow selectedRow = SalesHistoryDataGridView.SelectedRows[0];

            //string orderId = selectedRow.Cells[0].Value.ToString();
            //string purchaseDate = selectedRow.Cells[11].Value.ToString();
            //string productName = selectedRow.Cells[1].Value.ToString();
            //string orderQuantity = selectedRow.Cells[3].Value.ToString();
            //string totalAmount = selectedRow.Cells[12].Value.ToString();
            //string paymentMethod = selectedRow.Cells[9].Value.ToString();
            //string employeeFirstName = selectedRow.Cells[5].Value.ToString();
            //string customerFullName = selectedRow.Cells[6].Value.ToString();
            //string customerEmail = selectedRow.Cells[7].Value.ToString();
            //string customerAddress = selectedRow.Cells[8].Value.ToString();
            //string customerPhone = selectedRow.Cells[10].Value.ToString();
            string orderId = selectedRow.Cells[0].Value.ToString();
            string purchaseDate = selectedRow.Cells[9].Value.ToString();
            string productName = selectedRow.Cells[1].Value.ToString();
            string orderQuantity = selectedRow.Cells[2].Value.ToString();
            string totalAmount = selectedRow.Cells[10].Value.ToString();
            string paymentMethod = selectedRow.Cells[7].Value.ToString();
            string employeeFirstName = selectedRow.Cells[3].Value.ToString();
            string customerFullName = selectedRow.Cells[4].Value.ToString();
            string customerEmail = selectedRow.Cells[5].Value.ToString();
            string customerAddress = selectedRow.Cells[6].Value.ToString();
            string customerPhone = selectedRow.Cells[8].Value.ToString();

            // Define the invoice layout
            Font headerFont = new Font("Arial", 16, FontStyle.Bold);
            Font subheaderFont = new Font("Arial", 14, FontStyle.Bold);
            Font normalFont = new Font("Arial", 12);
            float yPos = 100;
            float pageWidth = e.MarginBounds.Width;
            float leftMargin = e.MarginBounds.Left;
            float topMargin = e.MarginBounds.Top;
            float centre = (pageWidth - e.Graphics.MeasureString("INVENTORY MANAGEMENT SYSTEM", headerFont).Width) / 2;
            float centre1 = (pageWidth - e.Graphics.MeasureString("INVOICE", headerFont).Width) / 2;
            float centre2 = (pageWidth - e.Graphics.MeasureString("Invoice generated on " + DateTime.Now.ToString(), headerFont).Width) / 2;
            // Draw a dotted line separator
            Pen separatorPen = new Pen(Color.Black, 1);
            separatorPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            e.Graphics.DrawLine(separatorPen, leftMargin, yPos, e.MarginBounds.Right, yPos);
            yPos += 10;

            // Draw the header
            e.Graphics.DrawString("INVENTORY MANAGEMENT SYSTEM", headerFont, Brushes.Blue, leftMargin + 120, topMargin);
            yPos += headerFont.GetHeight();

            // Draw the invoice title
            e.Graphics.DrawString("INVOICE", subheaderFont, Brushes.Red, leftMargin + 270, yPos);
            yPos += subheaderFont.GetHeight() + 10;

            // Draw a dotted line separator
            e.Graphics.DrawLine(separatorPen, leftMargin, yPos, e.MarginBounds.Right, yPos);
            yPos += 10;

            // Print the invoice data
            e.Graphics.DrawString("Order ID: " + orderId.PadRight(50) + "Purchased Date: " + purchaseDate, normalFont, Brushes.Black, leftMargin, yPos);
            yPos += normalFont.GetHeight() + 10;

            // Draw a dotted line separator
            e.Graphics.DrawLine(separatorPen, leftMargin, yPos, e.MarginBounds.Right, yPos);
            yPos += 40;

            e.Graphics.DrawString("Product Name: " + productName.PadRight(50) + "Order Quantity: " + orderQuantity, normalFont, Brushes.Black, leftMargin, yPos);
            yPos += normalFont.GetHeight() + 10;

            e.Graphics.DrawString("Total Amount: " + totalAmount.PadRight(50) + "Payment Method: " + paymentMethod, normalFont, Brushes.Black, leftMargin, yPos);
            yPos += normalFont.GetHeight() + 10;

            e.Graphics.DrawString("Seller Name: " + employeeFirstName.PadRight(50) + "Customer Name: " + customerFullName, normalFont, Brushes.Black, leftMargin, yPos);
            yPos += normalFont.GetHeight() + 10;

            e.Graphics.DrawString("Customer Email: " + customerEmail.PadRight(50) + "Customer Address: " + customerAddress, normalFont, Brushes.Black, leftMargin, yPos);
            yPos += normalFont.GetHeight() + 10;

            e.Graphics.DrawString("Customer Phone: " + customerPhone, normalFont, Brushes.Black, leftMargin, yPos);
            yPos += normalFont.GetHeight() + 40;

            // Draw a dotted line separator
            e.Graphics.DrawLine(separatorPen, leftMargin, yPos, e.MarginBounds.Right, yPos);
            yPos += 15;

            // Draw the footer
            e.Graphics.DrawString("Invoice generated on " + DateTime.Now.ToString(), normalFont, Brushes.Red, leftMargin + 130, yPos);
            yPos += normalFont.GetHeight();

            // Draw a dotted line separator
            e.Graphics.DrawLine(separatorPen, leftMargin, yPos, e.MarginBounds.Right, yPos);
        }
    }
}
