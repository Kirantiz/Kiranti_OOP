using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labor_rabota__7
{
   partial class Boat
    {
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
}
