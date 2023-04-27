using System;
using System.Collections.Generic;
using System.IO;

namespace LogStorage
{
    internal class LogsChangedArgs : EventArgs
    {
        public List<FileInfo> Files { get; set; }
        public LogsChangedArgs(List<FileInfo> changedFiles)
        {
            Files = changedFiles;
        }

    }
}
