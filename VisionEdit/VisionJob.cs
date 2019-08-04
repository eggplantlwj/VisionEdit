using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommonMethods;
using VisionEdit.FormLib;

namespace VisionEdit
{
    public class VisionJob : IVisionJob
    {
        public delegate void CreateLineDelegate(TreeView inputTreeView, TreeNode startNode, TreeNode endNode);
        CreateLineDelegate createLineDelegateFun;
        public TreeView tvwOnWorkJob = new TreeView();
        FormLog myFormLog = null;

        public VisionJob(TreeView inputTreeView, FormLog inputFormLog, string jobName)
        {
            tvwOnWorkJob = inputTreeView;
            this.myFormLog = inputFormLog;
            this.JobName = jobName;
            createLineDelegateFun = new CreateLineDelegate(CreateLine);
        }

       


        /// <summary>
        /// 拖动工具节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void TvwJob_ItemDrag(object sender, ItemDragEventArgs e)//左键拖动  
        {
            try
            {
                if (((TreeView)sender).SelectedNode != null)
                {
                    if (((TreeView)sender).SelectedNode.Level == 1)          //输入输出不允许拖动
                    {
                        tvwOnWorkJob.DoDragDrop(e.Item, DragDropEffects.Move);
                    }

                    else if (e.Button == MouseButtons.Left)
                    {
                        tvwOnWorkJob.DoDragDrop(e.Item, DragDropEffects.Move);
                    }
                }
            }
            catch (Exception ex)
            {
                myFormLog.ShowLog("拖动节点出错，描述： " + ex.Message);
            }
        }

        /// <summary>
        /// 节点拖动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void TvwJob_DragEnter(object sender, DragEventArgs e)
        {
            try
            {
                if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode"))
                {
                    e.Effect = DragDropEffects.Move;
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                }
            }
            catch (Exception ex)
            {
                myFormLog.ShowLog("节点拖动出错，描述： " + ex.Message);
            }
        }

