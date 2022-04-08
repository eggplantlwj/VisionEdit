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
using System.Windows.Forms;
using Logger;
using System.Diagnostics;
using System.IO;

namespace PMAlignTool
{
    [Serializable]
    public class PMAlign : IToolBase
    {
        public string toolName { get; set; } = string.Empty;
        /// <summary>
        /// 输入姿态
        /// </summary>
        public PosXYU inputPose = new PosXYU();
        /// <summary>
        /// 制作模板时的输入位姿
        /// </summary>
        public PosXYU templatePose = new PosXYU();
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
        internal HTuple modelID = -1;
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
        internal HObject templateRegion;
        /// <summary>
        /// 在进行模板创建及匹配时进行的图像预处理
        /// </summary>
        public ImagePreProcess imageProcess { get; set; } = new ImagePreProcess();
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
        internal int angleRange { get; set; } = 360;
        /// <summary>
        /// 角度步长
        /// </summary>
        internal int angleStep { get; set; } = 1;
        /// <summary>
        /// 对比度
        /// </summary>
        internal int contrast { get; set; } = 30;
        /// <summary>
        /// 超时处理
        /// </summary>
        internal int timeOut { get; set; } = 500;
        /// <summary>
        /// 训练时所使用的模板图像，不点击获取图像时，不进行更新
        /// </summary>
        public HObject oldTrainImage { get; set; }
        public bool isCreateModel { get; set; }
        internal string pmaModelName { get; set; } = Guid.NewGuid().ToString();
        /// <summary>
        /// 模板位置和实际位置的姿态差异
        /// </summary>
        internal HTuple posHomMat2D = new HTuple();

