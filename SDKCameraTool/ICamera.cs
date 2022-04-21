using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDKCameraTool
{
    public interface ICamera
    {
        /// <summary>
        /// CaemraID
        /// </summary>
        [CategoryAttribute("CaemraID")]
        int cameraID { get; }
        /// <summary>
        /// 
        /// </summary>
        CamereaCompanyType CompanyType { get; }
        /// <summary>
        /// 相机名称
        /// </summary>
        [CategoryAttribute("相机名称")]
        string cameraName { get; set; }
        /// <summary>
        /// bmp图像
        /// </summary>
        [CategoryAttribute("获取的图像")]
        Bitmap bmpImage { get; }
        /// <summary>
        /// 曝光值
        /// </summary>
        [CategoryAttribute("相机曝光")]
        float fExpTime { get; set; }
        /// <summary>
        /// 触发方式
        /// </summary>
        [CategoryAttribute("相机触发模式")]
        TriggerMode triggerMode { get; set; }
        /// <summary>
        /// 触发源
        /// </summary>
        [CategoryAttribute("相机触发源")]
        TriggerSouce triggerSource { get; set; }
        /// <summary>
        /// 相机序列号，相机调用唯一标识
        /// </summary>
        [CategoryAttribute("相机序列号")]
        string sSerialNumber { get; set; }
        /// <summary>
        /// 增益
        /// </summary>
        [CategoryAttribute("相机增益")]
        float fGain { get; set; }
        /// <summary>
        /// 伽马
        /// </summary>
        [CategoryAttribute("相机伽马值")]
        float iGamma { get; set; }
        /// <summary>
        /// 伽马使能
        /// </summary>
        [CategoryAttribute("相机伽马使能")]
        bool bGammaEnable { get; set; }
        /// <summary>
        /// 感兴趣区域宽度
        /// </summary>
        [CategoryAttribute("ROI宽")]
        int Width { get; set; }
        /// <summary>
        /// 感兴趣区域高度
        /// </summary>
        [CategoryAttribute("ROI高")]
        int Height { get; set; }
        /// <summary>
        /// X偏移
        /// </summary>
        [CategoryAttribute("X偏移")]
        int OffsetX { get; set; }
        /// <summary>
        /// Y偏移
        /// </summary>
        [CategoryAttribute("Y偏移")]
        int OffsetY { get; set; }
        /// <summary>
        /// 触发拍照延时
        /// </summary>
        int TriggerDelay { get; set; }
        /// <summary>
        /// 是否作为飞拍使用
        /// </summary>
        bool isFlowAcq { get; set; }
        /// <summary>
        /// 该相机触发次数
        /// </summary>
        int TriggerCount { get; set; }
        /// <summary>
        /// 该相机出来的图像是否需要经过标定
        /// </summary>
        bool IsNeedCalibration { get; set; }
        string CxpFilePath { get; set; }
        /// <summary>
        /// 打开相机
        /// </summary>
        /// <returns></returns>
        int OpenCam(CaptureMode captureMode);
        /// <summary>
        /// 关闭相机
        /// </summary>
        /// <returns></returns>
        int CloseCam();
        /// <summary>
        /// 取图
        /// </summary>
        /// <returns></returns>
        int Snap();
        /// <summary>
        /// 被动触发事件
        /// </summary>
        event EventHandler<EventImageTrigger> ImageTrigger;
    }

    public enum CamereaCompanyType
    {
        HIKVision,
        HIKVision_CXP,
        Ajhua,
        Basler,
        FLIR,
        File,
    }

    [Serializable]
    public class EventImageTrigger : EventArgs
    {
        public string cameraName { get; set; }
        public Bitmap image { get; set; }
        public int TriggerCount { get; set; }
    }
    public class EventIntPtrImageTrigger : EventArgs
    {
        public string cameraName { get; set; }
        public IntPtr pImage { get; set; }
        public int imageWidth { get; set; }
        public int imageHeight { get; set; }
    }
    public enum TriggerMode
    {
        Off = 0,
        On
    }

    public enum TriggerSouce
    {
        HIKLine0 = 0,
        HIKSoftWare = 1,
        FLIRLine0 = 2,
        FLIRSoftWare = 3,
        SoftWareHIK = 7
    }
    public enum CaptureMode
    {
        Positive,
        CallBack
    }
    /// <summary>
    /// 每次需从相机读取的参数
    /// </summary>
    public class CameraInfo
    {
    }
}
