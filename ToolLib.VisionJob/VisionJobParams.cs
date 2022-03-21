/*
* ==============================================================================
*
* Filename: VisionJobParams
* Description: 
*
* Version: 1.0
* Created: 2021/2/25 15:22:22
*
* Author: liu.wenjie
*
* ==============================================================================
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToolLib.VisionJob
{
    public class VisionJobParams
    {
        /// <summary>
        /// 当前项目，一个项目对应多个JOB
        /// </summary>
        public static VisionProject pVisionProject{ get; set; } = new VisionProject();
        /// <summary>
        /// 系统路径
        /// </summary>
        public static string sSysConfigPath { get; } = @"C:\MyCCDSystem\";
    }
}
