using System;
using System.Linq;

namespace Algorithminator.PerformanceTests
{
    public class SelectWhereOrder
    {
        //Faster
        public int[] WhereSelect(int[] array)
        {
            return array;
        }

        //Slower
        public int[] SelectWhere(int[] array)
        {
            return array
                .Select(x =>
                {
                    Console.WriteLine(x);
                    return x;
                })
                .Select(x =>
                {
                    Console.WriteLine(x);
                    return x;
                })
                .Select(x =>
                {
                    Console.WriteLine(x);
                    return x;
                }).ToArray();
        }
    }
}
