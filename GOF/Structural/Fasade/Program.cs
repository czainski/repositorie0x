    /*
    Facade
        The pattern is particularly useful when the whole process 
    requires a number of subprocesses. 
    */
    using System;
    using RedirectBC;
    
    abstract class Devices
    {
        public string Name ; 
        public int Amount;
    }//
    class Processor : Devices 
    {
        public override string ToString()
        {
            return String.Format("Processor: \"{0}\"  amount: {1} ",Name, Amount);
        }
    }//
    class Memory : Devices 
    {
        public override string ToString()
        {
            return String.Format("Memory: \"{0}\" amount: {1}", Name, Amount);
        }
    }//
    class Motherboard : Devices 
    {
        public override string ToString()
        {
            return String.Format("Motherboard: \"{0}\" amount: {1}", Name, Amount);
        }
    }//
    class Computer
    {
        private Processor _processor;
        private Memory _memory;
        private Motherboard _motherboard;

        public Computer()
        {
            _processor   = new Processor();
            _memory      = new Memory();
            _motherboard = new Motherboard();
        }
        public void Processor (string s)
        {
            _processor.Name = s;
        }
        public void Memory(string s)
        {
            _memory.Name = s;
        }
        public void Motherboard(string s)
        {
            _motherboard.Name = s;
        }
        public void Make(int i)
        {
            _processor.Amount   = i;
            _memory.Amount      = i;
            _motherboard.Amount = i;
        }
        public void Report()
        {
            Console.WriteLine("\tTo be supplied: \n\t\t{0}\n\t\t{1}\n\t\t{2}",
            _processor, _memory, _motherboard);
        }
    }//
    class Client
    {
        public static void Main()
        {
            //Redirect.Open();
            Computer facade = new Computer();

            facade.Processor("Intel Core i7-9870KA ");
            facade.Memory("Samsung DDR2 XfXgHY");
            facade.Motherboard("MSI AH970MX");

            facade.Make(5);
            facade.Report();
            Console.ReadKey();
            //Redirect.Close();
        }
    }//
    /* output:
    To be supplied: 
		Processor: "Intel Core i7-9870KA "  amount: 5 
		Memory: "Samsung DDR2 XfXgHY" amount: 5
		Motherboard: "MSI AH970MX" amount: 5

    */ 

