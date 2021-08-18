using System;
using System.Collections.Generic;
using System.Linq;

namespace Countdown
{
    class Countdown
    {

        List<MyEventArgs> queue = new List<MyEventArgs>();
        Publisher publisher;
        public Countdown(Publisher pub)
        {
            publisher = pub;
        }
        public void AddSubscriber(Subscriber incoming)
        {
            //при вызове метода ставим подписчика в очередь
            DateTime date;
            DateTime rightnow = DateTime.Now;
            //подписка на дальнейшие события
            incoming.Subscribe(publisher);
            foreach (var _event in queue)
            {
                //сравниваем время появления события + время жизни, с нынешнем временем               
                date = _event.CreateDate.AddSeconds(_event.Life);
                if (rightnow < date)
                {
                    //если время жизни события еще не прошло вызываем метод подписчика
                    incoming.Update(publisher, _event);
                }
                else
                {
                    //если время жизни события прошло то удаляем его из списка
                    queue.Remove(_event);
                }

            }
        }
        public void RaiseEvent(string message)
        {
            //при вызове метода сохраняем событие в список
            queue.Add(new MyEventArgs(3, message));

            //вызываем для каждого подписчика сообщение
            publisher.Notify(message);

        }
        public void RemoveSubscriber(Subscriber incoming)
        {
            incoming.Unsubscribe(publisher);
        }
    }
}