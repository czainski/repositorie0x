    using System;
    using RedirectBC;
    public interface IBread
    {
        void Production(int ilosc);
    }
    public class Rolls : IBread
    {
        public void Production(int quantity)
        {
            Console.WriteLine("\tRolls in quantity: " + quantity.ToString() );
        }
    }
    public class RyeBread : IBread
    {
        public void Production(int quantity)
        {
            Console.WriteLine("\tRye bread in quantity: " + quantity.ToString());
        }
    }
    public class WheatBread : IBread
    {
        public void Production(int quantity)
        {
            Console.WriteLine("\tWheat bread in quantity: " + quantity.ToString());
        }
    }
    /// A 'ConcreteCreator' class
    public class Factory 
    {
        //klasa decyzyjna (wybór zależny od literału podanego jako parametr
        public  IBread BreadProduction(string kindOfBread)
        {
            switch (kindOfBread)
            {
                case "\"Rye bread\"":
                    return new RyeBread();
                case "\"Wheat bread\"":
                    return new WheatBread();
                case "Rolls":
                    return new Rolls();
                default:
                    throw new ApplicationException(string.Format("Error ! - Kind of Bread'{0}' ", kindOfBread));
            }
        }
    }
     /// Factory Pattern Demo
     class Client
    {
        static void Main(string[] args)
        {
            Redirect.Open();

            Console.WriteLine("\n\n\t\t The Bakehouse - Factory Method \n");
            Factory factory = new Factory();

            IBread iBread = factory.BreadProduction("\"Rye bread\"");
            iBread.Production(10);

            iBread = factory.BreadProduction("\"Wheat bread\"");
            iBread.Production(20);


            iBread = factory.BreadProduction("Rolls");
            iBread.Production(30);

            Redirect.Close();
            Console.ReadKey();
        }
    }
     /* output
     
       The Bakehouse - Factory Method 

     Rye bread in quantity: 10
     Wheat bread in quantity: 20
     Rolls in quantity: 30
     
     */