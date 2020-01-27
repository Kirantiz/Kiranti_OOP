using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vetvei_i_grsanic
{
    class Program
    {
        static void Main(string[] args)
        {
              int n = 8;
              double[,] komi = new double[5, 5] { { double.PositiveInfinity, 2*n, 21+n,double.PositiveInfinity,n },
                  { n, double.PositiveInfinity, 15+n,68-n, 84-n },
                  { 2+n, 3*n, double.PositiveInfinity, 86,49+n }, 
                  { 17+n, 58-n, 4*n,double.PositiveInfinity,n*3 },
                  { 93-n, 66+n, 52,13+n,double.PositiveInfinity} };

              double[,] primer = new double[5, 5] { { double.PositiveInfinity,9,8,4,10 },
                  {6,double.PositiveInfinity,4,5,7 },
                  {5,3,double.PositiveInfinity,6,2 },
                  {1,7,2,double.PositiveInfinity, 8 },
                  {2,4,5,2,double.PositiveInfinity } };


              for (int i = 0; i < 5; i++)
              {
                  for (int j = 0; j < 5; j++)
                  {
                      Console.Write(komi[i, j] + "\t");
                  }
                  Console.WriteLine();
              }
              Console.WriteLine();
              VG.privTav(komi);
              



            Console.ReadKey();

        }
    }
}
