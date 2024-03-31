using System.Diagnostics;
using System;

public class Task613
{
    public static Task Main(string[] args)
    {

    }
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Observable.FromEventPattern<MouseEventHandler, MouseEventArgs>(
        handler => (s, a) => handler(s, a),
        handler => MouseMove += handler,
        handler => MouseMove -= handler)
        .Select(x => x.EventArgs.GetPosition(this))
        .Throttle(TimeSpan.FromSeconds(1))
     .Subscribe(x => Trace.WriteLine(
     $"{DateTime.Now.Second}: Saw {x.X + x.Y}"));
    }
}