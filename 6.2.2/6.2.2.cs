using System.Diagnostics;
using System;
using System.Reactive.Linq;
using System.Reactive;
public class Task613
{
    public static Task Main(string[] args)
    {

    }
    private void Button_Click(object sender, RoutedEventArgs e)
    {
            SynchronizationContext uiContext = SynchronizationContext.Current;
            Trace.WriteLine($"UI thread is {Environment.CurrentManagedThreadId}");
            Observable.Interval(TimeSpan.FromSeconds(1))
            .ObserveOn(uiContext)
            .Subscribe(x => Trace.WriteLine(
            $"Interval {x} on thread {Environment.CurrentManagedThreadId}"));
    }

}