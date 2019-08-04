using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonMethods;
using FindLineTool;
using HalconTool;

namespace VisionJobFactory
{
    [VisionToolAttribute(ToolType.HalconTool)]
    public class HalconToolInterface : IToolInfo
    {
        // 必添加输出项
        ToolIO outputImage = new ToolIO("OutputImage", null, DataType.Image);
        /// <summary>
        /// 获取工具的所有信息
        /// </summary>
        /// <param name="生成的工具名称"></param>
        public HalconToolInterface(string toolName)
        {
            enable = true;
            toolType = ToolType.HalconTool;
            this.toolName = toolName;
            tool = new HalconTool.HalconTool();
            FormTool = null;
            FormToolName = "HalconTool.FormHalconTool";
            toolInput = new List<ToolIO>();
            toolOutput = new List<ToolIO>() { outputImage };
        }

        /// <summary>
        /// 只获取选择工具的描述信息
        /// </summary>
        public HalconToolInterface()
        {
            toolDescription = "Halcon采集图像接口,可直接连接网口、USB等相机";
        }
    }
    [VisionToolAttribute(ToolType.FindLine)]
    public class FindLineToolInterface : IToolInfo
    {
        ToolIO inputImage = new ToolIO("InputImage", null, DataType.Image);
        ToolIO outputXld = new ToolIO("outputXld", null, DataType.Line);
        ToolIO startPointRow = new ToolIO("StartPointRow", null, DataType.Point);
        ToolIO startPointColumn = new ToolIO("StartPointRow", null, DataType.Point);
        ToolIO endPointRow = new ToolIO("EndPointRow", null, DataType.Point);
        ToolIO endPointColumn = new ToolIO("EndPointColumn", null, DataType.Point);
        public FindLineToolInterface(string toolName)
        {
            enable = true;
            toolType = ToolType.FindLine;
            this.toolName = toolName;
            tool = new FindLine();
            FormToolName = "FindLineTool.FormFindLine";
            FormTool = null;
            toolInput = new List<ToolIO>() { inputImage };
            toolOutput = new List<ToolIO>() { outputXld, startPointRow, startPointColumn, endPointRow, endPointColumn };
        }
        /// <summary>
        /// 只获取选择工具的描述信息
        /// </summary>
        public FindLineToolInterface()
        {
            toolDescription = "找线工具";
        }
    }

    [VisionToolAttribute(ToolType.BlobAnalyse)]
    public class BlobAnalyseToolInterface : IToolInfo
    {

    }
}
