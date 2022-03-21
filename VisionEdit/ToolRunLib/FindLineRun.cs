using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommonMethods;
using FindLineTool;
using HalconDotNet;
using VisionEdit.FormLib;

namespace VisionEdit.ToolRunLib
{
    public class FindLineRun : IToolRun
    {
        public void ToolRun(int toolIndex, int inputItemNum, TreeNode selectNode, FormLog myFormLog, FormImageWindow myFormWindow, List<IToolInfo> L_toolList)
        {
            FindLine myFindLine = (FindLine)L_toolList[toolIndex].tool;
            for (int j = 0; j < inputItemNum; j++)
            {
                if (L_toolList[toolIndex].GetInput(L_toolList[toolIndex].toolInput[j].IOName).value == null)
                {
                    selectNode.ForeColor = Color.Red;
                    myFormLog.ShowLog(L_toolList[toolIndex].toolName + "  无输入图像");
                }
                else
                {
                    string sourceFrom = L_toolList[toolIndex].GetInput(L_toolList[toolIndex].toolInput[j].IOName).value.ToString();
                    if (L_toolList[toolIndex].toolInput[j].IOName == "InputImage")
                    {
                        string sourceToolName = Regex.Split(sourceFrom, " . ")[0];
                        sourceToolName = sourceToolName.Substring(3, Regex.Split(sourceFrom, " . ")[0].Length - 3);
                        string toolItem = Regex.Split(sourceFrom, " . ")[1];
                        myFindLine.inputImage = GlobalParams.myVisionJob.GetToolInfoByToolName(GlobalParams.myVisionJob.JobName, sourceToolName).GetOutput(toolItem).value as HObject;
                    }
                }
            }
            myFindLine.Run(SoftwareRunState.Release);
            if (myFindLine.toolRunStatu == ToolRunStatu.Succeed)
            {
                myFindLine.DispMainWindow(GlobalParams.myVisionJob.myFormImageWindow.myHWindow);
                GlobalParams.myVisionJob.FormLogDisp(L_toolList[toolIndex].toolName + "  运行成功", Color.Green, selectNode);
            }
            else
            {
                GlobalParams.myVisionJob.FormLogDisp(L_toolList[toolIndex].toolName + "  运行失败", Color.Red, selectNode);
            }
        }
    }
}
