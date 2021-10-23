using BenchmarkDotNet.Attributes;
using System.Collections.Generic;
using System.Linq;

namespace Algorithminator.FrequencyNumbers
{
    public class FrequencyNumber
    {
        //O(n)
        [Benchmark]
        [ArgumentsSource(nameof(Data))]
        public int[] FrequencyNumbers(int[] input, int k)
        {
            Dictionary<int, int> numbers = new Dictionary<int, int>();
            //O(n) -> input = n
            foreach (var number in input)
            {
                if (!numbers.ContainsKey(number))
                {
                    numbers[number] = 0;
                }
                numbers[number]++;
            }

            Dictionary<int, Queue<int>> frequencyNumbers = new Dictionary<int, Queue<int>>();
            //O(n) -> When all numbers are diferents numbers.Count == input.Count
            foreach (var item in numbers)
            {
                if (!frequencyNumbers.ContainsKey(item.Value))
                {
                    frequencyNumbers.Add(item.Value, new Queue<int>());
                }

                frequencyNumbers[item.Value].Enqueue(item.Key);
            }

            int[] result = new int[k];
            int resultCount = 0;
            //O(n)
            for (int i = input.Length; i >= 0; i--)
            {
                if (frequencyNumbers.ContainsKey(i))
                {
                    foreach (var item in frequencyNumbers[i])
                    {
                        result[resultCount++] = item;
                        if (resultCount == k) return result;
                    }
                }
            }
            return result;

        }

        //O(n log n) ?
        [Benchmark]
        [ArgumentsSource(nameof(Data))]
        public int[] FrequencyNumbersThird(int[] array, int k)
        {
            return array
              //O(n)
              .GroupBy(x => x)
              //O(n)
              .Select(x => new { x.Key, Count = x.Count() })
              //O(nlogn)
              .OrderByDescending(x => x.Count)
              //O(k)
              .Take(k)
              //O(k)
              .Select(x => x.Key)
              //O(k)
              .ToArray();
        }
        [Benchmark]
        [ArgumentsSource(nameof(Data))]
        public int[] FrequencyNumbersSecond(int[] array, int k)
        {
            Dictionary<int, int> numbers = new Dictionary<int, int>();

            foreach (var number in array)
            {
                if (numbers.ContainsKey(number))
                {
                    numbers[number]++;
                }
                else
                {
                    numbers.Add(number, 1);
                }
            }

            var ordered = numbers.OrderByDescending(x => x.Value);

            return ordered.Take(k).Select(x => x.Key).ToArray();
        }

        public int[] TwoMostFrequencyNumbers(int[] array, int k)
        {
            Dictionary<int, int> numbers = new Dictionary<int, int>();

            foreach (var number in array)
            {
                if (numbers.ContainsKey(number))
                {
                    numbers[number]++;
                }
                else
                {
                    numbers.Add(number, 1);
                }
            }

            int biggest = int.MinValue;
            int biggestCount = int.MinValue;
            int bigger = int.MinValue;

            foreach (var item in numbers)
            {
                if (biggestCount < item.Value)
                {
                    bigger = biggest;
                    biggestCount = item.Value;
                    biggest = item.Key;
                }
            }

            return new[] { biggest, bigger };

        }

        public IEnumerable<object[]> Data()
        {
            yield return new object[] { new int[] { 1, 2, 3 }, 4 };
            yield return new object[] { Enumerable.Range(0, 100).ToArray(), 1 };
            yield return new object[] { Enumerable.Range(0, 1000).ToArray(), 10 };
            yield return new object[] { Enumerable.Range(0, 10000).ToArray(), 100 };
            yield return new object[] { Enumerable.Range(0, 100000).ToArray(), 1000 };
        }
    }
}
