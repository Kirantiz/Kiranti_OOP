using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace labor_rabota__12
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Задание
            /*
             
            № 12 Рефлексия
Задание
1.	Для изучения .NET Reflection API допишите класс Рефлектор, который будет содержать методы выполняющие следующие действия: 
a.	выводит всё содержимое класса в текстовый файл (принимает в качестве параметра имя класса);
b.	извлекает все общедоступные публичные методы класса (принимает в качестве параметра имя класса);
c.	получает информацию о полях и свойствах класса;
d.	получает все реализованные классом интерфейсы;
e.	выводит по имени класса имена методов, которые содержат заданный (пользователем) тип параметра (имя класса передается в качестве аргумента); 
f.	вызывает некоторый метод класса, при этом значения для его параметров необходимо прочитать из текстового файла (имя класса и имя метода передаются в качестве аргументов).

              */
            #endregion

            Reflector<testClass>.ClassInfo();
            Console.WriteLine("\n\n");
            Reflector<testClass>.MethodsInfo();
            Console.WriteLine("\n\n");
            Reflector<testClass>.FieldsandPropertiesInfo();
            Console.WriteLine("\n\n");
            Reflector<Printer>.InterfaceInfo();
            Console.WriteLine("\n\n");
            Reflector<Transport>.MethodInfo();
            Reflector<testClass>.MethodInfo();
            Reflector<Sailboat>.MethodInfo();
            //Reflector<testClass.sumXY(1,4).InMethod(),)
            testClass.sumXY(Reflector<testClass>.InMethod(), Reflector<testClass>.InMethod());
            Console.ReadKey();

        }
    }
}