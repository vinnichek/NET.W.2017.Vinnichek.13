﻿using System;
using QueueRealization.Logic;
using Matrixes.Logic;
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

            foreach (var i in queue)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine(" ");

            Console.WriteLine(queue.Peek());

            SquareMatrix<int> a = new SquareMatrix<int>(new int[] {2, 4, 1, 4, 5, 5, 6, 3, 2});
            foreach (var item in a)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("-------");
            Console.WriteLine(a.GetValue(2, 2));
            a.SetValue(2, 2, 78);

            Console.WriteLine(a.GetValue(2, 2));

            DiagonalMatrix<int> a1 = new DiagonalMatrix<int>(new int[] { 2, 4, 1, 4 });
            foreach (var item in a1)
            {
                Console.WriteLine(item);
            }

            SymmetricMatrix<int> a2 = new SymmetricMatrix<int>(new int[3][] { new int[] {1, 2, 3}, new int[] { 2, 4, 5 }, new int[] { 3,5,6 } });
            foreach (var item in a2)
            {
                Console.WriteLine(item);
            }
        }
    }
}
