using CommonMethods.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonMethods;
using System.Windows.Forms;

namespace EyeHandCalibTool
{
    public class EyeHandCalibRun : IToolRun
    {
        public void ToolRun(string jobName, int toolIndex, int inputItemNum, TreeNode selectNode, List<IToolInfo> L_toolList, IVisionJob runJob, Form myHalconWindowForm)
        {
          //  throw new NotImplementedException();

        }
    }
}
