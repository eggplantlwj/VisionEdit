namespace VisionEdit.FormLib
{
    partial class FormToolBox
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("流程", 1, 1);
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("Halcon窗口", 3, 3);
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("Basler");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("HIKVision");
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("获取图像", new System.Windows.Forms.TreeNode[] {
            treeNode18,
            treeNode19,
            treeNode20});
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("滤波");
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("平滑");
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("去噪");
            System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("图像预处理", new System.Windows.Forms.TreeNode[] {
            treeNode22,
            treeNode23,
            treeNode24});
            System.Windows.Forms.TreeNode treeNode26 = new System.Windows.Forms.TreeNode("形状匹配");
            System.Windows.Forms.TreeNode treeNode27 = new System.Windows.Forms.TreeNode("可变形匹配");
            System.Windows.Forms.TreeNode treeNode28 = new System.Windows.Forms.TreeNode("灰度匹配");
            System.Windows.Forms.TreeNode treeNode29 = new System.Windows.Forms.TreeNode("匹配", new System.Windows.Forms.TreeNode[] {
            treeNode26,
            treeNode27,
            treeNode28});
            System.Windows.Forms.TreeNode treeNode30 = new System.Windows.Forms.TreeNode("找线");
            System.Windows.Forms.TreeNode treeNode31 = new System.Windows.Forms.TreeNode("找圆");
            System.Windows.Forms.TreeNode treeNode32 = new System.Windows.Forms.TreeNode("几何", new System.Windows.Forms.TreeNode[] {
            treeNode30,
            treeNode31});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormToolBox));
            this.tvw_ToolBox = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.richTextBoxEx1 = new DevComponents.DotNetBar.Controls.RichTextBoxEx();
            this.imageListTool = new System.Windows.Forms.ImageList(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvw_ToolBox
            // 
            this.tvw_ToolBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvw_ToolBox.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tvw_ToolBox.ImageIndex = 4;
            this.tvw_ToolBox.ImageList = this.imageList1;
            this.tvw_ToolBox.Indent = 32;
            this.tvw_ToolBox.Location = new System.Drawing.Point(0, 0);
            this.tvw_ToolBox.Name = "tvw_ToolBox";
            treeNode17.ImageIndex = 1;
            treeNode17.Name = "NodeJob";
            treeNode17.SelectedImageIndex = 1;
            treeNode17.Text = "流程";
            treeNode18.ImageIndex = 3;
            treeNode18.Name = "节点1";
            treeNode18.SelectedImageIndex = 3;
            treeNode18.Tag = "HalconTool";
            treeNode18.Text = "Halcon窗口";
            treeNode19.ImageKey = "图像.png";
            treeNode19.Name = "节点2";
            treeNode19.SelectedImageIndex = 3;
            treeNode19.Text = "Basler";
            treeNode20.ImageKey = "图像.png";
            treeNode20.Name = "节点3";
            treeNode20.SelectedImageIndex = 3;
            treeNode20.Text = "HIKVision";
            treeNode21.ImageIndex = 4;
            treeNode21.Name = "节点0";
            treeNode21.Text = "获取图像";
            treeNode22.Name = "节点5";
            treeNode22.Text = "滤波";
            treeNode23.Name = "节点6";
            treeNode23.Text = "平滑";
            treeNode24.Name = "节点7";
            treeNode24.Text = "去噪";
            treeNode25.Name = "节点4";
            treeNode25.Text = "图像预处理";
            treeNode26.Name = "节点9";
            treeNode26.Text = "形状匹配";
            treeNode27.Name = "节点10";
            treeNode27.Text = "可变形匹配";
            treeNode28.Name = "节点11";
            treeNode28.Text = "灰度匹配";
            treeNode29.Name = "节点8";
            treeNode29.Text = "匹配";
            treeNode30.ImageKey = "Line.png";
            treeNode30.Name = "FindLine";
            treeNode30.SelectedImageKey = "Line.png";
            treeNode30.Tag = "FindLine";
            treeNode30.Text = "找线";
            treeNode31.ImageKey = "Circle.png";
            treeNode31.Name = "FindCircle";
            treeNode31.SelectedImageKey = "Circle.png";
            treeNode31.Text = "找圆";
            treeNode32.Name = "节点0";
            treeNode32.Text = "几何";
            this.tvw_ToolBox.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode17,
            treeNode21,
            treeNode25,
            treeNode29,
            treeNode32});
            this.tvw_ToolBox.SelectedImageIndex = 4;
            this.tvw_ToolBox.Size = new System.Drawing.Size(417, 543);
            this.tvw_ToolBox.TabIndex = 1;
            this.tvw_ToolBox.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvw_ToolBox_AfterSelect);
            this.tvw_ToolBox.Click += new System.EventHandler(this.tvw_ToolBox_Click);
            this.tvw_ToolBox.DoubleClick += new System.EventHandler(this.tvw_ToolBox_DoubleClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "镜头.png");
            this.imageList1.Images.SetKeyName(1, "流程.png");
            this.imageList1.Images.SetKeyName(2, "流程图.png");
            this.imageList1.Images.SetKeyName(3, "图像.png");
            this.imageList1.Images.SetKeyName(4, "文件夹.png");
            this.imageList1.Images.SetKeyName(5, "Line.png");
            this.imageList1.Images.SetKeyName(6, "Circle.png");
            // 
            // richTextBoxEx1
            // 
            // 
            // 
            // 
            this.richTextBoxEx1.BackgroundStyle.Class = "RichTextBoxBorder";
            this.richTextBoxEx1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.richTextBoxEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxEx1.Location = new System.Drawing.Point(0, 0);
            this.richTextBoxEx1.Name = "richTextBoxEx1";
            this.richTextBoxEx1.Rtf = "{\\rtf1\\ansi\\deff0{\\fonttbl{\\f0\\fnil\\fcharset134 \\\'cb\\\'ce\\\'cc\\\'e5;}}\r\n\\viewkind4\\u" +
    "c1\\pard\\lang2052\\f0\\fs18 richTextBoxEx1\\par\r\n}\r\n";
            this.richTextBoxEx1.Size = new System.Drawing.Size(417, 95);
            this.richTextBoxEx1.TabIndex = 2;
            this.richTextBoxEx1.Text = "richTextBoxEx1";
            // 
            // imageListTool
            // 
            this.imageListTool.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListTool.ImageStream")));
            this.imageListTool.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListTool.Images.SetKeyName(0, "流程图.png");
            this.imageListTool.Images.SetKeyName(1, "图像.png");
            this.imageListTool.Images.SetKeyName(2, "图像.png");
            this.imageListTool.Images.SetKeyName(3, "图像.png");
            this.imageListTool.Images.SetKeyName(4, "图像.png");
            this.imageListTool.Images.SetKeyName(5, "分析 数据.png");
            this.imageListTool.Images.SetKeyName(6, "Line 1.png");
            this.imageListTool.Images.SetKeyName(7, "Circle.png");
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tvw_ToolBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.richTextBoxEx1);
            this.splitContainer1.Size = new System.Drawing.Size(417, 642);
            this.splitContainer1.SplitterDistance = 543;
            this.splitContainer1.TabIndex = 7;
            // 
            // FormToolBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 642);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormToolBox";
            this.Text = "工具箱";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tvw_ToolBox;
        private DevComponents.DotNetBar.Controls.RichTextBoxEx richTextBoxEx1;
        public System.Windows.Forms.ImageList imageList1;
        public System.Windows.Forms.ImageList imageListTool;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}