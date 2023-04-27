using System;

namespace LogStorage
{
    class Program
    {
        static void Main(string[] args) 
        {
            using (LogProcessor processor = new LogProcessor()) 
            {
                processor.Process();
            }
        }
    }

}
