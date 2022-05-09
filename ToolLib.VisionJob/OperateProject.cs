/*
* ==============================================================================
*
* Filename: OperateJob
* Description: 
*
* Version: 1.0
* Created: 2021/2/25 15:23:31
*
* Author: liu.wenjie
*
* ==============================================================================
*/
using CommonMethods;
using FormLib;
using Logger;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace ToolLib.VisionJob
{
    public class OperateProject 
    {
        private static OperateProject _instance;
        private static readonly object lockObject = new object();
        private OperateProject() { }
        /// <summary>
        /// 操作者单例模式调用
        /// </summary>
        public static OperateProject Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (lockObject)
                    {
                        if (_instance == null)
                        {
                            _instance = new OperateProject();
                        }
                    }
                }
                return _instance;
            }
        }
        public void CreateNewJob(string jobName = "newJob", bool newAddJob = true)
        {
            TabPage newTab = new TabPage(jobName);
            newTab.Controls.Add(new TreeView());
            FormJobManage.Instance.tabJobUnion.TabPages.Add(newTab);
            if(newAddJob)
            {
                VisionJobParams.pVisionProject.Project.Add(jobName, new VisionJob(jobName));
                FormJobManage.Instance.tabJobUnion.SelectedTab = newTab;
               // newTab.Select();
            }
            InitJob(VisionJobParams.pVisionProject.Project[jobName]);
        }

        public void CreateNewJob(string jobName, VisionJob newJob, bool newAddJob = true)
        {
            TabPage newTab = new TabPage(jobName);
            newTab.Controls.Add(new TreeView());
            FormJobManage.Instance.tabJobUnion.TabPages.Add(newTab);
            if (newAddJob)
            {
                VisionJobParams.pVisionProject.Project.Add(jobName, newJob);
                FormJobManage.Instance.tabJobUnion.SelectedTab = newTab;
                // newTab.Select();
            }
            newJob.JobName = jobName;
            InitJob(VisionJobParams.pVisionProject.Project[jobName]);
        }

        public void AddDispImageindow(DockPanel myPanel, DockState myState, string windowName)
        {
            if(VisionJobParams.pVisionProject.Project.ContainsKey(windowName))
            {
                FormImageWindow myImageWindow =  VisionJobParams.pVisionProject.Project[windowName].myHalconWindow;
                if(myImageWindow == null)
                {
                    myImageWindow = new FormImageWindow();
                }
                myImageWindow.Text = windowName + "-图像";
                myImageWindow.Show(myPanel, myState);
            }
        }

        public void SaveJob()
        {
           // Serialize.BinarySerialize($"{VisionJobParams.sSysConfigPath}Vision.prj" , VisionJobParams.myProject);
            //SaveFileDialog saveFileDialog = new SaveFileDialog();
            //saveFileDialog.Title = "请指定项目保存路径";
            //saveFileDialog.Filter = "项目文件|*.pjt";
            //saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            //if (saveFileDialog.ShowDialog() == DialogResult.OK)
            //{
            //    try
            //    {
            //        Serialize.BinarySerialize(saveFileDialog.FileName, VisionJobParams.myProject);
            //        LoggerClass.WriteLog("项目保存成功");
            //    }
            //    catch (Exception ex)
            //    {
            //        LoggerClass.WriteLog("项目保存失败", ex);
            //    } 
            //}
        }


        public void InitJob(VisionJob myJob)
        {
            myJob.GetJobTree().ImageList = FormToolBox.Instance.imageListTool;
            if (myJob.L_toolList.Count > 0)
            {
                ReCoverJob(myJob);
            }
            myJob.GetJobTree().Dock = DockStyle.Fill;
            
            myJob.GetJobTree().Font = new Font("微软雅黑", 9, FontStyle.Bold);

            myJob.GetJobTree().Scrollable = true;
            myJob.GetJobTree().ItemHeight = 20;
            myJob.GetJobTree().ShowLines = false;
            myJob.GetJobTree().AllowDrop = true;

            // 在窗体UI出现变化时，更新画线
            myJob.GetJobTree().AfterSelect += myJob.tvw_job_AfterSelect;
            myJob.GetJobTree().ChangeUICues += myJob.MyJobTreeView_ChangeUICues;
            FormJobManage.Instance.SizeChanged += myJob.tbc_jobs_SelectedIndexChanged;
            //节点间拖拽
            myJob.GetJobTree().ItemDrag += new ItemDragEventHandler(myJob.TvwJob_ItemDrag);
            myJob.GetJobTree().DragEnter += new DragEventHandler(myJob.TvwJob_DragEnter);
            myJob.GetJobTree().DragDrop += new DragEventHandler(myJob.TvwJob_DragDrop);

            //以下事件为画线事件
            myJob.GetJobTree().MouseMove += myJob.DrawLineWithoutRefresh;
            myJob.GetJobTree().AfterExpand += myJob.Draw_Line;
            myJob.GetJobTree().AfterCollapse += myJob.Draw_Line;
            // 在流程节点上操作时
            myJob.GetJobTree().MouseDoubleClick += TreeViewJob_DoubleClick; ;
            myJob.GetJobTree().MouseClick += myJob.tvw_job_MouseClick;
            Application.DoEvents();
            if (myJob.GetJobTree().Nodes.Count > 0)
            {
                //默认选中第一个工具节点
                myJob.GetJobTree().SelectedNode = myJob.GetJobTree().Nodes[0];
            }
            //展开已默认添加的工具的输入输出项
            myJob.GetJobTree().ExpandAll();
        }
        public void InitJob(Dictionary<string, VisionJob> myProject, string jobName)
        {
            myProject[jobName].GetJobTree().Dock = DockStyle.Fill;
            myProject[jobName].GetJobTree().ImageList = FormToolBox.Instance.imageListTool;
            myProject[jobName].GetJobTree().Font = new Font("微软雅黑", 9, FontStyle.Bold);

            myProject[jobName].GetJobTree().Scrollable = true;
            myProject[jobName].GetJobTree().ItemHeight = 20;
            myProject[jobName].GetJobTree().ShowLines = false;
            myProject[jobName].GetJobTree().AllowDrop = true;
            //myTreeView.ImageList = Job.imageList;

            // 在窗体UI出现变化时，更新画线
            myProject[jobName].GetJobTree().AfterSelect += myProject[jobName].tvw_job_AfterSelect;
            myProject[jobName].GetJobTree().ChangeUICues += myProject[jobName].MyJobTreeView_ChangeUICues;
            FormJobManage.Instance.SizeChanged += myProject[jobName].tbc_jobs_SelectedIndexChanged;
            //节点间拖拽
            myProject[jobName].GetJobTree().ItemDrag += new ItemDragEventHandler(myProject[jobName].TvwJob_ItemDrag);
            myProject[jobName].GetJobTree().DragEnter += new DragEventHandler(myProject[jobName].TvwJob_DragEnter);
            myProject[jobName].GetJobTree().DragDrop += new DragEventHandler(myProject[jobName].TvwJob_DragDrop);

            //以下事件为画线事件
            myProject[jobName].GetJobTree().MouseMove += myProject[jobName].DrawLineWithoutRefresh;
            myProject[jobName].GetJobTree().AfterExpand += myProject[jobName].Draw_Line;
            myProject[jobName].GetJobTree().AfterCollapse += myProject[jobName].Draw_Line;
            // 在流程节点上操作时
            myProject[jobName].GetJobTree().MouseDoubleClick += TreeViewJob_DoubleClick; ;
            myProject[jobName].GetJobTree().MouseClick += myProject[jobName].tvw_job_MouseClick;
            Application.DoEvents();
            if(myProject[jobName].GetJobTree().Nodes.Count > 0)
            {
                //默认选中第一个工具节点
                myProject[jobName].GetJobTree().SelectedNode = myProject[jobName].GetJobTree().Nodes[0];
            }
            //展开已默认添加的工具的输入输出项
            myProject[jobName].GetJobTree().ExpandAll();
        }

        /// <summary>
        /// TreeView双击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void TreeViewJob_DoubleClick(object sender, MouseEventArgs e)
        {
            //判断是否在节点上双击
            object toolClass = new object();
            string jobName = FormJobManage.Instance.tabJobUnion.SelectedTab.Text;
            TreeViewHitTestInfo test = VisionJobParams.pVisionProject.Project[jobName].GetJobTree().HitTest(e.X, e.Y);
            TreeNode selectNode = test.Node.Level == 0 ? test.Node : test.Node.Parent;
            selectNode.ExpandAll();
            for (int i = 0; i < VisionJobParams.pVisionProject.Project[jobName].L_toolList.Count; i++)
            {
                if (selectNode.Text == VisionJobParams.pVisionProject.Project[jobName].L_toolList[i].toolName)
                {
                    string AssemblyName = VisionJobParams.pVisionProject.Project[jobName].L_toolList[i].FormToolName.Split('.')[0];
                    string className = VisionJobParams.pVisionProject.Project[jobName].L_toolList[i].FormToolName;
                    toolClass = VisionJobParams.pVisionProject.Project[jobName].L_toolList[i];
                    IToolInfo.FormTool = (Form)Assembly.Load(AssemblyName).CreateInstance(className, false, BindingFlags.Default, null, new object[] { toolClass }, null, null);
                    IToolInfo.FormTool.ShowDialog();
                    //VisionJobParams.myProject[jobName].L_toolList[i].SetFormTool(IToolInfo.FormTool);
                    //VisionJobParams.myProject[jobName].L_toolList[i].GetFormTool().ShowDialog();
                    //VisionJobParams.myProject[jobName].L_toolList[i].FormTool = (Form)Assembly.Load(AssemblyName).CreateInstance(className, false, BindingFlags.Default, null, new object[] { toolClass }, null, null);
                    //VisionJobParams.myProject[jobName].L_toolList[i].FormTool.ShowDialog();
                }
            }
        }
        /// <summary>
        /// 恢复工具之间的关系和连线
        /// </summary>
        private void ReCoverJob(VisionJob myJob, ImageList inputImageList = null)
        {
            //反序列化各工具
            myJob.D_itemAndSource.Clear();
            for (int i = 0; i < myJob.L_toolList.Count; i++)
            {
                TreeNode node = myJob.GetJobTree().Nodes.Add(myJob.L_toolList[i].toolName);
                for (int j = 0; j < myJob.L_toolList[i].toolInput.Count; j++)
                {
                    TreeNode treeNode;
                    //因为OutputBox只有源，所以此处特殊处理
                    if (myJob.L_toolList[i].toolType != ToolType.Output)
                        treeNode = node.Nodes.Add("<--" + myJob.L_toolList[i].toolInput[j].IOName + myJob.L_toolList[i].toolInput[j].value);
                    else
                        treeNode = node.Nodes.Add("<--" + myJob.L_toolList[i].toolInput[j].IOName);

                    treeNode.Tag = myJob.L_toolList[i].toolInput[j].ioType;
                    treeNode.ForeColor = Color.DarkMagenta;

                    //解析需要连线的节点对
                    if (treeNode.ToString().Contains("《-"))
                    {
                        string toolNodeText = Regex.Split(myJob.L_toolList[i].toolInput[j].value.ToString(), "->")[0].Substring(3);
                        string a = myJob.L_toolList[i].toolInput[j].value.ToString();
                        string toolIONodeText = "-->" + Regex.Split(myJob.L_toolList[i].toolInput[j].value.ToString(), "->")[1];
                        myJob.D_itemAndSource.Add(treeNode, myJob.GetToolIONodeByNodeText(toolNodeText, toolIONodeText));
                    }
                    if (myJob.L_toolList[i].toolType == ToolType.Output)
                    {
                        string toolNodeText = Regex.Split(treeNode.Text, "->")[0].Substring(3);
                        string toolIONodeText = Regex.Split(treeNode.Text, "->")[1];
                        myJob.D_itemAndSource.Add(treeNode, myJob.GetToolIONodeByNodeText(toolNodeText, "-->" + toolIONodeText));
                    }
                }
                for (int k = 0; k < myJob.L_toolList[i].toolOutput.Count; k++)
                {
                    TreeNode treeNode = node.Nodes.Add("-->" + myJob.L_toolList[i].toolOutput[k].IOName);

                    treeNode.Tag = myJob.L_toolList[i].toolOutput[k].ioType;
                    treeNode.ForeColor = Color.Blue;
                }
            }

            // UpdateJobTreeIcon(job.jobName);

            //默认选中第一个节点
            //if (tvw_job.Nodes.Count > 0)
            //    tvw_job.SelectedNode = tvw_job.Nodes[0];
        }

    }
}
