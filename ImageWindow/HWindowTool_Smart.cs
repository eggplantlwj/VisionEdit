using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HalconDotNet;

namespace ViewROI
{
    public partial class HWindowTool_Smart : UserControl
    {
        public bool DispStatus { get; set; }
        public HImage hv_Image { get; set; }
        public HWindow DispHWindow
        {
            get
            {
                return this.SmartWindow.HalconWindow;
            }
        }
        public HWindowTool_Smart()
        {
            InitializeComponent();
        }
        public void DispImage(HObject inputImage)
        {
            statusStrip.BackColor = Color.White;
            if (inputImage == null || !inputImage.IsInitialized())
            {
                this.lb_Status.Text = "输入图像为空，请检查！";
                statusStrip.BackColor = Color.Red;
                return;
            }
            this.SmartWindow.HalconWindow.DispImage(new HImage(inputImage));
        }

        private void SmartWindow_HMouseMove(object sender, HalconDotNet.HMouseEventArgs e)
        {
            this.Cursor = e.Button == MouseButtons.Left ? Cursors.Hand : Cursors.Default;
            if(DispStatus)
            {

            }
        }

        private void HWindowTool_Smart_Load(object sender, EventArgs e)
        {
            this.MouseWheel += HWindowTool_Smart_MouseWheel;
        }

        private void HWindowTool_Smart_MouseWheel(object sender, MouseEventArgs e)
        {
            Point pt = SmartWindow.Location;
            MouseEventArgs newe = new MouseEventArgs(e.Button, e.Clicks, e.X - pt.X, e.Y - pt.Y, e.Delta);
            SmartWindow.HSmartWindowControl_MouseWheel(sender, newe);
        }

        private void HWindowTool_Smart_SizeChanged(object sender, EventArgs e)
        {
            //Point pt = SmartWindow.Location;
            //Point pt2 = SmartWindow.PointToScreen(pt);
            //this.SmartWindow.HalconWindow.SendMouseDoubleClickEvent(pt2.X+20, pt2.Y+30,(int)MouseButtons.Left);
        }
    }
}
