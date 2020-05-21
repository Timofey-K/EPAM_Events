using System;

namespace events
{
    public delegate void PersonCameEventHandler(Person person, DateTime time);
    public delegate void PersonLeaveEventHandler(Person person);
    public class Person
    {
        public string Name { get; set; }


        public void SayHello(Person person, DateTime time)
        {
            string SayTime;
            if (time.Hour < 12)
            {
                SayTime = "Доброе утро";
            }
            else if (time.Hour > 17)
            {
                SayTime = "Добрый вечер";
            }
            else
            {
                SayTime = "Добрый день";
            }

            Console.WriteLine($"{SayTime}, {person.Name}! - Сказал {Name}");
        }

        public void SayBay(Person person)
        {
            Console.WriteLine($"Пока - {person.Name}! - Сказал {Name} ");
        }


        public event PersonCameEventHandler OnCome;
        public event PersonLeaveEventHandler OnLeave;

        public void GoToOfice()
        {
            OnCome?.Invoke(this, DateTime.Now);
        }
        public void GoHome()
        {
            OnLeave?.Invoke(this);
        }
    }
}

