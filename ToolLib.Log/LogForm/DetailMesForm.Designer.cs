namespace LogForm
{
    partial class DetailMesForm
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
            this.btnClose = new System.Windows.Forms.Button();
            this.Rtb_DetailMes = new System.Windows.Forms.RichTextBox();
            this.lb_Level = new System.Windows.Forms.Label();
            this.lb_Time = new System.Windows.Forms.Label();
            this.lb_Detail = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(427, 334);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(99, 33);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // Rtb_DetailMes
            // 
            this.Rtb_DetailMes.Location = new System.Drawing.Point(29, 140);
            this.Rtb_DetailMes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Rtb_DetailMes.Name = "Rtb_DetailMes";
            this.Rtb_DetailMes.Size = new System.Drawing.Size(503, 182);
            this.Rtb_DetailMes.TabIndex = 8;
            this.Rtb_DetailMes.Text = "";
            // 
            // lb_Level
            // 
            this.lb_Level.AutoSize = true;
            this.lb_Level.Location = new System.Drawing.Point(110, 57);
            this.lb_Level.Name = "lb_Level";
            this.lb_Level.Size = new System.Drawing.Size(0, 17);
            this.lb_Level.TabIndex = 3;
            // 
            // lb_Time
            // 
            this.lb_Time.AutoSize = true;
            this.lb_Time.Location = new System.Drawing.Point(110, 16);
            this.lb_Time.Name = "lb_Time";
            this.lb_Time.Size = new System.Drawing.Size(0, 17);
            this.lb_Time.TabIndex = 4;
            // 
            // lb_Detail
            // 
            this.lb_Detail.AutoSize = true;
            this.lb_Detail.Location = new System.Drawing.Point(25, 100);
            this.lb_Detail.Name = "lb_Detail";
            this.lb_Detail.Size = new System.Drawing.Size(79, 17);
            this.lb_Detail.TabIndex = 5;
            this.lb_Detail.Text = "Log详细信息";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Log级别：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "时间：";
            // 
            // DetailMesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(544, 381);
            this.ControlBox = false;
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.Rtb_DetailMes);
            this.Controls.Add(this.lb_Level);
            this.Controls.Add(this.lb_Time);
            this.Controls.Add(this.lb_Detail);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DetailMesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.DetailMesForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.RichTextBox Rtb_DetailMes;
        private System.Windows.Forms.Label lb_Level;
        private System.Windows.Forms.Label lb_Time;
        private System.Windows.Forms.Label lb_Detail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
    }
}