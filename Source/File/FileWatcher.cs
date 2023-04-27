using System;
using System.IO;
using System.Threading;
using System.Linq;
using System.Collections.Generic;

namespace LogStorage
{
    internal class FileWatcher : IFileWatcher //observer design pattern
    {
        public event EventHandler<LogsChangedArgs> LogsChanged;

        private readonly Dictionary<FileInfo, DateTime> _alreadySyncedFiles;

        private readonly DirectoryInfo _directory;
        public FileWatcher(DirectoryInfo directory)
        {
            _alreadySyncedFiles = new Dictionary<FileInfo, DateTime>();
            _directory = directory;
        }

        private void OnChangedlogs(LogsChangedArgs args)
        {
            LogsChanged?.Invoke(this, args);
        }

        public void StartWatch()
        {
            ThreadPool.QueueUserWorkItem((obj) =>
            {
                try
                {
                    while (true)
                    {
                        ScanLogs();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            });
        }

        private void ScanLogs()
        {
            var files = _directory.EnumerateFiles("*", SearchOption.AllDirectories)
                .Where(x => (!_alreadySyncedFiles.ContainsKey(x) || x.LastWriteTime > _alreadySyncedFiles[x]) &&
                LogFileExtensions.Extentions.Contains(x.Extension))
                .ToList();

            if (files.Count > 0)
                OnChangedlogs(new LogsChangedArgs(files));
        }
    }
}
