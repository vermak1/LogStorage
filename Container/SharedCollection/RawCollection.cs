using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LogStorage
{
    internal class RawCollection : IEnumerable<LogEntity> // design pattern Iterator
    {
        private readonly List<LogEntity> _data;

        public RawCollection()
        {
            _data = new List<LogEntity>();
        }

        public void AddLogs(List<String> data, String name)
        {
            if (data == null) 
                throw new ArgumentNullException(nameof(data));
            if (name == null) 
                throw new ArgumentNullException(nameof(name));

            if (!_data.Select(x => x.Name).Contains(name))
            {
                _data.Add(new LogEntity()
                {
                    Name = name,
                    Content = data
                });
                return;
            }
            var entity = _data.Find(x => x.Name == name);
            entity.Content.AddRange(data);
        }

        public IEnumerator<LogEntity> GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
