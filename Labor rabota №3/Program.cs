using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labor_rabota__3
{

    class Airline
    {
        private string name;
        private string destination;
        private byte flight;
        private string typeAirplane;
        private float dateTime;
        private string dayWeek;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Destination
        {
            get { return destination; }
            set { destination = value; }
        }
        public byte Flight
        {
            get { return flight; }
            set {
                if (value < 1)
                    flight = 1;
                else flight = value;
            }
        }
        public string TypeAirplane
        {
            get { return typeAirplane; }
            set { typeAirplane = value; }
        }
        public float DateTime
        {
            get { return dateTime; }
            set
            {
                if (value > 24.59f) dateTime = 24.59f;
                else if (value % 1 * 100 > 59)
                {
                    dateTime = Convert.ToInt32(dateTime);
                }
                else dateTime = value;
            }
        }
        public string DayWeek
        {
            get { return dayWeek; }
            set
            { dayWeek = value; }
        }

        public static int count = 0;
        readonly static string week = "mo tu we th fr sa su";

        public Airline(string _def)
        {
            Name = "belavia";
            Destination = "Minsk";
            Flight = 3;
            TypeAirplane = "boing 747";
            DateTime = 21.30f;
            DayWeek = "mon, wed";
            count++;
        }
        static Airline ()
        {
            Console.WriteLine("Статичный контсруктор");
          
        }
        
        public Airline() //пустой
        {
            count++;
        }

        public Airline(string name, string destination, byte flight, string typeAirplane, float dateTime, string dayWeek) //по умолчанию
        {
                this.Name = name;
                this.Destination = destination;
                this.Flight = flight;
                this.TypeAirplane = typeAirplane;
                this.DateTime = dateTime;
                this.DayWeek = dayWeek;
                count++;
        }


        public void Print()
        {
            Console.WriteLine("Name: " + Name + "\t\tHash code: {0}", Name.GetHashCode());
            Console.WriteLine("destination: " + Destination + "\tHash code: {0}", Destination.GetHashCode());
            Console.WriteLine("flight: " + Flight + "\t\tHash code: {0}", Flight.GetHashCode());
            Console.WriteLine("typeAirplane: " + TypeAirplane + "\tHash code: {0}", TypeAirplane.GetHashCode());
            Console.WriteLine("dateTime: " + DateTime + "\t\tHash code: {0}", DateTime.GetHashCode());
            Console.WriteLine("dayWeek: " + DayWeek + "\tHash code: {0}", DayWeek.GetHashCode());
        }
        
        
    }

    class Program
    {


        static void Main(string[] args)
        {
           

            Airline aeroflot = new Airline("Aeroflot","minsk",5,"boeing",99.99f,"mo we");
            Airline belavia = new Airline("Belavia","moskva", 4, "tu", 10.44f, "th fr");
            Airline flydubai = new Airline("Fly-dubai","abu-dabi", 6, "emirates", 8.00f, "mo we fr su");
            Airline airfrance = new Airline("Air France","paris", 6, "airbus", 11.21f, "tu we st");
            var airberlin = new Airline("Air Berlin","minsk", 5, "bombardier", 17.30f, "mo we th st su"); // анонимный тип
            Airline[] AllAir = new Airline[] {aeroflot, belavia, flydubai, airfrance, airberlin}; //массив объектов
                        
            Console.WriteLine("Введите необходимый пункт назначения: ");
            string pointDest = Console.ReadLine();

            foreach (Airline allA in AllAir)
            {
                if (allA.Destination.Contains(pointDest))
                { allA.Print(); Console.WriteLine(); }
                else Console.WriteLine("\n{0} не летает\n", allA.Name);
            }
            Console.WriteLine("Введите необходимый день недели вылета в формате (mo tu we th fr sa su): ");
            string pointWeek = Console.ReadLine();

            foreach (Airline allA in AllAir)
            {
                if (allA.DayWeek.Contains(pointWeek))
                { allA.Print(); Console.WriteLine(); }
                else Console.WriteLine("\n{0} не летает\n", allA.Name);
            }
            Console.WriteLine(aeroflot.Equals(belavia));
            Console.WriteLine(aeroflot.GetHashCode()== belavia.GetHashCode() );
            Console.WriteLine(belavia.GetType());
 
            Console.ReadKey();
            // Лабораторная работа №3 (Проектирование типов. Классы.)
            /*
                        Задание
            1)	Определить класс, указанный в варианте, содержащий:
            •	Не менее трех конструкторов(с параметрами  и без, а также с параметрами по умолчанию);
            •	статический конструктор(конструктор типа);
            •	определите закрытый конструктор; предложите варианты его вызова;
            •	поле - только для чтения(например, для каждого экземпляра сделайте поле только для чтения ID -равно некоторому уникальному номеру(хэшу) вычисляемому автоматически на основе инициализаторов объекта);
            •	поле - константу;
            •	свойства(get, set) – для всех поле класса(поля класса должны быть закрытыми); Для одного из свойств ограните доступ по set
            •	в одном из методов класса для работы с аргументами используйте ref -и out-параметры.
            •	создайте в классе статическое поле, хранящее количество созданных объектов(инкрементируется в конструкторе) и статический метод вывода информации о классе.
            •	сделайте касс partial
            •	переопределяете методы класса Object: Equals, для сравнения объектов,  GetHashCode; для алгоритма вычисления хэша руководствуйтесь стандартными рекомендациями, ToString – вывода строки –информации об объекте.
            2)	Создайте несколько объектов вашего типа.Выполните вызов конструкторов, свойств, методов, сравнение объекты, проверьте тип созданного объекта и т.п.
            3)	Создайте массив объектов вашего типа.И выполните задание, выделенное курсивом в таблице.
            4)	Создайте и выведите анонимный тип(по образцу вашего класса).
            */
          /*  Вариант 15  Создать класс Airline: Cодержит: Пункт назначения, Номер рейса, Тип самолета, 
           *  Время вылета, Дни недели. Свойства и конструкторы должны обеспечивать проверку корректности.
Создать массив объектов.Вывести:
a)  список рейсов для заданного пункта назначения;
            b)  список рейсов для заданного дня недели;.
            */

        }
    }
}

    partial class Airline
{

}
