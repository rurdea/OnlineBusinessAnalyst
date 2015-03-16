using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineBusinessAnalyst.Internal
{
    /// <summary>
    /// Internal queue implementation that offers thread-safe Enqueue and Dequeue operations.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class ConcurrentQueue<T> : Queue<T>
    {
        private object _lock = new object();

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
        public new void Enqueue(T item)
        {
            lock (_lock)
            {
                base.Enqueue(item);
            }
        }

        public new T Dequeue() 
        {
            lock (_lock)
            {
                return base.Dequeue();
            }
        }
    }
}
