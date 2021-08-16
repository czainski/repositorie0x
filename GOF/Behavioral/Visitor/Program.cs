    /*
    Vistor 
        The visited object takes as its parameter a object (the so-called Visitor).
      The Visitor, in turn, receives as a parameter a reference to a visited object.
      In this way, the Visitor has access to the properties and methods of the visited object.
      A Client creates an instance of a concret object witch uses its method to get the Vistator.
    */
    using System;
    //The Visitor
    abstract class  Visitor
    {
        abstract public void Visitation(Employee employee);
    }
    //The 'Concrete Visitor' classes
    class Weight : Visitor
    {
        public override void Visitation(Employee employee)
        {
            Console.WriteLine("{0} weight: {1} euro",
              employee.Name, employee.Weight);
        }
    }//
    class Vacation : Visitor
    {
        public override void Visitation(Employee employee)
        {
            Console.WriteLine("{0} vacation: {1} days", employee.Name, employee.Vacation);
        }
    }
    //The 'Concrete' class
    class Employee 
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public int Vacation { get; set; }
        //
        public void Visitation(Visitor visitor)
        {
            visitor.Visitation(this);
        }//
    }//
    class Client
    {
        static void Main()
        {
            Employee employee =  new Employee();
            employee.Name="John Petrucci";
            employee.Weight=10000;
            employee.Vacation=28;

            employee.Visitation(new Weight());
            employee.Visitation(new Vacation());

            Console.ReadKey();
        }
    }//
    /*output:
    
     John Petrucci weight: 10000 euro
     John Petrucci vacation: 28 days
    
    */
