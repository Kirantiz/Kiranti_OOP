using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labor_rabota__8
{
    interface IGenInterface<T>
    {
        void AddEl (T e);
        void Remove(T e);
        void Print();
    }
}
