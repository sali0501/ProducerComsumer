using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;

namespace ProducerConsumer
{
    class Program
    {
        static BoundedBuffer bb = new BoundedBuffer(10);

        static void Main(string[] args)
        {
            Producer producer = new Producer(bb, 100);
            Comsumer comsumer = new Comsumer(bb, 100);
            Console.ReadKey();
        }

        public static void tryBoundedBuffer()
        {
            Thread produce = new Thread(ProducerBoundedBuffer);
            Thread comsumer = new Thread(ConsumerBoundedBuffer);

            produce.Start();
            comsumer.Start();

            produce.Join();
            comsumer.Join();
        }

        static void ProducerBoundedBuffer()
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

        static void ConsumerBoundedBuffer()
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
