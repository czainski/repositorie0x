using Newtonsoft.Json;
using WebApp.Models
;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WebApp.Models
{
    public class Repository : IRepository {
        public Context context { get; }
        public Repository(Context ctx) => context = ctx;
        public Context Context() => context;
        public async Task<object> GetCompany(long id)
        {
            try
            {
                var company = await Task.Run(()=> context.Companys
                             .OrderBy(p => p.Id)
                             .Select(p => new { p.Id, p.Name, p.EstablishmentYear, p.Employees })
                             .FirstOrDefault(p => p.Id == id));

                if (company != null) return company;
                return new Message { Alert = "Not Found a company with Id=" + id };
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(new Message { Alert = ex.GetType() + "! - not create a new company!!!" });
            }
        }
        //
        public async Task<Object> GetCompanys()
        {
            try
            {
                return await Task.Run(() => context.Companys
                         .OrderBy(p => p.Id)
                         .Select(p => new { p.Id, p.Name, p.EstablishmentYear, p.Employees }));
            }
            catch (Exception ex)
            {
                return new Message { Alert = "GetCompanys:  " + ex.GetType().FullName };
            }
        }
        //
        public async Task<object> CompanysSearcher(Criterion criterion) 
        {
            try
            {
                var companys =await Task.Run(()=> context.Companys
                            .Where(e => e.Name.Contains(criterion.Keyword)
                                || (e.EstablishmentYear >= criterion.EstablishmentYearFrom && e.EstablishmentYear <= criterion.EstablishmentYearTo))
                            .Select(e => e.Id));

                var hashSet = new HashSet<long>(companys); companys = null;
                var employees = await Task.Run(() => context.Employees
                                 .Where(e => (e.DateOfBirth >= criterion.EmployeeDateOfBirthFrom && e.DateOfBirth <= criterion.EmployeeDateOfBirthTo)
                                            || criterion.EmployeeJobTitles.Contains((int)e.JobTitle)
                                            || e.FirstName.Contains(criterion.Keyword) 
                                            || e.LastName.Contains(criterion.Keyword))
                                .Select(e => e.CompanyId));

                hashSet.UnionWith(employees); employees = null;

                return await Task.Run(() => context.Companys.Where(e => hashSet.Contains(e.Id))
                           .OrderBy(p => p.Id)
                           .Select(p => new { p.Id, p.Name, p.EstablishmentYear, p.Employees }));
             }
            catch (Exception ex)
            {
                return new Message { Alert = "GetCompanys:  " + ex.GetType().FullName };
            }
        }
        //
        public async   Task<string> CreateCompany(Company company)
        {
            try
            {
                context.Companys.Add(company);
                await   context.SaveChangesAsync();
                company = context.Entry(company).Entity;
                return JsonConvert.SerializeObject(new Result { Id = company.Id });
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(new Message { Alert = ex.GetType()+"! - not create a new company!!!" });
            }
        }
        //
        Company Update(Company company, Company companyUpdate)
        {
            company.Name = companyUpdate.Name;
            company.EstablishmentYear = companyUpdate.EstablishmentYear;
            company.Employees = companyUpdate.Employees;
            return company;
        }
        //
        public async Task UpdateCompany(long id,Company companyUpdate)
        {
            try
            {
                var company = await Task.Run(()=> context.Companys.FirstOrDefault(p => p.Id == id));
                if (company == null)
                    Console.WriteLine("Update : Not found a company with Id ={0} !!!", id);
                else
                {
                    company = await Task.Run(() => Update(company, companyUpdate));
                    await    context.SaveChangesAsync();
                    Console.WriteLine("Update a company with Id={0} is OK.  ", id);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("UpdateCompany:  " + ex.GetType().FullName);
            }
        }
        //
        public async Task DeleteCompany(int id)
        {
            try
            {
                var company = await  Task.Run(()=> (from p in context.Companys
                           where p.Id == id
                           select p).FirstOrDefault());

                if (company == null)
                {
                    Console.WriteLine("Delete: Not found  company with Id={0}", id);
                    return;
                }
                context.Companys.Remove(company);
                await context.SaveChangesAsync();
                Console.WriteLine("Delete a company with Id={0} is OK.  ", id);
            }
            catch (Exception ex)
            {
                Console.WriteLine("DeleteCompany:  " + ex.GetType().FullName);
            }
        }
        //
    }
}
