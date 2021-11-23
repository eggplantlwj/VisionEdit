namespace Controls
{
    partial class CCheckBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CCheckBox));
            this.pic_image = new System.Windows.Forms.PictureBox();
            this.ckb_box = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic_image)).BeginInit();
            this.SuspendLayout();
            // 
            // pic_image
            // 
            this.pic_image.Image = ((System.Drawing.Image)(resources.GetObject("pic_image.Image")));
            this.pic_image.Location = new System.Drawing.Point(1, 1);
            this.pic_image.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pic_image.Name = "pic_image";
            this.pic_image.Size = new System.Drawing.Size(18, 18);
            this.pic_image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_image.TabIndex = 0;
            this.pic_image.TabStop = false;
            this.pic_image.Click += new System.EventHandler(this.pic_image_Click);
            // 
            // ckb_box
            // 
            this.ckb_box.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ckb_box.BackColor = System.Drawing.Color.White;
            this.ckb_box.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ckb_box.Location = new System.Drawing.Point(5, 1);
            this.ckb_box.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ckb_box.Name = "ckb_box";
            this.ckb_box.Size = new System.Drawing.Size(161, 23);
            this.ckb_box.TabIndex = 1;
            this.ckb_box.Text = "复选框";
            this.ckb_box.UseVisualStyleBackColor = false;
            this.ckb_box.CheckedChanged += new System.EventHandler(this.ckb_box_CheckedChanged);
            // 
            // CCheckBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pic_image);
            this.Controls.Add(this.ckb_box);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "CCheckBox";
            this.Size = new System.Drawing.Size(167, 20);
            ((System.ComponentModel.ISupportInitialize)(this.pic_image)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pic_image;
        private System.Windows.Forms.CheckBox ckb_box;
    }
}
