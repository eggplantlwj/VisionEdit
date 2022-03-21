using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommonMethods;
using WeifenLuo.WinFormsUI.Docking;
using ToolLib.VisionJob;
using VisionJobFactory;

namespace ToolLib.VisionJob
{
    public partial class FormToolBox : DockContent
    {
        public FormToolBox()
        {
            InitializeComponent();
            VisionToolFactory.InitVisionToolTypeDic();
        }
        /// <summary>
        /// 窗体对象实例
        /// </summary>
        private static FormToolBox _instance;
        public static FormToolBox Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new FormToolBox();
                return _instance;
            }
        }

        private void tvw_ToolBox_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if(e.Node.Level == 0)
            {
                this.richTextBoxEx1.Text = e.Node.Text;
            }
            else if(e.Node.Level == 1)
            {
                object selectTag = tvw_ToolBox.SelectedNode.Tag;
                if (selectTag != null)
                {
                    IToolInfo insertTool = VisionToolFactory.CreateToolVision((ToolType)Enum.Parse(typeof(ToolType), selectTag.ToString()));
                    this.richTextBoxEx1.Text = insertTool.toolDescription;
                }
                else
                {
                    this.richTextBoxEx1.Text = "此工具尚未开发";
                }
            } 
        }

        private void tvw_ToolBox_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (tvw_ToolBox.SelectedNode.SelectedImageIndex == 0)         //如果双击的是文件夹节点，返回
                    return;
                if(VisionJobParams.pVisionProject.Project.Count == 0) // 若当前无流程，需要先建立项目和流程树，并对其进行初始化
                {
                    OperateProject.Instance.CreateNewJob();
                }
                if (VisionJobParams.pVisionProject.Project.Count > 0)        //再次确认已存在流程
                {
                    object selectTag = tvw_ToolBox.SelectedNode.Tag;
                    OperateTreeView.Instance.Add_Tool((ToolType)Enum.Parse(typeof(ToolType), selectTag.ToString())); 
                }
            }
            catch (Exception ex)
            {
                Logger.LoggerClass.WriteLog("添加流程失败！", ex);  
            }
        }

        

        private void tvw_ToolBox_Click(object sender, EventArgs e)
        {
           
        }
    }
}
