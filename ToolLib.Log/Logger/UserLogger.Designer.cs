namespace Logger
{
    partial class UserLogger
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserLogger));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnClear = new System.Windows.Forms.ToolStripMenuItem();
            this.listBoxAll = new System.Windows.Forms.ListBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.pageAll = new System.Windows.Forms.TabPage();
            this.pageInfo = new System.Windows.Forms.TabPage();
            this.listBoxInfo = new System.Windows.Forms.ListBox();
            this.pageWarn = new System.Windows.Forms.TabPage();
            this.listBoxWarn = new System.Windows.Forms.ListBox();
            this.padeDebug = new System.Windows.Forms.TabPage();
            this.listBoxDebug = new System.Windows.Forms.ListBox();
            this.pageExpection = new System.Windows.Forms.TabPage();
            this.listBoxExpection = new System.Windows.Forms.ListBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.pageAll.SuspendLayout();
            this.pageInfo.SuspendLayout();
            this.pageWarn.SuspendLayout();
            this.padeDebug.SuspendLayout();
            this.pageExpection.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnClear});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 26);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 22);
            this.btnClear.Text = "清空";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // listBoxAll
            // 
            this.listBoxAll.BackColor = System.Drawing.SystemColors.Info;
            this.listBoxAll.ContextMenuStrip = this.contextMenuStrip1;
            this.listBoxAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxAll.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBoxAll.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listBoxAll.FormattingEnabled = true;
            this.listBoxAll.ItemHeight = 18;
            this.listBoxAll.Location = new System.Drawing.Point(3, 3);
            this.listBoxAll.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBoxAll.Name = "listBoxAll";
            this.listBoxAll.Size = new System.Drawing.Size(662, 313);
            this.listBoxAll.TabIndex = 0;
            this.listBoxAll.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBox1_DrawItem);
            this.listBoxAll.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl1.Controls.Add(this.pageAll);
            this.tabControl1.Controls.Add(this.pageInfo);
            this.tabControl1.Controls.Add(this.pageWarn);
            this.tabControl1.Controls.Add(this.padeDebug);
            this.tabControl1.Controls.Add(this.pageExpection);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ImageList = this.imageList1;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(676, 347);
            this.tabControl1.TabIndex = 1;
            // 
            // pageAll
            // 
            this.pageAll.Controls.Add(this.listBoxAll);
            this.pageAll.ImageIndex = 3;
            this.pageAll.Location = new System.Drawing.Point(4, 4);
            this.pageAll.Name = "pageAll";
            this.pageAll.Padding = new System.Windows.Forms.Padding(3);
            this.pageAll.Size = new System.Drawing.Size(668, 319);
            this.pageAll.TabIndex = 0;
            this.pageAll.Text = "全部";
            this.pageAll.UseVisualStyleBackColor = true;
            // 
            // pageInfo
            // 
            this.pageInfo.Controls.Add(this.listBoxInfo);
            this.pageInfo.ImageIndex = 2;
            this.pageInfo.Location = new System.Drawing.Point(4, 4);
            this.pageInfo.Name = "pageInfo";
            this.pageInfo.Padding = new System.Windows.Forms.Padding(3);
            this.pageInfo.Size = new System.Drawing.Size(668, 319);
            this.pageInfo.TabIndex = 1;
            this.pageInfo.Text = "消息";
            this.pageInfo.UseVisualStyleBackColor = true;
            // 
            // listBoxInfo
            // 
            this.listBoxInfo.BackColor = System.Drawing.SystemColors.Info;
            this.listBoxInfo.ContextMenuStrip = this.contextMenuStrip1;
            this.listBoxInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxInfo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBoxInfo.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listBoxInfo.FormattingEnabled = true;
            this.listBoxInfo.ItemHeight = 18;
            this.listBoxInfo.Location = new System.Drawing.Point(3, 3);
            this.listBoxInfo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBoxInfo.Name = "listBoxInfo";
            this.listBoxInfo.Size = new System.Drawing.Size(662, 313);
            this.listBoxInfo.TabIndex = 1;
            this.listBoxInfo.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBox1_DrawItem);
            this.listBoxInfo.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
            // 
            // pageWarn
            // 
            this.pageWarn.Controls.Add(this.listBoxWarn);
            this.pageWarn.ImageIndex = 4;
            this.pageWarn.Location = new System.Drawing.Point(4, 4);
            this.pageWarn.Name = "pageWarn";
            this.pageWarn.Size = new System.Drawing.Size(668, 319);
            this.pageWarn.TabIndex = 2;
            this.pageWarn.Text = "警告";
            this.pageWarn.UseVisualStyleBackColor = true;
            // 
            // listBoxWarn
            // 
            this.listBoxWarn.BackColor = System.Drawing.SystemColors.Info;
            this.listBoxWarn.ContextMenuStrip = this.contextMenuStrip1;
            this.listBoxWarn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxWarn.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBoxWarn.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listBoxWarn.FormattingEnabled = true;
            this.listBoxWarn.ItemHeight = 18;
            this.listBoxWarn.Location = new System.Drawing.Point(0, 0);
            this.listBoxWarn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBoxWarn.Name = "listBoxWarn";
            this.listBoxWarn.Size = new System.Drawing.Size(668, 319);
            this.listBoxWarn.TabIndex = 1;
            this.listBoxWarn.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBox1_DrawItem);
            this.listBoxWarn.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
            // 
            // padeDebug
            // 
            this.padeDebug.Controls.Add(this.listBoxDebug);
            this.padeDebug.ImageIndex = 0;
            this.padeDebug.Location = new System.Drawing.Point(4, 4);
            this.padeDebug.Name = "padeDebug";
            this.padeDebug.Size = new System.Drawing.Size(668, 319);
            this.padeDebug.TabIndex = 3;
            this.padeDebug.Text = "调试";
            this.padeDebug.UseVisualStyleBackColor = true;
            // 
            // listBoxDebug
            // 
            this.listBoxDebug.BackColor = System.Drawing.SystemColors.Info;
            this.listBoxDebug.ContextMenuStrip = this.contextMenuStrip1;
            this.listBoxDebug.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxDebug.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBoxDebug.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listBoxDebug.FormattingEnabled = true;
            this.listBoxDebug.ItemHeight = 18;
            this.listBoxDebug.Location = new System.Drawing.Point(0, 0);
            this.listBoxDebug.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBoxDebug.Name = "listBoxDebug";
            this.listBoxDebug.Size = new System.Drawing.Size(668, 319);
            this.listBoxDebug.TabIndex = 1;
            this.listBoxDebug.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBox1_DrawItem);
            this.listBoxDebug.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
            // 
            // pageExpection
            // 
            this.pageExpection.Controls.Add(this.listBoxExpection);
            this.pageExpection.ImageIndex = 1;
            this.pageExpection.Location = new System.Drawing.Point(4, 4);
            this.pageExpection.Name = "pageExpection";
            this.pageExpection.Size = new System.Drawing.Size(668, 319);
            this.pageExpection.TabIndex = 4;
            this.pageExpection.Text = "异常";
            this.pageExpection.UseVisualStyleBackColor = true;
            // 
            // listBoxExpection
            // 
            this.listBoxExpection.BackColor = System.Drawing.SystemColors.Info;
            this.listBoxExpection.ContextMenuStrip = this.contextMenuStrip1;
            this.listBoxExpection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxExpection.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBoxExpection.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listBoxExpection.FormattingEnabled = true;
            this.listBoxExpection.ItemHeight = 18;
            this.listBoxExpection.Location = new System.Drawing.Point(0, 0);
            this.listBoxExpection.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.listBoxExpection.Name = "listBoxExpection";
            this.listBoxExpection.Size = new System.Drawing.Size(668, 319);
            this.listBoxExpection.TabIndex = 2;
            this.listBoxExpection.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBox1_DrawItem);
            this.listBoxExpection.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "debug.ico");
            this.imageList1.Images.SetKeyName(1, "error.ico");
            this.imageList1.Images.SetKeyName(2, "info.ico");
            this.imageList1.Images.SetKeyName(3, "loh.ico");
            this.imageList1.Images.SetKeyName(4, "warn.ico");
            // 
            // UserLogger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "UserLogger";
            this.Size = new System.Drawing.Size(676, 347);
            this.Load += new System.EventHandler(this.UserLogger_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.pageAll.ResumeLayout(false);
            this.pageInfo.ResumeLayout(false);
            this.pageWarn.ResumeLayout(false);
            this.padeDebug.ResumeLayout(false);
            this.pageExpection.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnClear;
        public System.Windows.Forms.ListBox listBoxAll;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage pageAll;
        private System.Windows.Forms.TabPage pageInfo;
        public System.Windows.Forms.ListBox listBoxInfo;
        private System.Windows.Forms.TabPage pageWarn;
        public System.Windows.Forms.ListBox listBoxWarn;
        private System.Windows.Forms.TabPage padeDebug;
        public System.Windows.Forms.ListBox listBoxDebug;
        private System.Windows.Forms.TabPage pageExpection;
        public System.Windows.Forms.ListBox listBoxExpection;
        private System.Windows.Forms.ImageList imageList1;
    }
}
