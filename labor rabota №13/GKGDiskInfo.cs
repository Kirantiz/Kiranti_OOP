using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace labor_rabota__13
{
   public static class GKGDiskInfo
    {
        public static void FreeDisk()
        {
            DriveInfo freeD = new DriveInfo(@"f:\");
            DriveInfo diskC = new DriveInfo(@"c:\");
            DriveInfo diskD = new DriveInfo(@"d:\");
            Console.WriteLine("На диске свободно "+ freeD.AvailableFreeSpace/1024/1024+" МБ");
            Console.WriteLine("Файловая система: {0}",freeD.DriveFormat);
            Console.WriteLine($"Имя диска {diskC.Name}, объём {diskC.TotalSize / 1024 / 1024}, доступный объём {diskC.AvailableFreeSpace / 1024 / 1024} метка тома {diskC.VolumeLabel}");
            Console.WriteLine($"Имя диска {diskD.Name}, объём {diskD.TotalSize / 1024 / 1024}, доступный объём {diskD.AvailableFreeSpace / 1024 / 1024} метка тома {diskD.VolumeLabel}");
        }


    }
}
