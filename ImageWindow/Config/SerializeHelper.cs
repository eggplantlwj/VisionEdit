using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
//using System.Runtime.Serialization.Json;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Formatters.Binary;

namespace ViewWindow.Config
{
    public class SerializeHelper
    {
        public SerializeHelper()
        { }

        #region XML序列化
        /// <summary>
        /// 文件化XML序列化
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="filename">文件路径</param>
        public static void Save(object obj, string filename)
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream(filename, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
                XmlSerializer serializer = new XmlSerializer(obj.GetType());
                serializer.Serialize(fs, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (fs != null) fs.Close();
            }
        }

        /// <summary>
        /// 文件化XML反序列化
        /// </summary>
        /// <param name="type">对象类型</param>
        /// <param name="filename">文件路径</param>
        public static object Load(Type type, string filename)
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                XmlSerializer serializer = new XmlSerializer(type);
                return serializer.Deserialize(fs);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (fs != null) fs.Close();
            }
        }

        /// <summary>
        /// 文本化XML序列化
        /// </summary>
        /// <param name="item">对象</param>
        public string ToXml<T>(T item)
        {
            XmlSerializer serializer = new XmlSerializer(item.GetType());
            StringBuilder sb = new StringBuilder();
            using (XmlWriter writer = XmlWriter.Create(sb))
            {
                serializer.Serialize(writer, item);
                return sb.ToString();
            }
        }

        /// <summary>
        /// 文本化XML反序列化
        /// </summary>
        /// <param name="str">字符串序列</param>
        public T FromXml<T>(string str)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (XmlReader reader = new XmlTextReader(new StringReader(str)))
            {
                return (T)serializer.Deserialize(reader);
            }
        }
        #endregion

        #region Json序列化
        /// <summary>
        /// JsonSerializer序列化
        /// </summary>
        /// <param name="item">对象</param>
        //public string ToJson<T>(T item)
        //{
        //    DataContractJsonSerializer serializer = new DataContractJsonSerializer(item.GetType());
        //    using (MemoryStream ms = new MemoryStream())
        //    {
        //        serializer.WriteObject(ms, item);
        //        return Encoding.UTF8.GetString(ms.ToArray());
        //    }
        //}

        ///// <summary>
        ///// JsonSerializer反序列化
        ///// </summary>
        ///// <param name="str">字符串序列</param>
        //public T FromJson<T>(string str) where T : class
        //{
        //    DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
        //    using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(str)))
        //    {
        //        return serializer.ReadObject(ms) as T;
        //    }
        //}
        #endregion

        #region SoapFormatter序列化
        /// <summary>
        /// SoapFormatter序列化
        /// </summary>
        /// <param name="item">对象</param>
        public string ToSoap<T>(T item)
        {
            SoapFormatter formatter = new SoapFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                formatter.Serialize(ms, item);
                ms.Position = 0;
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(ms);
                return xmlDoc.InnerXml;
            }
        }

        /// <summary>
        /// SoapFormatter反序列化
        /// </summary>
        /// <param name="str">字符串序列</param>
        public T FromSoap<T>(string str)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(str);
            SoapFormatter formatter = new SoapFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                xmlDoc.Save(ms);
                ms.Position = 0;
                return (T)formatter.Deserialize(ms);
            }
        }
        #endregion

        #region BinaryFormatter序列化
        /// <summary>
        /// BinaryFormatter序列化
        /// </summary>
        /// <param name="item">对象</param>
        public string ToBinary<T>(T item)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                formatter.Serialize(ms, item);
                ms.Position = 0;
                byte[] bytes = ms.ToArray();
                StringBuilder sb = new StringBuilder();
                foreach (byte bt in bytes)
                {
                    sb.Append(string.Format("{0:X2}", bt));
                }
                return sb.ToString();
            }
        }

        /// <summary>
        /// BinaryFormatter反序列化
        /// </summary>
        /// <param name="str">字符串序列</param>
        public T FromBinary<T>(string str)
        {
            int intLen = str.Length / 2;
            byte[] bytes = new byte[intLen];
            for (int i = 0; i < intLen; i++)
            {
                int ibyte = Convert.ToInt32(str.Substring(i * 2, 2), 16);
                bytes[i] = (byte)ibyte;
            }
            BinaryFormatter formatter = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                return (T)formatter.Deserialize(ms);
            }
        }
        #endregion

        /// <summary>
        /// 获取对象序列化的二进制版本
        /// </summary>
        /// <param name="pObj">对象实体</param>
        /// <returns>如果对象实体为Null，则返回结果为Null。</returns>
        public static byte[] GetBytes(object pObj)
        {
            if (pObj == null) { return null; }
            MemoryStream serializationStream = new MemoryStream();
            new BinaryFormatter().Serialize(serializationStream, pObj);
            serializationStream.Position = 0L;
            byte[] buffer = new byte[serializationStream.Length];
            serializationStream.Read(buffer, 0, buffer.Length);
            serializationStream.Close();
            return buffer;
        }

        /// <summary>
        /// 获取对象序列化的XmlDocument版本
        /// </summary>
        /// <param name="pObj">对象实体</param>
        /// <returns>如果对象实体为Null，则返回结果为Null。</returns>
        public static XmlDocument GetXmlDoc(object pObj)
        {
            if (pObj == null) { return null; }
            XmlSerializer serializer = new XmlSerializer(pObj.GetType());
            StringBuilder sb = new StringBuilder();
            StringWriter writer = new StringWriter(sb);
            serializer.Serialize((TextWriter)writer, pObj);
            XmlDocument document = new XmlDocument();
            document.LoadXml(sb.ToString());
            writer.Close();
            return document;
        }

        /// <summary>
        /// 从已序列化数据中(byte[])获取对象实体
        /// </summary>
        /// <typeparam name="T">要返回的数据类型</typeparam>
        /// <param name="binData">二进制数据</param>
        /// <returns>对象实体</returns>
        public static T GetObject<T>(byte[] binData)
        {
            if (binData == null) { return default(T); }
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream serializationStream = new MemoryStream(binData);
            return (T)formatter.Deserialize(serializationStream);
        }

        /// <summary>
        /// 从已序列化数据(XmlDocument)中获取对象实体
        /// </summary>
        /// <typeparam name="T">要返回的数据类型</typeparam>
        /// <param name="xmlDoc">已序列化的文档对象</param>
        /// <returns>对象实体</returns>
        public static T GetObject<T>(XmlDocument xmlDoc)
        {
            if (xmlDoc == null) { return default(T); }
            XmlNodeReader xmlReader = new XmlNodeReader(xmlDoc.DocumentElement);
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            return (T)serializer.Deserialize(xmlReader);
        }
    }
}