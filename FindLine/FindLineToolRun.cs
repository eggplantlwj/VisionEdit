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
using static DataStruct.DataStructClass;

namespace FindLineTool
{
    public class FindLineRun : IToolRun
    {
        public void ToolRun(string jobName, int toolIndex, int inputItemNum, TreeNode selectNode, List<IToolInfo> L_toolList, IVisionJob runJob, Form myHalconWindowForm)
        {
            FindLine myFindLine = (FindLine)L_toolList[toolIndex].tool;
            VisionJob myJob = (VisionJob)runJob;
            for (int j = 0; j < inputItemNum; j++)
            {
                if (L_toolList[toolIndex].GetInput(L_toolList[toolIndex].toolInput[j].IOName).value == null)
                {
                    // 仅当无输入图像时，将工具置为错误
                    if (L_toolList[toolIndex].toolInput[j].IOName == "InputImage")
                    {
                        selectNode.ForeColor = Color.Red;
                        LoggerClass.WriteLog(L_toolList[toolIndex].toolName + "  无输入图像", MsgLevel.Exception);
                        myFindLine.runMessage = "无输入图像";
                    }   
                }
                else
                {
                    string sourceFrom = L_toolList[toolIndex].GetInput(L_toolList[toolIndex].toolInput[j].IOName).value.ToString();
                    string sourceToolName = Regex.Split(sourceFrom, "->")[0];
                    sourceToolName = sourceToolName.Substring(3, Regex.Split(sourceFrom, "->")[0].Length - 3);
                    string toolItem = Regex.Split(sourceFrom, "->")[1];
                    switch (L_toolList[toolIndex].toolInput[j].IOName)
                    {
                        case "InputImage":
                            myFindLine.inputImage = myJob.GetToolInfoByToolName(sourceToolName).GetOutput(toolItem).value as HObject;
                            break;
                        case "InputPos":
                            myFindLine.inputPoseHomMat2D = myJob.GetToolInfoByToolName(sourceToolName).GetOutput(toolItem).value as HTuple;
                            break;
                        default:
                            break;
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
                myFindLine.DispMainWindow(((FormImageWindow)myHalconWindowForm).myHWindow);
            }
            L_toolList[toolIndex].toolRunStatu = myFindLine.toolRunStatu;
        }
    }
}
