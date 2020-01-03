using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labor_rabota__6
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
        }
    }
}
