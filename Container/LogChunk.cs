using System;
using System.Collections.Generic;
using System.IO;

namespace LogStorage
{
    internal class LogChunk
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public List<Entry> Entries { get; set; }
    }
}