        /// <summary>
        /// 释放被拖动的节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void TvwJob_DragDrop(object sender, DragEventArgs e)//拖动  
        {
            try
            {
                //获得拖放中的节点
                TreeNode moveNode = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode");
                //根据鼠标坐标确定要移动到的目标节点  
                System.Drawing.Point pt;
                TreeNode targeNode;  // 目标节点
                pt = ((TreeView)(sender)).PointToClient(new System.Drawing.Point(e.X, e.Y));
                targeNode = tvwOnWorkJob.GetNodeAt(pt);
                //如果目标节点无子节点则添加为同级节点,反之添加到下级节点的未端  
                if (moveNode == targeNode)       //若是把自己拖放到自己，不可，返回
                    return;

                if (targeNode == null)       //目标节点为null，就是把节点拖到了空白区域，不可，直接返回
                    return;

                if (moveNode.Level == 1 && targeNode.Level == 1 && moveNode.Parent == targeNode.Parent)          //都是输入输出节点，内部拖动排序
                {
                    moveNode.Remove();
                    targeNode.Parent.Nodes.Insert(targeNode.Index, moveNode);
                    return;
                }

                if (moveNode.Level == 0)        //  被拖动的是子节点，也就是工具节点
                {
                    if (targeNode.Level == 0) // 目标也是工具节点
                    {
                        moveNode.Remove();
                        tvwOnWorkJob.Nodes.Insert(targeNode.Index, moveNode);

                        IToolInfo temp = new IToolInfo();
                        for (int i = 0; i < L_toolList.Count; i++)
                        {
                            if (L_toolList[i].toolName == moveNode.Text)
                            {
                                SwapDataFun(L_toolList, i, targeNode.Index);
                                break;
                            }
                        }
                    }
                    else 
                    {
                        // 目标是子节点，则移动到该子节点的父节点的下一个节点上
                        moveNode.Remove();
                        tvwOnWorkJob.Nodes.Insert(targeNode.Parent.Index + 1, moveNode);
                        for (int i = 0; i < L_toolList.Count; i++)
                        {
                            if (L_toolList[i].toolName == moveNode.Text)
                            {
                                SwapDataFun(L_toolList, i, targeNode.Parent.Index);
                                break;
                            }
                        }
                    }
                }
                else        //被拖动的是输入输出节点
                {
                    if (targeNode.Level == 0 && GetToolInfoByToolName(JobName, targeNode.Text).toolType == ToolType.Output)
                    {
                        // 如果目标节点是工具节点，并且工具节点类型为可接收输入的节点，则直接将输出添加，先不考虑该情况
                        //string result = moveNode.Parent.Text + " . -->" + moveNode.Text.Substring(3);
                        //GetToolInfoByToolName(jobName, targeNode.Text).input.Add(new ToolIO("<--" + result, "", DataType.String));
                        //TreeNode node = targeNode.Nodes.Add("", "<--" + result, 26, 26);
                        //node.ForeColor = Color.DarkMagenta;
                        //D_itemAndSource.Add(node, moveNode);
                        //targeNode.Expand();
                        //DrawLine();
                        return;
                    }
                    else if (targeNode.Level == 0)
                        return;

                    //连线前首先要判断被拖动节点是否为输出项，目标节点是否为输入项
                    if (moveNode.Text.Substring(0, 3) != "-->" || targeNode.Text.Substring(0, 3) != "<--")
                    {
                        myFormLog.ShowLog("拖动类型不匹配！");
                        return;
                    }

                    //连线前要判断被拖动节点和目标节点的数据类型是否一致
                    if ((DataType)moveNode.Tag != (DataType)targeNode.Tag)
                    {
                        myFormLog.ShowLog("被拖动节点和目标节点数据类型不一致，不可关联");
                        return;
                    }

                    string input = targeNode.Text;
                    if (input.Contains("《"))       //表示已经连接了源
                        input = Regex.Split(input, "《")[0];
                    else            //第一次连接源就需要添加到输入输出集合
                        D_itemAndSource.Add(targeNode, moveNode);
                    GetToolInfoByToolName(this.JobName, targeNode.Parent.Text).GetInput(input.Substring(3)).value = "《- " + moveNode.Parent.Text + " . " + moveNode.Text.Substring(3);
                    targeNode.Text = input + "《- " + moveNode.Parent.Text + ". " + moveNode.Text.Substring(3);
                    DrawLine();

                    //移除拖放的节点  
                    if (moveNode.Level == 0)
                        moveNode.Remove();
                }
                //更新当前拖动的节点选择  
                tvwOnWorkJob.SelectedNode = moveNode;
                //展开目标节点,便于显示拖放效果  
                targeNode.Expand();
            }
            catch (Exception ex)
            {
                myFormLog.ShowLog("释放节点出错，原因： " + ex.Message + ex.StackTrace.ToString());
            }
        }
        


