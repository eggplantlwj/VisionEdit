namespace HalconTool
{
    partial class FormHalconTool
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHalconTool));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.superTabControl1 = new DevComponents.DotNetBar.SuperTabControl();
            this.superTabControlPanel1 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.txbLog = new System.Windows.Forms.TextBox();
            this.panelMultImage = new System.Windows.Forms.Panel();
            this.gpb_multImage = new System.Windows.Forms.GroupBox();
            this.btn_selectImageDirectory = new System.Windows.Forms.Button();
            this.lbl_imageNum = new System.Windows.Forms.Label();
            this.lbl_imageName = new System.Windows.Forms.Label();
            this.btn_lastImage = new System.Windows.Forms.Button();
            this.btn_nextImage = new System.Windows.Forms.Button();
            this.tbx_imageDirectory = new System.Windows.Forms.TextBox();
            this.panelOneImage = new System.Windows.Forms.Panel();
            this.gpb_oneImage = new System.Windows.Forms.GroupBox();
            this.btn_readImage = new System.Windows.Forms.Button();
            this.tbx_imagePath = new System.Windows.Forms.TextBox();
            this.btn_browseImage = new System.Windows.Forms.Button();
            this.ckb_autoSwitch = new System.Windows.Forms.CheckBox();
            this.btn_runHalconInterfaceTool = new System.Windows.Forms.Button();
            this.btn_registImage = new System.Windows.Forms.Button();
            this.rdo_readOneImage = new System.Windows.Forms.RadioButton();
            this.rdo_readMultImage = new System.Windows.Forms.RadioButton();
            this.ckb_RGBToGray = new System.Windows.Forms.CheckBox();
            this.tabReadFormLocal = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel2 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btn_RealTime = new System.Windows.Forms.Button();
            this.cbx_deviceList = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label148 = new System.Windows.Forms.Label();
            this.tbx_exposure = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label147 = new System.Windows.Forms.Label();
            this.btn_saveImage = new System.Windows.Forms.Button();
            this.label123 = new System.Windows.Forms.Label();
            this.tabReadFormCamera = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControl2 = new DevComponents.DotNetBar.SuperTabControl();
            this.imageDispPanel = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.superTabItem1 = new DevComponents.DotNetBar.SuperTabItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).BeginInit();
            this.superTabControl1.SuspendLayout();
            this.superTabControlPanel1.SuspendLayout();
            this.panelMultImage.SuspendLayout();
            this.gpb_multImage.SuspendLayout();
            this.panelOneImage.SuspendLayout();
            this.gpb_oneImage.SuspendLayout();
            this.superTabControlPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl2)).BeginInit();
            this.superTabControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.superTabControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.superTabControl2);
            this.splitContainer1.Size = new System.Drawing.Size(1111, 477);
            this.splitContainer1.SplitterDistance = 590;
            this.splitContainer1.TabIndex = 1;
            // 
            // superTabControl1
            // 
            this.superTabControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            // 
            // 
            // 
            // 
            // 
            // 
            this.superTabControl1.ControlBox.CloseBox.Name = "";
            // 
            // 
            // 
            this.superTabControl1.ControlBox.MenuBox.Name = "";
            this.superTabControl1.ControlBox.Name = "";
            this.superTabControl1.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabControl1.ControlBox.MenuBox,
            this.superTabControl1.ControlBox.CloseBox});
            this.superTabControl1.Controls.Add(this.superTabControlPanel1);
            this.superTabControl1.Controls.Add(this.superTabControlPanel2);
            this.superTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControl1.ForeColor = System.Drawing.Color.Black;
            this.superTabControl1.Location = new System.Drawing.Point(0, 0);
            this.superTabControl1.Name = "superTabControl1";
            this.superTabControl1.ReorderTabsEnabled = true;
            this.superTabControl1.SelectedTabFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.superTabControl1.SelectedTabIndex = 0;
            this.superTabControl1.Size = new System.Drawing.Size(590, 477);
            this.superTabControl1.TabFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.superTabControl1.TabIndex = 1;
            this.superTabControl1.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.tabReadFormLocal,
            this.tabReadFormCamera});
            this.superTabControl1.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.OfficeMobile2014;
            this.superTabControl1.Text = "superTabControl1";
            // 
            // superTabControlPanel1
            // 
            this.superTabControlPanel1.Controls.Add(this.txbLog);
            this.superTabControlPanel1.Controls.Add(this.panelMultImage);
            this.superTabControlPanel1.Controls.Add(this.panelOneImage);
            this.superTabControlPanel1.Controls.Add(this.btn_browseImage);
            this.superTabControlPanel1.Controls.Add(this.ckb_autoSwitch);
            this.superTabControlPanel1.Controls.Add(this.btn_runHalconInterfaceTool);
            this.superTabControlPanel1.Controls.Add(this.btn_registImage);
            this.superTabControlPanel1.Controls.Add(this.rdo_readOneImage);
            this.superTabControlPanel1.Controls.Add(this.rdo_readMultImage);
            this.superTabControlPanel1.Controls.Add(this.ckb_RGBToGray);
            this.superTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel1.Location = new System.Drawing.Point(0, 36);
            this.superTabControlPanel1.Name = "superTabControlPanel1";
            this.superTabControlPanel1.Size = new System.Drawing.Size(590, 441);
            this.superTabControlPanel1.TabIndex = 1;
            this.superTabControlPanel1.TabItem = this.tabReadFormLocal;
            // 
            // txbLog
            // 
            this.txbLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbLog.Location = new System.Drawing.Point(3, 420);
            this.txbLog.Name = "txbLog";
            this.txbLog.Size = new System.Drawing.Size(585, 21);
            this.txbLog.TabIndex = 93;
            // 
            // panelMultImage
            // 
            this.panelMultImage.BackColor = System.Drawing.Color.White;
            this.panelMultImage.Controls.Add(this.gpb_multImage);
            this.panelMultImage.Location = new System.Drawing.Point(77, 69);
            this.panelMultImage.Name = "panelMultImage";
            this.panelMultImage.Size = new System.Drawing.Size(462, 182);
            this.panelMultImage.TabIndex = 92;
            // 
            // gpb_multImage
            // 
            this.gpb_multImage.Controls.Add(this.btn_selectImageDirectory);
            this.gpb_multImage.Controls.Add(this.lbl_imageNum);
            this.gpb_multImage.Controls.Add(this.lbl_imageName);
            this.gpb_multImage.Controls.Add(this.btn_lastImage);
            this.gpb_multImage.Controls.Add(this.btn_nextImage);
            this.gpb_multImage.Controls.Add(this.tbx_imageDirectory);
            this.gpb_multImage.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gpb_multImage.Location = new System.Drawing.Point(6, 4);
            this.gpb_multImage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gpb_multImage.Name = "gpb_multImage";
            this.gpb_multImage.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gpb_multImage.Size = new System.Drawing.Size(451, 170);
            this.gpb_multImage.TabIndex = 15;
            this.gpb_multImage.TabStop = false;
            this.gpb_multImage.Text = "图像文件夹路径";
            // 
            // btn_selectImageDirectory
            // 
            this.btn_selectImageDirectory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_selectImageDirectory.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_selectImageDirectory.Location = new System.Drawing.Point(18, 99);
            this.btn_selectImageDirectory.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_selectImageDirectory.Name = "btn_selectImageDirectory";
            this.btn_selectImageDirectory.Size = new System.Drawing.Size(98, 32);
            this.btn_selectImageDirectory.TabIndex = 63;
            this.btn_selectImageDirectory.Text = "选择路径";
            this.btn_selectImageDirectory.UseVisualStyleBackColor = true;
            this.btn_selectImageDirectory.Click += new System.EventHandler(this.btn_selectImageDirectory_Click);
            // 
            // lbl_imageNum
            // 
            this.lbl_imageNum.AutoSize = true;
            this.lbl_imageNum.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_imageNum.Location = new System.Drawing.Point(386, 70);
            this.lbl_imageNum.Name = "lbl_imageNum";
            this.lbl_imageNum.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbl_imageNum.Size = new System.Drawing.Size(39, 17);
            this.lbl_imageNum.TabIndex = 62;
            this.lbl_imageNum.Text = "共0张";
            this.lbl_imageNum.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbl_imageName
            // 
            this.lbl_imageName.AutoSize = true;
            this.lbl_imageName.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_imageName.Location = new System.Drawing.Point(15, 70);
            this.lbl_imageName.Name = "lbl_imageName";
            this.lbl_imageName.Size = new System.Drawing.Size(0, 17);
            this.lbl_imageName.TabIndex = 61;
            // 
            // btn_lastImage
            // 
            this.btn_lastImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_lastImage.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_lastImage.Location = new System.Drawing.Point(339, 99);
            this.btn_lastImage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_lastImage.Name = "btn_lastImage";
            this.btn_lastImage.Size = new System.Drawing.Size(33, 32);
            this.btn_lastImage.TabIndex = 9;
            this.btn_lastImage.TabStop = false;
            this.btn_lastImage.Text = "<<";
            this.btn_lastImage.UseVisualStyleBackColor = true;
            this.btn_lastImage.Click += new System.EventHandler(this.btn_nextImage_Click);
            // 
            // btn_nextImage
            // 
            this.btn_nextImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_nextImage.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_nextImage.Location = new System.Drawing.Point(375, 99);
            this.btn_nextImage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_nextImage.Name = "btn_nextImage";
            this.btn_nextImage.Size = new System.Drawing.Size(33, 32);
            this.btn_nextImage.TabIndex = 8;
            this.btn_nextImage.TabStop = false;
            this.btn_nextImage.Text = ">>";
            this.btn_nextImage.UseVisualStyleBackColor = true;
            this.btn_nextImage.Click += new System.EventHandler(this.btn_nextImage_Click);
            // 
            // tbx_imageDirectory
            // 
            this.tbx_imageDirectory.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_imageDirectory.Location = new System.Drawing.Point(18, 28);
            this.tbx_imageDirectory.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbx_imageDirectory.Multiline = true;
            this.tbx_imageDirectory.Name = "tbx_imageDirectory";
            this.tbx_imageDirectory.Size = new System.Drawing.Size(415, 38);
            this.tbx_imageDirectory.TabIndex = 5;
            // 
            // panelOneImage
            // 
            this.panelOneImage.BackColor = System.Drawing.Color.White;
            this.panelOneImage.Controls.Add(this.gpb_oneImage);
            this.panelOneImage.Location = new System.Drawing.Point(79, 69);
            this.panelOneImage.Name = "panelOneImage";
            this.panelOneImage.Size = new System.Drawing.Size(460, 176);
            this.panelOneImage.TabIndex = 91;
            // 
            // gpb_oneImage
            // 
            this.gpb_oneImage.BackColor = System.Drawing.Color.White;
            this.gpb_oneImage.Controls.Add(this.btn_readImage);
            this.gpb_oneImage.Controls.Add(this.tbx_imagePath);
            this.gpb_oneImage.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gpb_oneImage.Location = new System.Drawing.Point(9, 10);
            this.gpb_oneImage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gpb_oneImage.Name = "gpb_oneImage";
            this.gpb_oneImage.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gpb_oneImage.Size = new System.Drawing.Size(440, 153);
            this.gpb_oneImage.TabIndex = 83;
            this.gpb_oneImage.TabStop = false;
            this.gpb_oneImage.Text = "图像路径";
            // 
            // btn_readImage
            // 
            this.btn_readImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_readImage.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_readImage.Location = new System.Drawing.Point(21, 95);
            this.btn_readImage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_readImage.Name = "btn_readImage";
            this.btn_readImage.Size = new System.Drawing.Size(85, 32);
            this.btn_readImage.TabIndex = 3;
            this.btn_readImage.Text = "加载";
            this.btn_readImage.UseVisualStyleBackColor = true;
            this.btn_readImage.Click += new System.EventHandler(this.btn_readImage_Click);
            // 
            // tbx_imagePath
            // 
            this.tbx_imagePath.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_imagePath.Location = new System.Drawing.Point(18, 28);
            this.tbx_imagePath.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbx_imagePath.Name = "tbx_imagePath";
            this.tbx_imagePath.Size = new System.Drawing.Size(415, 23);
            this.tbx_imagePath.TabIndex = 1;
            // 
            // btn_browseImage
            // 
            this.btn_browseImage.BackColor = System.Drawing.Color.White;
            this.btn_browseImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_browseImage.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_browseImage.Location = new System.Drawing.Point(156, 357);
            this.btn_browseImage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_browseImage.Name = "btn_browseImage";
            this.btn_browseImage.Size = new System.Drawing.Size(76, 26);
            this.btn_browseImage.TabIndex = 90;
            this.btn_browseImage.Text = "查看图像";
            this.btn_browseImage.UseVisualStyleBackColor = false;
            // 
            // ckb_autoSwitch
            // 
            this.ckb_autoSwitch.AutoSize = true;
            this.ckb_autoSwitch.BackColor = System.Drawing.Color.White;
            this.ckb_autoSwitch.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_autoSwitch.Location = new System.Drawing.Point(74, 322);
            this.ckb_autoSwitch.Margin = new System.Windows.Forms.Padding(2);
            this.ckb_autoSwitch.Name = "ckb_autoSwitch";
            this.ckb_autoSwitch.Size = new System.Drawing.Size(99, 21);
            this.ckb_autoSwitch.TabIndex = 82;
            this.ckb_autoSwitch.Text = "图像自动切换";
            this.ckb_autoSwitch.UseVisualStyleBackColor = false;
            // 
            // btn_runHalconInterfaceTool
            // 
            this.btn_runHalconInterfaceTool.BackColor = System.Drawing.Color.White;
            this.btn_runHalconInterfaceTool.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_runHalconInterfaceTool.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_runHalconInterfaceTool.Location = new System.Drawing.Point(436, 348);
            this.btn_runHalconInterfaceTool.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_runHalconInterfaceTool.Name = "btn_runHalconInterfaceTool";
            this.btn_runHalconInterfaceTool.Size = new System.Drawing.Size(98, 45);
            this.btn_runHalconInterfaceTool.TabIndex = 88;
            this.btn_runHalconInterfaceTool.TabStop = false;
            this.btn_runHalconInterfaceTool.Text = "运行";
            this.btn_runHalconInterfaceTool.UseVisualStyleBackColor = false;
            this.btn_runHalconInterfaceTool.Click += new System.EventHandler(this.btn_runHalconInterfaceTool_Click);
            // 
            // btn_registImage
            // 
            this.btn_registImage.BackColor = System.Drawing.Color.White;
            this.btn_registImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_registImage.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_registImage.Location = new System.Drawing.Point(74, 357);
            this.btn_registImage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_registImage.Name = "btn_registImage";
            this.btn_registImage.Size = new System.Drawing.Size(76, 26);
            this.btn_registImage.TabIndex = 84;
            this.btn_registImage.Text = "注册图像";
            this.btn_registImage.UseVisualStyleBackColor = false;
            // 
            // rdo_readOneImage
            // 
            this.rdo_readOneImage.AutoSize = true;
            this.rdo_readOneImage.BackColor = System.Drawing.Color.White;
            this.rdo_readOneImage.Checked = true;
            this.rdo_readOneImage.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdo_readOneImage.Location = new System.Drawing.Point(365, 25);
            this.rdo_readOneImage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdo_readOneImage.Name = "rdo_readOneImage";
            this.rdo_readOneImage.Size = new System.Drawing.Size(74, 21);
            this.rdo_readOneImage.TabIndex = 86;
            this.rdo_readOneImage.TabStop = true;
            this.rdo_readOneImage.Text = "单张图像";
            this.rdo_readOneImage.UseVisualStyleBackColor = false;
            this.rdo_readOneImage.Click += new System.EventHandler(this.rdo_readMultImage_CheckedChanged);
            // 
            // rdo_readMultImage
            // 
            this.rdo_readMultImage.AutoSize = true;
            this.rdo_readMultImage.BackColor = System.Drawing.Color.White;
            this.rdo_readMultImage.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rdo_readMultImage.Location = new System.Drawing.Point(139, 25);
            this.rdo_readMultImage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdo_readMultImage.Name = "rdo_readMultImage";
            this.rdo_readMultImage.Size = new System.Drawing.Size(74, 21);
            this.rdo_readMultImage.TabIndex = 85;
            this.rdo_readMultImage.Text = "多张图像";
            this.rdo_readMultImage.UseVisualStyleBackColor = false;
            this.rdo_readMultImage.Click += new System.EventHandler(this.rdo_readMultImage_CheckedChanged);
            // 
            // ckb_RGBToGray
            // 
            this.ckb_RGBToGray.AutoSize = true;
            this.ckb_RGBToGray.BackColor = System.Drawing.Color.White;
            this.ckb_RGBToGray.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ckb_RGBToGray.Location = new System.Drawing.Point(74, 297);
            this.ckb_RGBToGray.Margin = new System.Windows.Forms.Padding(2);
            this.ckb_RGBToGray.Name = "ckb_RGBToGray";
            this.ckb_RGBToGray.Size = new System.Drawing.Size(99, 21);
            this.ckb_RGBToGray.TabIndex = 89;
            this.ckb_RGBToGray.Text = "彩图转灰度图";
            this.ckb_RGBToGray.UseVisualStyleBackColor = false;
            // 
            // tabReadFormLocal
            // 
            this.tabReadFormLocal.AttachedControl = this.superTabControlPanel1;
            this.tabReadFormLocal.GlobalItem = false;
            this.tabReadFormLocal.Name = "tabReadFormLocal";
            this.tabReadFormLocal.Text = "本地读取";
            // 
            // superTabControlPanel2
            // 
            this.superTabControlPanel2.Controls.Add(this.checkBox1);
            this.superTabControlPanel2.Controls.Add(this.btn_RealTime);
            this.superTabControlPanel2.Controls.Add(this.cbx_deviceList);
            this.superTabControlPanel2.Controls.Add(this.button1);
            this.superTabControlPanel2.Controls.Add(this.label148);
            this.superTabControlPanel2.Controls.Add(this.tbx_exposure);
            this.superTabControlPanel2.Controls.Add(this.button2);
            this.superTabControlPanel2.Controls.Add(this.label147);
            this.superTabControlPanel2.Controls.Add(this.btn_saveImage);
            this.superTabControlPanel2.Controls.Add(this.label123);
            this.superTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel2.Location = new System.Drawing.Point(0, 36);
            this.superTabControlPanel2.Name = "superTabControlPanel2";
            this.superTabControlPanel2.Size = new System.Drawing.Size(590, 441);
            this.superTabControlPanel2.TabIndex = 0;
            this.superTabControlPanel2.TabItem = this.tabReadFormCamera;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = System.Drawing.Color.White;
            this.checkBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox1.Location = new System.Drawing.Point(46, 164);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(99, 21);
            this.checkBox1.TabIndex = 113;
            this.checkBox1.Text = "彩图转灰度图";
            this.checkBox1.UseVisualStyleBackColor = false;
            // 
            // btn_RealTime
            // 
            this.btn_RealTime.BackColor = System.Drawing.Color.White;
            this.btn_RealTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_RealTime.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_RealTime.Location = new System.Drawing.Point(150, 200);
            this.btn_RealTime.Margin = new System.Windows.Forms.Padding(2);
            this.btn_RealTime.Name = "btn_RealTime";
            this.btn_RealTime.Size = new System.Drawing.Size(76, 26);
            this.btn_RealTime.TabIndex = 110;
            this.btn_RealTime.Text = "实时显示";
            this.btn_RealTime.UseVisualStyleBackColor = false;
            // 
            // cbx_deviceList
            // 
            this.cbx_deviceList.BackColor = System.Drawing.Color.Gainsboro;
            this.cbx_deviceList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_deviceList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbx_deviceList.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbx_deviceList.FormattingEnabled = true;
            this.cbx_deviceList.Items.AddRange(new object[] {
            ""});
            this.cbx_deviceList.Location = new System.Drawing.Point(49, 61);
            this.cbx_deviceList.Margin = new System.Windows.Forms.Padding(2);
            this.cbx_deviceList.Name = "cbx_deviceList";
            this.cbx_deviceList.Size = new System.Drawing.Size(522, 25);
            this.cbx_deviceList.TabIndex = 104;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(460, 288);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 45);
            this.button1.TabIndex = 109;
            this.button1.Text = "运行";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // label148
            // 
            this.label148.AutoSize = true;
            this.label148.BackColor = System.Drawing.Color.White;
            this.label148.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label148.Location = new System.Drawing.Point(170, 107);
            this.label148.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label148.Name = "label148";
            this.label148.Size = new System.Drawing.Size(25, 17);
            this.label148.TabIndex = 107;
            this.label148.Text = "ms";
            // 
            // tbx_exposure
            // 
            this.tbx_exposure.BackColor = System.Drawing.Color.White;
            this.tbx_exposure.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_exposure.Location = new System.Drawing.Point(109, 103);
            this.tbx_exposure.Margin = new System.Windows.Forms.Padding(2);
            this.tbx_exposure.Name = "tbx_exposure";
            this.tbx_exposure.Size = new System.Drawing.Size(61, 23);
            this.tbx_exposure.TabIndex = 106;
            this.tbx_exposure.Text = "0";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(46, 200);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(76, 26);
            this.button2.TabIndex = 112;
            this.button2.Text = "注册图像";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // label147
            // 
            this.label147.AutoSize = true;
            this.label147.BackColor = System.Drawing.Color.White;
            this.label147.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label147.Location = new System.Drawing.Point(46, 106);
            this.label147.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label147.Name = "label147";
            this.label147.Size = new System.Drawing.Size(68, 17);
            this.label147.TabIndex = 105;
            this.label147.Text = "曝光时间：";
            // 
            // btn_saveImage
            // 
            this.btn_saveImage.BackColor = System.Drawing.Color.White;
            this.btn_saveImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_saveImage.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_saveImage.Location = new System.Drawing.Point(248, 200);
            this.btn_saveImage.Margin = new System.Windows.Forms.Padding(2);
            this.btn_saveImage.Name = "btn_saveImage";
            this.btn_saveImage.Size = new System.Drawing.Size(76, 26);
            this.btn_saveImage.TabIndex = 111;
            this.btn_saveImage.Text = "图像另存";
            this.btn_saveImage.UseVisualStyleBackColor = false;
            // 
            // label123
            // 
            this.label123.AutoSize = true;
            this.label123.BackColor = System.Drawing.Color.White;
            this.label123.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label123.Location = new System.Drawing.Point(46, 42);
            this.label123.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label123.Name = "label123";
            this.label123.Size = new System.Drawing.Size(56, 17);
            this.label123.TabIndex = 108;
            this.label123.Text = "设备列表";
            // 
            // tabReadFormCamera
            // 
            this.tabReadFormCamera.AttachedControl = this.superTabControlPanel2;
            this.tabReadFormCamera.GlobalItem = false;
            this.tabReadFormCamera.Name = "tabReadFormCamera";
            this.tabReadFormCamera.Text = "相机读取";
            // 
            // superTabControl2
            // 
            this.superTabControl2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(242)))));
            // 
            // 
            // 
            // 
            // 
            // 
            this.superTabControl2.ControlBox.CloseBox.Name = "";
            // 
            // 
            // 
            this.superTabControl2.ControlBox.MenuBox.Name = "";
            this.superTabControl2.ControlBox.Name = "";
            this.superTabControl2.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabControl2.ControlBox.MenuBox,
            this.superTabControl2.ControlBox.CloseBox});
            this.superTabControl2.Controls.Add(this.imageDispPanel);
            this.superTabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControl2.ForeColor = System.Drawing.Color.Black;
            this.superTabControl2.Location = new System.Drawing.Point(0, 0);
            this.superTabControl2.Name = "superTabControl2";
            this.superTabControl2.ReorderTabsEnabled = true;
            this.superTabControl2.SelectedTabFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold);
            this.superTabControl2.SelectedTabIndex = 0;
            this.superTabControl2.Size = new System.Drawing.Size(517, 477);
            this.superTabControl2.TabFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.superTabControl2.TabIndex = 0;
            this.superTabControl2.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabItem1});
            this.superTabControl2.TabStyle = DevComponents.DotNetBar.eSuperTabStyle.OfficeMobile2014;
            this.superTabControl2.Text = "显示图像";
            // 
            // imageDispPanel
            // 
            this.imageDispPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageDispPanel.Location = new System.Drawing.Point(0, 36);
            this.imageDispPanel.Name = "imageDispPanel";
            this.imageDispPanel.Size = new System.Drawing.Size(517, 441);
            this.imageDispPanel.TabIndex = 1;
            this.imageDispPanel.TabItem = this.superTabItem1;
            // 
            // superTabItem1
            // 
            this.superTabItem1.AttachedControl = this.imageDispPanel;
            this.superTabItem1.GlobalItem = false;
            this.superTabItem1.Name = "superTabItem1";
            this.superTabItem1.Text = "显示图像";
            // 
            // FormHalconTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1111, 477);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormHalconTool";
            this.Text = "Halcon读取";
            this.Load += new System.EventHandler(this.FormHalconTool_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).EndInit();
            this.superTabControl1.ResumeLayout(false);
            this.superTabControlPanel1.ResumeLayout(false);
            this.superTabControlPanel1.PerformLayout();
            this.panelMultImage.ResumeLayout(false);
            this.gpb_multImage.ResumeLayout(false);
            this.gpb_multImage.PerformLayout();
            this.panelOneImage.ResumeLayout(false);
            this.gpb_oneImage.ResumeLayout(false);
            this.gpb_oneImage.PerformLayout();
            this.superTabControlPanel2.ResumeLayout(false);
            this.superTabControlPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl2)).EndInit();
            this.superTabControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevComponents.DotNetBar.SuperTabControl superTabControl1;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel1;
        private System.Windows.Forms.Panel panelMultImage;
        public System.Windows.Forms.GroupBox gpb_multImage;
        public System.Windows.Forms.Button btn_selectImageDirectory;
        public System.Windows.Forms.Label lbl_imageNum;
        public System.Windows.Forms.Label lbl_imageName;
        internal System.Windows.Forms.Button btn_lastImage;
        internal System.Windows.Forms.Button btn_nextImage;
        internal System.Windows.Forms.TextBox tbx_imageDirectory;
        private System.Windows.Forms.Panel panelOneImage;
        public System.Windows.Forms.GroupBox gpb_oneImage;
        internal System.Windows.Forms.Button btn_readImage;
        internal System.Windows.Forms.TextBox tbx_imagePath;
        public System.Windows.Forms.Button btn_browseImage;
        public System.Windows.Forms.CheckBox ckb_autoSwitch;
        public System.Windows.Forms.Button btn_runHalconInterfaceTool;
        public System.Windows.Forms.Button btn_registImage;
        public System.Windows.Forms.RadioButton rdo_readOneImage;
        public System.Windows.Forms.RadioButton rdo_readMultImage;
        public System.Windows.Forms.CheckBox ckb_RGBToGray;
        private DevComponents.DotNetBar.SuperTabItem tabReadFormLocal;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel2;
        public System.Windows.Forms.CheckBox checkBox1;
        internal System.Windows.Forms.Button btn_RealTime;
        internal System.Windows.Forms.ComboBox cbx_deviceList;
        internal System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label148;
        internal System.Windows.Forms.TextBox tbx_exposure;
        internal System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label147;
        internal System.Windows.Forms.Button btn_saveImage;
        private System.Windows.Forms.Label label123;
        private DevComponents.DotNetBar.SuperTabItem tabReadFormCamera;
        private DevComponents.DotNetBar.SuperTabControl superTabControl2;
        private DevComponents.DotNetBar.SuperTabControlPanel imageDispPanel;
        private DevComponents.DotNetBar.SuperTabItem superTabItem1;
        public System.Windows.Forms.TextBox txbLog;
    }
}