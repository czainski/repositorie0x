    /*
	Template
		Used for objects of similar functionality.
        For example, objects that make querys for different databases 
		or objects that create a launch platform for different games and so on.
    */      
    using System;
    //"Template Class"
    abstract class Game
    {
        public abstract void Execute();
        public abstract void Open();
        public abstract void Close();
        //Template Method
        public void Run()
        {
            Open();
            Execute();
            Close();
        }
    }//    
    //"Concrete clases"
    class TanksGame : Game
    {
        public override void Execute()
        {
            Console.WriteLine("\tTanks are in action : Puf! Puf!");
        }
        public override void Open()
        {
            Console.WriteLine("\tOpen Tanks Game!");
        }
        public override void Close()
        {
            Console.WriteLine("\tClose Tanks Game!");
        }
    }//
    class PlanesGame : Game
    {
        public override void Execute()
        {
            Console.WriteLine("\tPlanes are in action : Bamp! Bamp!");
        }
        public override void Open()
        {
            Console.WriteLine("\n\tOpen Planes Game!");
        }
        public override void Close()
        {
            Console.WriteLine("\tClose Planes Game!");
        }
    }//
    class Client
    {
        static void Main()
        {
            Game 
            templateClass = new TanksGame();
            templateClass.Run();

            templateClass = new PlanesGame();
            templateClass.Run();

            Console.ReadKey();
        }
    }
    /*output:
     
     Open Tanks Game!
     Tanks are in action : Puf! Puf!"
     Close Tanks Game!

     Open Planes Game!
     Planes are in action : Bamp! Bamp!
     Close Planes Game!
     
    */
