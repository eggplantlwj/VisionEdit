/*
* ==============================================================================
*
* Filename: OperateTreeView
* Description: 
*
* Version: 1.0
* Created: 2021/2/26 10:09:32
*
* Author: liu.wenjie
*
* ==============================================================================
*/
using CommonMethods;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisionJobFactory;

namespace ToolLib.VisionJob
{
    public class OperateTreeView
    {
        private static OperateTreeView _instance;
        private static readonly object lockObject = new object();
        /// <summary>
        /// 禁止直接生成
        /// </summary>
        private OperateTreeView(){}
        /// <summary>
        /// 操作者单例模式调用
        /// </summary>
        public static OperateTreeView Instance
        {
            get
            {
                if(_instance == null)
                {
                    lock (lockObject)
                    {
                        if(_instance == null)
                        {
                            return _instance = new OperateTreeView();
                        }
                    }
                }
                return _instance;
            }
        }
        /// <summary>
        /// 获取当前流程所对应的流程树对象
        /// </summary>
        /// <param name="jobName">流程名</param>
        /// <returns>流程树控件对象</returns>
        public static TreeView GetJobTree(string jobName)
        {
            try
            {
                foreach (var myJob in VisionJobParams.pVisionProject.Project)
                {
                    if(myJob.Value.JobName == jobName)
                    {
                        return myJob.Value.GetJobTree();
                    }
                }
                return new TreeView();
            }
            catch (Exception ex)
            {
                Logger.LoggerClass.WriteLog("获取JobTree时出错", ex);
                return new TreeView();
            }
        }
        /// <summary>
        /// 向流程中添加工具，需要根据选择的工具名对工具类型等进行判断
        /// </summary>
        /// <param name="tool">工具类型</param>
        /// <param name="isInsert">插入位置，当为-1时，表示在末尾插入，当不为-1时，表示被插入的工具索引</param>
        public void Add_Tool(ToolType tool, bool newAddTool = true, int insertPos = -1, int imageKey = 0)
        {
            string jobName = FormJobManage.Instance.tabJobUnion.SelectedTab.Text;
            string toolName = GetNewToolName(jobName, tool.ToString());
            
            IToolInfo insertTool = VisionToolFactory.CreateToolVision(tool, toolName);
            TreeNode insertNode = new TreeNode();
            insertNode = GetJobTree(jobName).Nodes.Add("", insertTool.toolName, (int)tool, (int)tool); // 该工具对应的节点

            // 判断节点是否添加默认输入输出图
            // 输入
            for (int i = 0; i < insertTool.toolInput.Count; i++)
            {
                TreeNode childrenInputNode = insertNode.Nodes.Add("<--" + insertTool.toolInput[i].IOName);
                childrenInputNode.Tag = insertTool.toolInput[i].ioType;
                childrenInputNode.ForeColor = Color.DarkMagenta;
            }
            // 输出
            for (int i = 0; i < insertTool.toolOutput.Count; i++)
            {
                TreeNode childrenOutputNode = insertNode.Nodes.Add("-->" + insertTool.toolOutput[i].IOName);
                childrenOutputNode.Tag = insertTool.toolOutput[i].ioType;
                childrenOutputNode.ForeColor = Color.Blue;
            }
            insertNode.Expand();
            if(newAddTool)
            {
                VisionJobParams.pVisionProject.Project[jobName].L_toolList.Add(insertTool);
            }
            
        }

        internal string GetNewToolName(string jobName, string toolType)
        {
            try
            {
                if (!TreeView_Contains_Key(jobName, toolType))
                {
                    return toolType;
                }
                for (int i = 1; i < 101; i++)
                {
                    if (!TreeView_Contains_Key(jobName, toolType + "_" + i))
                    {
                        return toolType + "_" + i;
                    }
                }
                Logger.LoggerClass.WriteLog("此工具已添加个数已达到数量上限，无法继续添加", true);
                return "Error";
            }
            catch (Exception ex)
            {
                Logger.LoggerClass.WriteLog("添加出错！", ex);
                return "Error";
            }
        }

        /// <summary>
        /// 判断TreeView是否已经包含某节点
        /// </summary>
        /// <param name="key">节点文本</param>
        /// <returns>是否包含</returns>
        private bool TreeView_Contains_Key(string jobName, string key)
        {
            try
            {
                foreach (TreeNode node in VisionJobParams.pVisionProject.Project[jobName].GetJobTree().Nodes)
                {
                    if (node.Text == key)
                        return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Logger.LoggerClass.WriteLog("TreeView_Contains_Key 函数出错", ex);
                return false;
            }
        }
    }
}
