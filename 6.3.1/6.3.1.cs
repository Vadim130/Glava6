using System.Diagnostics;
using System;

public class Task613
{
    public static Task Main(string[] args)
    {
        Observable.Interval(TimeSpan.FromSeconds(1))
 .Window(2)
 .Subscribe(group =>
 {
     Trace.WriteLine($"{DateTime.Now.Second}: Starting new group");
     group.Subscribe(
     x => Trace.WriteLine($"{DateTime.Now.Second}: Saw {x}"),
     () => Trace.WriteLine($"{DateTime.Now.Second}: Ending group"));
 });
    }


}