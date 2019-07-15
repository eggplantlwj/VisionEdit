using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using HalconDotNet;
using VisionEdit.FormLib;

namespace VisionEdit
{
    public class VisionJob : IVisionJob
    {
        public TreeView tvwOnWorkJob = new TreeView();
        FormLog myFormLog = null;

        public VisionJob(TreeView inputTreeView, FormLog inputFormLog)
        {
            tvwOnWorkJob = inputTreeView;
            this.myFormLog = inputFormLog;
        }

        /// <summary>
        /// 拖动工具节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void TvwJobItemDrag(object sender, ItemDragEventArgs e)//左键拖动  
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
                Point pt;
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
                    if (targeNode.Level == 0)
                    {
                        moveNode.Remove();
                        tvwOnWorkJob.Nodes.Insert(targeNode.Index, moveNode);

                        ToolInfo temp = new ToolInfo();
                        for (int i = 0; i < L_toolList.Count; i++)
                        {
                            if (L_toolList[i].toolName == moveNode.Text)
                            {
                                temp = (ToolInfo)L_toolList[i];
                                L_toolList.RemoveAt(i);
                                L_toolList.Insert(targeNode.Index - 2, temp);
                                break;
                            }
                        }
                    }
                    else
                    {
                        moveNode.Remove();
                        tvwOnWorkJob.Nodes.Insert(targeNode.Parent.Index + 1, moveNode);

                        ToolInfo temp = new ToolInfo();
                        for (int i = 0; i < L_toolList.Count; i++)
                        {
                            if (L_toolList[i].toolName == moveNode.Text)
                            {
                                temp = (ToolInfo)L_toolList[i];
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
                tvwOnWorkJob.SelectedNode = moveNode;
                //展开目标节点,便于显示拖放效果  
                targeNode.Expand();
            }
            catch (Exception ex)
            {
            }
        }
    }

}
