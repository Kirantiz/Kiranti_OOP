using System;
using System.Text;
using System.IO;
using System.IO.Ports;
using System.IO.Compression;



namespace labor_rabota__13
{
   static class GKGFileManager
    {

        public static void Method1(string _patch)
        {
            FileInfo fileInfo = new FileInfo(_patch  +"\\"+ "gkgdirinfo.txt");
            var patch = new DirectoryInfo(_patch);

            patch.CreateSubdirectory(@"GKGInspect");
           string patch2 = patch + "\\GKGInspect";

            var dirInf = new DirectoryInfo("f:\\");

            using (FileStream fstream = new FileStream(patch + "\\" + "gkgdirinfo.txt", FileMode.Create))
            {
                if (Directory.Exists("f:\\"))
                {
                    Console.WriteLine("Директории на диске: " + "f");
                    string[] dirs = Directory.GetDirectories("f:\\");
                    byte[] arrayy = Encoding.Default.GetBytes("Директории на диске: ");
                    fstream.Write(arrayy, 0, arrayy.Length);
                    foreach (string s in dirs)
                    {
                        Console.WriteLine(s);
                        byte[] array = Encoding.Default.GetBytes(s + "\r\n");
                        fstream.Write(array, 0, array.Length);

                    }
                    Console.WriteLine("Файлы на диске: " + "f");
                    string[] files = Directory.GetFiles("f:\\");
                    byte[] arraay = Encoding.Default.GetBytes("Файлы на диске: ");
                    fstream.Write(arraay, 0, arraay.Length);
                    foreach (string s in files)
                    {
                        Console.WriteLine(s);
                        byte[] array = Encoding.Default.GetBytes(s + "\r\n");
                        fstream.Write(array, 0, array.Length);
                    }

                }

            }
            fileInfo.CopyTo(patch +"\\GKGInspect" + "\\" + "gkgdirinfo1.txt", true);
            fileInfo.Delete();
        }

        public static void XxxDir()
        {
            string b;
            string nameDir = @"F:\Git\Kiranti_OOP\labor rabota №13\bin\Debug\GKGFiles";
            var dirInfo = new DirectoryInfo(nameDir);
            dirInfo.Create();
            Console.WriteLine("Введите название директории: ");
            string nameDir2 = Console.ReadLine();
            DirectoryInfo dirInfoo = new DirectoryInfo(nameDir2);
            if (Directory.Exists(nameDir2))
            {
                Console.WriteLine("Введите расширение: ");
                b = Console.ReadLine();
                string[] files = Directory.GetFiles(nameDir2);
                foreach (string s in files)
                {
                    FileInfo fileInfo = new FileInfo(s);
                    if (fileInfo.Extension == b)
                    {
                        File.Copy(s, nameDir + "\\" + new FileInfo(s).Name);
                    }
                }
                dirInfo.MoveTo(@"F:\Git\Kiranti_OOP\labor rabota №13\bin\Debug\GKGInspect\GKGFiles");
            }
            else { Console.WriteLine("Директории не существует."); }
        }

        public static void ZipArh()
        {
            string patch = @"F:\Git\Kiranti_OOP\labor rabota №13\bin\Debug\GKGInspect\GKGFiles";
            string patchZip = @"F:\Git\Kiranti_OOP\labor rabota №13\bin\Debug\GKGInspect\GKGFiles.zip";
            string patchExt = @"F:\Git\Kiranti_OOP\labor rabota №13\bin\Debug\GKGInspect";
          
            ZipFile.CreateFromDirectory(patch, patchZip);
            ZipFile.ExtractToDirectory(patchZip, patchExt);
        }

    }
}
