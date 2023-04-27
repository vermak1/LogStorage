using System;

namespace LogStorage
{
    internal interface IFileWriter
    {
        void WriteInFile(string content);
    }
}
