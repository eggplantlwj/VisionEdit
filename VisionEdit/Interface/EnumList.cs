using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisionEdit
{
    public enum ToolType
    {
        None,
        Job,
        HalconInterface,
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
}
