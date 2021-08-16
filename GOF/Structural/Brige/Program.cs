    /*  
    Bridge
        It allows a unified way to run objects of different classes 
    which implementing the same interface.
    */
    using System;
    using RedirectBC;

    //The abstraction class and a class allows instances for a Brige.
    abstract class  Bridge
    {
        protected CommonInterface commonInterface;
        public CommonInterface SetInstance
        {
            set { commonInterface = value; }
        }
        public abstract void Execute();
    }//
    class ChildBrige : Bridge
    {
        public override void Execute()
        {
            commonInterface.InterfaceMethod();
        }
    }
    //The concrets classes with the same interface.
    interface CommonInterface
    {
        void InterfaceMethod();
    }//
    class ConcreteClassA : CommonInterface
    {
        public  void InterfaceMethod()
        {
            Console.WriteLine("Method A");
        }
    }//
    class ConcreteClassB : CommonInterface
    {
        public  void InterfaceMethod()
        {
            Console.WriteLine("Method B");
        }
    }//
    //
    class Client
    {
        static void Main()
        {
            Redirect.Open();

            Bridge bridge = new ChildBrige();
            bridge.SetInstance = new ConcreteClassA();
            bridge.Execute();

            bridge.SetInstance = new ConcreteClassB();
            bridge.Execute();
            
            //Console.ReadKey();
            Redirect.Close();
        }
    }//
    /* output:
        Method A
        Method B
    */