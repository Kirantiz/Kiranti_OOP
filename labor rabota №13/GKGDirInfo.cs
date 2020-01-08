using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace labor_rabota__13
{
   static class GKGDirInfo
    {

        public static void DirInfo(string _patch)
        {
            int count = 0;
            int count2 = 0;
            DirectoryInfo patch = new DirectoryInfo(_patch);
            foreach (var spisok in patch.GetFiles()) count++;
            foreach (var spisok in patch.EnumerateDirectories()) count2++;

            Console.WriteLine("Количество файлов в директории: {0}", count);
            Console.WriteLine("Время создания: {0}", patch.CreationTime);
            Console.WriteLine("Количество поддиректориев: {0}", count2);
            Console.WriteLine("Список родительских директориев: 1){0} 2){1} 3){2} 4){3}", patch.Parent,patch.Parent.Parent,patch.Parent.Parent.Parent,patch.Parent.Parent.Parent.Parent);

        }

    }
}
