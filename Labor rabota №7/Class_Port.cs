using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Labor_rabota__7
{
    public class Port
    {
        public Port()
        {
            PortList = new List<Transport>();
        }
        public List<Transport> PortList { get; set; } //= new List<Transport>
    }
}
