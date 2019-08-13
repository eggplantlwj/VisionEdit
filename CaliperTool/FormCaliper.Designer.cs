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
            this.tbx_resultStartRow = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tbx_caliperLength2 = new System.Windows.Forms.TextBox();
            this.tbx_Sigma = new System.Windows.Forms.TextBox();
            this.tbx_caliperLength1 = new System.Windows.Forms.TextBox();
            this.tbx_threshold = new System.Windows.Forms.TextBox();
            this.cbx_polarity = new System.Windows.Forms.ComboBox();
            this.btn_runCaliperool = new System.Windows.Forms.Button();
            this.btn_moveCliperRegion = new System.Windows.Forms.Button();
            this.cbx_edgeSelect = new System.Windows.Forms.ComboBox();
            this.tbx_resultStartCol = new System.Windows.Forms.TextBox();
            this.txbLog = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chBDispCaliperROI = new System.Windows.Forms.CheckBox();
            this.chBDispCross = new System.Windows.Forms.CheckBox();
            this.chBDispRec = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbx_expectPhi = new System.Windows.Forms.TextBox();
            this.tbx_expectCenterCol = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbx_expectCenterRow = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbx_resultStartRow
            // 
            this.tbx_resultStartRow.Location = new System.Drawing.Point(98, 28);
            this.tbx_resultStartRow.Margin = new System.Windows.Forms.Padding(2);
            this.tbx_resultStartRow.Name = "tbx_resultStartRow";
            this.tbx_resultStartRow.Size = new System.Drawing.Size(71, 21);
            this.tbx_resultStartRow.TabIndex = 102;
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
            // tbx_caliperLength2
            // 
            this.tbx_caliperLength2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_caliperLength2.Location = new System.Drawing.Point(109, 68);
            this.tbx_caliperLength2.Margin = new System.Windows.Forms.Padding(2);
            this.tbx_caliperLength2.Name = "tbx_caliperLength2";
            this.tbx_caliperLength2.Size = new System.Drawing.Size(92, 26);
            this.tbx_caliperLength2.TabIndex = 301;
            // 
            // tbx_Sigma
            // 
            this.tbx_Sigma.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_Sigma.Location = new System.Drawing.Point(111, 135);
            this.tbx_Sigma.Margin = new System.Windows.Forms.Padding(2);
            this.tbx_Sigma.Name = "tbx_Sigma";
            this.tbx_Sigma.Size = new System.Drawing.Size(92, 26);
            this.tbx_Sigma.TabIndex = 309;
            // 
            // tbx_caliperLength1
            // 
            this.tbx_caliperLength1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_caliperLength1.Location = new System.Drawing.Point(109, 35);
            this.tbx_caliperLength1.Margin = new System.Windows.Forms.Padding(2);
            this.tbx_caliperLength1.Name = "tbx_caliperLength1";
            this.tbx_caliperLength1.Size = new System.Drawing.Size(92, 26);
            this.tbx_caliperLength1.TabIndex = 301;
            // 
            // tbx_threshold
            // 
            this.tbx_threshold.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx_threshold.Location = new System.Drawing.Point(109, 102);
            this.tbx_threshold.Margin = new System.Windows.Forms.Padding(2);
            this.tbx_threshold.Name = "tbx_threshold";
            this.tbx_threshold.Size = new System.Drawing.Size(92, 26);
            this.tbx_threshold.TabIndex = 309;
            // 
            // cbx_polarity
            // 
            this.cbx_polarity.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbx_polarity.FormattingEnabled = true;
            this.cbx_polarity.Items.AddRange(new object[] {
            "从明到暗",
            "从暗到明"});
            this.cbx_polarity.Location = new System.Drawing.Point(109, 168);
            this.cbx_polarity.Name = "cbx_polarity";
            this.cbx_polarity.Size = new System.Drawing.Size(92, 28);
            this.cbx_polarity.TabIndex = 314;
            this.cbx_polarity.Text = "从明到暗";
            // 
            // btn_runCaliperool
            // 
            this.btn_runCaliperool.BackColor = System.Drawing.Color.White;
            this.btn_runCaliperool.Location = new System.Drawing.Point(430, 355);
            this.btn_runCaliperool.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_runCaliperool.Name = "btn_runCaliperool";
            this.btn_runCaliperool.Size = new System.Drawing.Size(90, 48);
            this.btn_runCaliperool.TabIndex = 270;
            this.btn_runCaliperool.Text = "运行";
            this.btn_runCaliperool.UseVisualStyleBackColor = false;
            this.btn_runCaliperool.Click += new System.EventHandler(this.btn_runCaliperool_Click);
            // 
            // btn_moveCliperRegion
            // 
            this.btn_moveCliperRegion.BackColor = System.Drawing.Color.White;
            this.btn_moveCliperRegion.Location = new System.Drawing.Point(296, 355);
            this.btn_moveCliperRegion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_moveCliperRegion.Name = "btn_moveCliperRegion";
            this.btn_moveCliperRegion.Size = new System.Drawing.Size(90, 48);
            this.btn_moveCliperRegion.TabIndex = 269;
            this.btn_moveCliperRegion.Text = "编辑卡尺";
            this.btn_moveCliperRegion.UseVisualStyleBackColor = false;
            this.btn_moveCliperRegion.Click += new System.EventHandler(this.btn_moveCliperRegion_Click);
            // 
            // cbx_edgeSelect
            // 
            this.cbx_edgeSelect.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbx_edgeSelect.FormattingEnabled = true;
            this.cbx_edgeSelect.Items.AddRange(new object[] {
            "all",
            "first",
            "last"});
            this.cbx_edgeSelect.Location = new System.Drawing.Point(109, 199);
            this.cbx_edgeSelect.Name = "cbx_edgeSelect";
            this.cbx_edgeSelect.Size = new System.Drawing.Size(92, 28);
            this.cbx_edgeSelect.TabIndex = 317;
            this.cbx_edgeSelect.Text = "all";
            // 
            // tbx_resultStartCol
            // 
            this.tbx_resultStartCol.Location = new System.Drawing.Point(98, 61);
            this.tbx_resultStartCol.Margin = new System.Windows.Forms.Padding(2);
            this.tbx_resultStartCol.Name = "tbx_resultStartCol";
            this.tbx_resultStartCol.Size = new System.Drawing.Size(71, 21);
            this.tbx_resultStartCol.TabIndex = 104;
            // 
            // txbLog
            // 
            this.txbLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbLog.Location = new System.Drawing.Point(1, 487);
            this.txbLog.Name = "txbLog";
            this.txbLog.ReadOnly = true;
            this.txbLog.Size = new System.Drawing.Size(1127, 21);
            this.txbLog.TabIndex = 276;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(1, 2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.Color.White;
            this.splitContainer1.Panel2.Controls.Add(this.groupBox4);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel2.Controls.Add(this.btn_runCaliperool);
            this.splitContainer1.Panel2.Controls.Add(this.btn_moveCliperRegion);
            this.splitContainer1.Size = new System.Drawing.Size(1127, 479);
            this.splitContainer1.SplitterDistance = 562;
            this.splitContainer1.TabIndex = 275;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(562, 479);
            this.panel1.TabIndex = 272;
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
            this.groupBox4.Location = new System.Drawing.Point(14, 166);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(224, 271);
            this.groupBox4.TabIndex = 320;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "卡尺参数";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chBDispCaliperROI);
            this.groupBox3.Controls.Add(this.chBDispCross);
            this.groupBox3.Controls.Add(this.chBDispRec);
            this.groupBox3.Location = new System.Drawing.Point(296, 170);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(213, 124);
            this.groupBox3.TabIndex = 319;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "显示";
            // 
            // chBDispCaliperROI
            // 
            this.chBDispCaliperROI.AutoSize = true;
            this.chBDispCaliperROI.Location = new System.Drawing.Point(29, 92);
            this.chBDispCaliperROI.Name = "chBDispCaliperROI";
            this.chBDispCaliperROI.Size = new System.Drawing.Size(96, 16);
            this.chBDispCaliperROI.TabIndex = 0;
            this.chBDispCaliperROI.Text = "结果显示交点";
            this.chBDispCaliperROI.UseVisualStyleBackColor = true;
            // 
            // chBDispCross
            // 
            this.chBDispCross.AutoSize = true;
            this.chBDispCross.Location = new System.Drawing.Point(29, 60);
            this.chBDispCross.Name = "chBDispCross";
            this.chBDispCross.Size = new System.Drawing.Size(96, 16);
            this.chBDispCross.TabIndex = 0;
            this.chBDispCross.Text = "结果显示交点";
            this.chBDispCross.UseVisualStyleBackColor = true;
            // 
            // chBDispRec
            // 
            this.chBDispRec.AutoSize = true;
            this.chBDispRec.Location = new System.Drawing.Point(29, 29);
            this.chBDispRec.Name = "chBDispRec";
            this.chBDispRec.Size = new System.Drawing.Size(108, 16);
            this.chBDispRec.TabIndex = 0;
            this.chBDispRec.Text = "结果显示矩形框";
            this.chBDispRec.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbx_expectPhi);
            this.groupBox1.Controls.Add(this.tbx_expectCenterCol);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbx_expectCenterRow);
            this.groupBox1.Location = new System.Drawing.Point(14, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(224, 127);
            this.groupBox1.TabIndex = 318;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "输入坐标";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 89);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 276;
            this.label3.Text = "卡尺角度：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 272;
            this.label1.Text = "中心行坐标：";
            // 
            // tbx_expectPhi
            // 
            this.tbx_expectPhi.Location = new System.Drawing.Point(131, 86);
            this.tbx_expectPhi.Margin = new System.Windows.Forms.Padding(2);
            this.tbx_expectPhi.Name = "tbx_expectPhi";
            this.tbx_expectPhi.Size = new System.Drawing.Size(71, 21);
            this.tbx_expectPhi.TabIndex = 275;
            // 
            // tbx_expectCenterCol
            // 
            this.tbx_expectCenterCol.Location = new System.Drawing.Point(131, 57);
            this.tbx_expectCenterCol.Margin = new System.Windows.Forms.Padding(2);
            this.tbx_expectCenterCol.Name = "tbx_expectCenterCol";
            this.tbx_expectCenterCol.Size = new System.Drawing.Size(71, 21);
            this.tbx_expectCenterCol.TabIndex = 273;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 60);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 274;
            this.label2.Text = "中心列坐标：";
            // 
            // tbx_expectCenterRow
            // 
            this.tbx_expectCenterRow.Location = new System.Drawing.Point(131, 28);
            this.tbx_expectCenterRow.Margin = new System.Windows.Forms.Padding(2);
            this.tbx_expectCenterRow.Name = "tbx_expectCenterRow";
            this.tbx_expectCenterRow.Size = new System.Drawing.Size(71, 21);
            this.tbx_expectCenterRow.TabIndex = 271;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbx_resultStartRow);
            this.groupBox2.Controls.Add(this.tbx_resultStartCol);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Location = new System.Drawing.Point(296, 19);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(201, 127);
            this.groupBox2.TabIndex = 297;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "结果点";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 31);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 12);
            this.label7.TabIndex = 103;
            this.label7.Text = "中心行坐标：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(22, 64);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 12);
            this.label9.TabIndex = 105;
            this.label9.Text = "中心列坐标：";
            // 
            // FormCaliper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1132, 509);
            this.Controls.Add(this.txbLog);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormCaliper";
            this.Text = "卡尺工具";
            this.Load += new System.EventHandler(this.FormCaliper_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.TextBox tbx_resultStartRow;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        public System.Windows.Forms.TextBox tbx_caliperLength2;
        public System.Windows.Forms.TextBox tbx_Sigma;
        public System.Windows.Forms.TextBox tbx_caliperLength1;
        public System.Windows.Forms.TextBox tbx_threshold;
        public System.Windows.Forms.ComboBox cbx_polarity;
        public System.Windows.Forms.Button btn_runCaliperool;
        private System.Windows.Forms.Button btn_moveCliperRegion;
        public System.Windows.Forms.ComboBox cbx_edgeSelect;
        public System.Windows.Forms.TextBox tbx_resultStartCol;
        public System.Windows.Forms.TextBox txbLog;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chBDispCross;
        private System.Windows.Forms.CheckBox chBDispRec;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox tbx_expectPhi;
        public System.Windows.Forms.TextBox tbx_expectCenterCol;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox tbx_expectCenterRow;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox chBDispCaliperROI;
    }
}