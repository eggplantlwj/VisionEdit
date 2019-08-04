using System;
using HalconDotNet;
using DataStruct;
using static DataStruct.DataStruct;
using ToolBase;
using HalconWindow.HalconWindow;
using CommonMethods;

namespace FindLineTool
{
    [Serializable]
    public class FindLine:IToolBase
    {
        internal bool toolEnable = true;
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
        /// 卡尺宽
        /// </summary>
        internal int weidth = 5;
        /// <summary>
        /// 边阈值
        /// </summary>
        internal int threshold = 30;
        /// <summary>
        /// 边Sigma
        /// </summary>
        internal double sigma = 1.0;
        /// <summary>
        /// 选择所查找到的边
        /// </summary>
        internal string edgeSelect = "all";
        /// <summary>
        /// 分数阈值
        /// </summary>
        internal double _minScore = 0.5;
        internal double minScore
        {
            get
            {
                return _minScore;
            }
            set
            {
                if(minScore >= 1)
                {
                    _minScore = 1;
                }
                else if(minScore <= 0)
                {
                    _minScore = 0;
                }
                else
                {
                    _minScore = value;
                }
            }
        } 
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

        public HObject inputImage { get; set; }

        public ToolRunStatu toolRunStatu { get; set; }
        public void DispImage()
        {
            FormFindLine.Instance.myHwindow.HobjectToHimage(inputImage);
        }

        public void UpdateImage()
        {
            FormFindLine.Instance.myHwindow.ClearWindow();
            DispImage();
        }

