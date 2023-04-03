using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithminator.Heaps
{
    public class MyHeap<T>
    {
        public MyHeap(IEnumerable<T> array)
        {
            
        }

        //public HeapNode Generate()
        //{

        //}

    }

    public class HeapNode
    {
        public HeapNode Left { get; set; }

        public HeapNode Righit { get; set; }
    }
}
