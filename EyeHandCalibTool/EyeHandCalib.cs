using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonMethods;
using ToolBase;
using ViewROI;
using HalconDotNet;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using Logger;
using static DataStruct.DataStructClass;

namespace EyeHandCalibTool
{
    [Serializable]
    public class EyeHandCalib : IToolBase
    {
        /// <summary>
        /// 仿射变换矩阵
        /// </summary>
        public HTuple homMat2D = new HTuple();
        /// <summary>
        /// 标定类型 四点标定|九点标定
        /// </summary>
        public CalibType calibType = CalibType.Four_Point;
        /// <summary>
        /// 标定表源数据
        /// </summary>
        public DataTable CalibSourceDataTable { get; set; } = null;
        /// <summary>
        /// 输入点信息
        /// </summary>
        public Point inputPoint = new Point();
        /// <summary>
        /// 输出点信息
        /// </summary>
        public Point outputPoint = new Point();
        /// <summary>
        /// 矩阵名称
        /// </summary>
        public string homMat2DName { get; set; } = Guid.NewGuid().ToString();
        /// <summary>
        /// X平移
        /// </summary>
        private HTuple _translateX = 0;
        internal HTuple TranslateX
        {
            get
            {
                _translateX = Math.Round((double)_translateX, 2);
                return _translateX;
            }
            set
            {
                value = Math.Round((double)value, 2);
                _translateX = value;
            }
        }
        /// <summary>
        /// Y平移
        /// </summary>
        private HTuple _translateY = 0;
        internal HTuple TranslateY
        {
            get
            {
                _translateY = Math.Round((double)_translateY, 2);
                return _translateY;
            }
            set
            {
                value = Math.Round((double)value, 2);
                _translateY = value;
            }
        }
        /// <summary>
        /// X缩放
        /// </summary>
        private HTuple _scanX = 1;
        internal HTuple ScanX
        {
            get
            {
                _scanX = Math.Round((double)_scanX, 2);
                return _scanX;
            }
            set
            {
                value = Math.Round((double)value, 2);
                _scanX = value;
            }
        }
        /// <summary>
        /// Y缩放
        /// </summary>
        private HTuple _scanY = 1;
        internal HTuple ScanY
        {
            get
            {
                _scanY = Math.Round((double)_scanY, 2);
                return _scanY;
            }
            set
            {
                value = Math.Round((double)value, 2);
                _scanY = value;
            }
        }
        /// <summary>
        /// 角度旋转
        /// </summary>
        private HTuple _rotation = 0;
        internal HTuple Rotation
        {
            get
            {
                _rotation = Math.Round((double)_rotation, 2);
                return _rotation;
            }
            set
            {
                value = Math.Round((double)value, 2);
                _rotation = value;
            }
        }
        /// <summary>
        /// 轴斜切
        /// </summary>
        private HTuple _theta = 0;
        internal HTuple Theta
        {
            get
            {
                _theta = Math.Round((double)_theta, 2);
                return _theta;
            }
            set
            {
                value = Math.Round((double)value, 2);
                _theta = value;
            }
        }

        public override void DispImage()
        {
          //  throw new NotImplementedException();
        }

        public override void DispMainWindow(HWindowTool_Smart window)
        {
           // throw new NotImplementedException();
        }

        public override void Run(SoftwareRunState softwareRunState)
        {
            try
            {
                // 若首次加载且本地存在矩阵，优先读取本地
                if (File.Exists(homMat2DName) && homMat2D.Length == 0)
                {
                    HOperatorSet.ReadTuple(homMat2DName, out homMat2D);
                }
                // 再次判断
                if (homMat2D.Length == 0)
                {
                    runMessage = $"{FormEyeHandCalib.Instance.myToolInfo.FormToolName}未生成仿射矩阵工具，需要先标定标准！";
                    toolRunStatu = ToolRunStatu.Tool_Run_Error;
                    FormEyeHandCalib.Instance.SetToolStatus(runMessage, toolRunStatu);
                }
                else
                {
                    HTuple tupOutX, tupOutY;
                    HOperatorSet.AffineTransPoint2d(homMat2D, inputPoint.Row, inputPoint.Col, out tupOutX, out tupOutY);
                    outputPoint.Row = tupOutX;
                    outputPoint.Col = tupOutY;
                    runMessage = $"{FormEyeHandCalib.Instance.myToolInfo.FormToolName}运行成功";
                    toolRunStatu = ToolRunStatu.Succeed;
                    FormEyeHandCalib.Instance.SetToolStatus(runMessage, toolRunStatu);
                }
            }
            catch (Exception ex)
            {
                runMessage = $"{FormEyeHandCalib.Instance.myToolInfo.FormToolName}运行出现异常";
                toolRunStatu = ToolRunStatu.Tool_Run_Error;
            }
           
        }

