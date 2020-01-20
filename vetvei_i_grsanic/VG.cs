using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vetvei_i_grsanic
{
   public class VG    //
    {

        public static int F; //Нижняя граница длины кратчайшего кольцевого маршрута

        public static double[,] privTav(double[,] massif) //Приведение таблицы
        {
            double[] minStroka = new double[5] {massif[0,0], massif[1,0] ,massif[2, 0],massif[3, 0],massif[4, 0] };
            
            int sumMinStr=0;
            int sumMinSto = 0;
            int tempMin;

            for (int i =0; i < 5; i++)      //Определяем минимум в строках и записываем в сумму Ф
            {
                for(int j=0; j < 5; j++)
                {
                    if (minStroka[i] > massif[i, j]) minStroka[i] = massif[i, j];
                }
                sumMinStr += Convert.ToInt32(minStroka[i]);
            }

            for (int i = 0; i < 5; i++)     // Приведение таблицы по строкам
            {
                for (int j = 0; j < 5; j++)
                {
                    massif[i, j] -= minStroka[i];
                }
            }

            for (int i = 0; i < 5; i++)     // вывод таблицы на консоль
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write(massif[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine(); Console.WriteLine();
            double[] minStolb = new double[5] { massif[0, 0], massif[0, 1], massif[0, 2], massif[0, 3], massif[0, 4] };
            for (int j = 0; j < 5; j++) // Определение минимума в столбцах и суммируем с Ф
            {
                for (int i = 0; i < 5; i++)
                {
                    if (minStolb[j] > massif[i, j]) minStolb[j] = massif[i, j];
                }
                sumMinStr += Convert.ToInt32(minStolb[j]);
            }

            for (int i = 0; i < 5; i++) // вывод констант приведения столбцов
            {
                Console.Write(minStolb[i]+"\t");
            }
            Console.WriteLine();
            for (int i = 0; i < 5; i++)     // Приведения таблицы по столбцам
            {
                for (int j = 0; j < 5; j++)
                {
                    massif[j, i] -= minStolb[i];
                }
            }

            for (int i = 0; i < 5; i++)     // вывод таблицы на консоль
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write(massif[i,j] + "\t");
                }
                Console.WriteLine();
            }




            for (int i = 0; i < 5; i++)     // вывод констант приведения рядов
            {
                Console.WriteLine(minStroka[i]);
            }

            double[,] tempM = new double[5, 5]; // создание временного массива

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    tempM[i, j] = massif[i, j];
                }
            }

            int FiTemp=0;
            int tempI=0, tempJ=0;
            for (int i = 0; i < 5; i++)
            {
              //  tempM = massif;
                for (int j = 0; j < 5; j++)
                {
                     if (massif[i, j] == 0)
                    {
                        tempM[i, j] = 9999;
                        if (Fi(tempM) > FiTemp) { FiTemp = Fi(tempM);tempI = i;tempJ = j; }
                        tempM[i, j] = massif[i, j];
                    }
                }
            }
            for (int i = 0; i < 5; i++)     // вывод таблицы на консоль
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write(massif[i, j] + "\t");
                }
                Console.WriteLine();
            }

            
            /*   double[,] mas2 = new double[4, 4];
               int countI=0; int countJ = 0; 
               for (int i = 0; i < 5; i++)
               {
                   for (int j=0;j<5; j++)
                   {
                       if (j == countJ) continue;
                       mas2[i, j] = massif[i,j];

                   }
               }
               Console.WriteLine("табличка");
               for (int i = 0; i < 4; i++)     // вывод таблицы на консоль
               {
                   for (int j = 0; j < 4; j++)
                   {
                       Console.Write(mas2[i, j] + "\t");
                   }
                   Console.WriteLine();
               }
               */
            Console.WriteLine($"Строка {tempI} и Столбец {tempJ}");
            Console.WriteLine("Fi maks = {0}", FiTemp);
            Console.WriteLine("Summa min = {0}", sumMinStr);
            return massif;
        }


        public static int Fi(double[,] mas)
        {

            double[] minStroka = new double[5] { double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity };
            double[] minStolb = new double[5] { double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity };
            int Fi=0;
            for (int i = 0; i < 5; i++)      //Определяем минимум в строках и записываем в сумму Ф
            {
                for (int j = 0; j < 5; j++)
                {
                    if (minStroka[i] > mas[i, j]) minStroka[i] = mas[i, j];
                }
                Fi += Convert.ToInt32(minStroka[i]);
            }

            for (int j = 0; j < 5; j++) // Определение минимума в столбцах и суммируем с Ф
            {
                for (int i = 0; i < 5; i++)
                {
                    if (minStolb[j] > mas[i, j]) minStolb[j] = mas[i, j];
                }
                Fi += Convert.ToInt32(minStolb[j]);
            }
            Console.WriteLine(Fi);
            return Fi;
        }
    }

    
}
