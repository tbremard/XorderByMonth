using System;
using System.IO;

namespace XorderByMonth
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var item in args)
            {
                Console.WriteLine("Ordering folder: "+item);
                XorderDirectory(item);

            }
        }

        private static void XorderDirectory(string path)
        {
            var files = Directory.GetFiles(path);
            foreach (var file in files)
            {


            }
        }
    }
}
