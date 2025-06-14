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
    public partial class UCDashboard : Form
    {
        public SqlDataAdapter dataAdapter;
        public DataTable dataTable;
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Testing\MS\MS\MS\Database2.mdf;Integrated Security=True");
        public UCDashboard()
        {
            InitializeComponent();
        }
        private void LoadStockData()
        {
            string availabe = "Available";
            con.Open();
            string queryAvailableStock = "SELECT COUNT(*) FROM Products WHERE ProductStatus ='" + availabe + "'";
            SqlCommand commandAvailableStock = new SqlCommand(queryAvailableStock, con);
            int availableStock = (int)commandAvailableStock.ExecuteScalar();
            lblAvailableStock.Text = availableStock.ToString();

            string queryTotalStock = "SELECT COUNT(*) FROM Products";
            SqlCommand commandTotalStock = new SqlCommand( queryTotalStock, con);
            int totalStock = (int)commandTotalStock.ExecuteScalar();
            lblTotalStock.Text = totalStock.ToString();

            lblNotAvailableStock.Text = (totalStock - availableStock).ToString();
            con.Close();
        }

        private void LoadCategoriesData()
        {
            con.Open();
            string queryMainCategories = "SELECT COUNT(*) FROM MainCategories";
            SqlCommand commandMainCategories = new SqlCommand(queryMainCategories, con);
            int mainCategoriesCount = (int)commandMainCategories.ExecuteScalar();
            lblTotalMC.Text = mainCategoriesCount.ToString();

            string querySecondCategories = "SELECT COUNT(*) FROM SecondCategories";
            SqlCommand commandSecondCategories = new SqlCommand(querySecondCategories, con);
            int secondCategoriesCount = (int)commandSecondCategories.ExecuteScalar();
            lblTotalSC.Text = secondCategoriesCount.ToString();

            string queryThirdCategories = "SELECT COUNT(*) FROM ThirdCategories";
            SqlCommand commandThirdCategories = new SqlCommand(queryThirdCategories, con);
            int thirdCategoriesCount = (int)commandThirdCategories.ExecuteScalar();
            lblTotalTH.Text = thirdCategoriesCount.ToString();

            string queryBrands = "SELECT COUNT(*) FROM Brands";
            SqlCommand commandBrands = new SqlCommand(queryBrands, con);
            int brandsCount = (int)commandBrands.ExecuteScalar();
            lblTotalBR.Text = brandsCount.ToString();

            string queryVendors = "SELECT COUNT(*) FROM Vendors";
            SqlCommand commandVendors = new SqlCommand(queryVendors, con);
            int vendorsCount = (int)commandVendors.ExecuteScalar();
            lblTotalVN.Text = vendorsCount.ToString();
            con.Close();


        }
        private void LoadUsersData()
        {
            con.Open();
            string queryAdmins = "SELECT COUNT(*) FROM Users WHERE Role ='"+"Admin"+"'";
            SqlCommand commandAdmins = new SqlCommand(queryAdmins, con);
            int adminsCount = (int)commandAdmins.ExecuteScalar();
            lblTotalAdmin.Text = adminsCount.ToString();

            string queryCashiers = "SELECT COUNT(*) FROM Users WHERE Role ='" + "Cashier" + "'";
            SqlCommand commandCashiers = new SqlCommand(queryCashiers, con);
            int cashiersCount = (int)commandCashiers.ExecuteScalar();
            lblTotalCashier.Text = cashiersCount.ToString();

            string querySalesmans = "SELECT COUNT(*) FROM Users WHERE Role ='" + "Salesman" + "'";
            SqlCommand commandSalesmans = new SqlCommand(querySalesmans, con);
            int salesmansCount = (int)commandSalesmans.ExecuteScalar();
            lblTotalSalesMan.Text = salesmansCount.ToString();

            lblTotalUser.Text = (adminsCount + cashiersCount + salesmansCount).ToString();
            con.Close();

        }
        private void LoadSalesData()
        {
            con.Open();
            string queryToday = "SELECT COUNT(*) FROM Orders WHERE CONVERT(DATE, PurchasedDate) = CONVERT(DATE, GETDATE())";
            SqlCommand commandToday = new SqlCommand(queryToday, con);
            int salesToday = (int)commandToday.ExecuteScalar();
            lblLastDaySell.Text = salesToday.ToString();

            string queryLast7Days = "SELECT COUNT(*) FROM Orders WHERE PurchasedDate >= DATEADD(dd, -7, GETDATE())";
            SqlCommand commandLast7Days = new SqlCommand(queryLast7Days, con);
            int salesLast7Days = (int)commandLast7Days.ExecuteScalar();
            lblLast7DaySell.Text = salesLast7Days.ToString();

            string queryLast30Days = "SELECT COUNT(*) FROM Orders WHERE PurchasedDate >= DATEADD(dd, -30, GETDATE())";
            SqlCommand commandLast30Days = new SqlCommand(queryLast30Days, con);
            int salesLast30Days = (int)commandLast30Days.ExecuteScalar();
            lblLast30DaySell.Text = salesLast30Days.ToString();

            string queryTotalSales = "SELECT COUNT(*) FROM Orders";
            SqlCommand commandTotalSales = new SqlCommand(queryTotalSales, con);
            int totalSales = (int)commandTotalSales.ExecuteScalar();
            lblLastTotalSell.Text = totalSales.ToString();
            con.Close();
        }
        private void LoadSalariesData()
        {
            con.Open();
            string queryAdminSalaries = "SELECT SUM(Salary) FROM Users WHERE Role = '" + "Admin" + "'";
            SqlCommand commandAdminSalaries  = new SqlCommand(queryAdminSalaries, con);
            Int64 adminSalariesSum = (Int64)commandAdminSalaries.ExecuteScalar();
            lblAdminTotalSal.Text = adminSalariesSum.ToString();

            string queryCashierSalaries = "SELECT SUM(Salary) FROM Users WHERE Role = '" + "Cashier" + "'";
            SqlCommand commandCashierSalaries = new SqlCommand(queryCashierSalaries, con);
            Int64 cashierSalariesSum = (Int64)commandCashierSalaries.ExecuteScalar();
            lblCashierTotalSal.Text = cashierSalariesSum.ToString();

            string querySalesmanSalaries = "SELECT SUM(Salary) FROM Users WHERE Role = '" + "Salesman" + "'";
            SqlCommand commandSalesmanSalaries = new SqlCommand(querySalesmanSalaries, con);
            Int64 salesmanSalariesSum = (Int64)commandSalesmanSalaries.ExecuteScalar();
            lblSalesManTotalSal.Text = salesmanSalariesSum.ToString();

            lblTotalSal.Text = (adminSalariesSum + cashierSalariesSum + salesmanSalariesSum).ToString();

            con.Close();

        }

        private void UCDashboard_Load(object sender, EventArgs e)
        {
            LoadCategoriesData();
            LoadStockData();
            LoadUsersData();
            LoadSalesData();
            LoadSalariesData();
        }
    }
}
