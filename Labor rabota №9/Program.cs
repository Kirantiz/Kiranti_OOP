using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labor_rabota__9
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Задание_Лабораторной_работы_№9
            /*
             Лабораторная работа №9

            Задание
1.	Используя делегаты (множественные) и события промоделируйте ситуации, приведенные в таблице ниже. 
Можете добавить новые типы (классы), если существующих недостаточно. При реализации методов везде где возможно использовать
лямбда-выражения.
2.	Создайте пять методов пользовательской обработки строки (например, удаление знаков препинания, добавление символов, замена 
на заглавные, удаление лишних пробелов и т.п.). Используя стандартные типы делегатов (Action, Func) организуйте алгоритм 
последовательной обработки строки написанными вами методами.

                            Вариант 15
         Создать  класс Пользователь с  событиями Переместить  (можно задать  смещение) и Сжать 
         (коэффициент сжатия). В main создать некоторое количество объектов разного типа. Часть объектов 
         подписать на одно событие, часть на два (часть можете не подписывать).  Проверить состояния объектов 
         после наступления событий.

             */
            #endregion

            User user1 = new User();
            User user2 = new User();
            User user3 = new User();
            User user4 = new User();
            user1.userMove += User1_userMove;
            user2.userMove += User2_userMove;
            user3.userMove += User3_userMove;
            user1.userCompression += User1_userCompression;
            user2.userCompression += User2_userCompression;
            user3.userCompression += User3_userCompression;

            user1.doList("go", 3);
            user1.doList("go", 5);
            user1.doList("go", 123);
            user1.doList("go", 11);
            user2.doList("go", 5);
            user2.doList("go", 10);
            user2.doList("go", 25);
            user3.doList("go", 1);
            user3.doList("go", 11);
            user3.doList("go", 111);

            user1.doList("Compression", 3);
            user1.doList("Compression", 5);
            user1.doList("Compression", 123);
            user1.doList("Compression", 11);
            user2.doList("Compression", 5);
            user2.doList("Compression", 10);
            user2.doList("Compression", 25);
            user3.doList("Compression", 1);
            user3.doList("Compression", 11);
            user3.doList("Compression", 111);

            /*
                        Создайте пять методов пользовательской обработки строки (например, удаление знаков препинания, добавление 
                        символов, замена 
                        на заглавные, удаление лишних пробелов и т.п.). Используя стандартные типы делегатов(Action, Func) организуйте 
                        алгоритм
            последовательной обработки строки написанными вами методами.
            */
           string stroka= "Создайте  пять методов пользовательской  обработки строки  (например, удаление знаков препинания,  " +
                "добавление символов,  замена на заглавные,  удаление    лишних пробелов  и  т.п.)";

            Func<string, string> funcDeleg = UdalenieZnakov;
            funcDeleg += DvaA;
            funcDeleg += Zaglavn;
            funcDeleg += AddSim;
            funcDeleg += DelProbel;
        
           funcDeleg(stroka);

          //  Console.WriteLine(stroka);


            Console.ReadKey();
        }

        //удаление ","

            public static string UdalenieZnakov(string str)
        {
            Console.WriteLine("\nУдаление знаков препинания: \n");
            int sizeStr = str.Length;
            for(int i=0; i<sizeStr;i++)
            {
                if(str[i]==','||str[i]=='!'||str[i]=='.'||str[i]=='?')
                {
                    str = str.Remove(i, 1);
                    sizeStr--;
                    i--;
                }
            }
           
            Console.WriteLine(str);
            return str;
        }

        // добавление 2а

            public static string DvaA(string str)
        {
            Console.WriteLine("\nУдвоенные буквы \"а\": \n");
            for (int i=0; i < str.Length; i++)
            {
                if (str[i] == 'a' || str[i] == 'а')
                {
                    str = str.Insert(i,"a");
                    i++;
                }
            }
            Console.WriteLine(str);
            return str;
        }
        // Заглавные буквы
        public static string Zaglavn(string str)
        {
            Console.WriteLine("\nЗаглавная строчка: \n");
            str = str.ToUpper();
            Console.WriteLine(str);
            return str;
        }

        //добавление символов к строке
        public static string AddSim(string str)
        {
            Console.WriteLine("\nДобавление \"Символы\": \n");
            str =  str.Insert( 0, "Символы ");
            str +=" Символы";
            Console.WriteLine(str);
            return str;
        }
        //удаление лишних пробелов

        public static string DelProbel(string str)
        {
            Console.WriteLine("\nУдаление лишних пробелов: \n");
            int sizeStr = str.Length;
            bool prob = false;
            for (int i = 0; i < sizeStr; i++)
            {
                if (str[i] == ' ')
                {
                    if (prob == true)
                    {
                        str = str.Remove(i, 1);
                        sizeStr--;
                        i--;
                    }
                    prob = true;
                }
                else
                {
                    prob = false;
                }
            }
            Console.WriteLine(str);
            return str;
        }


        private static void User3_userCompression(string stat)
        {
            Console.WriteLine(stat);
        }

        private static void User2_userCompression(string stat)
        {
            Console.WriteLine(stat);
        }

        private static void User1_userCompression(string stat)
        {
            Console.WriteLine(stat);
        }

        private static void User3_userMove(string stat)
        {
            Console.WriteLine(stat);
        }

        private static void User2_userMove(string stat)
        {
            Console.WriteLine(stat);
        }

        private static void User1_userMove(string stat)
        {
            Console.WriteLine(stat);
        }
    }
}
