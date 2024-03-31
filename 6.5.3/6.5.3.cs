using System.Diagnostics;
using System;
using System.Drawing;

public class Task613
{
    public static Task Main(string[] args)
    {

    }
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        IObservable<Point> clicks =
        Observable.FromEventPattern<MouseButtonEventHandler,
        MouseButtonEventArgs>(
        handler => (s, a) => handler(s, a),
        handler => MouseDown += handler,
        handler => MouseDown -= handler)
        .Select(x => x.EventArgs.GetPosition(this));
        Observable.FromEventPattern<MouseEventHandler, MouseEventArgs>(
        handler => (s, a) => handler(s, a),
        handler => MouseMove += handler,
        handler => MouseMove -= handler)
        .Select(x => x.EventArgs.GetPosition(this))
        .Timeout(TimeSpan.FromSeconds(1), clicks)
        .Subscribe(
        x => Trace.WriteLine($"{DateTime.Now.Second}: Saw 
     { x.X},{ x.Y}
        "),
     ex => Trace.WriteLine(ex));
    }
}