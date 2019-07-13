using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisionEditTest
{
    public partial class TestFrmIn : Form
    {
        public string inputText { get; set; } = null;
        /// <summary>
        /// 当前工具所对应的工具对象
        /// </summary>
        internal ShapeMatchTool shapeMatchTool = new ShapeMatchTool();
        /// <summary>
        /// 窗体对象实例
        /// </summary>
        private static TestFrmIn _instance;
        public static TestFrmIn Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new TestFrmIn();
                return _instance;
            }
        }

        public TestFrmIn()
        {
            InitializeComponent();
            //this.inputText = inputText;
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            if(inputText != null)
            {
                MessageBox.Show(inputText);
            }

        }
    }
}
