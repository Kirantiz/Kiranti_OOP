using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labor_rabota__10
{
    abstract public class Transport :IComparable 
    {
        private string name;
        private int speed;
        private int crew;
        private string madeOf;
        private string engineType;
        public bool capStatus = false;
        public static int count = 0;

        public int CompareTo(object obj)
        {
            Transport p = obj as Transport;
            if (p != null)
                return this.Name.CompareTo(p.Name);
            else
                throw new Exception("Невозможно сравнить два объекта");
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (value == "" || value == null) name = "Кораблик №" + count;
                else name = value;
            }
        }

        public int Speed        //аксессоры
        {
            get { return speed; }
            set
            {
                if (value < 1) speed = 1;
                else speed = value;
            }
        }
        public int Crew
        {
            get { return crew; }
            set
            {
                if (value < 1) crew = 1;
                else crew = value;
            }
        }
        public string MadeOf
        {
            get { return madeOf; }
            set { madeOf = value; }
        }
        public string EngineType
        {
            get { return engineType; }
            set { engineType = value; }
        }

        public string nameCap;
        public byte ageCap;
        public byte termCap;

        public virtual void Constructor()
        {
            count++;
            this.Name = Name;
            this.Speed = Speed;
            this.Crew = Crew;
            this.MadeOf = MadeOf;
            this.EngineType = EngineType;

        }
        public virtual void Constructor(string _default)
        {
            count++;
            Name = "Unknown ship №" + count;
            Speed = 40;
            Crew = 14;
            MadeOf = "Steel";
            EngineType = "Unknown";
        }
        public virtual void Constructor(string name, int speed, int crew, string madeOf, string engineType)
        {
            count++;
            this.Name = name;
            this.Speed = speed;
            this.Crew = crew;
            this.MadeOf = madeOf;
            this.EngineType = engineType;
        }
        public virtual void appointCap(Capitan capTan)
        {
            if (capStatus == true) Console.WriteLine("На корабле уже есть капитан");
            if (capTan.BusyCap == true) Console.WriteLine("Капитан уже работает на другом корабле");
            if (capStatus == false && capTan.BusyCap == false)
            {
                capStatus = true;
                capTan.BusyCap = true;
                nameCap = capTan.NameCap;
                ageCap = capTan.AgeCap;
                termCap = capTan.TermCap;
            }


        }

        public virtual void Print()
        {
            Console.WriteLine("Имя транспорта: {0}", Name);
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
        }
        public Ship(string _default)                    //конструктор по умолчанию
        {
            base.Constructor("default");
        }
        public Ship(string name, int speed, int crew, string madeOf, string engineType)
        {
            base.Constructor(name, speed, crew, madeOf, engineType);
        }

        public override string ToString()
        {
            Console.WriteLine("Имя транспорта: {0}", Name);
            Console.WriteLine("Скорость транспорта: {0}", Speed);
            Console.WriteLine("Экипаж транспорта: {0}", Crew);
            Console.WriteLine("Материал транспорта: {0}", MadeOf);
            Console.WriteLine("Тип двигателя транспорта: {0}", EngineType);
            Console.WriteLine("Капитан водного транспорта: {0}\n", capStatus);
            if (capStatus == true)
            {
                Console.WriteLine("Информация о капитане: ");
                Console.WriteLine("Имя: {0}", nameCap);
                Console.WriteLine("Возраст: {0}", ageCap);
                Console.WriteLine("Срок службы: {0}\n", termCap);
            }
            return base.ToString();
        }
    }

    sealed class Steamboat : Transport      //класс параход
    {
        public Steamboat()
        {
            base.Constructor();
        }

        public Steamboat(string _default)
        {
            base.Constructor("default");
        }

        public Steamboat(string name, int speed, int crew, string madeOf, string engineType)
        {
            base.Constructor(name, speed, crew, madeOf, engineType);
        }

        public override string ToString()
        {
            Console.WriteLine("Имя транспорта: {0}", Name);
            Console.WriteLine("Скорость транспорта: {0}", Speed);
            Console.WriteLine("Экипаж транспорта: {0}", Crew);
            Console.WriteLine("Материал транспорта: {0}", MadeOf);
            Console.WriteLine("Тип двигателя транспорта: {0}", EngineType);
            Console.WriteLine("Капитан водного транспорта: {0}\n", capStatus);
            if (capStatus == true)
            {
                Console.WriteLine("Информация о капитане: ");
                Console.WriteLine("Имя: {0}", nameCap);
                Console.WriteLine("Возраст: {0}", ageCap);
                Console.WriteLine("Срок службы: {0}\n", termCap);
            }
            return base.ToString();
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

        public override string ToString()
        {
            Console.WriteLine("Имя транспорта: {0}", Name);
            Console.WriteLine("Скорость транспорта: {0}", Speed);
            Console.WriteLine("Экипаж транспорта: {0}", Crew);
            Console.WriteLine("Материал транспорта: {0}", MadeOf);
            Console.WriteLine("Тип двигателя транспорта: {0}", EngineType);
            Console.WriteLine("Капитан водного транспорта: {0}\n", capStatus);
            if (capStatus == true)
            {
                Console.WriteLine("Информация о капитане: ");
                Console.WriteLine("Имя: {0}", nameCap);
                Console.WriteLine("Возраст: {0}", ageCap);
                Console.WriteLine("Срок службы: {0}\n", termCap);
            }
            return base.ToString();
        }
    }

    sealed class Corvette : Transport
    //класс корвет
    {
        public Corvette()
        {
            base.Constructor();
        }

        public Corvette(string _default)
        {
            base.Constructor("default");
        }

        public Corvette(string name, int speed, int crew, string madeOf, string engineType)
        {
            base.Constructor(name, speed, crew, madeOf, engineType);
        }

        public override string ToString()
        {
            Console.WriteLine("Имя транспорта: {0}", Name);
            Console.WriteLine("Скорость транспорта: {0}", Speed);
            Console.WriteLine("Экипаж транспорта: {0}", Crew);
            Console.WriteLine("Материал транспорта: {0}", MadeOf);
            Console.WriteLine("Тип двигателя транспорта: {0}", EngineType);
            Console.WriteLine("Капитан водного транспорта: {0}\n", capStatus);
            if (capStatus == true)
            {
                Console.WriteLine("Информация о капитане: ");
                Console.WriteLine("Имя: {0}", nameCap);
                Console.WriteLine("Возраст: {0}", ageCap);
                Console.WriteLine("Срок службы: {0}\n", termCap);
            }
            return base.ToString();
        }
    }

    sealed class Boat : Transport      //класс лодка
    {
        public Boat()
        {
            Constructor();
        }

        public Boat(string _default)
        {
            Constructor("default");
        }

        public Boat(string name, int speed, int crew, string madeOf, string engineType)
        {
            Constructor(name, speed, crew, madeOf, engineType);
        }

        public override string ToString()
        {
            Console.WriteLine("Имя транспорта: {0}", Name);
            Console.WriteLine("Скорость транспорта: {0}", Speed);
            Console.WriteLine("Экипаж транспорта: {0}", Crew);
            Console.WriteLine("Материал транспорта: {0}", MadeOf);
            Console.WriteLine("Тип двигателя транспорта: {0}", EngineType);
            Console.WriteLine("Капитан водного транспорта: {0}\n", capStatus);
            if (capStatus == true)
            {
                Console.WriteLine("Информация о капитане: ");
                Console.WriteLine("Имя: {0}", nameCap);
                Console.WriteLine("Возраст: {0}", ageCap);
                Console.WriteLine("Срок службы: {0}\n", termCap);
            }
            return base.ToString();
        }
    }
     public class Capitan
    {
        private string nameCap;
        private byte ageCap;
        private byte termCap;
        private bool busyCap;
        public static int countCap = 0;

        public string NameCap
        {
            get { return nameCap; }
            set { nameCap = value; }
        }

        public byte AgeCap
        {
            get { return ageCap; }
            set
            {
                if (value < 1) ageCap = 1;
                else ageCap = value;
            }
        }

        public byte TermCap
        {
            get { return termCap; }
            set
            {
                if (value < 1) termCap = 1;
                else termCap = value;
            }
        }

        public bool BusyCap
        {
            get { return busyCap; }
            set { busyCap = value; }
        }

        public Capitan()
        {
            countCap++;
            this.NameCap = NameCap;
            this.AgeCap = AgeCap;
            this.TermCap = TermCap;
            this.BusyCap = BusyCap;
        }
        public Capitan(string _default)
        {
            countCap++;
            NameCap = "Capitan №" + countCap;
            AgeCap = 43;
            TermCap = 5;
            BusyCap = false;
        }
        public Capitan(string nameCap, byte ageCap, byte termCap)
        {
            countCap++;
            NameCap = nameCap;
            AgeCap = ageCap;
            TermCap = termCap;
            BusyCap = false;
        }
        public override string ToString()
        {
            Console.WriteLine("Имя капитана: {0}", NameCap);
            Console.WriteLine("Возраст капитана: {0}", AgeCap);
            Console.WriteLine("Срок службы: {0}", TermCap);
            Console.WriteLine("Есть ли у капитана корабль: {0}\n", BusyCap);
            return base.ToString();
        }
    }
}
