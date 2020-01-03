using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labor_rabota__6
{
    public static class PortManager
    {
        public static void PrintList(List<Transport> _port)
        {
            foreach (var printList in _port) Console.WriteLine(printList.Name);
        }
        
        public static void AvDis(List<Transport> _port)
        {
            double sumAvDis = 0;
            int countAvDis = 0;
            foreach (var printList in _port)
            {
                if (printList is Sailboat)
                {
                    sumAvDis += printList.Displacement;
                    countAvDis++;
                }
            }
            Console.WriteLine("Среднее водоизмещение всех парусников в порту: {0:##.##}", sumAvDis / countAvDis);
        }
        
        public static void AvCre(List<Transport> _port)
        {
            double sumAvCre = 0;
            int countAvCre = 0;
            foreach (var printList in _port)
            {
                if (printList is Steamboat)
                {
                    sumAvCre += printList.Crew;
                    countAvCre++;
                }
            }
            Console.WriteLine("Среднее количество посадочных мест на параходах: {0:##.##}", sumAvCre / countAvCre);        
        }

        public static void CapShip35(List<Transport> _port)
        {
            int countCap = 0;
            Console.WriteLine("Список названий всех кораблей на которых капитаны моложе 35 лет :\n");
            foreach(var printList in _port)
            {
                if (printList.ageCap <= 35)
                {
                    countCap++;
                    Console.WriteLine("Название корабля: {0}", printList.Name);
                }
            }
            Console.WriteLine("Всего кораблей на которых капитаны моложе 35 лет : {0}", countCap);
        }
    }
}
