using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logger
{
    public partial class LogDetail : Form
    {
        string logMsg = string.Empty;
        public LogDetail(string inputMsg)
        {
            InitializeComponent();
            logMsg = inputMsg;
        }

        private void LogDetail_Load(object sender, EventArgs e)
        {
            try
            {
                string time = Regex.Split(logMsg, " -> ")[0];
                string msgLevel = Regex.Split(logMsg, " -> ")[1].Split(',')[0];
                string msgDetal = Regex.Split(logMsg, " -> ")[1];
               // msgDetal = Regex.Split(msgDetal, ",")[1];
                txbLogTime.Text = time;
                txbLogLevel.Text = msgLevel;
                txbLogLevel.BackColor = (msgLevel == "Warn" || msgLevel == "Exception") ? Color.Red : Color.Lime;
                richDetail.Text = msgDetal;
            }
            catch (Exception)
            {
                richDetail.Text = logMsg;
            }
        }
    }
}
