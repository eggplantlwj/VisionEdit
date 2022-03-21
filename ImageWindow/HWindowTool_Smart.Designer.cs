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
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lb_Status = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // SmartWindow
            // 
            this.SmartWindow.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.SmartWindow.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
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
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.Color.White;
            this.statusStrip.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lb_Status});
            this.statusStrip.Location = new System.Drawing.Point(0, 435);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(576, 22);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip1";
            this.statusStrip.Visible = false;
            // 
            // lb_Status
            // 
            this.lb_Status.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_Status.Name = "lb_Status";
            this.lb_Status.Size = new System.Drawing.Size(0, 17);
            // 
            // HWindowTool_Smart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.SmartWindow);
            this.Name = "HWindowTool_Smart";
            this.Size = new System.Drawing.Size(576, 457);
            this.Load += new System.EventHandler(this.HWindowTool_Smart_Load);
            this.SizeChanged += new System.EventHandler(this.HWindowTool_Smart_SizeChanged);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lb_Status;
        public HalconDotNet.HSmartWindowControl SmartWindow;
    }
}
