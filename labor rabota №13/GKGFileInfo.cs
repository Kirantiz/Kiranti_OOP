using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace labor_rabota__13
{
   public static class GKGFileInfo
    {

        public static void FileInfo(string file)
        {
            //FileInfo file = new FileInfo;
            long size = file.Length;
            Console.WriteLine("Информация о файле: ");
            Console.WriteLine("Полный путь: {0}", Path.GetFullPath(file));
            Console.WriteLine("Размер файла: {0} байт", file.Length);
            Console.WriteLine("Расширение файла: {0}", Path.GetExtension(file));
            Console.WriteLine("Имя файла: {0}", Path.GetFileNameWithoutExtension(file));
            Console.WriteLine("Время создания файла {0}", File.GetCreationTime(file));

        }

    }
}
