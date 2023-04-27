using System;

namespace LogStorage
{
    internal class LogWriterContext
    {
        private readonly IWriter _writer;

        private readonly ChunkCollection _collection;
        public LogWriterContext(ChunkCollection collection, Boolean throttlingNeeded)
        {
            _collection = collection;
            if (throttlingNeeded) 
            {
                _writer = WriterFactory.CreateWriterWithThrottling();
            }
            else
            {
                _writer = WriterFactory.CreateWriter();
            }
        }
        public void StartCycle()
        {
            _writer.Write(new LogChunk());
            throw new NotImplementedException(); //Reading from ChunkCollection and write to a repository
        }
    }
}
