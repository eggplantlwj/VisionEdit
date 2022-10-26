namespace CaliperTool
{
    partial class FormCaliper
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCaliper));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtRunTool = new System.Windows.Forms.ToolStripButton();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lb_RunStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lb_RunTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cbx_edgeSelect = new System.Windows.Forms.ComboBox();
            this.cbx_polarity = new System.Windows.Forms.ComboBox();
            this.tbx_threshold = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbx_caliperLength1 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.tbx_Sigma = new System.Windows.Forms.TextBox();
            this.tbx_caliperLength2 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chBDispCaliperROI = new System.Windows.Forms.CheckBox();
            this.chBDispCross = new System.Windows.Forms.CheckBox();
            this.chBDispRec = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbx_resultStartRow = new System.Windows.Forms.TextBox();
            this.tbx_resultStartCol = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
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
            this.toolStrip1.Size = new System.Drawing.Size(1112, 32);
            this.toolStrip1.TabIndex = 5;
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
            this.statusStrip.Location = new System.Drawing.Point(0, 643);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip.Size = new System.Drawing.Size(1112, 22);
            this.statusStrip.TabIndex = 4;
            // 
            // lb_RunStatus
            // 
            this.lb_RunStatus.Name = "lb_RunStatus";
            this.lb_RunStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(16, 17);
            this.toolStripStatusLabel1.Text = "  ";
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
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1112, 611);
            this.splitContainer1.SplitterDistance = 642;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(642, 611);
            this.panel1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(465, 611);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Size = new System.Drawing.Size(457, 581);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "参数设置";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Size = new System.Drawing.Size(457, 581);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "图形显示";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox2);
            this.tabPage3.Location = new System.Drawing.Point(4, 26);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(457, 581);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "结果";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.cbx_edgeSelect);
            this.groupBox4.Controls.Add(this.cbx_polarity);
            this.groupBox4.Controls.Add(this.tbx_threshold);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.tbx_caliperLength1);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.tbx_Sigma);
            this.groupBox4.Controls.Add(this.tbx_caliperLength2);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(3, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(451, 573);
            this.groupBox4.TabIndex = 321;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "卡尺参数";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(19, 38);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 20);
            this.label14.TabIndex = 302;
            this.label14.Text = "卡尺长：";
            // 
            // cbx_edgeSelect
            // 
            this.cbx_edgeSelect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbx_edgeSelect.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbx_edgeSelect.FormattingEnabled = true;
            this.cbx_edgeSelect.Items.AddRange(new object[] {
            "all",
            "first",
            "last"});
            this.cbx_edgeSelect.Location = new System.Drawing.Point(109, 199);
            this.cbx_edgeSelect.Name = "cbx_edgeSelect";
            this.cbx_edgeSelect.Size = new System.Drawing.Size(282, 28);
            this.cbx_edgeSelect.TabIndex = 317;
            this.cbx_edgeSelect.Text = "all";
            // 
            // cbx_polarity
            // 
            this.cbx_polarity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbx_polarity.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbx_polarity.FormattingEnabled = true;
            this.cbx_polarity.Items.AddRange(new object[] {
            "从明到暗",
            "从暗到明"});
            this.cbx_polarity.Location = new System.Drawing.Point(109, 168);
            this.cbx_polarity.Name = "cbx_polarity";
            this.cbx_polarity.Size = new System.Drawing.Size(282, 28);
            this.cbx_polarity.TabIndex = 314;
            this.cbx_polarity.Text = "从明到暗";
            // 
            // tbx_threshold
            // 
            this.tbx_threshold.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_threshold.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_threshold.Location = new System.Drawing.Point(109, 102);
            this.tbx_threshold.Margin = new System.Windows.Forms.Padding(2);
            this.tbx_threshold.Name = "tbx_threshold";
            this.tbx_threshold.Size = new System.Drawing.Size(282, 26);
            this.tbx_threshold.TabIndex = 309;
            this.tbx_threshold.Text = "5";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(19, 201);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 20);
            this.label5.TabIndex = 279;
            this.label5.Text = "结果选择：";
            // 
            // tbx_caliperLength1
            // 
            this.tbx_caliperLength1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_caliperLength1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_caliperLength1.Location = new System.Drawing.Point(109, 35);
            this.tbx_caliperLength1.Margin = new System.Windows.Forms.Padding(2);
            this.tbx_caliperLength1.Name = "tbx_caliperLength1";
            this.tbx_caliperLength1.Size = new System.Drawing.Size(282, 26);
            this.tbx_caliperLength1.TabIndex = 301;
            this.tbx_caliperLength1.Text = "50";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(19, 71);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(65, 20);
            this.label16.TabIndex = 302;
            this.label16.Text = "卡尺宽：";
            // 
            // tbx_Sigma
            // 
            this.tbx_Sigma.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_Sigma.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_Sigma.Location = new System.Drawing.Point(111, 135);
            this.tbx_Sigma.Margin = new System.Windows.Forms.Padding(2);
            this.tbx_Sigma.Name = "tbx_Sigma";
            this.tbx_Sigma.Size = new System.Drawing.Size(280, 26);
            this.tbx_Sigma.TabIndex = 309;
            this.tbx_Sigma.Text = "2";
            // 
            // tbx_caliperLength2
            // 
            this.tbx_caliperLength2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_caliperLength2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_caliperLength2.Location = new System.Drawing.Point(109, 68);
            this.tbx_caliperLength2.Margin = new System.Windows.Forms.Padding(2);
            this.tbx_caliperLength2.Name = "tbx_caliperLength2";
            this.tbx_caliperLength2.Size = new System.Drawing.Size(282, 26);
            this.tbx_caliperLength2.TabIndex = 301;
            this.tbx_caliperLength2.Text = "10";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(21, 138);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(54, 20);
            this.label15.TabIndex = 310;
            this.label15.Text = "Sigma:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(19, 171);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 20);
            this.label11.TabIndex = 298;
            this.label11.Text = "极性：";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(19, 105);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(51, 20);
            this.label13.TabIndex = 310;
            this.label13.Text = "阈值：";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chBDispCaliperROI);
            this.groupBox3.Controls.Add(this.chBDispCross);
            this.groupBox3.Controls.Add(this.chBDispRec);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(3, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(451, 166);
            this.groupBox3.TabIndex = 320;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "显示";
            // 
            // chBDispCaliperROI
            // 
            this.chBDispCaliperROI.AutoSize = true;
            this.chBDispCaliperROI.Location = new System.Drawing.Point(29, 92);
            this.chBDispCaliperROI.Name = "chBDispCaliperROI";
            this.chBDispCaliperROI.Size = new System.Drawing.Size(99, 21);
            this.chBDispCaliperROI.TabIndex = 0;
            this.chBDispCaliperROI.Text = "结果显示交点";
            this.chBDispCaliperROI.UseVisualStyleBackColor = true;
            // 
            // chBDispCross
            // 
            this.chBDispCross.AutoSize = true;
            this.chBDispCross.Location = new System.Drawing.Point(29, 60);
            this.chBDispCross.Name = "chBDispCross";
            this.chBDispCross.Size = new System.Drawing.Size(99, 21);
            this.chBDispCross.TabIndex = 0;
            this.chBDispCross.Text = "结果显示交点";
            this.chBDispCross.UseVisualStyleBackColor = true;
            // 
            // chBDispRec
            // 
            this.chBDispRec.AutoSize = true;
            this.chBDispRec.Location = new System.Drawing.Point(29, 29);
            this.chBDispRec.Name = "chBDispRec";
            this.chBDispRec.Size = new System.Drawing.Size(111, 21);
            this.chBDispRec.TabIndex = 0;
            this.chBDispRec.Text = "结果显示矩形框";
            this.chBDispRec.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbx_resultStartRow);
            this.groupBox2.Controls.Add(this.tbx_resultStartCol);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(457, 127);
            this.groupBox2.TabIndex = 299;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "结果点";
            // 
            // tbx_resultStartRow
            // 
            this.tbx_resultStartRow.Location = new System.Drawing.Point(98, 28);
            this.tbx_resultStartRow.Margin = new System.Windows.Forms.Padding(2);
            this.tbx_resultStartRow.Name = "tbx_resultStartRow";
            this.tbx_resultStartRow.Size = new System.Drawing.Size(71, 23);
            this.tbx_resultStartRow.TabIndex = 102;
            // 
            // tbx_resultStartCol
            // 
            this.tbx_resultStartCol.Location = new System.Drawing.Point(98, 61);
            this.tbx_resultStartCol.Margin = new System.Windows.Forms.Padding(2);
            this.tbx_resultStartCol.Name = "tbx_resultStartCol";
            this.tbx_resultStartCol.Size = new System.Drawing.Size(71, 23);
            this.tbx_resultStartCol.TabIndex = 104;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 31);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 17);
            this.label7.TabIndex = 103;
            this.label7.Text = "中心行坐标：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(22, 64);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 17);
            this.label9.TabIndex = 105;
            this.label9.Text = "中心列坐标：";
            // 
            // FormCaliper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 665);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormCaliper";
            this.Text = "卡尺工具";
            this.Load += new System.EventHandler(this.FormCaliper_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtRunTool;
        private System.Windows.Forms.ToolStripStatusLabel lb_RunStatus;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lb_RunTime;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label14;
        public System.Windows.Forms.ComboBox cbx_edgeSelect;
        public System.Windows.Forms.ComboBox cbx_polarity;
        public System.Windows.Forms.TextBox tbx_threshold;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox tbx_caliperLength1;
        private System.Windows.Forms.Label label16;
        public System.Windows.Forms.TextBox tbx_Sigma;
        public System.Windows.Forms.TextBox tbx_caliperLength2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chBDispCaliperROI;
        private System.Windows.Forms.CheckBox chBDispCross;
        private System.Windows.Forms.CheckBox chBDispRec;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.TextBox tbx_resultStartRow;
        public System.Windows.Forms.TextBox tbx_resultStartCol;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.StatusStrip statusStrip;
    }
}