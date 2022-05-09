using System;
using HalconDotNet;
using static DataStruct.DataStructClass;
using ToolBase;
using CommonMethods;
using System.Diagnostics;
using ViewROI;

namespace FindLineTool
{
    [Serializable]
    public class FindLine:IToolBase
    {
        public bool toolEnable = true;
        /// <summary>
        /// 输入姿态
        /// </summary>
        public HTuple inputPoseHomMat2D = new HTuple();
        /// <summary>
        /// 位置修正姿态
        /// </summary>
        public HTuple changePoseHomMat2D = new HTuple();
        /// <summary>
        /// 修改的位姿
        /// </summary>
        public HTuple changedPose = new HTuple();
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
        /// 期望线起点行坐标
        /// </summary>
        public HTuple expectLineStartRow = 200;
        /// <summary>
        /// 期望线起点列坐标
        /// </summary>
        public HTuple expectLineStartCol = 200;
        /// <summary>
        /// 期望线终点行坐标
        /// </summary>
        public HTuple expectLineEndRow = 200;
        /// <summary>
        /// 期望线终点列坐标
        /// </summary>
        public HTuple expectLineEndCol = 600;
        /// <summary>
        /// 新的跟随姿态变化后的预期线信息
        /// </summary>
        public HTuple modelStartRow = new HTuple(200), modelStartCol = new HTuple(200), modelEndRow = new HTuple(200), modelEndCol = new HTuple(600);
        /// <summary>
        /// 新的跟随姿态变化后的预期线信息
        /// </summary>
        public HTuple newExpectLineStartRow = new HTuple(200), newExpectLineStartCol = new HTuple(200), newExpectLineEndRow = new HTuple(200), newExpectLineEndCol = new HTuple(600);
        ///// <summary>
        ///// 区域中心行坐标
        ///// </summary>
        //public HTuple recCenterRow = 200;
        ///// <summary>
        ///// 区域中心列坐标
        ///// </summary>
        //public HTuple recCenterCol = 200;
        //public HTuple recAngle = 0;
        //public HTuple recWidth = 100;
        //public HTuple recLength = 200;
        /// <summary>
        /// 找边极性，从明到暗或从暗到明
        /// </summary>
        public string polarity = "negative";
        /// <summary>
        /// 卡尺数量
        /// </summary>
        public int cliperNum = 20;
        /// <summary>
        /// 卡尺高
        /// </summary>
        public int length = 80;
        /// <summary>
        /// 卡尺宽
        /// </summary>
        public int weidth = 5;
        /// <summary>
        /// 边阈值
        /// </summary>
        public int threshold = 30;
        /// <summary>
        /// 边Sigma
        /// </summary>
        public double sigma = 1.0;
        /// <summary>
        /// 选择所查找到的边
        /// </summary>
        public string edgeSelect = "all";
        /// <summary>
        /// 分数阈值
        /// </summary>
        public double _minScore = 0.5;
        /// <summary>
        /// 矩形框显示
        /// </summary>
        public bool dispRec = true;
        /// <summary>
        /// 交点显示
        /// </summary>
        public bool dispCross = true;
        public double minScore
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
        public Line resultLine = null;
        /// <summary>
        /// 显示的线
        /// </summary>
        public HObject LineDisp = null;
        /// <summary>
        /// 新的跟随姿态变化后的预期线信息
        /// </summary>
        HTuple newExpectCenterRow = new HTuple(200), newExpectCenterCol = new HTuple(200), newExpectAngle = new HTuple(0);
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
        public override void DispImage()
        {
            if(inputImage != null)
            {
                FormFindLine.Instance.myHwindow.DispImage(new HImage(inputImage));
            }
        }

