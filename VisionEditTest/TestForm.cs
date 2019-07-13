using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static VisionEditTest.ToolInfo;

namespace VisionEditTest
{
    public partial class TestForm : Form
    {
        private static TestForm instance = null;
        public Job myJob = null;
        public TestForm()
        {
            InitializeComponent();
            instance = this;
            CheckForIllegalCrossThreadCalls = false;
        }
         
        public static TestForm GetInstance()
        {
            return instance;
        }

        private void btnAddTree_Click(object sender, EventArgs e)
        {
            //string path = @"E:\VM Pro_0.0.0.3\VM Pro_0.0.0.3\Resources\Sample\OCR.job";
            //IFormatter formatter = new BinaryFormatter();
            //Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None);
            //Job job = (Job)formatter.Deserialize(stream);
            //stream.Close();
            myJob = new Job();
            myJob.jobName = "test";

            myJob.tvw_job = new TreeView();
            
            myJob.tvw_job.Scrollable = true;
            
            myJob.tvw_job.ItemHeight = 26;
            myJob.tvw_job.ShowLines = false;
            myJob.tvw_job.AllowDrop = true;
            myJob.tvw_job.ImageList = Job.imageList;

            myJob.tvw_job.AfterSelect += myJob.tvw_job_AfterSelect;
            //tvw_job.AfterLabelEdit += new NodeLabelEditEventHandler(myJob.EditNodeText);
            //tvw_job.MouseClick += new MouseEventHandler(myJob.TVW_MouseClick);
            myJob.tvw_job.MouseDoubleClick += new MouseEventHandler(myJob.TVW_DoubleClick);

            //节点间拖拽
            myJob.tvw_job.ItemDrag += new ItemDragEventHandler(myJob.tvw_job_ItemDrag);
            myJob.tvw_job.DragEnter += new DragEventHandler(myJob.tvw_job_DragEnter);
            myJob.tvw_job.DragDrop += new DragEventHandler(myJob.tvw_job_DragDrop);

            //以下事件为画线事件
            myJob.tvw_job.MouseMove += myJob.DrawLineWithoutRefresh;
            myJob.tvw_job.AfterExpand += myJob.Draw_Line;
            myJob.tvw_job.AfterCollapse += myJob.Draw_Line;
            //   Frm_Job.Instance.tbc_jobs.SelectedIndexChanged += myJob.tbc_jobs_SelectedIndexChanged;

            myJob.tvw_job.Dock = DockStyle.Fill;
            myJob.tvw_job.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.TabPages.Add("test");
            this.tabControl1.TabPages[0].Controls.Add(myJob.tvw_job);
            //Frm_Job.Instance.tbc_jobs.TabPages.Add(jobName);
            //Frm_Job.Instance.tbc_jobs.TabPages[Frm_Job.Instance.tbc_jobs.TabPages.Count - 1].Controls.Add(tvw_job);
            //Frm_Job.Instance.tbc_jobs.SelectedIndex = Frm_Job.Instance.tbc_jobs.TabCount - 1;
            Application.DoEvents();
        }

        private void AddNode_Click(object sender, EventArgs e)
        {
            int insertPos = -1;
            ToolInfo toolInfo = new ToolInfo();
            TreeNode toolNode = new TreeNode();
            HalconInterfaceTool halconInterfaceTool = new HalconInterfaceTool();
            toolInfo.toolType = ToolType.HalconInterface;
            toolInfo.tool = halconInterfaceTool;
            toolInfo.toolName = "可输出工具";
           
            if (toolInfo.toolName == "Error")       //此工具添加个数已达到上限，不让继续添加
            {
                return;
            }
            if (insertPos == -1)
            {
                toolNode = myJob.tvw_job.Nodes.Add("", toolInfo.toolName, 1, 1);
                myJob.L_toolList.Add(toolInfo);
            }
            

            //添加必用项
            TreeNode itemNode = toolNode.Nodes.Add("","-->OutputImage", 26, 26);
            itemNode.ForeColor = Color.Blue;
            toolNode.ExpandAll();
            itemNode.Tag = DataType.Image;
            toolNode.ToolTipText = "it's tips";
            ToolIO outIO = new ToolIO();
            outIO.IOName = "outText";
            outIO.value = "i am output text";
            toolInfo.output.Add(outIO);
            
            //    myJob.output.Add(new ToolIO(Configuration.language == Language.English ? "OutputImage" : "输出图像", "", DataType.Image));
            myJob.tvw_job.ShowNodeToolTips = true;
        }

        private void AddInputNode_Click(object sender, EventArgs e)
        {
            int insertPos = -1;
            ToolInfo toolInfo = new ToolInfo();
            TreeNode toolNode = new TreeNode();
            ShapeMatchTool shapeMatchTool = new ShapeMatchTool();
            toolInfo.toolType = ToolType.ShapeMatch;
            toolInfo.tool = shapeMatchTool;
            toolInfo.toolName = "可输入工具";
            if (toolInfo.toolName == "Error")
            {
                return;
            }
            if (insertPos == -1)
            {
                toolNode = myJob.tvw_job.Nodes.Add("", toolInfo.toolName, 2, 2);
                myJob.L_toolList.Add(toolInfo);
            }


            //添加必用项
            TreeNode itemNode = toolNode.Nodes.Add("", "<--InputImage", 26, 26);
            itemNode.ForeColor = Color.DarkMagenta;
            toolNode.ExpandAll();
            itemNode.Tag = DataType.Image;
            shapeMatchTool.text = GetToolInfoByToolName("可输出工具").GetOutput("outText").value.ToString();
            
            // Job.GetToolInfoByToolName(jobName, Configuration.language == Language.English ? "HalconAcqInterface" : toolInfo.toolName).input.Add(new ToolIO(Configuration.language == Language.English ? "OutputImage" : "输入图像", "", DataType.Image));
        }

        /// <summary>
        /// 通过工具名获取工具信息
        /// </summary>
        /// <param name="toolName">工具名</param>
        /// <returns>工具信息</returns>
        internal ToolInfo GetToolInfoByToolName(string toolName)
        {
            try
            {
                
                for (int i = 0; i < myJob.L_toolList.Count; i++)
                {
                    if (myJob.L_toolList[i].toolName == toolName)
                    {
                        return myJob.L_toolList[i];
                    }
                }
                return new ToolInfo();
            }
            catch (Exception ex)
            {
                return new ToolInfo();
            }
        }

        
    }

    internal class HalconInterfaceTool
    {
    }
}
