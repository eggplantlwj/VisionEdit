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
        HWindow_Final myWindow = new HWindow_Final();
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.panel1.Controls.Add(myWindow);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HObject image = new HObject();
            HOperatorSet.ReadImage(out image, @"G:\Outer_HB.bmp");
            myWindow.HobjectToHimage(image);
        }
    }
}
