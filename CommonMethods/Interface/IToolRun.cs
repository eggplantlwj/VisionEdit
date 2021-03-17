/*
* ==============================================================================
*
* Filename: IToolRun
* Description: 
*
* Version: 1.0
* Created: 2021/2/25 14:49:20
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
        void ToolRun(int toolIndex, int inputItemNum, TreeNode selectNode, FormLog myFormLog, FormImageWindow myFormWindow, List<IToolInfo> L_toolList);
    }
}
