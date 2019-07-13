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
    public partial class FormToolBox : DockContent
    {
        public FormToolBox()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体对象实例
        /// </summary>
        private static FormToolBox _instance;
        public static FormToolBox Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new FormToolBox();
                return _instance;
            }
        }
    }
}
