using System;
using System.Threading;

namespace LogStorage
{
    internal class LogReaderContext : IDisposable
    {
        private readonly IReader _reader;

        private readonly RawCollection _rawCollection;

        public LogReaderContext(RawCollection rawCollection)
        {
            _reader = ReaderFactory.GetReaderFromCmdline();
            _rawCollection = rawCollection;
        }
        public void Dispose()
        {
            _reader?.Dispose();
        }

        public void StartCycle()
        {
            ThreadPool.QueueUserWorkItem(async (obj) =>
            {
                try
                {
                    while (true)
                    {
                        await _reader.ReadLogAndWriteIntoCollectionAsync(_rawCollection);
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            });
            
        }

        
    }
}
