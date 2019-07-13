using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace VisionEdit
{
    public class DockPanelOperate
    {
        private string m_DockPath { get; set; } = string.Empty;

        public DockPanelOperate()
        {
            m_DockPath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "DockPanel.config");
        }

        
    }
}
