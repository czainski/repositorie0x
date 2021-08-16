    /*
    Mediator
       The mediator have registrate a collection of objects which have a common interface.
    Then on based on the parameter that it will have receives from client, 
    it would been selects the  object from the collection and have executing his method. 
    */
    using System;
    using System.Collections.Generic;
    //using RedirectBC;
    //
    abstract class MediatorMethod
    {
         public abstract void Register(Recipient recipient);
         public abstract void SendMasage(string to, string message);
    }//
    class Mediator : MediatorMethod
    {
        private Dictionary<string, Recipient> _recipients =
                      new Dictionary<string, Recipient>();
        public override void Register(Recipient recipient)
        {
            if (!_recipients.ContainsValue(recipient))
                    _recipients[recipient.Name] = recipient;
        }
        public override void SendMasage(string to, string message)
        {
            Recipient recipient = _recipients[to];
            if (recipient != null)
                recipient.Send(message);
        }
    }//
    abstract class Recipient
    {
        public  string Name {get;set;}
        public Recipient(string name)
        {
            Name = name;
        }
        public virtual void Send(string message)
        {
            Console.WriteLine("To: {0} \nMessage: {1}\n", Name, message);
        }
    }//
    class Enterprise : Recipient
    {
        public Enterprise(string name) : base(name) {}
        public override void Send( string message)
        {
            Console.WriteLine("******* E-mail for enterprise: *******");
            base.Send( message);
        }
    }//
    class Customer : Recipient
    {
        public Customer(string name) : base(name)  {}
        public override void Send(string message)
        {
            Console.WriteLine("******* E-mail for customer: *******");
            base.Send(message);
        }
    }//
    class Client
    {
        static void Main()
        {
            //Redirect.Open();
            Mediator mediator = new Mediator();

            mediator.Register(new Enterprise("IBM"));
            mediator.Register(new Enterprise("Microsoft"));
            mediator.Register(new Customer("Mel Gibson"));
            mediator.Register(new Customer("Cary Grant"));

            mediator.SendMasage("Cary Grant", "Hi Cary!");
            mediator.SendMasage("IBM", "Wellcome IBM!");
            mediator.SendMasage("Mel Gibson", "Hi Mel!");
            mediator.SendMasage("Microsoft", "Wellcome Microsoft!");
            
            Console.ReadKey();
            //Redirect.Close();
        }
    }////
    /* output:
    ******* E-mail for customer: *******
    To: Cary Grant 
    Message: Hi Cary!

    ******* E-mail for enterprise: *******
    To: IBM 
    Message: Wellcome IBM!

    ******* E-mail for customer: *******
    To: Mel Gibson 
    Message: Hi Mel!

    ******* E-mail for enterprise: *******
    To: Microsoft 
    Message: Wellcome Microsoft!
    */
