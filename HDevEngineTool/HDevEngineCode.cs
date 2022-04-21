using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonMethods;
using ToolBase;
using ViewROI;
using HalconDotNet;
using System.IO;
using Logger;

namespace HDevEngineTool
{
    [Serializable]
    public class HDevEngineCode : IToolBase
    {
        public string uniqueName { get; set; } = Guid.NewGuid().ToString();
        public string toolName { get; set; } = string.Empty;
        [NonSerialized]
        public HDevProgramCall ProgramCall;
        [NonSerialized]
        public HDevEngine MyEngine  = new HDevEngine();
        [NonSerialized]
        public HDevProgram MyProgram  = new HDevProgram();
        public string CodeText { get; set; } = string.Empty;
        public string CodeFilePath { get; set; } = string.Empty;
        public override void DispImage()
        {
           // throw new NotImplementedException();
        }

        public override void DispMainWindow(HWindowTool_Smart window)
        {
           // throw new NotImplementedException();
        }

        public override void Run(SoftwareRunState softwareRunState)
        {
            if (File.Exists(CodeFilePath))
            {
                if(MyProgram != null)
                {
                    if(MyProgram.IsLoaded())
                    {
                        LoggerClass.WriteLog("程序已加载，准备运行！");
                    }
                }
                else
                {
                    FileInfo myFileInfo = new FileInfo(CodeFilePath);
                    MyEngine.SetProcedurePath(myFileInfo.DirectoryName);

                    MyProgram.LoadProgram(CodeFilePath);
                    ProgramCall = new HDevProgramCall(MyProgram);
                    MyEngine.SetHDevOperators(new HDevOpMultiWindowImpl(FormHDevEngineTool.Instance.myHwindow.SmartWindow.HalconWindow));
                }
                ProgramCall.Execute();
            }
        }
    }
}
