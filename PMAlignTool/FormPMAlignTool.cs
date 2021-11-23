using ChoiceTech.Halcon.Control;
using CommonMethods;
using HalconDotNet;
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
        private PMAlign myPMAlign = null;
        private IToolInfo myToolInfo = null;
        public HWindowTool_Smart myHwindow = new HWindowTool_Smart();
        private HDrawingObject selected_drawing_object = new HDrawingObject();
        private List<HDrawingObject> templateModelListAdd = new List<HDrawingObject>() { };
        private List<HDrawingObject> templateModelListSub = new List<HDrawingObject>() { };
        public FormPMAlignTool(ref object pmalign)
        {
            InitializeComponent();
            _instance = this;
            if (pmalign.GetType().FullName != "System.Object")
            {
                myToolInfo = (IToolInfo)pmalign;
                myPMAlign = (PMAlign)myToolInfo.tool;
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

        private void InitTool()
        {
            cNumErosionValue1.Value = myPMAlign.imageProcess.erosionValue1.algValue;
            cbCErosion1.Checked = myPMAlign.imageProcess.erosionValue1.isEnable;
            cNumDilationValue2.Value = myPMAlign.imageProcess.dilationValue.algValue;
            cbCDilation1.Checked = myPMAlign.imageProcess.dilationValue.isEnable;
            cNumErosionValue2.Value = myPMAlign.imageProcess.erosionValue2.algValue;
            cbCErosion2.Checked = myPMAlign.imageProcess.erosionValue2.isEnable;
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
                templateModelListAdd.Add(temp_object);
            }
            else
            {
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

        private void btnCreateModel_Click(object sender, EventArgs e)
        {
            if(myPMAlign.modelID == -1)
            {
                myPMAlign.oldTrainImage = myPMAlign.inputImage;

            }
        }

        private void PreProcess_CheckChanged(object sender, EventArgs e)
        {
            myPMAlign.imageProcess.erosionValue1.isEnable = cbCErosion1.Checked;
            myPMAlign.imageProcess.dilationValue.isEnable = cbCDilation1.Checked;
            myPMAlign.imageProcess.erosionValue2.isEnable = cbCErosion2.Checked;
        }

        private void PreValueChanged(double value)
        {
            myPMAlign.imageProcess.erosionValue1.algValue = cNumErosionValue1.Value;
            myPMAlign.imageProcess.dilationValue.algValue = cNumDilationValue2.Value;
            myPMAlign.imageProcess.erosionValue2.algValue = cNumErosionValue2.Value;
        }
    }
}
