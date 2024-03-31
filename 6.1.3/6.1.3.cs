using System.Diagnostics;
using System ;
using System.Reactive.Linq;
using System.Reactive;
using System.Timers;

public class Task613
{
    public static void Main(string[] args)
    {
        var timer = new System.Timers.Timer(interval: 1000) { Enabled = true };
        IObservable<EventPattern<object>> ticks =
         Observable.FromEventPattern(timer, nameof(timer.Elapsed));
        ticks.Subscribe(data => Trace.WriteLine("OnNext: "+ ((ElapsedEventArgs)data.EventArgs).SignalTime));
    }
}