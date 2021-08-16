using System;
using System.Data.Entity;
using WebApiSelfHostBC.Context;
using WebApiSelfHostBC.Models;

namespace WebApiSelfHostBC.Seed
{
    public class DbInitializer : DropCreateDatabaseAlways<Context.Context>
    {
        protected override void Seed(Context.Context context)
        {
            context.Companys.AddRange(new Company[] {
                new Company {
                    Name = "Name Alfa A ", //
                    EstablishmentYear = 100,
                    Employees = new Employee[] {
                        new Employee {
                            FirstName = "FirstA1",
                            LastName = "LastA1",
                            DateOfBirth = new DateTime(1970, 7, 7),
                            JobTitle  = JobTitle.Administrator
                        }                 
                    }
                },
                 new Company {
                    Name = "Name  B",
                    EstablishmentYear = 100,
                    Employees = new Employee[] {
                        new Employee {
                            FirstName = "FirstAlfaB1", //
                            LastName = "LastB1",
                            DateOfBirth = new DateTime(1970, 7, 7),
                            JobTitle  = JobTitle.Administrator
                        }
                    }
                },
                 new Company {
                    Name = "Name  C",
                    EstablishmentYear = 100,
                    Employees = new Employee[] {
                        new Employee {
                            FirstName = "FirstC1",
                            LastName = "LastC1",
                            DateOfBirth = new DateTime(1970, 7, 7),
                            JobTitle  = JobTitle.Manager
                        },
                        new Employee {
                            FirstName = "FirstC2",
                            LastName = "LastAlfaC2", //
                            DateOfBirth = new DateTime(1970, 7, 7),
                            JobTitle  = JobTitle.Manager
                        }
                    }
                 },
                 new Company {
                    Name = "Name  D",
                    EstablishmentYear = 100,
                    Employees = new Employee[] {
                        new Employee {
                            FirstName = "FirstD",
                            LastName = "LastD",
                            DateOfBirth = new DateTime(1980, 8, 8), //
                            JobTitle  = JobTitle.Administrator
                        }
                    }
                 },
                 new Company {
                    Name = "Name  E",
                    EstablishmentYear = 5,  //
                    Employees = new Employee[] {
                        new Employee {
                            FirstName = "FirstE1",
                            LastName = "LastE1",
                            DateOfBirth = new DateTime(1970, 7, 7),
                            JobTitle  = JobTitle.Administrator
                        },
                        new Employee {
                            FirstName = "FirstE2",
                            LastName = "LastE2",
                            DateOfBirth = new DateTime(1981, 8, 8),
                            JobTitle  = JobTitle.Manager
                        }
                    }
                 },
                 new Company {
                    Name = "Name  F",
                    EstablishmentYear = 100,
                    Employees = new Employee[] {
                        new Employee {
                            FirstName = "FirstF11",
                            LastName = "LastF11",
                            DateOfBirth = new DateTime(1970, 7, 7),
                            JobTitle  = JobTitle.Administrator
                        },
                        new Employee {
                            FirstName = "FirstE21",
                            LastName = "LastE22",
                            DateOfBirth = new DateTime(1981, 8, 8),
                            JobTitle  = JobTitle.Developer //
                        }
                    }
                 },
                 new Company {
                    Name = "Name  G",
                    EstablishmentYear = 100,
                    Employees = new Employee[] {
                        new Employee {
                            FirstName = "FirstG11",
                            LastName = "LastG11",
                            DateOfBirth = new DateTime(1970, 7, 7),
                            JobTitle  = JobTitle.Administrator
                        },
                        new Employee {
                            FirstName = "FirstE21",
                            LastName = "LastE22",
                            DateOfBirth = new DateTime(1981, 8, 8),
                            JobTitle  = JobTitle.Architect //
                        }
                    }
                 }

             });
        }
    }
}
