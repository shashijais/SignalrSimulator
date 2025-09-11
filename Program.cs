using System.Diagnostics;

namespace SignalrSimulator
{
    internal class Program
    {
        static async Task Main()
        {
            var client = new HttpClient();
            var tasks = new List<Task>();
            Console.WriteLine("Starting simulation...");
            var sw = Stopwatch.StartNew();
            for (int i = 1; i <= 36000; i++) // 300 RPS for 2 min (example) 5 mins quite big time here
            {
                string rfId = $"RFID{i}";
                tasks.Add(client.GetAsync($"http://localhost:5153/api/lookup?rfId={rfId}"));
                Console.WriteLine($"Dispatched request {i}");
                await Task.Delay(3); // ~300 RPS pacing
            }
            await Task.WhenAll(tasks);
            sw.Stop();

            Console.WriteLine($"Completed {tasks.Count} requests in {sw.ElapsedMilliseconds} ms");
        }
    }
}





