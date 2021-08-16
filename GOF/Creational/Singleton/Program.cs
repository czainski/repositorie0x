    /*
    Singleton Pattern
        A pattern provides one and only one instance of the Singleton class.
    */ 
    using System;
    using RedirectBC;
    //
    public class Singleton
    {
        static Singleton instance = null;
        string _Name { get; set; }
        string _IP { get; set; }
        //
        Singleton(string Name, string IP)
        {
            _Name = Name;
            _IP = IP;
        }//
        public static Singleton Instance(string Name, string IP)
        {
                if (Singleton.instance == null)
                {
                    Console.WriteLine("\n\tConstructor:\t{0}\tIP = {1}", Name, IP);
                    Singleton.instance = new Singleton(Name, IP);
                }
                return Singleton.instance;
        }//
        public static Singleton getSingleton
        {
            get 
            {
                return Singleton.instance;
            }   
        }//
        public void Show()
        {
            Console.WriteLine("\n\t{0}\tIP = {1}", _Name, _IP );
        }//
    }////
    class Client
    {
        static void Main(string[] args)
        {
            Redirect.Open();
            
            Singleton.Instance("Server 1", "30.90.39.29");
            Singleton.getSingleton.Show();
        
            Singleton.Instance("Server 2", "99.8.88.88"); 
            Singleton.getSingleton.Show();

            //Console.ReadKey();
            Redirect.Close();
        }
    }////
    /*output:
    
	Constructor:	Server 1	IP = 30.90.39.29

	Server 1	IP = 30.90.39.29

	Server 1	IP = 30.90.39.29

    */