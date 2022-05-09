using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using Sunny.UI;

namespace ToolLib.VisionJob
{
    public partial class FormJobManage : DockContent
    {
        public FormJobManage()
        {
            InitializeComponent();
            _instance = this;
        }

        /// <summary>
        /// 窗体对象实例
        /// </summary>
        private static FormJobManage _instance;
        public static FormJobManage Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new FormJobManage();
                return _instance;
            }
        }

        private void FormJobManage_Load(object sender, EventArgs e)
        {
        }

        private void btnSignael_Click(object sender, EventArgs e)
        {
            string jobName = tabJobUnion.SelectedTab.Text;
            VisionJobParams.pVisionProject.Project[jobName].Run();
        }

        private void picNewJob_Click(object sender, EventArgs e)
        {
            UIInputForm myUIInputForm = new UIInputForm();
            myUIInputForm.Label.Text = "输入新建Job名称";
            if (myUIInputForm.ShowDialog() == DialogResult.OK)
            {
                string newJobName = myUIInputForm.Editor.Text;
                if(VisionJobParams.pVisionProject.Project.ContainsKey(newJobName))
                {
                    MessageBox.Show("新建流程名称重复，请重新建立！");
                    return;
                }
                else
                {
                    OperateProject.Instance.CreateNewJob(newJobName, true);
                }
            }
        }

        private void picSaveJob_Click(object sender, EventArgs e)
        {
            SaveFileDialog myDia = new SaveFileDialog();
            string jobName = tabJobUnion.SelectedTab.Text;
            myDia.Title = "保存job文件";
            myDia.Filter = "job文件(*.job)|*.job";
            myDia.FilterIndex = 1;
            myDia.FileName = jobName;//这里是key
            if (myDia.ShowDialog() == DialogResult.OK)
            {
                VisionJobParams.pVisionProject.SaveJob(jobName, myDia.FileName);
            }
        }

        private void picOpenJob_Click(object sender, EventArgs e)
        {
            UIInputForm myUIInputForm = new UIInputForm();
            myUIInputForm.Label.Text = "输入新建Job名称";
            if (myUIInputForm.ShowDialog() == DialogResult.OK)
            {
                OpenFileDialog myDia = new OpenFileDialog();
                if (myDia.ShowDialog() == DialogResult.OK)
                {
                    string newJobName = myUIInputForm.Editor.Text;
                    VisionJobParams.pVisionProject.LoadJob(newJobName, myDia.FileName);
                }
            }
               
        }
    }
}
