using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HalconDotNet;
using System.Diagnostics;

namespace ViewROI
{
    public partial class HWindowTool_Smart : UserControl
    {
        public bool DispStatus { get; set; }
        public HImage hv_Image { get; set; }
        HTuple hv_Width = new HTuple();
        HTuple hv_Height = new HTuple();
        public HWindow DispHWindow
        {
            get
            {
                return this.SmartWindow.HalconWindow;
            }
        }
        public HWindowTool_Smart()
        {
            InitializeComponent();
        }
        public void DispImage(HObject inputImage)
        {
            if (inputImage == null || !inputImage.IsInitialized())
            {
                return;
            }

            
            #region 缩放图像，适应窗口
            //获取图像大小及纵横比
            HOperatorSet.GetImageSize(inputImage, out hv_Width, out hv_Height);
            int im_width = int.Parse(hv_Width.ToString());
            int im_height = int.Parse(hv_Height.ToString());
            double im_AspectRatio = (double)(im_width) / (double)(im_height);
            //获取窗口大小及纵横比
            int w_width = SmartWindow.Size.Width;
            int w_height = SmartWindow.Size.Height;
            double w_AspectRatio = (double)(w_width) / (double)(w_height);

            HOperatorSet.SetSystem("int_zooming", "false");//图像缩放之前最好将此参数设置为false.
            HTuple para = new HTuple("constant");
            HObject ho_zoomImage;
            HOperatorSet.GenEmptyObj(out ho_zoomImage);

            ho_zoomImage.Dispose();
            if (w_width < im_width && im_AspectRatio > w_AspectRatio)
            {
                //超宽图像
                HOperatorSet.ZoomImageSize(inputImage, out ho_zoomImage, w_width, w_width / im_AspectRatio, para);
            }
            else if (w_height < im_height && im_AspectRatio < w_AspectRatio)
            {
                //超高图像
                HOperatorSet.ZoomImageSize(inputImage, out ho_zoomImage, w_height * im_AspectRatio, w_height, para);
            }
            #endregion
            SmartWindow.HalconWindow.SetPart(0, 0,-2, -2);
            hv_Image = new HImage(inputImage);
            SmartWindow.HalconWindow.DispImage(hv_Image);
            ho_zoomImage.Dispose();
            hv_Width.Dispose();
            hv_Height.Dispose();
        }

        private void SmartWindow_HMouseMove(object sender, HalconDotNet.HMouseEventArgs e)
        {
           // this.Cursor = e.Button == MouseButtons.Left ? Cursors.Hand : Cursors.Default;
            if(DispStatus)
            {
                if (hv_Image != null && hv_Image.IsInitialized())
                {
                    try
                    {
                        double positionX, positionY;
                        string str_value;
                        string str_position;
                        bool _isXOut = true, _isYOut = true;
                        HTuple channel_count;
                        HOperatorSet.CountChannels(hv_Image, out channel_count);
                        //SmartWindow.HalconWindow.GetMpositionSubPix(out positionY, out positionX, out button_state);
                        positionY = e.Y;
                        positionX = e.X;
                        str_position = String.Format("RC: {0:0},{1:0}", positionY, positionX);

                        _isXOut = (positionX < 0 || positionX >= hv_Width);
                        _isYOut = (positionY < 0 || positionY >= hv_Height);

                        if (!_isXOut && !_isYOut)
                        {
                            if ((int)channel_count == 1)
                            {
                                double grayVal;
                                grayVal = hv_Image.GetGrayval((int)positionY, (int)positionX);
                                str_value = String.Format("Val: {0:000}", grayVal);
                            }
                            else if ((int)channel_count == 3)
                            {
                                double grayValRed, grayValGreen, grayValBlue;

                                HImage _RedChannel, _GreenChannel, _BlueChannel;

                                _RedChannel = hv_Image.AccessChannel(1);
                                _GreenChannel = hv_Image.AccessChannel(2);
                                _BlueChannel = hv_Image.AccessChannel(3);

                                grayValRed = _RedChannel.GetGrayval((int)positionY, (int)positionX);
                                grayValGreen = _GreenChannel.GetGrayval((int)positionY, (int)positionX);
                                grayValBlue = _BlueChannel.GetGrayval((int)positionY, (int)positionX);

                                _RedChannel.Dispose();
                                _GreenChannel.Dispose();
                                _BlueChannel.Dispose();

                                str_value = String.Format("Gray: ({0:000}, {1:000}, {2:000})", grayValRed, grayValGreen, grayValBlue);
                            }
                            else
                            {
                                str_value = "";
                            }
                            grayValueLable.Text = $"Ch{channel_count.D }, {str_position}:   {str_value}";
                        }
                    }
                    catch (Exception ex)
                    {
                        //不处理
                    }
                }
            }
        }

        private void HWindowTool_Smart_Load(object sender, EventArgs e)
        {
            this.MouseWheel += HWindowTool_Smart_MouseWheel;
        }

        private void HWindowTool_Smart_MouseWheel(object sender, MouseEventArgs e)
        {
            Point pt = SmartWindow.Location;
            MouseEventArgs newe = new MouseEventArgs(e.Button, e.Clicks, e.X - pt.X, e.Y - pt.Y, e.Delta);
            SmartWindow.HSmartWindowControl_MouseWheel(sender, newe);
        }

        private void HWindowTool_Smart_SizeChanged(object sender, EventArgs e)
        {
            //Point pt = SmartWindow.Location;
            //Point pt2 = SmartWindow.PointToScreen(pt);
            //this.SmartWindow.HalconWindow.SendMouseDoubleClickEvent(pt2.X+20, pt2.Y+30,(int)MouseButtons.Left);
        }

        private void tsmiDispCorr_Click(object sender, EventArgs e)
        {
            if(tsmiDispCorr.Checked)
            {
                tsmiDispCorr.Checked = false;
                DispStatus = false;
                grayValueLable.Visible = false;
            }
            else
            {
                tsmiDispCorr.Checked = true;
                DispStatus = true;
                grayValueLable.Visible = true;
            }
        }
    }
}
