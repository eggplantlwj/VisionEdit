using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HalconDotNet;

namespace VisionEdit
{
    /// <summary>
    /// XYU结果
    /// </summary>
    [Serializable]
    internal class PosXYU
    {
        internal double X;
        internal double Y;
        internal double U;
        /// <summary>
        /// 将XYU类型转化成格式化字符串
        /// </summary>
        /// <returns></returns>
        internal string ToFormatStr()
        {
            return (X >= 0 ? "+" + X.ToString("0000.000") : X.ToString("0000.000")) + "," + (Y >= 0 ? "+" + Y.ToString("0000.000") : Y.ToString("0000.000")) + "," + (U >= 0 ? "+" + U.ToString("0000.000") : U.ToString("0000.000"));
        }
        internal string ToShowTip()
        {
            return X.ToString() + " | " + Y.ToString() + " | " + U.ToString();
        }
    }

    [Serializable]
    internal class Line
    {
        internal Point StartPoint;
        internal Point EndPoint;
        internal string ToShowTip()
        {
            return StartPoint.Row.ToString() + " | " + StartPoint.Col.ToString() + " | " + EndPoint.Row.ToString() + " | " + EndPoint.Col.ToString();
        }
        private HTuple _angle;
        public double Angle
        {
            get
            {
                HOperatorSet.AngleLx(StartPoint.Row, StartPoint.Col, EndPoint.Row, EndPoint.Col, out _angle);
                return _angle;
            }
        }
    }

    [Serializable]
    internal class Point
    {
        internal Point() { }
        internal Point(double x, double y)
        {
            this.Row = x;
            this.Col = y;
        }
        internal double Row;
        internal double Col;
        /// <summary>
        /// 重写 -
        /// </summary>
        /// <param name="p1">点1</param>
        /// <param name="p2">点2</param>
        /// <returns></returns>
        public static Point operator -(Point p1, Point p2)
        {
            return new Point(p1.Row - p2.Row, p1.Col - p2.Col);
        }
        /// <summary>
        /// 获得点矢量长度
        /// </summary>
        internal double GetDistance
        {
            get
            {
                return Math.Sqrt(Row * Row + Col * Col);
            }
        }
        internal string ToShowTip()
        {
            return Row.ToString() + " | " + Col.ToString();
        }
    }
}
