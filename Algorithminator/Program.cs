using Algorithminator.Fibonacci;
using Algorithminator.PerformanceTests;
using BenchmarkDotNet.Running;
using System;
using System.Diagnostics;
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


            var service = new WhereAnd();

            var array = Enumerable.Range(0, 1_000).ToArray();

            Stopwatch s = new Stopwatch();
            s.Start();

            for (int i = 0; i < 1_000_00; i++)
            {
                service.MultiWhere(array);
            }
            s.Stop();

            Console.WriteLine(s.ElapsedMilliseconds);

            s.Reset();
            s.Start();

            for (int i = 0; i < 1_000_00; i++)
            {
                service.And(array);
            }
            s.Stop();

            Console.WriteLine(s.ElapsedMilliseconds);
        }
    }
}
