using System;
using HalconDotNet;
using static DataStruct.DataStruct;
using ToolBase;
using CommonMethods;

namespace FindCircle
{
    [Serializable]
    public class FindClrcle: IToolBase
    {
        /// <summary>
        /// 输入位姿
        /// </summary>
        internal PosXYU inputPose = new PosXYU();
        /// <summary>
        /// 期望圆圆心行坐标
        /// </summary>
        internal HTuple expectCircleRow = 300;
        /// <summary>
        /// 期望圆圆心列坐标
        /// </summary>
        internal HTuple expectCircleCol = 300;
        /// <summary>
        /// 期望圆半径
        /// </summary>
        internal HTuple expectCircleRadius = 200;
        /// <summary>
        /// 查找到圆的圆心行坐标
        /// </summary>
        private double _resultCircleRow = 0;
        internal double ResultCircleRow
        {
            get
            {
                return Math.Round(_resultCircleRow, 3);
            }
            set { _resultCircleRow = value; }
        }
        /// <summary>
        /// 查找到的圆的圆心列坐标
        /// </summary>
        private double _resultCircleCol = 0;
        internal double ResultCircleCol
        {
            get
            {
                return Math.Round(_resultCircleCol, 3);
            }
            set { _resultCircleCol = value; }
        }
        /// <summary>
        /// 查找到的圆的半径
        /// </summary>
        private double resultCircleRadius = 0;
        internal double ResultCircleRadius
        {
            get
            {
                return Math.Round(resultCircleRadius, 3);
            }
        }

        public SoftwareRunState softwareRunState
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public ToolRunStatu toolRunStatu
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public string runMessage
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public string runTime
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        HObject IToolBase.inputImage
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        /// 起始角度
        /// </summary>
        internal double startAngle = 10;
        /// <summary>
        /// 结束角度
        /// </summary>
        internal double endAngle = 360;
        /// <summary>
        /// 运行工具时是否刷新输入图像
        /// </summary>
        internal bool updateImage = false;
        /// <summary>
        /// 圆环径向长度
        /// </summary>
        internal double ringRadiusLength = 80;
        /// <summary>
        /// 边阈值
        /// </summary>
        internal int threshold = 30;
        /// <summary>
        /// 卡尺
        /// </summary>
        internal HObject contours;
        /// <summary>
        /// 找边极性，从明到暗或从暗到明
        /// </summary>
        internal string polarity = "negative";
        /// <summary>
        /// 卡尺数量
        /// </summary>
        internal int cliperNum = 20;
        /// <summary>
        /// 输入图像
        /// </summary>
        internal HObject inputImage;
        /// <summary>
        /// 新的跟随姿态变化后的预期圆信息
        /// </summary>
        HTuple newExpecCircleRow = new HTuple(200), newExpectCircleCol = new HTuple(200), newExpectCircleRadius = new HTuple(200);
        /// <summary>
        /// 制作模板时的输入位姿
        /// </summary>
        internal PosXYU templatePose = new PosXYU();

        public void Run(SoftwareRunState softwareRunState)
        {
            throw new NotImplementedException();
        }

        public void DispImage()
        {
            throw new NotImplementedException();
        }
    }
}
