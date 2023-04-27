using System;
using System.Threading.Tasks;

namespace LogStorage.Source.WindowsEvents
{
    internal class WindowsEventsReaderStrategy : IReader
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task ReadLogAndWriteIntoCollectionAsync(RawCollection collection)
        {
            throw new NotImplementedException();
        }
    }
}
