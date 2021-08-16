    /*
    Flyweight:
        Depending on the parameters, it generates
    and memorizes the corresponding concrete classes objects 
    in the array and returns its references to the client. 
        Concrete classes implement a common interface.
        The Table allows grouping or selecting
    stored objects. Object selection can be eg. through
    recognizing the type of object.
    */
    using System;
    using System.Collections.Generic;
    using RedirectBC;

    //
    abstract class  Staff
    {
        public string _FirstName { set; get; }
        public string _LastName { set; get; }
        public string _Department { set; get; }
        //
        public abstract  void Recipience(string FirstName, string LastName);
    }//
    class Manager : Staff
    {
        public Manager(string Department)
        {
            _Department = Department;
        }
        public override void Recipience(string FirstName, string LastName)
        {
            Console.WriteLine("\n{0} {1} - Manager for: {2}", FirstName, LastName, _Department);
            _FirstName  = FirstName;
            _LastName   = LastName;
        }
    }//
    class Employee : Staff
    {
        public Employee(string Department)
        {
            _Department = Department;
        }
        public override void Recipience(string FirstName, string LastName)
        {
            Console.WriteLine("{0} {1} - Employee for Department: {2}", FirstName,  LastName,  _Department);
        
            _FirstName  = FirstName;
            _LastName   = LastName;
        }
    }//
    class FlyweightFactory
    {
        //All objects which had been generated 
        List<Staff> _flyweightFactoryObiects = new List<Staff>();

        //Generate and store the appropriate class
        public Staff CreateSaveObject(string nameClass, string Department)
        {
            Staff staff;
            switch (nameClass)
            {
                case "Manager":
                    staff = new Manager(Department);
                    break;
                case "Employee":
                    staff = new Employee(Department);
                    break;
                default:
                    throw new Exception("Invalid parameter!");
            }
            _flyweightFactoryObiects.Add(staff);
            return staff;
        }   
        public void Count()
        {
             Console.WriteLine("\nStaff consists of {0} people.", _flyweightFactoryObiects.Count);
        }
        //Select only managers
        public void Managers() 
        {
            Console.WriteLine("\n\n");
            foreach (Staff staff in _flyweightFactoryObiects)
            {
                System.Type type = staff.GetType();
                if (type.ToString()=="Manager")
                {
                    Console.WriteLine("{0} {1} - Maganer of: {2}", staff._FirstName, staff._LastName, staff._Department);
                }
            }
        }
    }//
    class Client
    {
        static void Main(string[] args)
        {
            Redirect.Open();

            FlyweightFactory flyweightFactory = new FlyweightFactory();

            Staff employment = flyweightFactory.CreateSaveObject("Manager", "Cloud Services");
            employment.Recipience("Samuel", "Anderson");
            // 
            employment = flyweightFactory.CreateSaveObject("Employee", "Cloud Services");
            employment.Recipience("Rowan", "Atkinson");

            employment = flyweightFactory.CreateSaveObject("Employee", "Cloud Services");
            employment.Recipience("James", "Bachman");

            employment = flyweightFactory.CreateSaveObject("Manager", "Cloud Platforms");
            employment.Recipience("Harold", "Bennett");

            //Synthetic analysis
            flyweightFactory.Managers();
            flyweightFactory.Count(); 
    
            //Console.ReadKey();
            Redirect.Close();
        }
    }//
	/*output:
	
	Samuel Anderson - Manager for: Cloud Services
	Rowan Atkinson - Employee for Department: Cloud Services
	James Bachman - Employee for Department: Cloud Services

	Harold Bennett - Manager for: Cloud Platforms

	Samuel Anderson - Maganer of: Cloud Services
	Harold Bennett - Maganer of: Cloud Platforms

	Staff consists of 4 people.

	*/