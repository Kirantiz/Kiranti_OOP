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
 
        public int Size()
        {
            return (this.vector.Length);        // возвращаем размер вектора
        }

        public void Print()                      //вывыдим вектор в консоль
        {
            Console.WriteLine("Вектор №{0}", count); count++;
            for (int i = 0; i < this.vector.Length; ++i)
            {
                Console.Write(this.vector[i] + "\t");   
            }
            Console.WriteLine();

        }
       public double SetRandom(int _ot, int _do)     //заполнение случайными числами
        {
            return Math.Round((double)rnd.Next(_ot, _do) / 100 + (double)rnd.Next(_ot, _do), 2); // сотая рандомная часть + рандомная часть округлённая до 2 знаков после ,
        }

        public Vector() //конструктор
        {
           int n = 4;
            vector = new double[n];
            for (int i = 0; i < 4; i++)
                vector[i] = SetRandom(-100, 100);
        }
        public Vector(int n) //конструктор
        {
            vector = new double[n];
            for (int i = 0; i < n; i++)
                vector[i] = SetRandom(-100, 100);
        }
        public double[] Summa(double[] vec1, double[] vec2)             // сложение векторов
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
                //vec3[0] Convert.ToDouble( vector[0]) + Convert.ToDouble( vector[0]);
            }
            return vec3;
        }
        public double[] Summa(double[] vec1, double[] vec2, double[] vec0)             // сложение векторов
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
            return vec3;
        }
    }
   
    class Program
    {
        static void Main(string[] args)
        {
            Vector v = new Vector(5);
            Vector v2 = new Vector(9);
            Vector v3 = new Vector(6);

            v.Print();
            Console.WriteLine();
            v2.Print();
            v3.Print();
            v.Summa(v.vector, v2.vector,v3.vector);

            
            Console.ReadKey();


            /* Лабораторная работа № 4 
             * Перегрузка операций, методы расширения и вложенные типы
 Задание

 1)	Создать заданный в варианте класс.Определить в классе необходимые методы, конструкторы, индексаторы и заданные
 перегруженные операции.Написать программу тестирования, в которой проверяется использование перегруженных операций.
 2)	Добавьте в свой класс вложенный объект Owner, который содержит Id, имя и организацию создателя. Проинициализируйте его
 3)	Добавьте в свой класс вложенный класс Date(дата создания).Проинициализируйте

 4)	Создайте статический класс MathOperation, содержащий 3 метода для работы с вашим классом(по варианту п.1): поиск максимального, минимального, подсчет количества элементов.
 5)	 Добавьте к классу MathOperation методы расширения для типа string и  вашего типа из задания№1.См.задание по вариантам.  
 */
            /*          Вариант №15
                  Класс - Bектор.Дополнительно перегрузить следующие операции: +-сложение векторов; > -сравнение векторов; = = -копирование вектора, true - проверка, пустой ли вектор
      Методы расширения:
                  1)	Усечение строки с начала
      2)	Удаление положительных элементов из вектора*/
        }
    }
}
