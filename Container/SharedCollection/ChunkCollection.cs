using System;
using System.Collections;
using System.Collections.Generic;

namespace LogStorage
{
    internal class ChunkCollection : IEnumerable<LogChunk>
    {
        private readonly List<LogChunk> _collection;

        public ChunkCollection()
        {
            _collection = new List<LogChunk>();
        }

        public IEnumerator<LogChunk> GetEnumerator()
        {
            return _collection.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
