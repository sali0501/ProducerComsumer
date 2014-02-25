using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProducerConsumer
{

    class Comsumer
    {
        private BoundedBuffer _buffer;
        private int _howMany;

        public Comsumer(BoundedBuffer buffer, int howMany)
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
                Console.WriteLine("Take: " + _buffer.Take());
            }
        }
    }
}
