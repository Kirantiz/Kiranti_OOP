using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labor_rabota__11
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Задание
            /*
                    Лабораторная работа №11
                     LINQ to Object
Задание
1.Задайте массив типа string, содержащий 12 месяцев(June, July, May, December, January ….).Используя LINQ to Object
напишите запрос выбирающий последовательность месяцев с длиной строки равной n, запрос возвращающий только летние и
зимние месяцы, запрос вывода месяцев в алфавитном порядке, запрос  считающий месяцы содержащие букву «u» и длиной имени
не менее 4 - х..2.Создайте коллекцию List<T> и параметризируйте ее типом (классом) из лабораторной №3(при необходимости 
реализуйте нужные интерфейсы).
3.На основе LINQ сформируйте следующие запросы по вариантам.При необходимости добавьте в класс T(тип параметра) свойства.
4.Придумайте и напишите свой собственный запрос, в котором было бы не менее 5 операторов из разных категорий: условия, 
проекций, упорядочивания, группировки, агрегирования, кванторов и разиения.
5.Придумайте запрос с оператором Join

 Вариант №15 список рейсов для заданного пункта назначения;
 количество рейсов для заданного дня недели
Рейс который вылетает в понедельник раньше всех
Рейс который вылетает в среду или пятницу  позже всех
Список рейсов, упорядоченных по времени вылета
    */
            #endregion

            string[] mesec = new string[] { "January", "February", "Mart", "April", "May", "June", "Jule", "August", "September", "October", "November", "December" };

            int n=4;

            Console.WriteLine(mesec[0]);

            var simMon= from m in mesec
                         where m.Length == n
                         select m;
            Console.WriteLine("Месяцы которые состоят из {0} символов", n);
            foreach (var spismon in simMon)
            {
                Console.WriteLine(spismon);
            }

            //

            //var result2 = mesec.Where(item => item.Length == 4);
            Console.ReadKey();
        }
    }
}
