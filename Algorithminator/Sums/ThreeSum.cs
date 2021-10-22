using System.Collections.Generic;
using System.Linq;

namespace Algorithminator.Sums
{
    public class ThreeSum
    {

        //O(n²) ?
        public int[][] Exists(int number, int[] array)
        {
            int[][] sum = new int[array.Length][];
            int index = 0;
            //O(n log n)?
            var ordered = array.OrderByDescending(x => x).ToArray();

            int front = 1;
            int back;

            //O(n)
            for (int i = 0; i < ordered.Length - 2; i++)
            {
                front = i + 1;
                back = ordered.Length - 1;
                //O(n)?
                while (front < back)
                {
                    if (ordered[i] + ordered[front] + ordered[back] == number)
                    {
                        sum[index++] = new[] { ordered[i], ordered[front], ordered[back] };
                        front++;
                        back--;
                    }
                    else if (ordered[i] + ordered[front] + ordered[back] < number)
                    {
                        back--;
                    }
                    else if (ordered[i] + ordered[front] + ordered[back] > number)
                    {
                        front++;
                    }
                }
            }

            return sum;
        }

        //O(n³)
        public int[][] ExistsSlow(int number, int[] array)
        {
            int[][] sum = new int[array.Length][];
            int index = 0;

            for (int i = 0; i < array.Length - 2; i++)
            {
                for (int j = i + 1; j < array.Length - 1; j++)
                {
                    for (int k = j + 1; k < array.Length; k++)
                    {
                        if (array[i] + array[j] + array[k] == number)
                        {
                            sum[index++] = new int[] { array[i], array[j], array[k] };
                        }
                    }
                }
            }

            return sum;
        }
    }
}
