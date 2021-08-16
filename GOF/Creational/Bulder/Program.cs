    /*Builder*/    
    using System;
    //using RedirectBC;
    abstract class Builder
    {
        public abstract void Transport();
        public abstract void Location();
        public abstract void Price();
        public abstract void Report();  
    }//
    //Concrete Builders
    class CocosLands : Builder
    {
        public Tour _tour = new Tour();
        public CocosLands(int number)
        {
            _tour._Number = number;
        }
        public override void Transport() { _tour._Transport = "Boeing 787 Dreamliner"; }
        public override void Location()  { _tour._Location = "Territory of Cocos Islands"; }
        public override void Price()     { _tour._Price = 10000; }
        public override void Report()    { _tour._Report(); }
    }//
    class Pompeii : Builder
    {
        public Tour _tour = new Tour();
        public Pompeii(int number) 
        {
            _tour._Number = number;
        }
        public override void Transport() { _tour._Transport = "Champion Challenger Bus"; }
        public override void Location()  { _tour._Location = "Pompeii - Italy"; }
        public override void Price()     { _tour._Price = 2000; }
        public override void Report()    { _tour._Report(); }
    }
    //The "Director" class 
    class Director
    {
        private Builder _builder;
        public Director (Builder builder) 
        {
            _builder = builder;
        }
        public void Construct()
        {
            _builder.Transport();
            _builder.Location();
            _builder.Price();
            _builder.Report();  
        }
    }//
    //A Concrete class
   class Tour
    {
        string  _location;
        string  _transport;
        decimal _price;
        int     _number;
        public string _Transport
        {
            set { _transport = value; }
        }//
        public string _Location
        {
            set { _location = value; }
        }//
        public decimal _Price
        {
            set { _price = value; }
        }//
        public int _Number
        {
            set { _number = value; }
        }//
        public void _Report()
        {
            System.Console.WriteLine(String.Format("\n\n\tTravel to \"{1}\""+
                " has prepared.\n\n\t\tTransport: {0}"+
                "\n\t\tIncome: {2:N2} Euro",
                _transport,
                _location,
                _price*_number));
        }//
    }////
    class Client
    {
        public static void Main()
        {
            //Redirect.Open();
            
            //Director
            Director director = null;
            
            director = new Director(new Pompeii(40));
            director.Construct();

            director = new Director(new CocosLands(200));
            director.Construct();
            
            //
            Console.ReadKey();
            //Redirect.Close();
        }
    }// 
    /*output:

        Travel to "Pompeii - Italy" has prepared.

		    Transport: Champion Challenger Bus
		    Income: 80 000,00 Euro

       Travel to "Territory of Cocos Islands" has prepared.

		    Transport: Boeing 787 Dreamliner
		    Income: 2 000 000,00 Euro
	
    */