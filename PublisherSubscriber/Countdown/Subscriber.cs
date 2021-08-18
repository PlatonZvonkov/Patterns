
namespace Countdown
{
    public class Subscriber
    {
        public string Name { get; set; }
        public string Info { get; set; }
        public void Subscribe(Publisher pub)
        {
            pub.myEvent += Update;
        }
        public void Unsubscribe(Publisher pub)
        {
            pub.myEvent -= Update;
        }
        public void Update(object sender, MyEventArgs args)
        {
            Publisher pub = (Publisher)sender;
            Info = ($"{ pub.Name } send a Message to {Name}: {args.CreateDate} {args.Message}");
            System.Console.WriteLine(Info);
        }
    }
}