        public void Run()
        {
            if(inputImage == null)
            {
                FormFindLine.Instance.TextBoxMessageDisp("图像为空", System.Drawing.Color.Red);
                toolRunStatu = ToolRunStatu.Not_Input_Image;
                return;
            }
            try
            {
                UpdateImage();
                if (inputPose != null)
                {
                    HTuple Row = inputPose.X - templatePose.X;
                    HTuple Col = inputPose.Y - templatePose.Y;
                    HTuple angle = inputPose.U - templatePose.U;

                    HTuple _homMat2D;
                    HOperatorSet.HomMat2dIdentity(out _homMat2D);
                    HOperatorSet.HomMat2dRotate(_homMat2D, (HTuple)(angle), (HTuple)templatePose.X, (HTuple)templatePose.Y, out _homMat2D);
                    HOperatorSet.HomMat2dTranslate(_homMat2D, (HTuple)(Row), (HTuple)(Col), out _homMat2D);

                    //对预期线的起始点做放射变换
                    HOperatorSet.AffineTransPixel(_homMat2D, (HTuple)expectLineStartRow, (HTuple)expectLineStartCol, out newExpectLineStartRow, out newExpectLineStartCol);
                    HOperatorSet.AffineTransPixel(_homMat2D, (HTuple)expectLineEndRow, (HTuple)expectLineEndCol, out newExpectLineEndRow, out newExpectLineEndCol);
                }
                else
                {
                    newExpectLineStartRow = expectLineStartRow;
                    newExpectLineStartCol = expectLineStartCol;
                    newExpectLineEndRow = expectLineEndRow;
                    newExpectLineEndCol = expectLineEndCol;
                }

                HTuple handleID;
                HOperatorSet.CreateMetrologyModel(out handleID);
                HTuple width, height;
                HOperatorSet.GetImageSize(inputImage, out width, out height);
                HOperatorSet.SetMetrologyModelImageSize(handleID, width[0], height[0]);
                HTuple index;
                HOperatorSet.AddMetrologyObjectLineMeasure(handleID, newExpectLineStartRow, newExpectLineStartCol, newExpectLineEndRow, newExpectLineEndCol, new HTuple(50), new HTuple(20), new HTuple(1), new HTuple(30), new HTuple(), new HTuple(), out index);

                //参数在这里设置
                HOperatorSet.SetMetrologyObjectParam(handleID, new HTuple("all"), new HTuple("measure_transition"), new HTuple(polarity));
                HOperatorSet.SetMetrologyObjectParam(handleID, new HTuple("all"), new HTuple("num_measures"), new HTuple(cliperNum));
                HOperatorSet.SetMetrologyObjectParam(handleID, new HTuple("all"), new HTuple("measure_length1"), new HTuple(length));
                HOperatorSet.SetMetrologyObjectParam(handleID, new HTuple("all"), new HTuple("measure_length2"), new HTuple(weidth));
                HOperatorSet.SetMetrologyObjectParam(handleID, new HTuple("all"), new HTuple("measure_threshold"), new HTuple(threshold));
                HOperatorSet.SetMetrologyObjectParam(handleID, new HTuple("all"), new HTuple("measure_select"), new HTuple(edgeSelect));
                HOperatorSet.SetMetrologyObjectParam(handleID, new HTuple("all"), new HTuple("measure_sigma"), new HTuple(sigma));
                HOperatorSet.SetMetrologyObjectParam(handleID, new HTuple("all"), new HTuple("min_score"), new HTuple(minScore));
                HOperatorSet.ApplyMetrologyModel(inputImage, handleID);

                //显示所有卡尺
                HTuple pointRow, pointCol;
                HOperatorSet.GetMetrologyObjectMeasures(out contours, handleID, new HTuple("all"), new HTuple("all"), out pointRow, out pointCol);
                HOperatorSet.SetColor(FormFindLine.Instance.myHwindow.hWindowControl.HalconWindow, new HTuple("blue"));
                HOperatorSet.DispObj(contours, FormFindLine.Instance.myHwindow.hWindowControl.HalconWindow);
                FormFindLine.Instance.myHwindow.DispObj(contours, "blue");

                //显示指示找线方向的箭头
                HTuple arrowAngle;
                HOperatorSet.AngleLx(newExpectLineStartRow, newExpectLineStartCol, newExpectLineEndRow, newExpectLineEndCol, out arrowAngle);
                #region 测试箭头

                
                #endregion
                arrowAngle = arrowAngle + Math.PI / 2;
                arrowAngle = arrowAngle.TupleDeg();
                HTuple row = (newExpectLineStartRow + newExpectLineEndRow) / 2;
                HTuple column = (newExpectLineStartCol + newExpectLineEndCol) / 2;
                double drow, dcolumn;
                double arrowLength = length + 100;
                if (0 <= arrowAngle && arrowAngle <= 90)
                {
                    drow = Math.Abs(arrowLength * Math.Sin(((HTuple)arrowAngle).TupleRad()));
                    dcolumn = Math.Abs(arrowLength * Math.Cos(((HTuple)arrowAngle).TupleRad()));
                    HOperatorSet.DispArrow(FormFindLine.Instance.myHwindow.hWindowControl.HalconWindow, row, column, row - drow, column + dcolumn, 5.0);
                }
                else if (arrowAngle > 90 && arrowAngle <= 180)
                {
                    drow = arrowLength * Math.Sin(((HTuple)(180 - arrowAngle)).TupleRad());
                    dcolumn = arrowLength * Math.Cos(((HTuple)(180 - arrowAngle)).TupleRad());
                    HOperatorSet.DispArrow(FormFindLine.Instance.myHwindow.hWindowControl.HalconWindow, row, column, row - drow, column - dcolumn, 5.0);
                }
                else if (arrowAngle < 0 && arrowAngle >= -90)
                {
                    drow = arrowLength * Math.Sin(((HTuple)arrowAngle * -1).TupleRad());
                    dcolumn = arrowLength * Math.Cos(((HTuple)arrowAngle * -1).TupleRad());
                    HOperatorSet.DispArrow(FormFindLine.Instance.myHwindow.hWindowControl.HalconWindow, row, column, row + drow, column + dcolumn, 5.0);
                }
                else if (arrowAngle < -90 && arrowAngle >= -180)
                {
                    drow = Math.Abs(arrowLength * Math.Sin(((HTuple)arrowAngle + 180).TupleRad()));
                    dcolumn = Math.Abs(arrowLength * Math.Cos(((HTuple)arrowAngle + 180).TupleRad()));
                    HOperatorSet.DispArrow(FormFindLine.Instance.myHwindow.hWindowControl.HalconWindow, row, column, row + drow, column - dcolumn, 5.0);
                }

                //把点显示出来
                HObject cross;
                HOperatorSet.GenCrossContourXld(out cross, pointRow, pointCol, new HTuple(12), new HTuple(0));
                HOperatorSet.SetColor(FormFindLine.Instance.myHwindow.hWindowControl.HalconWindow, new HTuple("orange"));
                HOperatorSet.DispObj(cross, FormFindLine.Instance.myHwindow.hWindowControl.HalconWindow);
                FormFindLine.Instance.myHwindow.DispObj(cross, "orange");

                //得到所找到的线
                HTuple parameter;
                HObject line;
                HOperatorSet.GetMetrologyObjectResult(handleID, new HTuple("all"), new HTuple("all"), new HTuple("result_type"), new HTuple("all_param"), out parameter);
                HOperatorSet.GetMetrologyObjectResultContour(out line, handleID, new HTuple("all"), new HTuple("all"), new HTuple(1.5));

                if (parameter.Length >= 4)
                {
                    ResultLineStartRow = parameter[0];
                    ResultLineStartCol = parameter[1];
                    ResultLineEndRow = parameter[2];
                    ResultLineEndCol = parameter[3];
                    Point start = new Point() { Row = ResultLineStartRow, Col = ResultLineStartCol };
                    Point end = new Point() { Row = ResultLineEndRow, Col = ResultLineEndCol };
                    resultLine = new Line() { StartPoint = start, EndPoint = end };

                    //显示找到的线
                    HOperatorSet.SetColor(FormFindLine.Instance.myHwindow.hWindowControl.HalconWindow, new HTuple("green"));
                    // HOperatorSet.DispObj(line, GetWindowHandle(jobName));
                    FormFindLine.Instance.myHwindow.hWindowControl.HalconWindow.SetLineWidth(2);
                    FormFindLine.Instance.myHwindow.DispObj(line, "green");
                }
                HOperatorSet.AngleLx(ResultLineStartRow, ResultLineStartCol, ResultLineEndRow, ResultLineEndCol, out _angle);
                HOperatorSet.ClearMetrologyModel(handleID);

                FormFindLine.Instance.tbx_resultStartRow.Text = ResultLineStartRow.ToString();
                FormFindLine.Instance.tbx_resultStartCol.Text = ResultLineEndCol.ToString();
                FormFindLine.Instance.tbx_resultEndRow.Text = ResultLineEndRow.ToString();
                FormFindLine.Instance.tbx_resultEndCol.Text = ResultLineEndCol.ToString();
                FormFindLine.Instance.TextBoxMessageDisp("运行成功", System.Drawing.Color.Green);
                toolRunStatu = ToolRunStatu.Succeed;
            }
            catch (Exception ex)
            {
                FormFindLine.Instance.TextBoxMessageDisp("工具运行异常" + ex.Message, System.Drawing.Color.Red);
            }
        }

