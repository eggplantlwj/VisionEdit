namespace EyeHandCalibTool
{
    partial class FormEyeHandCalib
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEyeHandCalib));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtRunTool = new System.Windows.Forms.ToolStripButton();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lb_RunStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lb_RunTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.uiGroupBox1 = new Sunny.UI.UIGroupBox();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.chbSelectCalibType = new Sunny.UI.UIComboBox();
            this.uiPanel1 = new Sunny.UI.UIPanel();
            this.CalibDataGrid = new Sunny.UI.UIDataGridView();
            this.btnImportData = new Sunny.UI.UISymbolButton();
            this.btnExportData = new Sunny.UI.UISymbolButton();
            this.uiTabControl1 = new Sunny.UI.UITabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnCalibAuto = new Sunny.UI.UISymbolButton();
            this.btnCalibManual = new Sunny.UI.UISymbolButton();
            this.txbTheta = new Sunny.UI.UITextBox();
            this.txbRatation = new Sunny.UI.UITextBox();
            this.txbScaleY = new Sunny.UI.UITextBox();
            this.txbScaleX = new Sunny.UI.UITextBox();
            this.txbMoveY = new Sunny.UI.UITextBox();
            this.txbMoveX = new Sunny.UI.UITextBox();
            this.uiLabel7 = new Sunny.UI.UILabel();
            this.uiLabel6 = new Sunny.UI.UILabel();
            this.uiLabel5 = new Sunny.UI.UILabel();
            this.uiLabel4 = new Sunny.UI.UILabel();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.toolStrip1.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.uiGroupBox1.SuspendLayout();
            this.uiPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CalibDataGrid)).BeginInit();
            this.uiTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtRunTool});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(823, 32);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtRunTool
            // 
            this.tsbtRunTool.Image = ((System.Drawing.Image)(resources.GetObject("tsbtRunTool.Image")));
            this.tsbtRunTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtRunTool.Name = "tsbtRunTool";
            this.tsbtRunTool.Size = new System.Drawing.Size(85, 29);
            this.tsbtRunTool.Text = "运行工具";
            this.tsbtRunTool.Click += new System.EventHandler(this.tsbtRunTool_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lb_RunStatus,
            this.toolStripStatusLabel1,
            this.lb_RunTime});
            this.statusStrip.Location = new System.Drawing.Point(0, 500);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(823, 22);
            this.statusStrip.TabIndex = 4;
            // 
            // lb_RunStatus
            // 
            this.lb_RunStatus.Name = "lb_RunStatus";
            this.lb_RunStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(16, 17);
            this.toolStripStatusLabel1.Text = "  ";
            // 
            // lb_RunTime
            // 
            this.lb_RunTime.Name = "lb_RunTime";
            this.lb_RunTime.Size = new System.Drawing.Size(0, 17);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 32);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.CalibDataGrid);
            this.splitContainer1.Panel1.Controls.Add(this.uiPanel1);
            this.splitContainer1.Panel1.Controls.Add(this.uiGroupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.uiTabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(823, 468);
            this.splitContainer1.SplitterDistance = 542;
            this.splitContainer1.TabIndex = 6;
            // 
            // uiGroupBox1
            // 
            this.uiGroupBox1.BackColor = System.Drawing.Color.White;
            this.uiGroupBox1.Controls.Add(this.uiLabel1);
            this.uiGroupBox1.Controls.Add(this.chbSelectCalibType);
            this.uiGroupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiGroupBox1.FillColor = System.Drawing.Color.White;
            this.uiGroupBox1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiGroupBox1.IsScaled = false;
            this.uiGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.uiGroupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox1.Name = "uiGroupBox1";
            this.uiGroupBox1.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox1.Size = new System.Drawing.Size(542, 82);
            this.uiGroupBox1.Style = Sunny.UI.UIStyle.Custom;
            this.uiGroupBox1.TabIndex = 26;
            this.uiGroupBox1.Text = "选择标定模式";
            this.uiGroupBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.Location = new System.Drawing.Point(12, 38);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(96, 23);
            this.uiLabel1.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel1.TabIndex = 26;
            this.uiLabel1.Text = "标定类型：";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chbSelectCalibType
            // 
            this.chbSelectCalibType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chbSelectCalibType.DataSource = null;
            this.chbSelectCalibType.FillColor = System.Drawing.Color.White;
            this.chbSelectCalibType.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chbSelectCalibType.IsScaled = false;
            this.chbSelectCalibType.Items.AddRange(new object[] {
            "四点标定",
            "九点标定"});
            this.chbSelectCalibType.Location = new System.Drawing.Point(146, 38);
            this.chbSelectCalibType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chbSelectCalibType.MinimumSize = new System.Drawing.Size(63, 0);
            this.chbSelectCalibType.Name = "chbSelectCalibType";
            this.chbSelectCalibType.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.chbSelectCalibType.Size = new System.Drawing.Size(285, 29);
            this.chbSelectCalibType.Style = Sunny.UI.UIStyle.Custom;
            this.chbSelectCalibType.TabIndex = 25;
            this.chbSelectCalibType.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.chbSelectCalibType.SelectedIndexChanged += new System.EventHandler(this.chbSelectCalibType_SelectedIndexChanged);
            // 
            // uiPanel1
            // 
            this.uiPanel1.Controls.Add(this.btnExportData);
            this.uiPanel1.Controls.Add(this.btnImportData);
            this.uiPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.uiPanel1.FillColor = System.Drawing.Color.White;
            this.uiPanel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiPanel1.IsScaled = false;
            this.uiPanel1.Location = new System.Drawing.Point(0, 418);
            this.uiPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiPanel1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiPanel1.Name = "uiPanel1";
            this.uiPanel1.Size = new System.Drawing.Size(542, 50);
            this.uiPanel1.Style = Sunny.UI.UIStyle.Custom;
            this.uiPanel1.TabIndex = 27;
            this.uiPanel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CalibDataGrid
            // 
            this.CalibDataGrid.AllowUserToAddRows = false;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.CalibDataGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.CalibDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.CalibDataGrid.BackgroundColor = System.Drawing.Color.White;
            this.CalibDataGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.CalibDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.CalibDataGrid.ColumnHeadersHeight = 32;
            this.CalibDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.CalibDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CalibDataGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.CalibDataGrid.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CalibDataGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            this.CalibDataGrid.Location = new System.Drawing.Point(0, 82);
            this.CalibDataGrid.Name = "CalibDataGrid";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.CalibDataGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            dataGridViewCellStyle12.BackColor = System.Drawing.Color.White;
            this.CalibDataGrid.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.CalibDataGrid.RowTemplate.Height = 23;
            this.CalibDataGrid.SelectedIndex = -1;
            this.CalibDataGrid.ShowGridLine = true;
            this.CalibDataGrid.Size = new System.Drawing.Size(542, 336);
            this.CalibDataGrid.TabIndex = 28;
            this.CalibDataGrid.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.CalibDataGrid_RowPostPaint);
            // 
            // btnImportData
            // 
            this.btnImportData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImportData.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnImportData.IsScaled = false;
            this.btnImportData.Location = new System.Drawing.Point(86, 6);
            this.btnImportData.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnImportData.Name = "btnImportData";
            this.btnImportData.Size = new System.Drawing.Size(114, 35);
            this.btnImportData.Style = Sunny.UI.UIStyle.Custom;
            this.btnImportData.Symbol = 61568;
            this.btnImportData.TabIndex = 0;
            this.btnImportData.Text = "数据导入";
            this.btnImportData.Click += new System.EventHandler(this.btnImportData_Click);
            // 
            // btnExportData
            // 
            this.btnExportData.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportData.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExportData.IsScaled = false;
            this.btnExportData.Location = new System.Drawing.Point(273, 6);
            this.btnExportData.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnExportData.Name = "btnExportData";
            this.btnExportData.Size = new System.Drawing.Size(114, 35);
            this.btnExportData.Style = Sunny.UI.UIStyle.Custom;
            this.btnExportData.Symbol = 61584;
            this.btnExportData.TabIndex = 0;
            this.btnExportData.Text = "数据导出";
            this.btnExportData.Click += new System.EventHandler(this.btnExportData_Click);
            // 
            // uiTabControl1
            // 
            this.uiTabControl1.Controls.Add(this.tabPage1);
            this.uiTabControl1.Controls.Add(this.tabPage2);
            this.uiTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.uiTabControl1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTabControl1.ItemSize = new System.Drawing.Size(100, 40);
            this.uiTabControl1.Location = new System.Drawing.Point(0, 0);
            this.uiTabControl1.MainPage = "";
            this.uiTabControl1.Name = "uiTabControl1";
            this.uiTabControl1.SelectedIndex = 0;
            this.uiTabControl1.Size = new System.Drawing.Size(277, 468);
            this.uiTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.uiTabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.btnCalibAuto);
            this.tabPage1.Controls.Add(this.btnCalibManual);
            this.tabPage1.Controls.Add(this.txbTheta);
            this.tabPage1.Controls.Add(this.txbRatation);
            this.tabPage1.Controls.Add(this.txbScaleY);
            this.tabPage1.Controls.Add(this.txbScaleX);
            this.tabPage1.Controls.Add(this.txbMoveY);
            this.tabPage1.Controls.Add(this.txbMoveX);
            this.tabPage1.Controls.Add(this.uiLabel7);
            this.tabPage1.Controls.Add(this.uiLabel6);
            this.tabPage1.Controls.Add(this.uiLabel5);
            this.tabPage1.Controls.Add(this.uiLabel4);
            this.tabPage1.Controls.Add(this.uiLabel3);
            this.tabPage1.Controls.Add(this.uiLabel2);
            this.tabPage1.Location = new System.Drawing.Point(0, 40);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(277, 428);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "标定结果";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(0, 40);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(277, 428);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "转换结果";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnCalibAuto
            // 
            this.btnCalibAuto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCalibAuto.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCalibAuto.IsScaled = false;
            this.btnCalibAuto.Location = new System.Drawing.Point(151, 352);
            this.btnCalibAuto.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnCalibAuto.Name = "btnCalibAuto";
            this.btnCalibAuto.Size = new System.Drawing.Size(103, 35);
            this.btnCalibAuto.Style = Sunny.UI.UIStyle.Custom;
            this.btnCalibAuto.Symbol = 261778;
            this.btnCalibAuto.TabIndex = 15;
            this.btnCalibAuto.Text = "自动标定";
            // 
            // btnCalibManual
            // 
            this.btnCalibManual.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCalibManual.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCalibManual.IsScaled = false;
            this.btnCalibManual.Location = new System.Drawing.Point(23, 352);
            this.btnCalibManual.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnCalibManual.Name = "btnCalibManual";
            this.btnCalibManual.Size = new System.Drawing.Size(103, 35);
            this.btnCalibManual.Style = Sunny.UI.UIStyle.Custom;
            this.btnCalibManual.Symbol = 363128;
            this.btnCalibManual.TabIndex = 16;
            this.btnCalibManual.Text = "手动标定";
            this.btnCalibManual.Click += new System.EventHandler(this.btnCalibManual_Click);
            // 
            // txbTheta
            // 
            this.txbTheta.ButtonSymbol = 61761;
            this.txbTheta.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbTheta.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txbTheta.IsScaled = false;
            this.txbTheta.Location = new System.Drawing.Point(104, 292);
            this.txbTheta.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txbTheta.Maximum = 2147483647D;
            this.txbTheta.Minimum = -2147483648D;
            this.txbTheta.MinimumSize = new System.Drawing.Size(1, 16);
            this.txbTheta.Name = "txbTheta";
            this.txbTheta.Size = new System.Drawing.Size(150, 29);
            this.txbTheta.Style = Sunny.UI.UIStyle.Custom;
            this.txbTheta.TabIndex = 9;
            this.txbTheta.Text = "0";
            this.txbTheta.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txbRatation
            // 
            this.txbRatation.ButtonSymbol = 61761;
            this.txbRatation.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbRatation.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txbRatation.IsScaled = false;
            this.txbRatation.Location = new System.Drawing.Point(104, 242);
            this.txbRatation.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txbRatation.Maximum = 2147483647D;
            this.txbRatation.Minimum = -2147483648D;
            this.txbRatation.MinimumSize = new System.Drawing.Size(1, 16);
            this.txbRatation.Name = "txbRatation";
            this.txbRatation.Size = new System.Drawing.Size(150, 29);
            this.txbRatation.Style = Sunny.UI.UIStyle.Custom;
            this.txbRatation.TabIndex = 10;
            this.txbRatation.Text = "0";
            this.txbRatation.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txbScaleY
            // 
            this.txbScaleY.ButtonSymbol = 61761;
            this.txbScaleY.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbScaleY.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txbScaleY.IsScaled = false;
            this.txbScaleY.Location = new System.Drawing.Point(104, 192);
            this.txbScaleY.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txbScaleY.Maximum = 2147483647D;
            this.txbScaleY.Minimum = -2147483648D;
            this.txbScaleY.MinimumSize = new System.Drawing.Size(1, 16);
            this.txbScaleY.Name = "txbScaleY";
            this.txbScaleY.Size = new System.Drawing.Size(150, 29);
            this.txbScaleY.Style = Sunny.UI.UIStyle.Custom;
            this.txbScaleY.TabIndex = 11;
            this.txbScaleY.Text = "0";
            this.txbScaleY.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txbScaleX
            // 
            this.txbScaleX.ButtonSymbol = 61761;
            this.txbScaleX.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbScaleX.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txbScaleX.IsScaled = false;
            this.txbScaleX.Location = new System.Drawing.Point(104, 142);
            this.txbScaleX.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txbScaleX.Maximum = 2147483647D;
            this.txbScaleX.Minimum = -2147483648D;
            this.txbScaleX.MinimumSize = new System.Drawing.Size(1, 16);
            this.txbScaleX.Name = "txbScaleX";
            this.txbScaleX.Size = new System.Drawing.Size(150, 29);
            this.txbScaleX.Style = Sunny.UI.UIStyle.Custom;
            this.txbScaleX.TabIndex = 12;
            this.txbScaleX.Text = "0";
            this.txbScaleX.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txbMoveY
            // 
            this.txbMoveY.ButtonSymbol = 61761;
            this.txbMoveY.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbMoveY.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txbMoveY.IsScaled = false;
            this.txbMoveY.Location = new System.Drawing.Point(104, 92);
            this.txbMoveY.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txbMoveY.Maximum = 2147483647D;
            this.txbMoveY.Minimum = -2147483648D;
            this.txbMoveY.MinimumSize = new System.Drawing.Size(1, 16);
            this.txbMoveY.Name = "txbMoveY";
            this.txbMoveY.Size = new System.Drawing.Size(150, 29);
            this.txbMoveY.Style = Sunny.UI.UIStyle.Custom;
            this.txbMoveY.TabIndex = 13;
            this.txbMoveY.Text = "0";
            this.txbMoveY.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txbMoveX
            // 
            this.txbMoveX.ButtonSymbol = 61761;
            this.txbMoveX.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbMoveX.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txbMoveX.IsScaled = false;
            this.txbMoveX.Location = new System.Drawing.Point(104, 42);
            this.txbMoveX.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txbMoveX.Maximum = 2147483647D;
            this.txbMoveX.Minimum = -2147483648D;
            this.txbMoveX.MinimumSize = new System.Drawing.Size(1, 16);
            this.txbMoveX.Name = "txbMoveX";
            this.txbMoveX.Size = new System.Drawing.Size(150, 29);
            this.txbMoveX.Style = Sunny.UI.UIStyle.Custom;
            this.txbMoveX.TabIndex = 14;
            this.txbMoveX.Text = "0";
            this.txbMoveX.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel7
            // 
            this.uiLabel7.BackColor = System.Drawing.Color.White;
            this.uiLabel7.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel7.Location = new System.Drawing.Point(24, 292);
            this.uiLabel7.Name = "uiLabel7";
            this.uiLabel7.Size = new System.Drawing.Size(73, 23);
            this.uiLabel7.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel7.TabIndex = 3;
            this.uiLabel7.Text = "斜切：";
            this.uiLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel6
            // 
            this.uiLabel6.BackColor = System.Drawing.Color.White;
            this.uiLabel6.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel6.Location = new System.Drawing.Point(24, 242);
            this.uiLabel6.Name = "uiLabel6";
            this.uiLabel6.Size = new System.Drawing.Size(73, 23);
            this.uiLabel6.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel6.TabIndex = 4;
            this.uiLabel6.Text = "旋转：";
            this.uiLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel5
            // 
            this.uiLabel5.BackColor = System.Drawing.Color.White;
            this.uiLabel5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel5.Location = new System.Drawing.Point(24, 192);
            this.uiLabel5.Name = "uiLabel5";
            this.uiLabel5.Size = new System.Drawing.Size(73, 23);
            this.uiLabel5.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel5.TabIndex = 5;
            this.uiLabel5.Text = "缩放Y：";
            this.uiLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel4
            // 
            this.uiLabel4.BackColor = System.Drawing.Color.White;
            this.uiLabel4.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel4.Location = new System.Drawing.Point(24, 142);
            this.uiLabel4.Name = "uiLabel4";
            this.uiLabel4.Size = new System.Drawing.Size(73, 23);
            this.uiLabel4.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel4.TabIndex = 6;
            this.uiLabel4.Text = "缩放X：";
            this.uiLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel3
            // 
            this.uiLabel3.BackColor = System.Drawing.Color.White;
            this.uiLabel3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel3.Location = new System.Drawing.Point(24, 92);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(73, 23);
            this.uiLabel3.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel3.TabIndex = 7;
            this.uiLabel3.Text = "平移Y：";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiLabel2
            // 
            this.uiLabel2.BackColor = System.Drawing.Color.White;
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel2.Location = new System.Drawing.Point(24, 42);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(73, 23);
            this.uiLabel2.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel2.TabIndex = 8;
            this.uiLabel2.Text = "平移X：";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FormEyeHandCalib
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 522);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormEyeHandCalib";
            this.Text = "手眼标定工具";
            this.Load += new System.EventHandler(this.FormEyeHandCalib_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.uiGroupBox1.ResumeLayout(false);
            this.uiPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CalibDataGrid)).EndInit();
            this.uiTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtRunTool;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lb_RunStatus;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lb_RunTime;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Sunny.UI.UIComboBox chbSelectCalibType;
        private Sunny.UI.UIGroupBox uiGroupBox1;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UIDataGridView CalibDataGrid;
        private Sunny.UI.UIPanel uiPanel1;
        private Sunny.UI.UISymbolButton btnExportData;
        private Sunny.UI.UISymbolButton btnImportData;
        private Sunny.UI.UITabControl uiTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private Sunny.UI.UISymbolButton btnCalibAuto;
        private Sunny.UI.UISymbolButton btnCalibManual;
        private Sunny.UI.UITextBox txbTheta;
        private Sunny.UI.UITextBox txbRatation;
        private Sunny.UI.UITextBox txbScaleY;
        public Sunny.UI.UITextBox txbScaleX;
        public Sunny.UI.UITextBox txbMoveY;
        public Sunny.UI.UITextBox txbMoveX;
        private Sunny.UI.UILabel uiLabel7;
        private Sunny.UI.UILabel uiLabel6;
        private Sunny.UI.UILabel uiLabel5;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UILabel uiLabel2;
    }
}