    /*
    Strategy
        Using this pattern, you can manage the properties of a class 
    (so-colled a "Contex" class), that is, they manage by using 
    different methods of different classes which implementing 
    a method of the strategy.
    */
    using System;
    using System.Collections.Generic;
    using RedirectBC;
    //
    abstract class Strategy
    {
        public abstract void StrategyMethod(List<string> components);
    }
    //"Concrete Strategy"
    class Cooking : Strategy
    {
        public override void StrategyMethod(List<string> components)
        {
            Console.WriteLine("\n\tFirst strategy:\n\n\t\t\tWe prepare the soup. \n\t\tPreparate the following components:");
            foreach (var component in components)
                Console.WriteLine("\t\t\t"+component);
                Console.WriteLine ("\t\tDo not forget to add the laurel leaf and allspice.\n\t\tProvide with noodles. \n");
        }//
    }//
    class Frying : Strategy
    {
        public override void StrategyMethod(List<string> list)
        {
            Console.WriteLine("\n\tSecond strategy:\n\n\t\tWe'll fry for dinner:");
            foreach (var skladnik in list)
                Console.WriteLine("\t\t\t" + skladnik);
        }
    }//
    //The 'Context' class
    class Dinner
    {
        private Strategy _strategy;
        private List<string> _components= new List<string>();
        public List<string> Components
            {get{return _components;}}
        //
        public void ChoiceStrategy(Strategy strategy)
        {
            _strategy = strategy;
        }
        public void PrepareDinner()
        {
            _strategy.StrategyMethod(_components);
        }
    }//
    class Client
    {
        static void Main()
        {
            Redirect.Open();

            Dinner dinner = new Dinner();
            
            dinner.Components.Add("chicken");
            dinner.Components.Add("carrot");
            dinner.Components.Add("parsley");
            dinner.Components.Add("celery");

            dinner.ChoiceStrategy(new Cooking());
            dinner.PrepareDinner();
            
            dinner.ChoiceStrategy(new Frying());
            dinner.PrepareDinner();
         
            //Console.ReadKey();
            Redirect.Close();
        }
    }
    /*output:

	First strategy:

			We prepare the soup. 
		Preparate the following components:
			chicken
			carrot
			parsley
			celery
		Do not forget to add the laurel leaf and allspice.
		Provide with noodles. 


	Second strategy:

		We'll fry for dinner:
			chicken
			carrot
			parsley
			celery
    */
