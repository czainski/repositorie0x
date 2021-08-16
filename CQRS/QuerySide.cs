using System;
namespace CQRS
{
    //
    public interface IQuery<out TResults>
    {
        TResults Execute();
    }
    //
    public interface IQueryBus<TResults>
    {
        TResults Send(IQuery<TResults> query);
    }
    //
    public class QueryBus<TResults> : IQueryBus<TResults>
    {
        public TResults Send(IQuery<TResults> query)
                 => query.Execute();
    }
    //
    public class Context : IDisposable
    {
        //...
        public void Dispose() { }
    }
    //
    public class Person : IQuery<Person.Results>
    {
        public int Id { set; get; }
        public Results results { set; get; }

        public Results Execute()
        {
            using (var context = new Context())
            {
                //... repository.GetPerson(Id);
                Console.WriteLine($"repository.GetPerson({Id})");
            }
            return new Results();
        }
        public class Results
        {
            //...
        }
    }
    //
    public class Raport : IQuery<Raport.Results>
    {
        public Results Execute()
        {
            using (var context = new Context())
            {
                //... repository.Raport();
                Console.WriteLine("repository.Raport()");
            }
            return new Results();
        }
        public class Results
        {
            //...
        }
    }
    //
    /* output:
        repository.GetPerson(111)
        repository.GetPerson(999)
        repository.Raport()
    */

}
