using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommonMethods;
using ChoiceTech.Halcon.Control;
using HalconDotNet;
using ViewROI;

namespace CaliperTool
{
    public partial class FormCaliper : Form
    {

        public Caliper myCaliper = null;
        public IToolInfo myToolInfo = null;
        public HWindowTool_Smart myHwindow = new HWindowTool_Smart();

        private static FormCaliper _instance;
        public FormCaliper(ref object caliper)
        {
            InitializeComponent();
            _instance = this;
            if (caliper.GetType().FullName != "System.Object")
            {
                myToolInfo = (IToolInfo)caliper;
                myCaliper = (Caliper)myToolInfo.tool;
                myCaliper.DispImage();
            }
        }
        public static FormCaliper Instance
        {
            get
            {
                if (_instance != null)
                {
                    lock (_instance)
                    {
                        if (_instance == null)
                        {
                            object calib = new object();
                            _instance = new FormCaliper(ref calib);
                        }
                        return _instance;
                    }
                }
                else
                {
                    object line = new object();
                    _instance = new FormCaliper(ref line);
                    return _instance;
                }

            }
        }

        private void FormCaliper_Load(object sender, EventArgs e)
        {
            this.panel1.Controls.Add(myHwindow);
            myHwindow.Dock = DockStyle.Fill;
            InitTool();
        }

        private void InitTool()
        {
            this.Text = myToolInfo.toolName;
            btn_runCaliperool.Focus();
            Application.DoEvents();
            // 预期设定值
            tbx_expectCenterRow.Text = myCaliper.expectRecStartRow.ToString();
            tbx_expectCenterCol.Text = myCaliper.expectRecStartColumn.ToString();
            tbx_expectPhi.Text = myCaliper.expectAngle.ToString();
            // 预期参数
            tbx_caliperLength1.Text = myCaliper.length1.ToString();
            tbx_caliperLength2.Text = myCaliper.length2.ToString();
            cbx_edgeSelect.Text = myCaliper.edgeSelect;
            cbx_polarity.Text = myCaliper.polarity == "positive" ? "从暗到明" : "从明到暗";
            tbx_threshold.Text = myCaliper.threshold.ToString();
            tbx_Sigma.Text = myCaliper.sigma.ToString();
            // 显示
            chBDispRec.Checked = myCaliper.dispRec;
            chBDispCross.Checked = myCaliper.dispCross;
            chBDispCaliperROI.Checked = myCaliper.LineDisp;
        }

        private void btn_moveCliperRegion_Click(object sender, EventArgs e)
        {
            myCaliper.UpdateImage();
            myCaliper.DrawExpectLine(myHwindow.DispHWindow);
        }

        private void btn_runCaliperool_Click(object sender, EventArgs e)
        {
            // 更改界面中参数，实时更新类中参数
            myCaliper.expectRecStartRow = Convert.ToDouble(tbx_expectCenterRow.Text.Trim());
            myCaliper.expectRecStartColumn = Convert.ToDouble(tbx_expectCenterCol.Text.Trim());
            myCaliper.expectAngle = Convert.ToDouble(tbx_expectPhi.Text.Trim());
            // 运行参数
            myCaliper.threshold = Convert.ToInt16(tbx_threshold.Text.Trim());
            myCaliper.length1 = Convert.ToDouble(tbx_caliperLength1.Text.Trim());
            myCaliper.length2 = Convert.ToDouble(tbx_caliperLength2.Text.Trim());
            myCaliper.polarity = cbx_polarity.SelectedItem.ToString() == "从明到暗" ? "negative" : "positive";
            myCaliper.edgeSelect = cbx_edgeSelect.SelectedItem.ToString();
            myCaliper.sigma = Convert.ToDouble(tbx_Sigma.Text.Trim());
            myCaliper.Run(SoftwareRunState.Debug);
        }

        /// <summary>
        /// 设定工具运行状态
        /// </summary>
        /// <param name="msg">运行中的信息</param>
        /// <param name="status">运行状态</param>
        public void SetToolStatus(string msg, ToolRunStatu status)
        {
            if (myCaliper != null)
            {
                myCaliper.runMessage = msg;
                myCaliper.toolRunStatu = status;
                lb_RunStatus.Text = myCaliper.toolRunStatu == ToolRunStatu.Succeed ? "工具运行成功！" : $"工具运行异常, 异常原因：{myCaliper.runMessage}";
                lb_RunTime.Text = myCaliper.runTime;
                if (myCaliper.toolRunStatu == ToolRunStatu.Succeed)
                {
                    statusStrip.BackColor = Color.LimeGreen;
                }
                else
                {
                    statusStrip.BackColor = Color.Red;
                }
            }
        }
    }
}
