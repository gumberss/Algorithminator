using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithminator.PerformanceTests
{
    public class WhereAnd
    {
        //Slow  
        public int[] MultiWhere(int[] array)
        {
            return array
                .Where(x => x > 1)
                .Where(x => x > 2)
                .Where(x => x > 3)
                .Where(x => x > 4)
                .Where(x => x > 5)
                .Where(x => x > 6)
                .ToArray();
        }
   
        //Fast
        public int[] And(int[] array)
        {
            return array
                .Where(x => x > 1 
                         && x > 2
                         && x > 3
                         && x > 4
                         && x > 5
                         && x > 6)
                .ToArray();
        }
    }
}
