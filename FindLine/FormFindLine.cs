using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommonMethods;
using HalconDotNet;
using ChoiceTech.Halcon.Control;

namespace FindLineTool
{
    public partial class FormFindLine : Form
    {
        public FindLine myFindLine = null;
        public IToolInfo myToolInfo = null;
        public HWindow_Final myHwindow = new HWindow_Final();
        /// <summary>
        /// 窗体对象实例
        /// </summary>
        private static FormFindLine _instance;
        public static FormFindLine Instance
        {
            get
            {
                if(_instance != null)
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


        public FormFindLine(ref object findLine)
        {
            InitializeComponent();
            _instance = this;
            if(findLine.GetType().FullName != "System.Object")
            {
                myToolInfo = (IToolInfo)findLine;
                myFindLine = (FindLine)myToolInfo.tool;
                //myFindLine.inputImage = ComGlobalParams.inputImageGlobal; // 暂时直接将图像传递给该工具
                myFindLine.DispImage();
            }
        }

        private void FormFindLine_Load(object sender, EventArgs e)
        {
            this.panel1.Controls.Add(myHwindow);
            myHwindow.Dock = DockStyle.Fill;
            InitTool();
        }

        private void btn_moveCliperRegion_Click(object sender, EventArgs e)
        {
            myFindLine.UpdateImage();
            myFindLine.DrawExpectLine(myHwindow);
        }

        private void btn_runFindLineTool_Click(object sender, EventArgs e)
        {
            // 更改界面中参数，实时更新类中参数
            myFindLine.expectLineStartRow = Convert.ToDouble(tbx_expectLineStartRow.Text.Trim());
            myFindLine.expectLineStartCol = Convert.ToDouble(tbx_expectLineStartCol.Text.Trim());
            myFindLine.expectLineEndRow = Convert.ToDouble(tbx_expectLineEndRow.Text.Trim());
            myFindLine.expectLineEndCol = Convert.ToDouble(tbx_expectLineEndCol.Text.Trim());
            // 运行参数
            myFindLine.minScore = Convert.ToDouble(tbx_minScore.Text.Trim());
            myFindLine.cliperNum = Convert.ToInt16(tbx_caliperNum.Text.Trim());
            myFindLine.threshold = Convert.ToInt16(tbx_threshold.Text.Trim());
            myFindLine.length = Convert.ToInt16(tbx_caliperLength.Text.Trim());
            myFindLine.weidth = Convert.ToInt16(tbx_caliperLength2.Text.Trim());
            myFindLine.polarity = cbx_polarity.SelectedItem.ToString() == "从明到暗" ? "negative":"positive";
            myFindLine.edgeSelect = cbx_edgeSelect.SelectedItem.ToString();
            myFindLine.sigma = Convert.ToDouble(tbx_Sigma.Text.Trim());
            // Run
            myFindLine.Run(SoftwareRunState.Debug);
        }

        public void InitTool()
        {
            this.Text = myToolInfo.toolName;
            btn_runFindLineTool.Focus();
            Application.DoEvents();

            //myFindLine.Run();         //运行一下，使卡尺显示出来

            tbx_expectLineStartRow.Text = myFindLine.expectLineStartRow.ToString();
            tbx_expectLineStartCol.Text = myFindLine.expectLineStartCol.ToString();
            tbx_expectLineEndRow.Text = myFindLine.expectLineEndRow.ToString();
            tbx_expectLineEndCol.Text = myFindLine.expectLineEndCol.ToString();
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
        }
        /// <summary>
        /// 设定工具运行状态
        /// </summary>
        /// <param name="msg">运行中的信息</param>
        /// <param name="status">运行状态</param>
        public void SetToolStatus(string msg, ToolRunStatu status)
        {
            if(myFindLine!=null)
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

        #region 输入检查
        private void tbx_expectLineStartRow_TextChanged(object sender, EventArgs e)
        {
            try
            {
                myFindLine.expectLineStartRow = Convert.ToDouble(tbx_expectLineStartRow.Text.Trim());
            }
            catch
            {
                SetToolStatus("输入了非法字符，已自动替换为默认值：200", ToolRunStatu.Input_Value_Type_Error);
                tbx_expectLineStartRow.Text = "200";
            }
        }

        private void tbx_expectLineStartCol_TextChanged(object sender, EventArgs e)
        {
            try
            {
                myFindLine.expectLineStartCol = Convert.ToDouble(tbx_expectLineStartCol.Text.Trim());
            }
            catch
            {
                SetToolStatus("输入了非法字符，已自动替换为默认值：200", ToolRunStatu.Input_Value_Type_Error);
                tbx_expectLineStartCol.Text = "200";
            }
        }

        private void tbx_expectLineEndRow_TextChanged(object sender, EventArgs e)
        {
            try
            {
                myFindLine.expectLineEndRow = Convert.ToDouble(tbx_expectLineEndRow.Text.Trim());
            }
            catch
            {
                SetToolStatus("输入了非法字符，已自动替换为默认值：200", ToolRunStatu.Input_Value_Type_Error);
                tbx_expectLineEndRow.Text = "200";
            }
        }

        private void tbx_expectLineEndCol_TextChanged(object sender, EventArgs e)
        {
            try
            {
                myFindLine.expectLineEndCol = Convert.ToDouble(tbx_expectLineEndCol.Text.Trim());
            }
            catch
            {
                SetToolStatus("输入了非法字符，已自动替换为默认值：600", ToolRunStatu.Input_Value_Type_Error);
                tbx_expectLineEndCol.Text = "600";
            }
        }
        
        private void chBDispRec_CheckedChanged(object sender, EventArgs e)
        {
            if(chBDispRec.Checked)
            {
                myFindLine.dispRec = true;
            }
            else
            {
                myFindLine.dispRec = false;
            }
            
        }

        private void chBDispCross_CheckedChanged(object sender, EventArgs e)
        {
            if(chBDispCross.Checked)
            {
                myFindLine.dispCross = true;
            }
            else
            {
                myFindLine.dispCross = false;
            }
        }
        #endregion

        private void FormFindLine_FormClosing(object sender, FormClosingEventArgs e)
        {
            myHwindow.Dispose();
            this.Dispose();
            this.Dispose();
            GC.Collect();
            
        }
    }
}
