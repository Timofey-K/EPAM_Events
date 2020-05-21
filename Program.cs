using System;
using System.Collections.Generic;


namespace events
{
	class Program
	{

		private static PersonCameEventHandler sayHelloDeligate;
		private static PersonLeaveEventHandler sayLeaveDeligate;

		static void Main(string[] args)
		{
			var rand = new Random();
			List<Person> persons = new List<Person>()
			{
				new Person() { Name = "Аня" },
				new Person() { Name = "Боря" },
				new Person() { Name = "Вася" },
				new Person() { Name = "Гриша" },
				new Person() { Name = "Дина" },
				new Person() { Name = "Ева" }
			};

			foreach (Person person in persons)
			{
				person.OnCome += Person_OnCome;
				person.OnLeave += Person_OnLeave;
						
			}

			foreach (Person person in persons)
			{				
				person.GoToOfice();
				sayHelloDeligate += person.SayHello;
				sayLeaveDeligate += person.SayBay;
			}

			foreach (Person person in persons)
			{				
				sayLeaveDeligate -= person.SayBay;
				person.GoHome();

				sayHelloDeligate -= person.SayHello;
				person.OnCome -= Person_OnCome;				
				person.OnLeave -= Person_OnLeave;
			}				
			Console.ReadKey();
		}

		private static void Person_OnCome(Person person, DateTime time)
		{
			Console.WriteLine($"[Пришёл работник {person.Name} ]");
			sayHelloDeligate?.Invoke(person, time);
		}

		private static void Person_OnLeave(Person person)
		{
			Console.WriteLine($"[Ушёл работник {person.Name} ]");
			sayLeaveDeligate?.Invoke(person);
		}
	}
}

