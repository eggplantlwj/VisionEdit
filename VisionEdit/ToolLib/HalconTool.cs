using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HalconDotNet;

namespace VisionEdit.ToolLib
{
    public class HalconTool
    {
        /// <summary>
        /// 流程名
        /// </summary>
        internal string jobName = string.Empty;
        /// <summary>
        /// 曝光时间
        /// </summary>
        internal Int32 exposure = 30;
        /// <summary>
        /// 图像的获取方式
        /// </summary>
        //internal ImageSourceMode imageSourceMode = ImageSourceMode.FormDevice;
        /// <summary>
        /// 是否处于实时采集模式
        /// </summary>
        internal bool realTimeMode = false;
        /// <summary>
        /// 相机句柄
        /// </summary>
        internal Int64 cameraHandle = -1;
        /// <summary>
        /// 设备信息字符串，包括了相机SN、品牌等信息
        /// </summary>
        internal string deviceInfoStr = string.Empty;
        /// <summary>
        /// 实时采集线程
        /// </summary>
        internal static Thread th_acq;         //Thread类不能序列化，所以申明为静态的
        /// <summary>
        /// 读取文件夹图像模式时每次运行是否自动切换图像
        /// </summary>
        internal bool autoSwitch = true;
        /// <summary>
        /// 是否将彩色图像转化成灰度图像 
        /// </summary>
        internal bool RGBToGray = true;
        /// <summary>
        /// 工作模式为读取文件夹图像时，当前图像的名称
        /// </summary>
        internal string currentImageName = "";
        /// <summary>
        /// 工作模式为读取文件夹图像时，当前显示的图片的索引
        /// </summary>
        internal int currentImageIndex = 0;
        /// <summary>
        /// 文件夹中的图像文件集合
        /// </summary>
        internal List<string> L_imageFile = new List<string>();
        /// <summary>
        /// 单张图像的文件路径
        /// </summary>
        internal string imagePath = string.Empty;
        /// <summary>
        /// 图像文件夹路径
        /// </summary>
        internal string imageDirectoryPath = string.Empty;
        /// <summary>
        /// 输出图像
        /// </summary>
        internal HObject outputImage;
        /// <summary>
        /// 读取单张图像或批量读取文件夹图像工作模式
        /// </summary>
        //internal WorkMode workMode = WorkMode.ReadMultImage;
    }
}
