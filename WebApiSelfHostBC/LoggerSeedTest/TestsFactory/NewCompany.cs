using WebApiSelfHostBC.Models;
using System;
namespace WebApiSelfHostBC.Seed
{
    public class NewCompany
    {
        static int i = 500;
        Company company;
        public   NewCompany() 
        {
            company =  new Company
            {
                Name = "Name" + i,
                EstablishmentYear = 100,
                Employees = new Employee[] {
                        new Employee {
                            FirstName = "FirstNameA"+i,
                            LastName = "LastNameA"+i,
                            DateOfBirth = new DateTime(1990, 9,9),
                            JobTitle  = JobTitle.Administrator
                        },
                        new Employee {
                             FirstName = "FirstNameB"+i,
                            LastName = "LastNameB"+i,
                            DateOfBirth = new DateTime(1999, 8,8),
                            JobTitle  = JobTitle.Manager
                        },
                    }
            };
            i++;
        }
        public Company Get() =>   company;
    }
}
 

