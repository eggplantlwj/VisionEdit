using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HalconDotNet;

namespace DataStruct
{
    public class DataStruct
    {
        /// <summary>
        /// XYU结果
        /// </summary>
        [Serializable]
        public class PosXYU
        {
            public double X;
            public double Y;
            public double U;
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
        /// <summary>
        /// XYU结果
        /// </summary>
        [Serializable]
        public class XYU
        {
            public XYU()
            {
                _point = new XY();
            }
            public XYU(double x, double y, double u)
            {
                _point = new XY();
                _point.X = x;
                _point.Y = y;
                _u = u;
            }
            private XY _point;

            public XY Point
            {
                get { return _point; }
                set { _point = value; }
            }
            private double _u;
            public double U
            {
                get
                {
                    return Math.Round(_u, 3);
                }
                set { _u = value; }
            }
            /// <summary>
            /// 将XYU类型转化成格式化字符串
            /// </summary>
            /// <returns></returns>
            internal string ToFormatStr()
            {
                return (Point.X >= 0 ? "+" + Point.X.ToString("000.000") : Point.X.ToString("000.000")) + (Point.Y >= 0 ? "+" + Point.Y.ToString("000.000") : Point.Y.ToString("000.000")) + (U >= 0 ? "+" + U.ToString("000.000") : U.ToString("000.000"));

                //  return (X >= 0 ? "+" + X.ToString("000.000") : X.ToString("000.000")) + ";" + (Y >= 0 ? "+" + Y.ToString("000.000") : Y.ToString("000.000")) + ";" + (U >= 0 ? "+" + U.ToString("000.000") : U.ToString("000.000"));
            }
            /// <summary>
            /// 将XYU类型转化成格式化字符串
            /// </summary>
            /// <returns></returns>
            internal string ToFormatStrTwoSpace()
            {
                return (Point.X >= 0 ? "+" + Point.X.ToString("000.000") : Point.X.ToString("000.000")) + (Point.Y >= 0 ? "  +" + Point.Y.ToString("000.000") : Point.Y.ToString("000.000")) + (U >= 0 ? "  +" + U.ToString("000.000") : U.ToString("000.000"));

                //  return (X >= 0 ? "+" + X.ToString("000.000") : X.ToString("000.000")) + ";" + (Y >= 0 ? "+" + Y.ToString("000.000") : Y.ToString("000.000")) + ";" + (U >= 0 ? "+" + U.ToString("000.000") : U.ToString("000.000"));
            }
            internal string ToShowTip()
            {
                return Point.X.ToString() + " | " + Point.Y.ToString() + " | " + U.ToString();
            }
            /// <summary>
            /// 重写 -
            /// </summary>
            /// <param name="p1">点1</param>
            /// <param name="p2">点2</param>
            /// <returns></returns>
            public static XYU operator -(XYU p1, XYU p2)
            {
                return new XYU(p1.Point.X - p2.Point.X, p1.Point.Y - p2.Point.Y, p1.U - p2.U);
            }
            /// <summary>
            /// 重写 +
            /// </summary>
            /// <param name="p1">点1</param>
            /// <param name="p2">点2</param>
            /// <returns></returns>
            public static XYU operator +(XYU p1, XYU p2)
            {
                return new XYU(p1.Point.X + p2.Point.X, p1.Point.Y + p2.Point.Y, p1.U + p2.U);
            }
        }

        [Serializable]
        public class XY
        {
            internal XY() { }
            internal XY(double x, double y)
            {
                this.X = x;
                this.Y = y;
            }
            private double _x;

            public double X
            {
                get
                {
                    return Math.Round(_x, 3);
                }
                set { _x = value; }
            }
            private double _y;

            public double Y
            {
                get
                {
                    return Math.Round(_y, 3);
                }
                set { _y = value; }
            }
            /// <summary>
            /// 重写 -
            /// </summary>
            /// <param name="p1">点1</param>
            /// <param name="p2">点2</param>
            /// <returns></returns>
            public static XY operator -(XY p1, XY p2)
            {
                return new XY(p1.X - p2.X, p1.Y - p2.Y);
            }
            /// <summary>
            /// 重写 +
            /// </summary>
            /// <param name="p1">点1</param>
            /// <param name="p2">点2</param>
            /// <returns></returns>
            public static XY operator +(XY p1, XY p2)
            {
                return new XY(p1.X + p2.X, p1.Y + p2.Y);
            }
            /// <summary>
            /// 获得点矢量长度
            /// </summary>
            internal double GetDistance
            {
                get
                {
                    return Math.Sqrt(X * X + Y * Y);
                }
            }
            internal string ToShowTip()
            {
                return X.ToString() + " | " + Y.ToString();
            }
        }


        [Serializable]
        public class Line
        {
            public Point StartPoint;
            public Point EndPoint;
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
        public class Point
        {
            public Point() { }
            public Point(double x, double y)
            {
                this.Row = x;
                this.Col = y;
            }
            public double Row;
            public double Col;
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
            public double GetDistance
            {
                get
                {
                    return Math.Sqrt(Row * Row + Col * Col);
                }
            }
            public string ToShowTip()
            {
                return Row.ToString() + " | " + Col.ToString();
            }
        }
    }
}
