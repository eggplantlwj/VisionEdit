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
    public delegate void DSelectedIndexChanged();
    public partial class CComboBox : UserControl
    {
        public CComboBox()
        {
            InitializeComponent();
            cbx_item.Items.AddRange(Items);
        }

        /// <summary>
        /// 选中项改变事件
        /// </summary>
        public event DSelectedIndexChanged SelectedIndexChanged;
        /// <summary>
        /// 选中项索引
        /// </summary>
        private int _selectedIndex = -1;
        public int SelectedIndex
        {
            get { return _selectedIndex; }
            set
            {
                _selectedIndex = value;
                cbx_item.SelectedIndex = value;
            }
        }
        /// <summary>
        /// 文本
        /// </summary>
        private string _text = string.Empty;
        public string TextStr
        {
            get { return _text; }
            set
            {
                _text = value;
                cbx_item.Text = value;
            }
        }
        /// <summary>
        /// 是否可以编辑
        /// </summary>
        private bool _canEdit = false;
        public bool CanEdit
        {
            get { return _canEdit; }
            set
            {
                _canEdit = value;
                if (value)
                    cbx_item.DropDownStyle = ComboBoxStyle.DropDown;
                else
                    cbx_item.DropDownStyle = ComboBoxStyle.DropDownList;
            }
        }
        /// <summary>
        /// 项
        /// </summary>
        private string[] _items = new string[] { };
        public string[] Items
        {
            get { return _items; }
            set
            {
                _items = value;
                cbx_item.Items.Clear();
                cbx_item.Items.AddRange(value);
            }
        }


        /// <summary>
        /// 删除所有项
        /// </summary>
        public void Clear()
        {
            Items = new string[] { };
            cbx_item.Items.Clear();
        }
        /// <summary>
        /// 添加项
        /// </summary>
        /// <param name="item">项</param>
        public void Add(string item)
        {
            string[] items = new string[Items.Length + 1];
            for (int i = 0; i < Items.Length; i++)
            {
                items[i] = Items[i];
            }
            items[Items.Length] = item;
            Items = items;
        }


        private void cbx_item_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedIndex = cbx_item.SelectedIndex;
            TextStr = cbx_item.Text;
            if (SelectedIndexChanged != null)
                SelectedIndexChanged();
        }
        private void ComboBox_Enter(object sender, EventArgs e)
        {
            lbl_line.Height = 2;
            lbl_line.BackColor = Color.FromArgb(18, 150, 219);
            btn_showItem.Image = Resources.BlueImage;
        }
        private void ComboBox_Leave(object sender, EventArgs e)
        {
            lbl_line.Height = 1;
            lbl_line.BackColor = Color.Gray;
            btn_showItem.Image = Resources.GrayImage;
        }
        private void btn_showItem_Click(object sender, EventArgs e)
        {
            cbx_item.DroppedDown = true;
        }

    }
}
