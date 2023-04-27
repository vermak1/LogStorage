using System;

namespace LogStorage
{
    internal class DbWriterThrottler : IWriter
    {
        private readonly IWriter _writer;

        private Int32 counter;
        public DbWriterThrottler(IWriter writer)
        {
            _writer = writer;
        }

        private Boolean QuotaReached()
        {
            if (counter > 10)
                return true;
            return false;
        }

        public void Write(LogChunk chunk)
        {
            counter++;
            if (!QuotaReached())
            {
                _writer.Write(chunk);
                counter--;
                return;
            }
            throw new Exception("Quota is reached");
        }
    }
}
