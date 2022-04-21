using CommonMethods;
using FormLib;
using HalconDotNet;
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

namespace HDevEngineTool
{
    public partial class FormHDevEngineTool : Form
    {
        private HDevEngineCode myHDevEngine = new HDevEngineCode();
        public IToolInfo myToolInfo = new IToolInfo();
        public HWindowTool_Smart myHwindow = new HWindowTool_Smart();

        public FormHDevEngineTool(ref object hdevEngine)
        {
            InitializeComponent();
            _instance = this;
            if (hdevEngine.GetType().FullName != "System.Object")
            {
                myToolInfo = (IToolInfo)hdevEngine;
                myHDevEngine = (HDevEngineCode)myToolInfo.tool;
                myHDevEngine.toolName = myToolInfo.FormToolName;
                myHDevEngine.DispImage();
            }
        }

        /// <summary>
        /// 窗体对象实例
        /// </summary>
        private static FormHDevEngineTool _instance;
        public static FormHDevEngineTool Instance
        {
            get
            {
                if (_instance != null)
                {
                    lock (_instance)
                    {
                        if (_instance == null)
                        {
                            object hdevEngine = new object();
                            _instance = new FormHDevEngineTool(ref hdevEngine);
                        }
                        return _instance;
                    }
                }
                else
                {
                    object hdevEngine = new object();
                    _instance = new FormHDevEngineTool(ref hdevEngine);
                    return _instance;
                }

            }
        }

        private void FormHDevEngineTool_Load(object sender, EventArgs e)
        {
            this.panelHImageWindow.Controls.Add(myHwindow);
            myHwindow.Dock = DockStyle.Fill;
        }

        public void InitTool()
        {
            txbCodeText.Text = myHDevEngine.CodeText;
        }

        private void tsbReadHdev_Click(object sender, EventArgs e)
        {
            OpenFileDialog myDia = new OpenFileDialog();
            myDia.Filter = "Halcon程序(*.hdev)|*.hdev";
            myDia.Title = "打开Halcon程序";
            if (myDia.ShowDialog() == DialogResult.OK)
            {
                string filePath = myDia.FileName;
                myHDevEngine.CodeFilePath = filePath;
                string hdevText = FileOperate.ReadFile(filePath);
                txbCodeText.Text = hdevText;
            }
        }

        private void tsbSaveHdev_Click(object sender, EventArgs e)
        {
            SaveFileDialog myDia = new SaveFileDialog();
            myDia.Filter = "Halcon程序(*.hdev)|*.hdev";
            if (myDia.ShowDialog() == DialogResult.OK)
            {
                string path = myDia.FileName;
                myHDevEngine.CodeFilePath = path;
                FileOperate.WriteFile(path, txbCodeText.Text);
            }

        }

        private void tsbReLoad_Click(object sender, EventArgs e)
        {
            if (File.Exists(myHDevEngine.CodeFilePath))
            {
                FileInfo myFileInfo = new FileInfo(myHDevEngine.CodeFilePath);
                myHDevEngine.MyEngine.SetProcedurePath(myFileInfo.DirectoryName);

                myHDevEngine.MyProgram.LoadProgram(myHDevEngine.CodeFilePath);
                myHDevEngine.ProgramCall = new HDevProgramCall(myHDevEngine.MyProgram);
                myHDevEngine.MyEngine.SetHDevOperators(new HDevOpMultiWindowImpl(myHwindow.SmartWindow.HalconWindow));
            }

        }

        private void tsbtRunTool_Click(object sender, EventArgs e)
        {
            if(myHDevEngine.ProgramCall != null)
            {
                myHDevEngine.ProgramCall.Execute();
            }
            
        }
    }
}
