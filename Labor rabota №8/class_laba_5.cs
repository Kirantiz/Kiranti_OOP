using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labor_rabota__8
{
        public class Capitan<T>
        {
            private string nameCap;
            private T ageCap;
            private T termCap;
            private bool busyCap;
            public static int countCap = 0;

            public string NameCap
            {
                get { return nameCap; }
                set { nameCap = value; }
            }

            public T AgeCap
            {
                get { return ageCap; }
                set { ageCap = value; }
            }

            public T TermCap
            {
                get { return termCap; }
                set { termCap = value; }
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
                this.AgeCap = AgeCap;
                this.TermCap = TermCap;
                BusyCap = false;
            }
            public Capitan(string nameCap, T ageCap, T termCap)
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

