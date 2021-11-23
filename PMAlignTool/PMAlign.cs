/*
* ==============================================================================
*
* Filename: PMAlign
* Description: 
*
* Version: 1.0
* Created: 2021/3/30 14:07:10
*
* Author: liu.wenjie
*
* ==============================================================================
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonMethods;
using HalconDotNet;
using ToolBase;
using static DataStruct.DataStruct;

namespace PMAlignTool
{
    [Serializable]
    public class PMAlign:IToolBase
    {

        /// <summary>
        /// 是否显示匹配到的模板
        /// </summary>
        internal bool showTemplate { get; set; } = true;
        /// <summary>
        /// 是否显示中心十字架
        /// </summary>
        internal bool showCross { get; set; } = true;
        /// <summary>
        /// 是否显示特征
        /// </summary>
        internal bool showFeature { get; set; } = true;
        /// <summary>
        /// 显示结果序号
        /// </summary>
        internal bool showIndex { get; set; } = true;
        /// <summary>
        /// 是否显示搜索区域
        /// </summary>
        internal bool showSearchRegion { get; set; } = true;
        /// <summary>
        /// 模板句柄                                                   
        /// </summary>
        internal HTuple modelID { get; set; } = -1;
        /// <summary>
        /// 行列间隔像素数
        /// </summary>
        internal int spanPixelNum { get; set; } = 100;
        /// <summary>
        /// 排序模式
        /// </summary>
      //  internal SortMode sortMode = SortMode.从上至下且从左至右;
        /// <summary>
        /// 模板区域
        /// </summary>
        internal HObject templateRegion { get; set; }
        /// <summary>
        /// 在进行模板创建及匹配时进行的图像预处理
        /// </summary>
        public ImagePreProcess imageProcess { get; set; } = new ImagePreProcess();

        internal HObject totalRegion;
        /// <summary>
        /// 搜索区域图像
        /// </summary>
        internal HObject reducedImage;
        /// <summary>
        /// 最小匹配分数
        /// </summary>
        internal double minScore { get; set; } = 0.5;
        /// <summary>
        /// 匹配个数
        /// </summary>
        internal int matchNum { get; set; } = 1;
        /// <summary>
        /// 起始角度
        /// </summary>
        internal int startAngle { get; set; } = -30;
        /// <summary>
        /// 角度范围
        /// </summary>
        internal int angleRange { get; set; } = 30;
        /// <summary>
        /// 角度步长
        /// </summary>
        internal int angleStep { get; set; } = 1;
        /// <summary>
        /// 对比度
        /// </summary>
        internal int contrast { get; set; } = 30;
        /// <summary>
        /// 训练时所使用的模板图像，不点击获取图像时，不进行更新
        /// </summary>
        public HObject oldTrainImage { get; set; }

        internal void DispMainWindow(object dispHWindow)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 极性
        /// </summary>
        internal string polarity { get; set; } = "use_polarity";

        /// <summary>
        /// 工具锁
        /// </summary>
        private object obj { get; set; } = new object();
        /// <summary>
        /// 模板匹配结果
        /// </summary>
        internal List<XYU> L_result = new List<XYU>();

        public override void Run(SoftwareRunState softwareRunState)
        {
           
        }

        public override void DispImage()
        {
            if (inputImage != null)
            {
                FormPMAlignTool.Instance.myHwindow.DispHWindow.DispObj(inputImage);
            }
        }

        public override void DispMainWindow(HWindow window)
        {
            throw new NotImplementedException();
        }

        public void CreateModelTemplate()
        {

        }
    }
    [Serializable]
    public class ImagePreProcess
    {
        public ProcessAlg erosionValue1 { get; set; } = new ProcessAlg();
        public ProcessAlg dilationValue { get; set; } = new ProcessAlg();
        public ProcessAlg erosionValue2 { get; set; } = new ProcessAlg();
    }
    [Serializable]
    public class ProcessAlg
    {
        public double algValue { get; set; } = 0;
        public bool isEnable { get; set; } = false;
    }
}
