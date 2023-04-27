using System;
using System.Collections.Generic;

namespace LogStorage
{
    internal class LogEntity
    {
        public String Name { get; set; }

        public List<String> Content { get; set; }

        public LogEntity()
        {
            Content = new List<string>();
        }
    }
}
