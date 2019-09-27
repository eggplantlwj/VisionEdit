using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VisionEdit.FormLib;

namespace VisionEdit.ToolRunLib
{
    interface IToolRun
    {
        void ToolRun(int toolIndex, int inputItemNum, TreeNode selectNode, FormLog myFormLog, FormImageWindow myFormWindow, List<CommonMethods.IToolInfo> L_toolList);
    }
}
