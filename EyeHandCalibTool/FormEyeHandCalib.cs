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

namespace EyeHandCalibTool
{
    public partial class FormEyeHandCalib : Form
    {
        public EyeHandCalib myEyeHandCalib = null;
        public IToolInfo myToolInfo = new IToolInfo();
        public HWindowTool_Smart myHwindow = new HWindowTool_Smart();
        public HDrawingObject selected_drawing_object = new HDrawingObject();

        public FormEyeHandCalib(ref object eyeHandCalib)
        {
            InitializeComponent();
            _instance = this;
            if (eyeHandCalib.GetType().FullName != "System.Object")
            {
                myToolInfo = (IToolInfo)eyeHandCalib;
                myEyeHandCalib = (EyeHandCalib)myToolInfo.tool;
                myEyeHandCalib.DispImage();
            }
        }
        /// <summary>
        /// 窗体对象实例
        /// </summary>
        private static FormEyeHandCalib _instance;
        public static FormEyeHandCalib Instance
        {
            get
            {
                if (_instance != null)
                {
                    lock (_instance)
                    {
                        if (_instance == null)
                        {
                            object eyeHandCalib = new object();
                            _instance = new FormEyeHandCalib(ref eyeHandCalib);
                        }
                        return _instance;
                    }
                }
                else
                {
                    object eyeHandCalib = new object();
                    _instance = new FormEyeHandCalib(ref eyeHandCalib);
                    return _instance;
                }

            }
        }

        public FormEyeHandCalib()
        {
            InitializeComponent();
        }

        private void chbSelectCalibType_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalibType oldType = myEyeHandCalib.calibType;
            myEyeHandCalib.calibType = chbSelectCalibType.SelectedItem.ToString() == "四点标定" ? CalibType.Four_Point : CalibType.Nine_Point;
            if(oldType == CalibType.Four_Point && myEyeHandCalib.calibType == CalibType.Nine_Point)
            {
                for (int i = 0; i < 5; i++)
                {
                    DataRow dr = myEyeHandCalib.CalibSourceDataTable.NewRow();
                    dr[0] = 0;
                    dr[1] = 50;
                    dr[2] = 0;
                    dr[3] = 50;
                    myEyeHandCalib.CalibSourceDataTable.Rows.Add(dr);
                }
            }
            else if(oldType == CalibType.Nine_Point && myEyeHandCalib.calibType == CalibType.Four_Point)
            {
                for (int i = 0; i < 5; i++)
                {
                    myEyeHandCalib.CalibSourceDataTable.Rows.RemoveAt(myEyeHandCalib.CalibSourceDataTable.Rows.Count - 1);
                }    
            }
        }

        private void FormEyeHandCalib_Load(object sender, EventArgs e)
        {
            // 若为空，表示该工具未经标定校正
            if(myEyeHandCalib.CalibSourceDataTable == null)
            {
                myEyeHandCalib.InitDataTable();
            }
            CalibDataGrid.DataSource = myEyeHandCalib.CalibSourceDataTable;
            chbSelectCalibType.SelectedItem = myEyeHandCalib.calibType == CalibType.Four_Point ? "四点标定" : "九点标定";
            txbScaleX.Text = (Convert.ToDouble(myEyeHandCalib.ScanX.ToString())).ToString("0.00");
            txbScaleY.Text = (Convert.ToDouble(myEyeHandCalib.ScanY.ToString())).ToString("0.00");
            txbRatation.Text = (Convert.ToDouble(myEyeHandCalib.Rotation.ToString())).ToString("0.00");
            txbTheta.Text = (Convert.ToDouble(myEyeHandCalib.Theta.ToString())).ToString("0.00");
            txbMoveX.Text = (Convert.ToDouble(myEyeHandCalib.TranslateX.ToString())).ToString("0.00");
            txbMoveY.Text = (Convert.ToDouble(myEyeHandCalib.TranslateY.ToString())).ToString("0.00");

        }

        private void CalibDataGrid_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            using (SolidBrush b = new SolidBrush(
               CalibDataGrid.RowHeadersDefaultCellStyle.ForeColor))
            {
                e.Graphics.DrawString((e.RowIndex + 1).ToString(
                        System.Globalization.CultureInfo.CurrentCulture),
                        CalibDataGrid.DefaultCellStyle.Font
                        , b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y);
            }
        }

        private void btnImportData_Click(object sender, EventArgs e)
        {
            myEyeHandCalib.ReadCalibData();
            CalibDataGrid.Refresh();
        }

        private void btnExportData_Click(object sender, EventArgs e)
        {
            myEyeHandCalib.ExportCalibData();
        }

        private void btnCalibManual_Click(object sender, EventArgs e)
        {
            if(myEyeHandCalib.ManulCalib())
            {
                // 仿射矩阵信息
                txbScaleX.Text = (Convert.ToDouble(myEyeHandCalib.ScanX.ToString())).ToString("0.00");
                txbScaleY.Text = (Convert.ToDouble(myEyeHandCalib.ScanY.ToString())).ToString("0.00");
                txbRatation.Text = (Convert.ToDouble(myEyeHandCalib.Rotation.ToString())).ToString("0.00");
                txbTheta.Text = (Convert.ToDouble(myEyeHandCalib.Theta.ToString())).ToString("0.00");
                txbMoveX.Text = (Convert.ToDouble(myEyeHandCalib.TranslateX.ToString())).ToString("0.00");
                txbMoveY.Text = (Convert.ToDouble(myEyeHandCalib.TranslateY.ToString())).ToString("0.00");
                // 映射成功，则保存矩阵
                HOperatorSet.WriteTuple(myEyeHandCalib.homMat2D, myEyeHandCalib.homMat2DName + ".tup");
                MessageBox.Show("仿射矩阵已经保存成功！");
            }

        }
        /// <summary>
        /// 设定工具运行状态
        /// </summary>`
        /// <param name="msg">运行中的信息</param>
        /// <param name="status">运行状态</param>
        public void SetToolStatus(string msg, ToolRunStatu status)
        {
            if (myEyeHandCalib != null)
            {
                myEyeHandCalib.runMessage = msg;
                myEyeHandCalib.toolRunStatu = status;
                lb_RunStatus.Text = myEyeHandCalib.toolRunStatu == ToolRunStatu.Succeed ? "工具运行成功！" : $"工具运行异常, 异常原因：{myEyeHandCalib.runMessage}";
                lb_RunTime.Text = myEyeHandCalib.runTime;
                statusStrip.BackColor = myEyeHandCalib.toolRunStatu == ToolRunStatu.Succeed ? Color.LimeGreen : Color.Red;
            }
        }

        private void tsbtRunTool_Click(object sender, EventArgs e)
        {
            myEyeHandCalib.Run(SoftwareRunState.Debug);
        }
    }
}
