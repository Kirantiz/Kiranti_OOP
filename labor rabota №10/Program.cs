using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Collections;
using System.Collections.Specialized;

namespace labor_rabota__10
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Задание
            /*
                    Лабораторная работа №10
                        Коллекции 
Задание
1.	Создать необобщенную коллекцию ArrayList. 
a.	Заполните ее 5-ю случайными целыми числами
b.	Добавьте к ней строку
c.	Добавьте объект типа Student
d.	Удалите заданный элемент
e.	Выведите количество элементов и коллекцию на консоль.
f.	Выполните поиск в коллекции значения
2.	Создать обобщенную коллекцию в соответствии с вариантом задания и заполнить ее данными, тип которых определяется
вариантом задания (колонка – первый тип). 
a.	Вывести коллекцию на консоль
b.	Удалите из коллекции n последовательных элементов 
c.	Добавьте другие элементы (используйте все возможные методы добавления для вашего типа коллекции). 
d.	Создайте вторую коллекцию (см. таблицу) и заполните ее данными из первой коллекции. 
e.	Выведите вторую коллекцию на консоль. В случае не совпадения количества параметров (например, LinkedList<T> и
Dictionary<Tkey, TValue>), при нехватке  - генерируйте ключи, в случае избыточности – оставляйте TValue.
f.	Найдите во второй коллекции заданное значение.
3.	Повторите задание п.2 для пользовательского типа данных (в качестве типа T возьмите любой свой класс из лабораторной №5
(Наследование…. ). Не забывайте о необходимости реализации интерфейсов (IComparable, ICompare,….). При выводе коллекции
используйте цикл  foreach.
4.	Создайте объект наблюдаемой коллекции  ObservableCollection<T>. Создайте  произвольный метод  и зарегистрируйте его 
на событие CollectionChange. Напишите демонстрацию с добавлением и удалением элементов. В качестве типа T используйте 
свой класс из лабораторной №5 Наследование….

             */
            #endregion
            //1)
            ArrayList list = new ArrayList();
            Random rand = new Random();
            for (int i = 0; i < 5; i++)
            {
                list.Add(rand.Next(0, 100));
                Console.Write("{0} ", list[i]);
            }
            list.Add("String");
            object student = new object();
            list.Add(student);
            list.RemoveAt(2);

            Console.WriteLine("\nЧисло элементов: {0}", list.Count);
            Console.WriteLine(list.Contains(student));

            foreach (object listList in list)
            {
                Console.Write(" " + listList);
            }
            Console.Write("\n\n");
            //2)

            List<long> ListL = new List<long>();
            for (int i = 0; i < 10; i++)
            {
                ListL.Add(rand.Next(0, 100));
            }


            int n = 4;
            ListL.RemoveRange(3, n);    // от 3 индекса удаляет n(4) элемента
            ListL.Add(rand.Next(0, 111));

            SortedSet<long> Sorset = new SortedSet<long>();

            foreach (long lll in ListL)
            {
                Sorset.Add(lll);
                Console.Write(lll + " ");
            }

            Console.WriteLine("\n");
            foreach (long sor in Sorset)
            {
                Console.Write(sor + " ");
            }
            long x;

            Sorset.TryGetValue(14, out x);
            Sorset.Contains(14);
            Console.WriteLine("\n");
            // 3)
            List<Transport> ListTrans = new List<Transport>();
            Boat boat1 = new Boat("default");
            Sailboat sailboat1 = new Sailboat("default");
            Steamboat steamboat1 = new Steamboat("default");
            Corvette corve1 = new Corvette("default");
            Ship ship1 = new Ship("defautl");
            ListTrans.Add(sailboat1);
            ListTrans.Add(boat1);
            ListTrans.Add(steamboat1);
            ListTrans.Add(corve1);
            ListTrans.Add(ship1);

            foreach (var spisTrans in ListTrans)
            {
                Console.Write(spisTrans.GetType()); Console.WriteLine("\t" + spisTrans.Name);
            }

            ListTrans.RemoveRange(1, 2);    // от 1 индекса удаляет 2 элемента
            ListTrans.Add(boat1);
            ListTrans.Add(steamboat1);
            Console.WriteLine("\n");
            SortedSet<Transport> SorTrans = new SortedSet<Transport>();

            foreach (var spisTrans in ListTrans)
            {
                SorTrans.Add(spisTrans);
                Console.Write(spisTrans.Name + " ");
            }

            Console.WriteLine("\n");

            foreach (var spisTrans in SorTrans)
            {
                Console.Write(spisTrans.Name + " ");
            }

            SorTrans.Contains(boat1);
            Console.WriteLine("\n");

            //4)

            ObservableCollection<Transport> transObserv = new ObservableCollection<Transport>();

            transObserv.CollectionChanged += TransObserv_CollectionChanged;
            transObserv.Add(sailboat1);
            transObserv.Add(ship1);
            transObserv.Add(boat1);
            transObserv.Add(steamboat1);
            transObserv.Add(corve1);
            transObserv.Remove(corve1);
            transObserv.Remove(sailboat1);
 

            Console.ReadKey();
        }

        private static void TransObserv_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:         // если добавление
                    Transport newShip = e.NewItems[0] as Transport;
                    Console.WriteLine($"Добавлен новый корабль: {newShip.Name}");
                    break;
                case NotifyCollectionChangedAction.Remove: // если удаление
                    Transport oldShip = e.OldItems[0] as Transport;
                    Console.WriteLine($"Удален корабль: {oldShip.Name}");
                    break;
            }
        }
    }
}
