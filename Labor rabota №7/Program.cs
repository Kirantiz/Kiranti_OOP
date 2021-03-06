﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Labor_rabota__7
{
    abstract public class Transport
    {
        private string name;
        private int speed;
        private int crew;
        private string madeOf;
        private string engineType;
        private int displacement;
        public bool capStatus = false;
        public static int count = 0;

        public string Name
        {
            get { return name; }
            set
            {
                try
                {
                    if (value == "" || value == null)
                    {
                        name = "Кораблик №" + count;
                        throw new MyOwnException("Не назначено имя транспортного средства (Автоматическое имя \"Кораблик №"+count+"\")");
                    }
                    else name = value;
                    Debug.Assert(name.Length < 30, "Длинна имени не должна превышать 30 символов");
                }
                catch(MyOwnException ex)
                {
                    Console.WriteLine("Error: {0}",ex.Message);
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Error: {0}", ex.Message);
                }
            }
        }

        public int Speed        //аксессоры
        {
            get { return speed; }
            set
            {
                try
                {
                    if (value < 1)
                    {
                        speed = 1;
                        throw new MyOwnException("Скорость корабля \""+ name+"\" не может быть меньше чем 1 (Автоматически изменено на \"1\")");
                    }
                    else speed = value;
                }
                catch (MyOwnException ex)
                {
                    Console.WriteLine("Error: {0}", ex.Message);
                }
            }
        }
        public int Crew
        {
            get { return crew; }
            set
            {
                try
                {
                    if (value < 1)
                    {
                        crew = 1;
                        throw new MyOwnException("Посадочных мест на корабле \"" + name + "\" не может быть меньше 1 (Автоматически изменено на \"1\")");
                    }
                    else crew = value;
                }
                catch(MyOwnException ex)
                {
                    Console.WriteLine("Error: {0}", ex.Message);
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Error: {0}", ex.Message);
                }
            }
        }
        public int Displacement
        {
            get { return displacement; }
            set {
                try
                {
                    if (value < 1)
                    { displacement = 1;
                        throw new MyOwnException("Водоизмещение коробля \"" + name + "\" не может быть меньше 1(Автоматически изменено на \"1\")");
                    }
                    else displacement = value;
                }
                catch (MyOwnException ex)
                {
                    Console.WriteLine("Error: {0}", ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: {0}", ex.Message);
                }
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
            this.Displacement = Displacement;
            this.MadeOf = MadeOf;
            this.EngineType = EngineType;

        }
        public virtual void Constructor(string _default)
        {
            count++;
            Name = "Unknown ship №" + count;
            Speed = 40;
            Crew = 14;
            Displacement = 5000;
            MadeOf = "Steel";
            EngineType = "Unknown";
        }
        public virtual void Constructor(string name, int speed, int crew,int displacement, string madeOf, string engineType)
        {
            count++;
            this.Name = name;
            this.Speed = speed;
            this.Crew = crew;
            this.Displacement = displacement;
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
            Console.WriteLine("Число мест в транспорте: {0}", Crew);
            Console.WriteLine("Водоизмещение водного транспортного средства: {0} кг.", Displacement);
            Console.WriteLine("Материал транспорта: {0}", MadeOf);
            Console.WriteLine("Тип двигателя транспорта: {0}", EngineType);
            Console.WriteLine("Капитан водного транспорта: {0}\n\n", capStatus);
        }
    }

    sealed class Ship : Transport         //класс корабль
    {
        public Ship()       //конструктор
        {
            Constructor();
        }
        public Ship(string _default)                    //конструктор по умолчанию
        {
            Constructor("default");
        }
        public Ship(string name, int speed, int crew,int displacement, string madeOf, string engineType)
        {
            Constructor(name, speed, crew, displacement, madeOf, engineType);
        }

        public override string ToString()
        {
            Console.WriteLine("Имя транспорта: {0}", Name);
            Console.WriteLine("Скорость транспорта: {0}", Speed);
            Console.WriteLine("Число мест в транспорте: {0}", Crew);
            Console.WriteLine("Водоизмещение водного транспортного средства: {0} кг.", Displacement);
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
            Constructor();
        }

        public Steamboat(string _default)
        {
           Constructor("default");
        }

        public Steamboat(string name, int speed, int crew, int displacement, string madeOf, string engineType)
        {
            Constructor(name, speed, crew, displacement, madeOf, engineType);
        }

        public override string ToString()
        {
            Console.WriteLine("Имя транспорта: {0}", Name);
            Console.WriteLine("Скорость транспорта: {0}", Speed);
            Console.WriteLine("Число мест в транспорте: {0}", Crew);
            Console.WriteLine("Водоизмещение водного транспортного средства: {0} кг.", Displacement);
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
           Constructor();
        }

        public Sailboat(string _default)
        {
            Constructor("default");
        }

        public Sailboat(string name, int speed, int crew, int displacement, string madeOf, string engineType)
        {
          Constructor(name, speed, crew, displacement, madeOf, engineType);
        }

        public override string ToString()
        {
            Console.WriteLine("Имя транспорта: {0}", Name);
            Console.WriteLine("Скорость транспорта: {0}", Speed);
            Console.WriteLine("Экипаж транспорта: {0}", Crew);
            Console.WriteLine("Водоизмещение водного транспортного средства: {0} кг.", Displacement);
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

    sealed class Corvette : Transport      //класс корвет
    {
        public Corvette()
        {
            Constructor();
        }

        public Corvette(string _default)
        {
            Constructor("default");
        }

        public Corvette(string name, int speed, int crew, int displacement, string madeOf, string engineType)
        {
            Constructor(name, speed, crew, displacement, madeOf, engineType);
        }

        public override string ToString()
        {
            Console.WriteLine("Имя транспорта: {0}", Name);
            Console.WriteLine("Скорость транспорта: {0}", Speed);
            Console.WriteLine("Число мест в транспорте: {0}", Crew);
            Console.WriteLine("Водоизмещение водного транспортного средства: {0} кг.", Displacement);
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
  
    enum Engine {Steam, Combustion, Wind, Physical, Combined };
    enum Material { Plastic, Steel, Wood, Titan, Another};

    public class Printer : IPrinter
    {
        public void iAmPrinting(Transport someobj)
        {
            Console.WriteLine(someobj.GetType());
            someobj.ToString();
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

    interface IPrinter
    {
        void iAmPrinting(Transport _someobj);

    }

    public struct cargo
    {
        public string cargoName;
        public int cargoweight;

        public void CargoShow()
        {
            Console.WriteLine("Наименование груза : {0}", cargoName);
            Console.WriteLine("Вес груза: {0} кг", cargoweight);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
                Ship Ship1 = new Ship("Ship №1", 60, 25, 11500, Material.Steel.ToString(), Engine.Combustion.ToString());
                Ship Ship2 = new Ship("Ship №2", 65, 30, 13800, Material.Steel.ToString(), Engine.Combustion.ToString());
                Ship Ship3 = new Ship("Ship №3", 50, 32, 9300, Material.Steel.ToString(), Engine.Combustion.ToString());
                Steamboat Steamboat1 = new Steamboat("Steamboat №1", 30, 110, 55000, Material.Steel.ToString(), Engine.Steam.ToString());
                Steamboat Steamboat2 = new Steamboat("Steamboat №2", 40, 150, 58500, Material.Steel.ToString(), Engine.Steam.ToString());
                Steamboat Steamboat3 = new Steamboat("Steamboat №3", 47, 170, 59900, Material.Steel.ToString(), Engine.Steam.ToString());
                Sailboat Sailboat1 = new Sailboat("Sailboat №1", 85, 7, 2500, Material.Plastic.ToString(), Engine.Wind.ToString());
                Sailboat Sailboat2 = new Sailboat("Sailboat №2", 90, 9, 2900, Material.Plastic.ToString(), Engine.Wind.ToString());
                Sailboat Sailboat3 = new Sailboat("Sailboat №3", 75, 11, 3500, Material.Plastic.ToString(), Engine.Wind.ToString());
                Corvette Corvette1 = new Corvette("Corvette №1", 50, 10, 24000, Material.Titan.ToString(), Engine.Combined.ToString());
                Corvette Corvette2 = new Corvette("Corvette №2", 50, 10, 25800, Material.Steel.ToString(), Engine.Combustion.ToString());
                Corvette Corvette3 = new Corvette("Corvette №3", 50, 10, 28690, Material.Steel.ToString(), Engine.Combustion.ToString());
                Boat Boat1 = new Boat("Boat №1", 20, 4, 150, Material.Wood.ToString(), Engine.Physical.ToString());
                Boat Boat2 = new Boat("Boat №2", 25, 3, 110, Material.Wood.ToString(), Engine.Physical.ToString());
                Boat Boat3 = new Boat("Boat №3", 30, 2, 90, Material.Wood.ToString(), Engine.Physical.ToString());
                Boat boat4 = new Boat();
           
            Capitan cap1 = new Capitan("Jonathan Meyer", 57, 5);
            Capitan cap2 = new Capitan("Benny Barker", 48, 7);
            Capitan cap3 = new Capitan("Reginald Collier", 49, 2);
            Capitan cap4 = new Capitan("Edward Santiago", 63, 3);
            Capitan cap5 = new Capitan("Bernard Ingram", 62, 2);
            Capitan cap6 = new Capitan("Trevor Pittman", 25, 5);
            Capitan cap7 = new Capitan("Christopher Dunn", 46, 5);
            Capitan cap8 = new Capitan("Bill Harvey", 19, 3);
            Capitan cap9 = new Capitan("Kristopher Beck", 25, 4);
            Capitan cap10 = new Capitan("Josh Walters", 20, 8);
            Capitan cap11 = new Capitan("Neal Freeman", 47, 3);
            Capitan cap12 = new Capitan("Leland Zimmerman", 28, 4);
            Capitan cap13 = new Capitan("Luther Mason", 24, 5);
            Capitan cap14 = new Capitan("Ruth Copeland", 27, 7);
            Capitan cap15 = new Capitan("Connie Douglas", 35, 5);

            Ship1.appointCap(cap1);
            Ship2.appointCap(cap2);
            Ship3.appointCap(cap3);
            Steamboat1.appointCap(cap4);
            Steamboat2.appointCap(cap5);
            Steamboat3.appointCap(cap6);
            Sailboat1.appointCap(cap7);
            Sailboat2.appointCap(cap8);
            Sailboat3.appointCap(cap9);
            Corvette1.appointCap(cap10);
            Corvette2.appointCap(cap11);
            Corvette3.appointCap(cap12);
            Boat1.appointCap(cap13);
            Boat2.appointCap(cap14);
            Boat3.appointCap(cap15);

            Port port = new Port();
            
            port.PortList.Add(Ship1);
            port.PortList.Add(Ship2);
            port.PortList.Add(Ship3);
            port.PortList.Add(Steamboat1);
            port.PortList.Add(Steamboat2);
            port.PortList.Add(Steamboat3);
            port.PortList.Add(Sailboat1);
            port.PortList.Add(Sailboat2);
            port.PortList.Add(Sailboat3);
            port.PortList.Add(Corvette1);
            port.PortList.Add(Corvette2);
            port.PortList.Add(Corvette3);
            port.PortList.Add(Boat1);
            port.PortList.Add(Boat2);
            port.PortList.Add(Boat3);
            try
            {
                if (port.PortList.Count < 1) throw new MyOwnException("Порт пустой, необходимо добавить в порт водный транспорт");
            }
            catch(MyOwnException ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
            }
            finally
            {
                Console.WriteLine("finally");
            }
            // PortManager.PrintList(port.PortList);
                PortManager.AvDis(port.PortList);
                PortManager.AvCre(port.PortList);
                PortManager.CapShip35(port.PortList);
            // Console.WriteLine(cap3.ToString());
            // Console.WriteLine(s1.ToString());
            /*
             s1.appointCap(cap3);
             s2.appointCap(cap3);
            */
            // Console.WriteLine(cap3.ToString());
            //Console.WriteLine(s1.ToString());
            /*
            if (b3 is Transport && cap3 is Capitan) b3.appointCap(cap1);
            else Console.WriteLine("Неправельные объекты! Надо <Транспорт>.appointCap(<Капитан>)");
            */
            /*
            b3.appointCap(cap1);
            s3.appointCap(cap2);
            ss3.appointCap(cap3);
            b3.ToString();
            s3.ToString();
            ss3.ToString();*/
            /*
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
                 bv3.Print();*/
            /*   
          object[] ArrObj = new object[] { b3, s3, ss3, c3, b1 };

          Printer Print = new Printer();

          foreach (Transport forObj in ArrObj)
              Print.iAmPrinting(forObj);
              */
            

            Console.WriteLine("Всего число транспортов: {0}", Transport.count);
            Console.WriteLine("Всего число капитанов: {0}", Capitan.countCap);
            Console.ReadKey();


            /*
                                    Лабораторная работа №7
Задание
Дополнить предыдущую лабораторную работу № 6. 
Создать иерархию классов исключений (собственных) –  3  типа и более. Сделать наследование пользовательских типов 
исключений от стандартных классов .Net (например Exception).
Сгенерировать и обработать как минимум пять различных исключительных ситуаций на основе своих и стандартных исключений.
Например, не позволять при инициализации объектов передавать неверные данные, обрабатывать ошибки при работе с памятью и 
ошибки работы  с файлами, деление на ноль, неверный индекс, нулевой указатель и т. д.
В конце поставить универсальный обработчик catch.
Обработку исключений вынести в main. При обработке выводить специфическую информацию о месте, диагностику и причине 
исключения. Последним должен быть блок, который отлавливает все исключения (finally).
Добавьте код в одной из функций макрос Assert. Объясните что он проверяет, как будет выполняться программа в случае
не выполнения условия. Объясните назначение Assert. 
Пример:
int[] aa= null;
            Debug.Assert(aa !=null, "Values array cannot be null");

Не забудьте подключить using  System.Diagnostics;

            */
        }
    }
}