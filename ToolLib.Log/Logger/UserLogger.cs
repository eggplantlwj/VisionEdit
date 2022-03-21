using System;
using System.Drawing;
using System.Windows.Forms;
using Logger;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;

namespace Logger
{
    public partial class UserLogger : UserControl
    {
        bool logFocus = true;
        string logDictory = @"C:\MyCCDSystem\Log\";
        public UserLogger()
        {
            InitializeComponent();
        }
        ~UserLogger()
        {
            logFocus = false;
        }

        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            ListBox seelctBox = sender as ListBox;
            if (e.Index < 0)
            { return; }
            else
            {
                e.DrawBackground();
                Brush mybsh = Brushes.Black;
                // 判断是什么类型的标签,在调用时必须信息前边标注信息的类别，分为Info，Warning，Error
                try
                {
                    MsgLevel msgLevel = (MsgLevel)Enum.Parse(typeof(MsgLevel), seelctBox.Items[e.Index].ToString().Split('>')[1].Trim().Split(',')[0]);
                    switch (msgLevel)
                    {
                        case MsgLevel.Info:
                            mybsh = Brushes.Black;
                            break;
                        case MsgLevel.Debug:
                            mybsh = Brushes.Green;
                            break;
                        case MsgLevel.Warn:
                            mybsh = Brushes.Purple;
                            break;
                        case MsgLevel.Exception:
                        case MsgLevel.Fatal:
                            mybsh = Brushes.Red;
                            break;
                        default:
                            mybsh = Brushes.Black;
                            break;
                    }
                }
                catch (Exception)
                {
                    mybsh = Brushes.Green;
                }
                e.DrawFocusRectangle();
                e.Graphics.DrawString(seelctBox.Items[e.Index].ToString(), e.Font, mybsh, e.Bounds, StringFormat.GenericDefault);
            }
        }


        public void AddLog(MsgLevel msgLog, string logInfo)
        {
            try
            {
                WriteLog(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss-fff") + " -> " + msgLog.ToString() + "," + logInfo);
                this.Invoke((MethodInvoker)delegate
                {
                    switch (msgLog)
                    {
                        case MsgLevel.Debug:
                            ControlListBox(msgLog, logInfo, listBoxDebug);
                            break;
                        case MsgLevel.Info:
                            ControlListBox(msgLog, logInfo, listBoxInfo);
                            break;
                        case MsgLevel.Warn:
                            ControlListBox(msgLog, logInfo, listBoxWarn);
                            break;
                        case MsgLevel.Exception:
                        case MsgLevel.Fatal:
                            ControlListBox(msgLog, logInfo, listBoxExpection);
                            break;
                        default:
                            break;
                    }
                    listBoxAll.Items.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss-fff") + " -> " + msgLog.ToString() + "," + logInfo);
                    listBoxAll.SelectedIndex = listBoxAll.Items.Count - 1;
                    if (listBoxAll.Items.Count > 1000)
                    {
                        listBoxAll.Items.Clear();
                    }
                    Application.DoEvents();
                });
            }
            catch(Exception)
            {
                
            }
        }

        private void ControlListBox(MsgLevel msgLog, string logInfo,ListBox myListBox)
        {
            myListBox.Items.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss-fff") + " -> " + msgLog.ToString() + "," + logInfo);
            myListBox.SelectedIndex = myListBox.Items.Count - 1;
            if (myListBox.Items.Count > 1000)
            {
                myListBox.Items.Clear();
            }
        }

        public void AddLog(MsgLevel msgLog, string logInfo, Exception ex)
        {
            try
            {
                WriteLog(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " -> " + msgLog.ToString() + "," + logInfo + ex);
                this.Invoke((MethodInvoker)delegate
                {
                    switch (msgLog)
                    {
                        case MsgLevel.Debug:
                            ControlListBox(msgLog, logInfo, listBoxDebug);
                            break;
                        case MsgLevel.Info:
                            ControlListBox(msgLog, logInfo, listBoxInfo);
                            break;
                        case MsgLevel.Warn:
                            ControlListBox(msgLog, logInfo, listBoxWarn);
                            break;
                        case MsgLevel.Exception:
                        case MsgLevel.Fatal:
                            ControlListBox(msgLog, logInfo, listBoxExpection);
                            break;
                        default:
                            break;
                    }
                    listBoxAll.Items.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " -> " + msgLog.ToString() + "," + logInfo + ex);
                    listBoxAll.SelectedIndex = listBoxAll.Items.Count - 1;
                    if(listBoxAll.Items.Count >1000)
                    {
                        listBoxAll.Items.Clear();
                    }
                    Application.DoEvents();
                });
            }
            catch (Exception)
            {
                
            }
        }
        public void WriteLog(string msg)
        {
            string time = DateTime.Now.ToString("HH:mm:ss.fff");
            if (!Directory.Exists(logDictory))
            {
                Directory.CreateDirectory(logDictory);
            }
            string runningLogFileName = logDictory + DateTime.Now.ToString("yyyyMMdd") + ".log";
            StreamWriter mySW = new StreamWriter(runningLogFileName, true);
            mySW.WriteLine(msg);
            mySW.Close();
        }
        object myObject = new object();
        private void UserLogger_Load(object sender, EventArgs e)
        {
            Task startLogFocus = new Task(() =>
            {
                while (logFocus)
                {
                    if (LoggerClass.logQueue.Count > 0)
                    {
                        lock(myObject)
                        { 
                            LogInfo log = LoggerClass.logQueue.Dequeue();
                            if (log.ex != null)
                            {
                                AddLog(log.logLevel, log.message, log.ex);
                            }
                            else
                            {
                                AddLog(log.logLevel, log.message);
                            }
                        }
                    }
                }
            });
            startLogFocus.Start();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                switch (tabControl1.SelectedIndex)
                {
                    case 0:
                        listBoxAll.Items.Clear();
                        break;
                    case 1:
                        listBoxInfo.Items.Clear();
                        break;
                    case 2:
                        listBoxDebug.Items.Clear();
                        break;
                    case 3:
                        listBoxWarn.Items.Clear();
                        break;
                    case 4:
                        listBoxExpection.Items.Clear();
                        break;
                    default:
                        break;
                }
                
            }
            catch
            {
            }
           
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            ListBox mySelectBox = sender as ListBox;
            if (mySelectBox.SelectedItem != null)
            {
                string selectInfo = mySelectBox.SelectedItem.ToString();
                LogDetail myLogDetail = new LogDetail(selectInfo);
                myLogDetail.Show();
            }
              
        }
    }

    public enum MsgLevel
    {
        /// <summary>
        /// 0.调试信息输出
        /// </summary>
        Debug = 0,
        /// <summary>
        /// 1.业务信息记录
        /// </summary>
        Info = 1,
        /// <summary>
        /// 2.警告提醒（捕获的业务异常）
        /// </summary>
        Warn = 2,
        /// <summary>
        /// 3.发生了异常（捕获的系统异常）
        /// </summary>
        Exception = 3,
        /// <summary>
        /// 4.发生致命异常（未被捕获的异常|捕获的业务逻辑异常）
        /// </summary>
        Fatal = 4
    }
}
