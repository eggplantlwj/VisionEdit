/*
* ==============================================================================
*
* Filename: Serial
* Description: 
*
* Version: 1.0
* Created: 2021/2/25 17:24:56
*
* Author: liu.wenjie
*
* ==============================================================================
*/
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CommonMethods
{
    public class Serialize
    {
        public static void XmlSerialize<T>(string objname, T obj)
        {

            try
            {
                string filename = objname + ".xml";
                if (System.IO.File.Exists(filename))
                    System.IO.File.Delete(filename);
                using (FileStream fileStream = new FileStream(filename, FileMode.Create))
                {
                    // 序列化为xml
                    XmlSerializer formatter = new XmlSerializer(typeof(T));
                    formatter.Serialize(fileStream, obj);
                    fileStream.Close();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        public static T XmlDeserailize<T>(string objname)
        {
            // System.Runtime.Serialization.IFormatter formatter = new XmlSerializer(typeof(Car));
            string filename = objname + ".xml";
            T obj;
            if (!System.IO.File.Exists(filename))
                throw new Exception("对反序列化之前,请先序列化");
            //Xml格式反序列化
            using (Stream stream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                XmlSerializer formatter = new XmlSerializer(typeof(T));
                obj = (T)formatter.Deserialize(stream);
                stream.Close();
            }
            return obj;
        }

        public static void BinarySerialize<T>(string filename, T obj)
        {
            try
            {
                //string filename = objname + ".ump";
                if (System.IO.File.Exists(filename))
                    System.IO.File.Delete(filename);
                using (FileStream fileStream = new FileStream(filename, FileMode.Create))
                {
                    // 用二进制格式序列化
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    binaryFormatter.Serialize(fileStream, obj);
                    fileStream.Close();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }


        public static T BinaryDeserialize<T>(string filename)
        {
            System.Runtime.Serialization.IFormatter formatter = new BinaryFormatter();
            //二进制格式反序列化
            T obj;
            //string filename = objname + ".ump";
            if (!System.IO.File.Exists(filename))
                throw new Exception("在反序列化之前,请先序列化");
            using (Stream stream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                obj = (T)formatter.Deserialize(stream);
                stream.Close();
            }
            return obj;

        }
        /// <summary>
        /// 把对象序列化并返回相应的字节
        /// </summary>
        /// <param name="pObj">需要序列化的对象</param>
        /// <returns>byte[]</returns>
        public static byte[] SerializeObject(object pObj)
        {
            if (pObj == null)
                return null;
            System.IO.MemoryStream _memory = new System.IO.MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(_memory, pObj);
            _memory.Position = 0;
            byte[] read = new byte[_memory.Length];
            _memory.Read(read, 0, read.Length);
            _memory.Close();
            return read;
        }


        /// <summary>
        /// 把字节反序列化成相应的对象
        /// </summary>
        /// <param name="pBytes">字节流</param>
        /// <returns>object</returns>
        public static object DeserializeObject(byte[] pBytes)
        {
            object _newOjb = null;
            if (pBytes == null)
                return _newOjb;
            System.IO.MemoryStream _memory = new System.IO.MemoryStream(pBytes);
            _memory.Position = 0;
            BinaryFormatter formatter = new BinaryFormatter();
            _newOjb = formatter.Deserialize(_memory);
            _memory.Close();
            return _newOjb;
        }
        public static void JsonSerialize<T>(T obj, string filePath)
        {
            string resultJson = JsonConvert.SerializeObject(obj, Formatting.Indented);
            FileInfo fi = new FileInfo(filePath);
            if (!fi.Directory.Exists)
            {
                Directory.CreateDirectory(fi.Directory.FullName);
            }
            FileOperate.WriteFile(filePath, resultJson);
        }

        public static T JsonDeserializeObject<T>(string jsonString)
        {
            T obj;
            try
            {
                obj = JsonConvert.DeserializeObject<T>(FileOperate.ReadFile(jsonString));
                return obj;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
