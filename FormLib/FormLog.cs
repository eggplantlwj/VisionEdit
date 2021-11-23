using Logger;
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

namespace FormLib
{
    public partial class FormLog : DockContent
    {
        UserLogger myUserLog = new UserLogger();
        public FormLog()
        {
            InitializeComponent();
        }
        private void FormLog_Load(object sender, EventArgs e)
        {
            this.Controls.Add(myUserLog);
            myUserLog.Dock = DockStyle.Fill;
        }
    }
}
