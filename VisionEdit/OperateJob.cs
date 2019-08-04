using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FindLineTool;


namespace VisionEdit
{
    public class OperateJob
    {
        public static void CreateNewJob()
        {
            try
            {
               
            }
            catch
            {

            }
        }

        /// <summary>
        /// TreeView双击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void TreeViewJob_DoubleClick(object sender, MouseEventArgs e)
        {
            //判断是否在节点上双击
            TreeViewHitTestInfo test = GlobalParams.myJobTreeView.HitTest(e.X, e.Y);
            TreeNode selectNode = test.Node.Level == 0 ? test.Node : test.Node.Parent;
            selectNode.ExpandAll();
            for (int i = 0; i < GlobalParams.myVisionJob.L_toolList.Count; i++)
            {
                if (selectNode.Text == GlobalParams.myVisionJob.L_toolList[i].toolName)
                {
                    string AssemblyName = GlobalParams.myVisionJob.L_toolList[i].FormToolName.Split('.')[0];
                    string className = GlobalParams.myVisionJob.L_toolList[i].FormToolName;
                    object toolClass = GlobalParams.myVisionJob.L_toolList[i];
                    GlobalParams.myVisionJob.L_toolList[i].FormTool = (Form)Assembly.Load(AssemblyName).CreateInstance(className, false, BindingFlags.Default, null, new object[] { toolClass }, null, null);
                    GlobalParams.myVisionJob.L_toolList[i].FormTool.Show();
                }
            }
        }

    }
}
