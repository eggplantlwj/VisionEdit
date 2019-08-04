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
using HalconDotNet;
using HalconWindow.HalconWindow;

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
        }


        public FormFindLine(ref object findLine)
        {
            InitializeComponent();
            _instance = this;
            myToolInfo = (IToolInfo)findLine;
            myFindLine = (FindLine)myToolInfo.tool;
            myFindLine.inputImage = ComGlobalParams.inputImageGlobal; // 暂时直接将图像传递给该工具
            myFindLine.DispImage();
            
        }

        private void FormFindLine_Load(object sender, EventArgs e)
        {
            this.panel1.Controls.Add(myHwindow);
            myHwindow.Dock = DockStyle.Fill;
            InitTool();
        }

        private void btn_moveCliperRegion_Click(object sender, EventArgs e)
        {
            myFindLine.DrawExpectLine(myHwindow);
        }

        public void TextBoxMessageDisp(string mes, Color setColor)
        {
            txbLog.BackColor = setColor;
            txbLog.Text = mes;
            txbLog.Font = new Font("微软雅黑", 10, FontStyle.Bold);
            CommonMethods.CommonMethods.Delay(2000);
            txbLog.BackColor = Color.White;
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
            myFindLine.polarity = cbx_polarity.SelectedItem.ToString() == "由明到暗" ? "negative":"positive";
            myFindLine.edgeSelect = cbx_edgeSelect.SelectedItem.ToString();
            myFindLine.sigma = Convert.ToDouble(tbx_Sigma.Text.Trim());
            // Run
            myFindLine.Run();
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
            cbx_polarity.Text = myFindLine.polarity == "positive" ? "由暗到明" : "由明到暗";
            tbx_caliperNum.Text = myFindLine.cliperNum.ToString();
            tbx_caliperLength.Text = myFindLine.length.ToString();
            tbx_threshold.Text = myFindLine.threshold.ToString();
            tbx_Sigma.Text = myFindLine.sigma.ToString();
            tbx_caliperLength2.Text = myFindLine.weidth.ToString();
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
                TextBoxMessageDisp("输入了非法字符，已自动替换为默认值：200", Color.Red);
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
                TextBoxMessageDisp("输入了非法字符，已自动替换为默认值：200", Color.Red);
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
                TextBoxMessageDisp("输入了非法字符，已自动替换为默认值：200", Color.Red);
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
                TextBoxMessageDisp("输入了非法字符，已自动替换为默认值：600", Color.Red);
                tbx_expectLineEndCol.Text = "600";
            }
        }
        #endregion
    }
}
