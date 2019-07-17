using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisionEdit.VisionTool;
using WeifenLuo.WinFormsUI.Docking;

namespace VisionEdit.FormLib
{
    public partial class FormToolBox : DockContent
    {
        FormLog myFormLog = null;
        FormJobManage myFormJobManage = null;

        public FormToolBox(FormLog inputFormLog, FormJobManage inputFormJob)
        {
            InitializeComponent();
            myFormLog = inputFormLog;
            myFormJobManage = inputFormJob;
            VisionToolFactory.InitVisionToolTypeDic();
        }

        private void tvw_ToolBox_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void tvw_ToolBox_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (tvw_ToolBox.SelectedNode.SelectedImageIndex == 0)         //如果双击的是文件夹节点，返回
                    return;
                if (myFormJobManage.tabControl1.TabPages.Count > 0)        //如果已存在流程
                {
                    object selectTag = tvw_ToolBox.SelectedNode.Tag;
                    Add_Tool((ToolType)Enum.Parse(typeof(ToolType), selectTag.ToString())); 
                }
                else
                {
                    //如果当前不存在可用流程，先创建流程，在添加工具
                    OperateJob.CreateNewJob();
                }
            }
            catch (Exception ex)
            {
                myFormLog.ShowLog("添加流程失败！" + ex.Message);   
            }
        }

        /// <summary>
        /// 向流程中添加工具，需要根据选择的工具名对工具类型等进行判断
        /// </summary>
        /// <param name="tool">工具类型</param>
        /// <param name="isInsert">插入位置，当为-1时，表示在末尾插入，当不为-1时，表示被插入的工具索引</param>
        internal void Add_Tool(ToolType tool, int insertPos = -1)
        {
            string toolName = GetNewToolName(tool.ToString());
            IToolInfo insertTool = VisionToolFactory.CreateToolVision(tool, toolName);
            TreeNode insertNode = new TreeNode();
            insertNode = GlobalParams.myJobTreeView.Nodes.Add("", insertTool.toolName, (int)tool, (int)tool); // 该工具对应的节点
            // 判断节点是否添加默认输入输出图
            for (int i = 0; i < insertTool.toolOutput.Count; i++)
            {
                TreeNode childrenNode = new TreeNode();
                childrenNode.Text = "-->" + insertTool.toolOutput[i].IOName;
                childrenNode.Tag = insertTool.toolOutput[i].ioType;
                insertNode.Nodes.Add(childrenNode);
            }
           

            GlobalParams.myVisionJob.L_toolList.Add(insertTool);
        }

        internal string GetNewToolName(string toolType)
        {
            try
            {
                if (!TreeView_Contains_Key(toolType))
                {
                    return toolType;
                }
                for (int i = 1; i < 101; i++)
                {
                    if (!TreeView_Contains_Key(toolType + "_" + i))
                    {
                        return toolType + "_" + i;
                    }
                }
                myFormLog.ShowLog("此工具已添加个数已达到数量上限，无法继续添加");
                return "Error";
            }
            catch (Exception ex)
            {
                myFormLog.ShowLog("添加出错！" + ex.Message);
                return "Error";
            }
        }

        /// <summary>
        /// 判断TreeView是否已经包含某节点
        /// </summary>
        /// <param name="key">节点文本</param>
        /// <returns>是否包含</returns>
        private bool TreeView_Contains_Key(string key)
        {
            try
            {
                foreach (TreeNode node in GlobalParams.myJobTreeView.Nodes)
                {
                    if (node.Text == key)
                        return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                myFormLog.ShowLog(ex.Message);
                return false;
            }
        }

        
    }
}
