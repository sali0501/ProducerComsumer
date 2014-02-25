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

            
        }

        static void Producer()
        {
            Console.WriteLine("Producer starts!");
            Console.ReadKey();
            while (true)
            {
                Thread.Sleep(1000);
                Random rnd = new Random();
                int number = rnd.Next(1, 100);
                bb.Put(number);
                Console.WriteLine("Put: " + number);
            }
        }

        static void Consumer()
        {
            while (true)
            {
                Thread.Sleep(700);
                int taken = bb.Take();
                Console.WriteLine("Take: " + taken);
            }
        }
    }
}
