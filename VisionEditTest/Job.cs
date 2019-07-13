using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static VisionEditTest.ToolInfo;

namespace VisionEditTest
{
    [Serializable]
    public class Job
    {
       
        /// <summary>
        /// 工具对象集合
        /// </summary>
        public List<ToolInfo> L_toolList = new List<ToolInfo>();
        public TreeView tvw_job = null;

        /// <summary>
        /// 当前流程树是否处于折叠状态
        /// </summary>
        private static bool jobTreeFold = true;
        /// <summary>
        /// 当前流程此次运行结果
        /// </summary>
        private JobRunStatu jobRunStatu = JobRunStatu.Fail;
        /// <summary>
        /// 工具输入项个数
        /// </summary>
        private int inputItemNum = 0;
        /// <summary>
        /// 工具输出项个数
        /// </summary>
        private int outputItemNum = 0;
        /// <summary>
        /// 指示图像窗口是否为第一次显示窗体，第一次显示时要初始化
        /// </summary>
        internal bool firstDisplayImage = true;
        /// <summary>
        /// 需要连线的节点对，不停的画连线，注意键值对中第一个为连线的结束节点，第二个为起始节点，一个输出可能连接多个输入，而键值对中的键不能重复，所以把源作为值，输入作为键
        /// </summary>
        internal Dictionary<TreeNode, TreeNode> D_itemAndSource = new Dictionary<TreeNode, TreeNode>();
        /// <summary>
        /// 本流程所绑定的图像窗口的句柄
        /// </summary>
        internal HTuple imageWindow = new HTuple();
        /// <summary>
        /// 本流程所绑定的生产窗口的名称
        /// </summary>
        internal string imageWindowName = "无";
        /// <summary>
        /// 流程结果图像所绑定的窗体
        /// </summary>
        internal string debugImageWindow = "图像";
        /// <summary>
        /// 流程运行结果图像
        /// </summary>
        internal HObject jobResultImage;
        /// <summary>
        /// 编辑节点前节点文本，用于修改工具名称
        /// </summary>
        private string nodeTextBeforeEdit = string.Empty;
        /// <summary>
        /// 流程编辑时的右击菜单
        /// </summary>
        private static ContextMenuStrip rightClickMenu = new ContextMenuStrip();
        /// <summary>
        /// 在空白除右击菜单
        /// </summary>
        private static ContextMenuStrip rightClickMenuAtBlank = new ContextMenuStrip();
        /// <summary>
        /// 流程名
        /// </summary>
        internal string jobName = string.Empty;
        /// <summary>
        /// 流程树中节点的最大长度
        /// </summary>
        private int maxLength = 130;
        /// <summary>
        /// 正在绘制输入输出指向线
        /// </summary>
        internal static bool isDrawing = false;
        /// <summary>
        /// 记录本工具执行完的耗时，用于计算各工具耗时
        /// </summary>
        private double recordElapseTime = 0;
        /// <summary>
        /// 标准图像字典，用于存储标准图像路径和图像对象
        /// </summary>
        internal static Dictionary<string, HObject> D_standardImage = new Dictionary<string, HObject>();
        /// <summary>
        /// 工具图标列表
        /// </summary>
        internal static ImageList imageList = new ImageList();
        /// <summary>
        /// 记录起始节点和此节点的列坐标值
        /// </summary>
        private static Dictionary<TreeNode, Color> startNodeAndColor = new Dictionary<TreeNode, Color>();
        /// <summary>
        /// 记录前面的划线所跨越的列段，
        /// </summary>
        private static Dictionary<int, Dictionary<TreeNode, TreeNode>> list = new Dictionary<int, Dictionary<TreeNode, TreeNode>>();
        /// <summary>
        /// 每一个列坐标值对应一种颜色
        /// </summary>
        private Dictionary<int, Color> colValueAndColor = new Dictionary<int, Color>();
        /// <summary>
        /// 输入输出指向线的颜色数组
        /// </summary>
        private static Color[] color = new Color[] { Color.Blue, Color.Orange, Color.Black, Color.Red, Color.Green, Color.Brown, Color.Blue, Color.Black, Color.Red, Color.Green, Color.Orange, Color.Brown, Color.Blue, Color.Black, Color.Red, Color.Green, Color.Orange, Color.Brown, Color.Blue, Color.Black, Color.Red, Color.Green, Color.Orange, Color.Brown, Color.Blue, Color.Black, Color.Red, Color.Green, Color.Orange, Color.Brown };

        public Job()
        {
           
        }


