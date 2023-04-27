using System;
using System.IO;

namespace LogStorage
{
    internal static class ReaderFactory //factory design pattern
    {
        public static IReader GetReaderFromCmdline()
        {
            String[] args = Environment.GetCommandLineArgs();
            if (args.Length == 1)
            {
                return new FileReaderStrategy(new DirectoryInfo(Environment.CurrentDirectory));
            }
            if (args.Length == 2) 
            {
                return new FileReaderStrategy(new DirectoryInfo(args[1]));
            }
            throw new NotImplementedException();
        }

        public static IReader GetReaderFromConfigFile()
        {
            throw new NotImplementedException(); //Reading configuration from file and returning IReader
        }
    }
}
