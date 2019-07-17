namespace VisionEdit.FormLib
{
    partial class FormJobManage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormJobManage));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.btnCycleRun = new System.Windows.Forms.Button();
            this.btnSignael = new System.Windows.Forms.Button();
            this.picDeleteJob = new System.Windows.Forms.PictureBox();
            this.picNewJob = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picDeleteJob)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNewJob)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Location = new System.Drawing.Point(-1, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(373, 588);
            this.tabControl1.TabIndex = 0;
            // 
            // btnCycleRun
            // 
            this.btnCycleRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCycleRun.Location = new System.Drawing.Point(218, 595);
            this.btnCycleRun.Name = "btnCycleRun";
            this.btnCycleRun.Size = new System.Drawing.Size(63, 33);
            this.btnCycleRun.TabIndex = 1;
            this.btnCycleRun.Text = "连续运行";
            this.btnCycleRun.UseVisualStyleBackColor = true;
            // 
            // btnSignael
            // 
            this.btnSignael.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSignael.Location = new System.Drawing.Point(297, 595);
            this.btnSignael.Name = "btnSignael";
            this.btnSignael.Size = new System.Drawing.Size(63, 33);
            this.btnSignael.TabIndex = 1;
            this.btnSignael.Text = "单次运行";
            this.btnSignael.UseVisualStyleBackColor = true;
            // 
            // picDeleteJob
            // 
            this.picDeleteJob.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.picDeleteJob.Image = global::VisionEdit.Properties.Resources.删除;
            this.picDeleteJob.Location = new System.Drawing.Point(53, 595);
            this.picDeleteJob.Name = "picDeleteJob";
            this.picDeleteJob.Size = new System.Drawing.Size(35, 40);
            this.picDeleteJob.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picDeleteJob.TabIndex = 2;
            this.picDeleteJob.TabStop = false;
            // 
            // picNewJob
            // 
            this.picNewJob.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.picNewJob.Image = global::VisionEdit.Properties.Resources.新建1;
            this.picNewJob.Location = new System.Drawing.Point(12, 595);
            this.picNewJob.Name = "picNewJob";
            this.picNewJob.Size = new System.Drawing.Size(35, 40);
            this.picNewJob.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picNewJob.TabIndex = 2;
            this.picNewJob.TabStop = false;
            // 
            // FormJobManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 636);
            this.Controls.Add(this.picDeleteJob);
            this.Controls.Add(this.picNewJob);
            this.Controls.Add(this.btnSignael);
            this.Controls.Add(this.btnCycleRun);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormJobManage";
            this.Text = "JobManage";
            this.Load += new System.EventHandler(this.FormJobManage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picDeleteJob)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNewJob)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnCycleRun;
        private System.Windows.Forms.Button btnSignael;
        private System.Windows.Forms.PictureBox picNewJob;
        private System.Windows.Forms.PictureBox picDeleteJob;
        public System.Windows.Forms.TabControl tabControl1;
    }
}