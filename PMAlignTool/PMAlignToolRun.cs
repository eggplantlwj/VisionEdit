/*
* ==============================================================================
*
* Filename: PMAlignToolRun
* Description: 
*
* Version: 1.0
* Created: 2021/3/30 11:05:40
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
using ToolLib.VisionJob;
using System.Drawing;
using System.Text.RegularExpressions;
using HalconDotNet;
using FormLib;
using Logger;

namespace PMAlignTool
{
    public class PMAlignToolRun : IToolRun
    {
        public void ToolRun(string jobName, int toolIndex, int inputItemNum, TreeNode selectNode, List<IToolInfo> L_toolList)
        {
            PMAlign myPMAlign = (PMAlign)L_toolList[toolIndex].tool;
            VisionJob myJob = VisionJobParams.pVisionProject.Project[jobName];
            for (int j = 0; j < inputItemNum; j++)
            {
                if (L_toolList[toolIndex].GetInput(L_toolList[toolIndex].toolInput[j].IOName).value == null)
                {
                    selectNode.ForeColor = Color.Red;
                    LoggerClass.WriteLog(L_toolList[toolIndex].toolName + "  无输入图像", MsgLevel.Exception);
                }
                else
                {
                    string sourceFrom = L_toolList[toolIndex].GetInput(L_toolList[toolIndex].toolInput[j].IOName).value.ToString();
                    if (L_toolList[toolIndex].toolInput[j].IOName == "InputImage")
                    {
                        string sourceToolName = Regex.Split(sourceFrom, "->")[0];
                        sourceToolName = sourceToolName.Substring(3, Regex.Split(sourceFrom, "->")[0].Length - 3);
                        string toolItem = Regex.Split(sourceFrom, "->")[1];
                        myPMAlign.inputImage = myJob.GetToolInfoByToolName(sourceToolName).GetOutput(toolItem).value as HObject;
                    }
                }
            }
            myPMAlign.Run(SoftwareRunState.Release);
            if (myPMAlign.toolRunStatu != ToolRunStatu.Succeed)
            {
                myJob.FormLogDisp($"{L_toolList[toolIndex].toolName} 运行失败，失败原因：{myPMAlign.runMessage}", Color.Red, selectNode, Logger.MsgLevel.Exception);
            }
            else
            {
                myJob.FormLogDisp($"{L_toolList[toolIndex].toolName} 运行成功，{myPMAlign.runTime}", Color.Green, selectNode);
                myPMAlign.DispMainWindow(FormImageWindow.Instance.myHWindow.DispHWindow);
            }
        }
    }
}
