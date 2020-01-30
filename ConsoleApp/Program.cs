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
            var tekrar = string.Empty;
            do
            {
                await IstekYolla().ConfigureAwait(false);
                Console.Write("Başka bir sayı ile denemek ister misiniz?(e/h): ");
                tekrar = Console.ReadLine();
            } while (tekrar == "e" || tekrar == "E");
        }
        private static async Task IstekYolla()
        {
            Console.Write("Kaç istek göndermek istediğinizi giriniz: ");
            var numbers = new List<int>();
            if (!int.TryParse(Console.ReadLine(), out var requestNumber))
            {
                Console.WriteLine("Sayı girmen gerekiyordu :/");
                Console.ReadKey();
                Environment.Exit(0);
            }

            for (int i = 1; i <= requestNumber; i++)
            {
                numbers.Add(i);
            }

            var tasks = numbers.Select(n => AsyncRequestAsync(n)).ToList();
            await Task.WhenAll(tasks);
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
