using System;


namespace Countdown
{
    public class Publisher
    {
        private static int delay;
        public int Delay { get { return delay; } set { delay = value; } }
        
        public EventHandler<MyEventArgs> myEvent;
        public string Name { get; set; }
        public void Notify(string message)
        {
            MyEventArgs args = new MyEventArgs(Delay, message);
            if (myEvent != null)
            {
                myEvent(this, args);
            }
        }
    }
}