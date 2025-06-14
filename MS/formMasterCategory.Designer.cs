namespace MS
{
    partial class formMasterCategory
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            this.txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            this.guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnAddBrands = new Guna.UI2.WinForms.Guna2Button();
            this.btnAddVendor = new Guna.UI2.WinForms.Guna2Button();
            this.btnAddThirdCate = new Guna.UI2.WinForms.Guna2Button();
            this.btnAddSecondCate = new Guna.UI2.WinForms.Guna2Button();
            this.btnAddMainCate = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.btnRefresh = new Guna.UI2.WinForms.Guna2Button();
            this.MasterCategoriesDataGridView = new Guna.UI2.WinForms.Guna2DataGridView();
            this.guna2Panel3.SuspendLayout();
            this.guna2Panel1.SuspendLayout();
            this.guna2Panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MasterCategoriesDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // guna2Panel3
            // 
            this.guna2Panel3.BackColor = System.Drawing.Color.White;
            this.guna2Panel3.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.guna2Panel3.Controls.Add(this.txtSearch);
            this.guna2Panel3.Controls.Add(this.guna2HtmlLabel3);
            this.guna2Panel3.Controls.Add(this.guna2HtmlLabel2);
            this.guna2Panel3.Location = new System.Drawing.Point(4, 2);
            this.guna2Panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.guna2Panel3.Name = "guna2Panel3";
            this.guna2Panel3.Size = new System.Drawing.Size(1041, 62);
            this.guna2Panel3.TabIndex = 2;
            // 
            // txtSearch
            // 
            this.txtSearch.AccessibleRole = System.Windows.Forms.AccessibleRole.Grip;
            this.txtSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSearch.DefaultText = "";
            this.txtSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSearch.IconRight = global::MS.Properties.Resources.icons8_search_480px;
            this.txtSearch.Location = new System.Drawing.Point(696, 9);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PasswordChar = '\0';
            this.txtSearch.PlaceholderText = "by Name, Tag, Cate. Brand";
            this.txtSearch.SelectedText = "";
            this.txtSearch.Size = new System.Drawing.Size(327, 37);
            this.txtSearch.TabIndex = 3;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // guna2HtmlLabel3
            // 
            this.guna2HtmlLabel3.AutoSize = false;
            this.guna2HtmlLabel3.BackColor = System.Drawing.Color.White;
            this.guna2HtmlLabel3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.guna2HtmlLabel3.Location = new System.Drawing.Point(532, 16);
            this.guna2HtmlLabel3.Margin = new System.Windows.Forms.Padding(0);
            this.guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            this.guna2HtmlLabel3.Size = new System.Drawing.Size(291, 43);
            this.guna2HtmlLabel3.TabIndex = 2;
            this.guna2HtmlLabel3.Text = "Search Categories";
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.AutoSize = false;
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.White;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel2.ForeColor = System.Drawing.Color.Black;
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(18, 13);
            this.guna2HtmlLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(426, 45);
            this.guna2HtmlLabel2.TabIndex = 1;
            this.guna2HtmlLabel2.Text = "View All Categories";
            // 
            // guna2Panel1
            // 
            this.guna2Panel1.AutoScroll = true;
            this.guna2Panel1.BackColor = System.Drawing.Color.White;
            this.guna2Panel1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.guna2Panel1.Controls.Add(this.btnAddBrands);
            this.guna2Panel1.Controls.Add(this.btnAddVendor);
            this.guna2Panel1.Controls.Add(this.btnAddThirdCate);
            this.guna2Panel1.Controls.Add(this.btnAddSecondCate);
            this.guna2Panel1.Controls.Add(this.btnAddMainCate);
            this.guna2Panel1.Location = new System.Drawing.Point(4, 68);
            this.guna2Panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.guna2Panel1.Name = "guna2Panel1";
            this.guna2Panel1.Size = new System.Drawing.Size(1041, 92);
            this.guna2Panel1.TabIndex = 3;
            // 
            // btnAddBrands
            // 
            this.btnAddBrands.Animated = true;
            this.btnAddBrands.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddBrands.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddBrands.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddBrands.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddBrands.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddBrands.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(255)))), ((int)(((byte)(203)))));
            this.btnAddBrands.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddBrands.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(173)))), ((int)(((byte)(27)))));
            this.btnAddBrands.HoverState.BorderColor = System.Drawing.Color.Black;
            this.btnAddBrands.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(173)))), ((int)(((byte)(27)))));
            this.btnAddBrands.HoverState.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddBrands.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnAddBrands.Location = new System.Drawing.Point(1300, 11);
            this.btnAddBrands.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddBrands.Name = "btnAddBrands";
            this.btnAddBrands.Size = new System.Drawing.Size(241, 43);
            this.btnAddBrands.TabIndex = 4;
            this.btnAddBrands.Text = "Add - Brands";
            this.btnAddBrands.TextOffset = new System.Drawing.Point(8, 0);
            this.btnAddBrands.Click += new System.EventHandler(this.btnAddBrands_Click);
            // 
            // btnAddVendor
            // 
            this.btnAddVendor.Animated = true;
            this.btnAddVendor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddVendor.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddVendor.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddVendor.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddVendor.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddVendor.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(255)))), ((int)(((byte)(203)))));
            this.btnAddVendor.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddVendor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(173)))), ((int)(((byte)(27)))));
            this.btnAddVendor.HoverState.BorderColor = System.Drawing.Color.Black;
            this.btnAddVendor.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(173)))), ((int)(((byte)(27)))));
            this.btnAddVendor.HoverState.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddVendor.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnAddVendor.Location = new System.Drawing.Point(1039, 11);
            this.btnAddVendor.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddVendor.Name = "btnAddVendor";
            this.btnAddVendor.Size = new System.Drawing.Size(241, 43);
            this.btnAddVendor.TabIndex = 3;
            this.btnAddVendor.Text = "Add - Vendors";
            this.btnAddVendor.TextOffset = new System.Drawing.Point(8, 0);
            this.btnAddVendor.Click += new System.EventHandler(this.btnAddVendor_Click);
            // 
            // btnAddThirdCate
            // 
            this.btnAddThirdCate.Animated = true;
            this.btnAddThirdCate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddThirdCate.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddThirdCate.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddThirdCate.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddThirdCate.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddThirdCate.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(255)))), ((int)(((byte)(203)))));
            this.btnAddThirdCate.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddThirdCate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(173)))), ((int)(((byte)(27)))));
            this.btnAddThirdCate.HoverState.BorderColor = System.Drawing.Color.Black;
            this.btnAddThirdCate.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(173)))), ((int)(((byte)(27)))));
            this.btnAddThirdCate.HoverState.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddThirdCate.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnAddThirdCate.Location = new System.Drawing.Point(710, 11);
            this.btnAddThirdCate.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddThirdCate.Name = "btnAddThirdCate";
            this.btnAddThirdCate.Size = new System.Drawing.Size(308, 43);
            this.btnAddThirdCate.TabIndex = 2;
            this.btnAddThirdCate.Text = "Add - Third Categories";
            this.btnAddThirdCate.TextOffset = new System.Drawing.Point(8, 0);
            this.btnAddThirdCate.Click += new System.EventHandler(this.btnAddThirdCate_Click);
            // 
            // btnAddSecondCate
            // 
            this.btnAddSecondCate.Animated = true;
            this.btnAddSecondCate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddSecondCate.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddSecondCate.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddSecondCate.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddSecondCate.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddSecondCate.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(255)))), ((int)(((byte)(203)))));
            this.btnAddSecondCate.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddSecondCate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(173)))), ((int)(((byte)(27)))));
            this.btnAddSecondCate.HoverState.BorderColor = System.Drawing.Color.Black;
            this.btnAddSecondCate.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(173)))), ((int)(((byte)(27)))));
            this.btnAddSecondCate.HoverState.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddSecondCate.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnAddSecondCate.Location = new System.Drawing.Point(355, 11);
            this.btnAddSecondCate.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddSecondCate.Name = "btnAddSecondCate";
            this.btnAddSecondCate.Size = new System.Drawing.Size(333, 43);
            this.btnAddSecondCate.TabIndex = 1;
            this.btnAddSecondCate.Text = "Add - Second Categories";
            this.btnAddSecondCate.TextOffset = new System.Drawing.Point(8, 0);
            this.btnAddSecondCate.Click += new System.EventHandler(this.btnAddSecondCate_Click);
            // 
            // btnAddMainCate
            // 
            this.btnAddMainCate.Animated = true;
            this.btnAddMainCate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddMainCate.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddMainCate.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddMainCate.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddMainCate.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddMainCate.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(255)))), ((int)(((byte)(203)))));
            this.btnAddMainCate.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddMainCate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(173)))), ((int)(((byte)(27)))));
            this.btnAddMainCate.HoverState.BorderColor = System.Drawing.Color.Black;
            this.btnAddMainCate.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(173)))), ((int)(((byte)(27)))));
            this.btnAddMainCate.HoverState.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddMainCate.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnAddMainCate.Location = new System.Drawing.Point(16, 11);
            this.btnAddMainCate.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddMainCate.Name = "btnAddMainCate";
            this.btnAddMainCate.Size = new System.Drawing.Size(317, 43);
            this.btnAddMainCate.TabIndex = 0;
            this.btnAddMainCate.Text = "Add - Main Categories";
            this.btnAddMainCate.TextOffset = new System.Drawing.Point(8, 0);
            this.btnAddMainCate.Click += new System.EventHandler(this.btnAddMainCate_Click);
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.AutoScroll = true;
            this.guna2Panel2.BackColor = System.Drawing.Color.White;
            this.guna2Panel2.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            this.guna2Panel2.Controls.Add(this.btnRefresh);
            this.guna2Panel2.Location = new System.Drawing.Point(3, 600);
            this.guna2Panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(1041, 55);
            this.guna2Panel2.TabIndex = 4;
            // 
            // btnRefresh
            // 
            this.btnRefresh.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnRefresh.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnRefresh.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnRefresh.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnRefresh.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(233)))), ((int)(((byte)(249)))));
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(148)))), ((int)(((byte)(247)))));
            this.btnRefresh.HoverState.BorderColor = System.Drawing.Color.Black;
            this.btnRefresh.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(148)))), ((int)(((byte)(247)))));
            this.btnRefresh.HoverState.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(233)))), ((int)(((byte)(249)))));
            this.btnRefresh.HoverState.Image = global::MS.Properties.Resources.icons8_restart_96px_1;
            this.btnRefresh.Image = global::MS.Properties.Resources.icons8_restart_96px;
            this.btnRefresh.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnRefresh.Location = new System.Drawing.Point(399, 6);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(263, 43);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.TextOffset = new System.Drawing.Point(15, 0);
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // MasterCategoriesDataGridView
            // 
            this.MasterCategoriesDataGridView.AllowUserToAddRows = false;
            this.MasterCategoriesDataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.MasterCategoriesDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.MasterCategoriesDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.None;
            this.MasterCategoriesDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MasterCategoriesDataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Raised;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.MasterCategoriesDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.MasterCategoriesDataGridView.ColumnHeadersHeight = 4;
            this.MasterCategoriesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.MasterCategoriesDataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.MasterCategoriesDataGridView.EnableHeadersVisualStyles = true;
            this.MasterCategoriesDataGridView.Location = new System.Drawing.Point(4, 166);
            this.MasterCategoriesDataGridView.Name = "MasterCategoriesDataGridView";
            this.MasterCategoriesDataGridView.ReadOnly = true;
            this.MasterCategoriesDataGridView.RowHeadersVisible = false;
            this.MasterCategoriesDataGridView.RowHeadersWidth = 51;
            this.MasterCategoriesDataGridView.RowTemplate.Height = 24;
            this.MasterCategoriesDataGridView.Size = new System.Drawing.Size(1040, 429);
            this.MasterCategoriesDataGridView.TabIndex = 5;
            this.MasterCategoriesDataGridView.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.MasterCategoriesDataGridView.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.MasterCategoriesDataGridView.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.MasterCategoriesDataGridView.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.MasterCategoriesDataGridView.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.MasterCategoriesDataGridView.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.MasterCategoriesDataGridView.ThemeStyle.GridColor = System.Drawing.SystemColors.ControlDark;
            this.MasterCategoriesDataGridView.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.MasterCategoriesDataGridView.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Raised;
            this.MasterCategoriesDataGridView.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MasterCategoriesDataGridView.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.MasterCategoriesDataGridView.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.MasterCategoriesDataGridView.ThemeStyle.HeaderStyle.Height = 4;
            this.MasterCategoriesDataGridView.ThemeStyle.ReadOnly = true;
            this.MasterCategoriesDataGridView.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
            this.MasterCategoriesDataGridView.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.MasterCategoriesDataGridView.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MasterCategoriesDataGridView.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            this.MasterCategoriesDataGridView.ThemeStyle.RowsStyle.Height = 24;
            this.MasterCategoriesDataGridView.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
            this.MasterCategoriesDataGridView.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
            // 
            // formMasterCategory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 660);
            this.Controls.Add(this.MasterCategoriesDataGridView);
            this.Controls.Add(this.guna2Panel2);
            this.Controls.Add(this.guna2Panel1);
            this.Controls.Add(this.guna2Panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "formMasterCategory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "formMasterCategory";
            this.guna2Panel3.ResumeLayout(false);
            this.guna2Panel1.ResumeLayout(false);
            this.guna2Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MasterCategoriesDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private Guna.UI2.WinForms.Guna2Button btnAddBrands;
        private Guna.UI2.WinForms.Guna2Button btnAddVendor;
        private Guna.UI2.WinForms.Guna2Button btnAddThirdCate;
        private Guna.UI2.WinForms.Guna2Button btnAddSecondCate;
        private Guna.UI2.WinForms.Guna2Button btnAddMainCate;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2Button btnRefresh;
        private Guna.UI2.WinForms.Guna2DataGridView MasterCategoriesDataGridView;
    }
}