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
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("流程");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Halcon窗口");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Basler");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("HIKVision");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("获取图像", new System.Windows.Forms.TreeNode[] {
            treeNode15,
            treeNode16,
            treeNode17});
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("滤波");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("平滑");
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("去噪");
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("图像预处理", new System.Windows.Forms.TreeNode[] {
            treeNode19,
            treeNode20,
            treeNode21});
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("形状匹配");
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("可变形匹配");
            System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("灰度匹配");
            System.Windows.Forms.TreeNode treeNode26 = new System.Windows.Forms.TreeNode("匹配", new System.Windows.Forms.TreeNode[] {
            treeNode23,
            treeNode24,
            treeNode25});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormToolBox));
            this.tvw_ToolBox = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.richTextBoxEx1 = new DevComponents.DotNetBar.Controls.RichTextBoxEx();
            this.SuspendLayout();
            // 
            // tvw_ToolBox
            // 
            this.tvw_ToolBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvw_ToolBox.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tvw_ToolBox.ImageIndex = 4;
            this.tvw_ToolBox.ImageList = this.imageList1;
            this.tvw_ToolBox.Indent = 32;
            this.tvw_ToolBox.Location = new System.Drawing.Point(0, 4);
            this.tvw_ToolBox.Name = "tvw_ToolBox";
            treeNode14.ImageIndex = 1;
            treeNode14.Name = "NodeJob";
            treeNode14.Text = "流程";
            treeNode15.ImageIndex = 3;
            treeNode15.Name = "节点1";
            treeNode15.Text = "Halcon窗口";
            treeNode16.ImageKey = "图像.png";
            treeNode16.Name = "节点2";
            treeNode16.Text = "Basler";
            treeNode17.ImageKey = "图像.png";
            treeNode17.Name = "节点3";
            treeNode17.Text = "HIKVision";
            treeNode18.ImageIndex = 4;
            treeNode18.Name = "节点0";
            treeNode18.Text = "获取图像";
            treeNode19.Name = "节点5";
            treeNode19.Text = "滤波";
            treeNode20.Name = "节点6";
            treeNode20.Text = "平滑";
            treeNode21.Name = "节点7";
            treeNode21.Text = "去噪";
            treeNode22.Name = "节点4";
            treeNode22.Text = "图像预处理";
            treeNode23.Name = "节点9";
            treeNode23.Text = "形状匹配";
            treeNode24.Name = "节点10";
            treeNode24.Text = "可变形匹配";
            treeNode25.Name = "节点11";
            treeNode25.Text = "灰度匹配";
            treeNode26.Name = "节点8";
            treeNode26.Text = "匹配";
            this.tvw_ToolBox.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode14,
            treeNode18,
            treeNode22,
            treeNode26});
            this.tvw_ToolBox.SelectedImageIndex = 4;
            this.tvw_ToolBox.Size = new System.Drawing.Size(367, 545);
            this.tvw_ToolBox.TabIndex = 1;
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
            // 
            // richTextBoxEx1
            // 
            this.richTextBoxEx1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.richTextBoxEx1.BackgroundStyle.Class = "RichTextBoxBorder";
            this.richTextBoxEx1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.richTextBoxEx1.Location = new System.Drawing.Point(0, 548);
            this.richTextBoxEx1.Name = "richTextBoxEx1";
            this.richTextBoxEx1.Rtf = "{\\rtf1\\ansi\\deff0{\\fonttbl{\\f0\\fnil\\fcharset134 \\\'cb\\\'ce\\\'cc\\\'e5;}}\r\n\\viewkind4\\u" +
    "c1\\pard\\lang2052\\f0\\fs18 richTextBoxEx1\\par\r\n}\r\n";
            this.richTextBoxEx1.Size = new System.Drawing.Size(367, 96);
            this.richTextBoxEx1.TabIndex = 2;
            this.richTextBoxEx1.Text = "richTextBoxEx1";
            // 
            // FormToolBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 642);
            this.Controls.Add(this.richTextBoxEx1);
            this.Controls.Add(this.tvw_ToolBox);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormToolBox";
            this.Text = "工具箱";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tvw_ToolBox;
        private DevComponents.DotNetBar.Controls.RichTextBoxEx richTextBoxEx1;
        private System.Windows.Forms.ImageList imageList1;
    }
}