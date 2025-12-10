using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading.Tasks;
using SynchAsynch;

class Program
{
    static async Task Main()
    {
        Console.WriteLine("=== SYNCHRONOUS VS ASYNCHRONOUS COMMUNICATION ===\n");

        var ids = Enumerable.Range(1, 200).ToList();

        // Synchronous (blocking)
        Stopwatch swSync = Stopwatch.StartNew();

        foreach (var id in ids)
        {
            SimulateSyncCall(id);
        }

        swSync.Stop();
        Console.WriteLine($"Synchronous time: {swSync.ElapsedMilliseconds} ms\n");

        // Asynchronous (non-blocking concurrency)
        Stopwatch swAsync = Stopwatch.StartNew();

        // Start all tasks immediately (true concurrency)
        List<Task> tasks = ids.Select(id => SimulateAsyncCall(id)).ToList();

        await Task.WhenAll(tasks);

        swAsync.Stop();
        Console.WriteLine($"Asynchronous time: {swAsync.ElapsedMilliseconds} ms\n");


        // Comparison
        Console.WriteLine("=== SUMMARY ===");
        Console.WriteLine($"Sync  = {swSync.ElapsedMilliseconds} ms");
        Console.WriteLine($"Async = {swAsync.ElapsedMilliseconds} ms");
    }



    // Simulated synchronous communication (blocking)
    static void SimulateSyncCall(int id)
    {
        // Simulated network latency
        Task.Delay(100).Wait();

        // Simulated CPU work
        double result = Math.Sqrt(id) * Math.PI;
    }

    // Asynchronous version (non-blocking)
    static async Task SimulateAsyncCall(int id)
    {
        await Task.Delay(100);  // simulates async I/O

        double result = Math.Sqrt(id) * Math.PI;
    }
}