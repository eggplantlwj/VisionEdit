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
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Location = new System.Drawing.Point(-1, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(373, 586);
            this.tabControl1.TabIndex = 0;
            // 
            // btnCycleRun
            // 
            this.btnCycleRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCycleRun.Location = new System.Drawing.Point(199, 595);
            this.btnCycleRun.Name = "btnCycleRun";
            this.btnCycleRun.Size = new System.Drawing.Size(74, 33);
            this.btnCycleRun.TabIndex = 1;
            this.btnCycleRun.Text = "连续运行";
            this.btnCycleRun.UseVisualStyleBackColor = true;
            // 
            // btnSignael
            // 
            this.btnSignael.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSignael.Location = new System.Drawing.Point(286, 595);
            this.btnSignael.Name = "btnSignael";
            this.btnSignael.Size = new System.Drawing.Size(74, 33);
            this.btnSignael.TabIndex = 1;
            this.btnSignael.Text = "单次运行";
            this.btnSignael.UseVisualStyleBackColor = true;
            // 
            // FormJobManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 636);
            this.Controls.Add(this.btnSignael);
            this.Controls.Add(this.btnCycleRun);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormJobManage";
            this.Text = "JobManage";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button btnCycleRun;
        private System.Windows.Forms.Button btnSignael;
    }
}