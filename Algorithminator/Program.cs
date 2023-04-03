using Algorithminator.Algorithms.DFS;
using Algorithminator.Fibonacci;
using Algorithminator.PerformanceTests;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Algorithminator
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(new FibonacciService().Slow(10));
            //Console.WriteLine(new FibonacciService().LogN(10));
            //var summary = BenchmarkRunner.Run(typeof(Program).Assembly);


            new Dfs().Test();

            return;

            var service = new SortMinMax();

            var array = Enumerable.Range(0, 5).ToArray();

            Stopwatch s = new Stopwatch();
            s.Start();
            var a = Enumerable.Range(0, 1_0_0000).Reverse().ToList();
                service.MinMax(a);
            s.Stop();

            Console.WriteLine(s.ElapsedMilliseconds);

            s.Reset();
            var b = Enumerable.Range(0, 1_0_000000).Reverse().ToList();
            s.Start();
                service.Sort(b);
            s.Stop();

            Console.WriteLine(s.ElapsedMilliseconds);
        }

        public int Solution(int[] numbs)
        {
            Dictionary<int, List<int>> grouped = new Dictionary<int, List<int>>();

            foreach (var item in numbs)
            {
                if (!grouped.ContainsKey(item))
                    grouped.Add(item, new List<int>());

                grouped[item].Add(item);
            }

            foreach (var item in grouped)
            {
                if(item.Value.Count % 2 != 0)
                {
                    return item.Key;
                }
            }

            return 0;
        }
    }
}
