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
    public delegate void DTextStrChanged(string textStr);
    public partial class CTextBox : UserControl
    {
        public CTextBox()
        {
            InitializeComponent();
            tbx_text.Text = DefaultText;
            //if (PasswordChar && tbx_text.Text != DefaultText)
            //{

            //}
            //else
            //{

            //}
            //if (PasswordChar)
            //{
            //    tbx_text.PasswordChar = '*';
            //    btn_eye.Visible = true;
            //}
            //else
            //{
               
            //}

            if (!PasswordChar)
            {
                tbx_text.PasswordChar = '\0';
                btn_eye.Visible = false;
            }
            else
            {
                tbx_text.PasswordChar = '\0';
                btn_eye.Visible = true  ;
            }
        }

        /// <summary>
        /// 文本改变事件
        /// </summary>
        public event DTextStrChanged TextStrChanged;
        /// <summary>
        /// 控件文本
        /// </summary>
        private string _text = string.Empty;
        public string TextStr
        {
            get
            {
                return _text;
            }
            set
            {
                if (value == string.Empty)
                {
                    tbx_text.PasswordChar = '\0';
                    tbx_text.ForeColor = Color.DarkGray;
                    tbx_text.Text = DefaultText;
                    _text = value;
                }
                else
                {
                    if (PasswordChar)
                        tbx_text.PasswordChar = '*';
                    else
                        tbx_text.PasswordChar = '\0';
                    tbx_text.ForeColor = Color.FromArgb(64, 64, 64);
                    _text = value;
                    tbx_text.Text = _text;
                }
            }
        }
        /// <summary>
        /// 默认文本
        /// </summary>
        private string _defaultText = string.Empty;
        public string DefaultText
        {
            get { return _defaultText; }
            set { _defaultText = value; }
        }
        /// <summary>
        /// 是否以密码形式显示
        /// </summary>
        private bool _passwordChar = false;
        public bool PasswordChar
        {
            get { return _passwordChar; }
            set
            {
                _passwordChar = value;
                if (PasswordChar)
                {
                    tbx_text.PasswordChar = '*';
                }
                else
                {
                    tbx_text.PasswordChar = '\0';
                }
            }
        }


        private void TextBox_Enter(object sender, EventArgs e)
        {
            lbl_line.Height = 2;
            lbl_line.BackColor = Color.FromArgb(18, 150, 219);
            if (tbx_text.Text == DefaultText)
            {
                tbx_text.SelectionStart = 0;
                tbx_text.SelectionLength = 0;
            }
        }
        private void TextBox_Leave(object sender, EventArgs e)
        {
            lbl_line.Height = 1;
            lbl_line.BackColor = Color.Gray;
        }
        private void tbx_text_TextChanged(object sender, EventArgs e)
        {
            if (tbx_text.Text != DefaultText && tbx_text.Text != TextStr)
                TextStr = tbx_text.Text;
            if (TextStrChanged != null)
                TextStrChanged(TextStr);
            if (PasswordChar && TextStr != string.Empty)
                tbx_text.PasswordChar = '*';
            else if (TextStr ==string .Empty )
                tbx_text.PasswordChar = '\0';
        }
        private void tbx_text_KeyDown(object sender, KeyEventArgs e)
        {
            if (tbx_text.Text == DefaultText && e.KeyCode != Keys.Back)
                tbx_text.Text = string.Empty;
        }
        private void tbx_text_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (tbx_text.Text == DefaultText)
                {
                    tbx_text.SelectionStart = 0;
                    tbx_text.SelectionLength = 0;
                }
            }
        }
        private void btn_eye_MouseDown(object sender, MouseEventArgs e)
        {
            tbx_text.PasswordChar = '\0';
            btn_eye.BackgroundImage = Resources.Show;
            //tbx_text.Width = tbx_text.Width - 30;
        }
        private void btn_eye_MouseUp(object sender, MouseEventArgs e)
        {
            if (TextStr != string.Empty)
                tbx_text.PasswordChar = '*';
            btn_eye.BackgroundImage = Resources.Hide;
            tbx_text.Width = tbx_text.Width + 30;
            tbx_text.Focus();
            tbx_text.SelectionStart = 0;
            tbx_text.SelectionLength = 0;
        }
        private void TextBox_Load(object sender, EventArgs e)
        {
            if (!PasswordChar)
            {
                tbx_text.PasswordChar = '\0';
                btn_eye.Visible = false;
            }
            else
            {
                tbx_text.PasswordChar = '\0';
                btn_eye.Visible = true ;
            }
        }

    }
}
