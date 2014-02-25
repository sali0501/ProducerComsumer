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
                while (IsFull())
                {
                    Monitor.Wait(queue);
                    
                }
                queue.Enqueue(element);
                Monitor.PulseAll(queue);
                
            }
            finally
            {
                Monitor.Exit(queue);
            }
            
        }

        public int Take()
        {
            Monitor.Enter(queue);
            try
            {
                while (queue.Count == 0)
                {
                    Monitor.Wait(queue);
                }
                int temp = queue.Dequeue();
                Monitor.PulseAll(queue);
                return temp;
            }
            finally
            {
                Monitor.Exit(queue);
            }
           
        }
    }
}
