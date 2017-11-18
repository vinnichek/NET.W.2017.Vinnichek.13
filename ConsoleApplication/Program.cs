using System;
using QueueRealization.Logic;
namespace ConsoleApplication
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>(7);

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);
            queue.Enqueue(6);
            queue.Enqueue(7);
            queue.Enqueue(8);
            queue.Enqueue(9);
            queue.Enqueue(10);
            queue.Enqueue(11);

            foreach (var i in queue)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine(" ");

            queue.Clear();

            queue.Enqueue(3);
            queue.Enqueue(5);
            queue.Enqueue(6);
            queue.Enqueue(7);
            Console.WriteLine(queue);
            /*foreach (var i in queue)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine(" ");

            Console.WriteLine(queue.Peek());*/
        }
    }
}
