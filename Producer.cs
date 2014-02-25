using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ProducerConsumer
{
    class Producer
    {
        private BoundedBuffer _buffer;
        private int _howMany;
        public static int LastElements = -1;

        public Producer(BoundedBuffer buffer, int howMany)
        {
            if (buffer == null)
            {
                throw new ArgumentNullException();
            }
            if (howMany < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            _buffer = buffer;
            _howMany = howMany;

            Thread task = new Thread(Run);
            task.Start();
        }

        public void Run()
        {
            for (int i = 0; i < _howMany; i++)
            {
                _buffer.Put(i);
                Console.WriteLine("Put: " + i);
            }
        }

    }
}
