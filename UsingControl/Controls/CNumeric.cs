using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Controls
{
    public partial class CNumeric : UserControl
    {
        public CNumeric()
        {
            InitializeComponent();
            tbx_value.Text = _value.ToString();
        }

        /// <summary>
        /// 值改变事件
        /// </summary>
        public event DValueChanged ValueChanged;
        /// <summary>
        /// 值
        /// </summary>
        private string _value = string.Empty;
        public string Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
                tbx_value.Text = value.ToString();
            }
        }


        private void tbx_value_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                /*只能数字键、退格键、负号、小数点*/
                if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 &&
                   (int)e.KeyChar != 45 && (int)e.KeyChar != 46) e.Handled = true;
                /*输入为负号和小数点时，且只能输入一次(负号只能最前面输入，小数点不可最前面输入)*/
                if (e.KeyChar == 45 && (((TextBox)sender).SelectionStart != 0 ||
                   ((TextBox)sender).Text.IndexOf("-") >= 0)) e.Handled = true;
                if (e.KeyChar == 46 && (((TextBox)sender).SelectionStart == 0 ||
                   ((TextBox)sender).Text.IndexOf(".") >= 0)) e.Handled = true;
            }
            catch { }
        }
        private void Numeric_Enter(object sender, EventArgs e)
        {
            lbl_line.Height = 2;
            lbl_line.BackColor = Color.FromArgb(18, 150, 219);
        }
        private void Numeric_Leave(object sender, EventArgs e)
        {
            lbl_line.Height = 1;
            lbl_line.BackColor = Color.Gray;
        }
        private void tbx_value_TextChanged(object sender, EventArgs e)
        {
            if (tbx_value.Text != string.Empty && tbx_value.Text != Value.ToString())
                Value = tbx_value.Text;
            if (ValueChanged != null)
                ValueChanged(Convert.ToDouble(Value));
        }

    }
}
