using System;
using System.Data.Common;

namespace LogStorage
{
    internal class DatabaseWriter : IDbWriter //abstract factory design pattern
    {
        private readonly DbProviderFactory _factory;

        public DatabaseWriter(DbProviderFactory factory)
        {
            _factory = factory;
        }

        public void WriteInDb(string message, ESeverity severity, DateTime date)
        {
            using (var con = _factory.CreateConnection())
            {
                con.Open();
                var command = _factory.CreateCommand();
                command.CommandText = "Abrakadabra";
                command.ExecuteNonQuery();
                throw new NotImplementedException();
            }
            throw new NotImplementedException();
        }
    }
}
