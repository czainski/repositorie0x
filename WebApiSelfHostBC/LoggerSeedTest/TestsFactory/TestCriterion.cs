using WebApiSelfHostBC.CompanyCriterions;
using WebApiSelfHostBC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiSelfHostBC.Seed.TestsFactory
{
    public static class TestCriterion
    {
        static Criterion criterion;
        static TestCriterion()
        {
            criterion = new Criterion
            {
                Keyword                           = "Alfa",
                EstablishmentYearFrom      = 2,
                EstablishmentYearTo          = 7,
                EmployeeDateOfBirthFrom = new DateTime(1980,  1,  1),
                EmployeeDateOfBirthTo     = new DateTime(1981,12, 31),
                EmployeeJobTitles             = new int[] 
                                                        { (int)JobTitle.Architect, (int)JobTitle.Developer }
            };
        }
        public static Criterion Get() => criterion; 
     }
}
