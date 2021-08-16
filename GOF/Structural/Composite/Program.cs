    /*
    Composite
        It enables to build a hierarchical structures
    */
    using System;
    using System.Collections.Generic;
    using RedirectBC;
    //
    abstract class Node
    {
        private string _name;
        public Node(string name)
        {
            _name = name;
        }
        public string Name
        {
            get { return _name; }
        }
        public abstract void DisplayAll(int depth);
        public abstract void DisplayNode(string c, int depth);
        public abstract void DisplaySubNote(Composite c, int depth);
    }//
    class Composite : Node
    {
        //
        private List<Node> _NodesList = new List<Node>();
        //
        public Composite(string _name)
            : base(_name){}
        //
        public List<Node> NodesList
        {
            get { return _NodesList; }
        }
        //
        public void Add(Node node)
        {
            _NodesList.Add(node);
        }
        //
        public override void DisplayAll(int depth)
        {
            Console.WriteLine(new String(' ', depth) + Name);
            foreach (Node component in NodesList)
                component.DisplayAll(depth + 2);
        }
        //
        public override void DisplayNode(string name, int depth)
        {
            foreach (Composite component in NodesList)
            {
                if (component.Name == name )
                {
                    Console.WriteLine(new String(' ', depth) + component.Name);
                    foreach (Composite c in component.NodesList)
                        component.DisplaySubNote(c, depth+2);
                    break;
                }
                depth += 2;
                component.DisplayNode(name, depth);              
            }
        }
        //
        public override void DisplaySubNote(Composite c,int depth)
        {
            Console.WriteLine(new String(' ', depth) + c.Name);
            foreach (Composite component in c.NodesList)
                component.DisplaySubNote(component, depth+2 );
        }
        //
        static private Result _result=new Result();
        private Result Result
        {
            get { return _result; }
        }
        public  void Remove(Composite node, string name)
        {
            NodeToResult(node, name);
            Result.Remove();
        }
        //
        static private bool gate = true;
        private void NodeToResult(Composite node, string name)
        {
            if (gate == false) { return; }
            if (Name == name)
            {
                _result.NodeSuper = node;
                _result.NodeToRemove = this;
                
                gate = false;
                return;
            }
            else 
            {
                node = this; //A prior for this table
                foreach (Composite component in _NodesList)
                    component.NodeToResult(node, name);
            }
        }

    }//
    class Result
    {
        private Composite _nodeSuper ;
        private Composite _nodeToRemove; 
        
        public  Composite NodeSuper 
        {
            set { _nodeSuper= value; } 
        }

        public Composite NodeToRemove
        {
            set { _nodeToRemove = value; }
        }
        public void Remove()
        {
            _nodeSuper.NodesList.Remove(_nodeToRemove);
        }
    }//
    //
    class Client
    {
        static void Main()
        {
            Redirect.Open();

            Composite root    = new Composite("Apteka");
    
            Composite comp0   = new Composite("1. Leki przeciwzapalne");
            Composite comp1   = new Composite("1.1.Steroidowe");
            Composite comp2   = new Composite("1.2.Niesteroidowe");
            
            Composite comp11  = new Composite("1.1.1.Glikokortykosteroidy ");
            Composite comp12  = new Composite("1.1.2.Syntetyczne");

            Composite comp21  = new Composite("1.2.1.Salicylan metylu");
            Composite comp211  = new Composite("1.2.1.1. vvvvvvvvvvv");
            Composite comp2111 = new Composite("1.2.1.1.1. wwwwwwwww");
            Composite comp22  = new Composite("1.2.2.Salicylan choliny");

            comp0.Add(comp1);
            comp1.Add(comp11);
            comp1.Add(comp12);
            
            comp0.Add(comp2);
            comp2.Add(comp21);
            comp2.Add(comp22);
            comp21.Add(comp211);
            comp211.Add(comp2111);
            root.Add(comp0);
        
            comp0 = new Composite("2. Leki układu krążenia");
            root.Add(comp0);

            Console.WriteLine("\nDisplay of a created structure:");            
            root.DisplayAll(5);

            Console.WriteLine("\nDisplay a parts to remove:");            
            root.DisplayNode("1.2.1.1. vvvvvvvvvvv",5);
            
            //Usunięcie podsieci
            root.Remove(root, "1.2.1.1. vvvvvvvvvvv");

            Console.WriteLine("\nDisplay a structure after a  parts removal:");            
            root.DisplayAll(5);
            
            //Console.ReadKey();
            Redirect.Close();
        }
    }
    /* ouput:
    
    Display of a created structure:

      Apteka
       1. Leki przeciwzapalne
         1.1.Steroidowe
           1.1.1.Glikokortykosteroidy 
           1.1.2.Syntetyczne
         1.2.Niesteroidowe
           1.2.1.Salicylan metylu
             1.2.1.1. vvvvvvvvvvv
               1.2.1.1.1. wwwwwwwww
           1.2.2.Salicylan choliny
       2. Leki układu krążenia

    Display a parts to remove:
             1.2.1.1. vvvvvvvvvvv
               1.2.1.1.1. wwwwwwwww

    Display a structure after a  parts removal:
    
      Apteka
       1. Leki przeciwzapalne
         1.1.Steroidowe
           1.1.1.Glikokortykosteroidy 
           1.1.2.Syntetyczne
         1.2.Niesteroidowe
           1.2.1.Salicylan metylu
           1.2.2.Salicylan choliny
       2. Leki układu krążenia

    */