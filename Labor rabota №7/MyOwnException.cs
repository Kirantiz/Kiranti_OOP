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
}
