using System.Diagnostics;
using System;
using System.Reactive;
using System.Reactive.Linq;

namespace _6._2._2_2_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SynchronizationContext uiContext = SynchronizationContext.Current;
            Trace.WriteLine($"UI thread is {Environment.CurrentManagedThreadId}");
            Observable.Interval(TimeSpan.FromSeconds(1))
            .ObserveOn(uiContext)
            .Subscribe(x => Trace.WriteLine(
            $"Interval {x} on thread {Environment.CurrentManagedThreadId}"));
        }
    }
}
