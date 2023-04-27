using System;

namespace LogStorage
{
    internal class DatabaseWriterAdapter : IWriter //adapter pattern
    {
        private readonly IDbWriter _databaseWriter;

        public DatabaseWriterAdapter()
        {
            _databaseWriter = WriterFactory.CreateDbWriter("string");
        }
        public void Write(LogChunk chunk)
        {
            foreach (var entry in chunk.Entries)
            {
                _databaseWriter.WriteInDb(entry.Content, entry.Severity, entry.TimeStamp);
            }
        }
    }
}
