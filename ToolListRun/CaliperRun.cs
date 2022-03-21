using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using CaliperTool;
using CommonMethods;
using HalconDotNet;
using VisionEdit;
using VisionEdit.FormLib;

namespace ToolListRun
{
    public class CaliperRun
    {
        public void ToolRun(int toolIndex, int inputItemNum, TreeNode selectNode, FormLog myFormLog, FormImageWindow myFormWindow, List<IToolInfo> L_toolList, VisionJob myVisionJob)
        {
            Caliper myCaliper = (Caliper)L_toolList[toolIndex].tool;
            for (int j = 0; j < inputItemNum; j++)
            {
                if (L_toolList[toolIndex].toolInput[j].IOName == "InputImage" && L_toolList[toolIndex].GetInput(L_toolList[toolIndex].toolInput[j].IOName).value == null)
                {
                    selectNode.ForeColor = Color.Red;
                    myFormLog.ShowLog(L_toolList[toolIndex].toolName + "  无输入图像");
                    break;
                }
                else
                {
                    if (L_toolList[toolIndex].GetInput(L_toolList[toolIndex].toolInput[j].IOName).value != null)
                    {
                        string sourceFrom = L_toolList[toolIndex].GetInput(L_toolList[toolIndex].toolInput[j].IOName).value.ToString();
                        string sourceToolName = Regex.Split(sourceFrom, " . ")[0];
                        sourceToolName = sourceToolName.Substring(3, Regex.Split(sourceFrom, " . ")[0].Length - 3);
                        string toolItem = Regex.Split(sourceFrom, " . ")[1];
                        if (L_toolList[toolIndex].toolInput[j].IOName == "InputImage")
                        {
                            myCaliper.inputImage = myVisionJob.GetToolInfoByToolName(myVisionJob.JobName, sourceToolName).GetOutput(toolItem).value as HObject;
                        }
                        if (L_toolList[toolIndex].toolInput[j].IOName == "inputCenterRow")
                        {
                            myCaliper.expectRecStartRow = myVisionJob.GetToolInfoByToolName(myVisionJob.JobName, sourceToolName).GetOutput(toolItem).value as HTuple;
                        }
                        if (L_toolList[toolIndex].toolInput[j].IOName == "inputCenterCol")
                        {
                            myCaliper.expectRecStartColumn = myVisionJob.GetToolInfoByToolName(myVisionJob.JobName, sourceToolName).GetOutput(toolItem).value as HTuple;
                        }
                        if (L_toolList[toolIndex].toolInput[j].IOName == "inputPhi")
                        {
                            myCaliper.expectAngle = myVisionJob.GetToolInfoByToolName(myVisionJob.JobName, sourceToolName).GetOutput(toolItem).value as HTuple;
                        }

                    }
                }
            }
            myCaliper.Run(SoftwareRunState.Release);
            if (myCaliper.toolRunStatu == ToolRunStatu.Succeed)
            {
                myCaliper.DispMainWindow(myFormWindow.myHWindow);
                myVisionJob.FormLogDisp(L_toolList[toolIndex].toolName + "  运行成功", Color.Green, selectNode);
            }
            else
            {
               myVisionJob.FormLogDisp(L_toolList[toolIndex].toolName + "  运行失败", Color.Red, selectNode);
            }
        }

    }
}
