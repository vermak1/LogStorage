using System;
using System.Collections.Generic;

namespace LogStorage
{
    internal interface IDbWriter
    {
        void WriteInDb(String message, ESeverity severity, DateTime date);
    }
}
