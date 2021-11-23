namespace Controls
{
    partial class CNumeric
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_line = new System.Windows.Forms.Label();
            this.tbx_value = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbl_line
            // 
            this.lbl_line.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_line.BackColor = System.Drawing.Color.Gray;
            this.lbl_line.Location = new System.Drawing.Point(0, 20);
            this.lbl_line.Name = "lbl_line";
            this.lbl_line.Size = new System.Drawing.Size(120, 1);
            this.lbl_line.TabIndex = 8;
            // 
            // tbx_value
            // 
            this.tbx_value.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_value.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbx_value.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.tbx_value.Location = new System.Drawing.Point(3, 0);
            this.tbx_value.Name = "tbx_value";
            this.tbx_value.Size = new System.Drawing.Size(114, 16);
            this.tbx_value.TabIndex = 9;
            this.tbx_value.TextChanged += new System.EventHandler(this.tbx_value_TextChanged);
            this.tbx_value.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbx_value_KeyPress);
            // 
            // CNumeric
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tbx_value);
            this.Controls.Add(this.lbl_line);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CNumeric";
            this.Size = new System.Drawing.Size(121, 22);
            this.Enter += new System.EventHandler(this.Numeric_Enter);
            this.Leave += new System.EventHandler(this.Numeric_Leave);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_line;
        private System.Windows.Forms.TextBox tbx_value;
    }
}
