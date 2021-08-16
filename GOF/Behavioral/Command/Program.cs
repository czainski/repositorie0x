    /*
    Command
        Allows you to standardization execute of method of objects 
        whose classes are different and not have common interface.
    */
    using System;
    //using RedirectBC;    
    //A abstraction layer
    abstract class Command
    {
        public abstract void Execute();
    }
    class Invoker
    {
        public Command Command { set; get; }
        //
        public void Report()
        {
            Command.Execute();
        }
    }
    //An intermediate layer that links an abstract layer 
    //to a layer of concrete classes.
    class CommandProduct : Command
    {
        Product _product {get;set;}
        public CommandProduct (Product product)
        {
            _product = product;
        }
        //
        public override void Execute()
        {
            _product.SaleProduct();
        }//
    }//
    class CommandStaff : Command
    {
        Staff _staff; 
        public CommandStaff (Staff staff)
        {
            _staff = staff;
        }
        public override void Execute()
        {
            _staff.Employ();
        }//
    }//
    //The 'Receiver' classes (The Concrete classes)
    class Staff
    {
        public string FirstName {get;set;}
        public string LastName {get;set;}
        
        public void Employ()
        {
            Console.WriteLine("\n\tEmploy:\n\t{0}\t{1} ", FirstName, LastName);
        }//
    }//
    class Product
    {
        public string  Name;
        public decimal Price;
        
        public void SaleProduct()
        {
           Console.WriteLine("\n\tSold:\n\t{0}\tPrice: {1} ", Name, Price);
        }//
     }//
    class Client
    {
        static void Main()
        {
            //Redirect.Open();

            //The 'Receiver' classes
            Product product    = new Product();
            product.Name   = "Atomic Lithium 10";
            product.Price  = 749;
            
            Staff   staff      = new Staff();
            staff.FirstName = "John";
            staff.LastName  = "Smith";
            
            //The Concrete Commands
            Command command1   = new CommandProduct(product);
            Command command2   = new CommandStaff(staff);
             
            //The invoker
            Invoker invoker    = new Invoker();

            invoker.Command   = command1;
            invoker.Report();

            invoker.Command   = command2;
            invoker.Report();
    
            Console.ReadKey();
            //Redirect.Close();
       }//
    }//
    /* output:
     
        Sold:
            Atomic Lithium 10 Price: 749 

        Employ:
            John Smith 
     */