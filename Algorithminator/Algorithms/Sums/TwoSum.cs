using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithminator.Sums
{
    public class TwoSum
    {
        //Time: O(n)
        //Space: O(n)
        public int[] Exists(int number, int[] array)
        {
            Dictionary<int, bool> dictionary = new Dictionary<int, bool>(array.Length);

            foreach (var arrNumber in array)
            {
                if (dictionary.ContainsKey(arrNumber))
                {
                    return new int[] { number - arrNumber, arrNumber };
                }

                dictionary.Add(number - arrNumber, true);
            }

            return new int[0];
        }

        //O(n²)
        public int[] ExistsSlow(int number, int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] + array[j] == number)
                        return new[] { array[i], array[j] };
                }
            }

            return new int[0];
        }


        //O(n log n)?
        public int[] ExistsMedium(int number, int[] array)
        {
            //O(n log n)?
            var ordered = array.OrderByDescending(x => x).ToArray();

            int left = 0, right = ordered.Length - 1;

            //O(n)?
            while (left < right)
            {
                if (ordered[left] + ordered[right] > number)
                {
                    left++;
                }
                else if (ordered[left] + ordered[right] < number)
                {
                    right--;
                }
                else
                {
                    return new int[] { ordered[left], ordered[right] };
                }
            }

            return new int[0];
        }
    }
}
