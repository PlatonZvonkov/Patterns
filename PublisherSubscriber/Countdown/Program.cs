using System;
using System.Threading;
using System.Collections.Generic;

namespace Countdown
{
    internal class Program
    {        
        public const string MSG = "Publisher-Subsctiber Demo";
        public const string INFO = "At The Moment We Have 1 Publisher and 3 Subsctibers";
        public const string ACTION = "\nEnter Message Delay After Witch Subscriber Will Get It (in milliseconds)";
        private static void Main(string[] args)
        {
            Program p = new Program();
            p.Start();            
        }

        private void Start()
        {
            Console.WriteLine(MSG);
            //экземпляры Издателя и Подписчиков
            Publisher pub1 = new Publisher();
            pub1.Name = "Publisher";
            Subscriber Sub1 = new Subscriber();
            Sub1.Name = "First Subscriber";
            Subscriber Sub2 = new Subscriber();
            Sub2.Name = "Second Subscriber";
            Subscriber Sub3 = new Subscriber();
            Sub3.Name = "Thrird Subscriber";

            Console.WriteLine(INFO);
            while (true)
            {
                Console.WriteLine(ACTION);
                //ввод задержки подписки на событие
                string input = Console.ReadLine();
                try
                {
                    int time = Int32.Parse(input);

                    var countdown = new Countdown(pub1);
                    countdown.RaiseEvent("this is First Message");

                    Thread.Sleep(time);
                    
                    countdown.AddSubscriber(Sub1);
                    countdown.AddSubscriber(Sub2);
                    countdown.AddSubscriber(Sub3);                    
                    
                }
                catch (Exception e)
                {
                    Console.WriteLine("Time is Up! No Messages for you lol! " + e.Message);
                    break;
                }                
            }            
        }
    }         
}
