using System;

namespace LogStorage
{
    internal interface IWriter
    {
        void Write(LogChunk chunk);
    }
}
