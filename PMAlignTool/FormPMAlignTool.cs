using ChoiceTech.Halcon.Control;
using CommonMethods;
using HalconDotNet;
using Logger;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewROI;

namespace PMAlignTool
{
    public partial class FormPMAlignTool : Form
    {
        private PMAlign myPMAlign = new PMAlign();
        public IToolInfo myToolInfo = new IToolInfo();
        public HWindowTool_Smart myHwindow = new HWindowTool_Smart();
        private HDrawingObject selected_drawing_object = new HDrawingObject();
        public List<HDrawingObject> templateModelListAdd = new List<HDrawingObject>() { };
        public List<HDrawingObject> templateModelListSub = new List<HDrawingObject>() { };

        public FormPMAlignTool(ref object pmalign)
        {
            InitializeComponent();
            _instance = this;
            if (pmalign.GetType().FullName != "System.Object")
            {
                myToolInfo = (IToolInfo)pmalign;
                myPMAlign = (PMAlign)myToolInfo.tool;
                myPMAlign.toolName = myToolInfo.FormToolName;
                myPMAlign.DispImage();
            }
        }

        /// <summary>
        /// 窗体对象实例
        /// </summary>
        private static FormPMAlignTool _instance;
        public static FormPMAlignTool Instance
        {
            get
            {
                if (_instance != null)
                {
                    lock (_instance)
                    {
                        if (_instance == null)
                        {
                            object pmalign = new object();
                            _instance = new FormPMAlignTool(ref pmalign);
                        }
                        return _instance;
                    }
                }
                else
                {
                    object pmalign = new object();
                    _instance = new FormPMAlignTool(ref pmalign);
                    return _instance;
                }

            }
        }

        private void FormPMAlignTool_Load(object sender, EventArgs e)
        {
            this.panel1.Controls.Add(myHwindow);
            myHwindow.Dock = DockStyle.Fill;
            InitTool();
        }
        bool isInitTool = false;
        private void InitTool()
        {
            isInitTool = true;
            #region 图像预处理
            cNumErosionValue1.Value = myPMAlign.imageProcess.erosionValue1.algValue;
            cbCErosion1.Checked = myPMAlign.imageProcess.erosionValue1.isEnable;
            cmbErsion1.TextStr = myPMAlign.imageProcess.erosionValue1.algName;

            cNumDilationValue2.Value = myPMAlign.imageProcess.dilationValue.algValue;
            cbCDilation1.Checked = myPMAlign.imageProcess.dilationValue.isEnable;
            cmbDilation.TextStr = myPMAlign.imageProcess.dilationValue.algName;

            cNumErosionValue2.Value = myPMAlign.imageProcess.erosionValue2.algValue;
            cbCErosion2.Checked = myPMAlign.imageProcess.erosionValue2.isEnable;
            cmbErsion2.TextStr = myPMAlign.imageProcess.erosionValue2.algName;
            #endregion
            #region 界面参数
            nud_minScore.Value = myPMAlign.minScore;
            nud_matchNum.Value = myPMAlign.matchNum;
            nud_angleStep.Value = myPMAlign.angleStep;
            nud_Timeout.Value = myPMAlign.timeOut;
            nud_angleStart.Value = myPMAlign.startAngle;
            nud_angleRange.Value = myPMAlign.angleRange;
            nud_ScaleStart.Value = myPMAlign.minScale;
            nud_ScaleRange.Value = myPMAlign.maxScale;
            tkb_contrast.Value = myPMAlign.contrast;

            #endregion
        }