        /// <summary>
        /// 初始化标定数据源
        /// </summary>
        public void InitDataTable()
        {
            CalibSourceDataTable = new DataTable();
            //初始化DataTable，并将datatable绑定到DataGridView的数据源
            DataColumn c1 = new DataColumn("像素X", typeof(double));
            DataColumn c2 = new DataColumn("像素Y", typeof(double));
            DataColumn c3 = new DataColumn("机械X", typeof(double));
            DataColumn c4 = new DataColumn("机械Y", typeof(double));
            CalibSourceDataTable.Columns.Add(c1);
            CalibSourceDataTable.Columns.Add(c2);
            CalibSourceDataTable.Columns.Add(c3);
            CalibSourceDataTable.Columns.Add(c4);
            CalibSourceDataTable.Rows.Clear();
            for (int i = 0; i < (int)calibType; i++)
            {
                DataRow dr = CalibSourceDataTable.NewRow();
                dr[0] = 0;
                dr[1] = 50;
                dr[2] = 0;
                dr[3] = 50;
                CalibSourceDataTable.Rows.Add(dr);
            }
        }

        /// <summary>
        /// 导入标定数据
        /// </summary>
        public void ReadCalibData()
        {
            OpenFileDialog digOpenFile = new OpenFileDialog();
            digOpenFile.FileName = string.Empty;
            digOpenFile.Title = "请选择表格文件";
            digOpenFile.Filter = "CSV文件(*.csv)|*.csv";
            if (digOpenFile.ShowDialog() == DialogResult.OK)
            {
                string[] lines = File.ReadAllLines(digOpenFile.FileName, Encoding.Default);
                for (int i = 0; i < lines.Length; i++)
                {
                    string[] data = Regex.Split(lines[i], ",");
                    for (int j = 0; j < data.Length; j++)
                    {
                        CalibSourceDataTable.Rows[i][j] = data[j];
                        if (j == 3)            //只导入前四列
                            break;
                    }
                    if (i == (int)calibType)           //若标定类型为四点标定，则导入前四行，若为九点标定，则导入前九行
                        break;
                }
            }
        }
        /// <summary>
        /// 导出标定数据
        /// </summary>
        public void ExportCalibData()
        {
            try
            {
                SaveFileDialog dig_saveImage = new SaveFileDialog();
                dig_saveImage.FileName = "CalibData " + DateTime.Now.ToString("yyyy_MM_dd");
                dig_saveImage.Title = "请选择导出路径";
                dig_saveImage.Filter = "CSV文件(*.csv)|*.csv";
                if (dig_saveImage.ShowDialog() == DialogResult.OK)
                {
                    File.Create(dig_saveImage.FileName).Close();
                    string data = string.Empty;
                    for (int i = 0; i <CalibSourceDataTable.Rows.Count; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            data += CalibSourceDataTable.Rows[i][j];
                            if (j < 3)
                                data += ",";
                        }
                        data += Environment.NewLine;
                    }
                    File.AppendAllText(dig_saveImage.FileName, data, Encoding.Default);
                }
            }
            catch (Exception ex)
            {
                Logger.LoggerClass.WriteLog("导出标定数据时出错", ex);
            }
        }

        public bool ManulCalib()
        {
            try
            {
                List<double> pixelRowList = new List<double>();
                List<double> pixelColList = new List<double>();
                List<double> MechanicalXList = new List<double>();
                List<double> MechanicalYList = new List<double>();
                try
                {
                    for (int i = 0; i < CalibSourceDataTable.Rows.Count; i++)
                    {
                        pixelRowList.Add(Convert.ToDouble(CalibSourceDataTable.Rows[i][0]));
                        pixelColList.Add(Convert.ToDouble(CalibSourceDataTable.Rows[i][1]));
                        MechanicalXList.Add(Convert.ToDouble(CalibSourceDataTable.Rows[i][2]));
                        MechanicalYList.Add(Convert.ToDouble(CalibSourceDataTable.Rows[i][3]));
                    }
                }
                catch(Exception ex)
                {
                    LoggerClass.WriteLog("标定失败，标定数据异常（错误代码：12901）", ex);
                    return false;
                }

                try
                {
                    HTuple pixelRow = new HTuple(pixelRowList.ToArray());
                    HTuple pixelCol = new HTuple(pixelColList.ToArray());
                    HTuple mechanicalX = new HTuple(MechanicalXList.ToArray());
                    HTuple mechanicalY = new HTuple(MechanicalYList.ToArray());
                    HOperatorSet.VectorToHomMat2d(pixelRow, pixelCol, mechanicalX, mechanicalY, out homMat2D);
                }
                catch(HalconException ex)
                {
                    LoggerClass.WriteLog("标定失败，标定数据异常，无法确定仿射变换关系（错误代码：12902）", ex);
                    return false;
                }
                HOperatorSet.HomMat2dToAffinePar(homMat2D, out _scanX, out _scanY, out _rotation, out _theta, out _translateX, out _translateY);
                return true;
            }
            catch (Exception ex)
            {
                LoggerClass.WriteLog("手动标定出现异常", ex);
                return false;
            }
        }
    }

    /// <summary>
    /// 标定类型 四点|九点
    /// </summary>
    [Serializable]
    public enum CalibType
    {
        Four_Point = 4,
        Nine_Point = 9,
    }
}
