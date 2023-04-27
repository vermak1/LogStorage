using System;

namespace LogStorage
{
    internal interface IFileWatcher
    {
        event EventHandler<LogsChangedArgs> LogsChanged;
        void StartWatch();
    }
}
