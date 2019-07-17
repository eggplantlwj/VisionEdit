using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisionEdit.VisionTool;

namespace VisionEdit
{
    public class GlobalParams
    {
        /// <summary>
        /// 流程树
        /// </summary>
        public static TreeView myJobTreeView { get; set; }
        public static VisionJob myVisionJob { get; set; }

        public static VisionToolFactory myVisionToolFactory = new VisionToolFactory();
    }
}
