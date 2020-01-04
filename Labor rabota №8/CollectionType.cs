using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labor_rabota__8
{
   public class CollectionType<T> :IGenInterface<T>
        where T: class
     {
        public dynamic[] ctVec = new dynamic[n];
        static int n = 20;
        static int index = 0;
        static bool removeBool=false;

       public void AddEl(T elem)
        {
            foreach (var ctVecList in ctVec)
            {
                if (elem == ctVecList) { Console.WriteLine("Данный элемент \"{0}\" уже находится в списке",elem); return; }
            }
            ctVec[index] = elem;
            index++;
        }

        public void Remove(T elem)
        {
            for (int i = 0; i < ctVec.Length; i++)
            {
                if (elem == ctVec[i])
                {
                    removeBool = true;
                    for(; i < ctVec.Length; i++)
                    {
                        if (i == ctVec.Length - 1) { ctVec[i] = null; break; }
                        ctVec[i] = ctVec[i + 1];
                    }
                }
            }
            if (removeBool)
            {
                index--;
                removeBool = false;
            }
            try
            {
                if (!removeBool) throw new Exception ("Данного элемента \""+ elem +"\" нет в списке.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
            }
        }

        public void Print()
        {
            try
            {
                if (index == 0) throw new Exception("Список пуст");
                foreach (var ctVecList in ctVec)
                {
                    Console.Write(ctVecList + "\t");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
            }
            finally
            {
                Console.WriteLine("\nEnd of work with exceptions");
            }
        }
    }
}
