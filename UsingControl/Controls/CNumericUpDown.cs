using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Controls.Properties;

namespace Controls
{
    public delegate void DValueChanged(double value);
    public partial class CNumericUpDown : UserControl
    {
        public CNumericUpDown()
        {
            InitializeComponent();
            nud_value.Text = Value.ToString();
        }

        /// <summary>
        /// 值改变事件
        /// </summary>
        public event DValueChanged ValueChanged;
        /// <summary>
        /// 点击一下值的变化量
        /// </summary>
        private decimal _incremeent = 1;
        public decimal Incremeent
        {
            get { return _incremeent; }
            set { _incremeent = value; }
        }

        /// <summary>
        /// 小数位数
        /// </summary>
        private int _decimalPlaces = 0;
        public int DecimalPlaces
        {
            get { return _decimalPlaces; }
            set
            {
                _decimalPlaces = value;
                nud_value.DecimalPlaces = value;
            }
        }

        /// <summary>
        /// 最小值
        /// </summary>
        private decimal _minValue = 0;
        public decimal MinValue
        {
            get { return _minValue; }
            set
            {
                _minValue = value;
                nud_value.Minimum = value;
            }
        }

        /// <summary>
        /// 最大值
        /// </summary>
        private decimal _maxValue = 100;
        public decimal MaxValue
        {
            get { return _maxValue; }
            set
            {
                _maxValue = value;
                nud_value.Maximum = value;
            }
        }

        /// <summary>
        /// 值
        /// </summary>
        private double _value = 0;
        public double Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
                nud_value.Text = value.ToString();
            }
        }


        private void btn_add_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                btn_add.BringToFront();
                if (nud_value.Value < MaxValue)
                {
                    btn_add.FlatAppearance.MouseDownBackColor = Color.Gray;
                    btn_add.FlatAppearance.MouseOverBackColor = Color.DarkGray;
                    btn_add.Image = Resources.blueAdd;
                }
                else
                {
                    btn_add.FlatAppearance.MouseDownBackColor = Color.White;
                    btn_add.FlatAppearance.MouseOverBackColor = Color.White;
                }
            }
            catch { }
        }
        private void btn_add_MouseLeave(object sender, EventArgs e)
        {
            btn_add.Image = Resources.grayAdd;
        }
        private void btn_sub_MouseEnter(object sender, EventArgs e)
        {
            try
            {
                btn_sub.BringToFront();
                if (nud_value.Value >= MinValue)
                {
                    btn_sub.FlatAppearance.MouseDownBackColor = Color.Gray;
                    btn_sub.FlatAppearance.MouseOverBackColor = Color.DarkGray;
                    btn_sub.Image = Resources.blueSub;
                }
                else
                {
                    btn_sub.FlatAppearance.MouseDownBackColor = Color.White;
                    btn_sub.FlatAppearance.MouseOverBackColor = Color.White;
                }
            }
            catch { }
        }
        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                if (nud_value.Value + Incremeent <= MaxValue)
                    nud_value.Text = (nud_value.Value + Incremeent).ToString();

                if (nud_value.Value >= MaxValue)
                {
                    btn_add.FlatAppearance.MouseDownBackColor = Color.White;
                    btn_add.FlatAppearance.MouseOverBackColor = Color.White;
                    btn_add.Image = Resources.grayAdd;
                }
            }
            catch { }
        }
        private void btn_sub_Click(object sender, EventArgs e)
        {
            try
            {
                if (nud_value.Value + Incremeent > MinValue)
                    nud_value.Text = (nud_value.Value - Incremeent).ToString();

                if (nud_value.Value <= MinValue)
                {
                    btn_sub.FlatAppearance.MouseDownBackColor = Color.White;
                    btn_sub.FlatAppearance.MouseOverBackColor = Color.White;
                    btn_sub.Image = Resources.graySub;
                }
            }
            catch { }
        }
        private void nud_value_ValueChanged(object sender, EventArgs e)
        {
            Value = (double)nud_value.Value;
            if (ValueChanged != null)
                ValueChanged(Value);
        }
        private void UserControl1_Leave(object sender, EventArgs e)
        {
            lbl_line.Height = 1;
            lbl_line.BackColor = Color.Gray;
        }
        private void UserControl1_Enter(object sender, EventArgs e)
        {
            lbl_line.Height = 2;
            lbl_line.BackColor = Color.FromArgb(18, 150, 219);
        }
        private void btn_sub_MouseLeave(object sender, EventArgs e)
        {
            btn_sub.Image = Resources.graySub;
        }

    }
}
