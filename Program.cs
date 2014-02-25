using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProducerConsumer
{
    class Program
    {
        static BoundedBuffer bb = new BoundedBuffer(10);

        static void Main(string[] args)
        {
            Thread produce = new Thread(Producer);
            Thread comsumer = new Thread(Consumer);

            produce.Start();
            comsumer.Start();
            produce.Join();
            comsumer.Join();
        }

        static void Producer()
        {
            Console.WriteLine("Producer starts!");
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(300);
                Random rnd = new Random();
                int number = rnd.Next(1, 100);
                bb.Put(number);
                Console.WriteLine("Put: " + number);
            }
        }

        static void Consumer()
        {
            Console.WriteLine("Comsumer starts");
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(1000);
                int taken = bb.Take();
                Console.WriteLine("Take: " + taken);
            }
        }
    }
}
