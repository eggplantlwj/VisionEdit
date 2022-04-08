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
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lb_RunStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lb_Split = new System.Windows.Forms.ToolStripStatusLabel();
            this.lb_RunTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabGrabImage = new Sunny.UI.UITabControl();
            this.grabFile = new System.Windows.Forms.TabPage();
            this.camera = new System.Windows.Forms.TabPage();
            this.gbImageDisp = new Sunny.UI.UIGroupBox();
            this.uiMarkLabel2 = new Sunny.UI.UIMarkLabel();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.txbFilePath = new Sunny.UI.UITextBox();
            this.btnSelectFilePath = new Sunny.UI.UISymbolButton();
            this.btnRun = new Sunny.UI.UISymbolButton();
            this.uiGroupBox2 = new Sunny.UI.UIGroupBox();
            this.uiGroupBox3 = new Sunny.UI.UIGroupBox();
            this.chbRGB2Gray = new Sunny.UI.UICheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.tabGrabImage.SuspendLayout();
            this.grabFile.SuspendLayout();
            this.camera.SuspendLayout();
            this.uiGroupBox2.SuspendLayout();
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
            this.splitContainer1.Size = new System.Drawing.Size(1111, 517);
            this.splitContainer1.SplitterDistance = 605;
            this.splitContainer1.TabIndex = 1;
            // 
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.Color.White;
            this.statusStrip.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lb_RunStatus,
            this.lb_Split,
            this.lb_RunTime});
            this.statusStrip.Location = new System.Drawing.Point(0, 518);
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
            this.tabGrabImage.Size = new System.Drawing.Size(605, 517);
            this.tabGrabImage.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabGrabImage.TabIndex = 0;
            // 
            // grabFile
            // 
            this.grabFile.Controls.Add(this.uiGroupBox3);
            this.grabFile.Controls.Add(this.uiGroupBox2);
            this.grabFile.Location = new System.Drawing.Point(0, 40);
            this.grabFile.Name = "grabFile";
            this.grabFile.Size = new System.Drawing.Size(605, 477);
            this.grabFile.TabIndex = 0;
            this.grabFile.Text = "本地读取";
            this.grabFile.UseVisualStyleBackColor = true;
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
            this.gbImageDisp.Size = new System.Drawing.Size(502, 517);
            this.gbImageDisp.Style = Sunny.UI.UIStyle.Custom;
            this.gbImageDisp.TabIndex = 0;
            this.gbImageDisp.Text = "显示图像";
            this.gbImageDisp.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
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
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.Location = new System.Drawing.Point(27, 45);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(100, 23);
            this.uiLabel1.TabIndex = 0;
            this.uiLabel1.Text = "图像路径：";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.btnSelectFilePath.Symbol = 61462;
            this.btnSelectFilePath.TabIndex = 2;
            this.btnSelectFilePath.Text = "选择图像";
            this.btnSelectFilePath.Click += new System.EventHandler(this.btnSelectFilePath_Click);
            // 
            // btnRun
            // 
            this.btnRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRun.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRun.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRun.IsScaled = false;
            this.btnRun.Location = new System.Drawing.Point(440, 129);
            this.btnRun.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(133, 35);
            this.btnRun.Symbol = 61515;
            this.btnRun.TabIndex = 2;
            this.btnRun.Text = "运行工具";
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // uiGroupBox2
            // 
            this.uiGroupBox2.Controls.Add(this.chbRGB2Gray);
            this.uiGroupBox2.Controls.Add(this.uiLabel1);
            this.uiGroupBox2.Controls.Add(this.btnRun);
            this.uiGroupBox2.Controls.Add(this.txbFilePath);
            this.uiGroupBox2.Controls.Add(this.btnSelectFilePath);
            this.uiGroupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.uiGroupBox2.FillColor = System.Drawing.Color.White;
            this.uiGroupBox2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiGroupBox2.IsScaled = false;
            this.uiGroupBox2.Location = new System.Drawing.Point(0, 0);
            this.uiGroupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox2.Name = "uiGroupBox2";
            this.uiGroupBox2.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox2.Size = new System.Drawing.Size(605, 188);
            this.uiGroupBox2.Style = Sunny.UI.UIStyle.Custom;
            this.uiGroupBox2.TabIndex = 3;
            this.uiGroupBox2.Text = "单张图像";
            this.uiGroupBox2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uiGroupBox3
            // 
            this.uiGroupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiGroupBox3.FillColor = System.Drawing.Color.White;
            this.uiGroupBox3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiGroupBox3.IsScaled = false;
            this.uiGroupBox3.Location = new System.Drawing.Point(0, 188);
            this.uiGroupBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiGroupBox3.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiGroupBox3.Name = "uiGroupBox3";
            this.uiGroupBox3.Padding = new System.Windows.Forms.Padding(0, 32, 0, 0);
            this.uiGroupBox3.Size = new System.Drawing.Size(605, 289);
            this.uiGroupBox3.Style = Sunny.UI.UIStyle.Custom;
            this.uiGroupBox3.TabIndex = 4;
            this.uiGroupBox3.Text = "多组图像";
            this.uiGroupBox3.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chbRGB2Gray
            // 
            this.chbRGB2Gray.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chbRGB2Gray.Checked = true;
            this.chbRGB2Gray.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chbRGB2Gray.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chbRGB2Gray.IsScaled = false;
            this.chbRGB2Gray.Location = new System.Drawing.Point(300, 133);
            this.chbRGB2Gray.MinimumSize = new System.Drawing.Size(1, 1);
            this.chbRGB2Gray.Name = "chbRGB2Gray";
            this.chbRGB2Gray.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.chbRGB2Gray.Size = new System.Drawing.Size(111, 29);
            this.chbRGB2Gray.Style = Sunny.UI.UIStyle.Custom;
            this.chbRGB2Gray.TabIndex = 3;
            this.chbRGB2Gray.Text = "彩色转灰度";
            this.chbRGB2Gray.CheckedChanged += new System.EventHandler(this.chbRGB2Gray_CheckedChanged);
            // 
            // FormHalconTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1111, 542);
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
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.tabGrabImage.ResumeLayout(false);
            this.grabFile.ResumeLayout(false);
            this.camera.ResumeLayout(false);
            this.uiGroupBox2.ResumeLayout(false);
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
        private Sunny.UI.UIGroupBox uiGroupBox2;
        private Sunny.UI.UIGroupBox uiGroupBox3;
        private Sunny.UI.UICheckBox chbRGB2Gray;
    }
}