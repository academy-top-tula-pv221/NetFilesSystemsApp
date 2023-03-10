using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NetFilesSystemsApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //DriveInfoExample();
            //DirectoryExample()
            //DirectoryInfoExample();

            string path = @"D:\RPO\Maxim Efimov\NewDir\";
            string fileName = "file.dat";

            string[] lines = new[] { "lkjdajd kjd", "jkjl qwek l;keqw", "873jhgjh qwjg9831" };
            string text = "kj aslkj kjh kjh jkh ;oik lkj lkj kj";

            if(!File.Exists(path + fileName))
                File.Create(path + fileName);

            //File.OpenWrite(path + fileName);
            File.WriteAllLines(path + fileName, lines);
            File.AppendAllText(path + fileName, text + "\n");
            File.AppendAllText(path + fileName, "98798b  987634 64623786");

            var result = File.ReadAllText(path + fileName);
            Console.WriteLine(result);

            Console.WriteLine();

            var resultLines = File.ReadAllLines(path + fileName);
            foreach(string line in resultLines)
                Console.WriteLine(line);

        }
        static void DriveInfoExample()
        {
            DriveInfo[] drivers = DriveInfo.GetDrives();

            foreach (DriveInfo driver in drivers)
            {
                Console.WriteLine($"Name: {driver.Name}");
                Console.WriteLine($"Type: {driver.DriveType}");
                if (driver.IsReady)
                {
                    Console.WriteLine($"Label: {driver.VolumeLabel}");
                    Console.WriteLine($"Format: {driver.DriveFormat}");
                    Console.WriteLine($"Total size: {driver.TotalSize / 1024 / 1024}");
                    Console.WriteLine($"Free size: {driver.TotalFreeSpace / 1024 / 1024}");
                }
                Console.WriteLine();
            }
        }

        static void DirectoryExample()
        {
            string path = @"D:\RPO\Maxim Efimov";

            //Directory.CreateDirectory(path + @"\New Directory");
            //Directory.Delete(path + @"\New Directory", true);
            Console.WriteLine(Directory.GetCurrentDirectory());
            Console.WriteLine(Directory.GetParent(path));
            Console.WriteLine(Directory.GetCreationTime(path));
            Console.WriteLine(Directory.GetLastWriteTime(path));

            var directories = Directory.GetDirectories(path);
            var files = Directory.GetFiles(path);
            var allSystem = Directory.GetFileSystemEntries(path);

            foreach (var dir in directories)
                Console.WriteLine(dir);

            Console.WriteLine();

            foreach (var file in files)
                Console.WriteLine(file);

            Console.WriteLine();

            foreach (var entry in allSystem)
                Console.WriteLine(entry);
        }

        static void DirectoryInfoExample()
        {
            string path = @"D:\RPO\Maxim Efimov\NewDir\";

            DirectoryInfo dir = new DirectoryInfo(path);
            if (!dir.Exists)
                dir.Create();
            dir.CreateSubdirectory("Folder 1");
            dir.CreateSubdirectory("Folder 2");

            DirectoryInfo parent = dir.Parent;
            var dirs = parent.EnumerateDirectories("~*"); // parent.GetDirectories();
            var files = parent.EnumerateFiles("*.pdf"); // parent.GetFiles();

            foreach (var d in dirs)
                Console.WriteLine(d.Name);
            Console.WriteLine();
            foreach (var f in files)
                Console.WriteLine(f.Name);
        }

    }
}