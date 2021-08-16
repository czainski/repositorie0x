using WebApiSelfHostBC.CompanyCriterions;
using WebApiSelfHostBC.Context;
using System.Threading.Tasks;

namespace WebApiSelfHostBC.Models
{
    public interface IRepository
    {
        Context.Context Context();
     
        Task<object> GetCompany(long id);
        Task<object> GetCompanys();
        Task<string> CreateCompany(Company company);
        Task UpdateCompany(long id, Company company);
        Task DeleteCompany(int id);
        Task<object> CompanysSearcher(Criterion criterion);
    }
}
