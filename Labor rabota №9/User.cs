using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labor_rabota__9
{
    class User
    {
        public static int countUser=0;
        public string name;
       public int move=0;
        public double koef = 1;
        public double compression = 1;
       public delegate void moveDel(string stat);
       public delegate double compressionDel (double step);
      public event moveDel userMove;
      public event moveDel userCompression;


      public void doList(string msg, int step)
        {
            
            
            if(msg == "go"||msg =="Go"||msg=="GO"||msg=="Иди"|| msg == "иди")
            {
                move += step;
                userMove?.Invoke("Пользователь "+name+" прошёл "+step+" метр(ов), всего путь составил "+move);
            }

            if(msg == "compression"|| msg =="Compression"|| msg =="Сжать"|| msg =="сжать")
            {
                koef += (double)step / 100;
                userCompression?.Invoke("Пользователь " + name + " был сжат. Коэффициент сжатия составил: "+koef);
            }
        
        
        }

        public User()
        {
            countUser++;
            this.name = "User №" + countUser;
        }
    }

}
