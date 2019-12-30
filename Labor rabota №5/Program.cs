using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labor_rabota__5
{
   abstract public class Transport
    {
        private string name;
        private int speed;
        private int crew;
        private string madeOf;
        private string engineType;
        public bool capStatus = false;
        public static int count=0;

        public string Name
        {
            get { return name; }
            set { if (value == "" || value == null)  name = "Кораблик №" + count;
                else name = value;
            }
        }

        public int Speed        //аксессоры
        {
            get { return speed; }
            set { if (value < 1) speed = 1;
                else speed = value; }
        }
        public int Crew
        {
            get { return crew; }
            set { if (value < 1) crew = 1;
                else crew = value; }
        }
        public string MadeOf
        {
            get { return madeOf; }
            set { madeOf = value; }
        }
        public string  EngineType
        {
            get {return engineType; }
            set {engineType = value; }
        }

        public void Constructor()
        {
            count++;
            this.Name = Name;
            this.Speed = Speed;
            this.Crew = Crew;
            this.MadeOf = MadeOf;
            this.EngineType = EngineType;
            
        }
        public void Constructor(string _default)
        {
            count++;
            Name = "Unknown ship №" + count;
            Speed = 40;
            Crew = 14;
            MadeOf = "Steel";
            EngineType = "Unknown";
        }
        public void Constructor(string name, int speed, int crew, string madeOf, string engineType)
        {
            count++;
            this.Name = name;
            this.Speed = speed;
            this.Crew = crew;
            this.MadeOf = madeOf;
            this.EngineType = engineType;
        }

            public virtual void Print()
        {
            Console.WriteLine("Имя транспорта: {0}",Name);
            Console.WriteLine("Скорость транспорта: {0}", Speed);
            Console.WriteLine("Экипаж транспорта: {0}", Crew);
            Console.WriteLine("Материал транспорта: {0}", MadeOf);
            Console.WriteLine("Тип двигателя транспорта: {0}", EngineType);
            Console.WriteLine("Капитан водного транспорта: {0}\n\n", capStatus);
        }
     }

   sealed class Ship : Transport         //класс корабль
    {
        public Ship()       //конструктор
        {
            base.Constructor();
            capStatus = true;            
        }
        public Ship(string _default)                    //конструктор по умолчанию
        {
            base.Constructor("default");
            capStatus = true;
        }
        public Ship(string name, int speed, int crew, string madeOf, string engineType)
        {
            base.Constructor(name,speed,crew,madeOf,engineType);
            capStatus = true;
        }
    }

  sealed class Steamboat : Transport      //класс параход
    {
        public Steamboat()
        {
            base.Constructor();
            capStatus = true;
        }

        public Steamboat(string _default)
        {
            base.Constructor("default");
            capStatus = true;
        }

        public Steamboat(string name, int speed, int crew, string madeOf, string engineType)
        {
            base.Constructor(name, speed, crew, madeOf, engineType);
            capStatus = true;
        }
    }
   
   sealed class Sailboat : Transport      //класс парусник
    {
        public Sailboat()
        {
            base.Constructor();
        }

        public Sailboat(string _default)
        {
            base.Constructor("default");
        }

        public Sailboat(string name, int speed, int crew, string madeOf, string engineType)
        {
            base.Constructor(name, speed, crew, madeOf, engineType);
        }
    }

   sealed class Corvette : Transport      //класс корвет
    {
        public Corvette()
        {
            base.Constructor();
            capStatus = true;
        }

       public Corvette(string _default)
        {
            base.Constructor("default");
            capStatus = true;
        }

        public Corvette(string name, int speed, int crew, string madeOf, string engineType)
        {
            base.Constructor(name, speed, crew, madeOf, engineType);
            capStatus = true;
        }
    }

   sealed class Boat : Transport          //класс лодка
    {
          public Boat()
        {
            base.Constructor();
        }

        public Boat(string _default)
        {
            base.Constructor("default");
        }

        public Boat(string name, int speed, int crew, string madeOf, string engineType)
        {
            base.Constructor(name, speed, crew, madeOf, engineType);
        }
    }
 
    class Printer
    {

    }

    class Program
    {
        static void Main(string[] args)
        {
            

            Ship b1 = new Ship();
            Ship b2 = new Ship("default");
            Ship b3 = new Ship("kkk1", 90, 3, "Plastic", "Wind");

            Steamboat s1 = new Steamboat();
            Steamboat s2 = new Steamboat("default");
            Steamboat s3 = new Steamboat("Parahod", 110, 35, "Steel", "Steam");

            Sailboat ss1 = new Sailboat();
            Sailboat ss2 = new Sailboat("default");
            Sailboat ss3 = new Sailboat("Parusnik", 150, 2, "Plastic", "Wind");

            Corvette c1 = new Corvette();
            Corvette c2 = new Corvette("default");
            Corvette c3 = new Corvette("Corvet", 50, 10, "Steel", "Sgoranie");

            Boat bv1 = new Boat();
            Boat bv2 = new Boat("default");
            Boat bv3 = new Boat("lodo4ka", 20, 2, "wood", "vesla");

            b1.Print();
            b2.Print();
            b3.Print();
            s1.Print();
            s2.Print();
            s3.Print();
            ss1.Print();
            ss2.Print();
            ss3.Print();
            c1.Print();
            c2.Print();
            c3.Print();
            bv1.Print();
            bv2.Print();
            bv3.Print();
            
            Console.WriteLine("Всего число транспортов: {0}",Transport.count);

            Console.ReadKey();

            
            /*
                                    Лабораторная работа №5
                         Наследование, полиморфизм, абстрактные классы и интерфейсы
            Задание
            1)	Определить иерархию и композицию классов(в соответствии с вариантом), реализовать классы. 
            Если необходимо расширьте по своему усмотрению  иерархию для выполнения всех пунктов л.р.
            Каждый класс должен иметь отражающее смысл название и информативный состав.   
            При кодировании должны быть использованы соглашения об оформлении кода code convention.
            В одном из классов переопределите все методы, унаследованные от Object.
            2)	В проекте должны быть интерфейсы и абстрактный класс(ы).  Использовать виртуальные методы и переопределение.
            3)	Сделайте один из классов герметизированным(бесплодным).
            4)	Добавьте в интерфейсы или интерфейс + абстрактный класс одноименные методы.Дайте в наследуемом классе 
            им разную реализацию и вызовите эти методы.
            5)	Написать демонстрационную программу, в которой создаются объекты различных классов. Поработать с объектами 
            через ссылки на абстрактные классы и интерфейсы. В этом случае для идентификации типов объектов использовать операторы 
            is или as.
            6)	Во всех классах(иерархии) переопределить метод ToString(), который выводит информацию о типе объекта и его 
            текущих значениях. Создайте дополнительный класс Printer c полиморфным методом 
            iAmPrinting(SomeAbstractClassorInterface someobj).
            Формальным параметром метода должна быть ссылка на абстрактный класс или наиболее общий интерфейс в вашей иерархии 
            классов.
            В методе iAmPrinting определите тип объекта и вызовите  ToString().В демонстрационной программе создайте массив,
            содержащий 
            ссылки на разнотипные объекты ваших классов по иерархии, а также объект класса Printer  и последовательно вызовите
            его метод
            iAmPrinting  со всеми ссылками в качестве аргументов.

              Вариант №15    Транспортное средство, Корабль, Пароход, Парусник, Корвет, Капитан, Лодка; 
            */
        }
    }
}
