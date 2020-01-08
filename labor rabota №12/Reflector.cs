using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

namespace labor_rabota__12
{
    public static class Reflector<T>
    {
        public static void ClassInfo()
        {
            File.Delete("ClassInfo.txt");
            foreach (var item in typeof(T).GetMembers())
            {
                Console.WriteLine(item);
                File.AppendAllText("ClassInfo.txt", item.ToString() + "\n");
            }

        }

        public static void MethodsInfo()
        {
            foreach (MethodInfo item in typeof(T).GetMethods())
            {
                Console.WriteLine(item);
            }
        }

        public static void FieldsandPropertiesInfo()
        {
            int countPr = 0;
            int countFi = 0;
            Console.WriteLine("Properties info: ");
            foreach (var item in typeof(T).GetProperties())
            {
                Console.WriteLine(item);
                countPr++;
            }
            if (countPr == 0) Console.WriteLine("В данном классе свойств не обнаружено\n");
            Console.WriteLine("Fields info: ");
            foreach (var item in typeof(T).GetFields())
            {
                Console.WriteLine(item);
                countFi++;
            }
            if (countFi == 0) Console.WriteLine("В данном классе полей не обнаружено");
        }

        public static void InterfaceInfo()
        {
            Console.WriteLine("Реализуемые интерфейсы в данном классе: ");
            foreach (var item in typeof(T).GetInterfaces())
            {
                Console.WriteLine(item);
            }
        }

        public static void MethodInfo()
        {
           MethodInfo mInfo = typeof(T).GetMethod("Constructor" ,
    BindingFlags.Public | BindingFlags.Instance |BindingFlags.Static,
    null,
    CallingConventions.Any,
    new Type[] { typeof(string)},
    null);
            Console.WriteLine("Found method: {0}", mInfo);
        }

        public static int InMethod()
        {
            int x=0;
            StreamReader readX = new StreamReader("arg.txt");
            if (countXY == 3) countXY = 1;
            for (int i = 0; i < countXY; i++)
            {
                 x = Convert.ToInt32(readX.ReadLine());
            }
            countXY++;
            
            return x;
        }
        public static int countXY = 1;

    }
}
