using System.Net.Http.Headers;

namespace BloomFilter
{
    internal class WordsApi
    {
        public static string[] GetWords()
        {
            using var client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Add(
       new MediaTypeWithQualityHeaderValue("application/json"));
            var response = client.GetAsync(new Uri("https://www.mit.edu/~ecprice/wordlist.10000")).Result;

            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsStringAsync()
                    .Result
                    .Split("\n");
            }
            else
            {
                return Enumerable.Empty<String>().ToArray();
            }
        }
    }
}
