using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommonMethods;
using HalconDotNet;
using ChoiceTech.Halcon.Control;
using ViewROI;

namespace HalconTool
{
    public partial class FormHalconTool : Form
    {
        public HalconTool myHalconTool = null;
        public IToolInfo myToolInfo = null;
        public HWindowTool_Smart myHwindow = new HWindowTool_Smart();
        public FormHalconTool(ref object halconTool)
        {
            InitializeComponent();
            // 若窗体还未被初始化，则此时仍是object类型，就无法对类型强转
            if (halconTool.GetType().FullName != "System.Object")
            {
                myToolInfo = (IToolInfo)halconTool;
                myHalconTool = (HalconTool)myToolInfo.tool;
            }
            _instance = this;
        }
        private static readonly object lockObkect = new object();
        private static FormHalconTool _instance;
        public static FormHalconTool Instance
        {
            get
            {
                if(_instance == null)
                {
                    lock (lockObkect)
                    {
                        if (_instance == null)
                        {
                            object halconTool = new object();
                            _instance = new FormHalconTool(ref halconTool);
                        }
                    }
                }
                return _instance;
            }
        }
        //private void rdo_readMultImage_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (rdo_readOneImage.Checked)
        //    {
        //        this.ckb_autoSwitch.Visible = false;
        //        this.panelOneImage.Visible = true;
        //        this.panelMultImage.Visible = false;
        //        this.btn_browseImage.Visible = false;
        //        myHalconTool.workMode = WorkMode.ReadOneImage;
        //        myHalconTool.outputImageFilePath = myHalconTool.imagePath;
        //    }
        //    else
        //    {
        //        if(myHalconTool.L_imageFile.Count > 0)
        //        {
        //            this.ckb_autoSwitch.Visible = true;
        //            this.panelMultImage.Visible = true;
        //            this.panelOneImage.Visible = false;
        //            this.btn_browseImage.Visible = true;
        //            myHalconTool.workMode = WorkMode.ReadMultImage;
        //            myHalconTool.outputImageFilePath = myHalconTool.L_imageFile[myHalconTool.currentImageIndex];
        //        } 
        //    }
        //    btn_runHalconInterfaceTool_Click(null, null);
        //}

        private void FormHalconTool_Load(object sender, EventArgs e)
        {
            gbImageDisp.Controls.Add(myHwindow);
            myHwindow.Dock = DockStyle.Fill;
            InitTool();
        }

        //private void btn_readImage_Click(object sender, EventArgs e)
        //{
        //    myHalconTool.ReadImage(out myHalconTool.imagePath);
        //    this.tbx_imagePath.Text = myHalconTool.imagePath;
        //    btn_runHalconInterfaceTool_Click(null, null);
        //}

        //private void btn_runHalconInterfaceTool_Click(object sender, EventArgs e)
        //{
        //    if(myHalconTool.workMode == WorkMode.ReadOneImage)
        //    {
               
        //    }
        //    if(myHalconTool.workMode == WorkMode.ReadMultImage)
        //    {
                
        //    }
        //    if (File.Exists(this.tbx_imagePath.Text))
        //    {
        //        myHalconTool.Run(SoftwareRunState.Debug);
        //        myHalconTool.imagePath = tbx_imagePath.Text;
        //        ParamsTrans();
        //    } 
        //}



        //private void btn_selectImageDirectory_Click(object sender, EventArgs e)
        //{
        //    myHalconTool.imageDirectoryPath = string.Empty;
        //    try
        //    {
        //        FolderBrowserDialog folderBrowseDialog = new FolderBrowserDialog();
        //        if (Directory.Exists(myHalconTool.imageDirectoryPath))
        //            folderBrowseDialog.SelectedPath = myHalconTool.imageDirectoryPath;
        //        folderBrowseDialog.Description = "请选择图像文件夹路径";
        //        if (folderBrowseDialog.ShowDialog() == DialogResult.OK)
        //        {
        //            myHalconTool.imageDirectoryPath = folderBrowseDialog.SelectedPath;
        //            this.tbx_imageDirectory.Text = myHalconTool.imageDirectoryPath;
        //            myHalconTool.L_imageFile.Clear();
        //            string[] files = Directory.GetFiles(folderBrowseDialog.SelectedPath);
        //            for (int i = 0; i < files.Length; i++)
        //            {
        //                FileInfo fileInfo = new FileInfo(files[i]);
        //                if (fileInfo.Extension == ".jpg" || fileInfo.Extension == ".bmp" || fileInfo.Extension == ".png" || fileInfo.Extension == ".tif")
        //                    myHalconTool.L_imageFile.Add(files[i]);
        //            }
        //            if (myHalconTool.L_imageFile.Count > 0)
        //            {
        //                myHalconTool.currentImageIndex = 0;
        //                myHalconTool.outputImageFilePath = myHalconTool.L_imageFile[myHalconTool.currentImageIndex];
        //                myHalconTool.DispImage();
        //                myHalconTool.currentImageName = Path.GetFileName(myHalconTool.L_imageFile[0]);
        //                lbl_imageName.Text = myHalconTool.currentImageName;

