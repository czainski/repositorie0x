    /* AbstractFactory
    */
    using System;
    //using RedirectBC;
    //
    class Tour1 : AbstractTour
    {
        public Tour1() 
        {
            _location = "Pompeii - Italy";
        }
    }
    class Tour2 : AbstractTour
    {
        public Tour2()
        {
            _location = "Territory of Cocos Islands";
        }
    }
    class Bus1 : AbstractTransport
    {
        public Bus1() 
        {
            _transport = "Champion Challenger Bus";
            _price = 2000;
        } 
    }
    class Airplane1 : AbstractTransport
    {
        public Airplane1()
        {
            _transport = "Boeing 787 Dreamliner";
            _price = 10000;
        }
    }
    class Ship1 : AbstractTransport
    {
        public Ship1()
        {
            _transport = "Allure Of The Seas II";
            _price = 8000;
        }
    }
    abstract class AbstractTour
    {
        public string _location;
    }
    abstract class  AbstractTransport
    {
        public string  _transport;
        public int     _number;
        public decimal _price ;

        public void Report(AbstractTour tour)
        {
            System.Console.WriteLine(String.Format("\n\n\tTravel to \"{1}\"" +
                      " has prepared.\n\n\t\tTransport: {0}" +
                      "\n\t\tIncome: {2:N2} Euro",
                      _transport,
                      tour._location,
                      _price*_number));
        }
    }
    class Factory1 : AbstractFactory
    {
        public override AbstractTransport CreateTransport() 
        {
            return new Bus1(); 
        }
        public override AbstractTour CreateTour() 
        {
            return new Tour1(); 
        } 
    }
    class Factory2 : AbstractFactory
    {
        public override AbstractTransport CreateTransport()
        {
            return new Airplane1();
        }
        public override AbstractTour CreateTour()
        {
            return new Tour2();
        }
    }
    class Factory3 : AbstractFactory
    {
        public override AbstractTransport CreateTransport()
        {
            return new Ship1();
        }
        public override AbstractTour CreateTour()
        {
            return new Tour2();
        }
    }
    abstract class AbstractFactory
    {
        public abstract AbstractTransport   CreateTransport();
        public abstract AbstractTour        CreateTour(); 
    }
    class Manager {

		AbstractTransport _transport; 
        AbstractTour      _tour; 
        
        public void Factory(AbstractFactory factory, int number) 
        { 
            _transport  = factory.CreateTransport();
            _transport._number = number;
            
            _tour       = factory.CreateTour(); 
        } 
        public void Run() 
        { 
            _transport.Report(_tour); 
        } 
    }
    ////
    public class Client
    {   
        public static void Main(String[] args)
        {
            //Redirect.Open(); 
 
            Manager manager = new Manager();
            manager.Factory(new Factory1(), 40);
            manager.Run();

            manager.Factory(new Factory2(), 200);
            manager.Run();

            manager.Factory(new Factory3(), 1500);
            manager.Run();

            //Redirect.Close();

            Console.ReadLine();
        }
     }
    /* output:

	  

Travel to "Pompeii - Italy" has prepared.

		
	  Transport: Champion Challenger Bus
		
	  Income: 80 000,00 Euro



	  Travel to "Territory of Cocos Islands" has prepared.

		
	  Transport: Boeing 787 Dreamliner
		
	  Income: 2 000 000,00 Euro



	  Travel to "Territory of Cocos Islands" has prepared.

		
	  Transport: Allure Of The Seas II
		
	  Income: 12 000 000,00 Euro
    
	*/