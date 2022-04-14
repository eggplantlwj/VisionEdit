/*
* ==============================================================================
*
* Filename: CaliperToolRun
* Description: 
*
* Version: 1.0
* Created: 2021/2/25 16:25:51
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

namespace CaliperTool
{
    public class CaliperRun : IToolRun
    {
        public void ToolRun(string jobName, int toolIndex, int inputItemNum, TreeNode selectNode, List<IToolInfo> L_toolList)
        {
            Caliper myCaliper = (Caliper)L_toolList[toolIndex].tool;
            VisionJob myJob = VisionJobParams.pVisionProject.Project[jobName];
            for (int j = 0; j < inputItemNum; j++)
            {
                if (L_toolList[toolIndex].toolInput[j].IOName == "InputImage" && L_toolList[toolIndex].GetInput(L_toolList[toolIndex].toolInput[j].IOName).value == null)
                {
                    selectNode.ForeColor = Color.Red;
                    LoggerClass.WriteLog($"{L_toolList[toolIndex].toolName} 无输入图像");
                    break;
                }
                else
                {
                    if (L_toolList[toolIndex].GetInput(L_toolList[toolIndex].toolInput[j].IOName).value != null)
                    {
                        string sourceFrom = L_toolList[toolIndex].GetInput(L_toolList[toolIndex].toolInput[j].IOName).value.ToString();
                        string sourceToolName = Regex.Split(sourceFrom, "->")[0];
                        sourceToolName = sourceToolName.Substring(3, Regex.Split(sourceFrom, "->")[0].Length - 3);
                        string toolItem = Regex.Split(sourceFrom, "->")[1];
                        if (L_toolList[toolIndex].toolInput[j].IOName == "InputImage")
                        {
                            myCaliper.inputImage = myJob.GetToolInfoByToolName(sourceToolName).GetOutput(toolItem).value as HObject;
                        }
                        if (L_toolList[toolIndex].toolInput[j].IOName == "inputCenterRow")
                        {
                            myCaliper.expectRecStartRow = myJob.GetToolInfoByToolName(sourceToolName).GetOutput(toolItem).value as HTuple;
                        }
                        if (L_toolList[toolIndex].toolInput[j].IOName == "inputCenterCol")
                        {
                            myCaliper.expectRecStartColumn = myJob.GetToolInfoByToolName(sourceToolName).GetOutput(toolItem).value as HTuple;
                        }
                        if (L_toolList[toolIndex].toolInput[j].IOName == "inputPhi")
                        {
                            myCaliper.expectAngle = myJob.GetToolInfoByToolName(sourceToolName).GetOutput(toolItem).value as HTuple;
                        }

                    }
                }
            }
            myCaliper.Run(SoftwareRunState.Release);
            if (myCaliper.toolRunStatu == ToolRunStatu.Succeed)
            {
                myCaliper.DispMainWindow(FormImageWindow.Instance.myHWindow);
                myJob.FormLogDisp(L_toolList[toolIndex].toolName + "  运行成功", Color.Green, selectNode);
            }
            else
            {
                myJob.FormLogDisp(L_toolList[toolIndex].toolName + "  运行失败", Color.Red, selectNode);
            }
        }

    }
}
