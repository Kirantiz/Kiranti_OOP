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

            var simMon= from m in mesec
                         where m.Length == n
                         select m;
            Console.WriteLine("Месяцы которые состоят из {0} символов", n);
            foreach (var spismon in simMon)
            {
                Console.WriteLine(spismon);
            }

            Console.WriteLine("Только летние и зимние месяцы: ");
            var onlySummer = mesec.Where(mon => mon == "January" || mon == "February" || mon == "June" || mon == "Jule" || mon == "August" || mon == "December");

            foreach (var sumSpis in onlySummer)
            {
                Console.WriteLine(sumSpis);
            }
            Console.WriteLine("\nМесяцы в алфавитном порядке: \n");
            var alfPor = mesec.OrderBy(mon => mon);
            foreach (var alfSpis in alfPor)
            {
                Console.WriteLine(alfSpis);
            }
 
            Console.WriteLine("\nзапрос  считающий месяцы содержащие букву «u» и длиной имени не менее 4: ");
            var zapros = mesec.Where(mon => mon.Contains('u') && mon.Length > 4);
            foreach (var zapSpis in zapros)
            {
                Console.WriteLine(zapSpis);
            }
            Console.WriteLine("\n");
            
            Airline aeroflot = new Airline("Aeroflot", "minsk", 5, "boeing", 99.99f, "mo we");
            Airline belavia = new Airline("Belavia ", "moskva", 4, "tu", 10.44f, "th fr");
            Airline flydubai = new Airline("Fly-dubai", "abu-dabi", 6, "emirates", 8.01f, "mo we fr su");
            Airline airfrance = new Airline("Air France", "paris", 6, "airbus", 11.21f, "tu we st");
            Airline airberlin = new Airline("Air Berlin", "minsk", 5, "bombardier", 17.30f, "mo we th st su");
            List<Airline> AirList = new List<Airline>() {aeroflot,belavia,flydubai,airberlin,airfrance };

            Console.WriteLine("\nКоличество рейсов для заданного дня недели: ");

            string strDay;
            strDay = "th";

            var DayReis = AirList.Where(air => air.DayWeek.Contains(strDay)).Count();
            Console.WriteLine(DayReis);

            Console.WriteLine("\nРейс который вылетает в понедельник раньше всех: ");
            var MonReis = AirList.Where(air => air.DayWeek.Contains("mo")).OrderBy(air => air.DateTime).ElementAt(0);
    
                Console.WriteLine(MonReis.Name +"\t"+MonReis.DateTime);

            Console.WriteLine("\nРейс который вылетает в среду или пятницу  позже всех: ");
           
            var weReis = AirList.Where(air => air.DayWeek.Contains("we")|| air.DayWeek.Contains("fr")).OrderByDescending(air => air.DateTime).ElementAt(0);
           
            Console.WriteLine(weReis.Name + "\t" + weReis.DateTime);

            Console.WriteLine("\nСписок рейсов, упорядоченных по времени вылета: ");
            var spisReis = AirList.OrderBy(air => air.DateTime).Select(air => air.Name +"\t"+ air.DateTime);
           

            foreach (var SpisDate in spisReis)
            {
                Console.WriteLine(SpisDate);
            }
            List<Airline> AirList2 = new List<Airline>() { aeroflot, belavia, flydubai, airberlin, airfrance };
          // var testJoin = AirList.Join(DayReis, air=>air.Name, p => p.(air2,air2)=> new {air2. })
           
                var testJoin = AirList.Join(AirList2, // второй набор
             p => p.Name, // свойство-селектор объекта из первого набора
             t => t.Name, // свойство-селектор объекта из второго набора
             (p, t) => new { Name = p.Name, Data = p.DateTime, Country = t.DayWeek }); // результат


            foreach (var te in testJoin)
            {
                Console.WriteLine(te);
            }
            Console.ReadKey();
        }
    }
}
