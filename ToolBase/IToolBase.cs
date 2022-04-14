using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonMethods;
using HalconDotNet;
using ViewROI;

namespace ToolBase
{
    [Serializable]
    public abstract class IToolBase
    {
        public ToolRunStatu toolRunStatu { get; set; } = ToolRunStatu.Not_Run;
        public SoftwareRunState softwareRunState { get; set; } = SoftwareRunState.Debug;
        public string runMessage { get; set; }
        public string runTime { get; set; }
        public abstract void Run(SoftwareRunState softwareRunState); 
        public HObject inputImage { get; set; }
        public abstract void  DispImage();
        public abstract void DispMainWindow(HWindowTool_Smart window);
    }
}
