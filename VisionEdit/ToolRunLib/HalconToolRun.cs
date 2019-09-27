using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommonMethods;
using VisionEdit.FormLib;

namespace VisionEdit.ToolRunLib
{
    public class HalconToolRun : IToolRun
    {
        public void ToolRun(int toolIndex, int inputItemNum, TreeNode selectNode, FormLog myFormLog, FormImageWindow myFormWindow, List<IToolInfo> L_toolList)
        {
            HalconTool.HalconTool myHalconTool = (HalconTool.HalconTool)L_toolList[toolIndex].tool;
            myHalconTool.Run(SoftwareRunState.Release);
            if (myHalconTool.outputImage == null)
            {
                GlobalParams.myVisionJob.FormLogDisp(L_toolList[toolIndex].toolName + "  运行失败", Color.Red, selectNode);
            }
            else
            {
                GlobalParams.myVisionJob.FormLogDisp(L_toolList[toolIndex].toolName + "  运行成功", Color.Green, selectNode);
                GlobalParams.myVisionJob.myFormImageWindow.myHWindow.HobjectToHimage(myHalconTool.outputImage);
            }
        }
    }
}