        internal void DrawExpectLine(HWindow_Final myHwindow)
        {
            if(inputImage != null)
            {
                try
                {
                    myHwindow.DrawModel = true;
                    myHwindow.Focus();
                    HOperatorSet.SetColor(myHwindow.hWindowControl.HalconWindow, new HTuple("green"));
                    HOperatorSet.DrawLineMod(myHwindow.hWindowControl.HalconWindow, newExpectLineStartRow, newExpectLineStartCol, newExpectLineEndRow, newExpectLineEndCol, out expectLineStartRow, out expectLineStartCol, out expectLineEndRow, out expectLineEndCol);

                    if (inputPose != null)
                    {
                        templatePose.X = inputPose.X;
                        templatePose.Y = inputPose.Y;
                        templatePose.U = inputPose.U;
                    }

                    FormFindLine.Instance.tbx_expectLineStartRow.Text = expectLineStartRow.TupleString("10.3f");
                    FormFindLine.Instance.tbx_expectLineStartCol.Text = expectLineStartCol.TupleString("10.3f");
                    FormFindLine.Instance.tbx_expectLineEndRow.Text = expectLineEndRow.TupleString("10.3f");
                    FormFindLine.Instance.tbx_expectLineEndCol.Text = expectLineEndCol.TupleString("10.3f");
                    myHwindow.DrawModel = false;
                    
                    Run();
                }
                catch (Exception ex)
                {
                    FormFindLine.Instance.TextBoxMessageDisp(ex.Message, System.Drawing.Color.Red);
                }
            }
            else
            {
                FormFindLine.Instance.TextBoxMessageDisp("图像为空", System.Drawing.Color.Red);
            }
            
        }

        
    }
}
