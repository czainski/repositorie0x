#region Using namespaces
using WebApiSelfHostBC.Models;
using WebApiSelfHostBC.Context;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebApiSelfHostBC.BasicAuthentication;
using System;
using System.Data.Entity;
using WebApiSelfHostBC.CompanyCriterions;
using System.Threading.Tasks;

#endregion

namespace WebApiSelfHostBC
{
     public class CompanyController : ApiController
    {
        bool _dataBaseNotExist = false;
        IRepository _repository = null;
        public CompanyController() 
        { 
            _repository =  UnitOfWork.SQLServer(false);
            if (_repository == null)
            {
                Console.WriteLine("Not found a data base !!!");
                _dataBaseNotExist = true;
            }  
        }

        [HttpGet]
        [ActionName("all")]
        [BasicAuthentication]
        public async Task<object> Get() 
        {
            if (_dataBaseNotExist) return null;
            try
            {
                return await _repository.GetCompanys();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Get:all:" + " :" + ex.GetType().FullName);
                return null;
                //   throw;
            }
        }
        //
        [HttpGet]
        [ActionName("any")]
        [BasicAuthentication]
        public async Task<object> Get( long id)
        {
            if (_dataBaseNotExist) return null;
            try
            {
                return await _repository.GetCompany(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Get:any: " + " :" + ex.GetType().FullName);
                return null;
                //   throw;
            }
        }
        //  
        [HttpPost]
        [ActionName("create")]
        [BasicAuthentication]
        public async Task< object> Post([FromBody] Company company) 
        {
            if (_dataBaseNotExist) return null;
            try
            {
               return await _repository.CreateCompany(company) ;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Post:create: " + ex.GetType().FullName);
                return null;
            }
        }
                
        [HttpPost]
        [ActionName("search")]
        public async Task<object> Post([FromBody] Criterion criterion)
        {
            if (criterion == null || _dataBaseNotExist) { 
                Console.WriteLine("Post:search:criterion == null || _dataBaseNotExist ");
                return null;
            }
            try
            {
                return await  _repository.CompanysSearcher(criterion);
            }
            catch (System.NullReferenceException ex)
            {
                Console.WriteLine("Post:search:" + ex.GetType().FullName);
                return null;
            }
        }

        [HttpPut]
        [ActionName("update")]
        [BasicAuthentication]
        public  async Task Put(int id, [FromBody] Company company)
        {
            if (_dataBaseNotExist) return;
            try
            {
                await _repository.UpdateCompany(id, company);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Put:update: " + ex.GetType().FullName);
            }
        }

        [HttpDelete]
        [ActionName("delete")]
        [BasicAuthentication]
        public async Task Delete(int id)
        {
            if (_dataBaseNotExist) return;
            try
            {
                await  _repository.DeleteCompany(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Delete:delete: " + ex.GetType().FullName);
            }
        }
    }
}