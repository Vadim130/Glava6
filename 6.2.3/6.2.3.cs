using System.Diagnostics;
using System;

public class Task613
{
    public static Task Main(string[] args)
    {
        SynchronizationContext uiContext = SynchronizationContext.Current;
        Trace.WriteLine($"UI thread is {Environment.CurrentManagedThreadId}");
        Observable.FromEventPattern<MouseEventHandler, MouseEventArgs>(
         handler => (s, a) => handler(s, a),
         handler => MouseMove += handler,
        
         handler => MouseMove -= handler)
         .Select(evt => evt.EventArgs.GetPosition(this))
         .ObserveOn(Scheduler.Default)
         .Select(position =>
         {
             // Сложные вычисления
             Thread.Sleep(100);
             var result = position.X + position.Y;
             var thread = Environment.CurrentManagedThreadId;
             Trace.WriteLine($"Calculated result {result} on thread {thread}");
             return result;
         })
         .ObserveOn(uiContext)
         .Subscribe(x => Trace.WriteLine(
         $"Result {x} on thread {Environment.CurrentManagedThreadId}"));
    }

}