        /// <summary>
        /// 拖动工具节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void tvw_job_ItemDrag(object sender, ItemDragEventArgs e)//左键拖动  
        {
            try
            {
                if (((TreeView)sender).SelectedNode != null)
                {
                    if (((TreeView)sender).SelectedNode.Level == 1)          //输入输出不允许拖动
                    {
                        tvw_job.DoDragDrop(e.Item, DragDropEffects.Move);
                    }

                    else if (e.Button == MouseButtons.Left)
                    {
                        tvw_job.DoDragDrop(e.Item, DragDropEffects.Move);
                    }
                }
            }
            catch (Exception ex)
            {
                
            }
        }

        /// <summary>
        /// 节点拖动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void tvw_job_DragEnter(object sender, DragEventArgs e)
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
                
            }
        }


        /// <summary>
        /// 释放被拖动的节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void tvw_job_DragDrop(object sender, DragEventArgs e)//拖动  
        {
            try
            {
                //获得拖放中的节点  
                TreeNode moveNode = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode");
                //根据鼠标坐标确定要移动到的目标节点  
                System.Drawing.Point pt;
                TreeNode targeNode;
                pt = ((TreeView)(sender)).PointToClient(new System.Drawing.Point(e.X, e.Y));
                targeNode = tvw_job.GetNodeAt(pt);
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

                if (moveNode.Level == 0)        //被拖动的是子节点，也就是工具节点
                {
                    if (targeNode.Level == 0)
                    {
                        moveNode.Remove();
                        tvw_job.Nodes.Insert(targeNode.Index, moveNode);

                        ToolInfo temp = new ToolInfo();
                        for (int i = 0; i < L_toolList.Count; i++)
                        {
                            if (L_toolList[i].toolName == moveNode.Text)
                            {
                                temp = L_toolList[i];
                                L_toolList.RemoveAt(i);
                                L_toolList.Insert(targeNode.Index - 2, temp);
                                break;
                            }
                        }
                    }
                    else
                    {
                        moveNode.Remove();
                        tvw_job.Nodes.Insert(targeNode.Parent.Index + 1, moveNode);

                        ToolInfo temp = new ToolInfo();
                        for (int i = 0; i < L_toolList.Count; i++)
                        {
                            if (L_toolList[i].toolName == moveNode.Text)
                            {
                                temp = L_toolList[i];
                                L_toolList.RemoveAt(i);
                                L_toolList.Insert(targeNode.Parent.Index, temp);
                                break;
                            }
                        }
                    }
                }
                else        //被拖动的是输入输出节点
                {
                    if (targeNode.Level == 0 && GetToolInfoByToolName(jobName, targeNode.Text).toolType == ToolType.Output)
                    {
                        string result = moveNode.Parent.Text + " . -->" + moveNode.Text.Substring(3);
                        GetToolInfoByToolName(jobName, targeNode.Text).input.Add(new ToolIO("<--" + result, "", DataType.String));
                        TreeNode node = targeNode.Nodes.Add("", "<--" + result, 26, 26);
                        node.ForeColor = Color.DarkMagenta;
                        D_itemAndSource.Add(node, moveNode);
                        targeNode.Expand();
                        DrawLine();
                        return;
                    }
                    else if (targeNode.Level == 0)
                        return;

                    //连线前首先要判断被拖动节点是否为输出项，目标节点是否为输入项
                    if (moveNode.Text.Substring(0, 3) != "-->" || targeNode.Text.Substring(0, 3) != "<--")
                    {
                        return;
                    }

                    //连线前要判断被拖动节点和目标节点的数据类型是否一致
                    if ((DataType)moveNode.Tag != (DataType)targeNode.Tag)
                    {
                      //  Frm_Main.Instance.OutputMsg("被拖动节点和目标节点数据类型不一致，不可关联", Color.Red);
                        return;
                    }

                    string input = targeNode.Text;
                    if (input.Contains("《"))       //表示已经连接了源
                        input = Regex.Split(input, "《")[0];
                    else            //第一次连接源就需要添加到输入输出集合
                        D_itemAndSource.Add(targeNode, moveNode);
                    GetToolInfoByToolName(jobName, targeNode.Parent.Text).GetInput(input.Substring(3)).value = "《- " + moveNode.Parent.Text + " . " + moveNode.Text.Substring(3);
                    targeNode.Text = input + "《- " + moveNode.Parent.Text + " . " + moveNode.Text.Substring(3);
                    DrawLine();

                    //移除拖放的节点  
                    if (moveNode.Level == 0)
                        moveNode.Remove();
                }
                //更新当前拖动的节点选择  
                tvw_job.SelectedNode = moveNode;
                //展开目标节点,便于显示拖放效果  
                targeNode.Expand();
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// 流程树的双击事件
        /// </summary>
        internal void TVW_DoubleClick(object sender, MouseEventArgs e)
        {
            //判断是否在节点上双击
            TreeViewHitTestInfo test = tvw_job.HitTest(e.X, e.Y);
            if (test.Node == null || test.Location != TreeViewHitTestLocations.Label)       //双击节点
            {
                if (jobTreeFold)
                {
                    tvw_job.ExpandAll();
                    jobTreeFold = false;
                }
                else
                {
                    tvw_job.CollapseAll();
                    jobTreeFold = true;
                }
                return;
            }
            string toolName = tvw_job.SelectedNode.Text;
            // TestFrmIn myForm = new TestFrmIn()
            for (int i = 0; i < L_toolList.Count; i++)
            {
                if (L_toolList[i].toolName == toolName)
                {
                    switch(toolName)
                    {
                        case "可输入工具":
                            ShapeMatchTool shapeMatchTool = (ShapeMatchTool)(L_toolList[i].tool);
                            TestFrmIn myTestFrmIn = new TestFrmIn();
                            myTestFrmIn.shapeMatchTool = shapeMatchTool;
                            myTestFrmIn.inputText = shapeMatchTool.text;
                            myTestFrmIn.Show();
                            break;
                    }
                }
            }

        }

        #region 绘制输入输出指向线
        internal void tvw_job_AfterSelect(object sender, TreeViewEventArgs e)
        {
            nodeTextBeforeEdit = tvw_job.SelectedNode.Text;
        }
        internal void Draw_Line(object sender, TreeViewEventArgs e)
        {
            tvw_job.Refresh();
            DrawLine();
        }
        internal void tbc_jobs_SelectedIndexChanged(object sender, EventArgs e)
        {
            tvw_job.Refresh();
            DrawLine();
        }
        public void DrawLineWithoutRefresh(object sender, MouseEventArgs e)
        {
            tvw_job.Update();
            DrawLine();
        }
        #endregion

        /// <summary>
        /// 通过工具名获取工具信息
        /// </summary>
        /// <param name="toolName">工具名</param>
        /// <returns>工具信息</returns>
        internal static ToolInfo GetToolInfoByToolName(string jobName, string toolName)
        {
            try
            {
                Job job = new Job();
                //for (int i = 0; i < Project.Instance.L_jobList.Count; i++)
                //{
                //    if (Project.Instance.L_jobList[i].jobName == jobName)
                //    {
                //        job = Project.Instance.L_jobList[i];
                //        break;
                //    }
                //}
                job = TestForm.GetInstance().myJob;
                for (int i = 0; i < job.L_toolList.Count; i++)
                {
                    if (job.L_toolList[i].toolName == toolName)
                    {
                        return job.L_toolList[i];
                    }
                }
                return new ToolInfo();
            }
            catch (Exception ex)
            {
                return new ToolInfo();
            }
        }
        private static Graphics g;
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
                        tvw_job.MouseWheel += new MouseEventHandler(numericUpDown1_MouseWheel);          //划线的时候不能滚动，否则画好了线，结果已经滚到其它地方了
                        maxLength = 150;
                        colValueAndColor.Clear();
                        startNodeAndColor.Clear();
                        list.Clear();
                        TreeView tree = tvw_job;
                        g = tree.CreateGraphics();
                        tree.CreateGraphics().Dispose();

                        foreach (KeyValuePair<TreeNode, TreeNode> item in D_itemAndSource)
                        {
                            CreateLine(tree, item.Key, item.Value);
                        }
                        Application.DoEvents();
                        tvw_job.MouseWheel -= new MouseEventHandler(numericUpDown1_MouseWheel);
                        isDrawing = false;
                    });
                    th.IsBackground = true;
                    th.ApartmentState = ApartmentState.STA;             //此处要加一行，否则画线时会报错
                    th.Start();
                }
            }
            catch (Exception ex)
            {
            }
        }

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
                //得到起始与结束节点之间所有节点的最大长度  ，保证画线不穿过节点
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

                g.DrawLine(pen, startNode.Bounds.X + startNode.Bounds.Width,
                    startNode.Bounds.Y + startNode.Bounds.Height / 2,
                max,
                  startNode.Bounds.Y + startNode.Bounds.Height / 2);
                g.DrawLine(pen, max,
                   startNode.Bounds.Y + startNode.Bounds.Height / 2,
                   max,
                  endNode.Bounds.Y + endNode.Bounds.Height / 2);
                g.DrawLine(pen, max,
                   endNode.Bounds.Y + endNode.Bounds.Height / 2,
                   endNode.Bounds.X + endNode.Bounds.Width,
                     endNode.Bounds.Y + endNode.Bounds.Height / 2);
                g.DrawString("<", new Font("微软雅黑", 12F), brush, endNode.Bounds.X + endNode.Bounds.Width - 5,
                     endNode.Bounds.Y + endNode.Bounds.Height / 2 - 12);
                Application.DoEvents();
            }
            catch { }
        }


        //取消滚轮事件
        void numericUpDown1_MouseWheel(object sender, MouseEventArgs e)
        {
            HandledMouseEventArgs h = e as HandledMouseEventArgs;
            if (h != null)
            {
                h.Handled = true;
            }
        }

        /// <summary>
        /// 添加输入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Add_input(object sender, EventArgs e)
        {
            try
            {
                string result = sender.ToString();

                //首先检查是否已经有此输入项,若已添加，则返回
                foreach (var item in tvw_job.SelectedNode.Nodes)
                {
                    string text;
                    if (((TreeNode)item).Text.Contains("《"))
                    {
                        text = Regex.Split(((TreeNode)item).Text, "《")[0];
                    }
                    else
                    {
                        text = ((TreeNode)item).Text;
                    }
                    if (text == "<--" + result)
                    {
                        //Frm_Main.Instance.OutputMsg(Configuration.language == Language.English ? "This input or output item already exists and cannot be added repeatedly" : "已存在此输入或输出项，不可重复添加", Color.Green);
                        return;
                    }
                }

                int insertPos = GetInputItemNum(tvw_job.SelectedNode);        //获取插入位置，要保证输入项在前，输出项在后
                TreeNode node = tvw_job.SelectedNode.Nodes.Insert(insertPos, "", "<--" + result, 26, 26);
                node.ForeColor = Color.DarkMagenta;
                tvw_job.SelectedNode.Expand();
                DataType ioType = (DataType)((ToolStripItem)sender).Tag;

                //指定输入变量的类型
                //if (result == (Configuration.language == Language.English ? "InputImage" : "输入图像"))
                //    node.Tag = DataType.Image;
                //else if (result == "BlobResult")
                //    node.Tag = "BlobResult";
                //else
                node.Tag = ioType;
                node.Name = "<--" + result;
                GetToolInfoByToolName(jobName, tvw_job.SelectedNode.Text).input.Add(new ToolIO(result, "", ioType));

                //如果是给输出工具添加输入，则需要连线
                if (GetToolInfoByToolName(jobName, tvw_job.SelectedNode.Text).toolType == ToolType.Output)
                {
                    string toolNodeText = Regex.Split(sender.ToString(), " . ")[0];
                    string toolIONodeText = Regex.Split(sender.ToString(), " . ")[1];
                    D_itemAndSource.Add(GetToolIONodeByNodeText(tvw_job.SelectedNode.Text, "<--" + sender.ToString()), GetToolIONodeByNodeText(toolNodeText, toolIONodeText));

                    Draw_Line(null, null);
                }
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// 通过TreeNode节点文本获取输入输出节点
        /// </summary>
        /// <param name="toolName">工具名称</param>
        /// <returns>IO名称</returns>
        internal TreeNode GetToolIONodeByNodeText(string toolName, string toolIOName)
        {
            try
            {
                foreach (TreeNode toolNode in tvw_job.Nodes)
                {
                    if (toolNode.Text == toolName)
                    {
                        foreach (TreeNode itemNode in ((TreeNode)toolNode).Nodes)
                        {
                            if (((TreeNode)itemNode).Text == toolIOName)
                            {
                                return itemNode;
                            }
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// 添加输出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Add_output(object sender, EventArgs e)
        {
            try
            {
                string result = sender.ToString();
                foreach (var item in tvw_job.SelectedNode.Nodes)
                {
                    if (((TreeNode)item).Text == "-->" + result)
                    {
                        return;
                    }
                }
                TreeNode node = tvw_job.SelectedNode.Nodes.Add("", "-->" + result, 26, 26);
                node.ForeColor = Color.Blue;
                tvw_job.SelectedNode.Expand();
                DataType ioType = (DataType)((ToolStripItem)sender).Tag;

                //指定输出变量的类型
                if (result ==  "输出图像")
                {
                    //  node.Tag = DataType.Image;
                    node.ToolTipText = "图形变量不支持显示";
                }
                //else if (result == "BlobResult")
                //    node.Tag = "BlobResult";
                //else
                node.Tag = ioType;

                node.Name = "-->" + result;
                GetToolInfoByToolName(jobName, tvw_job.SelectedNode.Text).output.Add(new ToolIO(result, "", ioType));
                node.ToolTipText =  "未运行";
                tvw_job.ShowNodeToolTips = true;
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// 获取工具输入项的个数
        /// </summary>
        private int GetInputItemNum(TreeNode toolNode)
        {
            try
            {
                int num = 0;
                foreach (TreeNode item in toolNode.Nodes)
                {
                    if (item.Text.Substring(0, 3) == "<--")
                    {
                        num++;
                    }
                }
                return num;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

    }
    public enum JobRunStatu
    {
        Succeed,
        Fail,
    }
}
