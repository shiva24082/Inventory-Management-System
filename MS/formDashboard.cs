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
    public partial class formDashboard : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Testing\MS\MS\MS\Database2.mdf;Integrated Security=True");
        public formDashboard(string username, string role)
        {
            InitializeComponent();
            lblRole.Text = role;
            lblUserName.Text = username;
            if(role == "Cashier")
            {
                btnMasterusers.Enabled = false;
                btnMasterusers.Visible = false;
                btnMastercategories.Enabled = false;
                btnMastercategories.Visible = false;
                btnSellinghistory.Location = new Point(13, 270);
            }
            else if(role == "Salesman")
            {
                btnMasterusers.Enabled = false;
                btnMasterusers.Visible = false;
                btnMastercategories.Enabled = false;
                btnMastercategories.Visible = false;
                btnAllstocks.Enabled = false;
                btnAllstocks.Visible = false;
                btnSellinghistory.Location = new Point(13, 213);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            sideBar.Height = btnDashboard.Height;
            sideBar.Top = btnDashboard.Top;

            UCDashboard uCDashboard = new UCDashboard();
            uCDashboard.TopLevel = false;
            uCDashboard.FormBorderStyle = FormBorderStyle.None;
            uCDashboard.Dock = DockStyle.Fill;
            tabDashboard.Controls.Clear();
            tabDashboard.Controls.Add(uCDashboard);
            uCDashboard.Show();

            this.Text = "IMS : Dashboard";
        }

        private void btnMasterusers_Click(object sender, EventArgs e)
        {
            sideBar.Height = btnMasterusers.Height;
            sideBar.Top = btnMasterusers.Top;

            UCMasterusers uCMasterusers = new UCMasterusers();
            uCMasterusers.TopLevel = false;
            uCMasterusers.FormBorderStyle = FormBorderStyle.None;
            uCMasterusers.Dock = DockStyle.Fill;
            tabDashboard.Controls.Clear();
            tabDashboard.Controls.Add(uCMasterusers);
            uCMasterusers.Show();

            this.Text = "IMS : Master Users";
        }

        private void btnmakesales_Click(object sender, EventArgs e)
        {
            sideBar.Height = btnmakesales.Height;
            sideBar.Top = btnmakesales.Top;

            formMakesales formMakesales = new formMakesales();
            formMakesales.TopLevel = false;
            formMakesales.FormBorderStyle = FormBorderStyle.None;
            formMakesales.Dock = DockStyle.Fill;
            tabDashboard.Controls.Clear();
            tabDashboard.Controls.Add(formMakesales);
            formMakesales.Show();

            this.Text = "IMS : Make Sales";
        }

        private void btnAllstocks_Click(object sender, EventArgs e)
        {
            sideBar.Height = btnAllstocks.Height;
            sideBar.Top = btnAllstocks.Top;

            formAddproducts formAddproducts = new formAddproducts();
            formAddproducts.TopLevel = false;
            formAddproducts.FormBorderStyle = FormBorderStyle.None;
            formAddproducts.Dock = DockStyle.Fill;
            tabDashboard.Controls.Clear();
            tabDashboard.Controls.Add(formAddproducts);
            formAddproducts.Show();

            this.Text = "IMS : All Stock";
        }

        private void btnMastercategories_Click(object sender, EventArgs e)
        {
            sideBar.Height = btnMastercategories.Height;
            sideBar.Top = btnMastercategories.Top;

            formMasterCategory formMasterCategory = new formMasterCategory();
            formMasterCategory.TopLevel = false;
            formMasterCategory.FormBorderStyle = FormBorderStyle.None;
            formMasterCategory.Dock = DockStyle.Fill;
            tabDashboard.Controls.Clear();
            tabDashboard.Controls.Add(formMasterCategory);
            formMasterCategory.Show();

            this.Text = "IMS : Master Categories";

        }

        private void btnSellinghistory_Click(object sender, EventArgs e)
        {
            sideBar.Height = btnSellinghistory.Height;
            sideBar.Top = btnSellinghistory.Top;

            formSalesHistory formSalesHistory = new formSalesHistory();
            formSalesHistory.TopLevel = false;
            formSalesHistory.FormBorderStyle = FormBorderStyle.None;
            formSalesHistory.Dock = DockStyle.Fill;
            tabDashboard.Controls.Clear();
            tabDashboard.Controls.Add(formSalesHistory);
            formSalesHistory.Show();

            this.Text = "IMS : Selling History";
        }

        private void formDashboard_Load(object sender, EventArgs e)
        {
            UCDashboard uCDashboard = new UCDashboard();
            uCDashboard.TopLevel = false;
            uCDashboard.FormBorderStyle = FormBorderStyle.None;
            uCDashboard.Dock = DockStyle.Fill;
            tabDashboard.Controls.Clear();
            tabDashboard.Controls.Add(uCDashboard);
            uCDashboard.Show();

            this.Text = "IMS : Dashboard";
        }
    }
}
