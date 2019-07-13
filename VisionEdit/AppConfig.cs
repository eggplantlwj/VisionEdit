using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeifenLuo.WinFormsUI.Docking;

namespace VisionEdit
{
    public class AppConfig
    {
        public static DockState leftForm = DockState.DockLeft;   // 功能窗体，左端停靠  
        public static DockState rightForm = DockState.DockRight;   // 功能窗体，右端停靠  
        public static DockState docForm = DockState.Document;   // 功能窗体，中间停靠  
    }
}
