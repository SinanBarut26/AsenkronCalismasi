using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var numbers = new List<int>();
            for (int i = 1; i <= 10; i++)
            {
                numbers.Add(i);
            }
            // await AsyncRequestAsync(i).ConfigureAwait(false);
            var tasks = numbers.Select(n => AsyncRequestAsync(n)).ToList();
            await Task.WhenAll(tasks);
            Console.ReadKey();
        }

        private static async Task AsyncRequestAsync(int requestId)
        {
            string baseUrl = "http://localhost:5000/Asenkron";
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage res = await client.GetAsync(baseUrl).ConfigureAwait(false))
            using (HttpContent content = res.Content)
            {
                string data = await content.ReadAsStringAsync().ConfigureAwait(false);
                if (data != null)
                {
                    Console.WriteLine("Request Id: " + requestId + "  --> Delay time:" + data);
                }
            }
        }

    }
}