        private void btnAcqNewModelImage_Click(object sender, EventArgs e)
        {
            if (myPMAlign.inputImage != null)
            {
                myPMAlign.oldTrainImage = myPMAlign.inputImage;
            }
        }
        private ShapeMode selectType;
        private void btnOperateROI_Click(object sender, EventArgs e)
        {
            HDrawingObject temp_object = new HDrawingObject();
            temp_object.ClearDrawingObject();
            Button btnClick = sender as Button;
            selectType = (ShapeMode)Enum.Parse(typeof(ShapeMode), btnClick.Tag.ToString());
            switch (selectType)
            {
                case ShapeMode.RECTANGLE1:
                    temp_object = HDrawingObject.CreateDrawingObject(HDrawingObject.HDrawingObjectType.RECTANGLE1, new HTuple[] { 100, 100, 300, 400 });
                    break;
                case ShapeMode.RECTANGLE2:
                    temp_object = HDrawingObject.CreateDrawingObject(HDrawingObject.HDrawingObjectType.RECTANGLE2, new HTuple[] { 200, 200, 0, 100,300 });
                    break;
                case ShapeMode.CIRCLE:
                    temp_object = HDrawingObject.CreateDrawingObject(HDrawingObject.HDrawingObjectType.CIRCLE, new HTuple[] { 200, 200, 100 });
                    break;
                case ShapeMode.ELLIPSE:
                    break;
                case ShapeMode.Other:
                    break;
                default:
                    break;
            }
            GC.KeepAlive(temp_object);
            temp_object.OnSelect(OnSelectDrawingObject);
            temp_object.OnAttach(OnSelectDrawingObject);
            temp_object.OnResize(OnSelectDrawingObject);
            temp_object.OnDrag(OnSelectDrawingObject);
            myHwindow.DispHWindow.AttachDrawingObjectToWindow(temp_object);
            if(rdo_templateRegionAdd.Checked)
            {
                temp_object.SetDrawingObjectParams("color","green");
                templateModelListAdd.Add(temp_object);
            }
            else
            {
                temp_object.SetDrawingObjectParams("color", "red");
                templateModelListSub.Add(temp_object);
            }
        }
        /// <summary>
        /// 参数回调
        /// </summary>
        /// <param name="dobj"></param>
        /// <param name="hwin"></param>
        /// <param name="type"></param>
        private void OnSelectDrawingObject(HDrawingObject dobj, HWindow hwin, string type)
        {
            HObject selectObj = dobj.GetDrawingObjectIconic();
            myPMAlign.templateRegion = selectObj.Clone();
            switch (selectType)
            {
                case ShapeMode.RECTANGLE1:
                    break;
                case ShapeMode.RECTANGLE2:
                    break;
                case ShapeMode.CIRCLE:
                    break;
                case ShapeMode.ELLIPSE:
                    break;
                case ShapeMode.Other:
                    break;
                default:
                    break;
            }
            selectObj.Dispose();
        }

        public HObject contour;
        private void btnCreateModel_Click(object sender, EventArgs e)
        {
            if(myPMAlign.inputImage != null)
            {
                if(myPMAlign.CreateModelTemplate() == 0)
                {
                    if (myPMAlign.matchMode == MatchMode.BasedShape)
                    {
                        HOperatorSet.GetShapeModelContours(out contour, myPMAlign.modelID, (HTuple)1);
                        HTuple area, row, col;
                        HOperatorSet.AreaCenter(myPMAlign.templateRegion, out area, out row, out col);
                        HTuple homMat2D;
                        HOperatorSet.HomMat2dIdentity(out homMat2D);
                        HOperatorSet.HomMat2dTranslate(homMat2D, row, col, out homMat2D);
                        HOperatorSet.AffineTransContourXld(contour, out contour, homMat2D);
                    }
                    myHwindow.DispHWindow.ClearWindow();
                    hWindowTool_Smart1.DispHWindow.ClearWindow();
                    myHwindow.DispImage(myPMAlign.inputImage);
                    //在模板窗口显示模板
                    HTuple row1, col1, row2, col2;
                    HOperatorSet.SmallestRectangle1(myPMAlign.templateRegion, out row1, out col1, out row2, out col2);
                    HObject outRectangle1;
                    HOperatorSet.GenRectangle1(out outRectangle1, row1 - 20, col1 - 20, row2 + 20, col2 + 20);
                    HObject imageReduced, imagePart;
                    HOperatorSet.ReduceDomain(myPMAlign.inputImage, outRectangle1, out imageReduced);
                    HObject outBoundary, inBoundary;
                    HOperatorSet.Boundary(myPMAlign.templateRegion, out outBoundary, "inner_filled");
                    HOperatorSet.Boundary(myPMAlign.templateRegion, out inBoundary, "outer");
                    HOperatorSet.CropDomain(imageReduced, out imagePart);
                    HOperatorSet.SetSystem("flush_graphic", "true");
                    hWindowTool_Smart1.DispImage(imagePart);
                    hWindowTool_Smart1.DispHWindow.SetColor("green");
                    hWindowTool_Smart1.DispHWindow.SetDraw("margin");
                    hWindowTool_Smart1.DispHWindow.DispObj(outBoundary);
                    hWindowTool_Smart1.DispHWindow.DispObj(inBoundary);
                    if (myPMAlign.matchMode == MatchMode.BasedShape)
                    {
                        HOperatorSet.SetLineStyle(myHwindow.DispHWindow, new HTuple());
                        HOperatorSet.SetColor(myHwindow.DispHWindow, new HTuple("orange"));
                        HOperatorSet.DispObj(contour, myHwindow.DispHWindow);
                    }
                }
                else
                {
                    LoggerClass.WriteLog("创建模板失败！", MsgLevel.Exception);
                }
            }
            else
            {
                myPMAlign.isCreateModel = false;
            }
        }

