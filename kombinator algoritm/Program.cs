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
            /*
                int count = 0;
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
               Console.ReadKey();
*/
            #endregion 
            
            Random rand = new Random();

            double centr = 0, num1 = 0, num2 = 0;
            int sudno = 0 ;
            string str ="" ;
            string tstr = "";
            int dohod=0, resdohod=0;
            int m1=0, m2=0, m3=0, m4=0, m5=0 ,k1=0,k2=0,k3=0,k4=0,k5=0,d1=0,d2=0, d3 = 0, d4 = 0, d5 = 0;
           
            int[] kon = new int[8] { rand.Next(50, 850), rand.Next(50, 850), rand.Next(50, 850), rand.Next(50, 850), rand.Next(50, 850), rand.Next(50, 850), rand.Next(50, 850), rand.Next(50, 850) };
            int[] d = new int[8] { rand.Next(10, 100), rand.Next(10, 100), rand.Next(10, 100), rand.Next(10, 100), rand.Next(10, 100), rand.Next(10, 100), rand.Next(10, 100), rand.Next(10, 100) };
            int sum=0, result=0;
            for (int i = 0; i <99999; i++)
            {
                str= Convert.ToString(sudno, 8);
                if (str.Length < 5) str= str.Insert(0, "0");
                if (str.Length < 5) str = str.Insert(0, "0");
                if (str.Length < 5) str = str.Insert(0, "0");
                if (str.Length < 5) str = str.Insert(0, "0");

                tstr = str;

                #region Убираем_повторяющийся груз
                if (tstr.Contains('0'))
                {
                    tstr = tstr.Remove(tstr.IndexOf('0'),1);
                    if (tstr.Contains('0')) { sudno++; continue; }
                }

                if (tstr.Contains('1'))
                {
                    tstr = tstr.Remove(tstr.IndexOf('1'),1);
                    if (tstr.Contains('1')) { sudno++; continue; }
                }

                if (tstr.Contains('2'))
                {
                    tstr = tstr.Remove(tstr.IndexOf('2'), 1);
                    if (tstr.Contains('2')) { sudno++; continue; }
                }

                if (tstr.Contains('3'))
                {
                    tstr = tstr.Remove(tstr.IndexOf('3'), 1);
                    if (tstr.Contains('3')) { sudno++; continue; }
                }

                if (tstr.Contains('4'))
                {
                    tstr = tstr.Remove(tstr.IndexOf('4'), 1);
                    if (tstr.Contains('4')) { sudno++; continue; }
                }

                if (tstr.Contains('5'))
                {
                    tstr = tstr.Remove(tstr.IndexOf('5'), 1);
                    if (tstr.Contains('5')) { sudno++; continue; }
                }

                if (tstr.Contains('6'))
                {
                    tstr = tstr.Remove(tstr.IndexOf('6'), 1);
                    if (tstr.Contains('6')) { sudno++; continue; }
                }

                if (tstr.Contains('7'))
                {
                    tstr = tstr.Remove(tstr.IndexOf('7'), 1);
                    if (tstr.Contains('7')) { sudno++; continue; }
                }
                #endregion

                #region Переводим_строку_в_отдельные_числа
                if (str[0] == '0') m1 = 0;
                if (str[1] == '0') m2 = 0;
                if (str[2] == '0') m3 = 0;
                if (str[3] == '0') m4 = 0;
                if (str[4] == '0') m5 = 0;
                if (str[0] == '1') m1 = 1;
                if (str[1] == '1') m2 = 1;
                if (str[2] == '1') m3 = 1;
                if (str[3] == '1') m4 = 1;
                if (str[4] == '1') m5 = 1;
                if (str[0] == '2') m1 = 2;
                if (str[1] == '2') m2 = 2;
                if (str[2] == '2') m3 = 2;
                if (str[3] == '2') m4 = 2;
                if (str[4] == '2') m5 = 2;
                if (str[0] == '3') m1 = 3;
                if (str[1] == '3') m2 = 3;
                if (str[2] == '3') m3 = 3;
                if (str[3] == '3') m4 = 3;
                if (str[4] == '3') m5 = 3;
                if (str[0] == '4') m1 = 4;
                if (str[1] == '4') m2 = 4;
                if (str[2] == '4') m3 = 4;
                if (str[3] == '4') m4 = 4;
                if (str[4] == '4') m5 = 4;
                if (str[0] == '5') m1 = 5;
                if (str[1] == '5') m2 = 5;
                if (str[2] == '5') m3 = 5;
                if (str[3] == '5') m4 = 5;
                if (str[4] == '5') m5 = 5;
                if (str[0] == '6') m1 = 6;
                if (str[1] == '6') m2 = 6;
                if (str[2] == '6') m3 = 6;
                if (str[3] == '6') m4 = 6;
                if (str[4] == '6') m5 = 6;
                if (str[0] == '7') m1 = 7;
                if (str[1] == '7') m2 = 7;
                if (str[2] == '7') m3 = 7;
                if (str[3] == '7') m4 = 7;
                if (str[4] == '7') m5 = 7;
                #endregion

                sum = kon[m1] + kon[m2] + kon[m3] + kon[m4] + kon[m5];  //подсчёт веса груза
                dohod = d[m1] + d[m2] + d[m3] + d[m4] + d[m5];          //подсчёт дохода от груза

                num1 = kon[m1] + kon[m2];
                num2 = kon[m4] + kon[m5];
                //if (> kon[m4] + kon[m5]) centr = (kon[m1] + kon[m2]) / (kon[m4] + kon[m5]);
                //if (kon[m1] + kon[m2] < kon[m4] + kon[m5]) centr = (kon[m4] + kon[m5]) / (kon[m1] + kon[m2]);
                centr = num1 / num2;
                if (centr>0.95 && centr<1.05)     // центрирования веса груза
                {
                    if (result < sum)                                    //Максимальная грузовместительность
                    {
                        result = sum;
                        k1 = m1; k2 = m2; k3 = m3; k4 = m4; k5 = m5;
                    }
                }
                if (centr > 0.99 && centr < 1.01)     //центрирование груза
                {
                    if (resdohod < dohod)                               //максимальный доход
                    {
                        resdohod = dohod;
                        d1 = m1; d2 = m2; d3 = m3; d4 = m4; d5 = m5;
                    }
                }


                if (centr > 0.99 && centr < 1.01)   //показание подбора с учётом центрирования груза
                {
                    Console.WriteLine(str + "\t" + sum + "\t" + dohod);
                }
                if (str == "76543") break;
                sudno++;
            }

           // Console.WriteLine(str);
            Console.WriteLine($"Расположение груза: \nМесто №1-Контейнер №{k1}= {kon[k1]}\n" +
                $"Место №2-Контейнер №{k2+1}= {kon[k2]}\n" +
                $"Место №3-Контейнер №{k3+1}= {kon[k3]}\n" +
                $"Место №4-Контейнер №{k4+1}= {kon[k4]}\n" +
                $"Место №5-Контейнер №{k5+1}= {kon[k5]}\n");

            Console.WriteLine("Общая масса груза = {0}\n", result);

            Console.WriteLine("Максимальный доход ");
            Console.WriteLine($"Расположение груза: \nМесто №1-Контейнер №{d1}= {d[d1]}\n" +
                $"Место №2-Контейнер №{d2+1}= {d[d2]}\n" +
                $"Место №3-Контейнер №{d3+1}= {d[d3]}\n" +
                $"Место №4-Контейнер №{d4+1}= {d[d4]}\n" +
                $"Место №5-Контейнер №{d5+1}= {d[d5]}\n");
            Console.WriteLine("Общий доход = {0}\n", resdohod);
            Console.ReadKey();
        }
    }
}
