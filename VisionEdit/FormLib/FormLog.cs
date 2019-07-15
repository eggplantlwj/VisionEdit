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
    public partial class FormLog : DockContent
    {
        public FormLog()
        {
            InitializeComponent();
        }
        
        public void ShowLog(string Mes)
        {
            this.Invoke((MethodInvoker)delegate
            {
                if (lbLog.Items.Count > 200) lbLog.Items.Clear();
                string time = DateTime.Now.ToString("HH:mm:ss.fff");
                lbLog.Items.Add(time  + "         "+ Mes);
                lbLog.SelectedIndex = lbLog.Items.Count - 1;
            });
        }
    }
}
