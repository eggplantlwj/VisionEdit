/*
* ==============================================================================
*
* Filename: ToolRun
* Description: 
*
* Version: 1.0
* Created: 2021/2/25 15:27:56
*
* Author: liu.wenjie
*
* ==============================================================================
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CommonMethods.Interface
{
    public interface IToolRun
    {
        void ToolRun(string jobName, int toolIndex, int inputItemNum, TreeNode selectNode, List<IToolInfo> L_toolList, IVisionJob runJob, Form myHalconWindow);
    }
}
