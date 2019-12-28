using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labor_rabota__4
{

    class Vector
    {
        public double[] vector;//поле
        public static Random rnd = new Random();
        public static int count = 1;
        public class Owner
        {
            int ID = 00110;
            string name = "Name";
            string organiz = "Organiz";
        }

        
 
         public void Print()                      //вывыдим вектор в консоль
        {
            Console.WriteLine("Вектор №{0}", count); count++;
            for (int i = 0; i < this.vector.Length; ++i)
            {
                Console.Write(this.vector[i] + "\t");   
            }
            Console.WriteLine("\n");

        }
       public double SetRandom(int _ot, int _do)     //заполнение случайными числами
        {
            return Math.Round((double)rnd.Next(_ot, _do) / 100 + (double)rnd.Next(_ot, _do), 2); // сотая рандомная часть + рандомная часть округлённая до 2 знаков после ,
        }

        public Vector()                             //конструктор
        {
           int n = 4;
            vector = new double[n];
            for (int i = 0; i < 4; i++)
                vector[i] = SetRandom(-100, 100);
        }
        public Vector(int n)                        //конструктор
        {
            vector = new double[n];
            for (int i = 0; i < n; i++)
                vector[i] = SetRandom(-100, 100);
        }
        public void Summa(double[] vec1, double[] vec2)             // сложение векторов
        {
            Console.WriteLine("\nСумма векторов: ");
            int maxLength = 0;
            if (vec1.Length > maxLength) maxLength = vec1.Length;
            if (vec2.Length > maxLength) maxLength = vec2.Length;
            double[] vec3 = new double[maxLength];

            for (int i = 0; i < maxLength; i++)
            {
                if (i >= vec1.Length) { vec3[i] = vec2[i]; Console.Write("{0}\t", vec3[i]); continue; }
                if (i >= vec2.Length) { vec3[i] = vec1[i]; Console.Write("{0}\t", vec3[i]); continue; }
               vec3[i]=vec1[i] + vec2[i];
                Console.Write("{0}\t", vec3[i]);
            }
        }
        public void Summa(double[] vec1, double[] vec2, double[] vec0)             // сложение векторов
        {
            Console.WriteLine("\nСумма векторов: ");
            int maxLength = 0;
            if (vec1.Length > maxLength) maxLength = vec1.Length;
            if (vec2.Length > maxLength) maxLength = vec2.Length;
            if (vec0.Length > maxLength) maxLength = vec0.Length;

            double[] vec3 = new double[maxLength];

            for (int i = 0; i < maxLength; i++)
            {
                if (i >= vec1.Length && i >= vec0.Length) { vec3[i] = vec2[i]; Console.Write("{0}\t", vec3[i]); continue; }
                if (i >= vec2.Length && i >= vec0.Length) { vec3[i] = vec1[i]; Console.Write("{0}\t", vec3[i]); continue; }
                if (i >= vec1.Length && i >= vec2.Length) { vec3[i] = vec0[i]; Console.Write("{0}\t", vec3[i]); continue; }
                if (i >= vec0.Length) { vec3[i] = vec1[i] + vec2[i]; Console.Write("{0}\t", vec3[i]); continue; }
                if (i >= vec1.Length) { vec3[i] = vec0[i] + vec2[i]; Console.Write("{0}\t", vec3[i]); continue; }
                if (i >= vec2.Length) { vec3[i] = vec1[i] + vec0[i]; Console.Write("{0}\t", vec3[i]); continue; }
                vec3[i] = vec1[i] + vec2[i]+vec0[i];
                Console.Write("{0}\t", vec3[i]);
            }
        }
        public double[] Copy(double[] vec1)             // копирование вектора
        {
            Console.WriteLine("\nСкопированный вектор: ");

            double[] vecCopy = new double[vec1.Length];

            for (int i = 0; i < vec1.Length; i++)
            {
                vecCopy[i] = vec1[i];
                Console.Write("{0}\t", vecCopy[i]);
            }
            return vecCopy;
        }

        public void sravnVec(double[] vec1, double[] vec2)      //сравнение векторов
        {
            int sravnCount =0;
            int maxLength = 0;
            if (vec1.Length > vec2.Length) { maxLength = vec1.Length; Console.WriteLine("\nДлинна первого вектора больше второго вектора на\t {0} элементов", vec1.Length - vec2.Length); }
            if (vec2.Length > vec1.Length) { maxLength = vec2.Length; Console.WriteLine("Длинна второго вектора больше первого вектора на\t {0} элементов", vec2.Length - vec1.Length); }
            if (vec1.Length == vec2.Length) { maxLength = vec1.Length; Console.WriteLine("Длинны векторов равны"); }
            
            for(int i =0; i < maxLength; i++)
            {
                if (i >= vec1.Length || i >= vec2.Length) break;
                if(vec1[i] == vec2[i])
                {
                    sravnCount++;
                }
            }
            if (sravnCount == maxLength) Console.WriteLine("Вектор 1 равен вектору 2");
            else Console.WriteLine("Вектор 1 совпадает с вектором 2 на\t {0} элементов из {1}", sravnCount, maxLength);
            if (sravnCount == 0) Console.WriteLine("Совпадений элементов не обнаружено");
            
        }

        public void CheckEm(double[] vec1)
        {
            if (vec1.Length == 0) Console.WriteLine("Вектор пустой");
            else Console.WriteLine("Вектор не пустой");
        }               //проверка пустой ли вектор

        public double[] CutVec(double[] cutV, int cut)
        {
            Console.WriteLine("\nВырезанный вектор:\n");
            for(int i = 0;i<cutV.Length-cut; i++)
            {
                if (cut >= cutV.Length) { Console.WriteLine("Вырезана вся строка");break; }
                cutV[i] = cutV[i + cut];
                Console.Write("{0} ",cutV[i]);
            }
            return cutV;
        }       // усечение строки сначала

        public double[] CutPlus(double[] cutP)                  // удаление положительных элементов
        {
            Console.WriteLine("\n\nВектор без положительных элементов: ");
            int n = 0;

            for(int i =0; i < cutP.Length; i++)
            {
                if(cutP[i]>0)
                {
                    n++;
                    continue;
                }
                cutP[i-n] = cutP[i];
            }
            double[] vecNoPlus = new double[cutP.Length-n];
            for(int i =0;i< cutP.Length - n; i++)
            {
                vecNoPlus[i] = cutP[i];
            }
            return vecNoPlus;
        }

       public class Data
        {
            public static void DataT()
            {
                DateTime dateCreate = new DateTime(2019, 12, 27, 15,44,00); 
                Console.WriteLine("\n\nДата создания - {0}",dateCreate);
            }
            }
    }



    class Program
    {
        static void Main(string[] args)
        {
            Vector v = new Vector(10);
            Vector v2 = new Vector(7);
            Vector v3 = new Vector(6);

              v.Print();
              Console.WriteLine();
             /* v2.Print();
              v3.Print();
              v.Summa(v.vector, v2.vector, v3.vector);
              v.sravnVec(v.vector, v2.vector);
              v.CheckEm(v.vector);
              v.CutVec(v.vector, 2);*/
           Console.WriteLine("\nМаксимальный элемент вектора: {0}", MathOperation.MaxEl(v.vector));
            Console.WriteLine("Минимальный элемент вектора: {0}", MathOperation.MinEl(v.vector));
            Console.WriteLine("Всего элементов в векторе: {0}", MathOperation.SizeVec(v.vector));


            foreach (double cutcut in v.CutPlus(v.vector))
                Console.Write(cutcut + " ");
            Vector.Data.DataT();

            Console.ReadKey();


            /* Лабораторная работа № 4 
             * Перегрузка операций, методы расширения и вложенные типы
 Задание

 1)	Создать заданный в варианте класс.Определить в классе необходимые методы, конструкторы, индексаторы и заданные
 перегруженные операции.Написать программу тестирования, в которой проверяется использование перегруженных операций.
 2)	Добавьте в свой класс вложенный объект Owner, который содержит Id, имя и организацию создателя. Проинициализируйте его
 3)	Добавьте в свой класс вложенный класс Date(дата создания).Проинициализируйте

 4)	Создайте статический класс MathOperation, содержащий 3 метода для работы с вашим классом(по варианту п.1):
 поиск максимального, минимального, подсчет количества элементов.
 5)	 Добавьте к классу MathOperation методы расширения для типа string и  вашего типа из задания№1.См.задание по вариантам.  
 */
            /*          Вариант №15
                  Класс - Bектор.Дополнительно перегрузить следующие операции: +-сложение векторов; > -сравнение векторов; = = -копирование вектора, true - проверка, пустой ли вектор
      Методы расширения:
                  1)	Усечение строки с начала
      2)	Удаление положительных элементов из вектора*/
        }
    }
    static class MathOperation
    {

        public static double MaxEl(double[] vecMax)
        {
            double max=vecMax[0];
            for(int i =0; i < vecMax.Length; i++)
            {
                if (max < vecMax[i]) max = vecMax[i];
            }
            return max;
        }

        public static double MinEl(double[] vecMin)
        {
            double min = 0;
            for (int i=0; i < vecMin.Length; i++)
            {
                if (min > vecMin[i]) min = vecMin[i];
            }
            return min;
        }

        public static double SizeVec(double[] vecSize)
        {
            return vecSize.Length;
        }
    }
}
