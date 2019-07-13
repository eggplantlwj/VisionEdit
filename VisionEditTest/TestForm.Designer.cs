namespace VisionEditTest
{
    partial class TestForm
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.btnAddTree = new System.Windows.Forms.Button();
            this.AddNodeOutPut = new System.Windows.Forms.Button();
            this.AddInputNode = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(434, 500);
            this.tabControl1.TabIndex = 0;
            // 
            // btnAddTree
            // 
            this.btnAddTree.Location = new System.Drawing.Point(462, 31);
            this.btnAddTree.Name = "btnAddTree";
            this.btnAddTree.Size = new System.Drawing.Size(91, 40);
            this.btnAddTree.TabIndex = 1;
            this.btnAddTree.Text = "添加JOB";
            this.btnAddTree.UseVisualStyleBackColor = true;
            this.btnAddTree.Click += new System.EventHandler(this.btnAddTree_Click);
            // 
            // AddNodeOutPut
            // 
            this.AddNodeOutPut.Location = new System.Drawing.Point(462, 101);
            this.AddNodeOutPut.Name = "AddNodeOutPut";
            this.AddNodeOutPut.Size = new System.Drawing.Size(90, 40);
            this.AddNodeOutPut.TabIndex = 2;
            this.AddNodeOutPut.Text = "添加输出节点";
            this.AddNodeOutPut.UseVisualStyleBackColor = true;
            this.AddNodeOutPut.Click += new System.EventHandler(this.AddNode_Click);
            // 
            // AddInputNode
            // 
            this.AddInputNode.Location = new System.Drawing.Point(462, 167);
            this.AddInputNode.Name = "AddInputNode";
            this.AddInputNode.Size = new System.Drawing.Size(91, 41);
            this.AddInputNode.TabIndex = 3;
            this.AddInputNode.Text = "添加输入节点";
            this.AddInputNode.UseVisualStyleBackColor = true;
            this.AddInputNode.Click += new System.EventHandler(this.AddInputNode_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 524);
            this.Controls.Add(this.AddInputNode);
            this.Controls.Add(this.AddNodeOutPut);
            this.Controls.Add(this.btnAddTree);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button btnAddTree;
        private System.Windows.Forms.Button AddNodeOutPut;
        private System.Windows.Forms.Button AddInputNode;
    }
}

