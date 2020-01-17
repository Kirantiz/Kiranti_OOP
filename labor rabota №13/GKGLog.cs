using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;


namespace labor_rabota__13
{
    
   public class GKGLog
    {
       public static DateTime nowTime = DateTime.Now;
        public void CreateFIle(string path)
        {
            DateTime t = DateTime.Now;
            string time =t.ToString();
            string name = Path.GetFileName(path);
            string path1 = Path.GetFullPath(path);
            using (var sw = new StreamWriter("GKGlogfile.txt",true))
            {
                sw.Write("Имя файла: "+name+"\t");
                sw.Write("Адрес файла: "+path1+"\t");
                sw.WriteLine("Время: "+time);
            }
        }

        public void FindLogHour()
        {
            using(var rw = new StreamReader("GKGlogfile.txt"))
            {
                Console.WriteLine("Лог действия с файлами за последний чаc: ");
                string line;
                string datline;
                int count = 0;
             //   int countH = 0;

                while ((line = rw.ReadLine()) != null)
                {
                    datline = line.Remove(0, 107);
                    DateTime dat = DateTime.Parse(datline);
                    count++;
                    if (dat > nowTime.AddHours(-0.5))
                    {
                       // countH++;
                        Console.WriteLine("{1}) {0}",line,count);
                    }
                }
            }
        }

        public void FindLogTime(DateTime time1, DateTime time2)
        {
            using (var rw = new StreamReader("GKGlogfile.txt"))
            {
                Console.WriteLine($"Лог действия с файлами в промежутке от {time1} до {time2}");
                string line;
                string datline;
                int count = 0;

                while ((line = rw.ReadLine()) != null)
                {
                    datline = line.Remove(0, 107);
                    DateTime dat = DateTime.Parse(datline);
                    count++;
                    if (dat > time1 && dat< time2)
                    {
                        Console.WriteLine("{1}) {0}", line, count);
                    }
                }
            }
        }

        public void FindLogWord(string str)
        {
            using (var rw = new StreamReader("GKGlogfile.txt"))
            {
                Console.WriteLine($"Лог действия с файлами в которых есть \"{str}\"");
                string line;
                int count = 0;

                while ((line = rw.ReadLine()) != null)
                {
                    count++;
                    if (line.Contains(str))
                    {
                        Console.WriteLine("{1}) {0}", line, count);
                    }
                }
            }
        }


        /*   public void creatFIleClass(string path)
           {
               using (FileStream fstream = new FileStream("D:\\University\\ООТП\\labrab13\\labrab13\\DMMlogfile.txt", FileMode.OpenOrCreate))
               {
                   FileInfo dirInfo = new FileInfo(path);
                   string name = $"\r\nНазвание файла: {dirInfo.Name}\r\n";
                   string fullname = $"Полное название файла: {dirInfo.FullName}\r\n";
                   string data = $"Время создания каталога: {dirInfo.CreationTime}\r\n";
                   fstream.Seek(0, SeekOrigin.End);
                   byte[] array = System.Text.Encoding.Default.GetBytes(name);
                   fstream.Write(array, 0, array.Length);
                   fstream.Seek(0, SeekOrigin.End);
                   byte[] array1 = System.Text.Encoding.Default.GetBytes(fullname);
                   fstream.Write(array1, 0, array1.Length);
                   byte[] array2 = System.Text.Encoding.Default.GetBytes(data);
                   fstream.Write(array2, 0, array2.Length);
               }

           }
           */
    }
}
