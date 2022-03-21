/*
* ==============================================================================
*
* Filename: VisionToolAttribute
* Description: 
*
* Version: 1.0
* Created: 2021/2/26 13:46:51
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

namespace CommonMethods
{
    //自定义Attribute
    public sealed class VisionToolAttribute : Attribute
    {
        public ToolType ToolType { get; private set; }
        public VisionToolAttribute(ToolType toolType)
        {
            ToolType = toolType;
        }
    }
}
