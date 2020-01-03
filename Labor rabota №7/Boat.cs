using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labor_rabota__7
{
    sealed partial class Boat : Transport     //класс лодка
    {
        public Boat()
        {
            Constructor();
        }

        public Boat(string _default)
        {
            Constructor("default");
        }

        public Boat(string name, int speed, int crew, int displacement, string madeOf, string engineType)
        {
            Constructor(name, speed, crew, displacement, madeOf, engineType);
            try
            {
                if (engineType == Engine.Combustion.ToString() || engineType == Engine.Steam.ToString() && madeOf == Material.Wood.ToString())
                {
                    throw new MyOwnException("Нельзя ставить двигатель основанный на сгорании ресурсов на деревянное транспортное средство"); ;
                }
            }
            catch(MyOwnException ex)
            {
                Console.WriteLine("Ошибка в конструкции корабля с именем {1}:\n{0}", ex.Message, Name);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
            }
        }
    }
}
