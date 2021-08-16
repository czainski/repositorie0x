    /*
    Proxy
       Generates and remembers an object 
    when certain conditions are met
    e.g. permission to access.
    */
    using System;
        
    class Proxy 
    {
        public ProtectedClass ProtectedClass { set; get; }
        public bool Gate { set; get; }
        public  void Request(string password)
        {
            if (ProtectedClass == null && password == "x")
            {
                ProtectedClass = new ProtectedClass();
                Gate = true;
                return;
            }
            Gate = false;
            Console.WriteLine("\nIllegal Request!");
        }
    }
    class ProtectedClass
    {
        public void Method()
        {
            Console.WriteLine("Method have been executed!");
        }
    }
    class Client
    {
        static void Main()
        {
            Proxy proxy = new Proxy();
            proxy.Request("x");
            test(proxy);

            proxy.Request("y");
            test(proxy);
            Console.ReadKey();
        }//
        static void test(Proxy proxy)
        {
            if (proxy.Gate == true)
            {
                Console.WriteLine("Authorization OK!");
                proxy.ProtectedClass.Method();
            }

        }// 
    }//        
    /*  output :

        Authorization OK!
        Method have been executed!
        
        Illegal Request!
    
    */