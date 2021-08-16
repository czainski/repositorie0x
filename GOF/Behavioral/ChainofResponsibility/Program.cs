    /*  Chain of Responsibility 
      Each object will remember the next object. This way we create 
    a chain of related objects. The recursive method runs 
    method of objects belong to the chain.
      
      In this simple example the program translates a word from English 
    to other languages (very simplified version ); a word  is passed  
    to subsequent dictionaries; the dictionaries form a chain. 
    */
    using System;
    
    // The 'Handler' abstract class
    abstract class Handler
    {
        public Handler Successor {set;get;}
        static Handler _first;
        
        public Handler First
        {
            set  {  _first = value;  }
            get  {  return  _first;  }
        }//
        public void HandleRequest(string request)
        {
            if (First == this)
            {
                Console.WriteLine("\n\tWe translate word => \"{0}\"\n", request);
                First.Translator(request);
            }
            //
            if (Successor != null)
            {
                //Translation by the successor's dictionary 
                Successor.Translator(request);

                //Transfer of word (request) to another chain.  
                Successor.HandleRequest(request);
            }
        }//
        abstract public void Translator(string word);
    }//
    //The concrete classes
    class GermanDictionary : Handler
    {
        override public void Translator(string word)
        {
            switch (word)
            {
                case "Job":
                    word = "Arbeit";
                    break;
                case "Rest":
                    word = "Rest";
                    break;
            }
            Console.WriteLine("\t\tinto German => \"{0}\"", word);
        }
    }//
    class FrenchDictionary : Handler
    {
        override public void Translator(string word)
        {
            switch (word)
            {
                case "Job":
                    word = "Travail";
                    break;
                case "Rest":
                    word = "Reste";
                    break;
            }
            Console.WriteLine("\t\tinto French => \"{0}\"", word);
        }
    }//
    class PolishDictionary : Handler
    {
        override public void Translator(string word) 
        {
            switch (word)
            {
                case "Job":
                    word = "Praca";
                    break;
                case "Rest":
                    word = "Odpoczynek";
                    break;
            }
            Console.WriteLine("\t\tinto Polish => \"{0}\"", word);
        }
    }////
    class Client
    {
        static void Main()
        {
            Handler h1 = new FrenchDictionary();
            Handler h2 = new GermanDictionary();
            Handler h3 = new PolishDictionary();

            //Determining the consequences in the chain
            h1.First=h1;
            h1.Successor=h2;
            h2.Successor=h3;
            h3.Successor=null;

            //A word that is translated
            string request = "Job";

            //Starting the recursive method.
            h1.HandleRequest(request) ;

            //Another word is translated.
            request = "Rest";
            h1.HandleRequest(request);

            Console.ReadKey();
        }
    }////

    /* output: 
    
     We translate word => "Job"

		into French => "Travail"
		into German => "Arbeit"
		into Polish => "Praca"

	 We translate word => "Rest"

		into French => "Reste"
		into German => "Rest"
		into Polish => "Odpoczynek"
     */
