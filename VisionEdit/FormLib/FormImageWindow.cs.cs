using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HalconWindowTest.HalconWindow;
using WeifenLuo.WinFormsUI.Docking;

namespace VisionEdit.FormLib
{
    public partial class FormImageWindow : DockContent
    {
        public FormImageWindow()
        {
            InitializeComponent();
        }
        public string m_fileName = string.Empty;
        /// <summary>
        /// 窗体对象实例
        /// </summary>
        private static FormImageWindow _instance;
        public static FormImageWindow Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new FormImageWindow();
                return _instance;
            }
        }

        private void FormImageWindow_Load(object sender, EventArgs e)
        {
            HWindow_Final myHWindow = new HWindow_Final();
            this.panel1.Controls.Add(myHWindow);
            myHWindow.Dock = DockStyle.Fill;
        }
    }
}
