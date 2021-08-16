    /*
    Context
          The client uses only the Contex class and its methods.
        With the help of intermediate class are generated
        the  concrete classes depending on the passed 
        parameter that was passed to the Contex object
    */
    using System;
    using System.Collections;
    using System.Collections.Generic;
    //using RedirectBC;
    //
    class Context
    {
        private Interpreter _interpreter;
    
        public Context (string contex)
        {
            _interpreter = new Interpreter(contex);
        }
        public void Interpreter (string s)
        {
            _interpreter.Translation(s);
        }
    }//
    class Interpreter 
    {
        //The interface for concrete classes
        private Translator _translator;
        
        //The constructor is a method of decision
        public Interpreter(string context)
        {
            switch (context)
            {
                case "FrenchTranslator":

                    _translator = new French();
                    break;

                case "GermanTranslator":

                    _translator = new German();
                    break;

                case "PolishTranslator":

                    _translator = new Polish();
                    break;
            }
        }//
        public void Translation(string word)
        {
             _translator.Translation(word);
        }//
    }
    ////The concrete classes with a common interface
    interface Translator
    {
        void Translation(string word);
    }//
    class French : Translator
    {
        Dictionary<string, string> _English = new Dictionary<string, string>();
        Dictionary<string, string> _German  = new Dictionary<string, string>();
        Dictionary<string, string> _Polish  = new Dictionary<string, string>();

        //The constructor: loading of the dictionaries 
        public  French() {
            
            _English.Add("Pouvair", "Power");
            _German.Add ("Pouvair", "Macht");
            _Polish.Add ("Pouvair", "Móc");

            _English.Add("Vouloir", "Want");
            _German.Add ("Vouloir", "Wollen");
            _Polish.Add ("Vouloir", "Chcieć");
        }//
        public void Translation(string word)
        {
            Console.WriteLine("\n     French : "+ word);
            Console.WriteLine("English: "+_English[word]);
            Console.WriteLine("German : "+_German [word]);
            Console.WriteLine("Polish : "+_Polish [word]);
        }//
    }//
    class German : Translator
    {
        Dictionary<string, string> _English = new Dictionary<string, string>();
        Dictionary<string, string> _French  = new Dictionary<string, string>();
        Dictionary<string, string> _Polish  = new Dictionary<string, string>();
        
        public German()
        {
            _English.Add("Macht", "Power");
            _French.Add ("Macht", "Pouvair");
            _Polish.Add ("Macht", "Móc");

            _English.Add("Wollen", "Want");
            _French.Add ("Wollen", "Vouloir");
            _Polish.Add ("Wollen", "Chcieć");
        }

        public void Translation(string word)
        {
            Console.WriteLine("\n     German : " + word);
            Console.WriteLine("English: " + _English[word]);
            Console.WriteLine("French : " + _French[word]);
            Console.WriteLine("Polish : " + _Polish[word]);
        }
    }//
    class Polish : Translator
    {
        Dictionary<string, string> _English = new Dictionary<string, string>();
        Dictionary<string, string> _French  = new Dictionary<string, string>();
        Dictionary<string, string> _German  = new Dictionary<string, string>();
        
        public Polish()
        {
            _English.Add("Móc", "Power");
            _French.Add ("Móc", "Pouvair");
            _German.Add ("Móc", "Macht");

            _English.Add("Chcieć", "Want");
            _French.Add ("Chcieć", "Vouloir");
            _German.Add ("Chcieć", "Wollen" );
        }//
        public void Translation(string word)
        {
            Console.WriteLine("\n     Polish : " + word);
            Console.WriteLine("English: " + _English[word]);
            Console.WriteLine("French : " + _French[word]);
            Console.WriteLine("German : " + _German[word]);
        }
    }////
    class Client
    {
        static void Main()
        {
            //Redirect.Open();
            
            Context
            context = new Context("FrenchTranslator");
            context.Interpreter("Pouvair");

            context = new Context("GermanTranslator");
            context.Interpreter("Wollen");

            context = new Context("PolishTranslator");
            context.Interpreter("Móc");
            
            Console.Read();
            //Redirect.Close();
        }
    }

    /*output:
     
             French : Pouvair
    English: Power
    German : Macht
    Polish : Móc

             German : Wollen
    English: Want
    French : Vouloir
    Polish : Chcieć

              Polish : Móc
    English: Power
    French : Pouvair
    German : Macht

     * */