using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Labor_rabota__7
{
    public class MyOwnException :Exception
    {

        public MyOwnException() :base("This is my own exception")
        {
        }

        public MyOwnException(string message) : base(message)
        {
        }
    }

    public class MyDivideByZeroException : ApplicationException
    {
        public MyDivideByZeroException() :base("Обнаруженно деление на нуль")
        {
        }
        public MyDivideByZeroException(string message) : base(message)
        {
        }
    }

    public class WrongParameter : ApplicationException
    {
        public WrongParameter() : base("Обнаружен неправельный параметр")
        {
        }
        public WrongParameter(string message) : base(message)
        {
        }
    }
}