        public void UpdateImage()
        {
            FormFindLine.Instance.myHwindow.DispHWindow.ClearWindow();
            DispImage();
        }
        // 更新模板线的位置，并生成变换矩阵
        public void UpdateModelLineLocation()
        {
            // 计算新的位置线和转换之后位置线之间的差异，再将差异补偿到模板位置线中
            if(newExpectLineStartRow.Type !=  HTupleType.EMPTY)
            {
                HOperatorSet.VectorToSimilarity(new HTuple(newExpectLineStartRow, newExpectLineEndRow), new HTuple(newExpectLineStartCol, newExpectLineEndCol),
                new HTuple(expectLineStartRow, expectLineEndRow), new HTuple(expectLineStartCol, expectLineEndCol), out changePoseHomMat2D);
                // 更新位置
                HOperatorSet.AffineTransPixel(changePoseHomMat2D, modelStartRow, modelStartCol, out modelStartRow, out modelStartCol);
                HOperatorSet.AffineTransPixel(changePoseHomMat2D, modelEndRow, modelEndCol, out modelEndRow, out modelEndCol);
            }
            
        }

        public override void Run(SoftwareRunState softwareRunState)
        {
            Stopwatch sw = new Stopwatch();
            sw.Restart();
            HTuple homMat2DArrow = null;
            HObject arrow = null, arrowTrans = null;
            HObject drawLine = null, imageReducedLine;
            
            if (inputImage == null)
            {
                FormFindLine.Instance.SetToolStatus("工具输入图像为空", ToolRunStatu.Not_Input_Image);
                return;
            }
            try
            {
                if(softwareRunState == SoftwareRunState.Debug)
                {
                    UpdateImage();
                }
                if (inputPoseHomMat2D.Type != HTupleType.EMPTY)
                {
                    //对预期线的起始点做放射变换
                    HOperatorSet.AffineTransPixel(inputPoseHomMat2D, modelStartRow, modelStartCol, out newExpectLineStartRow, out newExpectLineStartCol);
                    HOperatorSet.AffineTransPixel(inputPoseHomMat2D, modelEndRow, modelEndCol, out newExpectLineEndRow, out newExpectLineEndCol);
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
                HOperatorSet.GetMetrologyObjectMeasures(out contoursDisp, handleID, new HTuple("all"), new HTuple("all"), out pointRow, out pointCol);


                //显示指示找线方向的箭头

                #region 测试箭头
                HTuple arrowRow = null, arrowColumn = null;
                HOperatorSet.GenRegionLine(out drawLine, newExpectLineStartRow, newExpectLineStartCol, newExpectLineEndRow, newExpectLineEndCol);
                HOperatorSet.ReduceDomain(inputImage, drawLine, out imageReducedLine);
                HOperatorSet.GetRegionPoints(imageReducedLine, out arrowRow, out arrowColumn);
                if (arrowRow.Length < 200)
                {
                    CommonMethods.CommonMethods.gen_arrow_contour_xld(out arrow, arrowRow[0], arrowColumn[0], arrowRow[arrowRow.Length - 1], arrowColumn[arrowRow.Length - 1], 20, 20);
                }
                else
                {
                    CommonMethods.CommonMethods.gen_arrow_contour_xld(out arrow, arrowRow[0], arrowColumn[0], arrowRow[200], arrowColumn[200], 20, 20);
                }
                HOperatorSet.VectorAngleToRigid(newExpectLineStartRow, newExpectLineStartCol, 0, (newExpectLineStartRow + newExpectLineEndRow) / 2, (newExpectLineStartCol + newExpectLineEndCol) / 2, new HTuple(-90).TupleRad(), out homMat2DArrow);
                HOperatorSet.AffineTransContourXld(arrow, out arrowDisp, homMat2DArrow);
                #endregion

                //把点显示出来
                HOperatorSet.GenCrossContourXld(out crossDisp, pointRow, pointCol, new HTuple(12), new HTuple(0));

                //得到所找到的线
                HTuple parameter;
                HOperatorSet.GetMetrologyObjectResult(handleID, new HTuple("all"), new HTuple("all"), new HTuple("result_type"), new HTuple("all_param"), out parameter);
                HOperatorSet.GetMetrologyObjectResultContour(out LineDisp, handleID, new HTuple("all"), new HTuple("all"), new HTuple(1.5));

                if (parameter.Length >= 4)
                {
                    ResultLineStartRow = parameter[0];
                    ResultLineStartCol = parameter[1];
                    ResultLineEndRow = parameter[2];
                    ResultLineEndCol = parameter[3];
                    Point start = new Point() { Row = ResultLineStartRow, Col = ResultLineStartCol };
                    Point end = new Point() { Row = ResultLineEndRow, Col = ResultLineEndCol };
                    resultLine = new Line() { StartPoint = start, EndPoint = end };
                    HOperatorSet.AngleLx(ResultLineStartRow, ResultLineStartCol, ResultLineEndRow, ResultLineEndCol, out _angle);
                    if (softwareRunState == SoftwareRunState.Debug)
                    {
                        DispMainWindow(FormFindLine.Instance.myHwindow);
                        FormFindLine.Instance.tbx_resultStartRow.Text = ResultLineStartRow.ToString();
                        FormFindLine.Instance.tbx_resultStartCol.Text = ResultLineEndCol.ToString();
                        FormFindLine.Instance.tbx_resultEndRow.Text = ResultLineEndRow.ToString();
                        FormFindLine.Instance.tbx_resultEndCol.Text = ResultLineEndCol.ToString();
                    }
                    runMessage = "工具运行成功,已找到线！";
                    toolRunStatu = ToolRunStatu.Succeed;
                }
                else
                {
                    runMessage = "工具运行失败,未找到线";
                    toolRunStatu = ToolRunStatu.Tool_Run_Error;
                }
                
                // 参数传递
                ParamsTrans();
                sw.Stop();
                runTime = $"运行时间： {sw.ElapsedMilliseconds} ms";
                FormFindLine.Instance.SetToolStatus(runMessage, toolRunStatu);
                HOperatorSet.ClearMetrologyModel(handleID);
            }
            catch (Exception ex)
            {
                FormFindLine.Instance.SetToolStatus($"工具运行异常，异常原因： {ex}", ToolRunStatu.Tool_Run_Error);
            }
            finally
            {
                
                //homMat2DArrow.Dispose();
                //arrow.Dispose();
                //arrowTrans.Dispose();
            }
        }
        /// <summary>
        /// 将数据传递给FindlineToolInterface
        /// </summary>
        private void ParamsTrans()
        {
            FormFindLine.Instance.myToolInfo.toolOutput.Clear();
            FormFindLine.Instance.myToolInfo.toolOutput.Add(new ToolIO("outputXld", resultLine, DataType.Line));
            FormFindLine.Instance.myToolInfo.toolOutput.Add(new ToolIO("StartPoint.Row", ResultLineStartRow, DataType.IntValue));
            FormFindLine.Instance.myToolInfo.toolOutput.Add(new ToolIO("StartPoint.Column", ResultLineStartCol, DataType.IntValue));
            FormFindLine.Instance.myToolInfo.toolOutput.Add(new ToolIO("EndPoint.Row", ResultLineEndRow, DataType.IntValue));
            FormFindLine.Instance.myToolInfo.toolOutput.Add(new ToolIO("EndPoint.Column", ResultLineEndCol, DataType.IntValue));
        }

        public override void DispMainWindow(HWindowTool_Smart window)
        {
            // 显示矩形
            if (dispRec)
            {
                window.DispHWindow.SetColor("blue");
                window.DispHWindow.DispObj(contoursDisp);
            }
            // 显示交点
            if (dispCross)
            {
                window.DispHWindow.SetColor("orange");
                window.DispHWindow.DispObj(crossDisp);
            }
            //显示找到的线
            window.DispHWindow.SetColor("green");
            window.DispHWindow.DispObj(LineDisp);
        }
        
    }
}