        /// <summary>
        /// 设定工具运行状态
        /// </summary>
        /// <param name="msg">运行中的信息</param>
        /// <param name="status">运行状态</param>
        public void SetToolStatus(string msg, ToolRunStatu status, Exception ex = null)
        {
            if (myPMAlign != null)
            {
                myPMAlign.runMessage = msg;
                myPMAlign.toolRunStatu = status;
                lb_RunStatus.Text = myPMAlign.toolRunStatu == ToolRunStatu.Succeed ? "工具运行成功！" : $"工具运行异常, 异常原因：{myPMAlign.runMessage}";
                lb_RunTime.Text = myPMAlign.runTime;
                if (myPMAlign.toolRunStatu == ToolRunStatu.Succeed)
                {
                    statusStrip.BackColor = Color.LimeGreen;
                }
                else
                {
                    statusStrip.BackColor = Color.Red;
                }
            }
        }

        private void PreProcess_CheckChanged(object sender, EventArgs e)
        {
            if(!isInitTool)
            {
                myPMAlign.imageProcess.erosionValue1.isEnable = cbCErosion1.Checked;
                myPMAlign.imageProcess.dilationValue.isEnable = cbCDilation1.Checked;
                myPMAlign.imageProcess.erosionValue2.isEnable = cbCErosion2.Checked;
            }
            
        }

        private void PreValueChanged(double value)
        {
            if (!isInitTool)
            {
                myPMAlign.imageProcess.erosionValue1.algValue = cNumErosionValue1.Value;
                myPMAlign.imageProcess.dilationValue.algValue = cNumDilationValue2.Value;
                myPMAlign.imageProcess.erosionValue2.algValue = cNumErosionValue2.Value;
            }  
        }

        private void rabShape_CheckedChanged(object sender, EventArgs e)
        {
            myPMAlign.matchMode = rabShape.Checked ? MatchMode.BasedShape : MatchMode.BasedGray;
        }

        private void cmbErsion1_SelectedIndexChanged()
        {
            if (!isInitTool)
            {
                myPMAlign.imageProcess.erosionValue1.algName = cmbErsion1.TextStr;
                myPMAlign.imageProcess.dilationValue.algName = cmbDilation.TextStr;
                myPMAlign.imageProcess.erosionValue2.algName = cmbErsion2.TextStr;
            }
        }

        private void tsbtRunTool_Click(object sender, EventArgs e)
        {
            myPMAlign.Run(SoftwareRunState.Debug);
        }

        private void tkb_contrast_Scroll(object sender, EventArgs e)
        {
            lbl_contastValue.Text = tkb_contrast.Value.ToString();
        }
    }
}
