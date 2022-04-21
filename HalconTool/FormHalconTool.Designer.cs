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
            this.tabGrabImage = new Sunny.UI.UITabControl();
            this.grabFile = new System.Windows.Forms.TabPage();
            this.gbMultImg = new Sunny.UI.UIGroupBox();
            this.gbSignalImg = new Sunny.UI.UIGroupBox();
            this.chbRGB2Gray = new Sunny.UI.UICheckBox();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.btnRun = new Sunny.UI.UISymbolButton();
            this.txbFilePath = new Sunny.UI.UITextBox();
            this.btnSelectFilePath = new Sunny.UI.UISymbolButton();
            this.camera = new System.Windows.Forms.TabPage();
            this.uiMarkLabel2 = new Sunny.UI.UIMarkLabel();
            this.gbImageDisp = new Sunny.UI.UIGroupBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lb_RunStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lb_Split = new System.Windows.Forms.ToolStripStatusLabel();
            this.lb_RunTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.uiCheckBox1 = new Sunny.UI.UICheckBox();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.tbxImageDirectory = new Sunny.UI.UITextBox();
            this.btnSelectDir = new Sunny.UI.UISymbolButton();
            this.btnNext = new Sunny.UI.UISymbolButton();
            this.btnOld = new Sunny.UI.UISymbolButton();
            this.lbImageName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabGrabImage.SuspendLayout();
            this.grabFile.SuspendLayout();
            this.gbMultImg.SuspendLayout();
            this.gbSignalImg.SuspendLayout();
            this.camera.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabGrabImage);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gbImageDisp);
            this.splitContainer1.Size = new System.Drawing.Size(1111, 457);
            this.splitContainer1.SplitterDistance = 605;
            this.splitContainer1.TabIndex = 1;
            // 
            // tabGrabImage
            // 
            this.tabGrabImage.Controls.Add(this.grabFile);
            this.tabGrabImage.Controls.Add(this.camera);
            this.tabGrabImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabGrabImage.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabGrabImage.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabGrabImage.ItemSize = new System.Drawing.Size(150, 40);
            this.tabGrabImage.Location = new System.Drawing.Point(0, 0);
            this.tabGrabImage.MainPage = "";
            this.tabGrabImage.Name = "tabGrabImage";
            this.tabGrabImage.SelectedIndex = 0;
            this.tabGrabImage.Size = new System.Drawing.Size(605, 457);
            this.tabGrabImage.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabGrabImage.TabIndex = 0;
            // 
            // grabFile
            // 
            this.grabFile.Controls.Add(this.gbMultImg);
            this.grabFile.Controls.Add(this.gbSignalImg);
            this.grabFile.Location = new System.Drawing.Point(0, 40);
            this.grabFile.Name = "grabFile";
            this.grabFile.Size = new System.Drawing.Size(605, 417);
            this.grabFile.TabIndex = 0;
            this.grabFile.Text = "本地读取";
            this.grabFile.UseVisualStyleBackColor = true;
            // 
            // gbMultImg
            // 
            this.gbMultImg.Controls.Add(this.lbImageName);
            this.gbMultImg.Controls.Add(this.btnOld);
            this.gbMultImg.Controls.Add(this.btnNext);
            this.gbMultImg.Controls.Add(this.uiCheckBox1);
            this.gbMultImg.Controls.Add(this.uiLabel2);
            this.gbMultImg.Controls.Add(this.tbxImageDirectory);
            this.gbMultImg.Controls.Add(this.btnSelectDir);
            this.gbMultImg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbMultImg.FillColor = System.Drawing.Color.White;
            this.gbMultImg.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gbMultImg.IsScaled = false;
            this.gbMultImg.Location = new System.Drawing.Point(0, 188);
            this.gbMultImg.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbMultImg.MinimumSize = new System.Drawing.Size(1, 1);
            this.gbMultImg.Name = "gbMultImg";
            this.gbMultImg.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.gbMultImg.Size = new System.Drawing.Size(605, 229);
            this.gbMultImg.Style = Sunny.UI.UIStyle.Custom;
            this.gbMultImg.TabIndex = 4;
            this.gbMultImg.Text = "多组图像";
            this.gbMultImg.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.gbMultImg.Click += new System.EventHandler(this.ImageSource_Click);
            // 
            // gbSignalImg
            // 
            this.gbSignalImg.Controls.Add(this.chbRGB2Gray);
            this.gbSignalImg.Controls.Add(this.uiLabel1);
            this.gbSignalImg.Controls.Add(this.btnRun);
            this.gbSignalImg.Controls.Add(this.txbFilePath);
            this.gbSignalImg.Controls.Add(this.btnSelectFilePath);
            this.gbSignalImg.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbSignalImg.FillColor = System.Drawing.Color.White;
            this.gbSignalImg.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gbSignalImg.IsScaled = false;
            this.gbSignalImg.Location = new System.Drawing.Point(0, 0);
            this.gbSignalImg.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbSignalImg.MinimumSize = new System.Drawing.Size(1, 1);
            this.gbSignalImg.Name = "gbSignalImg";
            this.gbSignalImg.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.gbSignalImg.Size = new System.Drawing.Size(605, 188);
            this.gbSignalImg.Style = Sunny.UI.UIStyle.Custom;
            this.gbSignalImg.TabIndex = 3;
            this.gbSignalImg.Text = "单张图像";
            this.gbSignalImg.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.gbSignalImg.Click += new System.EventHandler(this.ImageSource_Click);
            // 
            // chbRGB2Gray
            // 
            this.chbRGB2Gray.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chbRGB2Gray.Checked = true;
            this.chbRGB2Gray.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chbRGB2Gray.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chbRGB2Gray.IsScaled = false;
            this.chbRGB2Gray.Location = new System.Drawing.Point(378, 135);
            this.chbRGB2Gray.MinimumSize = new System.Drawing.Size(1, 1);
            this.chbRGB2Gray.Name = "chbRGB2Gray";
            this.chbRGB2Gray.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.chbRGB2Gray.Size = new System.Drawing.Size(111, 29);
            this.chbRGB2Gray.Style = Sunny.UI.UIStyle.Custom;
            this.chbRGB2Gray.TabIndex = 3;
            this.chbRGB2Gray.Text = "彩色转灰度";
            this.chbRGB2Gray.CheckedChanged += new System.EventHandler(this.chbRGB2Gray_CheckedChanged);
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.Location = new System.Drawing.Point(27, 45);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(100, 23);
            this.uiLabel1.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel1.TabIndex = 0;
            this.uiLabel1.Text = "图像路径：";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnRun
            // 
            this.btnRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRun.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRun.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRun.IsScaled = false;
            this.btnRun.Location = new System.Drawing.Point(210, 129);
            this.btnRun.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(133, 35);
            this.btnRun.Style = Sunny.UI.UIStyle.Custom;
            this.btnRun.Symbol = 61515;
            this.btnRun.TabIndex = 2;
            this.btnRun.Text = "运行工具";
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // txbFilePath
            // 
            this.txbFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbFilePath.ButtonSymbol = 61761;
            this.txbFilePath.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txbFilePath.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txbFilePath.IsScaled = false;
            this.txbFilePath.Location = new System.Drawing.Point(183, 42);
            this.txbFilePath.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txbFilePath.Maximum = 2147483647D;
            this.txbFilePath.Minimum = -2147483648D;
            this.txbFilePath.MinimumSize = new System.Drawing.Size(1, 16);
            this.txbFilePath.Name = "txbFilePath";
            this.txbFilePath.Size = new System.Drawing.Size(405, 35);
            this.txbFilePath.Style = Sunny.UI.UIStyle.Custom;
            this.txbFilePath.TabIndex = 1;
            this.txbFilePath.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.txbFilePath.TextChanged += new System.EventHandler(this.txbFilePath_TextChanged);
            // 
            // btnSelectFilePath
            // 
            this.btnSelectFilePath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelectFilePath.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSelectFilePath.IsScaled = false;
            this.btnSelectFilePath.Location = new System.Drawing.Point(31, 129);
            this.btnSelectFilePath.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnSelectFilePath.Name = "btnSelectFilePath";
            this.btnSelectFilePath.Size = new System.Drawing.Size(133, 35);
            this.btnSelectFilePath.Style = Sunny.UI.UIStyle.Custom;
            this.btnSelectFilePath.Symbol = 61462;
            this.btnSelectFilePath.TabIndex = 2;
            this.btnSelectFilePath.Text = "选择图像";
            this.btnSelectFilePath.Click += new System.EventHandler(this.btnSelectFilePath_Click);
            // 
            // camera
            // 
            this.camera.Controls.Add(this.uiMarkLabel2);
            this.camera.Location = new System.Drawing.Point(0, 40);
            this.camera.Name = "camera";
            this.camera.Size = new System.Drawing.Size(605, 477);
            this.camera.TabIndex = 2;
            this.camera.Text = "相机";
            this.camera.UseVisualStyleBackColor = true;
            // 
            // uiMarkLabel2
            // 
            this.uiMarkLabel2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiMarkLabel2.Location = new System.Drawing.Point(209, 206);
            this.uiMarkLabel2.Name = "uiMarkLabel2";
            this.uiMarkLabel2.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.uiMarkLabel2.Size = new System.Drawing.Size(189, 50);
            this.uiMarkLabel2.TabIndex = 1;
            this.uiMarkLabel2.Text = "该功能暂未实现";
            this.uiMarkLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gbImageDisp
            // 
            this.gbImageDisp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbImageDisp.FillColor = System.Drawing.Color.White;
            this.gbImageDisp.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gbImageDisp.IsScaled = false;
            this.gbImageDisp.Location = new System.Drawing.Point(0, 0);
            this.gbImageDisp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbImageDisp.MinimumSize = new System.Drawing.Size(1, 1);
            this.gbImageDisp.Name = "gbImageDisp";
            this.gbImageDisp.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.gbImageDisp.Size = new System.Drawing.Size(502, 457);
            this.gbImageDisp.Style = Sunny.UI.UIStyle.Custom;
            this.gbImageDisp.TabIndex = 0;
            this.gbImageDisp.Text = "显示图像";
            this.gbImageDisp.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.Color.White;
            this.statusStrip.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lb_RunStatus,
            this.lb_Split,
            this.lb_RunTime});
            this.statusStrip.Location = new System.Drawing.Point(0, 458);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1111, 24);
            this.statusStrip.TabIndex = 95;
            this.statusStrip.Text = "statusStrip1";
            // 
            // lb_RunStatus
            // 
            this.lb_RunStatus.Name = "lb_RunStatus";
            this.lb_RunStatus.Size = new System.Drawing.Size(0, 19);
            // 
            // lb_Split
            // 
            this.lb_Split.Name = "lb_Split";
            this.lb_Split.Size = new System.Drawing.Size(189, 19);
            this.lb_Split.Text = "                                             ";
            // 
            // lb_RunTime
            // 
            this.lb_RunTime.Name = "lb_RunTime";
            this.lb_RunTime.Size = new System.Drawing.Size(0, 19);
            // 
            // uiCheckBox1
            // 
            this.uiCheckBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.uiCheckBox1.Checked = true;
            this.uiCheckBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiCheckBox1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiCheckBox1.IsScaled = false;
            this.uiCheckBox1.Location = new System.Drawing.Point(466, 102);
            this.uiCheckBox1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiCheckBox1.Name = "uiCheckBox1";
            this.uiCheckBox1.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.uiCheckBox1.Size = new System.Drawing.Size(111, 29);
            this.uiCheckBox1.Style = Sunny.UI.UIStyle.Custom;
            this.uiCheckBox1.TabIndex = 8;
            this.uiCheckBox1.Text = "彩色转灰度";
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel2.Location = new System.Drawing.Point(27, 62);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(116, 23);
            this.uiLabel2.Style = Sunny.UI.UIStyle.Custom;
            this.uiLabel2.TabIndex = 4;
            this.uiLabel2.Text = "图像夹路径：";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbxImageDirectory
            // 
            this.tbxImageDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbxImageDirectory.ButtonSymbol = 61761;
            this.tbxImageDirectory.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbxImageDirectory.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxImageDirectory.IsScaled = false;
            this.tbxImageDirectory.Location = new System.Drawing.Point(183, 59);
            this.tbxImageDirectory.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbxImageDirectory.Maximum = 2147483647D;
            this.tbxImageDirectory.Minimum = -2147483648D;
            this.tbxImageDirectory.MinimumSize = new System.Drawing.Size(1, 16);
            this.tbxImageDirectory.Name = "tbxImageDirectory";
            this.tbxImageDirectory.Size = new System.Drawing.Size(405, 35);
            this.tbxImageDirectory.Style = Sunny.UI.UIStyle.Custom;
            this.tbxImageDirectory.TabIndex = 5;
            this.tbxImageDirectory.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSelectDir
            // 
            this.btnSelectDir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelectDir.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSelectDir.IsScaled = false;
            this.btnSelectDir.Location = new System.Drawing.Point(31, 157);
            this.btnSelectDir.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnSelectDir.Name = "btnSelectDir";
            this.btnSelectDir.Size = new System.Drawing.Size(133, 35);
            this.btnSelectDir.Style = Sunny.UI.UIStyle.Custom;
            this.btnSelectDir.Symbol = 61462;
            this.btnSelectDir.TabIndex = 7;
            this.btnSelectDir.Text = "选择文件夹";
            this.btnSelectDir.Click += new System.EventHandler(this.btnSelectDir_Click);
            // 
            // btnNext
            // 
            this.btnNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNext.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNext.IsScaled = false;
            this.btnNext.Location = new System.Drawing.Point(361, 157);
            this.btnNext.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(121, 35);
            this.btnNext.Style = Sunny.UI.UIStyle.Custom;
            this.btnNext.Symbol = 61518;
            this.btnNext.TabIndex = 9;
            this.btnNext.Text = "下一张";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnOld
            // 
            this.btnOld.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOld.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOld.IsScaled = false;
            this.btnOld.Location = new System.Drawing.Point(232, 157);
            this.btnOld.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnOld.Name = "btnOld";
            this.btnOld.Size = new System.Drawing.Size(121, 35);
            this.btnOld.Style = Sunny.UI.UIStyle.Custom;
            this.btnOld.Symbol = 61514;
            this.btnOld.TabIndex = 9;
            this.btnOld.Text = "上一张";
            this.btnOld.Click += new System.EventHandler(this.btnOld_Click);
            // 
            // lbImageName
            // 
            this.lbImageName.AutoSize = true;
            this.lbImageName.Location = new System.Drawing.Point(183, 103);
            this.lbImageName.Name = "lbImageName";
            this.lbImageName.Size = new System.Drawing.Size(0, 21);
            this.lbImageName.TabIndex = 10;
            // 
            // FormHalconTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1111, 482);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormHalconTool";
            this.Text = "Halcon读取";
            this.Load += new System.EventHandler(this.FormHalconTool_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabGrabImage.ResumeLayout(false);
            this.grabFile.ResumeLayout(false);
            this.gbMultImg.ResumeLayout(false);
            this.gbMultImg.PerformLayout();
            this.gbSignalImg.ResumeLayout(false);
            this.camera.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        public System.Windows.Forms.StatusStrip statusStrip;
        public System.Windows.Forms.ToolStripStatusLabel lb_RunStatus;
        private System.Windows.Forms.ToolStripStatusLabel lb_Split;
        public System.Windows.Forms.ToolStripStatusLabel lb_RunTime;
        private Sunny.UI.UITabControl tabGrabImage;
        private System.Windows.Forms.TabPage grabFile;
        private System.Windows.Forms.TabPage camera;
        private Sunny.UI.UIGroupBox gbImageDisp;
        private Sunny.UI.UIMarkLabel uiMarkLabel2;
        private Sunny.UI.UITextBox txbFilePath;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UISymbolButton btnSelectFilePath;
        private Sunny.UI.UISymbolButton btnRun;
        private Sunny.UI.UIGroupBox gbSignalImg;
        private Sunny.UI.UIGroupBox gbMultImg;
        private Sunny.UI.UICheckBox chbRGB2Gray;
        private Sunny.UI.UICheckBox uiCheckBox1;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UITextBox tbxImageDirectory;
        private Sunny.UI.UISymbolButton btnSelectDir;
        private System.Windows.Forms.Label lbImageName;
        public Sunny.UI.UISymbolButton btnNext;
        public Sunny.UI.UISymbolButton btnOld;
    }
}