using System;
using System.Windows.Forms;
using HalconWindow.HalconWindow;

namespace FindCircle
{
    public partial class FormFindCircle : Form
    {
        FindClrcle myFindCircle = null;
        public FormFindCircle(object findCircleClass)
        {
            InitializeComponent();
            myFindCircle = (FindClrcle)findCircleClass;
        }

        private void FormFindCircle_Load(object sender, EventArgs e)
        {
            HWindow_Final myWindow = new HWindow_Final();
            this.panel1.Controls.Add(myWindow);
        }
    }
}
