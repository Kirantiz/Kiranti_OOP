using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace kombinator_algoritm
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Генератор подмножеств
            /*    int count = 0;
               int number=0;
               for (byte i=0; i < 256; i++)
               {
                   string output="";
                  // if (output == "11111111") break;
                   BitArray bitArray = new BitArray(new byte[] { i });
                    //output = "";
                   foreach (bool value in bitArray)
                   {
                       output += value ? "1" : "0";
                   }
                   count++;
                   Console.WriteLine(output);
                 //  number = Convert.ToInt32(output);
                   if (output == "11111111") break;
               }

               Console.WriteLine("Всего {0} комбинаций", count);
               Console.ReadKey();*/
            #endregion
            Random rand = new Random();
            int sudno = 0 ;
            string str ="" ;
            int m1, m2, m3, m4, m5 ,k1,k2,k3,k4,k5,k6,k7;
            //k1 = rand.Next(50, 850);
            //k2 = rand.Next(50, 850);
            //k3 = rand.Next(50, 850);
            //k4 = rand.Next(50, 850);
            //k5 = rand.Next(50, 850);
            //k6 = rand.Next(50, 850);
            //k7 = rand.Next(50, 850);
            int[] kon = new int[8] { rand.Next(50, 850), rand.Next(50, 850), rand.Next(50, 850), rand.Next(50, 850), rand.Next(50, 850), rand.Next(50, 850), rand.Next(50, 850), rand.Next(50, 850) };
            int sum=0, result=0;
            for (int i = 0; i <99999; i++)
            {
                str= Convert.ToString(sudno, 8);
                if (str.Length < 5) str= str.Insert(0, "0");
                if (str.Length < 5) str = str.Insert(0, "0");
                if (str.Length < 5) str = str.Insert(0, "0");
                if (str.Length < 5) str = str.Insert(0, "0");
                if (str.Length < 5) str = str.Insert(0, "0");
                str.
                m1 = Convert.ToInt32( str[0]);
                m2 = Convert.ToInt32( str[1]);
                m3 = Convert.ToInt32( str[2]);
                m4 = Convert.ToInt32(str[3]);
                m5 = Convert.ToInt32(str[4]);

                sum = kon[m1] + kon[m2] + kon[m3] + kon[m4] + kon[m5];
                if (result < sum) result = sum;
                Console.WriteLine(str+" "+sum);
                if (str == "77777") break;
                sudno++;
            }

            Console.WriteLine(str);


            Console.ReadKey();
        }
    }
}
