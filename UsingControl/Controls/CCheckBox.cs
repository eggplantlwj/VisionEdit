using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controls.Properties;

namespace Controls
{
    public delegate void DCheckChanged(bool Checked);
    public partial class CCheckBox : UserControl
    {
        public CCheckBox()
        {
            InitializeComponent();
            ckb_box.Text = TextStr;
        }

        /// <summary>
        /// 状态改变事件
        /// </summary>
        public event DCheckChanged CheckChanged;
        /// <summary>
        /// 勾选状态
        /// </summary>
        private bool _checked = false;
        public bool Checked
        {
            get { return _checked; }
            set
            {
                _checked = value;
                ckb_box.Checked = value;
            }
        }
        /// <summary>
        /// 文本
        /// </summary>
        private string _textStr = "复选框";
        public string TextStr
        {
            get { return _textStr; }
            set
            {
                _textStr = value;
                ckb_box.Text = value;
            }
        }


        private void pic_image_Click(object sender, EventArgs e)
        {
            ckb_box.Checked = !ckb_box.Checked;
        }
        private void ckb_box_CheckedChanged(object sender, EventArgs e)
        {
            if (ckb_box.Checked)
            {
                pic_image.Image = Resources.复选框;
                Checked = true;
            }
            else
            {
                pic_image.Image = Resources.去复选框;
                Checked = false;
            }
            if (CheckChanged != null)
                CheckChanged(ckb_box.Checked);
        }

    }
}
