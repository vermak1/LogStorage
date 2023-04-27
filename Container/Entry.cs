using System;

namespace LogStorage
{
    internal class Entry
    {
        public DateTime TimeStamp { get; set; }
        public ESeverity Severity { get; set; }
        public String Content { get; set; }
    }
}
