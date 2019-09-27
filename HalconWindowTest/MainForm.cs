using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HalconWindow.HalconWindow;
using HalconDotNet;

namespace HalconWindow
{
    public partial class MainForm : Form
    {
        HWindowSmart myWindow = new HWindowSmart();
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.panel1.Controls.Add(myWindow);
            myWindow.Dock = DockStyle.Fill;
            HObject image = new HObject();
            HOperatorSet.ReadImage(out image, @"G:\Outer_HB.bmp");
            myWindow.hSmartWindowControl.HalconWindow.DispObj(image);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HObject image = new HObject();
            HOperatorSet.ReadImage(out image, @"G:\Outer_HB.bmp");
            myWindow.hSmartWindowControl.HalconWindow.DispObj(image);
           // myWindow.HobjectToHimage(image);
        }
    }
}
