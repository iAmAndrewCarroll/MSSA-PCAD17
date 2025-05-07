using System.IO;
namespace Mod2Demo1
{
    internal class Program
    {
        static void PrintDirectories(string path, int depth)
        {
            string[] directories = Directory.GetDirectories(path);
            foreach (var d in directories)
            {
                Console.WriteLine(d);
                if (depth > 0)
                {
                    PrintDirectories(d, depth - 1);
                }
            }
        }
        // examining recursion
        static void Main(string[] args)
        {
            const string path = @"C:\Users\andre\MSSA-PCAD17";
            string[] directories = Directory.GetDirectories(path);
            PrintDirectories(path, 2);


            #region repetition logic

            //    foreach (var d in directories)
            //    {
            //        Console.WriteLine(d);
            //        string[] subdirs = Directory.GetDirectories(d);
            //        foreach(var subdir in subdirs)
            //        {
            //          Console.WriteLine(subsubdir);
            //        }
            //    }
            //}
            #endregion
            Console.ReadKey();
        }
    }
}
