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

namespace FindLineTool
{
    public partial class FormFindLine : Form
    {
        public FindLine myFindLine = null;
        public IToolInfo myToolInfo = new IToolInfo();
        public HWindowTool_Smart myHwindow = new HWindowTool_Smart();
        public HDrawingObject selected_drawing_object = new HDrawingObject();

        public FormFindLine(ref object findLine)
        {
            InitializeComponent();
            _instance = this;
            if (findLine.GetType().FullName != "System.Object")
            {
                myToolInfo = (IToolInfo)findLine;
                myFindLine = (FindLine)myToolInfo.tool;
                myFindLine.DispImage();
            }
        }
        /// <summary>
        /// 窗体对象实例
        /// </summary>
        private static FormFindLine _instance;
        public static FormFindLine Instance
        {
            get
            {
                if (_instance != null)
                {
                    lock (_instance)
                    {
                        if (_instance == null)
                        {
                            object line = new object();
                            _instance = new FormFindLine(ref line);
                        }
                        return _instance;
                    }
                }
                else
                {
                    object line = new object();
                    _instance = new FormFindLine(ref line);
                    return _instance;
                }

            }
        }

        private void FormFindLine2_Load(object sender, EventArgs e)
        {
            this.panel1.Controls.Add(myHwindow);
            myHwindow.Dock = DockStyle.Fill;
            InitTool();
        }
        bool isInit = false;
        private void InitTool()
        {
            isInit = true;
            this.Text = myToolInfo.toolName;
            Application.DoEvents();

           // myFindLine.Run();         //运行一下，使卡尺显示出来

            cbx_edgeSelect.Text = myFindLine.edgeSelect;
            tbx_minScore.Text = myFindLine.minScore.ToString();
            cbx_polarity.Text = myFindLine.polarity == "positive" ? "从暗到明" : "从明到暗";
            tbx_caliperNum.Text = myFindLine.cliperNum.ToString();
            tbx_caliperLength.Text = myFindLine.length.ToString();
            tbx_threshold.Text = myFindLine.threshold.ToString();
            tbx_Sigma.Text = myFindLine.sigma.ToString();
            tbx_caliperLength2.Text = myFindLine.weidth.ToString();
            chBDispRec.Checked = myFindLine.dispRec;
            chBDispCross.Checked = myFindLine.dispCross;
            //// 将要编辑的线显示
            selected_drawing_object = myFindLine.inputPoseHomMat2D.Length != 0? HDrawingObject.CreateDrawingObject(HDrawingObject.HDrawingObjectType.LINE, new HTuple[] { myFindLine.newExpectLineStartRow, myFindLine.newExpectLineStartCol, myFindLine.newExpectLineEndRow, myFindLine.newExpectLineEndCol })
                :HDrawingObject.CreateDrawingObject(HDrawingObject.HDrawingObjectType.LINE, new HTuple[] {myFindLine.modelStartRow, myFindLine.modelStartCol, myFindLine.modelEndRow, myFindLine.modelEndCol });
            GC.KeepAlive(selected_drawing_object);
            selected_drawing_object.OnSelect(OnSelectDrawingObject);
            selected_drawing_object.OnAttach(OnSelectDrawingObject);
            selected_drawing_object.OnResize(OnSelectDrawingObject);
            selected_drawing_object.OnDrag(OnSelectDrawingObject);
            myHwindow.DispHWindow.AttachDrawingObjectToWindow(selected_drawing_object);

            tsbtRunTool_Click(null, null);
            isInit = false;
        }
        /// <summary>
        /// 参数回调
        /// </summary>
        /// <param name="dobj"></param>
        /// <param name="hwin"></param>
        /// <param name="type"></param>
        private void OnSelectDrawingObject(HDrawingObject dobj, HWindow hwin, string type)
        {
            myFindLine.expectLineStartRow = dobj.GetDrawingObjectParams("row1");
            myFindLine.expectLineStartCol = dobj.GetDrawingObjectParams("column1");
            myFindLine.expectLineEndRow = dobj.GetDrawingObjectParams("row2");
            myFindLine.expectLineEndCol = dobj.GetDrawingObjectParams("column2");
        }
        private void tsbtRunTool_Click(object sender, EventArgs e)
        {
            // 运行参数
            myFindLine.minScore = Convert.ToDouble(tbx_minScore.Text.Trim());
            myFindLine.cliperNum = Convert.ToInt16(tbx_caliperNum.Text.Trim());
            myFindLine.threshold = Convert.ToInt16(tbx_threshold.Text.Trim());
            myFindLine.length = Convert.ToInt16(tbx_caliperLength.Text.Trim());
            myFindLine.weidth = Convert.ToInt16(tbx_caliperLength2.Text.Trim());
            myFindLine.polarity = cbx_polarity.SelectedItem.ToString() == "从明到暗" ? "negative" : "positive";
            myFindLine.edgeSelect = cbx_edgeSelect.SelectedItem.ToString();
            myFindLine.sigma = Convert.ToDouble(tbx_Sigma.Text.Trim());
            // Run
            myFindLine.Run(SoftwareRunState.Debug);
        }
        /// <summary>
        /// 设定工具运行状态
        /// </summary>`
        /// <param name="msg">运行中的信息</param>
        /// <param name="status">运行状态</param>
        public void SetToolStatus(string msg, ToolRunStatu status)
        {
            if (myFindLine != null)
            {
                myFindLine.runMessage = msg;
                myFindLine.toolRunStatu = status;
                lb_RunStatus.Text = myFindLine.toolRunStatu == ToolRunStatu.Succeed ? "工具运行成功！" : $"工具运行异常, 异常原因：{myFindLine.runMessage}";
                lb_RunTime.Text = myFindLine.runTime;
                if (myFindLine.toolRunStatu == ToolRunStatu.Succeed)
                {
                    statusStrip.BackColor = Color.LimeGreen;
                }
                else
                {
                    statusStrip.BackColor = Color.Red;
                }
            }
        }

        private void DispSetCheck(object sender, EventArgs e)
        {
            if(!isInit)
            {
                myFindLine.dispRec = chBDispRec.Checked ? true : false;
                myFindLine.dispCross = chBDispCross.Checked ? true : false;
            }
        }

        private void FormFindLine2_FormClosing(object sender, FormClosingEventArgs e)
        {
            myHwindow.Dispose();
            this.Dispose();
            this.Dispose();
            GC.Collect();
        }

        private void btnSetModelPose_Click(object sender, EventArgs e)
        {
            myFindLine.UpdateModelLineLocation();
            MessageBox.Show("模板线位置已更新");
        }
    }
}
