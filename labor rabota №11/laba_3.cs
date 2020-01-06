using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labor_rabota__11
{
    class Airline
    {
        private string name;
        private string destination;
        private byte flight;
        private string typeAirplane;
        private float dateTime;
        private string dayWeek;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Destination
        {
            get { return destination; }
            set { destination = value; }
        }
        public byte Flight
        {
            get { return flight; }
            set
            {
                if (value < 1)
                    flight = 1;
                else flight = value;
            }
        }
        public string TypeAirplane
        {
            get { return typeAirplane; }
            set { typeAirplane = value; }
        }
        public float DateTime
        {
            get { return dateTime; }
            set
            {
                if (value > 24.59f) dateTime = 24.59f;
                else if (value % 1 * 100 > 59)
                {
                    dateTime = Convert.ToInt32(dateTime);
                }
                else dateTime = value;
            }
        }
        public string DayWeek
        {
            get { return dayWeek; }
            set
            { dayWeek = value; }
        }

        public static int count = 0;
        readonly static string week = "mo tu we th fr sa su";

        public Airline(string _def)
        {
            Name = "belavia";
            Destination = "Minsk";
            Flight = 3;
            TypeAirplane = "boing 747";
            DateTime = 21.30f;
            DayWeek = "mon, wed";
            count++;
        }
        static Airline()
        {
            Console.WriteLine("Статичный контсруктор");

        }

        public Airline() //пустой
        {
            count++;
        }

        public Airline(string name, string destination, byte flight, string typeAirplane, float dateTime, string dayWeek) //по умолчанию
        {
            this.Name = name;
            this.Destination = destination;
            this.Flight = flight;
            this.TypeAirplane = typeAirplane;
            this.DateTime = dateTime;
            this.DayWeek = dayWeek;
            count++;
        }


        public void Print()
        {
            Console.WriteLine("Name: " + Name + "\t\tHash code: {0}", Name.GetHashCode());
            Console.WriteLine("destination: " + Destination + "\tHash code: {0}", Destination.GetHashCode());
            Console.WriteLine("flight: " + Flight + "\t\tHash code: {0}", Flight.GetHashCode());
            Console.WriteLine("typeAirplane: " + TypeAirplane + "\tHash code: {0}", TypeAirplane.GetHashCode());
            Console.WriteLine("dateTime: " + DateTime + "\t\tHash code: {0}", DateTime.GetHashCode());
            Console.WriteLine("dayWeek: " + DayWeek + "\tHash code: {0}", DayWeek.GetHashCode());
        }


    }
}
