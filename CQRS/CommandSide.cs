using System;

namespace CQRS
{
    //
    public interface ICommand
    {
        void Execute();
    }
    //
    public class CommandsBus
    {
        void Log(ICommand command)
             => Console.WriteLine($"\nExecute: {command.GetType().Name}");

        public void Send(ICommand command)
        {
            Log(command);
            command.Execute();
        }
    }
    //
    public class Command
    {
        protected long _id;
        protected Command(long id) => _id = id;
    }
    //
    public class UpdateName : Command, ICommand
    {
        string _name;
        public UpdateName(long id, string name) : base(id)
            => _name = name;
        public void Execute()
            => Console.WriteLine($"For Id=={_id} Update: {_name}");
    }
    //
    public class UpdateStreet : Command, ICommand
    {
        string _street;
        public UpdateStreet(long id, string street) : base(id)
            => _street = street;
        public void Execute()
            => Console.WriteLine($"For Id=={_id} Update: {_street}");
    }
}
