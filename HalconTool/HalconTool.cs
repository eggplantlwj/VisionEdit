using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommonMethods;
using HalconDotNet;
using ToolBase;
using System.Diagnostics;
using ViewROI;
using System.IO;

namespace HalconTool
{
    [Serializable]
    public class HalconTool: IToolBase
    {
        /// <summary>
        /// 流程名
        /// </summary>
        public string jobName = string.Empty;
        /// <summary>
        /// 曝光时间
        /// </summary>
        public Int32 exposure = 5;
        /// <summary>
        /// 图像的获取方式
        /// </summary>
        public ImageSourceMode imageSourceMode = ImageSourceMode.FormDevice;
        /// <summary>
        /// 是否处于实时采集模式
        /// </summary>
        public bool realTimeMode = false;
        /// <summary>
        /// 相机句柄
        /// </summary>
        public Int64 cameraHandle = -1;
        /// <summary>
        /// 设备信息字符串，包括了相机SN、品牌等信息
        /// </summary>
        public string deviceInfoStr = string.Empty;
        /// <summary>
        /// 实时采集线程
        /// </summary>
        public static Thread th_acq ;         //Thread类不能序列化，所以申明为静态的
        /// <summary>
        /// 读取文件夹图像模式时每次运行是否自动切换图像
        /// </summary>
        public bool autoSwitch = true;
        /// <summary>
        /// 是否将彩色图像转化成灰度图像 
        /// </summary>
        public bool RGBToGray = true;
        /// <summary>
        /// 工作模式为读取文件夹图像时，当前图像的名称
        /// </summary>
        public string currentImageName = "";
        /// <summary>
        /// 工作模式为读取文件夹图像时，当前显示的图片的索引
        /// </summary>
        public int currentImageIndex = 0;
        /// <summary>
        /// 文件夹中的图像文件集合
        /// </summary>
        public List<string> L_imageFile = new List<string>();
        /// <summary>
        /// 单张图像的文件路径
        /// </summary>
        public string imagePath = string.Empty;
        /// <summary>
        /// 图像文件夹路径
        /// </summary>
        public string imageDirectoryPath = string.Empty;
        /// <summary>
        /// 输出图像
        /// </summary>
        [NonSerialized]
        public HObject outputImage = new HObject();
        /// <summary>
        /// 输出图像的路径
        /// </summary>
        public string outputImageFilePath = null;
        /// <summary>
        /// 读取单张图像或批量读取文件夹图像工作模式
        /// </summary>
        internal WorkMode workMode = WorkMode.ReadMultImage;


        public override void Run(SoftwareRunState softwareState)
        {
            Stopwatch sw = new Stopwatch();
            sw.Restart();
            softwareRunState = softwareState;
            if(workMode == WorkMode.ReadOneImage)
            {
                DispImage();
            }
            else
            {
                if (currentImageIndex <= L_imageFile.Count && L_imageFile.Count != 0)
                {
                    currentImageIndex = currentImageIndex == L_imageFile.Count ? 0 : currentImageIndex;
                    outputImageFilePath = L_imageFile[currentImageIndex];
                    DispImage();
                    currentImageName = Path.GetFileName(L_imageFile[currentImageIndex]);
                    if(softwareState == SoftwareRunState.Release)
                        currentImageIndex++;
                }
            }
            
            SetToolStatusDisp();
            sw.Stop();
            runTime = $"工具运行时间：{sw.ElapsedMilliseconds.ToString()} ms";
        }

        public override void DispImage()
        {
            HObject image = new HObject();
            try
            {
                if(outputImageFilePath != null && outputImageFilePath != "") 
                {
                    HOperatorSet.ReadImage(out image, outputImageFilePath);
                    if (RGBToGray)
                    {
                        HTuple channel;
                        HOperatorSet.CountChannels(image, out channel);
                        if (channel == 3)
                            HOperatorSet.Rgb1ToGray(image, out image);
                    }
                    outputImage = image;
                }
                else
                {
                    runMessage = $"图像文件路径为空！";
                    toolRunStatu = ToolRunStatu.File_Error_Or_Path_Invalid;
                    return;
                }
            }
            catch(Exception ex)
            {
                if(softwareRunState == SoftwareRunState.Debug)
                {
                    runMessage = $"图像文件异常或路径不合法{ex}";
                    toolRunStatu = ToolRunStatu.File_Error_Or_Path_Invalid;
                }
                return;
            }
            if (outputImage != null)
            {
                if (softwareRunState == SoftwareRunState.Debug)
                {
                    FormHalconTool.Instance.myHwindow.DispImage(outputImage);
                }
                
            }
            else
            {
                runMessage = $"图像为空！";
                toolRunStatu = ToolRunStatu.Lack_Of_Input_Image;
                return;
            }
            toolRunStatu = ToolRunStatu.Succeed;
        }
        public void SetToolStatusDisp()
        {
            FormHalconTool.Instance.lb_RunStatus.Text = toolRunStatu == ToolRunStatu.Succeed ? "工具运行成功！" : $"工具运行异常, 异常原因：{runMessage}";
            FormHalconTool.Instance.lb_RunTime.Text = runTime;
            if (toolRunStatu == ToolRunStatu.Succeed)
            {
                FormHalconTool.Instance.statusStrip.BackColor = System.Drawing.Color.LimeGreen;
            }
            else
            {
                FormHalconTool.Instance.statusStrip.BackColor = System.Drawing.Color.Red;
            }
        }

        public override void DispMainWindow(HWindowTool_Smart window)
        {
            throw new NotImplementedException();
        }
    }

    
}
