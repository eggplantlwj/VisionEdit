using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisionEdit.Interface
{
    public interface ToolBase
    {
        //  internal ToolRunStatu runStatu = ToolRunStatu.Not_Run;
        /// <summary>
        /// 工具运行
        /// </summary>
        void Run(string jobName);
    }
}