        //            }
        //            lbl_imageNum.Text = "共" + myHalconTool.L_imageFile.Count + "张";

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        this.lb_RunStatus.Text = ex.Message;
        //    }
        //}

        //private void btn_nextImage_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        HObject image = new HObject();
        //        Button btnClick = sender as Button;
        //        if(btnClick.Name == "btn_nextImage")
        //        {
        //            myHalconTool.currentImageIndex = myHalconTool.currentImageIndex + 1;
        //        }
        //        else
        //        {
        //            myHalconTool.currentImageIndex = myHalconTool.currentImageIndex - 1;
        //        }

        //        if (myHalconTool.currentImageIndex > myHalconTool.L_imageFile.Count - 1)
        //        {
        //            myHalconTool.currentImageIndex = 0;
        //        }
        //        try
        //        {
        //            myHalconTool.outputImageFilePath = myHalconTool.L_imageFile[myHalconTool.currentImageIndex];
        //        }
        //        catch
        //        {
        //            lb_RunStatus.Text = "图像文件异常或路径不合法";
        //            lb_RunStatus.BackColor = Color.Red;
        //            return;
        //        }
        //        myHalconTool.DispImage();
        //        myHalconTool.currentImageName = Path.GetFileName(myHalconTool.L_imageFile[myHalconTool.currentImageIndex]);
        //        Instance.lbl_imageName.Text = myHalconTool.currentImageName;
        //        Instance.lbl_imageNum.Text = "共" + myHalconTool.L_imageFile.Count + "张";
        //    }
        //    catch (Exception ex)
        //    {
        //        lb_RunStatus.Text = ex.Message;
        //        lb_RunStatus.BackColor = Color.Red;
        //    }
        //}

        // 窗体载入时还原参数
        public void InitTool()
        {
            txbFilePath.Text = myHalconTool.imagePath;
            chbRGB2Gray.Checked = myHalconTool.RGBToGray;
        }
        /// <summary>
        /// 将数据传递给HalconToolInterface
        /// </summary>
        private void ParamsTrans()
        {
            myToolInfo.toolOutput[0] = new ToolIO("OutputImage", myHalconTool.outputImage, DataType.Image);
        }

        private void btnSelectFilePath_Click(object sender, EventArgs e)
        {
            HTuple channelCount = 0;
            OpenFileDialog dig_openImage = new OpenFileDialog();
            dig_openImage.Title = "请选择图像文件路径";
            dig_openImage.Filter = "图像文件(*.*)|*.*|图像文件(*.png)|*.png|图像文件(*.jpg)|*.jpg|图像文件(*.tif)|*.tif";
            if (dig_openImage.ShowDialog() == DialogResult.OK)
            {
                myHalconTool.imagePath = dig_openImage.FileName;
                myHalconTool.outputImageFilePath = dig_openImage.FileName;
                txbFilePath.Text = dig_openImage.FileName;
            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            if (File.Exists(txbFilePath.Text))
            {
                myHalconTool.outputImageFilePath = txbFilePath.Text;
                myHalconTool.imagePath = txbFilePath.Text;
                myHalconTool.Run(SoftwareRunState.Debug);
                ParamsTrans();
            }
            else
            {
                MessageBox.Show("文件不存在，请检查！");
            }
        }

        private void txbFilePath_TextChanged(object sender, EventArgs e)
        {
            myHalconTool.outputImageFilePath = txbFilePath.Text;
            myHalconTool.imagePath = txbFilePath.Text;
        }

        private void chbRGB2Gray_CheckedChanged(object sender, EventArgs e)
        {
            myHalconTool.RGBToGray = chbRGB2Gray.Checked;
        }
    }
}
