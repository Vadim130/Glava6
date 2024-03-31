using System.Diagnostics;
using System.Reactive;
using System.Reactive.Linq;

public class Task611
{
    public static void Main(string[] args)
    {
        Progress<int> progress = new Progress<int>();
        IProgress<int> ip = progress;
        IObservable<EventPattern<int>> progressReports =
         Observable.FromEventPattern<int>(
         handler => progress.ProgressChanged += handler,
         handler => progress.ProgressChanged -= handler);
        progressReports.Subscribe(data => Trace.WriteLine("OnNext: " + data.EventArgs));
        for (int i = 1; i <= 10; i++)
            ip.Report(i);
         
    }
}