        private static Graphics graph;
        /// <summary>
        /// 绘制输入输出指向线
        /// </summary>
        /// <param name="obj"></param>
        public void DrawLine()
        {
            try
            {
                if (!isDrawing)
                {
                    isDrawing = true;
                    Thread th = new Thread(() =>
                    {
                        tvwOnWorkJob.MouseWheel += new MouseEventHandler(CancelUpDowm_MouseWheel);          //划线的时候不能滚动，否则画好了线，结果已经滚到其它地方了
                        maxLength = 150;
                        colValueAndColor.Clear();
                        startNodeAndColor.Clear();
                        list.Clear();
                        TreeView tree = tvwOnWorkJob;
                        graph = tree.CreateGraphics();
                        tree.CreateGraphics().Dispose();

                        foreach (KeyValuePair<TreeNode, TreeNode> item in D_itemAndSource)
                        {
                            // 将此划线线程委托到JOB管理界面
                            FormJobManage.Instance.Invoke(createLineDelegateFun, new object[] { tree, item.Key, item.Value });
                        }
                        Application.DoEvents();
                        tvwOnWorkJob.MouseWheel -= new MouseEventHandler(CancelUpDowm_MouseWheel);
                        isDrawing = false;
                    });
                    th.IsBackground = true;
                    //th.ApartmentState = ApartmentState.STA;             
                    th.Start();
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void CancelUpDowm_MouseWheel(object sender, MouseEventArgs e)
        {
            HandledMouseEventArgs h = e as HandledMouseEventArgs;
            if (h != null)
            {
                h.Handled = true;
            }
        }

        #region 绘制输入输出指向线
        internal void tvw_job_AfterSelect(object sender, TreeViewEventArgs e)
        {
            nodeTextBeforeEdit = tvwOnWorkJob.SelectedNode.Text;
        }
        internal void Draw_Line(object sender, TreeViewEventArgs e)
        {
            tvwOnWorkJob.Refresh();
            DrawLine();
        }
        internal void tbc_jobs_SelectedIndexChanged(object sender, EventArgs e)
        {
            tvwOnWorkJob.Refresh();
            DrawLine();
        }
        public void DrawLineWithoutRefresh(object sender, MouseEventArgs e)
        {
            tvwOnWorkJob.Update();
            DrawLine();
        }
        internal void MyJobTreeView_ChangeUICues(object sender, UICuesEventArgs e)
        {
            tvwOnWorkJob.Update();
            DrawLine();
        }
        #endregion

        /// <summary>
        /// 画Treeview控件两个节点之间的连线
        /// </summary>
        /// <param name="treeview">要画连线的Treeview</param>
        /// <param name="startNode">结束节点</param>
        /// <param name="endNode">开始节点</param>
        private void CreateLine(TreeView treeview, TreeNode endNode, TreeNode startNode)
        {
            try
            {
                //得到起始与结束节点之间所有节点的最大长度，保证画线不穿过节点
                int startNodeParantIndex = startNode.Parent.Index;
                int endNodeParantIndex = endNode.Parent.Index;
                int startNodeIndex = startNode.Index;
                int endNodeIndex = endNode.Index;
                int max = 0;

                if (!startNode.Parent.IsExpanded)
                {
                    max = startNode.Parent.Bounds.X + startNode.Parent.Bounds.Width;
                }
                else
                {
                    for (int i = startNodeIndex; i < startNode.Parent.Nodes.Count - 1; i++)
                    {
                        if (max < treeview.Nodes[startNodeParantIndex].Nodes[i].Bounds.X + treeview.Nodes[startNodeParantIndex].Nodes[i].Bounds.Width)
                            max = treeview.Nodes[startNodeParantIndex].Nodes[i].Bounds.X + treeview.Nodes[startNodeParantIndex].Nodes[i].Bounds.Width;
                    }
                }
                for (int i = startNodeParantIndex + 1; i < endNodeParantIndex; i++)
                {
                    if (!treeview.Nodes[i].IsExpanded)
                    {
                        if (max < treeview.Nodes[i].Bounds.X + treeview.Nodes[i].Bounds.Width)
                            max = treeview.Nodes[i].Bounds.X + treeview.Nodes[i].Bounds.Width;
                    }
                    else
                    {
                        for (int j = 0; j < treeview.Nodes[i].Nodes.Count; j++)
                        {
                            if (max < treeview.Nodes[i].Nodes[j].Bounds.X + treeview.Nodes[i].Nodes[j].Bounds.Width)
                                max = treeview.Nodes[i].Nodes[j].Bounds.X + treeview.Nodes[i].Nodes[j].Bounds.Width;
                        }
                    }
                }
                if (!endNode.Parent.IsExpanded)
                {
                    if (max < endNode.Parent.Bounds.X + endNode.Parent.Bounds.Width)
                        max = endNode.Parent.Bounds.X + endNode.Parent.Bounds.Width;
                }
                else
                {
                    for (int i = 0; i < endNode.Index; i++)
                    {
                        if (max < treeview.Nodes[endNodeParantIndex].Nodes[i].Bounds.X + treeview.Nodes[endNodeParantIndex].Nodes[i].Bounds.Width)
                            max = treeview.Nodes[endNodeParantIndex].Nodes[i].Bounds.X + treeview.Nodes[endNodeParantIndex].Nodes[i].Bounds.Width;
                    }
                }
                max += 10;        //箭头不能连着 节点，

                if (!startNode.Parent.IsExpanded)
                    startNode = startNode.Parent;
                if (!endNode.Parent.IsExpanded)
                    endNode = endNode.Parent;

                if (endNode.Bounds.X + endNode.Bounds.Width + 20 > max)
                    max = endNode.Bounds.X + endNode.Bounds.Width + 20;
                if (startNode.Bounds.X + startNode.Bounds.Width + 20 > max)
                    max = startNode.Bounds.X + startNode.Bounds.Width + 20;

                //判断是否可以在当前处划线
                foreach (KeyValuePair<int, Dictionary<TreeNode, TreeNode>> item in list)
                {
                    if (Math.Abs(max - item.Key) < 15)
                    {
                        foreach (KeyValuePair<TreeNode, TreeNode> item1 in item.Value)
                        {
                            if (startNode != item1.Value)
                            {
                                if ((item1.Value.Bounds.X < maxLength && item1.Key.Bounds.X < maxLength) || (item1.Value.Bounds.X < maxLength && item1.Key.Bounds.X < maxLength))
                                {
                                    max += (15 - Math.Abs(max - item.Key));
                                }
                            }
                        }
                    }
                }

                Dictionary<TreeNode, TreeNode> temp = new Dictionary<TreeNode, TreeNode>();
                temp.Add(endNode, startNode);
                if (!list.ContainsKey(max))
                    list.Add(max, temp);
                else
                    list[max].Add(endNode, startNode);

                if (!startNodeAndColor.ContainsKey(startNode))
                    startNodeAndColor.Add(startNode, color[startNodeAndColor.Count]);

                Pen pen = new Pen(startNodeAndColor[startNode], 1);
                Brush brush = new SolidBrush(startNodeAndColor[startNode]);

                graph.DrawLine(pen, startNode.Bounds.X + startNode.Bounds.Width,
                    startNode.Bounds.Y + startNode.Bounds.Height / 2,
                max,
                  startNode.Bounds.Y + startNode.Bounds.Height / 2);
                graph.DrawLine(pen, max,
                   startNode.Bounds.Y + startNode.Bounds.Height / 2,
                   max,
                  endNode.Bounds.Y + endNode.Bounds.Height / 2);
                graph.DrawLine(pen, max,
                   endNode.Bounds.Y + endNode.Bounds.Height / 2,
                   endNode.Bounds.X + endNode.Bounds.Width,
                     endNode.Bounds.Y + endNode.Bounds.Height / 2);
                graph.DrawString("<", new Font("微软雅黑", 12F), brush, endNode.Bounds.X + endNode.Bounds.Width - 5,
                     endNode.Bounds.Y + endNode.Bounds.Height / 2 - 12);
                Application.DoEvents();
            }
            catch { }
        }


        /// <summary>
        /// 交换List中的两个位置的值
        /// </summary>
        /// <param name="inputList">要交换的List</param>
        /// <param name="souceIndex">原位置索引</param>
        /// <param name="targetIndex">现位置索引</param>
        /// <returns></returns>
        public static List<IToolInfo> SwapDataFun(List<IToolInfo> inputList, int souceIndex, int targetIndex)
        {
            IToolInfo temp = inputList[targetIndex];
            inputList[targetIndex] = inputList[souceIndex];
            inputList[souceIndex] = temp;
            return inputList;
        }

        /// <summary>
        /// 根据工具名获取工具信息
        /// </summary>
        /// <param name="jobName">下一版本去掉该参数，流程名</param>
        /// <param name="toolName">工具名</param>
        /// <returns></returns>
        public IToolInfo GetToolInfoByToolName(string jobName, string toolName)
        {
            try
            {
                for (int i = 0; i < L_toolList.Count; i++)
                {
                    if (L_toolList[i].toolName == toolName)
                    {
                        return (IToolInfo)L_toolList[i];
                    }
                }
                return new IToolInfo();
            }
            catch (Exception ex)
            {
                myFormLog.ShowLog("根据工具名获取工具信息出错！原因： " + ex.Message);
                return new IToolInfo();
            }
        }
    }

}
