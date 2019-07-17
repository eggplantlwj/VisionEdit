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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("流程", 1, 1);
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Halcon窗口", 3, 3);
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Basler");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("HIKVision");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("获取图像", new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode3,
            treeNode4});
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("滤波");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("平滑");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("去噪");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("图像预处理", new System.Windows.Forms.TreeNode[] {
            treeNode6,
            treeNode7,
            treeNode8});
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("形状匹配");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("可变形匹配");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("灰度匹配");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("匹配", new System.Windows.Forms.TreeNode[] {
            treeNode10,
            treeNode11,
            treeNode12});
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("找线");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("几何", new System.Windows.Forms.TreeNode[] {
            treeNode14});
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
            treeNode1.ImageIndex = 1;
            treeNode1.Name = "NodeJob";
            treeNode1.SelectedImageIndex = 1;
            treeNode1.Text = "流程";
            treeNode2.ImageIndex = 3;
            treeNode2.Name = "节点1";
            treeNode2.SelectedImageIndex = 3;
            treeNode2.Tag = "HalconToolInterface";
            treeNode2.Text = "Halcon窗口";
            treeNode3.ImageKey = "图像.png";
            treeNode3.Name = "节点2";
            treeNode3.SelectedImageIndex = 3;
            treeNode3.Text = "Basler";
            treeNode4.ImageKey = "图像.png";
            treeNode4.Name = "节点3";
            treeNode4.SelectedImageIndex = 3;
            treeNode4.Text = "HIKVision";
            treeNode5.ImageIndex = 4;
            treeNode5.Name = "节点0";
            treeNode5.Text = "获取图像";
            treeNode6.Name = "节点5";
            treeNode6.Text = "滤波";
            treeNode7.Name = "节点6";
            treeNode7.Text = "平滑";
            treeNode8.Name = "节点7";
            treeNode8.Text = "去噪";
            treeNode9.Name = "节点4";
            treeNode9.Text = "图像预处理";
            treeNode10.Name = "节点9";
            treeNode10.Text = "形状匹配";
            treeNode11.Name = "节点10";
            treeNode11.Text = "可变形匹配";
            treeNode12.Name = "节点11";
            treeNode12.Text = "灰度匹配";
            treeNode13.Name = "节点8";
            treeNode13.Text = "匹配";
            treeNode14.Name = "FindLine";
            treeNode14.Tag = "FindLine";
            treeNode14.Text = "找线";
            treeNode15.Name = "节点0";
            treeNode15.Text = "几何";
            this.tvw_ToolBox.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode5,
            treeNode9,
            treeNode13,
            treeNode15});
            this.tvw_ToolBox.SelectedImageIndex = 4;
            this.tvw_ToolBox.Size = new System.Drawing.Size(367, 545);
            this.tvw_ToolBox.TabIndex = 1;
            this.tvw_ToolBox.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvw_ToolBox_AfterSelect);
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
            this.imageList1.Images.SetKeyName(5, "20190709065619943_easyicon_net_256.ico");
            this.imageList1.Images.SetKeyName(6, "20190715063459237_easyicon_net_256.ico");
            this.imageList1.Images.SetKeyName(7, "20190716033549111_easyicon_net_128.ico");
            this.imageList1.Images.SetKeyName(8, "20190716033559344_easyicon_net_128.ico");
            this.imageList1.Images.SetKeyName(9, "avatar_guy_male_man_user_64px_1212479_easyicon.net.ico");
            this.imageList1.Images.SetKeyName(10, "avatar_male_man_user_64px_1212481_easyicon.net.ico");
            this.imageList1.Images.SetKeyName(11, "camera_96px_1157134_easyicon.net.ico");
            this.imageList1.Images.SetKeyName(12, "start.ico");
            this.imageList1.Images.SetKeyName(13, "stop.ico");
            this.imageList1.Images.SetKeyName(14, "User_64px_1115223_easyicon.net.ico");
            this.imageList1.Images.SetKeyName(15, "user_64px_1218470_easyicon.net.ico");
            this.imageList1.Images.SetKeyName(16, "保存.png");
            this.imageList1.Images.SetKeyName(17, "保存2.png");
            this.imageList1.Images.SetKeyName(18, "保存3.png");
            this.imageList1.Images.SetKeyName(19, "打开.png");
            this.imageList1.Images.SetKeyName(20, "复位.png");
            this.imageList1.Images.SetKeyName(21, "工具箱.ico");
            this.imageList1.Images.SetKeyName(22, "工具箱.png");
            this.imageList1.Images.SetKeyName(23, "镜头.png");
            this.imageList1.Images.SetKeyName(24, "开始.png");
            this.imageList1.Images.SetKeyName(25, "流程.ico");
            this.imageList1.Images.SetKeyName(26, "流程.png");
            this.imageList1.Images.SetKeyName(27, "流程图.png");
            this.imageList1.Images.SetKeyName(28, "删除.png");
            this.imageList1.Images.SetKeyName(29, "停止.png");
            this.imageList1.Images.SetKeyName(30, "图像.png");
            this.imageList1.Images.SetKeyName(31, "文件夹.png");
            this.imageList1.Images.SetKeyName(32, "相机.png");
            this.imageList1.Images.SetKeyName(33, "新建.png");
            this.imageList1.Images.SetKeyName(34, "新建2.png");
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
        public System.Windows.Forms.ImageList imageList1;
    }
}