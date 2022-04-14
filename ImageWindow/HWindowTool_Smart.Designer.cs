namespace ViewROI
{
    partial class HWindowTool_Smart
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.SmartWindow = new HalconDotNet.HSmartWindowControl();
            this.uiContextMenuStrip1 = new Sunny.UI.UIContextMenuStrip();
            this.tsmiDispCorr = new System.Windows.Forms.ToolStripMenuItem();
            this.grayValueLable = new Sunny.UI.UISymbolLabel();
            this.uiContextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SmartWindow
            // 
            this.SmartWindow.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.SmartWindow.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.SmartWindow.ContextMenuStrip = this.uiContextMenuStrip1;
            this.SmartWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SmartWindow.HDoubleClickToFitContent = true;
            this.SmartWindow.HDrawingObjectsModifier = HalconDotNet.HSmartWindowControl.DrawingObjectsModifier.None;
            this.SmartWindow.HImagePart = new System.Drawing.Rectangle(0, 0, 640, 480);
            this.SmartWindow.HKeepAspectRatio = true;
            this.SmartWindow.HMoveContent = true;
            this.SmartWindow.HZoomContent = HalconDotNet.HSmartWindowControl.ZoomContent.WheelForwardZoomsIn;
            this.SmartWindow.Location = new System.Drawing.Point(0, 0);
            this.SmartWindow.Margin = new System.Windows.Forms.Padding(0);
            this.SmartWindow.Name = "SmartWindow";
            this.SmartWindow.Size = new System.Drawing.Size(576, 457);
            this.SmartWindow.TabIndex = 0;
            this.SmartWindow.WindowSize = new System.Drawing.Size(576, 457);
            this.SmartWindow.HMouseMove += new HalconDotNet.HMouseEventHandler(this.SmartWindow_HMouseMove);
            // 
            // uiContextMenuStrip1
            // 
            this.uiContextMenuStrip1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiContextMenuStrip1.IsScaled = false;
            this.uiContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiDispCorr});
            this.uiContextMenuStrip1.Name = "uiContextMenuStrip1";
            this.uiContextMenuStrip1.Size = new System.Drawing.Size(145, 30);
            // 
            // tsmiDispCorr
            // 
            this.tsmiDispCorr.Name = "tsmiDispCorr";
            this.tsmiDispCorr.Size = new System.Drawing.Size(144, 26);
            this.tsmiDispCorr.Text = "显示坐标";
            this.tsmiDispCorr.Click += new System.EventHandler(this.tsmiDispCorr_Click);
            // 
            // grayValueLable
            // 
            this.grayValueLable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.grayValueLable.BackColor = System.Drawing.Color.Transparent;
            this.grayValueLable.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.grayValueLable.IsScaled = false;
            this.grayValueLable.Location = new System.Drawing.Point(3, 430);
            this.grayValueLable.MinimumSize = new System.Drawing.Size(1, 1);
            this.grayValueLable.Name = "grayValueLable";
            this.grayValueLable.Padding = new System.Windows.Forms.Padding(28, 0, 0, 0);
            this.grayValueLable.Size = new System.Drawing.Size(260, 26);
            this.grayValueLable.Symbol = 61483;
            this.grayValueLable.TabIndex = 4;
            this.grayValueLable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.grayValueLable.Visible = false;
            // 
            // HWindowTool_Smart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grayValueLable);
            this.Controls.Add(this.SmartWindow);
            this.Name = "HWindowTool_Smart";
            this.Size = new System.Drawing.Size(576, 457);
            this.Load += new System.EventHandler(this.HWindowTool_Smart_Load);
            this.SizeChanged += new System.EventHandler(this.HWindowTool_Smart_SizeChanged);
            this.uiContextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        public HalconDotNet.HSmartWindowControl SmartWindow;
        private Sunny.UI.UIContextMenuStrip uiContextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiDispCorr;
        private Sunny.UI.UISymbolLabel grayValueLable;
    }
}
