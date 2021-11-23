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
    public delegate void DClicked();
    public partial class CButton : UserControl
    {
        public CButton()
        {
            InitializeComponent();
            btn_button.Text = TextStr;
        }

        /// <summary>
        /// 点击事件
        /// </summary>
        public event DClicked Clicked;
        /// <summary>
        /// 文本
        /// </summary>
        private string _textStr = "Button";
        public string TextStr
        {
            get { return _textStr; }
            set
            {
                _textStr = value;
                btn_button.Text = value;
            }
        }
        private void btn_button_MouseEnter(object sender, EventArgs e)
        {
            btn_button.BackgroundImage = Resources.ButtonEnter;
            Application.DoEvents();
        }
        private void btn_button_MouseDown(object sender, MouseEventArgs e)
        {
            btn_button.BackgroundImage = Resources.ButtonDown;
            Application.DoEvents();
        }
        private void btn_button_MouseLeave(object sender, EventArgs e)
        {
            btn_button.BackgroundImage = Resources.ButtonUp;
            Application.DoEvents();
        }
        private void btn_button_MouseUp(object sender, MouseEventArgs e)
        {
            btn_button.BackgroundImage = Resources.ButtonUp;
            Application.DoEvents();
        }
        private void btn_button_Click(object sender, EventArgs e)
        {
            if (Clicked != null)
                Clicked();
        }

    }
}
