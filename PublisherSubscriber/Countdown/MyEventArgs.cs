using System;

namespace Countdown
{
    public class MyEventArgs : EventArgs
    {
        public string Message;
        public DateTime CreateDate { get; set; }
        public int Life { get; set; }
        public MyEventArgs(int delay, string message)
        {
            CreateDate = DateTime.Now;
            Life = delay;
            Message = message;
        }
    }
}
