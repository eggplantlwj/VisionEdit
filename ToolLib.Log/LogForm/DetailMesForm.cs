using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogForm
{
    public partial class DetailMesForm : Form
    {
        private string detailMsg = string.Empty;
        public DetailMesForm(string detailMsg)
        {
            InitializeComponent();
            this.detailMsg = detailMsg;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DetailMesForm_Load(object sender, EventArgs e)
        {
            try
            {
                string time = detailMsg.Split('>')[0];
                string level = detailMsg.Split(',')[0].Split('>')[1];
                lb_Time.Text = time;
                lb_Level.Text = level;
                Rtb_DetailMes.Text = detailMsg;
            }
            catch (Exception)
            {
                Rtb_DetailMes.Text = detailMsg;
            }
            
        }
    }
}
