    /*
    Adapter 
         If of different classes generate a similar data structure 
    it can be used Adapter. 
         This way, the Client uses only adapter instances and his methods.
    */
    using System;
    using System.Collections.Generic;
    //using RedirectBC;
    
    //Adapter's classes 
    abstract class Adapter
    {
        //Used to identify the class
        public string _name;
        //
        public Adapter(string name)
        {
            this._name = name;
        }
        public void Raport()
        {
            foreach (string item in CreateList())
            {
                Console.WriteLine("     {0}", item);
            }
        }
        abstract public List<string> CreateList();
   }//   
   class RealAdapter : Adapter
   { 
        public  RealAdapter(string name)
                        :base(name){}
        
       //The decision method
        public override List<string> CreateList()
        {
            switch (_name)
            {
                case "Staff":
                    return new Staff().StaffList();

                case "Products":
                    return new Products().ProductsList();
            
                default:
                    Console.WriteLine("Wrong case!");
                    return null;
            }
        }
    }//
    //The concrets classes 
    public class Products
    {
       public List<string> ProductsList()
       {
           List<string> productsList = new List<string>();

           productsList.Add("Product List:");
           productsList.Add("Fridge");
           productsList.Add("Washing Machine");
           productsList.Add("Vacuum cleaner");
           return productsList;
       }
    }//
    public class Staff
    {
        public List<string> StaffList()
        {
            List<string> staffList = new List<string>();
     
            staffList.Add("Staff List:");
            staffList.Add("We do not share personal information.");
            return staffList;
        }
    }//
    class Client
    {
        static void Main(string[] args)
        {
            //Redirect.Open();

            Console.WriteLine("\n   ============  Adapter Pattern ============\n");
            
            Adapter
            adapter = new RealAdapter("Products");
            adapter.Raport();

            Console.WriteLine("\n   -------------------------------------------\n");
            adapter = new RealAdapter("Staff");
            adapter.Raport();            
        
            Console.WriteLine("\n   ==========================================\n");
            Console.ReadLine();

            //Redirect.Close();
        }
    }//
    /*output:
    ============  Adapter Pattern ============
    
        Product List:
     Fridge
     Washing Machine
     Vacuum cleaner
     
     -------------------------------------------

        Staff List:
     We do not share personal information.

    ==========================================
    */