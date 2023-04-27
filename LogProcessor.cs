using System;

namespace LogStorage
{
    internal class LogProcessor : IDisposable //mediator design pattern
    {
        private readonly LogReaderContext _readerContext;

        private readonly IParser _parser;
        private readonly LogWriterContext _writerContext;
        public LogProcessor()
        {
            RawCollection rawCollection = new RawCollection();
            ChunkCollection chunkCollection = new ChunkCollection();
            _readerContext = new LogReaderContext(rawCollection);
            _parser = new CollectionParser(rawCollection, chunkCollection);
            _writerContext = new LogWriterContext(chunkCollection, true);
        }

        public void Process()
        {
            _readerContext.StartCycle();
            _parser.ParseLogs();
            _writerContext.StartCycle();
        }

        public void Dispose()
        {
            _readerContext.Dispose();
        }
    }
}
