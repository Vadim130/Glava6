using System;
using System.Diagnostics;
using System.Reactive.Linq;
using System.Reactive;

public class Task613
{
    public static Task Main(string[] args)
    {

    }
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Trace.WriteLine($"UI thread is {Environment.CurrentManagedThreadId}");
        Observable.Interval(TimeSpan.FromSeconds(1))
        .Subscribe(x => Trace.WriteLine(
        $"Interval {x} on thread {Environment.CurrentManagedThreadId}"));
    }

}