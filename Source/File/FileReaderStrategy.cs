using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LogStorage
{
    internal class FileReaderStrategy : IReader //Strategy and observer design patterns
    {
        private readonly IFileWatcher _watcher;

        private readonly Dictionary<FileInfo, Int32> _trackedFiles;
        public FileReaderStrategy(DirectoryInfo directory)
        {
            if (directory == null)
                throw new ArgumentNullException(nameof(directory));

            _watcher = new FileWatcher(directory);
            _watcher.LogsChanged += HandleLogsChanged;
            _watcher.StartWatch();
            _trackedFiles = new Dictionary<FileInfo, int>();
        }

        public void Dispose()
        {
            _watcher.LogsChanged -= HandleLogsChanged;
        }

        public async Task ReadLogAndWriteIntoCollectionAsync(RawCollection collection)
        {
            var temp = _trackedFiles;
            foreach (var file in temp)
            {
                if (!IsReadNeeded(file.Key))
                    return;

                var i = await ReadAndWriteIntoCollectionInternalAsync(file.Key, file.Value, collection);
                _trackedFiles[file.Key] = i;
            }
        }

        private Boolean IsReadNeeded(FileInfo file)
        {
            DateTime tempTime = file.LastWriteTime;
            file.Refresh();

            if (tempTime == file.LastWriteTime && _trackedFiles[file] != 0)
                return false;
            return true;
        }

        private async Task<int> ReadAndWriteIntoCollectionInternalAsync(FileInfo file, Int32 startPosition, RawCollection collection)
        {
            using (var reader = new StreamReader(file.FullName))
            {
                Int32 sizeForRead = (Int32)reader.BaseStream.Length - startPosition;

                char[] buffer = new char[sizeForRead];
                await reader.ReadAsync(buffer, startPosition, sizeForRead);

                AddStringsToCollection(file, collection, buffer);
                return (Int32)reader.BaseStream.Length;
            }
        }

        private void AddStringsToCollection(FileInfo file, RawCollection collection, char[] arr)
        {
            var str = new string(arr);
            var stringsList = str.Split('\n').ToList();
            collection.AddLogs(stringsList, file.FullName);
        }

        protected virtual void HandleLogsChanged(object sender, LogsChangedArgs eventArgs)
        {
            foreach(var file in eventArgs.Files)
            {
                if(!_trackedFiles.ContainsKey(file))
                    _trackedFiles.Add(file, 0);
            }
        }
    }
}
