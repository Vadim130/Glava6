using System.Diagnostics;
using System;
using System.Reactive.Linq;
using System.Reactive;
using System.Reactive.Threading.Tasks;

public class Task613
{
    public static void Main(string[] args)
    {
        HttpClient client = new HttpClient();
        GetWithTimeout(client);
    }
    static void GetWithTimeout(HttpClient client)
    {
        client.GetStringAsync("http://www.example.com/").ToObservable()
        .Timeout(TimeSpan.FromSeconds(1))
        .Subscribe(
        x => Trace.WriteLine($"{DateTime.Now.Second}: Saw {x.Length}"),
        ex => Trace.WriteLine(ex));
    }
}