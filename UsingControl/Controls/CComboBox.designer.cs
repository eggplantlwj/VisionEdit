namespace Controls
{
    partial class CComboBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CComboBox));
            this.cbx_item = new System.Windows.Forms.ComboBox();
            this.lbl_line = new System.Windows.Forms.Label();
            this.btn_showItem = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbx_item
            // 
            this.cbx_item.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbx_item.BackColor = System.Drawing.Color.White;
            this.cbx_item.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_item.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbx_item.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cbx_item.FormattingEnabled = true;
            this.cbx_item.Location = new System.Drawing.Point(2, -3);
            this.cbx_item.Margin = new System.Windows.Forms.Padding(0);
            this.cbx_item.Name = "cbx_item";
            this.cbx_item.Size = new System.Drawing.Size(120, 25);
            this.cbx_item.TabIndex = 10;
            this.cbx_item.TabStop = false;
            this.cbx_item.SelectedIndexChanged += new System.EventHandler(this.cbx_item_SelectedIndexChanged);
            // 
            // lbl_line
            // 
            this.lbl_line.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_line.BackColor = System.Drawing.Color.Gray;
            this.lbl_line.Location = new System.Drawing.Point(3, 20);
            this.lbl_line.Name = "lbl_line";
            this.lbl_line.Size = new System.Drawing.Size(120, 1);
            this.lbl_line.TabIndex = 11;
            // 
            // btn_showItem
            // 
            this.btn_showItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_showItem.BackColor = System.Drawing.Color.White;
            this.btn_showItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_showItem.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_showItem.FlatAppearance.BorderSize = 0;
            this.btn_showItem.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btn_showItem.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkGray;
            this.btn_showItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_showItem.Image = ((System.Drawing.Image)(resources.GetObject("btn_showItem.Image")));
            this.btn_showItem.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_showItem.Location = new System.Drawing.Point(103, -1);
            this.btn_showItem.Margin = new System.Windows.Forms.Padding(0);
            this.btn_showItem.Name = "btn_showItem";
            this.btn_showItem.Size = new System.Drawing.Size(17, 20);
            this.btn_showItem.TabIndex = 12;
            this.btn_showItem.UseVisualStyleBackColor = false;
            this.btn_showItem.Click += new System.EventHandler(this.btn_showItem_Click);
            // 
            // CComboBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.btn_showItem);
            this.Controls.Add(this.lbl_line);
            this.Controls.Add(this.cbx_item);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "CComboBox";
            this.Size = new System.Drawing.Size(120, 22);
            this.Enter += new System.EventHandler(this.ComboBox_Enter);
            this.Leave += new System.EventHandler(this.ComboBox_Leave);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbx_item;
        private System.Windows.Forms.Label lbl_line;
        private System.Windows.Forms.Button btn_showItem;
    }
}
