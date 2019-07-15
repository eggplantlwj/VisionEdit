using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisionEdit
{
    public class ToolInfo:IToolInfo
    {
        public ToolInfo()
        {
            enable = true;
            toolType = ToolType.None;
            toolName = string.Empty;
            tool = new object();
            toolInput = new List<ToolIO>();
            toolOutput = new List<ToolIO>();
        }

        /// <summary>
        /// 以IO名获取IO对象
        /// </summary>
        /// <param name="IOName"></param>
        /// <returns></returns>
        public ToolIO GetInput(string IOName)
        {
            for (int i = 0; i < toolInput.Count; i++)
            {
                if (toolInput[i].IOName == IOName)
                    return toolInput[i];
            }
            return new ToolIO();
        }
        /// <summary>
        /// 以IO名获取IO对象
        /// </summary>
        /// <param name="IOName"></param>
        /// <returns></returns>
        public ToolIO GetOutput(string IOName)
        {
            for (int i = 0; i < toolOutput.Count; i++)
            {
                if (toolOutput[i].IOName == IOName)
                    return toolOutput[i];
            }
            return new ToolIO();
        }
        /// <summary>
        /// 移除工具输入项
        /// </summary>
        /// <param name="IOName"></param>
        public void RemoveInputIO(string IOName)
        {
            for (int i = 0; i < toolInput.Count; i++)
            {
                if (toolInput[i].IOName == toolName)
                    toolInput.RemoveAt(i);
            }
        }
        /// <summary>
        /// 移除工具输出项
        /// </summary>
        /// <param name="IOName"></param>
        public void RemoveOutputIO(string IOName)
        {
            for (int i = 0; i < toolOutput.Count; i++)
            {
                if (toolOutput[i].IOName == toolName)
                    toolOutput.RemoveAt(i);
            }
        }
    }
}
