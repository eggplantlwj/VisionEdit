namespace HDevEngineTool
{
    partial class FormHDevEngineTool
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHDevEngineTool));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtRunTool = new System.Windows.Forms.ToolStripButton();
            this.tsbReadHdev = new System.Windows.Forms.ToolStripButton();
            this.tsbSaveHdev = new System.Windows.Forms.ToolStripButton();
            this.tsbReLoad = new System.Windows.Forms.ToolStripButton();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lb_RunStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lb_RunTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.uiSplitContainer1 = new Sunny.UI.UISplitContainer();
            this.panelHImageWindow = new System.Windows.Forms.Panel();
            this.uiTabControl1 = new Sunny.UI.UITabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txbCodeText = new Sunny.UI.UIRichTextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.toolStrip1.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiSplitContainer1)).BeginInit();
            this.uiSplitContainer1.Panel1.SuspendLayout();
            this.uiSplitContainer1.Panel2.SuspendLayout();
            this.uiSplitContainer1.SuspendLayout();
            this.uiTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtRunTool,
            this.tsbReadHdev,
            this.tsbSaveHdev,
            this.tsbReLoad});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1277, 32);
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
            // tsbReadHdev
            // 
            this.tsbReadHdev.Image = ((System.Drawing.Image)(resources.GetObject("tsbReadHdev.Image")));
            this.tsbReadHdev.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbReadHdev.Name = "tsbReadHdev";
            this.tsbReadHdev.Size = new System.Drawing.Size(85, 29);
            this.tsbReadHdev.Text = "代码读取";
            this.tsbReadHdev.Click += new System.EventHandler(this.tsbReadHdev_Click);
            // 
            // tsbSaveHdev
            // 
            this.tsbSaveHdev.Image = ((System.Drawing.Image)(resources.GetObject("tsbSaveHdev.Image")));
            this.tsbSaveHdev.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSaveHdev.Name = "tsbSaveHdev";
            this.tsbSaveHdev.Size = new System.Drawing.Size(85, 29);
            this.tsbSaveHdev.Text = "程序保存";
            this.tsbSaveHdev.Click += new System.EventHandler(this.tsbSaveHdev_Click);
            // 
            // tsbReLoad
            // 
            this.tsbReLoad.Image = ((System.Drawing.Image)(resources.GetObject("tsbReLoad.Image")));
            this.tsbReLoad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbReLoad.Name = "tsbReLoad";
            this.tsbReLoad.Size = new System.Drawing.Size(85, 29);
            this.tsbReLoad.Text = "重新载入";
            this.tsbReLoad.Click += new System.EventHandler(this.tsbReLoad_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lb_RunStatus,
            this.toolStripStatusLabel1,
            this.lb_RunTime});
            this.statusStrip.Location = new System.Drawing.Point(0, 601);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1277, 22);
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
            // uiSplitContainer1
            // 
            this.uiSplitContainer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.uiSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiSplitContainer1.Location = new System.Drawing.Point(0, 32);
            this.uiSplitContainer1.Name = "uiSplitContainer1";
            // 
            // uiSplitContainer1.Panel1
            // 
            this.uiSplitContainer1.Panel1.Controls.Add(this.panelHImageWindow);
            // 
            // uiSplitContainer1.Panel2
            // 
            this.uiSplitContainer1.Panel2.Controls.Add(this.uiTabControl1);
            this.uiSplitContainer1.Size = new System.Drawing.Size(1277, 569);
            this.uiSplitContainer1.SplitterDistance = 630;
            this.uiSplitContainer1.SplitterWidth = 11;
            this.uiSplitContainer1.TabIndex = 6;
            // 
            // panelHImageWindow
            // 
            this.panelHImageWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelHImageWindow.Location = new System.Drawing.Point(0, 0);
            this.panelHImageWindow.Name = "panelHImageWindow";
            this.panelHImageWindow.Size = new System.Drawing.Size(630, 569);
            this.panelHImageWindow.TabIndex = 0;
            // 
            // uiTabControl1
            // 
            this.uiTabControl1.Controls.Add(this.tabPage1);
            this.uiTabControl1.Controls.Add(this.tabPage2);
            this.uiTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiTabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.uiTabControl1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTabControl1.ItemSize = new System.Drawing.Size(150, 40);
            this.uiTabControl1.Location = new System.Drawing.Point(0, 0);
            this.uiTabControl1.MainPage = "";
            this.uiTabControl1.Name = "uiTabControl1";
            this.uiTabControl1.SelectedIndex = 0;
            this.uiTabControl1.Size = new System.Drawing.Size(636, 569);
            this.uiTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.uiTabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txbCodeText);
            this.tabPage1.Location = new System.Drawing.Point(0, 40);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(636, 529);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "工具代码";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txbCodeText
            // 
            this.txbCodeText.AutoWordSelection = true;
            this.txbCodeText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txbCodeText.FillColor = System.Drawing.Color.White;
            this.txbCodeText.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txbCodeText.IsScaled = false;
            this.txbCodeText.Location = new System.Drawing.Point(0, 0);
            this.txbCodeText.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txbCodeText.MinimumSize = new System.Drawing.Size(1, 1);
            this.txbCodeText.Name = "txbCodeText";
            this.txbCodeText.Padding = new System.Windows.Forms.Padding(2);
            this.txbCodeText.Size = new System.Drawing.Size(636, 529);
            this.txbCodeText.Style = Sunny.UI.UIStyle.Custom;
            this.txbCodeText.TabIndex = 0;
            this.txbCodeText.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.txbCodeText.WordWrap = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(0, 40);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(636, 529);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "其他";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // FormHDevEngineTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1277, 623);
            this.Controls.Add(this.uiSplitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip);
            this.Name = "FormHDevEngineTool";
            this.Text = "FormHDevEngineTool";
            this.Load += new System.EventHandler(this.FormHDevEngineTool_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.uiSplitContainer1.Panel1.ResumeLayout(false);
            this.uiSplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uiSplitContainer1)).EndInit();
            this.uiSplitContainer1.ResumeLayout(false);
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
        private Sunny.UI.UISplitContainer uiSplitContainer1;
        private System.Windows.Forms.Panel panelHImageWindow;
        private Sunny.UI.UITabControl uiTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private Sunny.UI.UIRichTextBox txbCodeText;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ToolStripButton tsbReadHdev;
        private System.Windows.Forms.ToolStripButton tsbSaveHdev;
        private System.Windows.Forms.ToolStripButton tsbReLoad;
    }
}