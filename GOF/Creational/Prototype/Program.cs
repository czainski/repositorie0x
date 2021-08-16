    using System;
    using System.Collections.Generic;
    using RedirectBC;
    
    class Manager
    {
        private Dictionary<string, Prototype>
        _dictionary = new Dictionary<string, Prototype>();

        public Prototype this[string key]
        {
            get { return _dictionary[key]; }
            set { _dictionary.Add(key, value); }
        }
        public Dictionary<string, Prototype> Dictionary() 
        {
            return _dictionary;
        }
    }
    //// The 'Prototype' abstract class
    abstract class Prototype
    {
        public Prototype Clone()
        {
            return this.MemberwiseClone() as Prototype;
        }
    }
    ////The 'Concrete' Classes  
    class Employee : Prototype
    {
        //
        public string FirstName   {  set; get; }
        public string LastName    {  set ; get;}
        public string Departament {  set ; get;}

    }
    class Car : Prototype
    {
        public string Name  { set ; get ; }
        public string Type { set; get; }
    }
    ////
    class Client
    {
        ////
        static void Main()
        {
          //  Redirect.Open();

            ////KLasa indeksowana
            Manager  manager = new Manager();
            ////
            Employee employee = null;

            employee = new Employee();
            employee.FirstName="Jhon";
            employee.LastName = "Smith";
            employee.Departament = "Mobile Phone Departament ";
            //
            manager["Employee1"] = employee ;
            //
            employee = employee.Clone() as Employee; ;
            employee.FirstName = "Adam";
            employee.LastName = "Grege";
            
            manager["Employee2"] = employee;
            ////            
            Car car = null;

            car = new Car();
            car.Name = "Fiat";
            car.Type = "Punto";
            //
            manager["Car1"] = car;
            //
            car = car.Clone() as Car ;
            car.Type = "Uno";
            //
            manager["Car2"] = car;

            Write(manager);

          //  Redirect.Close();
            Console.ReadKey();
        }
        static void Write(Manager manager)
        {
            Console.WriteLine();
            foreach (KeyValuePair<string, Prototype> entry in manager.Dictionary())
            {
                if (entry.Value.GetType() == typeof(Employee))
                {
                    Employee employee = entry.Value as Employee;
                    Console.WriteLine(employee.FirstName + " " + employee.LastName + " " + employee.Departament);
                }
                else if (entry.Value.GetType() == typeof(Car))
                {
                    Car car = entry.Value as Car;
                    Console.WriteLine(car.Name + " " + car.Type);
                }
                else
                {
                    Console.WriteLine("Error");
                }
            }
        }
    }
    /* output:

        Jhon Smith Mobile Phone Departament 
        Adam Grege Mobile Phone Departament 
        Fiat Punto
        Fiat Uno
     
     */

