using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labor_rabota__12
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
                            throw new Exception("Не назначено имя транспортного средства (Автоматическое имя \"Кораблик №" + count + "\")");
                        }
                        else name = value;
                    }
                    catch (Exception ex)
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
                            throw new Exception("Скорость корабля \"" + name + "\" не может быть меньше чем 1 (Автоматически изменено на \"1\")");
                        }
                        else speed = value;
                    }
                    catch (Exception ex)
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
                            throw new Exception("Посадочных мест на корабле \"" + name + "\" не может быть меньше 1 (Автоматически изменено на \"1\")");
                        }
                        else crew = value;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: {0}", ex.Message);
                    }
                }
            }
            public int Displacement
            {
                get { return displacement; }
                set
                {
                    try
                    {
                        if (value < 1)
                        {
                            displacement = 1;
                            throw new Exception("Водоизмещение коробля \"" + name + "\" не может быть меньше 1(Автоматически изменено на \"1\")");
                        }
                        else displacement = value;
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
            public virtual void Constructor(string name, int speed, int crew, int displacement, string madeOf, string engineType)
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
            public Ship(string name, int speed, int crew, int displacement, string madeOf, string engineType)
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

        enum Engine { Steam, Combustion, Wind, Physical, Combined };
        enum Material { Plastic, Steel, Wood, Titan, Another };

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
    }

