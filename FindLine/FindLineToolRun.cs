/*
* ==============================================================================
*
* Filename: FindLineToolRun
* Description: 
*
* Version: 1.0
* Created: 2021/2/25 16:23:29
*
* Author: liu.wenjie
*
* ==============================================================================
*/
using CommonMethods;
using CommonMethods.Interface;
using FormLib;
using HalconDotNet;
using Logger;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToolLib.VisionJob;

namespace FindLineTool
{
    public class FindLineRun : IToolRun
    {
        public void ToolRun(string jobName, int toolIndex, int inputItemNum, TreeNode selectNode, List<IToolInfo> L_toolList)
        {
            FindLine myFindLine = (FindLine)L_toolList[toolIndex].tool;
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
                        myFindLine.inputImage = myJob.GetToolInfoByToolName(sourceToolName).GetOutput(toolItem).value as HObject;
                    }
                }
            }
            myFindLine.Run(SoftwareRunState.Release);
            if (myFindLine.toolRunStatu != ToolRunStatu.Succeed)
            {
                myJob.FormLogDisp($"{L_toolList[toolIndex].toolName} 运行失败，失败原因：{myFindLine.runMessage}", Color.Red, selectNode, Logger.MsgLevel.Exception);
            }
            else
            {
                myJob.FormLogDisp($"{L_toolList[toolIndex].toolName} 运行成功，{myFindLine.runTime}", Color.Green, selectNode);
                myFindLine.DispMainWindow(FormImageWindow.Instance.myHWindow.DispHWindow);
            }
        }
    }
}
