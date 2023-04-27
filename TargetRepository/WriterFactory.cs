using System;
using System.Data.Common;

namespace LogStorage
{
    internal static class WriterFactory //factory method design pattern
    {
        public static IDbWriter CreateDbWriter(String s)
        {
            DbProviderFactory db = DbProviderFactories.GetFactory(s);
            switch(s)
            {
                default:
                    return new DatabaseWriter(db);
            }
        }

        public static IWriter CreateWriter()
        {
            return new DatabaseWriterAdapter();
        }

        public static IWriter CreateWriterWithThrottling()
        {
            return new DbWriterThrottler(new DatabaseWriterAdapter());
        }
    }
}
