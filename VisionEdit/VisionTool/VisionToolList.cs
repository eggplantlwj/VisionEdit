using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using HalconDotNet;
using VisionEdit.Interface;
using VisionEdit.ToolLib;

namespace VisionEdit.VisionTool
{
    [VisionToolAttribute(ToolType.HalconToolInterface)]
    public class HalconToolInterface : IToolInfo
    {
        // 必添加输出项
        ToolIO outputImage = new ToolIO("OutputImage", null, DataType.Image);
        public HalconToolInterface(string toolName)
        {
            enable = true;
            toolType = ToolType.HalconToolInterface;
            this.toolName = toolName;
            tool = new HalconTool();
            toolInput = new List<ToolIO>();
            toolOutput = new List<ToolIO>() { outputImage };
        }
    }
    [VisionToolAttribute(ToolType.FindLine)]
    public class FindLineToolInterface : IToolInfo
    {

    }
    [VisionToolAttribute(ToolType.BlobAnalyse)]
    public class BlobAnalyseToolInterface : IToolInfo
    {

    }
}
