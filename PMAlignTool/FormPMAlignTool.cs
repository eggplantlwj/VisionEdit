using ChoiceTech.Halcon.Control;
using CommonMethods;
using HalconDotNet;
using Logger;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        private HDrawingObject serachRegion_drawing_object = new HDrawingObject();
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
                myPMAlign.toolName = myToolInfo.toolName;
                myPMAlign.bingdingJobName = myToolInfo.bingingJobName;
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
            if(myPMAlign.modelPartImage != null)
            {
                hWindowTool_Smart1.DispImage(myPMAlign.modelPartImage);
            }
            // myHwindow.DispHWindow.AttachDrawingObjectToWindow(serachRegion_drawing_object);
            tsbtRunTool_Click(null, null);
             isInitTool = false;
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

        private void OnSerchRegionDrawingObject(HDrawingObject dobj, HWindow hwin, string type)
        {
            HObject selectObj = dobj.GetDrawingObjectIconic();
            myPMAlign.SearchRegion = selectObj.Clone();
        }

        public HObject contour;
        private void btnCreateModel_Click(object sender, EventArgs e)
        {
            if(myPMAlign.inputImage != null)
            {
                if(myPMAlign.CreateModelTemplate(false, null) == 0)
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
                    HOperatorSet.GenRectangle1(out outRectangle1, row1, col1, row2, col2);
                    HObject imageReduced;
                    HOperatorSet.ReduceDomain(myPMAlign.inputImage, outRectangle1, out imageReduced);
                    HOperatorSet.SetSystem("flush_graphic", "true");
                    hWindowTool_Smart1.DispImage(myPMAlign.modelPartImage);
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

        private void UIParams_ValueChanged(double value)
        {
            if (!isInitTool)
            {
                myPMAlign.minScore = nud_minScore.Value;
                myPMAlign.startAngle = Convert.ToInt16(nud_angleStart.Value);
                myPMAlign.angleRange = Convert.ToInt16(nud_angleRange.Value);
                myPMAlign.angleStep = Convert.ToInt16(nud_angleStep.Value);
                myPMAlign.polarity = cbx_polarity.TextStr;
                myPMAlign.isAutoConstants = ckb_autoContrast.Checked;
                myPMAlign.minScale = nud_ScaleStart.Value;
                myPMAlign.maxScale = nud_ScaleRange.Value;
            }
        }

        private void btnChangeModel_Click(object sender, EventArgs e)
        {
            if(!File.Exists(myPMAlign.pmaModelName + ".ShapeModel"))
            {
                MessageBox.Show("还未创建过模板，请先进行创建！");
                return;
            }
            myPMAlign.inputImage = myPMAlign.oldTrainImage;
            myPMAlign.Run(SoftwareRunState.Debug);

        }

        private void cbx_searchRegionType_SelectedIndexChanged()
        {
            serachRegion_drawing_object.ClearDrawingObject();
            string selectRegion = cbx_searchRegionType.TextStr;
            switch (selectRegion)
            {
                case "整幅图像":
                    myPMAlign.searchRegionType = RegionType.AllImage;
                    return;
                case "矩形":
                    myPMAlign.searchRegionType = RegionType.Rectangle1;
                    serachRegion_drawing_object = HDrawingObject.CreateDrawingObject(HDrawingObject.HDrawingObjectType.RECTANGLE1, new HTuple[] { 100, 100, 300, 400 });
                    break;
                case "圆":
                    myPMAlign.searchRegionType = RegionType.Circle;
                    serachRegion_drawing_object = HDrawingObject.CreateDrawingObject(HDrawingObject.HDrawingObjectType.CIRCLE, new HTuple[] { 200, 200, 100 });
                    break;
                case "多点":
                    myPMAlign.searchRegionType = RegionType.MultPoint;
                    break;
                default:
                    break;
            }
            GC.KeepAlive(serachRegion_drawing_object);
            serachRegion_drawing_object.OnSelect(OnSerchRegionDrawingObject);
            serachRegion_drawing_object.OnAttach(OnSerchRegionDrawingObject);
            serachRegion_drawing_object.OnResize(OnSerchRegionDrawingObject);
            serachRegion_drawing_object.OnDrag(OnSerchRegionDrawingObject);
            serachRegion_drawing_object.SetDrawingObjectParams("color", "yellow");
            myHwindow.DispHWindow.AttachDrawingObjectToWindow(serachRegion_drawing_object);
            
        }

    }
}
