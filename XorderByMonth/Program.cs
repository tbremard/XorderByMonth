using Core;
using NLog;
using System;
using System.IO;

namespace XorderByMonth
{
    class Program
    {
        private static Logger _log = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            if (args.Length ==0)
            {
                Console.WriteLine("XorderByMonth <dir1> <dir2> ...");
                return;
            }
            foreach (var item in args)
            {
                Console.WriteLine("Ordering folder: "+item);
                XorderDirectory(item);
            }
        }

        private static void XorderDirectory(string path)
        {
            try
            {
                var core = new XorderCore();
                var files = Directory.GetFiles(path);
                foreach (var pathOfFile in files)
                {
                    string fileName = Path.GetFileName(pathOfFile);
                    string directory = Path.GetDirectoryName(pathOfFile);
                    if (!core.IsValidFile(pathOfFile))
                    {
                        continue;
                    }
                    var date = core.GetDate(pathOfFile);
                    var subDir = core.GenerateSubFolderName(date);
                    _log.Debug($"Moving file: {fileName} to: {subDir}");
                    var pathSubDir = Path.Combine(directory, subDir);
                    Directory.CreateDirectory(pathSubDir);
                    string destFileName = Path.Combine(pathSubDir, fileName);
                    File.Move(pathOfFile, destFileName);
                }
            }
            catch (DirectoryNotFoundException ex)
            {
                _log.Error(ex);
            }
        }
    }
}
