namespace FindLineTool
{
    partial class FormFindLine
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFindLine));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtRunTool = new System.Windows.Forms.ToolStripButton();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lb_RunStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lb_RunTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbx_minScore = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tbx_caliperLength2 = new System.Windows.Forms.TextBox();
            this.tbx_Sigma = new System.Windows.Forms.TextBox();
            this.tbx_caliperLength = new System.Windows.Forms.TextBox();
            this.tbx_threshold = new System.Windows.Forms.TextBox();
            this.tbx_caliperNum = new System.Windows.Forms.TextBox();
            this.cbx_polarity = new System.Windows.Forms.ComboBox();
            this.cbx_edgeSelect = new System.Windows.Forms.ComboBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chBDispCross = new System.Windows.Forms.CheckBox();
            this.chBDispRec = new System.Windows.Forms.CheckBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbx_resultEndCol = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbx_resultStartRow = new System.Windows.Forms.TextBox();
            this.tbx_resultStartCol = new System.Windows.Forms.TextBox();
            this.tbx_resultEndRow = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnSetModelPose = new Sunny.UI.UISymbolButton();
            this.toolStrip1.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtRunTool});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1002, 32);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtRunTool
            // 
            this.tsbtRunTool.Image = ((System.Drawing.Image)(resources.GetObject("tsbtRunTool.Image")));
            this.tsbtRunTool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtRunTool.Name = "tsbtRunTool";
            this.tsbtRunTool.Size = new System.Drawing.Size(85, 29);
            this.tsbtRunTool.Text = "运行工具";
            this.tsbtRunTool.Click += new System.EventHandler(this.tsbtRunTool_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lb_RunStatus,
            this.toolStripStatusLabel1,
            this.lb_RunTime});
            this.statusStrip.Location = new System.Drawing.Point(0, 631);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1002, 22);
            this.statusStrip.TabIndex = 3;
            this.statusStrip.Text = "statusStrip1";
            // 
            // lb_RunStatus
            // 
            this.lb_RunStatus.Name = "lb_RunStatus";
            this.lb_RunStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(120, 17);
            this.toolStripStatusLabel1.Text = "                            ";
            // 
            // lb_RunTime
            // 
            this.lb_RunTime.Name = "lb_RunTime";
            this.lb_RunTime.Size = new System.Drawing.Size(0, 17);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 32);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1002, 599);
            this.splitContainer1.SplitterDistance = 561;
            this.splitContainer1.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(561, 599);
            this.panel1.TabIndex = 1;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(437, 599);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(15);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(429, 566);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "参数";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSetModelPose);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.tbx_minScore);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.tbx_caliperLength2);
            this.groupBox1.Controls.Add(this.tbx_Sigma);
            this.groupBox1.Controls.Add(this.tbx_caliperLength);
            this.groupBox1.Controls.Add(this.tbx_threshold);
            this.groupBox1.Controls.Add(this.tbx_caliperNum);
            this.groupBox1.Controls.Add(this.cbx_polarity);
            this.groupBox1.Controls.Add(this.cbx_edgeSelect);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(15);
            this.groupBox1.Size = new System.Drawing.Size(423, 560);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "参数设定";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(36, 42);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 20);
            this.label6.TabIndex = 320;
            this.label6.Text = "最小分数：";
            // 
            // tbx_minScore
            // 
            this.tbx_minScore.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_minScore.Location = new System.Drawing.Point(142, 27);
            this.tbx_minScore.Margin = new System.Windows.Forms.Padding(2);
            this.tbx_minScore.Name = "tbx_minScore";
            this.tbx_minScore.Size = new System.Drawing.Size(250, 26);
            this.tbx_minScore.TabIndex = 319;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(36, 368);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 20);
            this.label5.TabIndex = 318;
            this.label5.Text = "结果选择：";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(36, 180);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(65, 20);
            this.label16.TabIndex = 326;
            this.label16.Text = "卡尺宽：";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(36, 134);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 20);
            this.label14.TabIndex = 327;
            this.label14.Text = "卡尺长：";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(38, 272);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(54, 20);
            this.label15.TabIndex = 330;
            this.label15.Text = "Sigma:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(36, 226);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(51, 20);
            this.label13.TabIndex = 331;
            this.label13.Text = "阈值：";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(36, 88);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 20);
            this.label12.TabIndex = 323;
            this.label12.Text = "卡尺数：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(36, 320);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 20);
            this.label11.TabIndex = 321;
            this.label11.Text = "极性：";
            // 
            // tbx_caliperLength2
            // 
            this.tbx_caliperLength2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_caliperLength2.Location = new System.Drawing.Point(142, 165);
            this.tbx_caliperLength2.Margin = new System.Windows.Forms.Padding(2);
            this.tbx_caliperLength2.Name = "tbx_caliperLength2";
            this.tbx_caliperLength2.Size = new System.Drawing.Size(250, 26);
            this.tbx_caliperLength2.TabIndex = 324;
            // 
            // tbx_Sigma
            // 
            this.tbx_Sigma.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_Sigma.Location = new System.Drawing.Point(144, 257);
            this.tbx_Sigma.Margin = new System.Windows.Forms.Padding(2);
            this.tbx_Sigma.Name = "tbx_Sigma";
            this.tbx_Sigma.Size = new System.Drawing.Size(250, 26);
            this.tbx_Sigma.TabIndex = 328;
            // 
            // tbx_caliperLength
            // 
            this.tbx_caliperLength.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_caliperLength.Location = new System.Drawing.Point(142, 119);
            this.tbx_caliperLength.Margin = new System.Windows.Forms.Padding(2);
            this.tbx_caliperLength.Name = "tbx_caliperLength";
            this.tbx_caliperLength.Size = new System.Drawing.Size(250, 26);
            this.tbx_caliperLength.TabIndex = 325;
            // 
            // tbx_threshold
            // 
            this.tbx_threshold.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_threshold.Location = new System.Drawing.Point(142, 211);
            this.tbx_threshold.Margin = new System.Windows.Forms.Padding(2);
            this.tbx_threshold.Name = "tbx_threshold";
            this.tbx_threshold.Size = new System.Drawing.Size(250, 26);
            this.tbx_threshold.TabIndex = 329;
            // 
            // tbx_caliperNum
            // 
            this.tbx_caliperNum.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_caliperNum.Location = new System.Drawing.Point(142, 73);
            this.tbx_caliperNum.Margin = new System.Windows.Forms.Padding(2);
            this.tbx_caliperNum.Name = "tbx_caliperNum";
            this.tbx_caliperNum.Size = new System.Drawing.Size(250, 26);
            this.tbx_caliperNum.TabIndex = 322;
            // 
            // cbx_polarity
            // 
            this.cbx_polarity.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbx_polarity.FormattingEnabled = true;
            this.cbx_polarity.Items.AddRange(new object[] {
            "从明到暗",
            "从暗到明"});
            this.cbx_polarity.Location = new System.Drawing.Point(142, 303);
            this.cbx_polarity.Name = "cbx_polarity";
            this.cbx_polarity.Size = new System.Drawing.Size(250, 28);
            this.cbx_polarity.TabIndex = 332;
            this.cbx_polarity.Text = "从明到暗";
            // 
            // cbx_edgeSelect
            // 
            this.cbx_edgeSelect.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbx_edgeSelect.FormattingEnabled = true;
            this.cbx_edgeSelect.Items.AddRange(new object[] {
            "all",
            "first",
            "last"});
            this.cbx_edgeSelect.Location = new System.Drawing.Point(142, 351);
            this.cbx_edgeSelect.Name = "cbx_edgeSelect";
            this.cbx_edgeSelect.Size = new System.Drawing.Size(250, 28);
            this.cbx_edgeSelect.TabIndex = 333;
            this.cbx_edgeSelect.Text = "all";
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(429, 566);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "搜素区域";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.groupBox3);
            this.tabPage4.Location = new System.Drawing.Point(4, 29);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(429, 566);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "图形";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chBDispCross);
            this.groupBox3.Controls.Add(this.chBDispRec);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(15);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(15);
            this.groupBox3.Size = new System.Drawing.Size(429, 566);
            this.groupBox3.TabIndex = 320;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "显示设定";
            // 
            // chBDispCross
            // 
            this.chBDispCross.AutoSize = true;
            this.chBDispCross.Location = new System.Drawing.Point(41, 72);
            this.chBDispCross.Name = "chBDispCross";
            this.chBDispCross.Size = new System.Drawing.Size(112, 24);
            this.chBDispCross.TabIndex = 0;
            this.chBDispCross.Text = "结果显示交点";
            this.chBDispCross.UseVisualStyleBackColor = true;
            this.chBDispCross.CheckedChanged += new System.EventHandler(this.DispSetCheck);
            // 
            // chBDispRec
            // 
            this.chBDispRec.AutoSize = true;
            this.chBDispRec.Location = new System.Drawing.Point(41, 41);
            this.chBDispRec.Name = "chBDispRec";
            this.chBDispRec.Size = new System.Drawing.Size(126, 24);
            this.chBDispRec.TabIndex = 0;
            this.chBDispRec.Text = "结果显示矩形框";
            this.chBDispRec.UseVisualStyleBackColor = true;
            this.chBDispRec.CheckedChanged += new System.EventHandler(this.DispSetCheck);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.groupBox2);
            this.tabPage5.Location = new System.Drawing.Point(4, 29);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(429, 566);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "结果";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbx_resultEndCol);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.tbx_resultStartRow);
            this.groupBox2.Controls.Add(this.tbx_resultStartCol);
            this.groupBox2.Controls.Add(this.tbx_resultEndRow);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(15);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(429, 566);
            this.groupBox2.TabIndex = 298;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "找线结果";
            // 
            // tbx_resultEndCol
            // 
            this.tbx_resultEndCol.Location = new System.Drawing.Point(137, 123);
            this.tbx_resultEndCol.Margin = new System.Windows.Forms.Padding(2);
            this.tbx_resultEndCol.Name = "tbx_resultEndCol";
            this.tbx_resultEndCol.Size = new System.Drawing.Size(258, 26);
            this.tbx_resultEndCol.TabIndex = 108;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(27, 126);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 20);
            this.label8.TabIndex = 109;
            this.label8.Text = "终点列坐标：";
            // 
            // tbx_resultStartRow
            // 
            this.tbx_resultStartRow.Location = new System.Drawing.Point(137, 24);
            this.tbx_resultStartRow.Margin = new System.Windows.Forms.Padding(2);
            this.tbx_resultStartRow.Name = "tbx_resultStartRow";
            this.tbx_resultStartRow.Size = new System.Drawing.Size(258, 26);
            this.tbx_resultStartRow.TabIndex = 102;
            // 
            // tbx_resultStartCol
            // 
            this.tbx_resultStartCol.Location = new System.Drawing.Point(137, 57);
            this.tbx_resultStartCol.Margin = new System.Windows.Forms.Padding(2);
            this.tbx_resultStartCol.Name = "tbx_resultStartCol";
            this.tbx_resultStartCol.Size = new System.Drawing.Size(258, 26);
            this.tbx_resultStartCol.TabIndex = 104;
            // 
            // tbx_resultEndRow
            // 
            this.tbx_resultEndRow.Location = new System.Drawing.Point(137, 90);
            this.tbx_resultEndRow.Margin = new System.Windows.Forms.Padding(2);
            this.tbx_resultEndRow.Name = "tbx_resultEndRow";
            this.tbx_resultEndRow.Size = new System.Drawing.Size(258, 26);
            this.tbx_resultEndRow.TabIndex = 106;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(27, 27);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 20);
            this.label7.TabIndex = 103;
            this.label7.Text = "起点行坐标：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(27, 93);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(93, 20);
            this.label10.TabIndex = 107;
            this.label10.Text = "终点行坐标：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(27, 60);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 20);
            this.label9.TabIndex = 105;
            this.label9.Text = "起点列坐标：";
            // 
            // btnSetModelPose
            // 
            this.btnSetModelPose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSetModelPose.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSetModelPose.IsScaled = false;
            this.btnSetModelPose.Location = new System.Drawing.Point(40, 437);
            this.btnSetModelPose.MinimumSize = new System.Drawing.Size(1, 1);
            this.btnSetModelPose.Name = "btnSetModelPose";
            this.btnSetModelPose.Size = new System.Drawing.Size(352, 35);
            this.btnSetModelPose.Symbol = 361771;
            this.btnSetModelPose.TabIndex = 334;
            this.btnSetModelPose.Text = "标定为模板位置";
            this.btnSetModelPose.Click += new System.EventHandler(this.btnSetModelPose_Click);
            // 
            // FormFindLine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 653);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormFindLine";
            this.Text = "找线工具";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormFindLine2_FormClosing);
            this.Load += new System.EventHandler(this.FormFindLine2_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtRunTool;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox tbx_minScore;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        public System.Windows.Forms.TextBox tbx_caliperLength2;
        public System.Windows.Forms.TextBox tbx_Sigma;
        public System.Windows.Forms.TextBox tbx_caliperLength;
        public System.Windows.Forms.TextBox tbx_threshold;
        public System.Windows.Forms.TextBox tbx_caliperNum;
        public System.Windows.Forms.ComboBox cbx_polarity;
        public System.Windows.Forms.ComboBox cbx_edgeSelect;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chBDispCross;
        private System.Windows.Forms.CheckBox chBDispRec;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.TextBox tbx_resultEndCol;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.TextBox tbx_resultStartRow;
        public System.Windows.Forms.TextBox tbx_resultStartCol;
        public System.Windows.Forms.TextBox tbx_resultEndRow;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ToolStripStatusLabel lb_RunStatus;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lb_RunTime;
        private Sunny.UI.UISymbolButton btnSetModelPose;
    }
}