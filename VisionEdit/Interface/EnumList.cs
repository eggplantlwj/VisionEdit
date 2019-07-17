using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisionEdit
{
    public enum ToolType:int
    {
        None,
        Job,
        HalconToolInterface,
        SDK_Basler,
        SDK_Congex,
        SDK_PointGray,
        SDK_IMAVision,
        SDK_MindVision,
        SDK_HIKVision,
        ShapeMatch,
        EyeHandCalibration,
        CircleCalibration,
        SubImage,
        BlobAnalyse,
        FindLine,
        FindCircle,
        CreateROI,
        CreatePosition,
        CoorTrans,
        OCR,
        Barcode,
        RegionFeature,
        RegionOperation,
        QRCode,
        KeyenceSR1000,
        DownCamAlign,
        ColorToRGB,
        DistancePL,
        DistanceSS,
        LLPoint,
        CodeEdit,
        Label,
        Logic,
        Output,
        CreateLine,
    }

    public enum DataType
    {
        String,
        Region,
        Image,
        Point,
        Line,
        Circle,
        Pose,
    }

    public enum ToolRunStatu
    {
        Not_Run,
        Not_Enabled,
        No_Input_Image,
        Not_Input_Image,
        Character_Untrained,
        Not_Assign_Image_Template,
        Not_Assign_Input_Image,
        Not_Assign_Input_Source,
        Not_Assign_Input_Pos,
        Not_Asign_Input_Source,
        Lack_Of_Input_Image,
        Lack_Of_Input_Search_Region,
        Not_Assign_Path,
        Not_Asign_Input_Image,
        Input_Image_Cannot_Be_Converted,
        Not_Create_Template,
        No_Image_In_Folder,
        File_Error_Or_Path_Invalid,
        Not_Assign_Acq_Device,
        Not_Succeed,
        Succeed,
        No_Input_String,
        未运行,
        未启用,
        缺少输入搜索区域,
        未指定路径,
        无输入图像,
        未创建模板,
        未训练字符,
        无输入字符串,
        未指定输入图像,
        未指定图像模板,
        缺少输入图像,
        未指定输入坐标点,
        未指定输入源,
        输入图像不能被转化,
        文件夹内无图像,
        图像文件异常或路径不合法,
        未指定采集设备,
        失败,
        成功,
    }
}
