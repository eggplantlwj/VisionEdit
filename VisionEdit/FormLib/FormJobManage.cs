using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace VisionEdit.FormLib
{
    public partial class FormJobManage : DockContent
    {
        public FormJobManage()
        {
            InitializeComponent();
            _instance = this;
        }

        /// <summary>
        /// 窗体对象实例
        /// </summary>
        private static FormJobManage _instance;
        public static FormJobManage Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new FormJobManage();
                return _instance;
            }
        }

        private void FormJobManage_Load(object sender, EventArgs e)
        {
        }
    }
}
