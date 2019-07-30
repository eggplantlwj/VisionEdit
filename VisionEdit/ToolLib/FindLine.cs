using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HalconDotNet;

namespace VisionEdit.ToolLib
{
    public class FindLine
    {
        /// <summary>
        /// 输入图像
        /// </summary>
        internal HObject inputImage;
        /// <summary>
        /// 运行工具时是否刷新输入图像
        /// </summary>
        internal bool updateImage = false;
        /// <summary>
        /// 输入姿态
        /// </summary>
        internal PosXYU inputPose = new PosXYU();
        /// <summary>
        /// 制作模板时的输入位姿
        /// </summary>
        internal PosXYU templatePose = new PosXYU();
        /// <summary>
        /// 期望线起点行坐标
        /// </summary>
        internal HTuple expectLineStartRow = 200;
        /// <summary>
        /// 卡尺
        /// </summary>
        internal HObject contours;
        /// <summary>
        /// 期望线起点列坐标
        /// </summary>
        internal HTuple expectLineStartCol = 200;
        /// <summary>
        /// 期望线终点行坐标
        /// </summary>
        internal HTuple expectLineEndRow = 200;
        /// <summary>
        /// 期望线终点列坐标
        /// </summary>
        internal HTuple expectLineEndCol = 600;
        /// <summary>
        /// 找边极性，从明到暗或从暗到明
        /// </summary>
        internal string polarity = "negative";
        /// <summary>
        /// 卡尺数量
        /// </summary>
        internal int cliperNum = 20;
        /// <summary>
        /// 卡尺高
        /// </summary>
        internal int length = 80;
        /// <summary>
        /// 边阈值
        /// </summary>
        internal int threshold = 30;
        /// <summary>
        /// 选择所查找到的边
        /// </summary>
        internal string edgeSelect = "all";
        /// <summary>
        /// 分数阈值
        /// </summary>
        internal double minScore = 0.5;
        /// <summary>
        /// 找到的线段
        /// </summary>
        internal Line resultLine = new Line();
        /// <summary>
        /// 新的跟随姿态变化后的预期线信息
        /// </summary>
        HTuple newExpectLineStartRow = new HTuple(200), newExpectLineStartCol = new HTuple(200), newExpectLineEndRow = new HTuple(200), newExpectLineEndCol = new HTuple(600);
        /// <summary>
        /// 查找到的线的起点行坐标
        /// </summary>
        private HTuple _resultLineStartRow = 0;
        internal HTuple ResultLineStartRow
        {
            get
            {
                _resultLineStartRow = Math.Round((double)_resultLineStartRow, 3);
                return _resultLineStartRow;
            }
            set { _resultLineStartRow = value; }
        }
        /// <summary>
        /// 查找到的线的起点列坐标
        /// </summary>
        private HTuple _resultLineStartCol = 0;
        internal HTuple ResultLineStartCol
        {
            get
            {
                _resultLineStartCol = Math.Round((double)_resultLineStartCol, 3);
                return _resultLineStartCol;
            }
            set { _resultLineStartCol = value; }
        }
        /// <summary>
        /// 查找到的线的终点行坐标
        /// </summary>
        private HTuple _resultLineEndRow = 0;
        internal HTuple ResultLineEndRow
        {
            get
            {
                _resultLineEndRow = Math.Round((double)_resultLineEndRow, 3);
                return _resultLineEndRow;
            }
            set { _resultLineEndRow = value; }
        }
        /// <summary>
        /// 查找到的线的终点列坐标
        /// </summary>
        private HTuple _resultLineEndCol = 0;
        internal HTuple ResultLineEndCol
        {
            get
            {
                _resultLineEndCol = Math.Round((double)_resultLineEndCol, 3);
                return _resultLineEndCol;
            }
            set { _resultLineEndCol = value; }
        }
        /// <summary>
        /// 查找到线的方向
        /// </summary>
        private HTuple _angle = 0;
        internal HTuple Angle
        {
            get
            {
                _angle = Math.Round((double)_angle, 3);
                return _angle;
            }
            set { _angle = value; }
        }
    }
}
