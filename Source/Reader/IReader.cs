using System;
using System.Threading.Tasks;

namespace LogStorage
{
    internal interface IReader : IDisposable
    {
        Task ReadLogAndWriteIntoCollectionAsync(RawCollection collection);
    }
}
