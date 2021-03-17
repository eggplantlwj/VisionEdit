/*
* ==============================================================================
*
* Filename: HalconToolRun
* Description: 
*
* Version: 1.0
* Created: 2021/2/25 16:03:59
*
* Author: liu.wenjie
*
* ==============================================================================
*/
using CommonMethods.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonMethods;
using System.Windows.Forms;
using System.Drawing;
using FormLib;
using ToolLib.VisionJob;

namespace HalconTool
{
    public class HalconToolRun : IToolRun
    {
        public void ToolRun(string jobName, int toolIndex, int inputItemNum, TreeNode selectNode, List<IToolInfo> L_toolList)
        {
            Type a = this.GetType();
            HalconTool myHalconTool = (HalconTool)L_toolList[toolIndex].tool;
            VisionJob myJob = VisionJobParams.pVisionProject.Project[jobName];
            myHalconTool.Run(SoftwareRunState.Release);
            if (myHalconTool.toolRunStatu != ToolRunStatu.Succeed)
            {
                myJob.FormLogDisp($"{L_toolList[toolIndex].toolName} 运行失败，失败原因：{myHalconTool.runMessage}", Color.Red, selectNode, Logger.MsgLevel.Exception);
            }
            else
            {
                myJob.FormLogDisp($"{L_toolList[toolIndex].toolName} 运行成功，{myHalconTool.runTime}", Color.Green, selectNode);
                FormImageWindow.Instance.myHWindow.HobjectToHimage(myHalconTool.outputImage);
            }
        }
    }
}