        public override void DispMainWindow(HWindow dispHWindow)
        {
            if (showFeature)
            {
                ShowTemplate(dispHWindow, false);
            }
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
        public List<MatchResult> L_resultList { get; set; } = new List<MatchResult>() { };
        /// <summary>
        /// 匹配模式
        /// </summary>
        public MatchMode matchMode { get; set; } = MatchMode.BasedShape;
        /// <summary>
        /// 缩放最小值
        /// </summary>
        public HTuple minScale { get; internal set; } = 0.9;
        /// <summary>
        /// 缩放最大值
        /// </summary>
        public HTuple maxScale { get; internal set; } = 1.1;
        public bool isAutoConstants { get; set; }
        public string modelFilePath { get; set; }
        public RegionType searchRegionType { get; set; }
        public HObject SearchRegion { get; private set; }

        public override void Run(SoftwareRunState softwareState)
        {
            Stopwatch sw = new Stopwatch();
            sw.Restart();
            softwareRunState = softwareState;
            if (inputImage == null)
            {
                FormPMAlignTool.Instance.SetToolStatus("工具输入图像为空", ToolRunStatu.Not_Input_Image);
                return;
            }
            try
            {
                if (softwareRunState == SoftwareRunState.Debug)
                {
                    DispImage();
                }
                if (inputPose != null)
                {
                    HTuple Row = inputPose.X - templatePose.X;
                    HTuple Col = inputPose.Y - templatePose.Y;
                    HTuple angle = inputPose.U - templatePose.U;

                    HTuple _homMat2D;
                    HOperatorSet.HomMat2dIdentity(out _homMat2D);
                    HOperatorSet.HomMat2dRotate(_homMat2D, (HTuple)(angle), (HTuple)templatePose.X, (HTuple)templatePose.Y, out _homMat2D);
                    HOperatorSet.HomMat2dTranslate(_homMat2D, (HTuple)(Row), (HTuple)(Col), out _homMat2D);
                    //对预期线的找模板区域做放射变换

                }
              //  UpdateParamsFromUI(); // 操作前先将UI中参数写入类
                 HObject findModelImg = ProcessImage(inputImage);
                int ret = FindModelTemplate(findModelImg);
                ToolRunStatu myState = ret == 0 ? ToolRunStatu.Succeed : ToolRunStatu.Model_UnFound;
                string retMsg = ret == 0 ? "工具运行成功,已找到匹配项！" : "未找到匹配项";
                sw.Stop();
                runTime = $"运行时间： {sw.ElapsedMilliseconds} ms";
                FormPMAlignTool.Instance.SetToolStatus(retMsg, myState);
            }
            catch (Exception ex)
            {
                FormPMAlignTool.Instance.SetToolStatus($"工具运行异常，异常原因： {ex}", ToolRunStatu.Tool_Run_Error);
            }
            finally
            {
                
            }
        }
        public void UpdateParamsFromUI()
        {
            minScore = FormPMAlignTool.Instance.nud_minScore.Value;
            startAngle = Convert.ToInt16(FormPMAlignTool.Instance.nud_angleStart.Value);
            angleRange = Convert.ToInt16(FormPMAlignTool.Instance.nud_angleRange.Value);
            angleStep = Convert.ToInt16(FormPMAlignTool.Instance.nud_angleStep.Value);
            polarity = FormPMAlignTool.Instance.cbx_polarity.TextStr;
            isAutoConstants = FormPMAlignTool.Instance.ckb_autoContrast.Checked;
            minScale = FormPMAlignTool.Instance.nud_ScaleStart.Value;
            maxScale = FormPMAlignTool.Instance.nud_ScaleRange.Value;
            timeOut = Convert.ToInt16(FormPMAlignTool.Instance.nud_Timeout.Value);
            contrast = Convert.ToInt16(FormPMAlignTool.Instance.tkb_contrast.Value);
        }
        public override void DispImage()
        {
            FormPMAlignTool.Instance.myHwindow.DispHWindow.ClearWindow();
            if (inputImage != null)
            {
                FormPMAlignTool.Instance.myHwindow.DispHWindow.DispObj(inputImage);
            }
        }
        private void CreateModelRegion()
        {
            HOperatorSet.GenEmptyObj(out templateRegion);
            foreach (var item in FormPMAlignTool.Instance.templateModelListAdd)
            {
                HObject selectObj = item.GetDrawingObjectIconic();
                HOperatorSet.Union2(selectObj, templateRegion, out templateRegion);
            }
            foreach (var item in FormPMAlignTool.Instance.templateModelListSub)
            {
                HObject selectObj = item.GetDrawingObjectIconic();
                HOperatorSet.Difference(templateRegion, selectObj, out templateRegion);
            }
        }

        public void SetParamsFromUI()
        {
            minScore = FormPMAlignTool.Instance.nud_minScore.Value;
            startAngle = Convert.ToInt16(FormPMAlignTool.Instance.nud_angleStart.Value);
            angleRange = Convert.ToInt16(FormPMAlignTool.Instance.nud_angleRange.Value);
            angleStep = Convert.ToInt16(FormPMAlignTool.Instance.nud_angleStep.Value);
            polarity = FormPMAlignTool.Instance.cbx_polarity.TextStr;
            isAutoConstants = FormPMAlignTool.Instance.ckb_autoContrast.Checked;
            minScale = FormPMAlignTool.Instance.nud_ScaleStart.Value;
            maxScale = FormPMAlignTool.Instance.nud_ScaleRange.Value;
        }

        public int CreateModelTemplate()
        {
            HObject template;
            oldTrainImage = inputImage;
            if (FormPMAlignTool.Instance.templateModelListAdd.Count == 0)
            {
                LoggerClass.WriteLog("未划定模板建立区域", MsgLevel.Exception);
                isCreateModel = false;
                return -1;
            }
            CreateModelRegion();
            HObject createModelImg;
            HOperatorSet.GenEmptyObj(out createModelImg);
            createModelImg = ProcessImage(inputImage);
            HOperatorSet.ReduceDomain(createModelImg, templateRegion, out template);
            //SetParamsFromUI();
            try
            {
                HTuple rows, cols, angles, scores, scale;
                if (matchMode == MatchMode.BasedShape)
                {
                    HOperatorSet.CreateShapeModel(template,
                                                 "auto",
                                                0,
                                                 360,
                                                 "auto",
                                                 "auto",
                                                 polarity,
                                                  isAutoConstants ? (HTuple)"auto" : (HTuple)contrast,
                                                 "auto",
                                                  out modelID);
                    HOperatorSet.FindShapeModel(createModelImg,
                                               (HTuple)modelID,
                                               ((HTuple)startAngle).TupleRad(),
                                               ((HTuple)angleRange - startAngle).TupleRad(),
                                               (HTuple)minScore,
                                               (HTuple)matchNum,
                                               (HTuple)0.5,
                                               (HTuple)"least_squares",
                                               (HTuple)0,
                                               (HTuple)0.9,
                                                out rows,
                                                out cols,
                                                out angles,
                                                out scores);
                }
                else
                {
                    HOperatorSet.CreateNccModel(template,
                                                 "auto",
                                                ((HTuple)startAngle).TupleRad(),
                                                 ((HTuple)angleRange).TupleRad(),
                                                 "auto",
                                                 "use_polarity",
                                                  out modelID);
                    HOperatorSet.FindNccModel(createModelImg,
                                                (HTuple)modelID,
                                                ((HTuple)startAngle).TupleRad(),
                                                ((HTuple)angleRange - startAngle).TupleRad(),
                                                (HTuple)minScore,
                                                (HTuple)matchNum,
                                                (HTuple)0.5,
                                                (HTuple)"true",
                                                (HTuple)0,
                                                 out rows,
                                                 out cols,
                                                 out angles,
                                                 out scores);
                }
                isCreateModel = true;
                HOperatorSet.WriteRegion(templateRegion, FormPMAlignTool.Instance.myToolInfo.FormToolName + ".hobj");
                HOperatorSet.WriteShapeModel(modelID, pmaModelName + ".ShapeModel");
                if (scores != null && scores.Type != HTupleType.EMPTY)
                {
                    templatePose = new PosXYU { X = rows[0].D, Y = cols[0].D , U = angles[0].D };
                }

            }
            catch (Exception ex)
            {
                Logger.LoggerClass.WriteLog("创建模板时出现异常", ex);
                isCreateModel = false;
                return -1;
            }
            finally
            {
                FormPMAlignTool.Instance.templateModelListAdd.Clear();
                FormPMAlignTool.Instance.templateModelListSub.Clear();
            }
            return 0;
        }

        public int FindModelTemplate(HObject findModelImage)
        {
            if (!isCreateModel)
            {
                LoggerClass.WriteLog("未创建或加载模板", MsgLevel.Exception);
                return -1;
            }
            if (!File.Exists(pmaModelName + ".ShapeModel"))
            {
                LoggerClass.WriteLog("未创建或加载模板", MsgLevel.Exception);
                return -1;
            }
            HOperatorSet.ReadShapeModel(pmaModelName + ".ShapeModel", out modelID);
            HObject image;
            if (searchRegionType == RegionType.AllImage)
            {
                image = findModelImage;
            }
            else
            {
                HOperatorSet.ReduceDomain(inputImage, SearchRegion, out reducedImage);
                image = reducedImage;
            }
            HTuple rows, cols, angles, scores;
            L_resultList.Clear();
            try
            {
                image = ProcessImage(image);
                if (matchMode == MatchMode.BasedShape)
                {
                    HTuple temp;
                    HOperatorSet.FindShapeModel(image,
                                               (HTuple)modelID,
                                               ((HTuple)startAngle).TupleRad(),
                                               ((HTuple)angleRange - startAngle).TupleRad(),
                                               (HTuple)minScore,
                                               (HTuple)matchNum,
                                               (HTuple)0.5,
                                               (HTuple)"least_squares",
                                               (HTuple)0,
                                               (HTuple)0.7,
                                                out rows,
                                                out cols,
                                                out angles,
                                                out scores);
                    /*
                    HOperatorSet.FindScaledShapeModel(image,
                                               (HTuple)modelID,
                                               ((HTuple)startAngle).TupleRad(),
                                               ((HTuple)angleRange - startAngle).TupleRad(),
                                               minScale,
                                               maxScale,
                                               (HTuple)minScore,
                                               (HTuple)matchNum,
                                               (HTuple)0.5,
                                               (HTuple)"least_squares",
                                               (HTuple)0,
                                               (HTuple)0.9,
                                                out rows,
                                                out cols,
                                                out angles,
                                                out temp,
                                                out scores);
                */
                }
                else
                {
                    HOperatorSet.FindNccModel(image,
                                                (HTuple)modelID,
                                                ((HTuple)startAngle).TupleRad(),
                                                ((HTuple)angleRange - startAngle).TupleRad(),
                                                (HTuple)minScore,
                                                (HTuple)matchNum,
                                                (HTuple)0.5,
                                                (HTuple)"true",
                                                (HTuple)0,
                                                 out rows,
                                                 out cols,
                                                 out angles,
                                                 out scores);
                }
                
                if (rows.TupleLength() > 0)
                {
                    for (int i = 0; i < rows.TupleLength(); i++)
                    {
                        MatchResult matchResult = new MatchResult();
                        matchResult.Row = Math.Round((double)rows[i], 3);
                        matchResult.Col = Math.Round((double)cols[i], 3);
                        matchResult.Angle = Math.Round((double)angles[i], 3);
                        matchResult.Socre = Math.Round((double)scores[i], 3);
                        L_resultList.Add(matchResult);
                    }
                    MatchResult temp;
                    // 将匹配结果按分值由大到小排序
                    for (int i = 0; i < L_resultList.Count - 1; i++)
                    {
                        for (int j = i + 1; j < L_resultList.Count; j++)
                        {
                            if (L_resultList[i].Socre < L_resultList[j].Socre)
                            {
                                temp = L_resultList[i];
                                L_resultList[i] = L_resultList[j];
                                L_resultList[j] = temp;
                            }
                        }
                    }
                    HOperatorSet.VectorAngleToRigid(templatePose.X, templatePose.Y, templatePose.U, L_resultList[0].Row, L_resultList[0].Col, L_resultList[0].Angle, out posHomMat2D);
                }
                if (softwareRunState == SoftwareRunState.Debug)
                {
                    FormPMAlignTool.Instance.myHwindow.DispHWindow.ClearWindow();
                    FormPMAlignTool.Instance.myHwindow.DispImage(inputImage);
                }
                if (L_resultList.Count > 0)
                {
                    toolRunStatu = ToolRunStatu.Succeed;
                    if (softwareRunState == SoftwareRunState.Debug)
                    {
                        ShowTemplate(FormPMAlignTool.Instance.myHwindow.DispHWindow);
                    }  
                    return 0;
                }
            }
            catch (Exception ex)
            {
                LoggerClass.WriteLog("寻找模板时出现异常！", ex);
                toolRunStatu = ToolRunStatu.Not_Succeed;
            }
            return -1;
        }

        public HObject contour;
        /// <summary>
        /// 显示模板
        /// </summary>
        internal void ShowTemplate(HWindow dispHWindow, bool clearImg = false)
        {
            try
            {
                if (modelID == null)
                {
                    return;
                }
                if(clearImg)
                {
                    dispHWindow.ClearWindow();
                    dispHWindow.DispObj(inputImage);
                }
                if(L_resultList.Count > 0)
                {
                    foreach (var item in L_resultList)
                    {
                        HTuple homMat2D;
                        HOperatorSet.GetShapeModelContours(out contour, modelID, new HTuple(1));
                        HOperatorSet.VectorAngleToRigid(0, 0, 0, item.Row, item.Col, item.Angle,out homMat2D);
                        HOperatorSet.AffineTransContourXld(contour, out contour, homMat2D);
                        dispHWindow.SetColor("green");
                        dispHWindow.DispObj(contour);
                    }
                }
                
            }
            catch (Exception ex)
            {
                Logger.LoggerClass.WriteLog("显示模板时出现错误", ex);
            }
        }

        private HObject ProcessImage(HObject inputImg)
        {
            if (inputImage == null) return inputImage;
            if (imageProcess.erosionValue1.isEnable)
            {
                HOperatorSet.GrayErosionShape(inputImg, out inputImg, imageProcess.erosionValue1.algValue, imageProcess.erosionValue1.algValue, imageProcess.erosionValue1.algName);
            }
            if (imageProcess.dilationValue.isEnable)
            {
                HOperatorSet.GrayDilationShape(inputImg, out inputImg, imageProcess.erosionValue1.algValue, imageProcess.erosionValue1.algValue, imageProcess.dilationValue.algName);
            }
            if (imageProcess.erosionValue2.isEnable)
            {
                HOperatorSet.GrayErosionShape(inputImg, out inputImg, imageProcess.erosionValue1.algValue, imageProcess.erosionValue1.algValue, imageProcess.erosionValue2.algName);
            }
            return inputImg;
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
        public string algName { get; set; } = "rectangle";
    }
    [Serializable]
    public enum MatchMode
    {
        BasedShape,
        BasedGray,
    }
    [Serializable]
    public enum RegionType
    {
        AllImage,
        Rectangle1,
        Rectangle2,
        Circle,
        Ellipse,
        MultPoint,
        Ring,
        Any,
    }
    /// <summary>
    /// 模板匹配结果
    /// </summary>
    [Serializable]
    public struct MatchResult
    {
        internal double Row;
        internal double Col;
        internal double Angle;
        internal double Socre;
    }
}
