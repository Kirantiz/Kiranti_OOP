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

            for (int i = 0; i < 5; i++)         //заполнение временного массива
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
                        tempM[i, j] = double.PositiveInfinity;
                        if (Fi(tempM) > FiTemp) { FiTemp = Fi(tempM);tempI = i;tempJ = j; }
                        tempM[i, j] = massif[i, j];
                    }
                }
            }
            for (int i = 0; i < 5; i++)     // вывод таблицы на консоль
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write(tempM[i, j] + "\t");
                }
                Console.WriteLine();
            }
            tempM[tempJ, tempI]=double.PositiveInfinity;

            double[,] mas44 = new double[4, 4];     // создание таблицы в которой убираем убираем определённую строку и столбец
               int countI=0; int countJ = 0; 
               for (int i = 0; i < 5; i++)
               {
                if (i == tempI) { countI++; continue; }
                countJ = 0;
                   for (int j=0;j<5; j++)
                   {
                    if (j == tempJ) { countJ++; continue; }

                       mas44[i-countI, j-countJ] = tempM[i,j];
                    }
                }

               Console.WriteLine("табличка");
               for (int i = 0; i < 4; i++)     // вывод таблицы на консоль
               {
                   for (int j = 0; j < 4; j++)
                   {
                       Console.Write(mas44[i, j] + "\t");
                   }
                   Console.WriteLine();
               }
            Console.WriteLine();
            int step1 = Mas44min(mas44);

            Console.WriteLine("\nтабличка");
            for (int i = 0; i < 4; i++)     // вывод таблицы на консоль
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(mas44[i, j] + "\t");
                }
                Console.WriteLine();
            }

            double[,] tempMas44 = new double[4, 4]; //создаём временную таблицу и заполняем

            for(int i=0; i < 4; i++)
            {
                for(int j=0; j < 4; j++)
                {
                    tempMas44[i, j] = mas44[i, j];
                }
            }


            int FiTemp4=0, tempI4=0, tempJ4=0;
            for (int i = 0; i < 4; i++)             // по очереди заменяем каждый 0 на бесконечность
            {
                for (int j = 0; j < 4; j++)
                {
                    if (tempMas44[i, j] == 0)
                    {
                        tempMas44[i, j] = double.PositiveInfinity;
                        if (Fi4(tempMas44) > FiTemp4) { FiTemp4 = Fi4(tempMas44); tempI4 = i; tempJ4 = j; }
                        tempMas44[i, j] = mas44[i, j];
                    }
                }
            }
            mas44[tempJ4, tempI4] = double.PositiveInfinity;    //убираем невозможный обратный путь


            double[,] mas33 = new double[3, 3];     // создание таблицы в которой убираем убираем определённую строку и столбец
             countI = 0;
            for (int i = 0; i < 4; i++)
            {
                if (i == tempI4) { countI++; continue; }
                countJ = 0;
                for (int j = 0; j < 4; j++)
                {
                    if (j == tempJ4) { countJ++; continue; }

                    mas33[i - countI, j - countJ] = mas44[i, j];
                }
            }

            Console.WriteLine("\nтабличка33");
            for (int i = 0; i < 3; i++)     // вывод таблицы на консоль
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(mas33[i, j] + "\t");
                }
                Console.WriteLine();
            }

           int step2 = Mas33min(mas33); 

            Console.WriteLine("\nтабличка33");
            for (int i = 0; i < 3; i++)     // вывод таблицы на консоль
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(mas33[i, j] + "\t");
                }
                Console.WriteLine();
            }

            double[,] tempMas33 = new double[3, 3]; //создаём временную таблицу и заполняем

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    tempMas33[i, j] = mas33[i, j];
                }
            }

            int FiTemp3 = 0, tempI3 = 0, tempJ3 = 0;
            for (int i = 0; i < 3; i++)             // по очереди заменяем каждый 0 на бесконечность
            {
                for (int j = 0; j < 3; j++)
                {
                    if (tempMas33[i, j] == 0)
                    {
                        tempMas33[i, j] = double.PositiveInfinity;
                        if (Fi3(tempMas33) > FiTemp3) { FiTemp3 = Fi3(tempMas33); tempI3 = i; tempJ3 = j; }
                        tempMas33[i, j] = mas33[i, j];
                    }
                }
            }
            mas33[tempJ3, tempI3] = double.PositiveInfinity;    //убираем невозможный обратный путь


            double[,] mas22 = new double[2, 2];     // создание таблицы в которой убираем убираем определённую строку и столбец
            countI = 0;
            for (int i = 0; i < 3; i++)
            {
                if (i == tempI3) { countI++; continue; }
                countJ = 0;
                for (int j = 0; j < 3; j++)
                {
                    if (j == tempJ3) { countJ++; continue; }

                    mas22[i - countI, j - countJ] = mas33[i, j];
                }
            }

            Console.WriteLine("\nтабличка22");
            for (int i = 0; i < 2; i++)     // вывод таблицы на консоль
            {
                for (int j = 0; j < 2; j++)
                {
                    Console.Write(mas22[i, j] + "\t");
                }
                Console.WriteLine();
            }
            
            int step3 = Mas22min(mas22);

            Console.WriteLine("\nтабличка22");
            for (int i = 0; i < 2; i++)     // вывод таблицы на консоль
            {
                for (int j = 0; j < 2; j++)
                {
                    Console.Write(mas22[i, j] + "\t");
                }
                Console.WriteLine();
            }

            double[,] tempMas22 = new double[2, 2]; //создаём временную таблицу и заполняем

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    tempMas22[i, j] = mas22[i, j];
                }
            }
            /*
            int FiTemp2 = 0, tempI2 = 0, tempJ2 = 0;
            for (int i = 0; i < 2; i++)             // по очереди заменяем каждый 0 на бесконечность
            {
                for (int j = 0; j < 2; j++)
                {
                    if (tempMas22[i, j] == 0)
                    {
                        tempMas22[i, j] = double.PositiveInfinity;
                        if (Fi2(tempMas22) > FiTemp2) { FiTemp2 = Fi2(tempMas22); tempI2 = i; tempJ2 = j; }
                        tempMas22[i, j] = mas22[i, j];
                    }
                }
            }
            mas33[tempJ3, tempI3] = double.PositiveInfinity;    //убираем невозможный обратный путь
            */
            Console.WriteLine($"Строка {tempI} и Столбец {tempJ}");
            Console.WriteLine($"Строка {tempI4} и Столбец {tempJ4}");
            Console.WriteLine($"Строка {tempI3} и Столбец {tempJ3}");
            Console.WriteLine("Fi 5 maks = {0}", FiTemp);
            Console.WriteLine("Fi 4 maks = {0}", FiTemp4);
            Console.WriteLine("Fi 3 maks = {0}", FiTemp3);
           // Console.WriteLine("Fi 2 maks = {0}", FiTemp2);
            Console.WriteLine("Summa min = {0} + {1} + {2} + {3} = {4}", sumMinStr, step1,step2 ,step3,sumMinStr+ step1+step2+step3);
            return massif;
        }


        public static int Fi(double[,] mas)
        {

            double[] minStroka = new double[5] { double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity };
            double[] minStolb = new double[5] { double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity };
            int Fi = 0;
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
            return Fi;
        }

        public static int Mas44min(double[,] mas)
        {
            double[] minStroka = new double[4] { double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity };
            int sumMinStr = 0;
            
            for (int i = 0; i < 4; i++)      //Определяем минимум в строках и записываем в сумму Ф
            {
                for (int j = 0; j < 4; j++)
                {
                    if (minStroka[i] > mas[i, j]) minStroka[i] = mas[i, j];
                }
                sumMinStr += Convert.ToInt32(minStroka[i]);
            }

            for (int i = 0; i < 4; i++)     // Приведение таблицы по строкам
            {
                for (int j = 0; j < 4; j++)
                {
                    mas[i, j] -= minStroka[i];
                }
            }

            double[] minStolb = new double[4] { double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity };
            for (int j = 0; j < 4; j++) // Определение минимума в столбцах и суммируем с Ф
            {
                for (int i = 0; i < 4; i++)
                {
                    if (minStolb[j] > mas[i, j]) minStolb[j] = mas[i, j];
                }
                sumMinStr += Convert.ToInt32(minStolb[j]);
            }

            for (int i = 0; i < 4; i++)     // Приведения таблицы по столбцам
            {
                for (int j = 0; j < 4; j++)
                {
                    mas[j, i] -= minStolb[i];
                }
            }

            return sumMinStr;
        }

        public static int Fi4(double[,] mas)
        {

            double[] minStroka = new double[4] { double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity };
            double[] minStolb = new double[4] { double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity };
            int Fi = 0;
            for (int i = 0; i < 4; i++)      //Определяем минимум в строках и записываем в сумму Ф
            {
                for (int j = 0; j < 4; j++)
                {
                    if (minStroka[i] > mas[i, j]) minStroka[i] = mas[i, j];
                }
                Fi += Convert.ToInt32(minStroka[i]);
            }

            for (int j = 0; j < 4; j++) // Определение минимума в столбцах и суммируем с Ф
            {
                for (int i = 0; i < 4; i++)
                {
                    if (minStolb[j] > mas[i, j]) minStolb[j] = mas[i, j];
                }
                Fi += Convert.ToInt32(minStolb[j]);
            }
            return Fi;
        }

        public static int Fi3(double[,] mas)
        {

            double[] minStroka = new double[3] { double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity };
            double[] minStolb = new double[3] { double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity };
            int Fi = 0;
            for (int i = 0; i < 3; i++)      //Определяем минимум в строках и записываем в сумму Ф
            {
                for (int j = 0; j < 3; j++)
                {
                    if (minStroka[i] > mas[i, j]) minStroka[i] = mas[i, j];
                }
                Fi += Convert.ToInt32(minStroka[i]);
            }

            for (int j = 0; j < 3; j++) // Определение минимума в столбцах и суммируем с Ф
            {
                for (int i = 0; i < 3; i++)
                {
                    if (minStolb[j] > mas[i, j]) minStolb[j] = mas[i, j];
                }
                Fi += Convert.ToInt32(minStolb[j]);
            }
            return Fi;
        }

        public static int Mas33min(double[,] mas)
        {
            double[] minStroka = new double[3] { double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity };
            int sumMinStr = 0;

            for (int i = 0; i < 3; i++)      //Определяем минимум в строках и записываем в сумму Ф
            {
                for (int j = 0; j < 3; j++)
                {
                    if (minStroka[i] > mas[i, j]) minStroka[i] = mas[i, j];
                }
                sumMinStr += Convert.ToInt32(minStroka[i]);
            }

            for (int i = 0; i < 3; i++)     // Приведение таблицы по строкам
            {
                for (int j = 0; j < 3; j++)
                {
                    mas[i, j] -= minStroka[i];
                }
            }

            double[] minStolb = new double[3] { double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity };
            for (int j = 0; j < 3; j++) // Определение минимума в столбцах и суммируем с Ф
            {
                for (int i = 0; i < 3; i++)
                {
                    if (minStolb[j] > mas[i, j]) minStolb[j] = mas[i, j];
                }
                sumMinStr += Convert.ToInt32(minStolb[j]);
            }

            for (int i = 0; i < 3; i++)     // Приведения таблицы по столбцам
            {
                for (int j = 0; j < 3; j++)
                {
                    mas[j, i] -= minStolb[i];
                }
            }

            return sumMinStr;
        }

        public static int Mas22min(double[,] mas)
        {
            double[] minStroka = new double[2] { double.PositiveInfinity, double.PositiveInfinity };
            int sumMinStr = 0;

            for (int i = 0; i < 2; i++)      //Определяем минимум в строках и записываем в сумму Ф
            {
                for (int j = 0; j < 2; j++)
                {
                    if (minStroka[i] > mas[i, j]) minStroka[i] = mas[i, j];
                }
                sumMinStr += Convert.ToInt32(minStroka[i]);
            }

            for (int i = 0; i < 2; i++)     // Приведение таблицы по строкам
            {
                for (int j = 0; j < 2; j++)
                {
                    mas[i, j] -= minStroka[i];
                }
            }

            double[] minStolb = new double[2] { double.PositiveInfinity, double.PositiveInfinity };
            for (int j = 0; j < 2; j++) // Определение минимума в столбцах и суммируем с Ф
            {
                for (int i = 0; i < 2; i++)
                {
                    if (minStolb[j] > mas[i, j]) minStolb[j] = mas[i, j];
                }
                sumMinStr += Convert.ToInt32(minStolb[j]);
            }

            for (int i = 0; i < 2; i++)     // Приведения таблицы по столбцам
            {
                for (int j = 0; j < 2; j++)
                {
                    mas[j, i] -= minStolb[i];
                }
            }

            return sumMinStr;
        }

        public static int Fi2(double[,] mas)
        {

            double[] minStroka = new double[2] {  double.PositiveInfinity, double.PositiveInfinity };
            double[] minStolb = new double[2] {  double.PositiveInfinity, double.PositiveInfinity };
            int Fi = 0;
            for (int i = 0; i < 2; i++)      //Определяем минимум в строках и записываем в сумму Ф
            {
                for (int j = 0; j < 2; j++)
                {
                    if (minStroka[i] > mas[i, j]) minStroka[i] = mas[i, j];
                }
                Fi += Convert.ToInt32(minStroka[i]);
            }

            for (int j = 0; j < 2; j++) // Определение минимума в столбцах и суммируем с Ф
            {
                for (int i = 0; i < 2; i++)
                {
                    if (minStolb[j] > mas[i, j]) minStolb[j] = mas[i, j];
                }
                Fi += Convert.ToInt32(minStolb[j]);
            }
            return Fi;
        }

    }

    
}
