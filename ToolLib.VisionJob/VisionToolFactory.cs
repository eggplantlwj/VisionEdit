using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CommonMethods;
using System.IO;

namespace VisionJobFactory
{

    public class VisionToolFactory
    {
        private static Dictionary<ToolType, Type> animalTypeDic = new Dictionary<ToolType, Type>();
        public static void InitVisionToolTypeDic()
        {
            animalTypeDic.Clear();

            //读取所有带有VisionToolAttribute的类
            var classEnumerator = new ClassEnumerator(typeof(VisionToolAttribute), null, typeof(VisionToolAttribute).Assembly);
            var em = classEnumerator.Results.GetEnumerator();

            while (em.MoveNext())
            {
                var classType = em.Current;
                var atts = classType.GetCustomAttributes(typeof(VisionToolAttribute), true);
                if (atts.Length > 0)
                {
                    var att = atts[0] as VisionToolAttribute;
                    if (null != att)
                    {
                        animalTypeDic.Add(att.ToolType, classType);
                    }
                }
            }
        }

        public static IToolInfo CreateToolVision(ToolType animalType, string toolName)
        {
            if (animalTypeDic.ContainsKey(animalType))
            {
                return (IToolInfo)Activator.CreateInstance(animalTypeDic[animalType], new object[] { toolName });
            }
            return null;
        }
        public static IToolInfo CreateToolVision(ToolType animalType)
        {
            if (animalTypeDic.ContainsKey(animalType))
            {
                return (IToolInfo)Activator.CreateInstance(animalTypeDic[animalType]);
            }
            return null;
        }
    }

   

    //根据Attribute提取类
    public class ClassEnumerator
    {
        protected List<Type> results = new List<Type>();

        public List<Type> Results
        {
            get
            {
                return results;
            }
        }

        private Type AttributeType;
        private Type InterfaceType;

        public ClassEnumerator(Type InAttributeType, Type InInterfaceType, Assembly InAssembly, bool bIgnoreAbstract = true, bool bInheritAttribute = false, bool bShouldCrossAssembly = true)
        {
            AttributeType = InAttributeType;
            InterfaceType = InInterfaceType;

            try
            {
                if (bShouldCrossAssembly)
                {


                    Assembly[] Assemblys = AppDomain.CurrentDomain.GetAssemblies();
                    if (Assemblys != null)
                    {
                        for (int i = 0, len = Assemblys.Length; i < len; i++)
                        {
                            CheckInAssembly(Assemblys[i], bIgnoreAbstract, bInheritAttribute);
                        }
                    }
                    //List<Assembly> allAssemblies = new List<Assembly>();
                    //string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                    //string[] FILES = Directory.GetFiles(path, "*.dll");
                    //foreach (string dll in Directory.GetFiles(path, "*.dll"))
                    //    allAssemblies.Add(Assembly.LoadFile(dll));


                    // 手动寻找该dll，若dll名称改变需要重新编译，不智能
                    // Assembly assem = Assembly.LoadFile($"{AppDomain.CurrentDomain.BaseDirectory}ToolLib.VisionToolList.dll");
                    //if (allAssemblies != null)
                    //{
                    //    for (int i = 0; i < allAssemblies.Count; i++)
                    //    {
                    //        CheckInAssembly(allAssemblies[i], bIgnoreAbstract, bInheritAttribute);
                    //    }
                    //}

                }
                else
                {
                    CheckInAssembly(InAssembly, bIgnoreAbstract, bInheritAttribute);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error in enumerate classes: " + e.Message);
            }
        }

        private void CheckInAssembly(Assembly InAssembly, bool bInIgnoreAbstract, bool bInInheritAttribute)
        {
            Type[] types = InAssembly.GetTypes();
            if (null == types)
            {
                return;
            }

            for (int i = 0, len = types.Length; i < len; i++)
            {
                var type = types[i];
                if (InterfaceType == null || InterfaceType.IsAssignableFrom(type))
                {
                    if (!bInIgnoreAbstract || (bInIgnoreAbstract && !type.IsAbstract))
                    {
                        if (type.GetCustomAttributes(AttributeType, bInInheritAttribute).Length > 0)
                        {
                            results.Add(type);
                        }
                    }
                }
            }
        }
    }
}
