using System;

namespace LogStorage
{
    internal class CollectionParser : IParser
    {
        private readonly RawCollection _rawCollection;

        private readonly ChunkCollection _chunkCollection;
        public CollectionParser(RawCollection rawCollection, ChunkCollection chunkCollection)
        {
            _rawCollection = rawCollection;
            _chunkCollection = chunkCollection;
        }
        public void ParseLogs()
        {
            throw new NotImplementedException(); // parsing from Rawcollection to ChunkCollection
        }
    }
}
