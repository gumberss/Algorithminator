using BloomFilter;
using System.Net.Http.Headers;

public class Program
{
    public static void Main(string[] args)
    {
        // Reference: https://hur.st/bloomfilter/?n=10000&p=0.0001&m=&k=4
        var bloom = new BloomFilter.BloomFilter(379649, 4);

        foreach (var word in WordsApi.GetWords())
        {
            bloom.Add(word);
        }

        var academic = bloom.Check("academic");
        var inator = bloom.Check("Inatorino");

        Console.WriteLine(academic);
        Console.WriteLine(inator);
    }
}