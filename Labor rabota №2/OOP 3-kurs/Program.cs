using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_3_kurs
{
    class Program
    {
        static void Main(string[] args)
        {
            //Лабораторная работа №2
            /*1)	Типы
a.	Определите переменные всех возможных примитивных типов С#  и проинициализируйте их.  
b.	Выполните 5 операций явного и 5 неявного приведения.
c.	Выполните упаковку и распаковку значимых типов.
d.	Продемонстрируйте работу с неявно типизированной переменной.
e.	Продемонстрируйте пример работы с Nullable переменной.
 */

            //a) Определите переменные всех возможных примитивных типов С#  и проинициализируйте их.
            int varInt; varInt = -42;
            uint varUint = 553;
            long varLong; varLong = -3211;
            ulong varUlong = 4454;
            short varShort; varShort = 51;
            ushort varUshort = 2525;
            double varDouble; varDouble = 41.234;
            float varFloat; varFloat = 23.13f;
            string varString; varString = "Пример строки";
            char varChar; varChar = 'a';
            decimal varDecimal; varDecimal = 12.32M;
            bool varBool; varBool = true;
            byte varByte; varByte = 120;
            sbyte varSbyte; varSbyte = 11;

            // b.Выполните 5 операций явного и 5 неявного приведения.

            int o1 = varShort;
            short o2 = varByte;
            double o3 = varFloat;
            long o4 = varInt;
            decimal o5 = varInt;

            byte np1 = (byte)varShort;
            short np2 = (short)(varInt);
            int np3 = (int)varLong;
            float np4 = (float)varLong;
            sbyte np5 = (sbyte)varUshort;

            //c.	Выполните упаковку и распаковку значимых типов.

            int i = 12345;
            object obj = i;
            int j = (int)obj;

            //d.	Продемонстрируйте работу с неявно типизированной переменной.
            /*
            var varVarNum = 3.1415f;
            var varVarStr1 = "Длинна окружности: ";
            var varVarStr2 = "Укажите радиус";
            Console.WriteLine(varVarStr2);
            int r = Convert.ToInt32(Console.ReadLine());
            float result = 2 * varVarNum * r;
            Type nameType = varVarNum.GetType();
            Type nameType1 = varVarStr1.GetType();

            Console.WriteLine(varVarStr1 + result);
            Console.WriteLine("\nТип переменной varVarNum: {0}\n" +
                "Тип переменной varVarStr: {1}", nameType, nameType1);
            Console.ReadKey();
            
            //e.	Продемонстрируйте пример работы с Nullable переменной.

            int? varNull = null;
            int? varOp1 = 31;

            Console.WriteLine(varNull ?? 123); //Оператор ?? (null-объединение) (Если первый операнд null то выводит второй операнд)
            Console.WriteLine(varOp1 ?? 321);
            Console.ReadKey();
            */
            /* 2)	Строки
 a.Объявите строковые литералы.Сравните их.
 b.Создайте три строки на основе String. Выполните: сцепление, копирование, 
 выделение подстроки, разделение строки на слова, вставки подстроки в заданную позицию,
 удаление заданной подстроки.
 c.Создайте пустую и null строку.Продемонстрируйте что можно выполнить с такими строками
 d.Создайте строку на основе StringBuilder.Удалите определенные позиции и добавьте новые символы
 в начало и конец строки.
 */

            //  a.Объявите строковые литералы.Сравните их.
/*
            string Str1 = "Пробный текст";
            string Str2 = "Пробный текст2";
            if (Str1 == Str2)
                Console.WriteLine("Строки равны");
            else Console.WriteLine("Строки не равны");
      
            Console.WriteLine(Str1 + "\n" + Str2);
            Console.ReadKey();
*/
            /* b.Создайте три строки на основе String. Выполните: сцепление, копирование, 
  выделение подстроки, разделение строки на слова, вставки подстроки в заданную позицию,
  удаление заданной подстроки.*/

            string StrB1 = "First string ";
            string StrB2 = "Second string ";
            string StrB3 = "Third string";
            string StrBs = StrB1 + StrB2 + StrB3;
            Console.WriteLine(StrBs);
            Console.ReadKey();
        }
    }
}
