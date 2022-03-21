using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HalconDotNet;

namespace CommonMethods
{
    [Serializable]
    public abstract class IVisionJob
    {
        /// <summary>
        /// 当前流程树是否处于折叠状态
        /// </summary>
        public bool jobTreeFold = true;
        /// <summary>
        /// Job名
        /// </summary>
        public string JobName { get; set; }
        /// <summary>
        /// 需要连线的节点对，不停的画连线，注意键值对中第一个为连线的结束节点，第二个为起始节点，一个输出可能连接多个输入，而键值对中的键不能重复，
        /// 所以把源作为值，输入作为键
        /// </summary>
        public Dictionary<TreeNode, TreeNode> D_itemAndSource { get; set; } = new Dictionary<TreeNode, TreeNode>();
        /// <summary>
        /// JOB上的树结构,取消该参数，TreeView无法二进制序列化
        /// </summary>
        //public TreeView tvwOnWorkJob { get; set; } = new TreeView();
        /// <summary>
        /// 工具输入项个数
        /// </summary>
        public int inputItemNum = 0;
        /// <summary>
        /// 工具输出项个数
        /// </summary>
        public int outputItemNum = 0;
        /// <summary>
        /// 流程运行结果图像，取消，无法序列化
        /// </summary>
        public static HObject jobResultImage { get; set; } = new HObject();
        /// <summary>
        /// 流程树中节点的最大长度
        /// </summary>
        public int maxLength { get; set; }
        /// <summary>
        /// 工具对象集合
        /// </summary>
        public List<IToolInfo> L_toolList { get; set; } = new List<IToolInfo>();
        /// <summary>
        /// 正在绘制输入输出指向线
        /// </summary>
        public bool isDrawing { get; set; }
        /// <summary>
        /// 记录本工具执行完的耗时，用于计算各工具耗时
        /// </summary>
        public double recordElapseTime { get; set; }
        /// <summary>
        /// 编辑节点前节点文本，用于修改工具名称
        /// </summary>
        public string nodeTextBeforeEdit { get; set; } = string.Empty;
        /// <summary>
        /// 标准图像字典，用于存储标准图像路径和图像对象
        /// </summary>
        public Dictionary<string, HObject> D_standardImage { get; set; } = new Dictionary<string, HObject>();
        /// <summary>
        /// 记录起始节点和此节点的列坐标值
        /// </summary>
        public Dictionary<TreeNode, Color> startNodeAndColor { get; set; } = new Dictionary<TreeNode, Color>();
        /// <summary>
        /// 记录前面的划线所跨越的列段，
        /// </summary>
        public Dictionary<int, Dictionary<TreeNode, TreeNode>> list { get; set; } = new Dictionary<int, Dictionary<TreeNode, TreeNode>>();
        /// <summary>
        /// 每一个列坐标值对应一种颜色
        /// </summary>
        public Dictionary<int, Color> colValueAndColor { get; set; } = new Dictionary<int, Color>();
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
        public static ContextMenuStrip rightClickMenu { get; set; } = new ContextMenuStrip();
        /// <summary>
        /// 在空白除右击菜单
        /// </summary>
        public static ContextMenuStrip rightClickMenuAtBlank { get; set; }

    }
}
