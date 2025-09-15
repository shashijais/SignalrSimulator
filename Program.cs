using System.Diagnostics;

namespace SignalrSimulator
{
    internal class Program
    {
        static async Task Main()
        {
            try
            {
                var url = GetUrl(useThreadApp: true);
                var client = new HttpClient();
                var tasks = new List<Task>();
                Console.WriteLine("Starting simulation...");
                var sw = Stopwatch.StartNew();
                for (int i = 1; i <= 36000; i++) // ~300 RPS for 2 min example
                {
                    string rfId = $"RFID{i}";
                    tasks.Add(client.GetAsync($"{url}api/lookup?rfId={rfId}"));
                    if (i % 500 == 0)
                        Console.WriteLine($"Dispatched request {i}"); //log status every 500th request
                    await Task.Delay(1); // ~300 RPS pacing
                }
                await Task.WhenAll(tasks);
                sw.Stop();

                Console.WriteLine($"Completed {tasks.Count} requests in {sw.ElapsedMilliseconds} ms");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        static string GetUrl(bool useThreadApp)
            {
                var threadAppUrl = "http://localhost:5083/";
                var appUrl = "http://localhost:5153/";
                return useThreadApp ? threadAppUrl : appUrl;
            }            

        
    }
}





