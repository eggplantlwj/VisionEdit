using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisionEdit
{
    public abstract class IToolInfo
    {
        /// <summary>
        /// 工具是否启用
        /// </summary>
        public bool enable { get; set; }
        /// <summary>
        /// 工具名称
        /// </summary>
        public string toolName { get; set; }
        /// <summary>
        /// 工具类型
        /// </summary>
        public ToolType toolType { get; set; }
        /// <summary>
        /// 工具对象
        /// </summary>
        public object tool { get; set; }
        /// <summary>
        /// 工具描述信息
        /// </summary>
        public string toolTipInfo { get; set; }
        /// <summary>
        /// 工具输入字典集合
        /// </summary>
        public List<ToolIO> toolInput { get; set; }
        /// <summary>
        /// 工具输出字典集合
        /// </summary>
        public List<ToolIO> toolOutput { get; set; }

    }

    /// <summary>
    /// 工具的输入输出类
    /// </summary>
    [Serializable]
    public class ToolIO
    {

        public string IOName;
        public object value;
        public DataType ioType;

        public ToolIO() { }
        public ToolIO(string IOName1, object value1, DataType ioType1)
        {
            this.IOName = IOName1;
            this.value = value1;
            this.ioType = ioType1;
        }

    }
}
