using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HalconDotNet;

namespace VisionEdit
{
    [Serializable]
    public abstract class IVisionJob
    {
        /// <summary>
        /// Job名
        /// </summary>
        public string JobName { get; set; }
        /// <summary>
        /// 需要连线的节点对，不停的画连线，注意键值对中第一个为连线的结束节点，第二个为起始节点，一个输出可能连接多个输入，而键值对中的键不能重复，
        /// 所以把源作为值，输入作为键
        /// </summary>
        public Dictionary<TreeNode, TreeNode> D_itemAndSource { get; set; }
        /// <summary>
        /// 流程运行结果图像
        /// </summary>
        public HObject jobResultImage { get; set; }
        /// <summary>
        /// 流程树中节点的最大长度
        /// </summary>
        public int maxLength { get; set; }
        /// <summary>
        /// 工具对象集合
        /// </summary>
        public List<IToolInfo> L_toolList { get; set; }
        /// <summary>
        /// 正在绘制输入输出指向线
        /// </summary>
        public bool isDrawing { get; set; }
        /// <summary>
        /// 记录本工具执行完的耗时，用于计算各工具耗时
        /// </summary>
        public double recordElapseTime { get; set; }
        /// <summary>
        /// 标准图像字典，用于存储标准图像路径和图像对象
        /// </summary>
        public Dictionary<string, HObject> D_standardImage { get; set; }
        /// <summary>
        /// 记录起始节点和此节点的列坐标值
        /// </summary>
        public Dictionary<TreeNode, Color> startNodeAndColor { get; set; }
        /// <summary>
        /// 记录前面的划线所跨越的列段，
        /// </summary>
        public Dictionary<int, Dictionary<TreeNode, TreeNode>> list { get; set; }
        /// <summary>
        /// 每一个列坐标值对应一种颜色
        /// </summary>
        public Dictionary<int, Color> colValueAndColor { get; set; }
        /// <summary>
        /// 输入输出指向线的颜色数组
        /// </summary>
        public Color[] color { get; set; } = new Color[] { Color.Blue, Color.Orange, Color.Black, Color.Red, Color.Green,
            Color.Brown, Color.Blue, Color.Black, Color.Red, Color.Green, Color.Orange, Color.Brown, Color.Blue, Color.Black,
            Color.Red, Color.Green, Color.Orange, Color.Brown, Color.Blue, Color.Black, Color.Red, Color.Green, Color.Orange,
            Color.Brown, Color.Blue, Color.Black, Color.Red, Color.Green, Color.Orange, Color.Brown};
        /// <summary>
        /// 流程编辑时的右击菜单
        /// </summary>
        public ContextMenuStrip rightClickMenu { get; set; }
        /// <summary>
        /// 在空白除右击菜单
        /// </summary>
        public ContextMenuStrip rightClickMenuAtBlank { get; set; }

    }
}
