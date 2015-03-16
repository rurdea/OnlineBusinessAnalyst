using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineBusinessAnalyst.Internal
{
    /// <summary>
    /// Internal list implementation that offers thread-safe Clear, Add and Remove methods.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class ConcurrentList<T> : List<T>
    {
        private object _lock = new object();

        public new void Clear()
        {
            lock (_lock)
            {
                base.Clear();
            }
        }

        public new void Add(T item)
        {
            lock (_lock)
            {
                base.Add(item);
            }
        }

        public new void Remove(T item)
        {
            lock (_lock)
            {
                base.Remove(item);
            }
        }

        public new int Count
        {
            get
            {
                lock (_lock)
                {
                    return base.Count;
                }
            }
        }
    }
}
