using System.Diagnostics;
using System;
using System.Timers;
using System.Reactive;
using System.Reactive.Linq;

public class Task612
{
    public static void Main(string[] args)
    {
        var timer = new System.Timers.Timer(interval: 1000) { Enabled = true };
        IObservable<EventPattern<ElapsedEventArgs>> ticks =
         Observable.FromEventPattern<ElapsedEventHandler, ElapsedEventArgs>(
         handler => (s, a) => handler(s, a),
         handler => timer.Elapsed += handler,
         handler => timer.Elapsed -= handler);
        ticks.Subscribe(data => Trace.WriteLine("OnNext: " + data.EventArgs.SignalTime));
    }
}