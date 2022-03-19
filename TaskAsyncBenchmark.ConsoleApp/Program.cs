using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace TaskAsyncBenchmark.ConsoleApp
{
    internal class Program
    {
        async static Task Main(string[] args) 
        {
            do
            {
                AddLog("App is running...");

                Console.WriteLine("Enter the request type (Sync = 0 , Async = 1)");
                int requestType = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter how many requests you want to send: ");
                int requestCount = int.Parse(Console.ReadLine());
                
                var stopWatch = Stopwatch.StartNew();

                var tasks = requestType == 0 ? GetSyncTasks(requestCount) : GetASyncTasks(requestCount);

                await Task.WhenAll(tasks);

                AddLog($"Total Requests:{requestCount} Total time: {stopWatch.ElapsedMilliseconds} MS with {(requestType == 0 ? "SYNC Api Action" : "Async Api Action")}");
                Console.WriteLine("Please press 'R' for sending other requests");
                

            } while (Console.ReadKey().Key == ConsoleKey.R);
        }
        public static IEnumerable<Task> GetSyncTasks(int requestCount)
        {
            var result = new List<Task>();

            var client = new WebApiClient();

            for (int i = 0; i < requestCount; i++)
            {
                result.Add(client.CallSync());
            }
            return result;
        }
        public static IEnumerable<Task> GetASyncTasks(int requestCount)
        {
            var result = new List<Task>();

            var client = new WebApiClient();

            for (int i = 0; i < requestCount; i++)
            {
                result.Add(client.CallAsync());
            }
            return result;
        }

        private static void AddLog(string logStr)
        {
            logStr = $"[{DateTime.Now:dd.MM.yyyy hh:mm:ss}] - {logStr}";
            Console.WriteLine(logStr); ;
        }
    }
}
