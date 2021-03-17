/*
* ==============================================================================
*
* Filename: VisionProject
* Description: 
*
* Version: 1.0
* Created: 2021/2/27 15:49:25
*
* Author: liu.wenjie
*
* ==============================================================================
*/
using CommonMethods;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolLib.VisionJob
{
    public class VisionProject
    {
        /// <summary>
        /// 工程路径
        /// </summary>
        public string prjFilePath { get; set; } = @"D:\vision.prj";
        /// <summary>
        /// 工程名称
        /// </summary>
        public string prjName { get; set; }
        /// <summary>
        /// 工程中所包含的VisionJob
        /// </summary>
        public Dictionary<string, VisionJob> Project { get; set; } = new Dictionary<string, VisionJob>() { }; 

        public bool LoadProject()
        {
            if(!File.Exists(prjFilePath))
            {
                return false;
            }
            else
            {
                try
                {
                    Project = Serialize.BinaryDeserialize<Dictionary<string, VisionJob>>(prjFilePath);
                    foreach (var item in Project)
                    {
                        OperateProject.Instance.CreateNewJob(item.Key, false);
                        foreach (var tool in item.Value.L_toolList)
                        {
                            OperateTreeView.Instance.Add_Tool((ToolType)Enum.Parse(typeof(ToolType), tool.toolType.ToString()), false);
                        }
                        OperateProject.Instance.InitJob(item.Value);
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    Logger.LoggerClass.WriteLog("载入项目工程时出现异常！", ex);
                    return false;
                }
                
            }
        }

        public void SaveObject()
        {
            Serialize.BinarySerialize(prjFilePath, Project);
        }
    }
}
