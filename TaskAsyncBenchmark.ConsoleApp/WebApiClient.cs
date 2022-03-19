using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TaskAsyncBenchmark.ConsoleApp
{
    public class WebApiClient
    {
        private const string url = "https://localhost:5001/api/test/";

        //We marked these two methods as asynchronous so that there is no difference in clients.
        public async Task CallAsync()
        {
            HttpClient client = new HttpClient()
            {
                BaseAddress = new Uri(url)
            };
            await client.GetAsync("Async");
        }
        //We marked these two methods as asynchronous so that there is no difference in clients.
        public async Task CallSync()
        {
            HttpClient client = new HttpClient()
            {
                BaseAddress = new Uri(url)
            };
            await client.GetAsync("Sync");
        }
    }
}
