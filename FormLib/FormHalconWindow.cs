using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewROI;

namespace FormLib
{
    public partial class FormHalconWindow : Form
    {
        public HWindowTool_Smart myHWindow = new HWindowTool_Smart();
        public string WindowName { get; set; }

        public FormHalconWindow(string inputName)
        {
            InitializeComponent();
            WindowName = inputName;
        }

        private void FormHalconWindow_Load(object sender, EventArgs e)
        {
            panel1.Controls.Add(myHWindow);
            myHWindow.Dock = DockStyle.Fill;
        }
        public void ClearWindow()
        {
            myHWindow.DispHWindow.ClearWindow();
        }
    }
}
