using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonMethods;
using HalconDotNet;

namespace ToolBase
{
    public interface IToolBase
    {
        SoftwareRunState softwareRunState { get; set; }
        ToolRunStatu toolRunStatu { get; set; }
        void Run(SoftwareRunState softwareRunState); 
        HObject inputImage { get; set; }
        void DispImage();
    }
}
