using Algorithminator.Fibonacci;
using BenchmarkDotNet.Running;
using System;

namespace Algorithminator
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(new FibonacciService().Slow(10));
            //Console.WriteLine(new FibonacciService().LogN(10));
            var summary = BenchmarkRunner.Run(typeof(Program).Assembly);
        }
    }
}
