using System.Diagnostics;
using System;
using System.Reactive;
using System.Reactive.Linq;

namespace _6._2._1_1_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Trace.WriteLine($"UI thread is {Environment.CurrentManagedThreadId}");
            Observable.Interval(TimeSpan.FromSeconds(1))
            .Subscribe(x => Trace.WriteLine(
            $"Interval {x} on thread {Environment.CurrentManagedThreadId}"));
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
