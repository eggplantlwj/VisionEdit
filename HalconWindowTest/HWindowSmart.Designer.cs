namespace HalconWindow
{
    partial class HWindowSmart
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
            this.hSmartWindowControl = new HalconDotNet.HSmartWindowControl();
            this.SuspendLayout();
            // 
            // hSmartWindowControl
            // 
            this.hSmartWindowControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hSmartWindowControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.hSmartWindowControl.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.hSmartWindowControl.HDoubleClickToFitContent = true;
            this.hSmartWindowControl.HDrawingObjectsModifier = HalconDotNet.HSmartWindowControl.DrawingObjectsModifier.None;
            this.hSmartWindowControl.HImagePart = new System.Drawing.Rectangle(0, 0, 640, 480);
            this.hSmartWindowControl.HKeepAspectRatio = true;
            this.hSmartWindowControl.HMoveContent = true;
            this.hSmartWindowControl.HZoomContent = HalconDotNet.HSmartWindowControl.ZoomContent.WheelForwardZoomsIn;
            this.hSmartWindowControl.Location = new System.Drawing.Point(0, 0);
            this.hSmartWindowControl.Margin = new System.Windows.Forms.Padding(0);
            this.hSmartWindowControl.Name = "hSmartWindowControl";
            this.hSmartWindowControl.Size = new System.Drawing.Size(652, 498);
            this.hSmartWindowControl.TabIndex = 0;
            this.hSmartWindowControl.WindowSize = new System.Drawing.Size(652, 498);
            // 
            // HWindowSmart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.hSmartWindowControl);
            this.Name = "HWindowSmart";
            this.Size = new System.Drawing.Size(652, 522);
            this.ResumeLayout(false);

        }

        #endregion

        public HalconDotNet.HSmartWindowControl hSmartWindowControl;
    }
}
