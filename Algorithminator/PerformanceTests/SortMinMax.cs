using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithminator.PerformanceTests
{
    internal class SortMinMax
    {
        public void MinMax(List<int> numbs)
        {
            for (int i = 0; i < 1_0_0; i++)
            {
                var b = numbs.Min();
                var a = numbs.Max();
            }
        }

        public void Sort(List<int> numbs)
        {
            numbs.Sort();

            for (int i = 0; i < 1_0_0; i++)
            {
                var b = numbs.First();
                var a = numbs.Last();
            }

        }
    }
}
