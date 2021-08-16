
using WebApp.Models
;
using System;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public interface IRepository
    {
       // Db Context();
     
        Task<object> GetCompany(long id);
        //Task<IAsyncEnumerable<Company>> GetCompanys();

        Task<Object> GetCompanys();

        Task<string> CreateCompany(Company company);
        Task UpdateCompany(long id, Company company);
        Task DeleteCompany(int id);
        Task<object> CompanysSearcher(Criterion criterion);
    }
}
