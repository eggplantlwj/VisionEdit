using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonMethods;
using HalconDotNet;
using static DataStruct.DataStruct;

namespace CaliperTool
{
    [Serializable]
    public class CaliperTool:IToolInfo
    {
        public bool toolEnable = true;
        /// <summary>
        /// 输入姿态
        /// </summary>
        public PosXYU inputPose = new PosXYU();
        /// <summary>
        /// 制作模板时的输入位姿
        /// </summary>
        public PosXYU templatePose = new PosXYU();
        /// <summary>
        /// 卡尺
        /// </summary>
        public HObject contoursDisp = null;
        /// <summary>
        /// 箭头
        /// </summary>
        public HObject arrowDisp = null;
        /// <summary>
        /// 交点
        /// </summary>
        public HObject crossDisp = null;
        /// <summary>
        /// 期望矩形中心行坐标
        /// </summary>
        public HTuple expectRecStartRow = 200;
        /// <summary>
        /// 期望矩形中心列坐标
        /// </summary>
        public HTuple expectRecStartColumn = 200;
        /// <summary>
        /// 期望矩形起点方向
        /// </summary>
        public HTuple expectAngle = 0;
        /// <summary>
        /// 卡尺高
        /// </summary>
        public int length1 = 40;
        /// <summary>
        /// 卡尺宽
        /// </summary>
        public int length2 = 40;
        /// <summary>
        /// 找边极性，从明到暗或从暗到明
        /// </summary>
        public string polarity = "negative";
        /// <summary>
        /// 边阈值
        /// </summary>
        public int threshold = 30;
        /// <summary>
        /// 边Sigma
        /// </summary>
        public double sigma = 1.0;
        /// <summary>
        /// 选择所查找到的点
        /// </summary>
        public string edgeSelect = "all";
        /// <summary>
        /// 矩形框显示
        /// </summary>
        public bool dispRec = true;
        /// <summary>
        /// 交点显示
        /// </summary>
        public bool dispCross = true;
        /// <summary>
        /// 找到的线段
        /// </summary>
        public Point resultPoint = null;
        /// <summary>
        /// 显示的线
        /// </summary>
        public HObject LineDisp = null;
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

        public HObject inputImage { get; set; } = null;

        public ToolRunStatu toolRunStatu { get; set; } = ToolRunStatu.Not_Run;
    }
}
