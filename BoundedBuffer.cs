using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProducerConsumer
{
    class BoundedBuffer
    {
        private readonly int _capasity;
        private Queue<int> queue = new Queue<int>(); 

        public BoundedBuffer(int capasity)
        {
            if (capasity < 1)
            {
                throw new ArgumentException();
            }

            _capasity = capasity;
        }

        public bool IsFull()
        {
            return queue.Count == _capasity;
        }

        public void Put(int element)
        {
            Monitor.Enter(queue);
            try
            {
                if (IsFull())
                {
                    Monitor.Wait(queue);
                }
                queue.Enqueue(element);
            }
            finally
            {
                Monitor.Exit(queue);
                Monitor.Pulse(queue);
            }
            
        }

        public int Take()
        {
            Monitor.Enter(queue);
            int temp;
            try
            {
                if (queue.Count == 0)
                {
                    Monitor.Wait(queue);
                }
                temp = queue.Dequeue();
            }
            finally
            {
                Monitor.Exit(queue);
                Monitor.Pulse(queue);
            }
            return temp;
        }
    }
}
