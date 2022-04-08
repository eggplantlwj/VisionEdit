using CaliperTool;
using CommonMethods;
using FindLineTool;
using HalconTool;
using PMAlignTool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisionJobFactory
{
    [Serializable]
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
        /// 只获取选择工具的描述信息..
        /// </summary>
        public HalconToolInterface()
        {
            toolDescription = "Halcon采集图像接口,可直接连接网口、USB等相机";
        }
    }
    [Serializable]
    [VisionToolAttribute(ToolType.FindLine)]
    public class FindLineToolInterface : IToolInfo
    {
        ToolIO inputImage = new ToolIO("InputImage", null, DataType.Image);
        ToolIO inputPos = new ToolIO("InputPos", null, DataType.Pose);
        ToolIO outputXld = new ToolIO("outputXld", null, DataType.Line);
        ToolIO startPointRow = new ToolIO("StartPointRow", null, DataType.IntValue);
        ToolIO startPointColumn = new ToolIO("StartPointColumn", null, DataType.IntValue);
        ToolIO endPointRow = new ToolIO("EndPointRow", null, DataType.IntValue);
        ToolIO endPointColumn = new ToolIO("EndPointColumn", null, DataType.IntValue);
        public FindLineToolInterface(string toolName)
        {
            enable = true;
            toolType = ToolType.FindLine;
            this.toolName = toolName;
            tool = new FindLine();
            FormToolName = "FindLineTool.FormFindLine";
            FormTool = null;
            toolInput = new List<ToolIO>() { inputImage, inputPos };
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
    [Serializable]
    [VisionToolAttribute(ToolType.Caliper)]
    public class CaliperInterface : IToolInfo
    {
        ToolIO inputImage = new ToolIO("InputImage", null, DataType.Image);
        ToolIO inputPos = new ToolIO("InputPos", null, DataType.Pose);
        ToolIO inputCenterRow = new ToolIO("inputCenterRow", null, DataType.IntValue);
        ToolIO inputCenterColumn = new ToolIO("inputCenterColumn", null, DataType.IntValue);
        ToolIO inputPhi = new ToolIO("inputPhi", null, DataType.IntValue);
        ToolIO outputCenterRow = new ToolIO("outputCenterRow", null, DataType.IntValue);
        ToolIO outputCenterColumn = new ToolIO("outputCenterColumn", null, DataType.IntValue);
        public CaliperInterface(string toolName)
        {
            enable = true;
            toolType = ToolType.Caliper;
            this.toolName = toolName;
            tool = new Caliper();
            FormToolName = "CaliperTool.FormCaliper";
            FormTool = null;
            toolInput = new List<ToolIO>() { inputImage, inputCenterRow, inputCenterColumn, inputPhi , inputPos };
            toolOutput = new List<ToolIO>() { outputCenterRow, outputCenterColumn };
        }
        /// <summary>
        /// 只获取选择工具的描述信息
        /// </summary>
        public CaliperInterface()
        {
            toolDescription = "卡尺工具";
        }
    }
    [Serializable]
    [VisionToolAttribute(ToolType.BlobAnalyse)]
    public class BlobAnalyseToolInterface : IToolInfo
    {

    }

    [Serializable]
    [VisionToolAttribute(ToolType.PMAlignTool)]
    public class PMAlignToolToolInterface : IToolInfo
    {
        ToolIO inputImage = new ToolIO("InputImage", null, DataType.Image);
        ToolIO outPose = new ToolIO("GetPose", null, DataType.Pose);
        ToolIO outPoseX = new ToolIO("GetPose.X", null, DataType.IntValue);
        ToolIO outPoseY = new ToolIO("GetPose.Y", null, DataType.IntValue);
        ToolIO outPoseR = new ToolIO("GetPose.Z", null, DataType.DoubleValue);
        ToolIO outPoseScore = new ToolIO("GetPose.Score", null, DataType.DoubleValue);
        public PMAlignToolToolInterface(string toolName)
        {
            enable = true;
            toolType = ToolType.PMAlignTool;
            this.toolName = toolName;
            tool = new PMAlign();
            FormToolName = "PMAlignTool.FormPMAlignTool";
            FormTool = null;
            toolInput = new List<ToolIO>() { inputImage };
            toolOutput = new List<ToolIO>() { outPose, outPoseX, outPoseY, outPoseR, outPoseScore };
            
        }
        /// <summary>
        /// 只获取选择工具的描述信息
        /// </summary>
        public PMAlignToolToolInterface()
        {
            toolDescription = "模板匹配工具，可得到根据图像捕获特征的姿态";
        }
    }
}
