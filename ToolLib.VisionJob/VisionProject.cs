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
using System.Windows.Forms;

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

        public bool LoadJob(string jobName,string path)
        {
            if (!File.Exists(path))
            {
                Logger.LoggerClass.WriteLog("job路径不存在！", true);
                return false;
            }
            else if(Project.ContainsKey(jobName))
            {
                Logger.LoggerClass.WriteLog("项目中已存在该JOB名称，请更换！", true);
                return false;
            }
            else
            {
                try
                {
                    VisionJob myNewJob = Serialize.BinaryDeserialize<VisionJob>(path);
                    OperateProject.Instance.CreateNewJob(jobName, myNewJob, true); // 新添加job
                    return true;
                }
                catch (Exception ex)
                {
                    Logger.LoggerClass.WriteLog("载入项目工程时出现异常！", ex);
                    return false;
                }
            }
        }

        public void SaveJob(string jobName,string filePath)
        {
            if(Project.ContainsKey(jobName))
            {
                Serialize.BinarySerialize(filePath, Project[jobName]);
            }
            else
            {
                Logger.LoggerClass.WriteLog("保存时出现异常，未找到Job", true);
            }
        }
    }
}
