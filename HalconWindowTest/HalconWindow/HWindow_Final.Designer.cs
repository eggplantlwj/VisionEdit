namespace HalconWindowTest.HalconWindow
{
    partial class HWindow_Final
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
            this.m_CtrlHStatusLabelCtrl = new System.Windows.Forms.Label();
            this.mCtrl_HWindow = new HalconDotNet.HWindowControl();
            this.SuspendLayout();
            // 
            // m_CtrlHStatusLabelCtrl
            // 
            this.m_CtrlHStatusLabelCtrl.AutoSize = true;
            this.m_CtrlHStatusLabelCtrl.Location = new System.Drawing.Point(14, 533);
            this.m_CtrlHStatusLabelCtrl.Name = "m_CtrlHStatusLabelCtrl";
            this.m_CtrlHStatusLabelCtrl.Size = new System.Drawing.Size(41, 12);
            this.m_CtrlHStatusLabelCtrl.TabIndex = 1;
            this.m_CtrlHStatusLabelCtrl.Text = "label1";
            // 
            // mCtrl_HWindow
            // 
            this.mCtrl_HWindow.BackColor = System.Drawing.Color.Black;
            this.mCtrl_HWindow.BorderColor = System.Drawing.Color.Black;
            this.mCtrl_HWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mCtrl_HWindow.ImagePart = new System.Drawing.Rectangle(0, 0, 640, 480);
            this.mCtrl_HWindow.Location = new System.Drawing.Point(0, 0);
            this.mCtrl_HWindow.Name = "mCtrl_HWindow";
            this.mCtrl_HWindow.Size = new System.Drawing.Size(629, 558);
            this.mCtrl_HWindow.TabIndex = 2;
            this.mCtrl_HWindow.WindowSize = new System.Drawing.Size(629, 558);
            // 
            // HWindow_Final
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_CtrlHStatusLabelCtrl);
            this.Controls.Add(this.mCtrl_HWindow);
            this.Name = "HWindow_Final";
            this.Size = new System.Drawing.Size(629, 558);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label m_CtrlHStatusLabelCtrl;
        private HalconDotNet.HWindowControl mCtrl_HWindow;
    }
}
