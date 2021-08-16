using System;

namespace CQRS
{
    public class Client
    {
        static void Main()
        {
            //QuerySide
            Person person = new Person();
            person.Id = 111;
            person.results = new QueryBus<Person.Results>().Send(person);
            //...
            person.Id = 999;
            person.results = new QueryBus<Person.Results>().Send(person);
            //...
            Raport.Results results = new QueryBus<Raport.Results>().
                    Send(new Raport());
            //...
            //CommandSide
            CommandsBus commandsBus = new CommandsBus();
            commandsBus.Send(new UpdateName(100, "Donald"));
            commandsBus.Send(new UpdateStreet(100, "1600 Pennsylvania Avenue"));

            Console.ReadKey();
        }
    }

}
