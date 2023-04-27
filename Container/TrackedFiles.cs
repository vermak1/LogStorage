using System.Collections.Generic;
using System.IO;

namespace LogStorage
{
    internal class TrackedFiles
    {
        List<FileInfo> FileInfos { get; set; }

        public TrackedFiles()
        {
            FileInfos = new List<FileInfo>();
        }
    }
}
