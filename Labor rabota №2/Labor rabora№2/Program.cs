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

                      int x = 12345;
                      object obj = x;
                      int z = (int)obj;

                      //d.	Продемонстрируйте работу с неявно типизированной переменной.

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
            
                        string Str1 = "Пробный текст";
                        string Str2 = "Пробный текст2";
                        if (Str1 == Str2)
                            Console.WriteLine("Строки равны");
                        else Console.WriteLine("Строки не равны");

                        Console.WriteLine(Str1 + "\n" + Str2);
                        Console.ReadKey();
            
            /* b.Создайте три строки на основе String. Выполните: сцепление, копирование, 
  выделение подстроки, разделение строки на слова, вставки подстроки в заданную позицию,
  удаление заданной подстроки.*/
            
                      string StrB1 = "First string\n";
                      string StrB2 = "Second string\n";
                      string StrB3 = "Third string\n";
                      string StrResult1 = StrB1 + StrB2 + StrB3; //сцепление
                      string StrResult2 = String.Concat(StrB1, StrB2, StrB3);
                      Console.WriteLine(StrResult1+"\n\n"+StrResult2);

                      string StrResultCopy = String.Copy(StrB1); //копия
                      Console.WriteLine("Копия строки StrB1: \n" + StrResultCopy);

                      string StrPodStoka = StrB1.Substring(3, 5); // выделение подстроки
                      Console.WriteLine(StrPodStoka);

                      string[] naborSlov = StrResult2.Split(); // Создаём массив и заполняем его строкой разбтой пробелами.

                      foreach (var str in naborSlov)
                      {
                          Console.WriteLine(str);
                      }

                      StrB1 = StrB1.Insert(6,"insert "); // Вставка подстроки в заданную позицию
                      Console.WriteLine("\n"+StrB1 + "\n");

                      StrB1 = StrB1.Remove(6,7);  // Удаление заданной подстроки
                      Console.WriteLine(StrB1 + "\n");
                      Console.ReadKey();
          
            // c.Создайте пустую и null строку.Продемонстрируйте что можно выполнить с такими строками
                       
                        string StrEmpty = "";
                        string StrNull = null;

                        StrEmpty = StrEmpty + "word";
                        StrNull = StrNull + "word";

                        StrEmpty = "";
                        StrNull = null;

                        Console.WriteLine("Пустая строка: {0}\nnull строка: {1}\n",StrEmpty, StrNull);
                        Console.WriteLine(StrEmpty ?? "не отобразится");//Оператор ?? (null-объединение) (Если первый операнд null то выводит второй операнд)
                        Console.WriteLine(StrNull ?? "отобразится");
                        Console.ReadKey();
              
            /*d.Создайте строку на основе StringBuilder.Удалите определенные позиции и добавьте новые символы
 в начало и конец строки.*/
            
                       StringBuilder varStrBuild = new StringBuilder("Пример строки с разными словами", 100);
                       Console.WriteLine("\n\n" + varStrBuild);
                       varStrBuild = varStrBuild.Remove(0, 7); //удаление определённой позиции
                       varStrBuild = varStrBuild.Append(" и пробелами"); // добавление в конец строки
                       varStrBuild = varStrBuild.Insert(0, "Example "); // добавление в начало строки
                       Console.WriteLine("\n\n"+varStrBuild);
                       Console.ReadKey();
           
            /*  3)	Массивы
  a.Создайте целый двумерный массив и выведите его на консоль в отформатированном виде(матрица). 
  b.Создайте одномерный массив строк. Выведите на консоль его содержимое, длину массива. Поменяйте произвольный элемент(пользователь определяет позицию и значение).
  c.Создайте ступечатый(не выровненный) массив вещественных чисел с 3 - мя строками, в каждой из которых 2, 3 и 4 столбцов соответственно. Значения массива введите с консоли.
  d.Создайте неявно типизированные переменные для хранения массива и строки.
  */

            //a.Создайте целый двумерный массив и выведите его на консоль в отформатированном виде(матрица). 
            int[,] Array = new int[3, 4];
            Random ran = new Random();
            for (int i=0; i<3; i++)
            {
                for(int j=0; j<4; j++)
                {
                    Array[i, j] = ran.Next(-100, 100);
                    Console.Write(Array[i, j] +"\t");
                }
               Console.WriteLine();
            }
            Console.ReadKey();

            /*b.Создайте одномерный массив строк. Выведите на консоль его содержимое, 
            длину массива. Поменяйте произвольный элемент(пользователь определяет позицию и значение).*/

            string[] ArratStr = new string[] {"Это","Одномерный","Массив", "Строк","." };
            foreach (string ArrM in ArratStr)
                Console.Write(ArrM +" ");
            Console.WriteLine("\nДлинна массива строк: {0}", ArratStr.Length); //длинна массива
            Console.WriteLine("Введите № элемента для замены (Не больше {0})", ArratStr.Length);
            int el = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите текст для замены");
            string text = Console.ReadLine();
            ArratStr[el-1] = text;
            Console.WriteLine();
            foreach (string ArrM in ArratStr)
                Console.Write(ArrM +" ");
            Console.ReadKey();
            Console.WriteLine();
            /* c.Создайте ступечатый(не выровненный) массив вещественных чисел с 3 - мя строками, 
             в каждой из которых 2, 3 и 4 столбцов соответственно. Значения массива введите с консоли.*/


            int[][] ArrZub = new int[4][]; // Объявляем ступенчатый массив
            ArrZub[0] = new int[2];
            ArrZub[1] = new int[3];
            ArrZub[2] = new int[4];

            for (int i=0; i < 2; i++)
            {
                ArrZub[0][i] = i+1;
                Console.Write("{0}\t", ArrZub[0][i]);
            }

            Console.WriteLine();
            for (int i = 0; i < 3; i++)
            {
                ArrZub[1][i] = i+1;
                Console.Write("{0}\t", ArrZub[1][i]);
            }

            Console.WriteLine();
            for (int i = 0; i < 4; i++)
            {
                ArrZub[2][i] = i+1;
                Console.Write("{0}\t", ArrZub[2][i]);
            }

            Console.WriteLine("\n\n");
            Console.ReadKey();

            //d.Создайте неявно типизированные переменные для хранения массива и строки.
            var varArray = new string[] {"dsfs", "asdf" ,"afzzf", "242"};


            /*  4)	Кортежи
  a.Задайте кортеж из 5 элементов с типами int, string, char, string, ulong.
  b.Сделайте именование его элементов.
  c.Выведите кортеж на консоль целиком и выборочно(1, 3, 4  элементы)
  d.Выполните распаковку кортежа в переменные.
  e.Сравните два кортежа.*/

            //var varTurple = new Tuple<int, string, char, string, ulong>(10, "Строка", 'x',"Ещё строка", 222);
            var varTurple = Tuple.Create (10, "Строка", 'x', "Ещё строка", 222);
            Console.WriteLine(varTurple);
            Console.WriteLine("{0} {1} {2} {3}",varTurple.Item1, varTurple.Item3, varTurple.Item4, varTurple.Item5);
            var (varT1, varT2, varT3, varT4, varT5) = varTurple; //распаковка
            Console.WriteLine("1:{0} 2:{1} 3:{2} 4:{3} 5:{4}", varT1, varT2, varT3, varT4, varT5);
            var varTurple2 = Tuple.Create(10, "Строка", 'x', "Ещё строка", 222);
            Console.WriteLine(varTurple.Equals(varTurple2)); //сравнение строк

            Console.ReadKey();
        }
    }
}
