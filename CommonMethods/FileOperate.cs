/*
* ==============================================================================
*
* Filename: FileOperate
* Description: 
*
* Version: 1.0
* Created: 2021/2/26 16:59:16
*
* Author: liu.wenjie
*
* ==============================================================================
*/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonMethods
{
    public class FileTimeInfo
    {
        public string FileName;  //文件名
        public DateTime FileCreateTime; //创建时间
    }

    public class FileOperate
    {
        public static void DelFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
        /// <summary>
        /// 文件夹及其子目录的删除
        /// </summary>
        /// <param name="directoryPath"></param>
        public static void DeleteFolder(string directoryPath)
        {
            try
            {
                foreach (string d in Directory.GetFileSystemEntries(directoryPath))
                {
                    if (File.Exists(d))
                    {
                        FileInfo fi = new FileInfo(d);
                        if (fi.Attributes.ToString().IndexOf("ReadOnly") != -1)
                            fi.Attributes = FileAttributes.Normal;
                        File.Delete(d);
                    }
                    else
                        DeleteFolder(d);    // 递归删除
                }
                Directory.Delete(directoryPath);
            }
            catch (Exception)
            { }
        }



        public static FileTimeInfo GetLatestFileTimeInfo(string dir)
        {
            List<FileTimeInfo> list = new List<FileTimeInfo>();
            DirectoryInfo d = new DirectoryInfo(dir);
            foreach (DirectoryInfo fi in d.GetDirectories())
            {
                list.Add(new FileTimeInfo()
                {
                    FileName = fi.FullName,
                    FileCreateTime = fi.CreationTime
                });
            }
            var qry = from x in list
                      orderby x.FileCreateTime
                      select x;
            return qry.LastOrDefault();
        }

        /// <summary>
        /// 获取某目录下的所有文件(包括子目录下文件)的数量
        /// </summary>
        /// <param name="srcPath"></param>
        /// <returns></returns>
        public static int GetFileNum(string srcPath)
        {
            int fileNum = 0;
            try
            {
                string[] fileList = System.IO.Directory.GetFileSystemEntries(srcPath);
                foreach (string file in fileList)
                {
                    fileNum++;
                }
            }
            catch (Exception e)
            {

            }
            return fileNum;
        }
        public static void WriteFile(string filePath, string text)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(filePath, false, Encoding.UTF8))
                {
                    byte[] mybyte = Encoding.UTF8.GetBytes(text);
                    text = Encoding.UTF8.GetString(mybyte);
                    sw.Write(text);
                }
            }
            catch
            {

            }
        }
        public static string ReadFile(string filePath)
        {
            string readResult = string.Empty;
            try
            {
                if (File.Exists(filePath))
                {
                    using (StreamReader sr = new StreamReader(filePath, Encoding.UTF8))
                    {
                        readResult = sr.ReadToEnd();
                        byte[] mybyte = Encoding.UTF8.GetBytes(readResult);
                        readResult = Encoding.UTF8.GetString(mybyte);
                    }
                }
                return readResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
