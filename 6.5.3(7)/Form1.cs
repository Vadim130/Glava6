using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reactive;
using System.Reactive.Linq;
using System.Windows.Input;

namespace _6._5._3_7_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
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
}
