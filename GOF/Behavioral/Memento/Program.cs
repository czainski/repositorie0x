    /*
    Memento
        
        The purpose of this pattern is to store object states
    and is achieved by cloning objects.
    Clones are remembered in an array such as Dictionary
    with access via key.
    */
    using System;
    using System.Collections.Generic;
    using RedirectBC;
    //
    class Memento : ICloneable
    {
        private string _name;
        private string _phone;
        private double _budget;
        //
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }
        public double Budget
        {
            get { return _budget; }
            set { _budget = value; }
        }
        //
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }//
    class Memory 
    {
        Dictionary<string, Memento> _saveStates =
                 new Dictionary<string, Memento>();

        public void SaveState (string key, Memento state )
        {
            _saveStates.Add(key, (Memento) state.Clone());
        }
        public void GetState(string key) 
        {
            Console.WriteLine("\n----- Selected: {0} ------------", key);
            Console.WriteLine(_saveStates[key].Name);
            Console.WriteLine(_saveStates[key].Phone);
            Console.WriteLine(_saveStates[key].Budget);
            Console.WriteLine("------------------------------------");
        }
        public void AllStates()
        {
            Console.WriteLine("\n--------- All saved states: --------");
            foreach (var item in _saveStates)
            {
                Console.WriteLine("   {0}: ", item.Key );
                Console.WriteLine("Name: {0}",_saveStates[item.Key].Name);
                Console.WriteLine("Phone: {0}", _saveStates[item.Key].Phone);
                Console.WriteLine("Budget: {0}\n",_saveStates[item.Key].Budget);
            }
            Console.WriteLine("------------------------------------");
        }
    }//
    class Client
    {
        static void Main()
        {
            Redirect.Open();
            
            Memory  memory  = new Memory();
            Memento memento = new Memento();
            //
            memento.Name    = "Audio Systems Project";
            memento.Phone   = "(412) 256-0990";
            memento.Budget  = 25000000;
            //
            memory.SaveState("State 1", memento);
            //
            memento.Name    = "Project Fi";
            memento.Phone   = "(310) 209-7111";
            memento.Budget  = 30000000;
            memory.SaveState("State 2", memento);
            //
            memory.AllStates();
            //
            memory.GetState("State 1");
            
            //Console.ReadKey();
            Redirect.Close();
        }
    }
    /*output:
    --------- All saved states: --------
        State 1: 
    Name: Audio Systems Project
    Phone: (412) 256-0990
    Budget: 25000000

       State 2: 
    Name: Project Fi
    Phone: (310) 209-7111
    Budget: 30000000

    ------------------------------------

    ----- Selected: State 1 ------------
    Audio Systems Project
    (412) 256-0990
    25000000
    ------------------------------------
 
    */