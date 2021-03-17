using System;
using System.Drawing;
using System.Windows.Forms;
using Logger;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;

namespace LogForm
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
            if (e.Index < 0)
            { return; }
            else
            {
                e.DrawBackground();
                Brush mybsh = Brushes.Black;
                // 判断是什么类型的标签,在调用时必须信息前边标注信息的类别，分为Info，Warning，Error
                try
                {
                    MsgLevel msgLevel = (MsgLevel)Enum.Parse(typeof(MsgLevel), listBox1.Items[e.Index].ToString().Split('>')[1].Trim().Split(',')[0]);
                    switch (msgLevel)
                    {
                        case MsgLevel.Info:
                            mybsh = Brushes.Green;
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
                e.Graphics.DrawString(listBox1.Items[e.Index].ToString(), e.Font, mybsh, e.Bounds, StringFormat.GenericDefault);
            }
        }


        public void AddLog(MsgLevel msgLog, string logInfo)
        {
            try
            {
                this.Invoke((MethodInvoker)delegate
                {
                    string recordMsg = $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} -> {msgLog.ToString()}, {logInfo}";
                    listBox1.Items.Add(recordMsg);
                    WriteLog(recordMsg);
                    listBox1.SelectedIndex = listBox1.Items.Count - 1;
                    if (listBox1.Items.Count > 1000)
                    {
                        listBox1.Items.Clear();
                    }
                    Application.DoEvents();
                });
            }
            catch(Exception)
            {
                
            }
        }
        public void AddLog(MsgLevel msgLog, string logInfo, Exception ex)
        {
            try
            {
                this.Invoke((MethodInvoker)delegate
                {
                    listBox1.Items.Add(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " -> " + msgLog.ToString() + "," + logInfo + ex);
                    listBox1.SelectedIndex = listBox1.Items.Count - 1;
                    WriteLog(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " -> " + msgLog.ToString() + "," + logInfo + ex);
                    if(listBox1.Items.Count >1000)
                    {
                        listBox1.Items.Clear();
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
        private void UserLogger_Load(object sender, EventArgs e)
        {
            Task startLogFocus = new Task(() =>
            {
                while (logFocus)
                {
                    if (LoggerClass.logQueue.Count > 0)
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
            });
            startLogFocus.Start();
        }

        private void ClearLog_Click(object sender, EventArgs e)
        {
            this.listBox1.Items.Clear();
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(listBox1.SelectedIndex != -1)
            {
                string detalText = listBox1.SelectedItem.ToString();
                DetailMesForm myForm = new DetailMesForm(detalText);
                myForm.Show();
            }
        }
    }
}
